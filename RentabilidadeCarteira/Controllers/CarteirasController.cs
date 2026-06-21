using Microsoft.AspNetCore.Mvc;
using RentabilidadeCarteira.Interfaces;
using RentabilidadeCarteira.Models.Requests;

namespace RentabilidadeCarteira.Controllers
{
    [ApiController]
    [Route("api/carteiras")]
    public class CarteirasController : ControllerBase
    {
        private readonly ICarteiraService _carteiraService;

        public CarteirasController(ICarteiraService carteiraService)
        {
            _carteiraService = carteiraService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var carteiras = _carteiraService.GetAll();
                return Ok(carteiras);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var carteira = _carteiraService.GetById(id);
                if(carteira == null)
                    return NotFound();

                return Ok(carteira);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CarteiraRequest request)
        {
            try
            {
                var carteira = _carteiraService.Create(request);
                return CreatedAtAction(nameof(GetById), new { id = carteira.Id }, carteira);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
    }

}
