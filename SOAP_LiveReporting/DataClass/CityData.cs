using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class CityData
    {
        public class GetCityList
        {
            public string CityName { get; set; }
            public int CityIDP { get; set; }
            
            public GetCityList(string _CityName, int _CityIDP)
            {
                this.CityName = _CityName; this.CityIDP = _CityIDP;
            }
        }
    }
}