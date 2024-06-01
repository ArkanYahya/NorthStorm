using NorthStorm.Models;
using NorthStorm.Models.ViewModels;

namespace NorthStorm.Interfaces
{
    public interface IEmployee
    {
        public string GetErrors();

        PaginatedList<Employee> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5);
        Employee GetItem(int id); // read particular item

        bool Create(Employee employee);
        bool Edit(Employee employee);
        bool Delete(Employee employee);

    }
}
