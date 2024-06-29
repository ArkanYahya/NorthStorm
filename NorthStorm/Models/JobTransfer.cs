using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthStorm.Models
{
    public class JobTransfer
    {
        #region Model Properties
        public int Id { get; set; }

        [Required, Display(Name ="العدد")]
        public string ReferenceNo { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "التاريخ")]
        public DateTime ReferenceDate { get; set; } = DateTime.Now.Date;

        [Required, Display(Name = "الموضوع")]
        public string Subject { get; set; }


        [Display(Name = "نقل من")]
        public string TransferFrom { get; set; }

        [Display(Name = "نقل إلى")]
        public string TransferTo { get; set; }
        #endregion

        #region Not Mapped Properties
        [NotMapped, Display(Name ="عدد الموظفين")]
        public int EmployeeCount { get; set; }
        #endregion

        #region Navigation Properties
        public ICollection<Employee> Employees{ get; set; } = new Collection<Employee>();
        #endregion
    }
}
