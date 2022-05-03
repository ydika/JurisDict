using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Requests
{
    public class ClientRequest
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PassportData { get; set; }
        public string Gender { get; set; }
    }
}
