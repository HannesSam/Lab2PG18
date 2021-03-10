using PrescriptionClient.PrescriptionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrescriptionClient
{
    class ServiceInteraction
    {
        IWCFService ic;
        private XElement _result;
        public ServiceInteraction()
        {
           ic = new WCFServiceClient();
        }

        public XElement Result
        {
            get { return _result; }
            set
            {
                XAttribute timeFetch = new XAttribute("TimeFetched", DateTime.Now);
                value.Add(timeFetch);
                _result = value;
            }
        }

        public void GetAll()
        {
            Result = ic.GetAllInterchanges();
        }

        public void GetTestData()
        {
            Result = ic.GetTestData();
        }

        public void GetFilteredByID(int id)
        {
            ic.FilterByInterchangeID(id);
        }

        public void GetFilteredByNode(string node)
        {
            ic.FilterByInterchangeNode(node);
        }
        public void GetFilteredByIDAndNode(int id, string node)
        {
            ic.FilterByInterchangeIDAndNode(id, node);
        }
        public void GetFilteredByNodeValue(string node, string nodeValue)
        {
            ic.FilterByInterchangeNodeValue(node, nodeValue);
        }

    }
}
