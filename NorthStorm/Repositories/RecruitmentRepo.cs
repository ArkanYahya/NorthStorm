using Microsoft.EntityFrameworkCore;
using NorthStorm.Data;
using NorthStorm.Interfaces;
using NorthStorm.Models;
using NorthStorm.Models.ViewModels;

namespace NorthStorm.Repositories
{
    public class RecruitmentRepo : IRecruitment
    {
        private string _errors = "";

        public string GetErrors()
        {
            return _errors;
        }


        private readonly NorthStormContext _context; // for connecting to efcore.
        public RecruitmentRepo(NorthStormContext context) // will be passed by dependency injection.
        {
            _context = context;
        }
        public bool Create(Recruitment recruitment)
        {
            bool retVal = false;
            _errors = "";

            try
            {
                _context.Recruitments.Add(recruitment);
                _context.SaveChanges();
                retVal = true;
            }
            catch (Exception ex)
            {
                _errors = "Create Failed - Sql Exception Occured , Error Info : " + ex.Message;
            }
            return retVal;
        }


        public bool Delete(Recruitment recruitment)
        {
            bool retVal = false;
            _errors = "";

            try
            {
                _context.Attach(recruitment);
                _context.Entry(recruitment).State = EntityState.Deleted;
                _context.SaveChanges();
                retVal = true;
            }
            catch (Exception ex)
            {
                _errors = "Delete Failed - Sql Exception Occured , Error Info : " + ex.Message;
            }
            return retVal;
        }


        public bool Edit(Recruitment recruitment)
        {
            bool retVal = false;
            _errors = "";

            try
            {

                List<Employee> poDetails = _context.Employees.Where(d => d.Id == recruitment.Id).ToList();
                _context.Employees.RemoveRange(poDetails);
                _context.SaveChanges();

                _context.Attach(recruitment);
                _context.Entry(recruitment).State = EntityState.Modified;
                _context.Employees.AddRange(recruitment.Employees);
                _context.SaveChanges();


                retVal = true;
            }
            catch (Exception ex)
            {
                _errors = "Update Failed - Sql Exception Occured , Error Info : " + ex.Message;
            }
            return retVal;
        }




        private List<Recruitment> DoSort(List<Recruitment> items, string SortProperty, SortOrder sortOrder)
        {

            if (SortProperty == "Subject")
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(n => n.Subject).ToList();
                else
                    items = items.OrderByDescending(n => n.Subject).ToList();
            }
            else if (SortProperty == "ReferenceDate")
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(n => n.ReferenceDate).ToList();
                else
                    items = items.OrderByDescending(n => n.ReferenceDate).ToList();
            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderByDescending(d => d.ReferenceNo).ToList();
                else
                    items = items.OrderBy(d => d.ReferenceNo).ToList();
            }

            return items;
        }

        public PaginatedList<Recruitment> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<Recruitment> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.Recruitments.Where(n => n.ReferenceNo.Contains(SearchText) || n.Subject.Contains(SearchText))
                    .Include(s => s.Employees)
                    .ToList();
            }
            else
                items = _context.Recruitments
                   .Include(s => s.Employees)
                   .ToList();




            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<Recruitment> retItems = new PaginatedList<Recruitment>(items, pageIndex, pageSize);

            return retItems;
        }


        public Recruitment GetItem(int Id)
        {
            Recruitment item = _context.Recruitments.Where(i => i.Id == Id)
                     .Include(d => d.Employees)
                     .FirstOrDefault();
            return item;
        }
    }
}
