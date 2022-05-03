using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.DTOs.Responses.CreateUpdateResponses.RelatedTables;

namespace Common.DTOs.Responses.CreateUpdateResponses
{
    public class EmployeeRelatedTablesResponse
    {
        public IEnumerable<EmployeeResponse> Employees { get; set; }

        public IEnumerable<DepartmentRelatedTableResponse> Departments { get; set; }
        public IEnumerable<PositionRelatedTableResponse> Positions { get; set; }
    }
}
