using System;

namespace RateMyProfessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram  = new Program();
            var name = myProgram.RecieveProfName();
            // handle if input is null, not alphabetic

            // check if Professor exists
            // if so, do not make a new ID

            

            // handle if input is null, not a number, a number > 10 or < 0

            // You can call other methods or perform additional actions here as needed
        }

        public string RecieveProfName()
        {
            Console.WriteLine("Please enter the Professor's name: ");
            string p_input = Console.ReadLine();
            return p_input;
        }

        public string RecieveProfRating()
        {
            Console.WriteLine("Please enter your rating of the Professor: ");
            string r_input = Console.ReadLine();
            return r_input;
        }
    }
}
