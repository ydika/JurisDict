using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Responses.CreateUpdateResponses
{
    public class RelatedTables
    {
        public class ClientRelatedTableResponse
        {
            public Guid Id { get; set; }
            public string FullName { get; set; }
        }

        public class ContractRelatedTableResponse
        {
            public Guid Id { get; set; }
            public string ContractNumber { get; set; }
        }

        public class DepartmentRelatedTableResponse
        {
            public Guid Id { get; set; }
            public string DepartmentName { get; set; }
        }

        public class EmployeeRelatedTableResponse
        {
            public Guid Id { get; set; }
            public string FullName { get; set; }
        }

        public class PositionRelatedTableResponse
        {
            public Guid Id { get; set; }
            public string PositionName { get; set; }
        }

        public class ServiceRelatedTableResponse
        {
            public Guid Id { get; set; }
            public string ServiceName { get; set; }
        }
    }
}
