using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST_DEV_API.Errors
{
    public class APIException
    {
        public APIException(int StatusCode, string Message, string Details)
        {

            this.StatusCode = StatusCode;
            this.Message = Message;
            this.Details = Details;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}
