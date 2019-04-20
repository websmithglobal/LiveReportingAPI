using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;
using System.Web.Services.Protocols;
using SOAP_LiveReporting;
namespace SOAP_LiveReporting.DataClass
{
    public class UserAuthntication : SoapHeader
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
    }
}