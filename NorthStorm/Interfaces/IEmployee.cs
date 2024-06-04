using Microsoft.AspNetCore.Mvc;
using NorthStorm.Models;
using NorthStorm.Models.ViewModels;

namespace NorthStorm.Interfaces
{
    public interface IEmployee
    {
        public string GetErrors();

        Task<PaginatedList<Employee>> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5);
        Task<Employee> GetItem(int id); // read particular item

        Task<bool> Create(Employee employee);
        Task<bool> Edit(Employee employee);
        Task<bool> Delete(Employee employee);

    }
}
