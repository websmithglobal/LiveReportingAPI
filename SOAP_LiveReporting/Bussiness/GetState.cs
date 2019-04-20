using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOAP_LiveReporting;
using _SqlHelper;
using System.Data;
namespace SOAP_LiveReporting.Bussiness
{
    public class GetState
    {
        public List<DataClass.StateData.GetStateList> GetSTateList()
        {
            List<DataClass.StateData.GetStateList> ListUser = new List<DataClass.StateData.GetStateList>();
            DataTable dt = SqlHelper.GetDataUsingQuery("select StateName,StateIDP from mstate where IsActive='True'");
            foreach (DataRow row in dt.Rows)
            {
                ListUser.Add(new DataClass.StateData.GetStateList(row["StateName"].ToString(),int.Parse(row["StateIDP"].ToString())));
            }
            return ListUser;

        }

    }
}