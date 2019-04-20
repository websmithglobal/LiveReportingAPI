using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOAP_LiveReporting;
using _SqlHelper;
using System.Data;
namespace SOAP_LiveReporting.Bussiness
{
    public class GetCity
    {
        public List<DataClass.CityData.GetCityList> GetCityList(int StateIDF)
        {
            List<DataClass.CityData.GetCityList> ListUser = new List<DataClass.CityData.GetCityList>();
            DataTable dt = SqlHelper.GetDataUsingQuery("select CityName,CityIDP from mCity where StateIDF=" + StateIDF + " and IsActive='True'");
            foreach (DataRow row in dt.Rows)
            {
                ListUser.Add(new DataClass.CityData.GetCityList(row["CityName"].ToString(), int.Parse(row["CityIDP"].ToString())));
            }
            return ListUser;

        }
    }
}