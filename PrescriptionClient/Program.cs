using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PrescriptionClient.PrescriptionServiceReference;

namespace PrescriptionClient
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            PrescriptionMenu menu = new PrescriptionMenu();
            menu.StartUI();
        }
    }
}
