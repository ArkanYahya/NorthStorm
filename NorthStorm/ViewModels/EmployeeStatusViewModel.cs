
using Microsoft.AspNetCore.Mvc.Rendering;
using NorthStorm.Models;
using System.Collections.Generic;


namespace NorthStorm.ViewModels
{
    public class EmployeeStatusViewModel
    {
        public List<Employee>? Employees { get; set; }
        public SelectList? Statuses { get; set; }
        public string? EmployeeStatus { get; set; }
        public string? SearchString { get; set; }
    }
}