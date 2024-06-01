using NorthStorm.Models;

namespace NorthStorm.ViewModels
{
    public class RecruitmentsVM
    {
        public ICollection<Recruitment> Recruitments { get; set; } = new List<Recruitment>();
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        
    }

    public class RecruitmentsVMSingle
    {
        public Recruitment recruitment { get; set; } = new Recruitment();
        public List<Employee> employees { get; set; } = new List<Employee>();

    }
}
