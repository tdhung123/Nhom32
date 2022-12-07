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
    public class KiemkhoController : Controller
    {
        private readonly MvcMovieContext _context;
        private StringProcess strPro = new StringProcess();


        public KiemkhoController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Kiemkho
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.Kiemkho.Include(k => k.Hanghoa).Include(k => k.Kho);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: Kiemkho/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Kiemkho == null)
            {
                return NotFound();
            }

            var kiemkho = await _context.Kiemkho
                .Include(k => k.Hanghoa)
                .Include(k => k.Kho)
                .FirstOrDefaultAsync(m => m.Idkk == id);
            if (kiemkho == null)
            {
                return NotFound();
            }

            return View(kiemkho);
        }

        // GET: Kiemkho/Create
        public IActionResult Create()
        {
            ViewData["Mahh"] = new SelectList(_context.Hanghoa, "Mahh", "Mahh");
            ViewData["Makho"] = new SelectList(_context.Kho, "Makho", "Makho");


            var newhanghoa = "KH01";
            var countnhacungcap = _context.Kiemkho.Count();
            if (countnhacungcap > 0)
            {
                var Idkk = _context.Kiemkho.OrderByDescending(m => m.Idkk).First().Idkk;
                newhanghoa = strPro.AutoGenerateCode(Idkk);
            }
            ViewBag.newID = newhanghoa;
            return View();

        }

        // POST: Kiemkho/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idkk,Mahh,Makho,Sluongkk")] Kiemkho kiemkho)
        {
            if (ModelState.IsValid)
            {
                kiemkho.Ngaykk = DateTime.Now;
                _context.Add(kiemkho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mahh"] = new SelectList(_context.Hanghoa, "Mahh", "Mahh", kiemkho.Mahh);
            ViewData["Makho"] = new SelectList(_context.Kho, "Makho", "Makho", kiemkho.Makho);
            return View(kiemkho);
        }

        // GET: Kiemkho/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Kiemkho == null)
            {
                return NotFound();
            }

            var kiemkho = await _context.Kiemkho.FindAsync(id);
            if (kiemkho == null)
            {
                return NotFound();
            }
            ViewData["Mahh"] = new SelectList(_context.Hanghoa, "Mahh", "Mahh", kiemkho.Mahh);
            ViewData["Makho"] = new SelectList(_context.Kho, "Makho", "Makho", kiemkho.Makho);
            return View(kiemkho);
        }

        // POST: Kiemkho/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Idkk,Ngaykk,Mahh,Makho,Sluongkk")] Kiemkho kiemkho)
        {
            if (id != kiemkho.Idkk)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kiemkho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KiemkhoExists(kiemkho.Idkk))
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
            ViewData["Mahh"] = new SelectList(_context.Hanghoa, "Mahh", "Mahh", kiemkho.Mahh);
            ViewData["Makho"] = new SelectList(_context.Kho, "Makho", "Makho", kiemkho.Makho);
            return View(kiemkho);
        }

        // GET: Kiemkho/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Kiemkho == null)
            {
                return NotFound();
            }

            var kiemkho = await _context.Kiemkho
                .Include(k => k.Hanghoa)
                .Include(k => k.Kho)
                .FirstOrDefaultAsync(m => m.Idkk == id);
            if (kiemkho == null)
            {
                return NotFound();
            }

            return View(kiemkho);
        }

        // POST: Kiemkho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Kiemkho == null)
            {
                return Problem("Entity set 'MvcMovieContext.Kiemkho'  is null.");
            }
            var kiemkho = await _context.Kiemkho.FindAsync(id);
            if (kiemkho != null)
            {
                _context.Kiemkho.Remove(kiemkho);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KiemkhoExists(string id)
        {
            return (_context.Kiemkho?.Any(e => e.Idkk == id)).GetValueOrDefault();
        }
    }
}
