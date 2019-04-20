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
                                //below four fields are added by KG
                                {"CityName",obj.CityName.ToString()},
                                {"AreaOfCity",obj.AreaOfCity.ToString()},
                                {"StateName",obj.StateName.ToString()},
                                {"Gender",obj.Gender.ToString()},
                                {"Flag","ADD"},
                              };
            return ExecuteProcWithMessageValue("Insert_Update_Client", param, true);
        }

        /// <summary>
        /// this function added by KG for update user profile from mobile app
        /// date: 20-apr-2019 12:00 PM
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static MEMBERS.SQLReturnValue Update_ClientProfileFromApp(DataClass.DataUpdateProfile obj)
        {
            string[,] param = { {"ClientIDP",obj.ClientIDP.ToString()},
                                {"FirstName",obj.FirstName.ToString()},
                                {"LastName",obj.LastName.ToString()},
                                {"EmailID",obj.EmailId.ToString()},
                                {"MobileNo",obj.Mobile.ToString()},
                                {"Dateofbirth",obj.Dateofbirth.ToString()},
                                {"CityName",obj.CityName.ToString()},
                                {"AreaOfCity",obj.AreaOfCity.ToString()},
                                {"StateName",obj.StateName.ToString()},
                                {"Gender",obj.Gender.ToString()},
                                {"Flag","UPDATE"},
                              };
            return ExecuteProcWithMessageValue("Update_Client_Profile", param, true);
        }
    }
}