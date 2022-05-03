using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Requests
{
    public class ServiceRequest
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public double Price { get; set; }
    }
}
