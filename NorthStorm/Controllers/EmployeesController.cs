using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthStorm.Data;
using NorthStorm.Interfaces;
using NorthStorm.Models;
using NorthStorm.Models.ViewModels;
using NorthStorm.Repositories;
using NorthStorm.ViewModels;

namespace NorthStorm.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly NorthStormContext _context;
        private readonly IEmployee _EmployeeRepo;

        public EmployeesController(NorthStormContext context, IEmployee employeeRepo)
        {
            _context = context;
            _EmployeeRepo = employeeRepo;
        }

        // GET: Employees
        //public async Task<IActionResult> Index(string searchString)
        //{
        //    if (_context.Employees == null)
        //    {
        //        return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
        //    }

        //    var employees = _context.Employees
        //        .Include(e => e.gender)
        //        .Include(e => e.nationality)
        //        .Include(e => e.race)
        //        .Include(e => e.religion)
        //        .Include(e => e.status)
        //        .AsNoTracking();

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        // لانه ليس حقلا في الجدول  FullName للبحث عن الاسم الكامل، ولا يمكن استخدام
        //        employees = employees.Where(s => 
        //        s.Id.ToString().Equals(searchString) ||
        //        s.FirstName.Contains(searchString) || 
        //        s.MiddleName.Contains(searchString) ||
        //        s.LastName.Contains(searchString) ||
        //        s.FourthName.Contains(searchString) ||
        //        s.SurName.Contains(searchString)
        //        );
        //    }

        //    return View(await employees.ToListAsync());
        //}

        // GET: Employees
        public IActionResult Index(
            string sortExpression = "",
            string SearchText = "",
            int pg = 1,
            int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("EmployeeId");
            sortModel.AddColumn("FullName");
            sortModel.AddColumn("MotherName");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;
            ViewData["pageSize"] = pageSize;

            ViewBag.SearchText = SearchText;

            PaginatedList<Employee> items = _EmployeeRepo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);

            var pager = new PagerModel(items.TotalRecords, pg, pageSize);

            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;

            TempData["CurrentPage"] = pg;
            return View(items);

            // Use LINQ to get list of state.
            //IQueryable<string> statusQuery = from m in _context.Employees
            //                                 orderby m.status.Name
            //                                 select m.status.Name;

            //var employees = _context.Employees
            //    .Include(e => e.gender)
            //    .Include(e => e.nationality)
            //    .Include(e => e.race)
            //    .Include(e => e.religion)
            //    .Include(e => e.status)
            //    .AsNoTracking();


            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    employees = employees.Where(s =>
            //                   s.Id.ToString().Equals(searchString) ||
            //                   s.FirstName.Contains(searchString) ||
            //                   s.MiddleName.Contains(searchString) ||
            //                   s.LastName.Contains(searchString) ||
            //                   s.FourthName.Contains(searchString) ||
            //                   s.SurName.Contains(searchString)
            //                   );
            //}

            //if (!string.IsNullOrEmpty(employeeStatus))
            //{
            //    employees = employees.Where(x => x.status.Name == employeeStatus);
            //}

            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        employees = employees.OrderByDescending(s => (s.FirstName + " " + s.MiddleName + " " + s.LastName + " " + s.FourthName + " " + s.SurName));
            //        break;
            //    case "Date":
            //        employees = employees.OrderBy(s => s.BirthDate);
            //        break;
            //    case "date_desc":
            //        employees = employees.OrderByDescending(s => s.BirthDate);
            //        break;
            //    default:
            //        employees = employees.OrderBy(s => (s.FirstName + " " + s.MiddleName + " " + s.LastName + " " + s.FourthName + " " + s.SurName));
            //        break;
            //}

            // pageSize = 3;
            ////var employeeStatusVM = new EmployeeStatusViewModel
            ////{
            ////    Statuses = new SelectList(await statusQuery.Distinct().ToListAsync()),
            ////    Employees = await PaginatedList<Employee>.CreateAsync(employees.AsNoTracking(), pageNumber ?? 1, pageSize)
            ////};
            ////return View(employeeStatusVM);

            ////return View(await employees.AsNoTracking().ToListAsync());
            //return View(await oldPaginatedList<Employee>.CreateAsync(employees.AsNoTracking(), pageNumber ?? 1, pageSize));
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
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return NotFound();

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
