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
    public class NhanvienController : Controller
    {
        private readonly MvcMovieContext _context;
        private StringProcess strPro = new StringProcess();


        public NhanvienController(MvcMovieContext context)
        {
            _context = context;
        }
        [HttpGet]
        // GET: Nhanvien
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.Nhanvien.Include(n => n.Chucvucv);
            return View(await mvcMovieContext.ToListAsync());
        }
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Nhanvien == null)
            {
                return Problem("Entity set 'MvcMovieContext.Nhanvien'  is null.");
            }

            var Nhanvien = from m in _context.Nhanvien
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Nhanvien = Nhanvien.Where(s => s.Tennv!.Contains(searchString));
            }

            return View(await Nhanvien.ToListAsync());
        }

        // GET: Nhanvien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nhanvien == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .Include(n => n.Chucvucv)
                .FirstOrDefaultAsync(m => m.Manv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // GET: Nhanvien/Create
        public IActionResult Create()
        {
            ViewData["Tencv"] = new SelectList(_context.Chucvucv, "Idcv", "Tencv");
            var newnhacungcap = "NV01";
            var countnhacungcap = _context.Nhanvien.Count();
            if (countnhacungcap > 0)
            {
                var Manv = _context.Nhanvien.OrderByDescending(m => m.Manv).First().Manv;
                newnhacungcap = strPro.AutoGenerateCode(Manv);
            }
            ViewBag.newID = newnhacungcap;

            return View();
        }

        // POST: Nhanvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Manv,Tennv,Gioitinhnv,ngaynv,Sdtnv,Diachinv,Emailnv,Tencv,ngaylamnv")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Tencv"] = new SelectList(_context.Chucvucv, "Idcv", "Tencv", nhanvien.Tencv);
            return View(nhanvien);
        }

        // GET: Nhanvien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nhanvien == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            ViewData["Tencv"] = new SelectList(_context.Chucvucv, "Idcv", "Tencv", nhanvien.Tencv);
            return View(nhanvien);
        }

        // POST: Nhanvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Manv,Tennv,Gioitinhnv,ngaynv,Sdtnv,Diachinv,Emailnv,Tencv,ngaylamnv")] Nhanvien nhanvien)
        {
            if (id != nhanvien.Manv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanvienExists(nhanvien.Manv))
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
            ViewData["Tencv"] = new SelectList(_context.Chucvucv, "Idcv", "Tencv", nhanvien.Tencv);
            return View(nhanvien);
        }

        // GET: Nhanvien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nhanvien == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .Include(n => n.Chucvucv)
                .FirstOrDefaultAsync(m => m.Manv == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // POST: Nhanvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nhanvien == null)
            {
                return Problem("Entity set 'MvcMovieContext.Nhanvien'  is null.");
            }
            var nhanvien = await _context.Nhanvien.FindAsync(id);
            if (nhanvien != null)
            {
                _context.Nhanvien.Remove(nhanvien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanvienExists(string id)
        {
            return (_context.Nhanvien?.Any(e => e.Manv == id)).GetValueOrDefault();
        }
    }
}
