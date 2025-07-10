using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionInventariosConAutenticacion.Data;
using GestionInventariosConAutenticacion.Models;

namespace GestionInventariosConAutenticacion.Controllers
{
    public class CategoríaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoríaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categoría
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categoría.ToListAsync());
        }

        // GET: Categoría/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoría = await _context.Categoría
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoría == null)
            {
                return NotFound();
            }

            return View(categoría);
        }

        // GET: Categoría/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoría/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripción")] Categoría categoría)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoría);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoría);
        }

        // GET: Categoría/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoría = await _context.Categoría.FindAsync(id);
            if (categoría == null)
            {
                return NotFound();
            }
            return View(categoría);
        }

        // POST: Categoría/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripción")] Categoría categoría)
        {
            if (id != categoría.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoría);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoríaExists(categoría.Id))
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
            return View(categoría);
        }

        // GET: Categoría/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoría = await _context.Categoría
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoría == null)
            {
                return NotFound();
            }

            return View(categoría);
        }

        // POST: Categoría/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoría = await _context.Categoría.FindAsync(id);
            if (categoría != null)
            {
                _context.Categoría.Remove(categoría);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoríaExists(int id)
        {
            return _context.Categoría.Any(e => e.Id == id);
        }
    }
}
