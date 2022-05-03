using Common.Models.Base;

namespace Common.Models
{
    public class Client : BaseModel
    {
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PassportData { get; set; }
        public string Gender { get; set; }
    }
}