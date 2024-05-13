using System.ComponentModel.DataAnnotations;

namespace NorthStorm.Models
{
    public class Religion
    {
        #region Model Properties
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        #endregion

        #region Navigation Properties
        public ICollection<Employee> Employees { get; set; }
        #endregion
    }
}
