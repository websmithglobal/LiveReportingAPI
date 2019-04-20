using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class StateData
    {
        public class GetStateList
        {
            public string StateName { get; set; }
            public int StateIDP { get; set; }

            public GetStateList(string _StateName, int _StateIDP)
            {
                this.StateName = _StateName; this.StateIDP = _StateIDP;
            }
        }
    }
}