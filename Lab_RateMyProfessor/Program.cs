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

            Guid _guid = Guid.NewGuid();

            string cat_desc = "";
            Category _category = new Category();
            Professor _prof = new Professor();

            

            while (run)
            {
                Console.WriteLine("M: M for menu to see options, E: Exit, " +
                            "\n-add: start adding a professor to be rated within a category, -addProf: add professor only, -addCateg: add category only, -addRating: add Rating to a professor" +
                            "\n-editProf: edit name, -editCateg: edit the category name and description, -editRating: edit the rating of a professor" +
                            "\n-rmProf: remove a professor, -rmCateg: remove a category, -rmRating: remove a rating from a professor");
                response = Console.ReadLine();

                switch (response)
                {
                    case "M":
                        Console.WriteLine("M: M for menu to see options, E: Exit, C: Continue, " +
                            "\n-add: start adding a professor to be rated within a category, -addProf: add professor only, -addCateg: add category only, -addRating: add Rating to a professor" +
                            "\n-editProf: edit name, -editCateg: edit the category name and description, -editRating: edit the rating of a professor" +
                            "\n-rmProf: remove a professor, -rmCateg: remove a category, -rmRating: remove a rating from a professor");
                        break;
                    case "-add":
                        Console.WriteLine("Please enter a professor's name.");
                        prof_name = Console.ReadLine();
                        _prof = new Professor(prof_name);

                        Console.WriteLine("Please enter a category.");
                        string cat_name = Console.ReadLine();

                        Console.WriteLine("Please enter the category's description.");
                        cat_desc = Console.ReadLine();
                        _category = new Category(cat_name, cat_desc);

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
                        response = Console.ReadLine();
                        _category = new Category(cat_name, cat_desc);
                        break;
                    case "-addRating":
                        Console.WriteLine("Please enter the GUID of the professor to add your rating to.");
                        string prof_guid = Console.ReadLine();
                        //TODO: does nothing atm

                        Console.WriteLine("Please enter a rating for the professor.");
                        prof_rating = Console.ReadLine();
                        _rating = new Ratings(_prof.getId(), _category.getCategoryId(), Int32.Parse(prof_rating));
                        break;
                    case "-rmProf":
                        Console.WriteLine("Please enter the Guid of the professor to remove");
                        _guid = new Guid(Console.ReadLine());

                        Professor prof = new Professor();

                        List<Professor> _professors =  File_Manager.getProfessors();
                        foreach(Professor p in _professors)
                        {
                            if(p.id == _guid)
                            {
                                prof = p;
                            }
                        }

                        File_Manager.deleteProfessor(prof);
                        break;

                    case "-rmCateg":
                        Console.WriteLine("Please enter the Guid of the category to remove.");
                        _guid = new Guid(Console.ReadLine());

                        Category cat = new Category();

                        List<Category> _categories = File_Manager.getCategories();
                        foreach(Category c in _categories)
                        {
                            if(c.categoryId == _guid)
                            {
                                cat = c;
                            }
                        }
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
