using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace PrescriptionService
{
    public class WCFService : IWCFService
    {
        public static XElement _testData;
        public static XElement _interchanges;

        public WCFService()
        {
           GetTestData();
           GetAllInterchanges();
        }

        public XElement FilterByInterchangeID(int id)
        {
            return new XElement("root", _interchanges.Descendants("Interchange").Where(i => (int)i.Element("MessageRoutingAddress").Element("InterchangeRef") == id).FirstOrDefault());
        }

        public XElement FilterByInterchangeNode(string node)
        {
            return new XElement("root", _interchanges.Descendants(node));
        }

        public XElement FilterByInterchangeIDAndNode(int id, string node)
        {
            return new XElement("root", _interchanges.Descendants("Interchange").Where(i => (int)i.Element("MessageRoutingAddress").Element("InterchangeRef") == id).FirstOrDefault().Descendants(node));
        }

        public XElement FilterByInterchangeNodeValue(string node, string value)
        {
            return new XElement("root", _interchanges.Descendants("Interchange").Where(n => (string)n.Descendants(node).FirstOrDefault() == value));
        }

        public XElement GetAllInterchanges()
        {
            using (WebClient webClient = new WebClient())
            {
                string jsonString = webClient.DownloadString(Encoding.UTF8.GetString(
                Convert.FromBase64String("aHR0cDovL3ByaXZhdC5iYWhuaG9mLnNlL3diNzE0ODI5L2pzb24vaWNzLmpzb24=")));
                _interchanges = JsonConvert.DeserializeObject<XElement>(jsonString);
            }
            return _interchanges;
        }

        public XElement GetTestData()
        {
            using (WebClient webClient = new WebClient())
            {
                string jsonString = webClient.DownloadString(Encoding.UTF8.GetString(
                Convert.FromBase64String("aHR0cDovL3ByaXZhdC5iYWhuaG9mLnNlL3diNzE0ODI5L2pzb24vdGVzdERhdGEuanNvbg==")));
                _testData = JsonConvert.DeserializeObject<XElement>(jsonString);
            }
            return _testData;
        }
    }
}

