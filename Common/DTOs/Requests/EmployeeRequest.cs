using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Requests
{
    public class EmployeeRequest
    {
        public Guid Id { get; set; }

        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public Guid PositionId { get; set; }
        public virtual Position Position { get; set; }

        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Salary { get; set; }
        public string PassportData { get; set; }
        public int Experience { get; set; }
        public string Gender { get; set; }
    }
}
