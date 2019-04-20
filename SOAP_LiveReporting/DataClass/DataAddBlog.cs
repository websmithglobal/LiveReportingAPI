using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.DataClass
{
    public class DataAddBlog
    {
        public string title { get; set; }
        public string tag { get; set; }
        public string desc { get; set; }
        public string url { get; set; }
        public int mainid { get; set; }

    }
    
}