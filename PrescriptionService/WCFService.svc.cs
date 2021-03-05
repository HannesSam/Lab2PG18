using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;

namespace PrescriptionService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WCFService : IWCFService
    {
        static XElement _testData;
        static XElement _interchanges;
        public XElement FilterByInterchangeID(int id)
        {
            return GetTestData().Descendants("Interchange").Where(i => (int)i.Element("MessageRoutingAddress").Element("InterchangeRef") == id).FirstOrDefault();
        }

        public XElement FilterByInterchangeNode(string node)
        {
            return new XElement("root", GetTestData().Descendants(node));
        }

        public XElement FilterByInterchangeIDAndNode(int id, string node)
        {
            return new XElement("root", GetTestData().Descendants("Interchange").Where(i => (int)i.Element("MessageRoutingAddress").Element("InterchangeRef") == id).FirstOrDefault().Descendants(node));
        }

        public XElement FilterByInterchangeNodeValue(string node, string value)
        {
            return new XElement("root", GetTestData().Descendants(node).Where(i => (string)i == value));
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

