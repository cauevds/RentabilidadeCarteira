using Microsoft.AspNetCore.Mvc;
using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Entities;
using RentabilidadeCarteira.Models.Requests;
using RentabilidadeCarteira.Models.Responses;

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

        [ProducesResponseType(typeof(BenchmarkResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var benchmarks = _benchmarkService.GetAll();
            if(benchmarks == null || benchmarks.Count == 0)
                return NotFound();

            return Ok(benchmarks);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(BenchmarkResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var benchmark = _benchmarkService.GetById(id);
            if (benchmark == null)
                return NotFound();
            
            return Ok(benchmark);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BenchmarkResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] BenchmarkRequest request)
        {
            if (request == null)
                return BadRequest();

            var createdBenchmark = _benchmarkService.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = createdBenchmark.Id }, createdBenchmark);
        }
    }
}
