using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class DataSocialMedia
    {
        public string SocialID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string ProfileLink { get; set; }
        public string PictureLink { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public DateTime Dateofbirth { get; set; }
    }
}