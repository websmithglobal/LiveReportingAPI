using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class VideoDetails
    {
        public class GetVideoDetails
        {
            public int UploadedVideoIDP { get; set; }
            public string UploadTitle { get; set; }
            public string IncidentStateName { get; set; }
            public string IncidentCityName { get; set; }
            public int IncidentSubCategoryIDF { get; set; }
            public int IncidentCategoryIDF { get; set; }
            public string ThumbPath { get; set; }
            public string VideoPath { get; set; }
            public string FirstName { get; set; }
            public string EntryDate { get; set; }
            public string AreaOfCity { get; set; }
            public string IncidentDescription { get; set; }
            public string KeyWordForSearch { get; set; }
            public string IncidentDate { get; set; }
            public string VideoLike { get; set; }
            public string VideoCountAll { get; set; }

            public string VideoComment { get; set; }

            public GetVideoDetails(int _UploadedVideoIDP, string _UploadTitle, string _IncidentStateName,string _IncidentCityName, int _IncidentSubCategoryIDF, int _IncidentCategoryIDF, string _ThumbPath, string _VideoPath, string _FirstName, string _EntryDate, string _AreaOfCity, string _IncidentDescription, string _KeyWordForSearch, string _IncidentDate, string _VideoLike, string _VideoCountAll, string _VideoComment)
            {
                this.UploadedVideoIDP = _UploadedVideoIDP; this.UploadTitle = _UploadTitle; this.IncidentStateName = _IncidentStateName;
                this.IncidentCityName = _IncidentCityName; this.IncidentSubCategoryIDF = _IncidentSubCategoryIDF; this.IncidentCategoryIDF = _IncidentCategoryIDF; this.ThumbPath = _ThumbPath; this.VideoPath = _VideoPath; this.FirstName = _FirstName; this.EntryDate = _EntryDate; this.AreaOfCity = _AreaOfCity;
                this.IncidentDescription = _IncidentDescription;
                this.KeyWordForSearch = _KeyWordForSearch;
                this.IncidentDate = _IncidentDate;
                this.VideoLike = _VideoLike;
                this.VideoCountAll = _VideoCountAll;
                this.VideoComment = _VideoComment;
            }
        }
    }
}