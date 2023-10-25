using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace BANKSOLID
{
    internal class Program
    {
       

      
        static void Main(string[] args)
        {
            try { 
             UserInterface ui = new UserInterface();
            Console.WriteLine("Welcome to the Bank Management System!");
            ui.EnviromentSetup();


                while (true)
                {
                    Console.WriteLine("1]> Admin Panel\n");
                    Console.WriteLine("2]> Customer Panel\n");
                    Console.WriteLine("3]> Register As a Customer!\n");
                    Console.WriteLine("4]> Exit\n");
                    Console.Write("Please select an option: ");

                    int option;
                    option = stringUtils.ConvertToInt(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("You are in the Admin Panel");
                            ui.AdminPanel();
                            // Implement Admin Panel UI
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("You are in the Customer Panel");
                            ui.CustomerPanel();
                            // Implement Customer Panel UI
                            break;
                        case 3:
                            Console.Clear();
                            ui.CreatingCustomer();
                            // Implement Create Customer UI
                            break;
                        case 4:
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid option. Please select a valid option.");
                            break;

                    }


                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}