using ClosedXML.Excel;
using RentabilidadeCarteira.Excel;
using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Entities;

namespace RentabilidadeCarteira.Repositories
{
    public class PerformanceCarteiraRepository : IPerformanceCarteiraRepository
    {
        private readonly IExcelContext _excel;

        public PerformanceCarteiraRepository(IExcelContext excel)
        {
            _excel = excel;
        }

        public IReadOnlyList<PerformanceCarteira> GetByCarteira(int carteiraId)
        {
            return ReadAll().Where(p => p.CarteiraId == carteiraId).ToList();
        }

        public bool Exists(int carteiraId, string competencia)
        {
            return ReadAll().Any(p => p.CarteiraId == carteiraId &&
                                      string.Equals(p.Competencia, competencia, StringComparison.OrdinalIgnoreCase));
        }

        public PerformanceCarteira Add(PerformanceCarteira performance)
        {
            using var workbook = _excel.Open();
            var sheet = workbook.Worksheet("PerformanceCarteira");

            var nextRow = sheet.LastRowUsed()!.RowNumber() + 1;
            performance.Id = NextId(sheet);

            sheet.Cell(nextRow, 1).Value = performance.Id;
            sheet.Cell(nextRow, 2).Value = performance.CarteiraId;
            sheet.Cell(nextRow, 3).SetValue(performance.Competencia);
            sheet.Cell(nextRow, 4).Value = performance.Rentabilidade;

            workbook.Save();
            return performance;
        }

        private IReadOnlyList<PerformanceCarteira> ReadAll()
        {
            using var workbook = _excel.Open();
            var sheet = workbook.Worksheet("PerformanceCarteira");

            return sheet.RowsUsed().Skip(1).Select(row => new PerformanceCarteira
            {
                Id = row.Cell(1).GetValue<int>(),
                CarteiraId = row.Cell(2).GetValue<int>(),
                Competencia = row.Cell(3).GetString(),
                Rentabilidade = row.Cell(4).GetValue<decimal>()
            }).ToList();
        }

        private static int NextId(IXLWorksheet sheet)
        {
            var ids = sheet.RowsUsed().Skip(1).Select(r => r.Cell(1).GetValue<int>()).ToList();
            return ids.Count == 0 ? 1 : ids.Max() + 1;
        }
    }

}
