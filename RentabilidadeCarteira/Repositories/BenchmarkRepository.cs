using ClosedXML.Excel;
using RentabilidadeCarteira.Excel;
using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Entities;

namespace RentabilidadeCarteira.Repositories
{
    public class BenchmarkRepository : IBenchmarkRepository
    {
        private readonly IExcelContext _excel;

        public BenchmarkRepository(IExcelContext excel)
        {
            _excel = excel;
        }

        public Benchmark Add(Benchmark benchmark)
        {
            using var workbook = _excel.Open();
            var sheet = workbook.Worksheet("Benchmarks");

            var nextRow = sheet.LastRowUsed()!.RowNumber() + 1;
            benchmark.Id = NextId(sheet);

            sheet.Cell(nextRow, 1).Value = benchmark.Id;
            sheet.Cell(nextRow, 2).Value = benchmark.Nome;
            sheet.Cell(nextRow, 3).Value = benchmark.Codigo;

            workbook.Save();
            return benchmark;
        }

        public IReadOnlyList<Benchmark> GetAll()
        {
            throw new NotImplementedException();
        }

        public Benchmark? GetById(int id)
        {
            return GetAll().FirstOrDefault(b => b.Id == id);
        }
        private static int NextId(IXLWorksheet sheet)
        {
            var ids = sheet.RowsUsed().Skip(1).Select(r => r.Cell(1).GetValue<int>()).ToList();
            return ids.Count == 0 ? 1 : ids.Max() + 1;
        }
    }
}
