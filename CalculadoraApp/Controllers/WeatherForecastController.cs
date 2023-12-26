using CalculadoraApp.Domain;
using CalculadoraApp.Service;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        private readonly IService _service;
        public WeatherForecastController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Calculo calculo)
        {
            var message = _service.Calculo(calculo);
            return Ok(message);
        }
        [HttpGet("GetConta")]
        public IActionResult Get()
        {
            var message = _service.Dados();
            return Ok(message);
        }
    }
}