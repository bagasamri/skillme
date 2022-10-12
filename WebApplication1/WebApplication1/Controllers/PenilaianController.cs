using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Contex;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PenilaianController : Controller
    {

        private readonly MasterContext _context;

        public PenilaianController(MasterContext context)
        {
            _context = context;

        }

        // GET: Penilaians
        public async Task<IActionResult> Index()
        {
              return View(await _context.penilaian.ToListAsync());
        }

        // GET: Penilaians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.penilaian == null)
            {
                return NotFound();
            }

            var penilaian = await _context.penilaian
                .FirstOrDefaultAsync(m => m.ID == id);
            if (penilaian == null)
            {
                return NotFound();
            }

            return View(penilaian);
        }

        // GET: Penilaians/Create
        public IActionResult Create()
        {
            return View();
        }
        public  IActionResult Report()
        {
   
            var a = _context.penilaian.Where(m => m.Nilai <= 70 && m.App == 1).Count();
            ViewBag.a = a;
            var b = _context.penilaian.Where(m => m.Nilai >= 71 && m.Nilai <= 90 && m.App == 1).Count();
            ViewBag.b = b;
            var c = _context.penilaian.Where(m => m.Nilai >= 91 && m.App == 1).Count();
            ViewBag.c = c;

         
            return View();
        }
        public IActionResult Upload()
        {
            return View();
        }

 

        // POST: Penilaians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Batch,NIK,Nama,Nilai")] Penilaian penilaian)
        {
            if (ModelState.IsValid)
            {
                _context.Add(penilaian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(penilaian);
        }

        // GET: Penilaians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.penilaian == null)
            {
                return NotFound();
            }

            var penilaian = await _context.penilaian.FindAsync(id);
            if (penilaian == null)
            {
                return NotFound();
            }
            return View(penilaian);
        }

        // POST: Penilaians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Batch,NIK,Nama,Nilai")] Penilaian penilaian)
        {
            if (id != penilaian.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(penilaian);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PenilaianExists(penilaian.ID))
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
            return View(penilaian);
        }

        // GET: Penilaians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.penilaian == null)
            {
                return NotFound();
            }

            var penilaian = await _context.penilaian
                .FirstOrDefaultAsync(m => m.ID == id);
            if (penilaian == null)
            {
                return NotFound();
            }

            return View(penilaian);
        }

        // POST: Penilaians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.penilaian == null)
            {
                return Problem("Entity set 'MasterContext.penilaians'  is null.");
            }
            var penilaian = await _context.penilaian.FindAsync(id);
            if (penilaian != null)
            {
                _context.penilaian.Remove(penilaian);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Approve(int? id)
        {
            if (id == null || _context.penilaian == null)
            {
                return NotFound();
            }

            var penilaian = await _context.penilaian
                .FirstOrDefaultAsync(m => m.ID == id);
            if (penilaian == null)
            {
                return NotFound();
            }

            return View(penilaian);
        }

        // POST: Penilaians/Delete/5
        [HttpPost, ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id, [Bind("ID,Batch,NIK,Nama,Nilai,App")] Penilaian penilaian)
        {
            
                    _context.Update(penilaian);
      
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PenilaianExists(int id)
        {
          return _context.penilaian.Any(e => e.ID == id);
        }



      
    }
}
