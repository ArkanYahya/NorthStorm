using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthStorm.Data;
using NorthStorm.Models;

namespace NorthStorm.Controllers
{
    public class RecruitmentsController : Controller
    {
        private readonly NorthStormContext _context;

        public RecruitmentsController(NorthStormContext context)
        {
            _context = context;
        }

        // GET: Recruitments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recruitments.ToListAsync());
        }

        // GET: Recruitments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recruitment = await _context.Recruitments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recruitment == null)
            {
                return NotFound();
            }

            return View(recruitment);
        }

        // GET: Recruitments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recruitments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReferenceNo,ReferenceDate,Subject")] Recruitment recruitment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recruitment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recruitment);
        }

        // GET: Recruitments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recruitment = await _context.Recruitments.FindAsync(id);
            if (recruitment == null)
            {
                return NotFound();
            }
            return View(recruitment);
        }

        // POST: Recruitments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReferenceNo,ReferenceDate,Subject")] Recruitment recruitment)
        {
            if (id != recruitment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recruitment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecruitmentExists(recruitment.Id))
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
            return View(recruitment);
        }

        // GET: Recruitments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recruitment = await _context.Recruitments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recruitment == null)
            {
                return NotFound();
            }

            return View(recruitment);
        }

        // POST: Recruitments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recruitment = await _context.Recruitments.FindAsync(id);
            if (recruitment != null)
            {
                _context.Recruitments.Remove(recruitment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecruitmentExists(int id)
        {
            return _context.Recruitments.Any(e => e.Id == id);
        }
    }
}
