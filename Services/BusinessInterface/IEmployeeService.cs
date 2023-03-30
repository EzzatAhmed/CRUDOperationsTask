using ApplicationCore.Models;
using ApplicationInfrastructure.DTOS;
using Services.ViewModels.RequestViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BusinessInterface
{
    public interface IEmployeeService
    {
        public EmployeeVM GetEmployeeById(int id);
        public bool UpdateEmployeeData(int EmployeeId, EmployeeRequestViewModel emp);
        public bool DeleteEmployeeById(int id);
        public EmployeeVM InsertNewEmployee(EmployeeRequestViewModel employee);
        public List<EmployeeVM> GetAllEmployees();
    }
}
