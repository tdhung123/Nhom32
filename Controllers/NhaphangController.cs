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
    public class NhaphangController : Controller
    {
        private readonly MvcMovieContext _context;
        private StringProcess strPro = new StringProcess();
        private ExcelProcess _excelProcess = new ExcelProcess();


        public NhaphangController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Nhaphang
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.Nhaphang.Include(n => n.Hanghoa).Include(n => n.Kho).Include(n => n.Nhacungcap);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: Nhaphang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Nhaphang == null)
            {
                return NotFound();
            }

            var nhaphang = await _context.Nhaphang
                .Include(n => n.Hanghoa)
                .Include(n => n.Kho)
                .Include(n => n.Nhacungcap)
                .FirstOrDefaultAsync(m => m.Idnh == id);
            if (nhaphang == null)
            {
                return NotFound();
            }

            return View(nhaphang);
        }

        // GET: Nhaphang/Create
        public IActionResult Create()
        {
            ViewData["Mahh"] = new SelectList(_context.Hanghoa, "Mahh", "Mahh");
            ViewData["Makho"] = new SelectList(_context.Kho, "Makho", "Makho");
            ViewData["Mancc"] = new SelectList(_context.Nhacungcap, "Mancc", "Mancc");



            var newhanghoa = "NH01";
            var countnhacungcap = _context.Nhaphang.Count();
            if (countnhacungcap > 0)
            {
                var Idnh = _context.Nhaphang.OrderByDescending(m => m.Idnh).First().Idnh;
                newhanghoa = strPro.AutoGenerateCode(Idnh);
            }
            ViewBag.newID = newhanghoa;
            return View();
        }

        // POST: Nhaphang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idnh,Mahh,Mancc,Makho,Soluongnh,ngaynh")] Nhaphang nhaphang)
        {
            if (ModelState.IsValid)
            {
                nhaphang.ngaynh = DateTime.Now;

                _context.Add(nhaphang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mahh"] = new SelectList(_context.Hanghoa, "Mahh", "Mahh", nhaphang.Mahh);
            ViewData["Makho"] = new SelectList(_context.Kho, "Makho", "Makho", nhaphang.Makho);
            ViewData["Mancc"] = new SelectList(_context.Nhacungcap, "Mancc", "Mancc", nhaphang.Mancc);
            return View(nhaphang);
        }

        // GET: Nhaphang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Nhaphang == null)
            {
                return NotFound();
            }

            var nhaphang = await _context.Nhaphang.FindAsync(id);
            if (nhaphang == null)
            {
                return NotFound();
            }
            ViewData["Mahh"] = new SelectList(_context.Hanghoa, "Mahh", "Mahh", nhaphang.Mahh);
            ViewData["Makho"] = new SelectList(_context.Kho, "Makho", "Makho", nhaphang.Makho);
            ViewData["Mancc"] = new SelectList(_context.Nhacungcap, "Mancc", "Mancc", nhaphang.Mancc);
            return View(nhaphang);
        }

        // POST: Nhaphang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Idnh,Mahh,Mancc,Makho,Soluongnh,ngaynh")] Nhaphang nhaphang)
        {
            if (id != nhaphang.Idnh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaphang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaphangExists(nhaphang.Idnh))
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
            ViewData["Mahh"] = new SelectList(_context.Hanghoa, "Mahh", "Mahh", nhaphang.Mahh);
            ViewData["Makho"] = new SelectList(_context.Kho, "Makho", "Makho", nhaphang.Makho);
            ViewData["Mancc"] = new SelectList(_context.Nhacungcap, "Mancc", "Mancc", nhaphang.Mancc);
            return View(nhaphang);
        }

        // GET: Nhaphang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Nhaphang == null)
            {
                return NotFound();
            }

            var nhaphang = await _context.Nhaphang
                .Include(n => n.Hanghoa)
                .Include(n => n.Kho)
                .Include(n => n.Nhacungcap)
                .FirstOrDefaultAsync(m => m.Idnh == id);
            if (nhaphang == null)
            {
                return NotFound();
            }

            return View(nhaphang);
        }

        // POST: Nhaphang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Nhaphang == null)
            {
                return Problem("Entity set 'MvcMovieContext.Nhaphang'  is null.");
            }
            var nhaphang = await _context.Nhaphang.FindAsync(id);
            if (nhaphang != null)
            {
                _context.Nhaphang.Remove(nhaphang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaphangExists(string id)
        {
            return (_context.Nhaphang?.Any(e => e.Idnh == id)).GetValueOrDefault();
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
                            var emp = new Nhaphang();

                            emp.Idnh = dt.Rows[i][0].ToString();
                            emp.Mahh = dt.Rows[i][1].ToString();

                            emp.Mancc = dt.Rows[i][2].ToString();
                            emp.Makho = dt.Rows[i][3].ToString();
                            emp.Soluongnh = dt.Rows[i][4].ToString();
                            emp.Makho = dt.Rows[i][5].ToString();
                            emp.ngaynh = Convert.ToDateTime(dt.Rows[i][6].ToString());
                            _context.Nhaphang.Add(emp);
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
