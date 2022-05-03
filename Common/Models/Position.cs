using Common.Models.Base;

namespace Common.Models
{
    public class Position : BaseModel
    {
        public string PositionName { get; set; }
        public string PositionType { get; set; }
        public string Description { get; set; }
    }
}