using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using _SqlHelper;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetCategories
    {
        public List<DataClass.CategoriesData.GetCategoryList> GetCategoriesList()
        {
            List<DataClass.CategoriesData.GetCategoryList> ListUser = new List<DataClass.CategoriesData.GetCategoryList>();
            DataTable dt = SqlHelper.GetDataUsingQuery("select IncidentCategoryName,IncidentCategoryIDP from mIncidentCategory where IsActive='True'");
            foreach (DataRow row in dt.Rows)
            {
                ListUser.Add(new DataClass.CategoriesData.GetCategoryList(row["IncidentCategoryName"].ToString(), int.Parse(row["IncidentCategoryIDP"].ToString())));
            }
            return ListUser;

        }

    }
}