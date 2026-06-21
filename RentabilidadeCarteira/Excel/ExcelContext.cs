using ClosedXML.Excel;

namespace RentabilidadeCarteira.Excel
{
    public class ExcelContext
    {

        private static readonly object _lock = new();

        public string FilePath { get; }

        public ExcelContext(IConfiguration configuration, IHostEnvironment environment)
        {
            var configured = configuration["Excel:FilePath"];
            FilePath = string.IsNullOrWhiteSpace(configured)
                ? Path.Combine(environment.ContentRootPath, "portfolio-data.xlsx")
                : configured;
        }

        public XLWorkbook Open()
        {
            EnsureInitialized();
            return new XLWorkbook(FilePath);
        }
        public void EnsureInitialized()
        {
            lock (_lock)
            {
                if (File.Exists(FilePath))
                    return;

                using var workbook = new XLWorkbook();

                CreateSheet(workbook, "Carteiras", "Id", "Nome", "Cliente", "Status");
                CreateSheet(workbook, "Benchmarks", "Id", "Nome", "Codigo");
                CreateSheet(workbook, "PerformanceCarteira", "Id", "CarteiraId", "Competencia", "Rentabilidade");
                CreateSheet(workbook, "PerformanceBenchmark", "Id", "BenchmarkId", "Competencia", "Rentabilidade");

                Seed(workbook);

                var directory = Path.GetDirectoryName(FilePath);
                if (!string.IsNullOrEmpty(directory))
                    Directory.CreateDirectory(directory);

                workbook.SaveAs(FilePath);
            }
        }

        private static void Seed(XLWorkbook workbook)
        {
            var carteiras = workbook.Worksheet("Carteiras");
            WriteRow(carteiras, 2, 1, "Carteira Private A", "Caue Souza", "Ativa");

            var benchmarks = workbook.Worksheet("Benchmarks");
            WriteRow(benchmarks, 2, 1, "CDI", "CDI");
            WriteRow(benchmarks, 3, 2, "IBOV", "IBOV");
            WriteRow(benchmarks, 4, 3, "IPCA", "IPCA");

            var perfCarteira = workbook.Worksheet("PerformanceCarteira");
            WriteRow(perfCarteira, 2, 1, 1, "2026-01", 1.20);
            WriteRow(perfCarteira, 3, 2, 1, "2026-02", 0.80);
            WriteRow(perfCarteira, 4, 3, 1, "2026-03", 1.50);

            var perfBenchmark = workbook.Worksheet("PerformanceBenchmark");
            // CDI
            WriteRow(perfBenchmark, 2, 1, 1, "2026-01", 1.00);
            WriteRow(perfBenchmark, 3, 2, 1, "2026-02", 0.90);
            WriteRow(perfBenchmark, 4, 3, 1, "2026-03", 1.10);
            // IBOV
            WriteRow(perfBenchmark, 5, 4, 2, "2026-01", 0.50);
            WriteRow(perfBenchmark, 6, 5, 2, "2026-02", 0.50);
            WriteRow(perfBenchmark, 7, 6, 2, "2026-03", 0.50);
            // IPCA
            WriteRow(perfBenchmark, 8, 7, 3, "2026-01", 0.40);
            WriteRow(perfBenchmark, 9, 8, 3, "2026-02", 0.40);
            WriteRow(perfBenchmark, 10, 9, 3, "2026-03", 0.40);
        }

        private static void WriteRow(IXLWorksheet sheet, int row, params object[] values)
        {
            for (var i = 0; i < values.Length; i++)
            {
                var cell = sheet.Cell(row, i + 1);
                switch (values[i])
                {
                    case int intValue:
                        cell.Value = intValue;
                        break;
                    case double doubleValue:
                        cell.Value = doubleValue;
                        break;
                    default:
                        cell.SetValue(values[i].ToString()); // texto (ex.: competência yyyy-MM)
                        break;
                }
            }
        }
        private static void CreateSheet(XLWorkbook workbook, string name, params string[] headers)
        {
            var sheet = workbook.Worksheets.Add(name);
            for (var i = 0; i < headers.Length; i++)
                sheet.Cell(1, i + 1).Value = headers[i];
            sheet.Row(1).Style.Font.Bold = true;
        }
    }
}
