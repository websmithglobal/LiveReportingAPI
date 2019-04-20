using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace SOAP_LiveReporting.Bussiness
{
    public class SendFCM
    {
        public bool sendFCMNotification(string token, string title, string message)
        {
            bool IsSendToFcm = false;
            try
            {
                #region Send Spectro Data To FCM

                FCMNotification.FCMResponseObject FCM_Response = new FCMNotification.FCMResponseObject();
                FCMNotification notification = new FCMNotification();

                if (!String.IsNullOrEmpty(token))
                {
                    string response = notification.PushNotifyAsync(token, title, message);
                    FCM_Response = Newtonsoft.Json.JsonConvert.DeserializeObject<FCMNotification.FCMResponseObject>(response);
                    if (FCM_Response.success > 0 && FCM_Response.failure == 0)
                    {
                        IsSendToFcm = true;
                    }
                    else
                    {
                        IsSendToFcm = false;
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
               
            }
            return IsSendToFcm;
        }
    }
}