using Common.Models.Base;

namespace Common.Models
{
    public record Service : BaseModel
    {
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public double Price { get; set; }
    }
}