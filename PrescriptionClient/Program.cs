using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrescriptionClient.PrescriptionServiceReference;

namespace PrescriptionClient
{
    class Program
    {
        static void Main(string[] args)
        {

            PrescriptionServiceReference.IWCFService ic = new PrescriptionServiceReference.WCFServiceClient();
            var test = ic.FilterByInterchangeID(1);
            
            

            
        }
    }
}
