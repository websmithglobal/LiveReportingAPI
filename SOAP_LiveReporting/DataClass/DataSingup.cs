using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class DataSingup
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string IMEINo { get; set; }
        public string Password { get; set; }
        public string CityName { get; set; }
        public string AreaOfCity { get; set; }
        public string StateName { get; set; }
        public string Gender { get; set; }
    }

    public class DataUpdateProfile
    {
        public Int64 ClientIDP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
        public DateTime Dateofbirth { get; set; }
        public string CityName { get; set; }
        public string AreaOfCity { get; set; }
        public string StateName { get; set; }
        public string Gender { get; set; }
    }
}