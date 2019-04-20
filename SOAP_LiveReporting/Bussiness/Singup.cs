using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;
namespace SOAP_LiveReporting.Bussiness
{
    public class Singup : SqlHelper
    {
        public static MEMBERS.SQLReturnValue Insert_Update_Client(DataClass.DataSingup obj)
        {
            bool IsActive = true;
            string[,] param = { {"ClientIDP",""},
                                {"FirstName",obj.FirstName.ToString()},
                                {"LastName",obj.LastName.ToString()},
                                {"EmailID",obj.EmailId.ToString()},
                                {"Address","NA"},
                                {"IMEINo",obj.IMEINo.ToString()},
                                {"MobileNo",obj.Mobile.ToString()},
                                {"StateIDF","0"},
                                {"CityIDF","0"},
                                {"IsActive",IsActive.ToString()},
                                {"UserName",obj.FirstName.ToString()},
                                {"Password",obj.Password.ToString()},
                                {"Dateofbirth",obj.Dateofbirth.ToString()},
                                {"Flag","ADD"},
                              };
            return ExecuteProcWithMessageValue("Insert_Update_Client", param, true);
        }
    }
}