using NorthStorm.Models.Assistants;

namespace NorthStorm.Models.Assistants
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public int? ParentLocationId { get; set; }

        public Location ParentLocation { get; set; }
        public ICollection<Location> ChildLocations { get; set; }
        public ICollection<Level> Levels { get; set; }
        public ICollection<GovernmentalInstitute> GovernmentalInstitutes { get; set; }
    }
}
