using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? EmployeeName { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public bool IsActive { get; set; }
        public DateTime? HiringDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal? Salary { get; set; }

    }
}
