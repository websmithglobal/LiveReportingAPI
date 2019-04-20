using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class ClientInfo
    {
        public class GetClinetInfomation
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string EmailID { get; set; }
            public string MobileNo { get; set; }
            public string DateOfBirth { get; set; }
            public string JoinDate { get; set; }
            public int UserID { get; set; }
            public string Password { get; set; }

            public GetClinetInfomation(string _FirstName, string _LastName, string _EmailID, string _MobileNo, string _JoinDate,int _UserID,string _Password, string _DateOfBirth)
            {
                this.FirstName = _FirstName; this.LastName = _LastName; this.EmailID = _EmailID; this.MobileNo = _MobileNo; this.JoinDate = _JoinDate;
                this.UserID = _UserID;
                this.Password = _Password;
                this.DateOfBirth = _DateOfBirth;
            }
        }
    }
}