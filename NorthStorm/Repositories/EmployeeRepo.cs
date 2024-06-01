using Microsoft.EntityFrameworkCore;
using NorthStorm.Data;
using NorthStorm.Interfaces;
using NorthStorm.Models;
using NorthStorm.Models.ViewModels;

namespace NorthStorm.Repositories
{
    public class EmployeeRepo : IEmployee
    {
        private string _errors = "";

        public string GetErrors()
        {
            return _errors;
        }


        private readonly NorthStormContext _context; // for connecting to efcore.
        public EmployeeRepo(NorthStormContext context) // will be passed by dependency injection.
        {
            _context = context;
        }
        public bool Create(Employee employee)
        {
            bool retVal = false;
            _errors = "";

            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                retVal = true;
            }
            catch (Exception ex)
            {
                _errors = "Create Failed - Sql Exception Occured , Error Info : " + ex.Message;
            }
            return retVal;
        }


        public bool Delete(Employee employee)
        {
            bool retVal = false;
            _errors = "";

            try
            {
                _context.Attach(employee);
                _context.Entry(employee).State = EntityState.Deleted;
                _context.SaveChanges();
                retVal = true;
            }
            catch (Exception ex)
            {
                _errors = "Delete Failed - Sql Exception Occured , Error Info : " + ex.Message;
            }
            return retVal;
        }


        public bool Edit(Employee employee)
        {
            bool retVal = false;
            _errors = "";

            try
            {

                List<Employee> poDetails = _context.Employees.Where(d => d.Id == employee.Id).ToList();
                _context.Employees.RemoveRange(poDetails);
                _context.SaveChanges();

                _context.Attach(employee);
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();


                retVal = true;
            }
            catch (Exception ex)
            {
                _errors = "Update Failed - Sql Exception Occured , Error Info : " + ex.Message;
            }
            return retVal;
        }




        private List<Employee> DoSort(List<Employee> items, string SortProperty, SortOrder sortOrder)
        {

            if (SortProperty == "FullName")
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(n => n.FullName).ToList();
                else
                    items = items.OrderByDescending(n => n.FullName).ToList();
            }
            else if (SortProperty == "MotherName")
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(n => n.MotherName).ToList();
                else
                    items = items.OrderByDescending(n => n.MotherName).ToList();
            }
            else
            {
                if (sortOrder == SortOrder.Descending)
                    items = items.OrderByDescending(d => d.Id).ToList();
                else
                    items = items.OrderBy(d => d.Id).ToList();
            }

            return items;
        }

        public PaginatedList<Employee> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<Employee> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.Employees.Where(s =>
                s.Id.ToString().Equals(SearchText) ||
                s.FirstName.Contains(SearchText) ||
                s.MiddleName.Contains(SearchText) ||
                s.LastName.Contains(SearchText) ||
                s.FourthName.Contains(SearchText) ||
                s.SurName.Contains(SearchText))
                    .Include(e => e.gender)
                    .Include(e => e.nationality)
                    .Include(e => e.race)
                    .Include(e => e.religion)
                    .Include(e => e.status)
                .ToList();
            }
            else
                items = _context.Employees
                    .Include(e => e.gender)
                    .Include(e => e.nationality)
                    .Include(e => e.race)
                    .Include(e => e.religion)
                    .Include(e => e.status)
                   //.AsNoTracking();
                   .ToList();

            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<Employee> retItems = new PaginatedList<Employee>(items, pageIndex, pageSize);

            return retItems;
        }


        public Employee GetItem(int Id)
        {
            Employee item = _context.Employees.Where(i => i.Id == Id)
                     .FirstOrDefault();
            return item;
        }


    }
}
