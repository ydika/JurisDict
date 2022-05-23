using Common.Models.Base;

namespace Common.Models
{
    public record ContractService : BaseModel
    {
        public Guid ContractId { get; set; }
        public Contract Contract { get; set; }

        public Guid ServiceId { get; set; }
        public Service Service { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime AppointmentDate { get; set; }
        public DateTime PerformanceDate { get; set; }
    }
}