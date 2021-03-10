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
        static void Main(string[] args)
        {
            ServiceInteraction serviceInteraction = new ServiceInteraction();

            Console.WriteLine("Welcome! Please choose an option to fetch information about e-prescriptions.");

            do
            {
                Console.WriteLine("Menu: \n" +
                    "1: Get all interchanges \n" +
                    "2: Get all test interchanges \n" +
                    "3: Filter interchanges by ID \n" +
                    "4: Filter interchanges by node \n" +
                    "5: Filter interchanges by node and ID \n" +
                    "6: Filter interchanges by node value");

                int input = Int32.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        serviceInteraction.GetAll();
                        break;
                    case 2:
                        serviceInteraction.GetTestData();
                        break;
                    case 3:
                        Console.WriteLine("Please give us an ID");
                        int inputID = Int32.Parse(Console.ReadLine());
                        serviceInteraction.GetFilteredByID(inputID);
                        break;
                    case 4:
                        Console.WriteLine("Please give us a node name");
                        string inputNodeName = Console.ReadLine();
                        serviceInteraction.GetFilteredByNode(inputNodeName);
                        break;
                    case 5:
                        Console.WriteLine("Please give us an ID");
                        inputID = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("Please give us a node name");
                        inputNodeName = Console.ReadLine();
                        serviceInteraction.GetFilteredByIDAndNode(inputID, inputNodeName);
                        break;
                    case 6:
                        Console.WriteLine("Please give us a node name");
                        inputNodeName = Console.ReadLine();

                        Console.WriteLine("Please give us a node value");
                        string inputNodeValue = Console.ReadLine();
                        serviceInteraction.GetFilteredByNodeValue(inputNodeName, inputNodeValue);
                        break;
                    default:
                        break;
                }

                Console.Clear();
                PrintXML(serviceInteraction.Result);
                Console.ReadLine();


            } while (true);




        }

        private static void PrintXML(XElement result)
        {
            foreach (XElement interchange in result.Elements("Interchange"))
            {
                var test = interchange.Elements("NewPrescriptionMessage").Elements("SubjectOfCare");
                string patients = interchange.Elements("NewPrescriptionMessage").Elements("SubjectOfCare").Elements("PatientMatchingInfo").Elements("PersonNameDetails").Elements("StructuredPersonName").Select(s => (string)s.Element("FirstGivenName") + " " + (string)s.Element("FamilyName")).FirstOrDefault();
                Console.WriteLine("Patient: " + patients);
            }
        }
    }
}
