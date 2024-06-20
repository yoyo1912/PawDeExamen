using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RedoPawProj.Data;
using RedoPawProj.Models;

namespace RedoPawProj.Controllers
{
    public class CompanieController : Controller
    {
        private readonly AppDbContext _context;

        public CompanieController(AppDbContext context)
        {
            _context = context;
        }

        // Index: List all companies
        public async Task<IActionResult> Index(bool sortByDomain = false)
        {         
            if (sortByDomain)
            {
                // Sort by the number of companies in each domain
                var companii = _context.Companii.Include(c => c.DomeniuActivitate).OrderByDescending(c => c.DomeniuActivitate.Companii.Count);
                return View(await companii.ToListAsync());
            }
            else
            {
                var companii = _context.Companii.Include(c => c.DomeniuActivitate);
                return View(await companii.ToListAsync());
            }            
        }

        // Create: Add new company
        public IActionResult Create()
        {
            ViewData["DomeniuActivitateId"] = new SelectList(_context.DomeniiActivitate, "Id", "Nume");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanieModel companie)
        {
            try
            {
                if (companie.DataInfiintarii > DateTime.Now)
                {
                    ModelState.AddModelError("DataInfiintarii", "Data infintarii nu poate fi in viitor");
                    ViewBag.DomeniuActivitateId = new SelectList(_context.DomeniiActivitate, "Id", "Nume", companie.DomeniuActivitateId);
                    return View(companie);
                }
                _context.Add(companie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["DomeniuActivitateId"] = new SelectList(_context.DomeniiActivitate, "Id", "Nume", companie.DomeniuActivitateId);
                return View(companie);
            }
        }

        // Edit: Modify existing company
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companie = await _context.Companii.FindAsync(id);
            if (companie == null)
            {
                return NotFound();
            }
            ViewData["DomeniuActivitateId"] = new SelectList(_context.DomeniiActivitate, "Id", "Nume", companie.DomeniuActivitateId);
            return View(companie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CompanieModel companie)
        {
            if (id != companie.Id)
            {
                return NotFound();
            }

            if (companie.DataInfiintarii > DateTime.Now)
            {
                ModelState.AddModelError("DataInfiintarii", "Data infintarii nu poate fi in viitor");
                ViewBag.DomeniuActivitateId = new SelectList(_context.DomeniiActivitate, "Id", "Nume", companie.DomeniuActivitateId);
                return View(companie);
            }

            try
            {
                _context.Update(companie);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanieExists(companie.Id))
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

        // Delete: Remove company
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companie = await _context.Companii.Include(c => c.DomeniuActivitate).FirstOrDefaultAsync(m => m.Id == id);
            if (companie == null)
            {
                return NotFound();
            }

            return View(companie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companie = await _context.Companii.FindAsync(id);
            _context.Companii.Remove(companie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanieExists(int id)
        {
            return _context.Companii.Any(e => e.Id == id);
        }
    }
}
