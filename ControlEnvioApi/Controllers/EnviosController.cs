using ControlEnvioApi.Models;
using ControlEnvioApi.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ControlEnvioApi.Controllers
{
    [ApiController]
    [Route("api / [controller]")]
    public class EnviosController : Controller
    {
        private readonly IEnviosService _enviosService;
        public EnviosController(IEnviosService enviosService)
        {
            _enviosService = enviosService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_enviosService.GetAll());

        [HttpGet("{id}")]
        public IActionResult getById(Guid id)
        {
            var envio = _enviosService.getById(id);
            //Refactoriza
            return envio != null ? Ok(envio) : NotFound("Error. No existe el envío.");
        }

        [HttpGet("price-calculator {id}")]
        public IActionResult getPrice(Guid id)
        {
            var precio = _enviosService.getPrice(id);
            //Refactoriza
            return precio != null ? Ok($"El precio del envio hacia {} con ID: {id} es de ${precio}.") : NotFound("Error. No existe el envío.");
        }


    }
}
