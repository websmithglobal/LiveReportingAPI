using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;
using System.Data;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetAddBlog : SqlHelper
    {
        public static MEMBERS.SQLReturnValue Insert_Update_Blog(DataClass.DataAddBlog obj)
        {
            string[,] param = { {"title_name",obj.title.ToString()},
                                {"tag_name",obj.tag.ToString()},
                                {"description",obj.desc.ToString()},
                                {"url",obj.url.ToString()},
                                {"mainid",obj.mainid.ToString()}};
            return ExecuteProcWithMessageValue("Insert_Update_Blog", param, true);
        }
        
    }
   
}