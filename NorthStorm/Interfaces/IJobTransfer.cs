using NorthStorm.Models;
using NorthStorm.Models.ViewModels;

namespace NorthStorm.Interfaces
{
    public interface IJobTransfer
    {
        public string GetErrors();

        Task<PaginatedList<JobTransfer>> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5);
        Task<JobTransfer> GetItem(int id); // read particular item

        Task<bool> Create(JobTransfer jobTransfer);
        Task<bool> Edit(JobTransfer jobTransfer);
        Task<bool> Delete(JobTransfer jobTransfer);
        Task<bool> Update(JobTransfer jobTransfer);

    }
}
