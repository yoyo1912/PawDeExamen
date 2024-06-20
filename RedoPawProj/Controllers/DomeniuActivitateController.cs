using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RedoPawProj.Data;
using RedoPawProj.Models;

namespace RedoPawProj.Controllers
{
    public class DomeniuActivitateController : Controller
    {
        private readonly AppDbContext _context;

        public DomeniuActivitateController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DomeniuActivitate
        public async Task<IActionResult> Index()
        {
            // List all domains sorted by the number of associated companies in descending order
            var domenii = await _context.DomeniiActivitate
                .Include(d => d.Companii)
                .OrderByDescending(d => d.Companii.Count)
                .ToListAsync();
            return View(domenii);
        }

        // GET: DomeniuActivitate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DomeniuActivitate/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DomeniuActivitateModel domeniuActivitate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(domeniuActivitate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(domeniuActivitate);
        }

        // GET: DomeniuActivitate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domeniuActivitate = await _context.DomeniiActivitate.FindAsync(id);
            if (domeniuActivitate == null)
            {
                return NotFound();
            }
            return View(domeniuActivitate);
        }

        // POST: DomeniuActivitate/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DomeniuActivitateModel domeniuActivitate)
        {
            if (id != domeniuActivitate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(domeniuActivitate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DomeniuActivitateExists(domeniuActivitate.Id))
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
            return View(domeniuActivitate);
        }

        // GET: DomeniuActivitate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var domeniuActivitate = await _context.DomeniiActivitate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (domeniuActivitate == null)
            {
                return NotFound();
            }

            return View(domeniuActivitate);
        }

        // POST: DomeniuActivitate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var domeniuActivitate = await _context.DomeniiActivitate.FindAsync(id);
            _context.DomeniiActivitate.Remove(domeniuActivitate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DomeniuActivitateExists(int id)
        {
            return _context.DomeniiActivitate.Any(e => e.Id == id);
        }
    }
}
