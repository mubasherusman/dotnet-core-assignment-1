using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class HeaderNotFoundException : Exception
    {
        public int HttpStatusCode { get; private set; }

        public HeaderNotFoundException()
        {

        }

        public HeaderNotFoundException(int httpStatusCode, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
