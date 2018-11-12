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
    public class PerguntasController : Controller
    {
        private readonly Context _context;

        public PerguntasController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
           return View(await _context.Perguntas.Include(p => p.Respostas).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Perguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Autor,Descricao")] Pergunta pergunta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pergunta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pergunta);
        }


        // GET: Perguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas.Include(p => p.Respostas).FirstOrDefaultAsync(m => m.Id == id);
           
            if (pergunta == null)
            {
                return NotFound();
            }
           

            return View(pergunta);
        }

    }
}