using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetSaveVideoComments : SqlHelper
    {
        public static MEMBERS.SQLReturnValue Insert_Update_Comments(DataClass.DataVideoComments obj)
        {
            string[,] param = { {"VideoIDF",obj.VideoIDF.ToString()},
                                {"UserIDF",obj.UserIDF.ToString()},
                                {"Msg",obj.Msg.ToString()}};
            return ExecuteProcWithMessageValue("Save_User_Comment", param, true);
        }
    }
}