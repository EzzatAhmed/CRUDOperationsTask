using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationInfrastructure.DTOS
{
    public class EmployeeVM
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? JobTitle { get; set; }
        public string? JobDescription { get; set; }
        public DateTime? HiringDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal? Salary { get; set; }

    }
}
