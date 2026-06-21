using Microsoft.AspNetCore.Mvc;
using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Requests;

namespace RentabilidadeCarteira.Controllers
{
    [ApiController]
    [Route("api/relatorios")]
    public class RelatoriosController : ControllerBase
    {
        private readonly IReportService _reportService;

        public RelatoriosController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("performance")]

        public IActionResult GeneratePerformanceReport([FromBody] ReportRequest request)
        {
            try
            {
                var report = _reportService.GerarRelatorio(request);
                return Ok(report);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
    }

}
