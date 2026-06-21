using Microsoft.AspNetCore.Mvc;
using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Requests;
using RentabilidadeCarteira.Models.Responses;

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

        /// <summary>
        /// Retorna o relatório de performance da carteira.
        /// </summary>
        /// <summary>Início do período no formato yyyy-MM.</summary>
        /// <summary>Fim do período no formato yyyy-MM.</summary>
        [HttpPost("gerar")]
        [ProducesResponseType(typeof(ReportResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GerarRelatorioPerformance([FromBody] ReportRequest request)
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
