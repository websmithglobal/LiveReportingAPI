using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class CategoriesData
    {
        public class GetCategoryList
        {
            public string IncidentCategoryName { get; set; }
            public int IncidentIDP { get; set; }

            public GetCategoryList(string _IncidentCategoryName, int _IncidentIDP)
            {
                this.IncidentCategoryName = _IncidentCategoryName; this.IncidentIDP = _IncidentIDP;
            }
        }
    }
}