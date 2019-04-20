using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;
using System.Data;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetBannerLR
    {
        public List<DataClass.Banner.GetBanner> GetYourBanner()
        {
            List<DataClass.Banner.GetBanner> ListUser = new List<DataClass.Banner.GetBanner>();
            DataTable dt = SqlHelper.GetDataUsingQuery("select priority,status,bannerIDP,'/banner/'+ bannerimg as tabanner from Tbl_Banner order by priority asc");
            foreach (DataRow row in dt.Rows)
            {
                ListUser.Add(new DataClass.Banner.GetBanner(row["bannerIDP"].ToString(), row["tabanner"].ToString()));
            }
            return ListUser;

        }
        public List<DataClass.Banner.GetBanner> GetMobileBanner()
        {
            List<DataClass.Banner.GetBanner> ListUser = new List<DataClass.Banner.GetBanner>();
            DataTable dt = SqlHelper.GetDataUsingQuery("select priority,status,bannerIDP,'/banner/'+ bannerimg as tabanner from Tbl_MobileBanner order by priority asc");
            foreach (DataRow row in dt.Rows)
            {
                ListUser.Add(new DataClass.Banner.GetBanner(row["bannerIDP"].ToString(), row["tabanner"].ToString()));
            }
            return ListUser;

        }
    }
}