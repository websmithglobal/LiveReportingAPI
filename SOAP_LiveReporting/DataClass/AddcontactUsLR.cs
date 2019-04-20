using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class AddcontactUsLR
    {
        public string UserName { get; set; }
        public string Subject { get; set; }
        public string EmailID { get; set; }
        public string Message { get; set; }
    }
}