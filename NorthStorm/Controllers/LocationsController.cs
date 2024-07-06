using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthStorm.Data;
using NorthStorm.Models.Assistants;
using System.Threading.Tasks;

namespace NorthStorm.Controllers
{
    public class LocationsController : Controller
    {
        private readonly NorthStormContext _context;

        public LocationsController(NorthStormContext context)
        {
            _context = context;
        }

        // GET: Location/Index
        public async Task<IActionResult> Index()
        {
            
            var locations = await _context.Locations
                    .Where(l => l.ParentLocationId == null)
                    .Include(l => l.ChildLocations)
                        .ThenInclude(c => c.ChildLocations)
                            .ThenInclude(c => c.ChildLocations)
                                .ThenInclude(c => c.ChildLocations) // Add more locations as needed
                    .ToListAsync();
            return View(locations);
        }

        // GET: Location/Create
        public IActionResult Create()
        {
            ViewBag.ParentLocations = new SelectList(_context.Locations, "Id", "Name");
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ParentLocationId")] Location location)
        {
            if (ModelState.IsValid)
            {
                _context.Add(location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ParentLocations = new SelectList(_context.Locations, "Id", "Name", location.ParentLocationId);
            return View(location);
        }

        // Other CRUD actions...
    }

}