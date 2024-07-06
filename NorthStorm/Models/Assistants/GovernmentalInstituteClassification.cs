using System.ComponentModel.DataAnnotations;

namespace NorthStorm.Models.Assistants
{
    public class GovernmentalInstituteClassification
    {
        #region Model Properties
        [Display(Name = "المعرف")]
        public int Id { get; set; }

        [Required, Display(Name = "التصنيف")]
        public string Name { get; set; }
        #endregion

        #region Navigation Properties
        public ICollection<GovernmentalInstitute> GovernmentalInstitutes { get; set; }
        #endregion
    }
}
