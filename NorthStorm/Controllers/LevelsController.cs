using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthStorm.Data;
using NorthStorm.Models.Assistants;
using System.Threading.Tasks;

namespace NorthStorm.Controllers
{
    public class LevelsController : Controller
    {
        private readonly NorthStormContext _context;

        public LevelsController(NorthStormContext context)
        {
            _context = context;
        }

        // GET: Location/Index
        public async Task<IActionResult> Index()
        {
            
            var levels = await _context.Levels
                    .Where(l => l.ParentLevelId == null)
                    .Include(l => l.ChildLevels)
                        .ThenInclude(c => c.ChildLevels)
                            .ThenInclude(c => c.ChildLevels)
                                .ThenInclude(c => c.ChildLevels) // Add more levels as needed
                    .ToListAsync();
            return View(levels);
        }

        // GET: Level/Create
        public IActionResult Create()
        {
            ViewBag.ParentLevels = new SelectList(_context.Levels, "Id", "Name");
            return View();
        }

        // POST: Level/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ParentLevelId")] Level level)
        {
            if (ModelState.IsValid)
            {
                _context.Add(level);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ParentLevels = new SelectList(_context.Levels, "Id", "Name", level.ParentLevelId);
            return View(level);
        }

        // Other CRUD actions...
    }

}