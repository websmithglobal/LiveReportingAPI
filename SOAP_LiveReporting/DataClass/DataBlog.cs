using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class DataBlog
    {
        public class GetDataBlog
        {
            public string title { get; set; }
            public string tag { get; set; }
            public string desc { get; set; }
            public string url { get; set; }
            public string UserName { get; set; }
            public string Entrydate { get; set; }

            public GetDataBlog(string _title, string _tag, string _desc, string _url, string _UserName, string _Entrydate)
            {
                this.title = _title; this.tag = _tag;
                this.desc = _desc; this.UserName = _UserName;
                this.url = _url; this.Entrydate = _Entrydate;
            }
        }
    }
}