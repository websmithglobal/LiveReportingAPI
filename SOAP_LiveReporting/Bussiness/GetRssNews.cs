using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _SqlHelper;
using System.Xml;
using System.Net;
using System.Data;
using System.Xml.Linq;
using System.Text;

namespace SOAP_LiveReporting.Bussiness
{
    public class GetRssNews
    {
        public string GetRSS()
        {
            XmlDocument newsUrl = new XmlDocument();
            newsUrl.Load("http://aninews.in/rssfeed/10-general-news.html");
            XDocument doc = XDocument.Parse(newsUrl.InnerXml);
            var docs = doc.Root.Element("channel").ToString();
            newsUrl.LoadXml(docs);
            XmlNodeList idNodes = newsUrl.SelectNodes("channel/item");
            StringBuilder sb = new StringBuilder();
            int count = 0;
            count = idNodes.Count;
            foreach (XmlNode node in idNodes)
            {

            }
            return "1";
        }
    }
}