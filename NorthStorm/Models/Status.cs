namespace NorthStorm.Models
{
    public class Status
    {
        #region Model Properties
        public int Id { get; set; }
        public string Name { get; set; }
        #endregion

        #region Navigation Properties
        public ICollection<Employee> Employees { get; set; }
        #endregion

    }
}
