using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;
using System.Data;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetStory : SqlHelper
    {
        public List<DataClass.DataStory.GetStoryList> Get_StoryPic(int UserID)
        {
            List<DataClass.DataStory.GetStoryList> tblStory = new List<DataClass.DataStory.GetStoryList>();

            string[,] param = { { "UserID", UserID.ToString() } };
            DataTable dt = ExecuteProcedureReturnDataTable("GET_STORY", param);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tblStory.Add(new DataClass.DataStory.GetStoryList(int.Parse(dt.Rows[i]["UploadedVideoIDP"].ToString()), dt.Rows[i]["UploadTitle"].ToString(), dt.Rows[i]["IncidentStateName"].ToString(), dt.Rows[i]["IncidentCityName"].ToString(),
                                                                        dt.Rows[i]["AreaOfCity"].ToString(), dt.Rows[i]["UserName"].ToString(), dt.Rows[i]["IncidentDate"].ToString(),
                                                                        dt.Rows[i]["EntryDate"].ToString(),
                                                                        dt.Rows[i]["IncidentDescription"].ToString(), GetStoryPic(int.Parse(dt.Rows[i]["UploadedVideoIDP"].ToString()))));
                }
            }
            return tblStory;
        }
        public List<DataClass.DataStory.GetStoryPicLst> GetStoryPic(int UploadedVideoIDF)
        {
            List<DataClass.DataStory.GetStoryPicLst> ListObjPA = new List<DataClass.DataStory.GetStoryPicLst>();
            DataTable tblData = GetDataUsingQuery("SELECT StoryPicAndVideoPathIDP,'http://livereporting.in/' + StoryPicNVideoPath as StoryPicNVideoPath  FROM tblUploadStoryPicAndVideoPath where UploadedVideoIDF=" + UploadedVideoIDF + " order by StoryPicAndVideoPathIDP desc");
            if (tblData.Rows.Count > 0)
            {
                List<DataClass.DataStory.GetStoryPicLst> ListObjSA = new List<DataClass.DataStory.GetStoryPicLst>();
                for (int i = 0; i < tblData.Rows.Count; i++)
                {
                    ListObjPA.Add(new DataClass.DataStory.GetStoryPicLst(int.Parse(tblData.Rows[i]["StoryPicAndVideoPathIDP"].ToString()), tblData.Rows[i]["StoryPicNVideoPath"].ToString()));
                }
            }
            return ListObjPA;
        }
    }
}