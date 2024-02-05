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
                Console.WriteLine("M: M for menu to see options, E: Exit, C: Continue, " +
                            "\n-add: start adding a professor to be rated within a category, -addProf: add professor only, -addCateg: add category only, -addRating: add Rating to a professor" +
                            "\n-editProf: edit name, -editCateg: edit the category name and description, -editRating: edit the rating of a professor" +
                            "\n-rmProf: remove a professor, -rmCateg: remove a category, -rmRating: remove a rating from a professor" +
                            "\n-delProf: delete professor json file, -delCateg: delete category json file, -delRating: delete ratings file" +
                            "\n");
                response = Console.ReadLine();

                switch (response)
                {
                    case "M":
                        Console.WriteLine("M: M for menu to see options, E: Exit, C: Continue, " +
                            "\n-add: start adding a professor to be rated within a category, -addProf: add professor only, -addCateg: add category only, -addRating: add Rating to a professor" +
                            "\n-editProf: edit name, -editCateg: edit the category name and description, -editRating: edit the rating of a professor" +
                            "\n-rmProf: remove a professor, -rmCateg: remove a category, -rmRating: remove a rating from a professor" +
                            "\n-delProf: delete professor json file, -delCateg: delete category json file, -delRating: delete ratings file" +
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

                        try
                        {
                            int rating = Int32.Parse(prof_rating);
                        } catch( Exception ex)
                        {
                            Console.WriteLine("ERROR: Please enter a number for the rating.");
                            break;
                        }

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
                    case "-editProf":
                        Console.WriteLine("Please enter the Guid of the professor to edit");
                        _guid = Console.ReadLine();

                        Professor prof = new Professor();

                        List<Professor> _professors = File_Manager.getProfessors();
                        foreach (Professor p in _professors)
                        {
                            if (p.id.ToString().Equals(_guid))
                            {
                                Console.WriteLine("Comparing " + p.id + " to " + _guid);
                                prof = p;
                            } else
                            {
                                Console.WriteLine("ERROR: professor not found. Check your Guid");
                            }
                        }

                        Console.WriteLine("Please pick what to edit.\n1:Name\n2:Rating");
                        response = Console.ReadLine();

                        Professor pf = new Professor();

                        switch (response)
                        {
                            case "1":
                                Console.WriteLine("Please enter a new name.");
                                prof.setProfName(Console.ReadLine());
                                break;
                            case "2":
                                Console.WriteLine("Listing ratings...");
                                List<Ratings> list = prof.ratings;
                                foreach(Ratings r_list in list)
                                {
                                    Console.WriteLine(r_list.ratingId.ToString());
                                }
                                Console.WriteLine("Please enter the guid of the rating you wish to edit.");
                                response = Console.ReadLine();
                                foreach(Ratings r_list in list)
                                {
                                    if (response.Equals(r_list.ratingId))
                                    {
                                        Console.WriteLine("Please enter your new rating");
                                        r_list.setRatingValue(Int32.Parse(Console.ReadLine()));
                                    }
                                }
                                break;
                        }
                        break;
                    case "-editCateg":
                        break;
                    case "-editRating":
                        break;
                    case "-rmProf":
                        Console.WriteLine("Please enter the Guid of the professor to remove");
                        _guid = Console.ReadLine();

                        prof = new Professor();

                        _professors =  File_Manager.getProfessors();
                        foreach(Professor p in _professors)
                        {
                            if(p.id.ToString().Equals(_guid))
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
                            if(c.categoryId.ToString().Equals(_guid))
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
                            if(r.ratingId.ToString().Equals(_guid))
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
                    case "-delProf":
                        File_Manager.DeleteFile("professors.json");
                        break;
                    case "-delCateg":
                        File_Manager.DeleteFile("categories.json");
                        break;
                    case "delRatings":
                        File_Manager.DeleteFile("ratings.json");
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
