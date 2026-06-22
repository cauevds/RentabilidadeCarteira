using ClosedXML.Excel;

namespace RentabilidadeCarteira.Excel
{
    public interface IExcelContext
    {
        string FilePath { get; }
        void EnsureInitialized();
        XLWorkbook Open();

    }
}
