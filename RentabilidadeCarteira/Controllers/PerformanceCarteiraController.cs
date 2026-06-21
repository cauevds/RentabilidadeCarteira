using Microsoft.AspNetCore.Mvc;
using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Requests;
using RentabilidadeCarteira.Models.Responses;

namespace RentabilidadeCarteira.Controllers
{
    [ApiController]
    [Route("api/performance-carteira")]
    public class PerformanceCarteiraController : ControllerBase
    {
        private readonly IPerformanceService _performanceService;

        public PerformanceCarteiraController(IPerformanceService performanceService)
        {
            _performanceService = performanceService;
        }

        /// <summary>
        /// Retorna o relatório de performance da carteira.
        /// </summary>
        /// <summary>Formato yyyy-MM.</summary>
        /// <summary>Rentabilidade mensal em percentual (ex.: 1.20 = 1,20%).</summary>
        [HttpPost]
        [ProducesResponseType(typeof(PerformanceCarteiraResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Create([FromBody] List<PerformanceCarteiraRequest> requests)
        {
            try
            {
                var performance = _performanceService.RegisterCarteiraPerformance(requests);
                return Ok(performance);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
    }
}
