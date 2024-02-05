using Lab_RateMyProfessor;
using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            string _guid = "";


            while (run)
            {
                Console.WriteLine("M: Menu to see options E: Exit" +
                            "\n-add: start adding a professor to be rated within a category" +
                            "\n-addProf: add professor only" +
                            "\n-addCateg: add category only" +
                            "\n-addRating: add Rating to a professor" +
                            "\n-editProf: edit name" +
                            "\n-editCateg: edit the category name and description" +
                            "\n-editRating: edit the rating of a professor" +
                            "\n-viewCateg: view the category properties" +
                            "\n-viewProf: view the professor properties" +
                            "\n-viewRatings: view the Rating Properties" +
                            "\n");
                response = Console.ReadLine();

                switch (response)
                {
                    case "M":
                        Console.WriteLine("M: Menu to see options, E: Exit, C: Continue, " +
                            "\n-add: start adding a professor to be rated within a category" +
                            "\n-addProf: add professor only" +
                            "\n-addCateg: add category only" +
                            "\n-addRating: add Rating to a professor" +
                            "\n-editProf: edit name" +
                            "\n-editCateg: edit the category name and description" +
                            "\n-editRating: edit the rating of a professor" +
                            "\n-viewCateg: view the category properties" +
                            "\n-viewProf: view the professor properties" +
                            "\n-viewRatings: view the Rating Properties" +
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
                        Category _category = new Category(cat_name, cat_desc);
                        File_Manager.addCategory(_category);
                        Console.WriteLine("Please enter a rating for the professor.");
                        string prof_rating = Console.ReadLine();
                        Ratings _rating = new Ratings(_prof.getId(), _category.getCategoryId(), Int32.Parse(prof_rating));
                        File_Manager.addRating(_rating);
                        _prof.addRating(_rating);
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
                        cat_desc = Console.ReadLine();
                        _category = new Category(cat_name, cat_desc);

                        File_Manager.addCategory(_category);
                        break;
                    case "-addRating":
                        
                        Professor prof2 = new Professor();
                        Category cat = new Category();
                        Console.WriteLine("Please enter the Guid of the professor to add the Rating to");
                        _guid = Console.ReadLine();
                        
                        List<Professor> _professors2 = File_Manager.getProfessors();
                        foreach (Professor p in _professors2)
                        {
                            if (p.id.ToString().Equals(_guid))
                            {
                                // Console.WriteLine("Comparing " + p.id + " to " + _guid);
                                prof2 = p;
                                Console.WriteLine("Please enter the category to add the Rating to.");
                                _guid = Console.ReadLine();
                                List<Category> cate = File_Manager.getCategories();
                                foreach (Category c in cate)
                                {
                                    if (c.categoryId.ToString().Equals(_guid))
                                    {
                                        cat= c;
                                        
                                        Console.WriteLine("Please enter the rating to add.");
                                        prof_rating = Console.ReadLine();
                                        _rating = new Ratings(prof2.getId(), cat.getCategoryId(), Int32.Parse(prof_rating));
                                        while (_rating.ratingValue < 1 || _rating.ratingValue > 10)
                                        {
                                            Console.WriteLine("Please enter the rating to add.");
                                            prof_rating = Console.ReadLine();
                                            _rating = new Ratings(prof2.getId(), cat.getCategoryId(), Int32.Parse(prof_rating));
                                        }
                                        File_Manager.addRating(_rating);
                                    }
                                    else
                                    {
                                        Console.WriteLine("ERROR: category not found. Check your Guid");
                                        break;
                                    }
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("ERROR: professor not found. Check your Guid");
                                break;
                            }
                        }

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
                                //Console.WriteLine("Comparing " + p.id + " to " + _guid);
                                prof = p;
                                Console.WriteLine("Please pick what to edit.\n1:Name\n2:Rating");
                                response = Console.ReadLine();

                                switch (response)
                                {
                                    case "1":
                                        Console.WriteLine("Please enter a new name.");
                                        prof.setProfName(Console.ReadLine());
                                        break;
                                    case "2":
                                        Console.WriteLine("Listing ratings...");
                                        List<Ratings> list = prof.ratings;
                                        foreach (Ratings r_list in list)
                                        {
                                            Console.WriteLine(r_list.ratingId.ToString());
                                        }
                                        Console.WriteLine("Please enter the guid of the rating you wish to edit.");
                                        response = Console.ReadLine();
                                        foreach (Ratings r_list in list)
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
                            } else
                            {
                                Console.WriteLine("ERROR: professor not found. Check your Guid");
                                break;
                            }
                        }
                        break;
                    case "-editCateg":
                        Category newcat = new Category();
                        Console.WriteLine("Please enter the category ID.");
                        _guid = Console.ReadLine();
                        List<Category> catee = File_Manager.getCategories();
                        foreach (Category c in catee)
                        {
                            if (c.categoryId.ToString().Equals(_guid))
                            {
                                newcat = c;
                                Guid ggggg = newcat.getCategoryId();
                                File_Manager.deleteCategory(newcat);
                                Console.WriteLine("Please enter the new category name.");
                                string name=Console.ReadLine();
                                Console.WriteLine("Please enter the new category description.");
                                string desc=Console.ReadLine();
                                Category arisencategory=new Category(ggggg);
                                File_Manager.addCategory(arisencategory);
                                arisencategory.setName(name);   
                                arisencategory.setDescription(desc);
                            }
                            else
                            {
                                Console.WriteLine("ERROR: category not found. Check your Guid");
                                break;
                            }
                        }
                        break;
                    case "-editRating":

                        Console.WriteLine("Please enter the Guid of the professor to change the Rating for");
                        string profGuid = Console.ReadLine();

                        List<Professor> _professors22 = File_Manager.getProfessors();
                        Professor prof22 = _professors22.FirstOrDefault(p => p.id.ToString().Equals(profGuid));

                        if (prof22 != null)
                        {
                            Console.WriteLine("Please enter the category to change the Rating for.");
                            string catGuid = Console.ReadLine();

                            List<Category> cate22 = File_Manager.getCategories();
                            Category cat22 = cate22.FirstOrDefault(c => c.categoryId.ToString().Equals(catGuid));

                            if (cat22 != null)
                            {
                                Console.WriteLine("Please enter the guid of the rating to change.");
                                string ratingGuid = Console.ReadLine();

                                Ratings ratingToEdit = prof22.ratings.FirstOrDefault(r => r.ratingId.ToString().Equals(ratingGuid));

                                if (ratingToEdit != null)
                                {
                                    Console.WriteLine("Please enter the new rating.");
                                    string newRating = Console.ReadLine();

                                    int newRatingValue;
                                    while (!int.TryParse(newRating, out newRatingValue) || newRatingValue < 1 || newRatingValue > 10)
                                    {
                                        Console.WriteLine("ERROR: Invalid rating. Please enter a number between 1 and 10.");
                                        newRating = Console.ReadLine();
                                    }

                                    ratingToEdit.setRatingValue(newRatingValue);
                                    File_Manager.addRating(ratingToEdit);
                                }
                                else
                                {
                                    Console.WriteLine("ERROR: Rating not found. Check your Guid.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("ERROR: Category not found. Check your Guid.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ERROR: Professor not found. Check your Guid.");
                        }
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

                        Category catel = new Category();

                        List<Category> _categories = File_Manager.getCategories();
                        foreach(Category c in _categories)
                        {
                            if(c.categoryId.ToString().Equals(_guid))
                            {
                                catel = c;
                            }
                        }
                        File_Manager.deleteCategory(catel);
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
                            Console.WriteLine("Rating ID: "+r.ratingId + " Assosciated Professor's ID:" +r.professorId+" Current Rating: "+r.ratingValue);
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
