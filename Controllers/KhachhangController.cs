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
    public class KhachhangController : Controller
    {
        private readonly MvcMovieContext _context;
        private StringProcess strPro = new StringProcess();

        public KhachhangController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Khachhang
        public async Task<IActionResult> Index()
        {
            return _context.Khachhang != null ?
                        View(await _context.Khachhang.ToListAsync()) :
                        Problem("Entity set 'MvcMovieContext.Khachhang'  is null.");
        }

        // GET: Khachhang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Khachhang == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang
                .FirstOrDefaultAsync(m => m.Makh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // GET: Khachhang/Create
        public IActionResult Create()
        {
            var newnhacungcap = "NCC01";
            var countnhacungcap = _context.Khachhang.Count();
            if (countnhacungcap > 0)
            {
                var Makh = _context.Khachhang.OrderByDescending(m => m.Makh).First().Makh;
                newnhacungcap = strPro.AutoGenerateCode(Makh);
            }
            ViewBag.newID = newnhacungcap;
            return View();
        }

        // POST: Khachhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Makh,Tenkh,Diachikh,Sdtkh")] Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khachhang);
        }

        // GET: Khachhang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Khachhang == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            return View(khachhang);
        }

        // POST: Khachhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Makh,Tenkh,Diachikh,Sdtkh")] Khachhang khachhang)
        {
            if (id != khachhang.Makh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachhangExists(khachhang.Makh))
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
            return View(khachhang);
        }

        // GET: Khachhang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Khachhang == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang
                .FirstOrDefaultAsync(m => m.Makh == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // POST: Khachhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Khachhang == null)
            {
                return Problem("Entity set 'MvcMovieContext.Khachhang'  is null.");
            }
            var khachhang = await _context.Khachhang.FindAsync(id);
            if (khachhang != null)
            {
                _context.Khachhang.Remove(khachhang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachhangExists(string id)
        {
            return (_context.Khachhang?.Any(e => e.Makh == id)).GetValueOrDefault();
        }
    }
}
