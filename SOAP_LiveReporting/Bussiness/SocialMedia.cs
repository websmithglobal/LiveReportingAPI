using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAP_LiveReporting.Bussiness
{
    public class SocialMedia : _SqlHelper.SqlHelper
    {
        public static MEMBERS.SQLReturnValue AUTHFacebookLogin(DataClass.DataSocialMedia ObjFB)
        {
            string[,] param = { { "FBNAME", ObjFB.FirstName.ToString()}, 
                          { "FIRSTNAME", ObjFB.FirstName.ToString()},
                          { "LASTNAME", ObjFB.LastName.ToString() }, 
                          { "GENDER", ObjFB.Gender.ToString() },
                          { "LINK", ObjFB.ProfileLink.ToString() },
                          { "PICTURE", ObjFB.PictureLink.ToString()},
                          { "EMAIL", ObjFB.EmailId.ToString() },
                          { "ST", ObjFB.Type.ToString() },
                          { "Dateofbirth", ObjFB.Dateofbirth.ToString() },
                          { "FBID", ObjFB.SocialID.ToString()}};
            return ExecuteProcWithMessageValue("AUTH_FACEBOOKGOOGLE", param, true);
        }
    }
}