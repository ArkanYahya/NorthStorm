using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthStorm.Data;
using NorthStorm.Models;

namespace NorthStorm.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly NorthStormContext _context;

        public EmployeesController(NorthStormContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var employees = _context.Employees
                .Include(e => e.gender)
                .Include(e => e.nationality)
                .Include(e => e.race)
                .Include(e => e.religion)
                .Include(e => e.status)
                .AsNoTracking();
            return View(await employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.gender)
                .Include(e => e.nationality)
                .Include(e => e.race)
                .Include(e => e.religion)
                .Include(e => e.status)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            PopulateDropDownLists();
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,FourthName,SurName,MotherFirstName,MotherMiddleName,MotherLastName,BirthDate,CivilNumber,IBAN,GenderId,ReligionId,RaceId,NationalityId,StatusId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateDropDownLists(employee.GenderId,
                employee.NationalityId,
                employee.RaceId,
                employee.ReligionId,
                employee.StatusId);

            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            PopulateDropDownLists(employee.GenderId,
                employee.NationalityId,
                employee.RaceId,
                employee.ReligionId,
                employee.StatusId);

            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,FourthName,SurName,MotherFirstName,MotherMiddleName,MotherLastName,BirthDate,CivilNumber,IBAN,GenderId,ReligionId,RaceId,NationalityId,StatusId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //catch (DbUpdateException /* ex */)
                //{
                //    Log the error(uncomment ex variable name and write a log.)
                //    ModelState.AddModelError("", "Unable to save changes. " +
                //        "Try again, and if the problem persists, " +
                //        "see your system administrator.");
                //}

                return RedirectToAction(nameof(Index));
            }
            PopulateDropDownLists(employee.GenderId,
                employee.NationalityId,
                employee.RaceId,
                employee.ReligionId,
                employee.StatusId);

            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var employee = await _context.Employees
                .Include(e => e.gender)
                .Include(e => e.nationality)
                .Include(e => e.race)
                .Include(e => e.religion)
                .Include(e => e.status)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }

        private void PopulateDropDownLists(
            object selectedGender = null,
            object selectedNationality = null,
            object selectedRace = null,
            object selectedReiligion = null,
            object selectedStatus = null
            )
        {
            var gendersQuery = from g in _context.Genders
                               orderby g.Name
                               select g;
            ViewBag.GenderId = new SelectList(gendersQuery.AsNoTracking(), "Id", "Name", selectedGender);

            var nationalitiesQuery = from n in _context.Nationalities
                                     orderby n.Name
                                     select n;
            ViewBag.NationalityId = new SelectList(nationalitiesQuery.AsNoTracking(), "Id", "Name", selectedNationality);

            var racesQuery = from r in _context.Races
                             orderby r.Name
                             select r;
            ViewBag.RaceId = new SelectList(racesQuery.AsNoTracking(), "Id", "Name", selectedRace);

            var reiligionsQuery = from n in _context.Religiones
                                  orderby n.Name
                                  select n;
            ViewBag.ReligionId = new SelectList(reiligionsQuery.AsNoTracking(), "Id", "Name", selectedReiligion);

            var statusesQuery = from n in _context.Statuses
                                orderby n.Name
                                select n;
            ViewBag.StatusId = new SelectList(statusesQuery.AsNoTracking(), "Id", "Name", selectedStatus);

        }
    }
}
