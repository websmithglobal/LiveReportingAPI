using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;
using System.Data;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetSubCategories
    {
        public List<DataClass.SubCategoriesData.GetSubcategoryList> GetSubCategoriesList(int IncidentCategoryIDF)
        {
            List<DataClass.SubCategoriesData.GetSubcategoryList> ListUser = new List<DataClass.SubCategoriesData.GetSubcategoryList>();
            DataTable dt = SqlHelper.GetDataUsingQuery("select IncidentSubCategoryName,IncidentSubCategoryIDP from mIncidentSubCategory where IncidentCategoryIDF=" + IncidentCategoryIDF + " and IsActive='True'");
            foreach (DataRow row in dt.Rows)
            {
                ListUser.Add(new DataClass.SubCategoriesData.GetSubcategoryList(row["IncidentSubCategoryName"].ToString(), int.Parse(row["IncidentSubCategoryIDP"].ToString())));
            }
            return ListUser;

        }
    }
}