using Lab_RateMyProfessor;
using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using Xunit;

namespace RateMyProfessor
{
    class Program
    {

        public static void Main(string[] args)
        {
            bool run = true;
            string response = "";
            string prof_name = "";

            string _guid = "";

            string cat_desc = "";
            Category _category = new Category();
            Professor _prof = new Professor();

            

            while (run)
            {
                Console.WriteLine("M: M for menu to see options, E: Exit, " +
                            "\n-add: start adding a professor to be rated within a category, -addProf: add professor only, -addCateg: add category only, -addRating: add Rating to a professor" +
                            "\n-editProf: edit name, -editCateg: edit the category name and description, -editRating: edit the rating of a professor" +
                            "\n-rmProf: remove a professor, -rmCateg: remove a category, -rmRating: remove a rating from a professor" +
                            "\n-viewProf: view professors and their guids, -viewCateg: view categories and their guids, -viewRatings: view ratings and their guids");
                response = Console.ReadLine();

                switch (response)
                {
                    case "M":
                        Console.WriteLine("M: M for menu to see options, E: Exit, C: Continue, " +
                            "\n-add: start adding a professor to be rated within a category, -addProf: add professor only, -addCateg: add category only, -addRating: add Rating to a professor" +
                            "\n-editProf: edit name, -editCateg: edit the category name and description, -editRating: edit the rating of a professor" +
                            "\n-rmProf: remove a professor, -rmCateg: remove a category, -rmRating: remove a rating from a professor" +
                            "\n");
                        break;
                    case "-add":
                        Console.WriteLine("Please enter a professor's name.");
                        prof_name = Console.ReadLine();
                        _prof = new Professor(prof_name);
                        File_Manager.addProfessor(_prof);

                        Console.WriteLine("Please enter a category.");
                        string cat_name = Console.ReadLine();
                        

                        Console.WriteLine("Please enter the category's description.");
                        cat_desc = Console.ReadLine();
                        _category = new Category(cat_name, cat_desc);
                        File_Manager.addCategory(_category);    

                        Console.WriteLine("Please enter a rating for the professor.");
                        string prof_rating = Console.ReadLine();
                        Ratings _rating = new Ratings(_prof.getId(), _category.getCategoryId(), Int32.Parse(prof_rating));
                        File_Manager.addRating(_rating);
                        break;
                    case "-addProf":
                        Console.WriteLine("Please enter a professor's name.");
                        prof_name = Console.ReadLine();
                        _prof = new Professor(prof_name);
                        File_Manager.addProfessor(_prof);
                        break;
                    case "-addCateg":
                        Console.WriteLine("Please enter a category.");
                        cat_name = Console.ReadLine();

                        Console.WriteLine("Please enter the category's description.");
                        response = Console.ReadLine();
                        _category = new Category(cat_name, cat_desc);
                        File_Manager.addCategory(_category);
                        break;
                    case "-addRating":
                        Console.WriteLine("Please enter the rating to add.");
                        prof_rating = Console.ReadLine();
                        _rating = new Ratings(_prof.getId(), _category.getCategoryId(), Int32.Parse(prof_rating));
                        File_Manager.addRating(_rating);
                        break;
                    case "-rmProf":
                        Console.WriteLine("Please enter the Guid of the professor to remove");
                        _guid = Console.ReadLine();

                        Professor prof = new Professor();

                        List<Professor> _professors =  File_Manager.getProfessors();
                        foreach(Professor p in _professors)
                        {
                            if(p.id.Equals(_guid))
                            {
                                prof = p;
                            }
                        }

                        File_Manager.deleteProfessor(prof);
                        break;

                    case "-rmCateg":
                        Console.WriteLine("Please enter the Guid of the category to remove.");
                        _guid = Console.ReadLine();

                        Category cat = new Category();

                        List<Category> _categories = File_Manager.getCategories();
                        foreach(Category c in _categories)
                        {
                            if(c.categoryId.Equals(_guid))
                            {
                                cat = c;
                            }
                        }
                        File_Manager.deleteCategory(cat);
                        break;
                    case "-rmRating":
                        Console.WriteLine("Please enter the Guid of the rating to remove.");
                        _guid = (Console.ReadLine());

                        Ratings rat = new Ratings();

                        List<Ratings> _ratings = File_Manager.getRatings();
                        foreach(Ratings r in _ratings)
                        {
                            if(r.ratingId.Equals(_guid))
                            {
                                rat = r;
                            }
                        }
                        File_Manager.deleteRating(rat);
                        break;
                    case "-viewProf":
                        Console.WriteLine("Displaying the current list of professors.");
                        List<Professor> ps = File_Manager.getProfessors();
                        foreach(Professor p in ps)
                        {
                            Console.WriteLine(p.name + " " + p.id);
                        }
                        break;
                    case "-viewCateg":
                        List<Category> cs = File_Manager.getCategories();
                        foreach(Category c in cs)
                        {
                            Console.WriteLine(c.categoryName + " " + c.categoryId);
                        }
                        break;
                    case "-viewRatings":
                        List<Ratings> rs = File_Manager.getRatings();
                        foreach(Ratings r in rs)
                        {
                            Console.WriteLine(r.ratingId);
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
