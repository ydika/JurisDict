using Common.Models.Base;

namespace Common.Models
{
    public class Department : BaseModel
    {
        public string DepartmentName { get; set; }
        public string Location { get; set; }
    }
}