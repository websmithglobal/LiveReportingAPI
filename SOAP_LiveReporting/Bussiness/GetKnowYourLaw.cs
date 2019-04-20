using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;
using System.Data;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetKnowYourLaw
    {
        public List<DataClass.KnowYourLawData.GetKnowYourLaw> GetKnowYourLawList()
        {
            List<DataClass.KnowYourLawData.GetKnowYourLaw> ListUser = new List<DataClass.KnowYourLawData.GetKnowYourLaw>();
            DataTable dt = SqlHelper.GetDataUsingQuery("select Rules,sourceName,RuleIDP from mKnowYourRule where IsActive='True'");
            foreach (DataRow row in dt.Rows)
            {
                ListUser.Add(new DataClass.KnowYourLawData.GetKnowYourLaw(row["Rules"].ToString(), int.Parse(row["RuleIDP"].ToString()), row["sourceName"].ToString()));
            }
            return ListUser;

        }

    }
}