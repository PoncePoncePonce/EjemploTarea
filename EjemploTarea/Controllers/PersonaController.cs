using Business.Interfaces;
using Business.Modelos;
using EjemploTarea.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EjemploTarea.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    [Route("persona/{version:apiVersion}")]
    public class PersonaController : ControllerBase
    {
        private readonly ILogger<PersonaController> logger;
        private readonly IPersonaService _service;
        private readonly IConfiguration _config;
        public PersonaController(ILogger<PersonaController> logger, IPersonaService service, IConfiguration config)
        {
            this.logger = logger;
            _service = service;
            _config = config;
        }
        [HttpPost(),MapToApiVersion("1.0")]
        public ActionResult CrearPersona([FromBody] PersonaDto persona)
        {
            try
            {
                var result = _service.AgregarPersona(persona.Nombre, persona.Apellido, persona.edad);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet(),MapToApiVersion("1.0")]
        public ActionResult ConsultarPersonas()
        {
            try
            {
                var result = _service.ConsultarPersona();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //--------------------------ConsultarPersona trae todo, ConsultarPersonaSSSSSS trae las paginadas--------------------------------------
        [HttpGet(), MapToApiVersion("2.0")]
        public ActionResult ConsultarPersonasv2([FromQuery] PersonaParameters parameters)
        {
            try
            {
                var result = _service.ConsultarPersonas(parameters);

                var metadata = new
                {
                    result.TotalCount,
                    result.PageSize,
                    result.CurrentPage,
                    result.TotalPages,
                    result.HasNext,
                    result.HasPrevious
                };
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                logger.LogInformation($"Returned {result.TotalCount} personas from database");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{Id}"), MapToApiVersion("1.0")]
        public ActionResult ConsultarPersonasPorId([FromRoute] string id)
        {
            try
            {
                var result = _service.ConsultarPersonaPorId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{Id}"), MapToApiVersion("1.0")]
        public ActionResult ActualizarPersona([FromRoute] string id, [FromBody] PersonaDto persona)
        {
            try
            {
                var result = _service.ActualizarPersona(id, persona.Nombre, persona.Apellido, persona.edad);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{Id}"), MapToApiVersion("1.0")]
        public ActionResult EliminarPersona([FromRoute] string id) 
        {
            try
            {
                var result = _service.EliminarPersona(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

    //[ApiVersion("2.O")]
    //[ApiController]
    //[Route("persona")]
    //public class PersonaController2: ControllerBase
    //{
    //    private readonly ILogger<PersonaController2> logger;
    //    private readonly IPersonaService _service;
    //    private readonly IConfiguration _config;
    //    public PersonaController2(ILogger<PersonaController2> logger, IPersonaService service, IConfiguration config)
    //    {
    //        this.logger = logger;
    //        _service = service;
    //        _config = config;
    //    }
    //    [HttpGet()]
    //    public ActionResult ConsultarPersonas()
    //    {
    //        try
    //        {
    //            var result = _service.ConsultarPersona();
    //            return Ok(result);
    //        }
    //        catch (Exception ex)
    //        {
    //            return StatusCode(500, ex.Message);
    //        }
    //    }
    //}
}