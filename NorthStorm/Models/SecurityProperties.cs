namespace NorthStorm.Models
{
    public class SecurityProperties
    {

        #region Security Properties
        // *********************************** الخواص الأمنية للحقول  *************************  // 
        // يمكنك إستخدام مزود خدمة قواعد البيانات في توليد قيمة محسوبة للحقل، مثلا
        // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        // ولكن هناك بعض القيم يجب ان تحتسب بشكل يدوي عن طريق توليدها في
        // Data\AppliationDbContext

        // من المفترض ان يتم حفظ وقت وتاريخ آخر تعديل
        // لكن يجب اعداد
        // Trigger
        // في قواعد البيانات
#warning set up a trigger in database to save record update timedate

        // لحفظ وقت وتاريخ انشاء القيد
        public DateTime RowCreatedTime { get; set; }

        // لحفظ وقت وتاريخ تعديل القيد
        public DateTime LastUpdatedTime { get; set; }

        // لبيان حالة القيد
        // pending, approved, rejected
        public State State { get; set; }

        public String ApprovedBy { get; set; }

        public String CreatedBy { get; set; }

        public String UpdatedBy { get; set;}

        public String DeletedBy { get; set; }
        public bool IsDeleted { get; set; }

        #endregion
    }
}
