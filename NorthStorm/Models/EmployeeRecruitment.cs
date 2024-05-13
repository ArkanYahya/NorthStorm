using System.ComponentModel.DataAnnotations;

namespace NorthStorm.Models
{
#warning deal with cascade delete by EF

    public class EmployeeRecruitment
    {
        #region Model Properties
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int RecruitmentId { get; set; }

        #endregion

        #region Navigation Properties
        public Employee Employee { get; set; }

        public Recruitment Recruitment { get; set; }
        #endregion
    }
}