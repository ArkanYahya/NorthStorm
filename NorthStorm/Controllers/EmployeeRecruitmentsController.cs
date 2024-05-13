using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthStorm.Data;
using NorthStorm.Models;

namespace NorthStorm.Controllers
{
    public class EmployeeRecruitmentsController : Controller
    {
        private readonly NorthStormContext _context;

        public EmployeeRecruitmentsController(NorthStormContext context)
        {
            _context = context;
        }

        // GET: EmployeeRecruitments
        public async Task<IActionResult> Index()
        {
            var northStormContext = _context.EmployeeRecruitments.Include(e => e.Employee).Include(e => e.Recruitment);
            return View(await northStormContext.ToListAsync());
        }

        // GET: EmployeeRecruitments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRecruitment = await _context.EmployeeRecruitments
                .Include(e => e.Employee)
                .Include(e => e.Recruitment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeRecruitment == null)
            {
                return NotFound();
            }

            return View(employeeRecruitment);
        }

        // GET: EmployeeRecruitments/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName");
            ViewData["RecruitmentId"] = new SelectList(_context.Set<Recruitment>(), "Id", "ReferenceNo");
            return View();
        }

        // POST: EmployeeRecruitments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,RecruitmentId")] EmployeeRecruitment employeeRecruitment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeRecruitment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", employeeRecruitment.EmployeeId);
            ViewData["RecruitmentId"] = new SelectList(_context.Set<Recruitment>(), "Id", "ReferenceNo", employeeRecruitment.RecruitmentId);
            return View(employeeRecruitment);
        }

        // GET: EmployeeRecruitments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRecruitment = await _context.EmployeeRecruitments.FindAsync(id);
            if (employeeRecruitment == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", employeeRecruitment.EmployeeId);
            ViewData["RecruitmentId"] = new SelectList(_context.Set<Recruitment>(), "Id", "ReferenceNo", employeeRecruitment.RecruitmentId);
            return View(employeeRecruitment);
        }

        // POST: EmployeeRecruitments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,RecruitmentId")] EmployeeRecruitment employeeRecruitment)
        {
            if (id != employeeRecruitment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeRecruitment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeRecruitmentExists(employeeRecruitment.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", employeeRecruitment.EmployeeId);
            ViewData["RecruitmentId"] = new SelectList(_context.Set<Recruitment>(), "Id", "ReferenceNo", employeeRecruitment.RecruitmentId);
            return View(employeeRecruitment);
        }

        // GET: EmployeeRecruitments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRecruitment = await _context.EmployeeRecruitments
                .Include(e => e.Employee)
                .Include(e => e.Recruitment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeRecruitment == null)
            {
                return NotFound();
            }

            return View(employeeRecruitment);
        }

        // POST: EmployeeRecruitments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeRecruitment = await _context.EmployeeRecruitments.FindAsync(id);
            if (employeeRecruitment != null)
            {
                _context.EmployeeRecruitments.Remove(employeeRecruitment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeRecruitmentExists(int id)
        {
            return _context.EmployeeRecruitments.Any(e => e.Id == id);
        }
    }
}
