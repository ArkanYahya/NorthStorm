using Microsoft.CodeAnalysis;

namespace NorthStorm.Models.Assistants
{
    public class Level
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int? ParentLevelId { get; set; }
        public int? LocationId { get; set; }


        public Level ParentLevel { get; set; }
        public Location Location { get; set; }
        public ICollection<JobTransfer> JobTransfers { get; set; }
        public ICollection<JobTitle> JobTitles { get; set; }
        public ICollection<Level> ChildLevels { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}