using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Book.Data;
using Book.Models;

namespace Book.Controllers
{
    public class CategoreysTempController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoreysTempController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoreysTemp
        public async Task<IActionResult> Index()
        {
              return _context.Categories != null ? 
                          View(await _context.Categories.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
        }

        // GET: CategoreysTemp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categorey = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorey == null)
            {
                return NotFound();
            }

            return View(categorey);
        }

        // GET: CategoreysTemp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoreysTemp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DisplayOrder,CreateDateTime")] Categorey categorey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categorey);
        }

        // GET: CategoreysTemp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categorey = await _context.Categories.FindAsync(id);
            if (categorey == null)
            {
                return NotFound();
            }
            return View(categorey);
        }

        // POST: CategoreysTemp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DisplayOrder,CreateDateTime")] Categorey categorey)
        {
            if (id != categorey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoreyExists(categorey.Id))
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
            return View(categorey);
        }

        // GET: CategoreysTemp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categorey = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorey == null)
            {
                return NotFound();
            }

            return View(categorey);
        }

        // POST: CategoreysTemp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categories == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
            }
            var categorey = await _context.Categories.FindAsync(id);
            if (categorey != null)
            {
                _context.Categories.Remove(categorey);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoreyExists(int id)
        {
          return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
