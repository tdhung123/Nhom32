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
    public class ChucvucvController : Controller
    {
        private readonly MvcMovieContext _context;
        private StringProcess strPro = new StringProcess();


        public ChucvucvController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Chucvucv
        public async Task<IActionResult> Index()
        {
            return _context.Chucvucv != null ?
                        View(await _context.Chucvucv.ToListAsync()) :
                        Problem("Entity set 'MvcMovieContext.Chucvucv'  is null.");
        }

        // GET: Chucvucv/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Chucvucv == null)
            {
                return NotFound();
            }

            var chucvucv = await _context.Chucvucv
                .FirstOrDefaultAsync(m => m.Idcv == id);
            if (chucvucv == null)
            {
                return NotFound();
            }

            return View(chucvucv);
        }

        // GET: Chucvucv/Create
        public IActionResult Create()
        {
            var newnhacungcap = "CV01";
            var countnhacungcap = _context.Chucvucv.Count();
            if (countnhacungcap > 0)
            {
                var Idcv = _context.Chucvucv.OrderByDescending(m => m.Idcv).First().Idcv;
                newnhacungcap = strPro.AutoGenerateCode(Idcv);
            }
            ViewBag.newID = newnhacungcap;
            return View();
        }

        // POST: Chucvucv/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcv,Tencv,Motacn")] Chucvucv chucvucv)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chucvucv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chucvucv);
        }

        // GET: Chucvucv/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Chucvucv == null)
            {
                return NotFound();
            }

            var chucvucv = await _context.Chucvucv.FindAsync(id);
            if (chucvucv == null)
            {
                return NotFound();
            }
            return View(chucvucv);
        }

        // POST: Chucvucv/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Idcv,Tencv,Motacn")] Chucvucv chucvucv)
        {
            if (id != chucvucv.Idcv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chucvucv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChucvucvExists(chucvucv.Idcv))
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
            return View(chucvucv);
        }

        // GET: Chucvucv/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Chucvucv == null)
            {
                return NotFound();
            }

            var chucvucv = await _context.Chucvucv
                .FirstOrDefaultAsync(m => m.Idcv == id);
            if (chucvucv == null)
            {
                return NotFound();
            }

            return View(chucvucv);
        }

        // POST: Chucvucv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Chucvucv == null)
            {
                return Problem("Entity set 'MvcMovieContext.Chucvucv'  is null.");
            }
            var chucvucv = await _context.Chucvucv.FindAsync(id);
            if (chucvucv != null)
            {
                _context.Chucvucv.Remove(chucvucv);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChucvucvExists(string id)
        {
            return (_context.Chucvucv?.Any(e => e.Idcv == id)).GetValueOrDefault();
        }
    }
}
