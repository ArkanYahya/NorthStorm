using Microsoft.EntityFrameworkCore;
using NorthStorm.Data;
using NorthStorm.Models.Assistants;

namespace NorthStorm.Services
{
    public class LevelService
    {
        private readonly NorthStormContext _context;

        public LevelService(NorthStormContext context)
        {
            _context = context;
        }

        public async Task<List<Level>> GetLevelHierarchy()
        {
            return await _context.Levels
                .Include(l => l.ChildLevels)
                .Where(l => l.ParentLevelId == null)
                .ToListAsync();
        }

        public async Task<List<Level>> GetAllLevels()
        {
            return await _context.Levels.ToListAsync();
        }
    }

}
