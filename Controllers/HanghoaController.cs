using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using btl_nhom32.Models;
using btl_nhom32.Models.Process;

namespace btl_nhom32.Controllers
{
    public class HanghoaController : Controller
    {
        private readonly MvcMovieContext _context;
        private StringProcess strPro = new StringProcess();


        public HanghoaController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Hanghoa
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.Hanghoa.Include(h => h.Thuonghieu);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: Hanghoa/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Hanghoa == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.Hanghoa
                .Include(h => h.Thuonghieu)
                .FirstOrDefaultAsync(m => m.Mahh == id);
            if (hanghoa == null)
            {
                return NotFound();
            }

            return View(hanghoa);
        }

        // GET: Hanghoa/Create
        public IActionResult Create()
        {
            ViewData["Tenth"] = new SelectList(_context.Thuonghieu, "Idth", "Tenth");
            var newhanghoa = "HH01";
            var countnhacungcap = _context.Hanghoa.Count();
            if (countnhacungcap > 0)
            {
                var Mahh = _context.Hanghoa.OrderByDescending(m => m.Mahh).First().Mahh;
                newhanghoa = strPro.AutoGenerateCode(Mahh);
            }
            ViewBag.newID = newhanghoa;
            return View();

        }

        // POST: Hanghoa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mahh,Tenhh,Tenth,Dvtinh,gvhh,gbhh")] Hanghoa hanghoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hanghoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tenth"] = new SelectList(_context.Thuonghieu, "Idth", "Tenth", hanghoa.Tenth);
            return View(hanghoa);
        }

        // GET: Hanghoa/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Hanghoa == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.Hanghoa.FindAsync(id);
            if (hanghoa == null)
            {
                return NotFound();
            }
            ViewData["Tenth"] = new SelectList(_context.Thuonghieu, "Idth", "Tenth", hanghoa.Tenth);
            return View(hanghoa);
        }

        // POST: Hanghoa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Mahh,Tenhh,Tenth,Dvtinh,gvhh,gbhh")] Hanghoa hanghoa)
        {
            if (id != hanghoa.Mahh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hanghoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HanghoaExists(hanghoa.Mahh))
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
            ViewData["Tenth"] = new SelectList(_context.Thuonghieu, "Idth", "Tenth", hanghoa.Tenth);
            return View(hanghoa);
        }

        // GET: Hanghoa/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Hanghoa == null)
            {
                return NotFound();
            }

            var hanghoa = await _context.Hanghoa
                .Include(h => h.Thuonghieu)
                .FirstOrDefaultAsync(m => m.Mahh == id);
            if (hanghoa == null)
            {
                return NotFound();
            }

            return View(hanghoa);
        }

        // POST: Hanghoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Hanghoa == null)
            {
                return Problem("Entity set 'MvcMovieContext.Hanghoa'  is null.");
            }
            var hanghoa = await _context.Hanghoa.FindAsync(id);
            if (hanghoa != null)
            {
                _context.Hanghoa.Remove(hanghoa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HanghoaExists(string id)
        {
            return (_context.Hanghoa?.Any(e => e.Mahh == id)).GetValueOrDefault();
        }
    }
}
