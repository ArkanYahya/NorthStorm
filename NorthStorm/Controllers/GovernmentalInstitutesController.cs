using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthStorm.Data;
using NorthStorm.Models.Assistants;
using System.Threading.Tasks;

namespace NorthStorm.Controllers
{
    public class GovernmentalInstitutesController : Controller
    {
        private readonly NorthStormContext _context;

        public GovernmentalInstitutesController(NorthStormContext context)
        {
            _context = context;
        }

        // GET: Location/Index
        public async Task<IActionResult> Index()
        {
            
            var governmentalInstitutes = await _context.GovernmentalInstitutes
                    .Where(l => l.ParentGovernmentalInstituteId == null)
                    .Include(l => l.ChildGovernmentalInstitutes)
                        .ThenInclude(c => c.ChildGovernmentalInstitutes)
                            .ThenInclude(c => c.ChildGovernmentalInstitutes)
                                .ThenInclude(c => c.ChildGovernmentalInstitutes) // Add more governmentalInstitutes as needed
                    .ToListAsync();
            return View(governmentalInstitutes);
        }

        // GET: GovernmentalInstitute/Create
        public IActionResult Create()
        {
            ViewBag.ParentGovernmentalInstitutes = new SelectList(_context.GovernmentalInstitutes, "Id", "Name");
            return View();
        }

        // POST: GovernmentalInstitute/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ParentGovernmentalInstituteId")] GovernmentalInstitute governmentalInstitute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(governmentalInstitute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ParentGovernmentalInstitutes = new SelectList(_context.GovernmentalInstitutes, "Id", "Name", governmentalInstitute.ParentGovernmentalInstituteId);
            return View(governmentalInstitute);
        }

        // Other CRUD actions...
    }

}