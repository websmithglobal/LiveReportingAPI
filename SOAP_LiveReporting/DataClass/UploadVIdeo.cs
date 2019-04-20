using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class UploadVIdeo
    {
        public int UploadedVideoIDP { get; set; }
        public int UploadTypeID { get; set; }
        public string UploadTitle { get; set; }
        public int IncidentCategoryIDF { get; set; }
        public int IncidentSubCategoryIDF { get; set; }
        public string IncidentCityName { get; set; }
        public string AreaOfCity { get; set; }
        public string IncidentDate { get; set; }
        public string IncidentDescription { get; set; }
        public string KeyWordForSearch { get; set; }
        public bool IsApproved { get; set; }
        public bool IsReject { get; set; }
        public bool IsFeatured { get; set; }
        public int UserID { get; set; }
        public int UserType { get; set; }
        public string video_path { get; set; }
        public string thumbpath { get; set; }
        public string Flag { get; set; }
        public int AreaID { get; set; }
        public string IncidentStateName { get; set; }

        //public List<string> SubImages = new List<string>();
    }
}