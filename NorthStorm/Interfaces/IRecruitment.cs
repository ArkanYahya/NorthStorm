using NorthStorm.Models;
using NorthStorm.Models.ViewModels;

namespace NorthStorm.Interfaces
{
    public interface IRecruitment
    {
        public string GetErrors();

        PaginatedList<Recruitment> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5);
        Recruitment GetItem(int id); // read particular item

        bool Create(Recruitment recruitment);
        bool Edit(Recruitment recruitment);
        bool Delete(Recruitment recruitment);

    }
}
