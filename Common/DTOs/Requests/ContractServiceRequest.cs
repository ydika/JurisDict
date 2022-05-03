using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Requests
{
    public class ContractServiceRequest
    {
        public Guid Id { get; set; }

        public Guid ContractId { get; set; }
        public virtual Contract Contract { get; set; }

        public Guid ServiceId { get; set; }
        public virtual Service Service { get; set; }

        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public DateTime AppointmentDate { get; set; }
        public DateTime PerformanceDate { get; set; }
    }
}
