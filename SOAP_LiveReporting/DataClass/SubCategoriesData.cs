using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class SubCategoriesData
    {
        public class GetSubcategoryList
        {
            public string IncidentSubCategoryName { get; set; }
            public int IncidentSubCategoryIDP { get; set; }

            public GetSubcategoryList(string _IncidentSubCategoryName, int _IncidentSubCategoryIDP)
            {
                this.IncidentSubCategoryName = _IncidentSubCategoryName; this.IncidentSubCategoryIDP = _IncidentSubCategoryIDP;
            }
        }
    }
}