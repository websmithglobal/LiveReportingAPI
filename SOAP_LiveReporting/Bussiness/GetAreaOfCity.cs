using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;
using System.Data;
using SOAP_LiveReporting;
namespace SOAP_LiveReporting.Bussiness
{
    public class GetAreaOfCity
    {
        public List<DataClass.AreaOfCityData.GetAreaList> GetAreaList(int CityIDF)
        {
            List<DataClass.AreaOfCityData.GetAreaList> ListUser = new List<DataClass.AreaOfCityData.GetAreaList>();
            DataTable dt = SqlHelper.GetDataUsingQuery("select AreaOfCity,Pincodeid from mPincode where CityIDF=" + CityIDF + " status=1");
            foreach (DataRow row in dt.Rows)
            {
                ListUser.Add(new DataClass.AreaOfCityData.GetAreaList(row["AreaOfCity"].ToString(), int.Parse(row["Pincodeid"].ToString())));
            }
            return ListUser;

        }
    }
}