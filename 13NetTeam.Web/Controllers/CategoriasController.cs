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
    public class CategoriasController : Controller
    {
        private readonly Context _context;

        public CategoriasController(Context context)
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

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_pergunta")] int id_pergunta, [Bind("Autor,Descricao")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var pergunta = _context.Perguntas.Include(p => p.Tags).First(m => m.Id == id_pergunta);
                pergunta.Tags.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details//{id_pergunta}", "Perguntas");
            }
            return View(categoria);
        }
    }
}