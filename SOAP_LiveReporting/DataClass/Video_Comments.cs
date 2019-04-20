using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class Video_Comments
    {
        public class GetVideo_Comments
        {
            public string CreateDate { get; set; }
            public string Msg { get; set; }
            public string UserName { get; set; }

            public GetVideo_Comments(string _CreateDate, string _Msg, string _UserName)
            {
                this.CreateDate = _CreateDate; this.Msg = _Msg; this.UserName = _UserName;
            }
        }
    }
}