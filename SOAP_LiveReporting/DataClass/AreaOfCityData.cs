using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class AreaOfCityData
    {
        public class GetAreaList
        {
            public string AreaOfCity { get; set; }
            public int AreaIDP { get; set; }

            public GetAreaList(string _AreaOfCity, int _AreaIDP)
            {
                this.AreaOfCity = _AreaOfCity; this.AreaIDP = _AreaIDP;
            }
        }
    }
}