using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class DataStory
    {
        public class GetStoryList
        {
            public int UploadedVideoIDP { get; set; }
            public string EntryDate { get; set; }
            public string UploadTitle { get; set; }
            public string IncidentStateName { get; set; }
            public string IncidentCityName { get; set; }
            public string AreaOfCity { get; set; }
            public string UserName { get; set; }
            public string IncidentDate { get; set; }
            public string IncidentDescription { get; set; }
            public List<GetStoryPicLst> StoryPic { get; set; }

            public GetStoryList(int _UploadedVideoIDP, string _UploadTitle, string _IncidentStateName, string _IncidentCityName, string _AreaOfCity, string _UserName, string _IncidentDate, string _EntryDate, string _IncidentDescription, List<GetStoryPicLst> _SubStoryList)
            {
                this.UploadedVideoIDP = _UploadedVideoIDP;
                this.UploadTitle = _UploadTitle;
                this.IncidentStateName = _IncidentStateName;
                this.IncidentCityName = _IncidentCityName;
                this.EntryDate = _EntryDate;
                this.AreaOfCity = _AreaOfCity;
                this.IncidentDescription = _IncidentDescription;
                this.IncidentDate = _IncidentDate;
                this.UserName = _UserName;
                this.StoryPic = _SubStoryList;
            }
        }
        public class GetStoryPicLst
        {
            public int StoryPicAndVideoPathIDP { get; set; }
            public string StoryPicNVideoPath { get; set; }


            public GetStoryPicLst(int _StoryPicAndVideoPathIDP, string _StoryPicNVideoPath)
            {
                this.StoryPicAndVideoPathIDP = _StoryPicAndVideoPathIDP; this.StoryPicNVideoPath = _StoryPicNVideoPath;
            }
        }
    }
}