using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Responses
{
    public class HttpExceptionResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
        public string StackTrace { get; set; }
    }
}
