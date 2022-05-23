using Common.Models.Base;

namespace Common.Models
{
    public record Employee : BaseModel
    {
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        public Guid PositionId { get; set; }
        public Position Position { get; set; }

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