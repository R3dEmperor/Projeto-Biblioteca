using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Biblioteca.WEB.Data;
using Projeto_Biblioteca.WEB.Models;

namespace Projeto_Biblioteca.WEB.Controllers
{
    public class GeneroesController : Controller
    {
        private readonly Projeto_BibliotecaWEBContext _context;

        public GeneroesController(Projeto_BibliotecaWEBContext context)
        {
            _context = context;
        }

        // GET: Generoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Genero.ToListAsync());
        }

        // GET: Generoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.Genero
                .FirstOrDefaultAsync(m => m.Id_Genero == id);
            if (genero == null)
            {
                return NotFound();
            }

            return View(genero);
        }

        // GET: Generoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Generoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Genero,Descricao_Genero,Classificacao_Genero")] Genero genero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genero);
        }

        // GET: Generoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.Genero.FindAsync(id);
            if (genero == null)
            {
                return NotFound();
            }
            return View(genero);
        }

        // POST: Generoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Genero,Descricao_Genero,Classificacao_Genero")] Genero genero)
        {
            if (id != genero.Id_Genero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneroExists(genero.Id_Genero))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(genero);
        }

        // GET: Generoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.Genero
                .FirstOrDefaultAsync(m => m.Id_Genero == id);
            if (genero == null)
            {
                return NotFound();
            }

            return View(genero);
        }

        // POST: Generoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genero = await _context.Genero.FindAsync(id);
            if (genero != null)
            {
                _context.Genero.Remove(genero);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneroExists(int id)
        {
            return _context.Genero.Any(e => e.Id_Genero == id);
        }
    }
}
