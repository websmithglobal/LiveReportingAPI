using SOAP_LiveReporting.DataClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace SOAP_LiveReporting.Bussiness
{

    public class SaveUploadVideoTaxdata:SoapHeader
    {
        public SaveUploadVideoClass[] taxdata { get; set; }
        public UserAuthntication ObjAuth { get; set; }
    }
}