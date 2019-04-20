using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;
using System.Data;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetSearchVideoStory : SqlHelper
    {
       
        public List<DataClass.VideoDetails.GetVideoDetails> SearchByVideoStory(string Keyword, int Type,int UserID)
        {
            List<DataClass.VideoDetails.GetVideoDetails> ListUser = new List<DataClass.VideoDetails.GetVideoDetails>();

            string[,] param = { { "Keyword", Keyword.ToString() },
            { "Type", Type.ToString() },{ "UserID", UserID.ToString() }};
            DataTable dt = ExecuteProcedureReturnDataTable("SearchVideo_ByCategory", param);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListUser.Add(new DataClass.VideoDetails.GetVideoDetails(int.Parse(dt.Rows[i]["UploadedVideoIDP"].ToString()), dt.Rows[i]["UploadTitle"].ToString(), dt.Rows[i]["IncidentStateName"].ToString(), dt.Rows[i]["IncidentCityName"].ToString(),
                                                                        int.Parse(dt.Rows[i]["IncidentSubCategoryIDF"].ToString()), int.Parse(dt.Rows[i]["IncidentCategoryIDF"].ToString()), dt.Rows[i]["ThumbPath"].ToString(),
                                                                        dt.Rows[i]["VideoPath"].ToString(), dt.Rows[i]["FirstName"].ToString(), dt.Rows[i]["EntryDate"].ToString(),
                                                                        dt.Rows[i]["AreaOfCity"].ToString(), dt.Rows[i]["IncidentDescription"].ToString(), dt.Rows[i]["KeyWordForSearch"].ToString(),
                                                                        dt.Rows[i]["IncidentDate"].ToString(), dt.Rows[i]["VideoLike"].ToString(), dt.Rows[i]["VideoCountAll"].ToString(), dt.Rows[i]["VideoComment"].ToString()));
                }
            }
            return ListUser;
        }
        public List<DataClass.DataStory.GetStoryList> Get_StoryPic(string Keyword, int Type, int UserID)
        {
            List<DataClass.DataStory.GetStoryList> tblStory = new List<DataClass.DataStory.GetStoryList>();

            string[,] param = { { "Keyword", Keyword.ToString() },
            { "Type", Type.ToString() },{ "UserID", UserID.ToString() }};
            DataTable dt = ExecuteProcedureReturnDataTable("SearchVideo_ByCategory", param);
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