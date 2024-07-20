using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST_DEV_API.Interfaces;
using TEST_DEV_API.Models;

namespace TEST_DEV_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasFisicasController : ControllerBase
    {

        private readonly IPersonaFisicaRepository _personaFisicaRepository;

        public PersonasFisicasController(IPersonaFisicaRepository personaFisicaRepository)
        {
            _personaFisicaRepository = personaFisicaRepository;
        }



        [HttpPost("CrearPersonaFisica")]
        public async Task<ActionResult> CrearPersonaFisica([FromBody] TbPersonasFisica nuevaPersonaFisica)
        {
            await _personaFisicaRepository.CrearPersonaFisica(nuevaPersonaFisica);

            return Ok(nuevaPersonaFisica);
        }

        [HttpGet("ObtenerPersonaFisicaPorId/{id}")]
        public async Task<ActionResult<TbPersonasFisica>> ObtenerPersonaFisicaPorId(int id)
        {

            TbPersonasFisica persona = await _personaFisicaRepository.ObtenerPersonaFisicaPorId(id);
            return Ok(persona);
        }

        [HttpGet("ObtenerPersonasFisicas")]
        public async Task<ActionResult<TbPersonasFisica>> ObtenerPersonaFisicaPorId(
                [FromQuery] string? nombre,
                [FromQuery] string? apellidoPaterno,
                [FromQuery] string? apellidoMaterno,
                [FromQuery] string? rfc,
                [FromQuery] DateTime? fechaNacimiento
            )
        {
            TbPersonasFisica persona = new TbPersonasFisica
            {
                IdPersonaFisica = 0,
                Nombre = nombre ?? "",
                ApellidoPaterno = apellidoPaterno ?? "",
                ApellidoMaterno = apellidoMaterno ?? "",
                Rfc = rfc ?? "",
                FechaNacimiento = fechaNacimiento ?? DateTime.Now,

            };

            IEnumerable<TbPersonasFisica> resultado = await _personaFisicaRepository.ObtenerPersonasFisicas(persona);

            return Ok(resultado);
        }

        [HttpPut("ActualizarPersonaFisica")]
        public async Task<ActionResult> ActualizarPersonaFisica(TbPersonasFisica personaFisica)
        {
            await _personaFisicaRepository.ActualizarPersonaFisica(personaFisica);
            return Ok();
        }

        [HttpDelete("EliminarPersonaFisica/{idPersonaFisica}")]
        public async Task<ActionResult> EliminarPersonaFisica(int idPersonaFisica)
        {
            await _personaFisicaRepository.EliminarPersonaFisica(idPersonaFisica);

            return Ok();
        }
    }
}
