using ClosedXML.Excel;
using RentabilidadeCarteira.Excel;
using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Entities;

namespace RentabilidadeCarteira.Repositories
{
    public class CarteiraRepository : ICarteiraRepository
    {
        private readonly IExcelContext _excel;

        public CarteiraRepository(IExcelContext excel)
        {
            _excel = excel;
        }

        public IReadOnlyList<Carteira> GetAll()
        {
            using var workbook = _excel.Open();
            var sheet = workbook.Worksheet("Carteiras");

            return sheet.RowsUsed().Skip(1).Select(row => new Carteira
            {
                Id = row.Cell(1).GetValue<int>(),
                Nome = row.Cell(2).GetString(),
                Cliente = row.Cell(3).GetString(),
                Status = row.Cell(4).GetString()
            }).ToList();
        }
        public Carteira? GetById(int id)
        {
            return GetAll().FirstOrDefault(c => c.Id == id);
        }

        public Carteira Add(Carteira carteira)
        {
            using var workbook = _excel.Open();
            var sheet = workbook.Worksheet("Carteiras");

            var nextRow = sheet.LastRowUsed()!.RowNumber() + 1;
            carteira.Id = NextId(sheet);

            sheet.Cell(nextRow, 1).Value = carteira.Id;
            sheet.Cell(nextRow, 2).Value = carteira.Nome;
            sheet.Cell(nextRow, 3).Value = carteira.Cliente;
            sheet.Cell(nextRow, 4).Value = carteira.Status;

            workbook.Save();
            return carteira;
        }

        private static int NextId(IXLWorksheet sheet)
        {
            var ids = sheet.RowsUsed().Skip(1).Select(r => r.Cell(1).GetValue<int>()).ToList();
            return ids.Count == 0 ? 1 : ids.Max() + 1;
        }
    }
}
