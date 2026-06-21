using RentabilidadeCarteira.Models.Requests;
using RentabilidadeCarteira.Models.Responses;

namespace RentabilidadeCarteira.Interfaces
{
    public interface IReportService
    {
        ReportResponse GerarRelatorio(ReportRequest request);

    }
}
