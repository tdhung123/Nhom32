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
    public class NhacungcapController : Controller
    {
        private readonly MvcMovieContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();

        private StringProcess strPro = new StringProcess();

        public NhacungcapController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Nhacungcap
        // public async Task<IActionResult> Index(string searchString)
        // {

        //     return _context.Nhacungcap != null ?
        //                 View(await _context.Nhacungcap.ToListAsync()) :
        //                 Problem("Entity set 'MvcMovieContext.Nhacungcap'  is null.");

        // }
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            if (_context.Nhacungcap == null)
            {
                return Problem("Entity set 'MvcMovieContext.Nhacungcap'  is null.");

            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Nhacungcap
                                            orderby m.Tenncc
                                            select m.Tenncc;
            var Nhacungcap = from m in _context.Nhacungcap
                             select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                Nhacungcap = Nhacungcap.Where(s => s.Tenncc!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                Nhacungcap = Nhacungcap.Where(x => x.Tenncc == movieGenre);
            }

            var movieGenreVM = new MovieGenreViewModel
            {
                Tenncc = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Nhacungcap = await Nhacungcap.ToListAsync()
            };

            return View(movieGenreVM);
        }

        // GET: Nhacungcap/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nhacungcap == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Nhacungcap
                .FirstOrDefaultAsync(m => m.Mancc == id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            return View(nhacungcap);
        }

        // GET: Nhacungcap/Create
        public IActionResult Create()
        {
            var newnhacungcap = "NCC01";
            var countnhacungcap = _context.Nhacungcap.Count();
            if (countnhacungcap > 0)
            {
                var Mancc = _context.Nhacungcap.OrderByDescending(m => m.Mancc).First().Mancc;
                newnhacungcap = strPro.AutoGenerateCode(Mancc);
            }
            ViewBag.newID = newnhacungcap;
            return View();
        }

        // POST: Nhacungcap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mancc,Tenncc,Diachincc,Sdtncc,Emailncc")] Nhacungcap nhacungcap)
        {
            if (ModelState.IsValid)
            {
                nhacungcap.ngayncc = DateTime.Now;
                _context.Add(nhacungcap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhacungcap);
        }

        // GET: Nhacungcap/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nhacungcap == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Nhacungcap.FindAsync(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }
            return View(nhacungcap);
        }

        // POST: Nhacungcap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Mancc,Tenncc,Diachincc,Sdtncc,Emailncc,ngayncc")] Nhacungcap nhacungcap)
        {
            if (id != nhacungcap.Mancc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhacungcap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhacungcapExists(nhacungcap.Mancc))
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
            return View(nhacungcap);
        }

        // GET: Nhacungcap/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nhacungcap == null)
            {
                return NotFound();
            }

            var nhacungcap = await _context.Nhacungcap
                .FirstOrDefaultAsync(m => m.Mancc == id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            return View(nhacungcap);
        }

        // POST: Nhacungcap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nhacungcap == null)
            {
                return Problem("Entity set 'MvcMovieContext.Nhacungcap'  is null.");
            }
            var nhacungcap = await _context.Nhacungcap.FindAsync(id);
            if (nhacungcap != null)
            {
                _context.Nhacungcap.Remove(nhacungcap);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhacungcapExists(string id)
        {
            return (_context.Nhacungcap?.Any(e => e.Mancc == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    var FileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", FileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to sever
                        await file.CopyToAsync(stream);
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            var emp = new Nhacungcap();

                            emp.Mancc = dt.Rows[i][0].ToString();
                            emp.Tenncc = dt.Rows[i][1].ToString();
                            emp.Diachincc = dt.Rows[i][2].ToString();
                            emp.Sdtncc = dt.Rows[i][3].ToString();
                            emp.Emailncc = dt.Rows[i][4].ToString();
                            emp.ngayncc = Convert.ToDateTime(dt.Rows[i][5].ToString());




                            _context.Nhacungcap.Add(emp);
                        }
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }
    }
}

