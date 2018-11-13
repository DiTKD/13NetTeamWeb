using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _13NetTeam.Core.Contexts;
using _13NetTeam.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _13NetTeam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespostasController : ControllerBase
    {
        private readonly Context _context;

        public RespostasController(Context context)
        {
            _context = context;
        }



        // GET: api/Respostas
        [HttpGet("{id_pergunta}")]
        public async Task<IActionResult> GetRespostas([FromRoute] int id_pergunta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pergunta = await _context.Perguntas.FindAsync(id_pergunta);

            if (pergunta == null)
            {
                return NotFound();
            }

            return Ok(pergunta.Respostas);
        }

        // POST: api/Resposta
        [HttpPost]
        public async Task<IActionResult> PostResposta(int id_pergunta, [FromBody]  Resposta resposta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Perguntas.First(p => p.Id == id_pergunta).Respostas.Add(resposta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRespostas", new { id = id_pergunta });
        }
    }
}