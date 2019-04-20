using _SqlHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetIMEI
    {
        public Bussiness.AuthResponse Save_IMEI(DataClass.DataIMEI obj)
        {
            int OutS = SqlHelper.DML("UPDATE tblClient SET IMEINo='" + obj.IMEI + "' WHERE ClientIDP=" + obj.Mainid + "");
            return new Bussiness.AuthResponse(OutS == 1 ? 1 : 0, OutS == 1 ? "IMEI UPDATED" : "IMEI UPDATE FAILED");
        }
    }
}