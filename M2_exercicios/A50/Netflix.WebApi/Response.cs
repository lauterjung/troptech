using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflix.WebApi
{
    public class Response
    {
        public int Status { get; set; }
        public string Message { get; set; }
        
        public Response(int status, string message)
        {
            this.Status = status;
            this.Message = message;
        }

        public Response()
        {

        }
    }
}