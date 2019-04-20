using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SOAP_LiveReporting;
using _SqlHelper;
namespace SOAP_LiveReporting.DataClass
{
    public class UserLogin : SqlHelper
    {
        MEMBERS.SqlReturnMessage OutMessage;
        MEMBERS.SQLReturnValue OutVal;

        public MEMBERS.SQLReturnValue CheckUserLogin(UserAuthntication Obj)
        {
            string[,] param = { { "UserName", Obj.UserName.ToString()}, 
                              { "Password", Obj.Password.ToString() }, 
                              { "UserType", Obj.UserType.ToString()}};
            return ExecuteProcWithMessageValue("CheckUserLogin", param, true); 
        }
    }
}