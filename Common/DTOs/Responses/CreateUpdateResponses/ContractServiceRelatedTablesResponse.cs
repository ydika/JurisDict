using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.DTOs.Responses.CreateUpdateResponses.RelatedTables;

namespace Common.DTOs.Responses.CreateUpdateResponses
{
    public class ContractServiceRelatedTablesResponse
    {
        public IEnumerable<ContractServiceResponse> ContractServices { get; set; }

        public IEnumerable<ContractRelatedTableResponse> Contracts { get; set; }
        public IEnumerable<ServiceRelatedTableResponse> Services { get; set; }
        public IEnumerable<EmployeeRelatedTableResponse> Employees { get; set; }
    }
}
