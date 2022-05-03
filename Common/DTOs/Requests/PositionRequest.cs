using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Requests
{
    public class PositionRequest
    {
        public Guid Id { get; set; }
        public string PositionName { get; set; }
        public string PositionType { get; set; }
        public string Description { get; set; }
    }
}
