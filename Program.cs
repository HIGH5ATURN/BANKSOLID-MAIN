namespace BANKSOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            void AdminOrCustomerPrint()
            {
                Console.WriteLine("-----Welcome to BANKSOLID-----");
                Console.WriteLine("If you are Admin type 1.");
                Console.WriteLine("If you are a Customer type 2.");

            }

           

            while(true)
            {
                AdminOrCustomerPrint();
                char chr = Console.ReadLine()[0];

                if(chr=='1')
                {

                }
                else if(chr=='2')
                {
                    Console.WriteLine("Please Give Your Credentials!");
                    Console.Write("USERNAME : ");
                    string username = Console.ReadLine();
                    Console.Write("PASSWORD : ");
                    string password = Console.ReadLine();

                    //if password valid enter in the below loop
                    while(true)
                    {
                        Console.WriteLine("write 0 to go back to previous page!");

                        chr = Console.ReadLine()[0];

                        
                        if (chr=='0')
                        {
                            break;
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Not a valid input!");
                }
            }
            //while(true)
            //{
            //    Console.Clear();
            //    Console.WriteLine("WELCOME TO BANK-SOLID!");
            //    Console.WriteLine("If you are ADMIN type 1.");
            //    Console.WriteLine("If you are a Customer type 2");

            //    char chr = Console.ReadLine()[0];

            //    if(chr=='1')
            //    {

            //    }
            //    else if(chr==2)
            //    {
            //        Console.WriteLine("Please give your UserName and Password to Log in!");

            //        string username = Console.ReadLine();
            //        string password = Console.ReadLine();

            //    }
            //}
        }
    }
}