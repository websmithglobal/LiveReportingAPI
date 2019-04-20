using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class Banner
    {
        public class GetBanner
        {
            public string BannerIDP { get; set; }
            public string BannerIMG { get; set; }


            public GetBanner(string _BannerIDP, string _BannerIMG)
            {
                this.BannerIDP = _BannerIDP; this.BannerIMG = _BannerIMG; 
            }
        }
    }
}