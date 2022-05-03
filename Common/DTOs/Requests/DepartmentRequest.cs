using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Requests
{
    public class DepartmentRequest
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }
    }
}
