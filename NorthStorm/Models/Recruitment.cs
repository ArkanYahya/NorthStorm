using System.ComponentModel.DataAnnotations;

namespace NorthStorm.Models
{
    public class Recruitment
    {
        #region Model Properties
        public int Id { get; set; }

        [Required, Display(Name ="العدد")]
        public string ReferenceNo { get; set; }

        [Required, DataType(DataType.Date), Display(Name = "التاريخ")]
        public DateTime ReferenceDate { get; set; } = DateTime.Now.Date;

        [Required, Display(Name = " الموضوع / رقم الأمر الإداري")]
        public string Subject { get; set; }
        #endregion

        #region Navigation Properties
        public List<Employee> Employees{ get; set; } = new List<Employee>();
        #endregion
    }
}
