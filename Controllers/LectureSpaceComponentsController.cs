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
    public class LectureSpaceComponentsController : Controller
    {
        private readonly LectureSpacesAppContext _context;

        public LectureSpaceComponentsController(LectureSpacesAppContext context)
        {
            _context = context;
        }

        // GET: LectureSpaceComponents
        public async Task<IActionResult> Index()
        {
              return _context.LectureSpaceComponent != null ? 
                          View(await _context.LectureSpaceComponent.ToListAsync()) :
                          Problem("Entity set 'LectureSpacesAppContext.LectureSpaceComponent'  is null.");
        }

        // GET: LectureSpaceComponents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LectureSpaceComponent == null)
            {
                return NotFound();
            }

            var lectureSpaceComponent = await _context.LectureSpaceComponent
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lectureSpaceComponent == null)
            {
                return NotFound();
            }

            return View(lectureSpaceComponent);
        }

        // GET: LectureSpaceComponents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LectureSpaceComponents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,titulo,descripcion")] LectureSpaceComponent lectureSpaceComponent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lectureSpaceComponent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lectureSpaceComponent);
        }

        // GET: LectureSpaceComponents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LectureSpaceComponent == null)
            {
                return NotFound();
            }

            var lectureSpaceComponent = await _context.LectureSpaceComponent.FindAsync(id);
            if (lectureSpaceComponent == null)
            {
                return NotFound();
            }
            return View(lectureSpaceComponent);
        }

        // POST: LectureSpaceComponents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,titulo,descripcion")] LectureSpaceComponent lectureSpaceComponent)
        {
            if (id != lectureSpaceComponent.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lectureSpaceComponent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LectureSpaceComponentExists(lectureSpaceComponent.ID))
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
            return View(lectureSpaceComponent);
        }

        // GET: LectureSpaceComponents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LectureSpaceComponent == null)
            {
                return NotFound();
            }

            var lectureSpaceComponent = await _context.LectureSpaceComponent
                .FirstOrDefaultAsync(m => m.ID == id);
            if (lectureSpaceComponent == null)
            {
                return NotFound();
            }

            return View(lectureSpaceComponent);
        }

        // POST: LectureSpaceComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LectureSpaceComponent == null)
            {
                return Problem("Entity set 'LectureSpacesAppContext.LectureSpaceComponent'  is null.");
            }
            var lectureSpaceComponent = await _context.LectureSpaceComponent.FindAsync(id);
            if (lectureSpaceComponent != null)
            {
                _context.LectureSpaceComponent.Remove(lectureSpaceComponent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LectureSpaceComponentExists(int id)
        {
          return (_context.LectureSpaceComponent?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
