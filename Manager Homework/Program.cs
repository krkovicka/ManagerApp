using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager_Homework
{
    class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, Manager> myManagers = new Dictionary<int, Manager>();

            bool displayMeny = true;
            while(displayMeny)
            {
                displayMeny = MainMenu();
            }

            bool MainMenu()
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("Choose option");
                Console.WriteLine("1) Create new Manager");
                Console.WriteLine("2) Chosee Manager");
                Console.WriteLine("3) Exit");

                string result = Console.ReadLine();

                if (result == "1")
                {
                    CreateManager();
                    return true;

                }
                else if (result == "2")
                {
                    ChoseManager();
                    return true;
                }
                else if (result == "3")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Choose a valid option");
                    return true;
                }
            }

            object CreateManager()
            {

                Console.Clear();
                Manager man = new Manager();
                List<SalesPerson> thisManagerList = new List<SalesPerson>();
                man.salesPerson = thisManagerList;

                Console.WriteLine("Create a new Manager");
                Console.Write("Insert Id: ");
                int id = Int32.Parse(Console.ReadLine());

                
                
                if (myManagers.ContainsKey(id))
                {
                    Console.WriteLine("That user Id is Taken");   
                    Console.ReadLine();
                    return CreateManager(); ;  
                }
                else
                {
                    man.Id = id;
                }
                
                Console.Write("Insert First Name: ");
                string name = Console.ReadLine();
                man.FirstName = name;

                Console.Write("Insert Last Name: ");
                string lastName = Console.ReadLine();
                man.LastName = lastName;

                Console.Write("Insert Department: ");
                string department = Console.ReadLine();
                man.Department = department;

                Console.Write("Select Gender (M or F): ");
                string gender = Console.ReadLine();
                man.Gender = gender;

                Console.Write("Insert Salary: ");
                int salary = Int32.Parse(Console.ReadLine());
                man.Salary = salary;

                Console.WriteLine("Succesfully Created! ");
                Console.WriteLine("Pres Enter to Continue ");

                Console.ReadLine();
                Console.Clear();

                myManagers.Add(man.Id, man);
                return myManagers;
            }

             void ChoseManager()
            {
                Console.Clear();
                     
                if (myManagers.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Empty managers list.First you need to create at least one manager");
                    Console.WriteLine("Select 0 to go back");
                   
                }
                else if (myManagers.Count > 0)
                {
                    Console.WriteLine("Please select Manager by chosing from the List");
                    foreach (KeyValuePair<int, Manager> kvp in myManagers)
                    {
                        Manager manager = kvp.Value;
                        Console.WriteLine("{0} ) {1} {2}", manager.Id, manager.FirstName, manager.LastName);
                    }

                    Console.WriteLine("Select 0 to go back");

                    int choseManager = Int32.Parse(Console.ReadLine());

                    foreach (KeyValuePair<int, Manager> kvp in myManagers)
                    {
                        Manager manager = kvp.Value;

                        if (choseManager == manager.Id)
                        {
                            Console.WriteLine("Manager's Menu - Selected Manager is" + (manager.FirstName + " " + manager.LastName));
                            Console.WriteLine("Chose Options:");
                            Console.WriteLine("1) Add  new sales Person");
                            Console.WriteLine("2) Print Manager's Details");
                            Console.WriteLine("3) Print Sales Person - ordered by First Name");
                            Console.WriteLine("4) Print Sales Person - only Female");
                            Console.WriteLine("0) Back");

                            int option = Int32.Parse(Console.ReadLine());

                            if (option == 1)
                            {
                                Console.WriteLine("======================================");
                                Console.WriteLine("Add new Sales Person");
                                Console.WriteLine("Create new Sales Person");
                                SalesPerson person = new SalesPerson();

                                Console.Write("Insert First Name: ");
                                string name = Console.ReadLine();
                                person.FirstName = name;

                                Console.Write("Insert Last Name: ");
                                string lastName = Console.ReadLine();
                                person.LastName = lastName;

                                Console.Write("Select Gender (M or F): ");
                                string gender = Console.ReadLine();
                                person.Gender = gender;

                                manager.salesPerson.Add(person);
                            }
                            else if (option == 2)
                            {
                                Console.WriteLine(" {0}  {1} ({2}) is a manager on {3} Department with Salary {4}",
                                    manager.FirstName, manager.LastName, manager.Gender, manager.Department, manager.Salary);
                            }
                            else if (option == 3)
                            {
                                Console.WriteLine(" Print Sales Person - ordered by First Name");
                                Console.WriteLine(" Sales Persons: ");

                                foreach (SalesPerson person in manager.salesPerson)
                                {
                                    manager.salesPerson.Sort((x, y) => string.Compare(x.FirstName, y.FirstName));
                                    Console.WriteLine("First Name = {0}; Last Name = {1}; Gender = {2}",
                                        person.FirstName, person.LastName, person.Gender);
                                }
                            }
                            else if (option == 4)
                            {
                                Console.WriteLine("Print Sales Person - only Female");
                                Console.WriteLine(" Sales Persons: ");

                                List<SalesPerson> female = manager.salesPerson.FindAll(pers => pers.Gender.StartsWith("F"));
                                
                                foreach (SalesPerson person in female)
                                {
                                    female.Sort((x, y) => string.Compare(x.FirstName, y.FirstName));
                                    Console.WriteLine("First Name = {0}; Last Name = {1}; Gender = {2}",
                                        person.FirstName, person.LastName, person.Gender);
                                }
                            }
                            else if (option == 0)
                            {
                                ChoseManager();
                            }
                            else
                            {
                                MainMenu();
                            }

                        }
                    }
                }

                
            }

        }      
        
        
    }
}
