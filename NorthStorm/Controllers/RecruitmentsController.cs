using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthStorm.Data;
using NorthStorm.Interfaces;
using NorthStorm.Models;
using NorthStorm.Models.ViewModels;
using NorthStorm.ViewModels;

namespace NorthStorm.Controllers
{
    public class RecruitmentsController : Controller
    {
        private readonly NorthStormContext _context;

        private readonly IRecruitment _RecruitmentRepo;


        public RecruitmentsController(NorthStormContext context, IRecruitment recruitmentRepo)
        {
            _context = context;
            _RecruitmentRepo = recruitmentRepo;
        }

        // GET: Recruitments
        //public async Task<IActionResult> Index(int? id, int? employeeId)
        //{
        //    var viewModel = new List<Recruitment>();
        //    viewModel = await _context.Recruitments
        //          .Include(i => i.Employees)
        //          .AsNoTracking()
        //          .OrderBy(i => i.Id)
        //          .ToListAsync();

        //    if (id != null)
        //    {
        //        ViewData["RecruitmentId"] = id.Value;
        //        //Recruitment recruitment = viewModel.Where(
        //        //    i => i.Id == id.Value).Single();
        //        //viewModel.FirstOrDefault(recruitment).Employees = (ICollection<Employee>) viewModel.Select(s => s..Employees);
        //    }

        //    return View(viewModel);
        //}
#warning use async Task and await and AskNoTracking for all repos
        public IActionResult Index(
            int? selectedId, 
            string sortExpression = "", 
            string SearchText = "", 
            int pg = 1, 
            int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("ReferenceNo");
            sortModel.AddColumn("ReferenceDate");
            sortModel.AddColumn("Subject");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;
            ViewData["pageSize"] = pageSize;

            if (selectedId != null)
                ViewData["RecruitmentId"] = selectedId.Value;


            ViewBag.SearchText = SearchText;

            PaginatedList<Recruitment> items = _RecruitmentRepo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(items.TotalRecords, pg, pageSize);

            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;
            return View(items);
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
            PopulateDropDownLists();

            Recruitment recruitment = new Recruitment();
            recruitment.ReferenceDate = DateTime.Now;
            recruitment.Employees.Add(new Employee() { BirthDate = DateTime.Now });
            return View(recruitment);
        }

        // POST: Recruitments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReferenceNo,ReferenceDate,Subject, Employees")]  Recruitment recruitment)
        {
            if (ModelState.IsValid)
            {
                // لحذف الموظفين الذين تم حذفهم من نافذة الادخال قبل الحفظ
                recruitment.Employees.RemoveAll(a => string.IsNullOrEmpty(a.FirstName));

                // لتحميل قوائم الجنس والدين والقومية ... الخ
                PopulateDropDownLists();

                try
                {
                    _context.Recruitments.Add(recruitment);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "تم حفظ الأمر ذي العدد " + recruitment.ReferenceNo + " بنجاح";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    ModelState.AddModelError("RecruitmentsCreate_POST", ex.Message);
                }
            }

            return View(recruitment);
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
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return NotFound();
        }

        private bool RecruitmentExists(int id)
        {
            return _context.Recruitments.Any(e => e.Id == id);
        }
    }
}
