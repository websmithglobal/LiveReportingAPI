using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;
namespace SOAP_LiveReporting.Bussiness
{
    public class UploadVideo_Insert : SqlHelper
    {
         MEMBERS.SqlReturnMessage OutMessage;
        MEMBERS.SQLReturnValue OutVal;

       public static MEMBERS.SQLReturnValue Add_Upload_Videos(DataClass.UploadVIdeo obj)
        {
            string[,] param = { {"UploadedVideoIDP",obj.UploadedVideoIDP.ToString()},
                                {"UploadTypeID",obj.UploadTypeID.ToString()},
                                {"UploadTitle",obj.UploadTitle.ToString()},
                                {"IncidentCategoryIDF",obj.IncidentCategoryIDF.ToString()},
                                {"IncidentCityName",obj.IncidentCityName.ToString()},
                                {"AreaOfCity",obj.AreaOfCity.ToString()},
                                {"IncidentDate",obj.IncidentDate.ToString()},
                                {"IncidentDescription",obj.IncidentDescription.ToString()},
                                {"KeyWordForSearch",obj.KeyWordForSearch.ToString()},
                                {"UserID",obj.UserID.ToString()},
                                {"UserType",obj.UserType.ToString()},
                                {"IncidentStateName",obj.IncidentStateName.ToString()},
                                {"Flag",obj.Flag.ToString()},
                                {"AreaID",obj.AreaID.ToString()},
                                {"IncidentSubCategoryIDF",obj.IncidentSubCategoryIDF.ToString()},
                              };
            return ExecuteProcWithMessageValue("Insert_Update_UploadVideo", param, true);
        }

    }
}