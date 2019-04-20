using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;


/// <summary>
/// FCMNotification : this class is used for send custome fcm notification.
/// </summary>
public class FCMNotification
{
    public string ServerKey = "AAAAn-N6-ag:APA91bFYw_zJS01AA-l3dIKi0tP8FhTyQuCaicwSzfooTNoctDXQ58axFNFJkI-7aqCIghcbsEzfpyVivkESyVq0CLPFn7tUSv8nMHYaz_akvmGZPKP1uLaVvCY37Y_NVfCiSDpAwCme";
    public string SenderID = "686716287400";

    public string PushNotifyAsync(string to, string title, string message)
    {
        string response = string.Empty;
        try
        {
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "POST";
            tRequest.ContentType = "application/json";

            // create data object
            FCMRootObject dataObject = new FCMRootObject();
            dataObject.priority = "high";
            dataObject.content_available = true;
            dataObject.to = to;

            Notification NotificationBody = new Notification
            {
                body = message,
                title = title,
                sound = "default"
            };

            // if devicetype = 0 then IOS and 1 for android
            // so we are not passing NotificationBody to android


            Data data = new Data
            {
                NotificationTitle = title,
                Description = message
            };
            dataObject.data = data;

            // create data object end

            string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(dataObject);

            Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);

            tRequest.Headers.Add(string.Format("Authorization: key={0}", ServerKey));
            tRequest.Headers.Add(string.Format("Sender: id={0}", SenderID));

            tRequest.ContentLength = byteArray.Length;
            tRequest.ContentType = "application/json";
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);

                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            response = tReader.ReadToEnd();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            response = ex.Message;
        }
        return response;
    }

    internal class FCMRootObject
    {
        public string to { get; set; }
        public Notification notification { get; set; }
        public Data data { get; set; }
        public string priority { get; set; }
        public bool content_available { get; set; }
    }
    public class FCMResult
    {
        public string message_id { get; set; }
        public string error { get; set; }
    }
    internal class Data
    {
        public string Description { get; set; }
        public string NotificationImage { get; set; }
        public string NotificationID { get; set; }
        public string NotificationTitle { get; set; }
    }

    public class FCMResponseObject
    {
        public long multicast_id { get; set; }
        public int success { get; set; }
        public int failure { get; set; }
        public int canonical_ids { get; set; }
        public List<FCMResult> results { get; set; }
    }
    internal class Notification
    {
        public Notification()
        {
            this.title = "LiveReporting";
            this.body = "LiveReporting Notification";
            this.sound = "default";
        }

        public string title { get; set; }
        public string body { get; set; }
        public string sound { get; set; }
    }
}