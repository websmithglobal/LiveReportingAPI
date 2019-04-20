using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;
using System.Data;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetBlog : SqlHelper
    {
        public List<DataClass.DataBlog.GetDataBlog> GetBlogList(int mainid,string Search)
        {
            List<DataClass.DataBlog.GetDataBlog> lstentity = new List<DataClass.DataBlog.GetDataBlog>();

            string[,] param = { { "mainid", mainid.ToString()}, { "Search", Search.ToString() } };
            DataTable dt = ExecuteProcedureReturnDataTable("Get_AllBlog", param);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lstentity.Add(new DataClass.DataBlog.GetDataBlog(dt.Rows[i]["title_name"].ToString(), dt.Rows[i]["tag_name"].ToString(), dt.Rows[i]["description"].ToString(), dt.Rows[i]["url"].ToString(), dt.Rows[i]["FirstName"].ToString(), dt.Rows[i]["entrydate"].ToString()));
                }
            }
            return lstentity;
        }
    }
}