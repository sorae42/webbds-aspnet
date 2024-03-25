using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDS.Data;
using WebBatDongSan.Models;

namespace WebBatDongSan.Controllers
{
    public class BDSController : Controller
    {
        private readonly BDSContext _context;

        public BDSController(BDSContext context)
        {
            _context = context;
        }

        // GET: BDS
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.BDS == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var movies = from m in _context.BDS
                select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.EstateName!.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }

        // GET: BDS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bDS = await _context.BDS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bDS == null)
            {
                return NotFound();
            }

            return View(bDS);
        }

        // GET: BDS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BDS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EstateName,Location,District,Area,Price,Direction,Description")] Models.BDS bDS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bDS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bDS);
        }

        // GET: BDS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bDS = await _context.BDS.FindAsync(id);
            if (bDS == null)
            {
                return NotFound();
            }
            return View(bDS);
        }

        // POST: BDS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EstateName,Location,District,Area,Price,Direction,Description")] Models.BDS bDS)
        {
            if (id != bDS.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bDS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BDSExists(bDS.Id))
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
            return View(bDS);
        }

        // GET: BDS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bDS = await _context.BDS
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bDS == null)
            {
                return NotFound();
            }

            return View(bDS);
        }

        // POST: BDS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bDS = await _context.BDS.FindAsync(id);
            if (bDS != null)
            {
                _context.BDS.Remove(bDS);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BDSExists(int id)
        {
            return _context.BDS.Any(e => e.Id == id);
        }
    }
}
