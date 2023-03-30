using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IReposetory;
using ApplicationCore.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationInfrastructure.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly IGenericRepository<Employee> _emp;
        public EmployeeRepo(IGenericRepository<Employee> emp)
        {
            _emp = emp;
        }
        public bool DeleteEmployeeById(int id)
        {
            Employee employee = new Employee();
            employee = _emp.GetByID(id);
            if (employee != null)
            {
               _emp.Delete(employee.Id);
                 return _emp.save();
            }
            else { return false; }
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee = new Employee();
            employee = _emp.GetByID(id);
            return employee;
        }

        public Employee InsertNewEmployee(Employee employee)
        {
            Employee newEmployee = new Employee();
            newEmployee = _emp.Create(employee);
            bool res = _emp.save();
            return newEmployee;
        }

        public bool UpdateEmployeeData(int EmployeeId, Employee emp)
        {
            Employee employee = new();
            employee = _emp.GetByID(EmployeeId);
            employee = emp;
            _emp.update(employee);
            return _emp.save();
        }
        public List<Employee> GetAllEmployees() 
        {
            List<Employee> employees = new List<Employee>();
            employees = _emp.GetAll().ToList();
            return employees;
        }

    }
}
