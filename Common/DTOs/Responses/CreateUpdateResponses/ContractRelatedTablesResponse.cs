using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.DTOs.Responses.CreateUpdateResponses.RelatedTables;

namespace Common.DTOs.Responses.CreateUpdateResponses
{
    public class ContractRelatedTablesResponse
    {
        public IEnumerable<ContractResponse> Contracts { get; set; }

        public IEnumerable<ClientRelatedTableResponse> Clients { get; set; }
    }
}
