using Common.Models.Base;

namespace Common.Models
{
    public class Contract : BaseModel
    {
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public string ContractNumber { get; set; }
        public DateTime ConclusionDate { get; set; }
        public bool Status { get; set; }
    }
}