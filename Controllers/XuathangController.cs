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
    public class XuathangController : Controller
    {
        private readonly MvcMovieContext _context;
        private StringProcess strPro = new StringProcess();


        public XuathangController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Xuathang
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.Xuathang.Include(x => x.Khachhang).Include(x => x.Nhanvien);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: Xuathang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Xuathang == null)
            {
                return NotFound();
            }

            var xuathang = await _context.Xuathang
                .Include(x => x.Khachhang)
                .Include(x => x.Nhanvien)
                .FirstOrDefaultAsync(m => m.Idxh == id);
            if (xuathang == null)
            {
                return NotFound();
            }

            return View(xuathang);
        }

        // GET: Xuathang/Create
        public IActionResult Create()
        {
            ViewData["Makh"] = new SelectList(_context.Khachhang, "Makh", "Makh");
            ViewData["Manv"] = new SelectList(_context.Nhanvien, "Manv", "Manv");
            var newhanghoa = "XH01";
            var countnhacungcap = _context.Xuathang.Count();
            if (countnhacungcap > 0)
            {
                var Idxh = _context.Xuathang.OrderByDescending(m => m.Idxh).First().Idxh;
                newhanghoa = strPro.AutoGenerateCode(Idxh);
            }
            ViewBag.newID = newhanghoa;
            return View();
        }

        // POST: Xuathang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idxh,Manv,Makh,ngayxh,trangtxh")] Xuathang xuathang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(xuathang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Makh"] = new SelectList(_context.Khachhang, "Makh", "Makh", xuathang.Makh);
            ViewData["Manv"] = new SelectList(_context.Nhanvien, "Manv", "Manv", xuathang.Manv);
            return View(xuathang);
        }

        // GET: Xuathang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Xuathang == null)
            {
                return NotFound();
            }

            var xuathang = await _context.Xuathang.FindAsync(id);
            if (xuathang == null)
            {
                return NotFound();
            }
            ViewData["Makh"] = new SelectList(_context.Khachhang, "Makh", "Makh", xuathang.Makh);
            ViewData["Manv"] = new SelectList(_context.Nhanvien, "Manv", "Manv", xuathang.Manv);
            return View(xuathang);
        }

        // POST: Xuathang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Idxh,Manv,Makh,ngayxh,trangtxh")] Xuathang xuathang)
        {
            if (id != xuathang.Idxh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(xuathang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!XuathangExists(xuathang.Idxh))
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
            ViewData["Makh"] = new SelectList(_context.Khachhang, "Makh", "Makh", xuathang.Makh);
            ViewData["Manv"] = new SelectList(_context.Nhanvien, "Manv", "Manv", xuathang.Manv);
            return View(xuathang);
        }

        // GET: Xuathang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Xuathang == null)
            {
                return NotFound();
            }

            var xuathang = await _context.Xuathang
                .Include(x => x.Khachhang)
                .Include(x => x.Nhanvien)
                .FirstOrDefaultAsync(m => m.Idxh == id);
            if (xuathang == null)
            {
                return NotFound();
            }

            return View(xuathang);
        }

        // POST: Xuathang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Xuathang == null)
            {
                return Problem("Entity set 'MvcMovieContext.Xuathang'  is null.");
            }
            var xuathang = await _context.Xuathang.FindAsync(id);
            if (xuathang != null)
            {
                _context.Xuathang.Remove(xuathang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool XuathangExists(string id)
        {
            return (_context.Xuathang?.Any(e => e.Idxh == id)).GetValueOrDefault();
        }
    }
}
