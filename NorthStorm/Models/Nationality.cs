using System.ComponentModel.DataAnnotations;

namespace NorthStorm.Models
{
    public class Nationality
    {
        #region Model Properties
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        #endregion

        #region Navigstion Properties
        public ICollection<Employee> Employees { get; set; }
        #endregion
    }
}
