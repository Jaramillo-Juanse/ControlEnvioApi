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
            var envio = _enviosService.getById(id);
            //Refactoriza
            return precio != 0.0f ? Ok($"El precio del envío hacia {envio.destino} es de ${precio}.\n (ID:{id})") : NotFound("Error. No existe el envío.");
        }
        [HttpPost]
        public IActionResult Create([FromBody] Envios newEnvio)
        {
            var createdEnvio = _enviosService.Create(newEnvio);
            return CreatedAtAction(nameof(getById), new { id = createdEnvio.id }, createdEnvio);

        }
        [HttpPut]
        public IActionResult Update(Guid id, [FromBody] Envios editedEnvio)
        {
            return _enviosService.Update(id, editedEnvio) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public IActionResult ChangeStatus(Guid id)
        {
            return _enviosService.ChangeStatus(id) ? Ok($"Se ha cambiado el estado del envío ID:{id}.") : NotFound();
        }

    }
}
