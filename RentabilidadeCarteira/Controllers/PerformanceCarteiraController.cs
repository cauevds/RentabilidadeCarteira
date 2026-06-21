using Microsoft.AspNetCore.Mvc;
using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Requests;

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

        [HttpPost]
        public IActionResult Register([FromBody] List<PerformanceCarteiraRequest> requests)
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
