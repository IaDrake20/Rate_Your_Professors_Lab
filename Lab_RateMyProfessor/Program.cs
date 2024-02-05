using Lab_RateMyProfessor;
using System;
using System.Reflection.Metadata.Ecma335;
using Xunit;

namespace RateMyProfessor
{
    class Program
    {

        static void Main(string[] args)
        {
            bool run = true;
            string response = "";
            while (run)
            {
                Console.WriteLine("Please enter a professor's name.");
                string prof_name = Console.ReadLine();

                Console.WriteLine("Please enter a category.");
                string cat_name = Console.ReadLine();

                Console.WriteLine("Continue(c) with program or exit(e)?");
                response = Console.ReadLine();
                switch (response)
                {
                    case "e":
                        Console.WriteLine("Exiting Program...");
                        run = false;
                        break;
                    case "c":
                        Console.WriteLine("Continuing...");
                        run = true;
                        break;
                }
                
            }
                    
        }
    }
}
