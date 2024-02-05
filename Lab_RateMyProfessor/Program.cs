using Lab_RateMyProfessor;
using System;
using System.ComponentModel.Design;
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
            string prof_name = "";

            string cat_desc = "";
            Category _cat = new Category();
            Professor _prof = new Professor();

            

            while (run)
            {
                Console.WriteLine("M: M for menu to see options, E: Exit, " +
                            "\n-add: start adding a professor to be rated within a category, -addProf: add professor only, -addCateg: add category only, -addRating: add Rating to a professor" +
                            "\n-editProf: edit name, -editCateg: edit the category name and description, -editRateing: edit the rating of a professor" +
                            "\n");
                response = Console.ReadLine();

                switch (response)
                {
                    case "M":
                        Console.WriteLine("M: M for menu to see options, E: Exit, C: Continue, " +
                            "\n-add: start adding a professor to be rated within a category, -addProf: add professor only, -addCateg: add category only, -addRating: add Rating to a professor" +
                            "\n-editProf: edit name, -editCateg: edit the category name and description, -editRateing: edit the rating of a professor" +
                            "\n");
                        break;
                    case "-add":
                        Console.WriteLine("Please enter a professor's name.");
                        prof_name = Console.ReadLine();
                        _prof = new Professor(prof_name);

                        Console.WriteLine("Please enter a category.");
                        string cat_name = Console.ReadLine();

                        Console.WriteLine("Please enter the category's description.");
                        prof_name = Console.ReadLine();
                        Category _category = new Category(cat_name, cat_desc);

                        Console.WriteLine("Please enter a rating for the professor.");
                        string prof_rating = Console.ReadLine();
                        Ratings _rating = new Ratings(_prof.getId(), _category.getCategoryId(), Int32.Parse(prof_rating));
                        break;
                    case "-addProf":
                        Console.WriteLine("Please enter a professor's name.");
                        prof_name = Console.ReadLine();
                        _prof = new Professor(prof_name);
                        break;
                    case "-addCateg":
                        Console.WriteLine("Please enter a category.");
                        cat_name = Console.ReadLine();

                        Console.WriteLine("Please enter the category's description.");
                        prof_name = Console.ReadLine();
                        _category = new Category(cat_name, cat_desc);
                        break;
                    case "E":
                        Console.WriteLine("Exiting Program...");
                        run = false;
                        break;
                }    
            }
        }
    }
}
