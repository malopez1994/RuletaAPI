using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuletaAPI.Modelo;
using RuletaAPI.Request;
using RuletaAPI.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuletaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RuletaController : Controller
    {
        private IRuletaServicio ruletaServicio;
        public RuletaController(IRuletaServicio _ruletaServicio)
        {
            this.ruletaServicio = _ruletaServicio;
        }
        [HttpPut("{id}/Abrir")]
        public IActionResult Abrir([FromRoute(Name = "id")] string id)
        {
            try
            {
                ruletaServicio.Abrir(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(405);
            }
        }
        [HttpPut("{id}/Cerrar")]
        public IActionResult Cerrar([FromRoute(Name = "id")] string id)
        {
            try
            {
                Ruleta ruleta = ruletaServicio.Cerrar(id);
                return Ok(ruleta);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(405);
            }
        }

        [HttpPost("{id}/Apuesta")]
        public IActionResult Apuesta([FromHeader(Name = "user-id")] string UserId, [FromRoute(Name = "id")] string id,
            [FromBody] RequestApuesta request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    error = true,
                    msg = "Bad Request"
                });
            }

            try
            {
                Ruleta ruleta = ruletaServicio.Apuesta(id, UserId, request.Ubicacion, request.ValorApostado);
                return Ok(ruleta);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(405);
            }

        }

        [HttpGet]
        public IActionResult ListadoRuletas()
        {
            return Ok(ruletaServicio.ListadoRuletas());
        }
        [HttpPost]
        public IActionResult NuevaRuleta()
        {
            Ruleta ruleta = ruletaServicio.creacion();
            return Ok(ruleta);
        }
    }
}
