using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOAP_LiveReporting;
using _SqlHelper;
namespace SOAP_LiveReporting.Bussiness
{
    public class UserContact : SqlHelper
    {
        MEMBERS.SqlReturnMessage OutMessage;
        MEMBERS.SQLReturnValue OutVal;


        public static MEMBERS.SQLReturnValue Add_ConatctUS(DataClass.AddcontactUsLR obj)
        {
            string[,] param = { {"Fullname",obj.UserName.ToString()},
                                {"Subject",obj.Subject.ToString()},
                                {"EmailID",obj.EmailID.ToString()},
                                {"Message",obj.Message.ToString()}};
            return ExecuteProcWithMessageValue("Insert_ConatcUs", param, true);
        }

    }
}