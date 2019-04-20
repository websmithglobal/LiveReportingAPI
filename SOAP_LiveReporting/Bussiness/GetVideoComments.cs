using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;
using System.Data;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetVideoComments
    {
        public List<DataClass.Video_Comments.GetVideo_Comments> GetUserVideoComments(int VIdeoIDF)
        {
            List<DataClass.Video_Comments.GetVideo_Comments> ListUser = new List<DataClass.Video_Comments.GetVideo_Comments>();
            DataTable dt = SqlHelper.GetDataUsingQuery("select TBC.EntryDate,TBC.Msg,TBU.FirstName from Tbl_User_Comments as TBC inner join tblClient as TBU on(TBC.UserIDF=TBU.ClientIDP) WHERE TBC.VideoIDF=" + VIdeoIDF + " order by TBC.CommentIDP desc");
            foreach (DataRow row in dt.Rows)
            {
                ListUser.Add(new DataClass.Video_Comments.GetVideo_Comments(row["EntryDate"].ToString(), row["Msg"].ToString(), row["FirstName"].ToString()));
            }
            return ListUser;

        }
    }
}