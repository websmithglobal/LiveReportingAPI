using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetUploadVideoPath : SqlHelper
    {
        public static MEMBERS.SQLReturnValue Save_Video_Path(DataClass.UploadVIdeo obj)
        {
            string[,] param = { {"UploadedVideoIDP",obj.UploadedVideoIDP.ToString()},
                                {"video_path",obj.video_path.ToString()},
                                {"IncidentCategoryIDF",obj.IncidentCategoryIDF.ToString()},
                                {"IncidentSubCategoryIDF",obj.IncidentSubCategoryIDF.ToString()},
                                {"ThumbPath",obj.thumbpath.ToString()}};
            return ExecuteProcWithMessageValue("Save_Path", param, true);
        }
    }
}