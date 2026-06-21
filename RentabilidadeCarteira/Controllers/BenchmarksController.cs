using Microsoft.AspNetCore.Mvc;
using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Requests;

namespace RentabilidadeCarteira.Controllers
{
    [ApiController]
    [Route("api/benchmarks")]
    public class BenchmarksController : ControllerBase
    {
        private readonly IBenchmarkService _benchmarkService;

        public BenchmarksController(IBenchmarkService benchmarkService)
        {
            _benchmarkService = benchmarkService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var benchmarks = _benchmarkService.GetAll();
            return Ok(benchmarks);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var benchmark = _benchmarkService.GetById(id);
            if (benchmark == null)
                return NotFound();
            
            return Ok(benchmark);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BenchmarkRequest request)
        {
            if (request == null)
                return BadRequest();

            var createdBenchmark = _benchmarkService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = createdBenchmark.Id }, createdBenchmark);
        }
    }
}
