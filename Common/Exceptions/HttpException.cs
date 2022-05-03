using System.Net;
using System.Runtime.Serialization;

namespace Common.Exceptions
{
    public class HttpException : ApplicationException
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Url { get; set; }

        public HttpException(HttpStatusCode statusCode, Exception innerException) : this(statusCode, innerException.Message, innerException)
        {
        }

        public HttpException(HttpStatusCode statusCode, string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public HttpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public HttpException() : base()
        {
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            StatusCode = (HttpStatusCode)info.GetUInt32("statusCode");
            Url = info.GetString("url");
        }
    }
}
