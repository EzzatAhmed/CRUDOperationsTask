using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.IReposetory
{
    public interface IEmployeeRepo
    {
        public Employee GetEmployeeById(int id);
        public bool UpdateEmployeeData(int EmployeeId,Employee emp);
        public bool DeleteEmployeeById(int id);
        public Employee InsertNewEmployee(Employee employee);
        public List<Employee> GetAllEmployees();
    }
}
