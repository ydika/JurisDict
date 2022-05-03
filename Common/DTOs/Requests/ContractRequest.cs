using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Requests
{
    public class ContractRequest
    {
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }

        public string ContractNumber { get; set; }
        public DateTime ConclusionDate { get; set; }
        public bool Status { get; set; }
    }
}
