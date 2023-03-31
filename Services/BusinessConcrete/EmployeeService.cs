using ApplicationCore.Interfaces.IReposetory;
using ApplicationCore.Models;
using ApplicationInfrastructure.DTOS;
using Services.BusinessInterface;
using Services.ViewModels.RequestViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessConcrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        public bool DeleteEmployeeById(int id)
        {
            return _employeeRepo.DeleteEmployeeById(id);
        }

        public EmployeeVM GetEmployeeById(int id)
        {
            EmployeeVM emp = new EmployeeVM();
            Employee employee = new Employee();
            employee = _employeeRepo.GetEmployeeById(id);
            if (employee != null)
            {
                emp.EmployeeId = employee.Id;
                emp.EmployeeName= employee.EmployeeName;
                emp.Salary  = employee.Salary;
                emp.HiringDate = employee.HiringDate;
                emp.BirthDate   = employee.BirthDate;
                emp.JobDescription = employee.JobDescription;
                emp.JobTitle = employee.JobTitle;
            }
            return emp;
        }

        public EmployeeVM InsertNewEmployee(EmployeeRequestViewModel newEmployee)
        {
            EmployeeVM emp = new EmployeeVM();
            Employee employee = new Employee();
            employee.EmployeeName = newEmployee.EmployeeName;
            employee.Salary = newEmployee.Salary;
            employee.HiringDate = newEmployee.HiringDate;
            employee.BirthDate = newEmployee.BirthDate;
            employee.JobDescription = newEmployee.JobDescription;
            employee.JobTitle = newEmployee.JobTitle;
            employee = _employeeRepo.InsertNewEmployee(employee);
            if (employee != null)
            {
                emp.JobDescription = employee.JobDescription;
                emp.BirthDate= employee.BirthDate;
                emp.HiringDate= employee.HiringDate;
                emp.Salary= employee.Salary;
                emp.EmployeeName = employee.EmployeeName;
                emp.EmployeeId = employee.Id;
            }
            return emp;
        }

        public bool UpdateEmployeeData(int EmployeeId, EmployeeRequestViewModel newEmployee)
        {
            bool res=false;
            Employee employee = new Employee();
            employee.EmployeeName = newEmployee.EmployeeName;
            employee.Salary = newEmployee.Salary;
            employee.HiringDate = newEmployee.HiringDate;
            employee.BirthDate = newEmployee.BirthDate;
            employee.JobDescription = newEmployee.JobDescription;
            employee.JobTitle = newEmployee.JobTitle;
            if (_employeeRepo.UpdateEmployeeData(EmployeeId, employee))
            {
                res = true;
            }
            return res;

        }
        public List<EmployeeVM> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            List<EmployeeVM> employeeVMs = new List<EmployeeVM>();
            employees= _employeeRepo.GetAllEmployees();

            foreach (Employee employee in employees)
            {
                EmployeeVM employeeVM = new EmployeeVM();
                employeeVM.Salary = employee.Salary;
                employeeVM.EmployeeName = employee.EmployeeName;
                employeeVM.EmployeeId = employee.Id;
                employeeVM.BirthDate = employee.BirthDate;
                employeeVM.HiringDate= employee.HiringDate;
                employeeVM.JobDescription = employee.JobDescription;
                employeeVM.JobTitle = employee.JobTitle;
                employeeVMs.Add(employeeVM);
            }


            return employeeVMs;
        }
    }
}
