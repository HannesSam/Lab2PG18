using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrescriptionClient
{
    /// <summary>
    /// The prescriptionmenu which the user will interact with from the Console.
    /// </summary>
    class PrescriptionMenu
    {
        /// <summary>
        /// The ServiceInteraction which will be used to interact with the service when user prompts a menuoption.
        /// </summary>
        readonly ServiceInteraction serviceInteraction;
        /// <summary>
        /// Bool which tells us whether the user wants to exit the program.
        /// </summary>
        bool runProgram;
        /// <summary>
        /// Constructor which creates the ServiceInteraction for this instance of the PrecsriptionMenu and sets the bool to true.
        /// </summary>
        public PrescriptionMenu()
        {
            serviceInteraction = new ServiceInteraction();
            runProgram = true;
        }

        /// <summary>
        /// Method which is used to start the UI for the menu. 
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
        /// A method which prints the menu with options and catches invalid user input. 
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
            Console.Clear();

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
            else
            {
                Console.WriteLine("\nPress enter to continue..");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// This method prints ut the menu.
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
        /// This method handles the menu input and the switch statment picks the choosen option and performs the action. 
        /// </summary>
        /// <returns>A bool that is true if the user should get the option to pretty print the XML</returns>
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
                    runProgram = false;
                    break;
            }
            return optionToPrintPrettyXML;
        }

        /// <summary>
        /// This method checks if the xml is null and if not prints it to the console.
        /// </summary>
        /// <param name="xml">XML for print</param>
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
        /// This method prints selected parts of the incoming xml to the console in a more structured way.
        /// </summary>
        /// <param name="xml">XML for pretty print</param>
        private void PrintPrettyXML(XElement xml)
        {
            foreach (XElement interchange in xml.Elements("Interchange"))
            {
                string patientName = interchange.Elements("NewPrescriptionMessage").Elements("SubjectOfCare").Elements("PatientMatchingInfo").Elements("PersonNameDetails").Elements("StructuredPersonName").Select(s => (string)s.Element("FirstGivenName") + " " + (string)s.Element("FamilyName")).FirstOrDefault();
                string physicianName = interchange.Elements("NewPrescriptionMessage").Elements("PrescriptionMessage").Elements("Prescriber").Elements("HealthcareAgent").Elements("HealthcareParty").Elements("HealthcarePerson").Select(s => (string)s.Element("Name")).FirstOrDefault();
                List<string> medicineIDs = interchange.Elements("NewPrescriptionMessage").Elements("PrescriptionSet").Elements("PrescriptionItemDetails").Elements("PrescribedMedicinalProduct").Elements("MedicinalProduct").Elements("ManufacturedProductId").Select(s => (string)s.Element("ProductId")).ToList();

                Console.WriteLine("Patient: " + patientName + "\n" + "Physician: " + physicianName);
                string medicineID = "";
                string dosage = "";
                foreach (var medicine in medicineIDs)
                {
                    List<string> dosages = new List<string>();
                    medicineID += "Medicine: " + medicine + "\n";
                    dosages.AddRange(interchange.Elements("NewPrescriptionMessage").Elements("PrescriptionSet").Elements("PrescriptionItemDetails").Elements("PrescribedMedicinalProduct").Where(s => (string)s.Element("MedicinalProduct").Element("ManufacturedProductId").Element("ProductId") == medicine).Elements("InstructionsForUse").Elements("UnstructuredInstructionsForUse").Select(s => (string)s.Element("UnstructuredDosageAdmin")));
                    dosage = "";
                    foreach (var dose in dosages)
                    {
                        dosage += "Dosage: " + dose + "\n";
                    }
                    Console.Write(medicineID + dosage);
                }
            }

            Console.WriteLine();
        }
    }
}
