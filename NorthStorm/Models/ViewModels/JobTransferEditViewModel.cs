using System.ComponentModel.DataAnnotations;

namespace NorthStorm.Models.ViewModels
{
    public class JobTransferEditViewModel
    {
        public int JobTransferId { get; set; }
        [Required, Display(Name ="العدد")]
        public string ReferenceNo { get; set; }
        [Required, DataType(DataType.Date), Display(Name = "التاريخ")]
        public DateTime ReferenceDate { get; set; }
        [Required, Display(Name = "الموضوع")]
        public string Subject { get; set; }
        [Display(Name = "نقل من")]
        public string TransferFrom { get; set; }
        [Display(Name = "نقل إلى")]
        public string TransferTo { get; set; }
        public List<EmployeesInfo> Employees { get; set; } = new List<EmployeesInfo>();
    }

    public class EmployeesInfo
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
    }
}
