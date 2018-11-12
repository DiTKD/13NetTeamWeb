using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _13NetTeam.Core.Contexts;
using _13NetTeam.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _13NetTeam.Web.Controllers
{
    public class RespostasController : Controller
    {
        private readonly Context _context;

        public RespostasController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create(int id)
        {
           
            var pergunta = await _context.Perguntas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pergunta == null)
            {
                return NotFound();
            }

            ViewBag.Pergunta = pergunta;

            return View();
        }

        // POST: Perguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_pergunta")] int id_pergunta, [Bind("Autor,Descricao")] Resposta resposta)
        {
            if (ModelState.IsValid)
            {
                var pergunta =  _context.Perguntas.Include(p => p.Respostas).First(m => m.Id == id_pergunta);
                pergunta.Respostas.Add(resposta);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details//{id_pergunta}","Perguntas");
            }
            return View(resposta);
        }
    }
}