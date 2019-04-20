using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class KnowYourLawData
    {
        public class GetKnowYourLaw
        {
            public string Rules { get; set; }
            public int RulesIDP { get; set; }
            public string sourceName { get; set; }

            public GetKnowYourLaw(string _Rules, int _RulesIDP, string _sourceName)
            {
                this.Rules = _Rules; this.RulesIDP = _RulesIDP; this.sourceName = _sourceName;
            }
        }
    }
}