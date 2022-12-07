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
    public class ThuonghieuController : Controller
    {
        private readonly MvcMovieContext _context;
        private StringProcess strPro = new StringProcess();


        public ThuonghieuController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Thuonghieu
        public async Task<IActionResult> Index()
        {
            return _context.Thuonghieu != null ?
                        View(await _context.Thuonghieu.ToListAsync()) :
                        Problem("Entity set 'MvcMovieContext.Thuonghieu'  is null.");
        }

        // GET: Thuonghieu/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Thuonghieu == null)
            {
                return NotFound();
            }

            var thuonghieu = await _context.Thuonghieu
                .FirstOrDefaultAsync(m => m.Idth == id);
            if (thuonghieu == null)
            {
                return NotFound();
            }

            return View(thuonghieu);
        }

        // GET: Thuonghieu/Create
        public IActionResult Create()
        {
            var newhanghoa = "TH01";
            var countnhacungcap = _context.Thuonghieu.Count();
            if (countnhacungcap > 0)
            {
                var Idth = _context.Thuonghieu.OrderByDescending(m => m.Idth).First().Idth;
                newhanghoa = strPro.AutoGenerateCode(Idth);
            }
            ViewBag.newID = newhanghoa;

            return View();
        }

        // POST: Thuonghieu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idth,Tenth")] Thuonghieu thuonghieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuonghieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thuonghieu);
        }

        // GET: Thuonghieu/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Thuonghieu == null)
            {
                return NotFound();
            }

            var thuonghieu = await _context.Thuonghieu.FindAsync(id);
            if (thuonghieu == null)
            {
                return NotFound();
            }
            return View(thuonghieu);
        }

        // POST: Thuonghieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Idth,Tenth")] Thuonghieu thuonghieu)
        {
            if (id != thuonghieu.Idth)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thuonghieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuonghieuExists(thuonghieu.Idth))
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
            return View(thuonghieu);
        }

        // GET: Thuonghieu/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Thuonghieu == null)
            {
                return NotFound();
            }

            var thuonghieu = await _context.Thuonghieu
                .FirstOrDefaultAsync(m => m.Idth == id);
            if (thuonghieu == null)
            {
                return NotFound();
            }

            return View(thuonghieu);
        }

        // POST: Thuonghieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Thuonghieu == null)
            {
                return Problem("Entity set 'MvcMovieContext.Thuonghieu'  is null.");
            }
            var thuonghieu = await _context.Thuonghieu.FindAsync(id);
            if (thuonghieu != null)
            {
                _context.Thuonghieu.Remove(thuonghieu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThuonghieuExists(string id)
        {
            return (_context.Thuonghieu?.Any(e => e.Idth == id)).GetValueOrDefault();
        }
    }
}
