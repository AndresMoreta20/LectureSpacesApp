using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LectureSpacesApp.Data;
using LectureSpacesApp.models;

namespace LectureSpacesApp.Controllers
{
    public class CuestionariosController : Controller
    {
        private readonly LectureSpacesAppContext _context;

        public CuestionariosController(LectureSpacesAppContext context)
        {
            _context = context;
        }

        // GET: Cuestionarios
        public async Task<IActionResult> Index()
        {
              return _context.Cuestionario != null ? 
                          View(await _context.Cuestionario.ToListAsync()) :
                          Problem("Entity set 'LectureSpacesAppContext.Cuestionario'  is null.");
        }

        // GET: Cuestionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cuestionario == null)
            {
                return NotFound();
            }

            var cuestionario = await _context.Cuestionario
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cuestionario == null)
            {
                return NotFound();
            }

            return View(cuestionario);
        }

        // GET: Cuestionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cuestionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,titulo,descripicion")] Cuestionario cuestionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cuestionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuestionario);
        }

        // GET: Cuestionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cuestionario == null)
            {
                return NotFound();
            }

            var cuestionario = await _context.Cuestionario.FindAsync(id);
            if (cuestionario == null)
            {
                return NotFound();
            }
            return View(cuestionario);
        }

        // POST: Cuestionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,titulo,descripicion")] Cuestionario cuestionario)
        {
            if (id != cuestionario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuestionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuestionarioExists(cuestionario.ID))
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
            return View(cuestionario);
        }

        // GET: Cuestionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cuestionario == null)
            {
                return NotFound();
            }

            var cuestionario = await _context.Cuestionario
                .FirstOrDefaultAsync(m => m.ID == id);
            if (cuestionario == null)
            {
                return NotFound();
            }

            return View(cuestionario);
        }

        // POST: Cuestionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cuestionario == null)
            {
                return Problem("Entity set 'LectureSpacesAppContext.Cuestionario'  is null.");
            }
            var cuestionario = await _context.Cuestionario.FindAsync(id);
            if (cuestionario != null)
            {
                _context.Cuestionario.Remove(cuestionario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuestionarioExists(int id)
        {
          return (_context.Cuestionario?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
