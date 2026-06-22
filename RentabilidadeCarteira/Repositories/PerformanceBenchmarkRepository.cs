using RentabilidadeCarteira.Excel;
using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Entities;

namespace RentabilidadeCarteira.Repositories
{
    public class PerformanceBenchmarkRepository : IPerformanceBenchmarkRepository
    {
        private readonly IExcelContext _excel;

        public PerformanceBenchmarkRepository(IExcelContext excel)
        {
            _excel = excel;
        }

        public IReadOnlyList<PerformanceBenchmark> GetByBenchmark(int benchmarkId)
        {
            using var workbook = _excel.Open();
            var sheet = workbook.Worksheet("PerformanceBenchmark");

            return sheet.RowsUsed().Skip(1)
                .Select(row => new PerformanceBenchmark
                {
                    Id = row.Cell(1).GetValue<int>(),
                    BenchmarkId = row.Cell(2).GetValue<int>(),
                    Competencia = row.Cell(3).GetString(),
                    Rentabilidade = row.Cell(4).GetValue<decimal>()
                })
                .Where(p => p.BenchmarkId == benchmarkId)
                .ToList();
        }
    }
}
