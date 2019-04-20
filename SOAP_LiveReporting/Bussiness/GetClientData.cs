using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;
using System.Data;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetClientData
    {

        public List<DataClass.ClientInfo.GetClinetInfomation> GetUserInformation(int UserID)
        {
            List<DataClass.ClientInfo.GetClinetInfomation> ListUser = new List<DataClass.ClientInfo.GetClinetInfomation>();
            DataTable dt = SqlHelper.GetDataUsingQuery("select top 1 ClientIDP,FirstName,LastName,EmailID,MobileNo,Password,EntryDate,dateofbirth from tblClient where  ClientIDP=" + UserID + "");
            foreach (DataRow row in dt.Rows)
            {
                ListUser.Add(new DataClass.ClientInfo.GetClinetInfomation(row["FirstName"].ToString(), row["LastName"].ToString(), row["EmailID"].ToString(), row["MobileNo"].ToString(), row["EntryDate"].ToString(), int.Parse(row["ClientIDP"].ToString()), row["Password"].ToString(), DateTime.Parse(row["dateofbirth"].ToString()).ToString("dd-MM-yyyy")));

            }
            return ListUser;

        }
    }
}