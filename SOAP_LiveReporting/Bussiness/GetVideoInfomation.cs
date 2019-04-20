using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using _SqlHelper;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetVideoInfomation : SqlHelper
    {
        public List<DataClass.VideoDetails.GetVideoDetails> Get_Video_InfoLR(int IncidentCategoryIDF, int UserID)
        {
            List<DataClass.VideoDetails.GetVideoDetails> ListUser = new List<DataClass.VideoDetails.GetVideoDetails>();

            string[,] param = { { "IncidentCategoryIDF", IncidentCategoryIDF.ToString() },
            { "UserID", UserID.ToString() }};
            DataTable dt = ExecuteProcedureReturnDataTable("GetAllVideo_ByCategory", param);
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

    }
}