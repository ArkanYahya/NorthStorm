using NorthStorm.Models;
using NorthStorm.Models.ViewModels;

namespace NorthStorm.Interfaces
{
    public interface IRecruitment
    {
        public string GetErrors();

        Task<PaginatedList<Recruitment>> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5);
        Task<Recruitment> GetItem(int id); // read particular item

        Task<bool> Create(Recruitment recruitment);
        Task<bool> Edit(Recruitment recruitment);
        Task<bool> Delete(Recruitment recruitment);
        Task<bool> Update(Recruitment recruitment);

    }
}
