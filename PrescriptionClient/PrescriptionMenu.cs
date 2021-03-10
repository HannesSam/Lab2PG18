using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrescriptionClient
{
    /// <summary>
    /// 
    /// </summary>
    class PrescriptionMenu
    {
        readonly ServiceInteraction serviceInteraction;
        bool runProgram;

        public PrescriptionMenu()
        {
            serviceInteraction = new ServiceInteraction();
            runProgram = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartUI()
        {

            Console.WriteLine("Welcome!");
            do
            {
                RunMenu();

            } while (runProgram);

        }

        /// <summary>
        /// 
        /// </summary>
        private void RunMenu()
        {
            PrintMenu();
            bool printPrettyXML = false;
            try
            {
                printPrettyXML = HandleMenuInput();
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input! Press enter to get back to the menu...");
                Console.ReadLine();
            }

            PrintXML(serviceInteraction.Result);
            if (printPrettyXML)
            {
                Console.WriteLine("Would you like to print the most important information in a more accessible way? y/n");
                if (Console.ReadLine() == "y")
                {
                    Console.Clear();
                    PrintPrettyXML(serviceInteraction.Result);

                    Console.WriteLine("\nPress enter to continue..");
                    Console.ReadLine();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Please choose an option to fetch information about e-prescriptions.");
            Console.WriteLine("Menu: \n" +
                "1: Get all interchanges \n" +
                "2: Get all test interchanges \n" +
                "3: Filter interchanges by ID \n" +
                "4: Filter interchanges by node \n" +
                "5: Filter interchanges by node and ID \n" +
                "6: Filter interchanges by node value \n" +
                "7: Show the latest result \n" +
                "8: Exit program"
                );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool HandleMenuInput()
        {
            int input = Int32.Parse(Console.ReadLine());
            bool optionToPrintPrettyXML = false;

            switch (input)
            {
                case 1:
                    serviceInteraction.GetAll();
                    optionToPrintPrettyXML = true;
                    break;
                case 2:
                    serviceInteraction.GetTestData();
                    optionToPrintPrettyXML = true;
                    break;
                case 3:
                    Console.WriteLine("Please give us an ID");
                    int inputID = Int32.Parse(Console.ReadLine());
                    serviceInteraction.GetFilteredByID(inputID);
                    optionToPrintPrettyXML = true;
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
                    optionToPrintPrettyXML = true;
                    break;
                case 7:
                    optionToPrintPrettyXML = true;
                    break;
                case 8:
                    runProgram = false;
                    break;
                default:
                    break;
            }
            return optionToPrintPrettyXML;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        private void PrintXML(XElement xml)
        {
            if (xml != null)
            {
                Console.WriteLine(xml);
            }
            else
            {
                Console.WriteLine("Could not find any elements matching that query. \nPress enter to go back to the menu...");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xml"></param>
        private void PrintPrettyXML(XElement xml)
        {
            foreach (XElement interchange in xml.Elements("Interchange"))
            {
                string patientName = interchange.Elements("NewPrescriptionMessage").Elements("SubjectOfCare").Elements("PatientMatchingInfo").Elements("PersonNameDetails").Elements("StructuredPersonName").Select(s => (string)s.Element("FirstGivenName") + " " + (string)s.Element("FamilyName")).FirstOrDefault();
                string physicianName = interchange.Elements("NewPrescriptionMessage").Elements("PrescriptionMessage").Elements("Prescriber").Elements("HealthcareAgent").Elements("HealthcareParty").Elements("HealthcarePerson").Select(s => (string)s.Element("Name")).FirstOrDefault();
                List<string> medicineIDs = interchange.Elements("NewPrescriptionMessage").Elements("PrescriptionSet").Elements("PrescriptionItemDetails").Elements("PrescribedMedicinalProduct").Elements("MedicinalProduct").Select(s => (string)s.Element("ProductType")).ToList();
                List<string> dosages = interchange.Elements("NewPrescriptionMessage").Elements("PrescriptionSet").Elements("PrescriptionItemDetails").Elements("PrescribedMedicinalProduct").Elements("InstructionsForUse").Elements("UnstructuredInstructionsForUse").Select(s => (string)s.Element("UnstructuredDosageAdmin")).ToList();

                string medicineID = "";
                foreach (var medicine in medicineIDs)
                {
                    medicineID += "Medicine: " + medicine + "\n";
                }
                string dosage = "";
                foreach (var dose in dosages)
                {
                    dosage += "Dosage: " + dose + "\n";
                }

                Console.WriteLine("Patient: " + patientName + "\n" + "Physician: " + physicianName + "\n" + medicineID + dosage);

            }
        }
    }
}
