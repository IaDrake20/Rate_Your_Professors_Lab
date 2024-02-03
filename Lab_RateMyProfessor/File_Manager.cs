using RateMyProfessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using System.IO;

namespace Lab_RateMyProfessor
{
    internal class File_Manager
    {
        public static void addCategory(Category cat)
        {
            string path = "categories.json";

            try
            {
                string existingJson = File.ReadAllText(path);

                List<Category> existingCategories;

                if (!string.IsNullOrWhiteSpace(existingJson))
                {
                    existingCategories = JsonConvert.DeserializeObject<List<Category>>(existingJson);
                }
                else
                {
                    existingCategories = new List<Category>();
                }

                existingCategories.Add(cat);

                string updatedJson = JsonConvert.SerializeObject(existingCategories, Formatting.Indented);
                File.WriteAllText(path, updatedJson);
            }
            catch (JsonSerializationException ex)
            {
                Console.WriteLine($"Error during JSON serialization/deserialization: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading/writing the file: {ex.Message}");
            }
        }

        public static void addRating(Ratings rat)
        {
            string path = "ratings.json";

            try
            {
                string existingJson = File.ReadAllText(path);

                List<Ratings> existingRatings;

                if (!string.IsNullOrWhiteSpace(existingJson))
                {
                    existingRatings = JsonConvert.DeserializeObject<List<Ratings>>(existingJson);
                }
                else
                {
                    existingRatings = new List<Ratings>();
                }

                existingRatings.Add(rat);

                string updatedJson = JsonConvert.SerializeObject(existingRatings, Formatting.Indented);
                File.WriteAllText(path, updatedJson);
            }
            catch (JsonSerializationException ex)
            {
                Console.WriteLine($"Error during JSON serialization/deserialization: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading/writing the file: {ex.Message}");
            }
        }

        public static void addProfessor(Professor pro)
        {
            string path = "professors.json";

            try
            {
                string existingJson = File.ReadAllText(path);

                List<Professor> existingProfessors;

                if (!string.IsNullOrWhiteSpace(existingJson))
                {
                    existingProfessors = JsonConvert.DeserializeObject<List<Professor>>(existingJson);
                }
                else
                {
                    existingProfessors = new List<Professor>();
                }

                existingProfessors.Add(pro);

                string updatedJson = JsonConvert.SerializeObject(existingProfessors, Formatting.Indented);
                File.WriteAllText(path, updatedJson);
            }
            catch (JsonSerializationException ex)
            {
                Console.WriteLine($"Error during JSON serialization/deserialization: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading/writing the file: {ex.Message}");
            }
        }



        public List<Category> getCategories()
        {
            string path = "categories.json";

            string existingJson = File.ReadAllText(path);

            if (string.IsNullOrWhiteSpace(existingJson))
            {
                return new List<Category>();
            }

            List<Category> existingCategories = JsonConvert.DeserializeObject<List<Category>>(existingJson);

            return existingCategories;
        }

        public List<Professor> getProfessors()
        {
            string path = "professors.json";

            string existingJson = File.ReadAllText(path);

            if (string.IsNullOrWhiteSpace(existingJson))
            {
                return new List<Professor>();
            }

            List<Professor> existingProfessors = JsonConvert.DeserializeObject<List<Professor>>(existingJson);

            return existingProfessors;
        }

        public List<Ratings> getratings()
        {
            string path = "ratings.json";

            string existingJson = File.ReadAllText(path);

            if(string.IsNullOrWhiteSpace(existingJson))
            {
                return new List<Ratings>();
            }

            List<Ratings> existingRatings = JsonConvert.DeserializeObject<List<Ratings>>(existingJson);

            return existingRatings;
        }

        public static void deleteCategory(Category cat)
        {
            string path = "categories.json";

            string existingJson = File.ReadAllText(path);
            
            List<Category> existingCategories = JsonConvert.DeserializeObject<List<Category>>(existingJson);

            if(existingCategories != null)
            {
                foreach (Category category in existingCategories)
                {
                    if (cat.getCategoryId() == category.getCategoryId())
                    {
                        existingCategories.Remove(category);


                        if(existingCategories.Count == 0)
                        {
                            File.WriteAllText(path, "");
                        }
                        else
                        {
                            string updatedJson = JsonConvert.SerializeObject(existingCategories, Formatting.Indented);

                            File.WriteAllText(path, updatedJson);
                        }
                        return;
                    }
                }

                Console.WriteLine("Category cannot be deleted because it does not exist");
            }
            else
            {
                Console.WriteLine("There are no existing categories to delete from");
            }

            
        }

        public static void deleteProfessor(Professor pro)
        {
            string path = "professors.json";

            string existingJson = File.ReadAllText(path);

            List<Professor> existingProfessors = JsonConvert.DeserializeObject<List<Professor>>(existingJson);

            if (existingProfessors != null)
            {
                foreach (Professor professor in existingProfessors)
                {
                    if (pro.getId() == professor.getId())
                    {
                        existingProfessors.Remove(professor);


                        if (existingProfessors.Count == 0)
                        {
                            File.WriteAllText(path, "");
                        }
                        else
                        {
                            string updatedJson = JsonConvert.SerializeObject(existingProfessors, Formatting.Indented);

                            File.WriteAllText(path, updatedJson);
                        }
                        return;
                    }
                }

                Console.WriteLine("Professor cannot be deleted because it does not exist");
            }
            else
            {
                Console.WriteLine("There are no existing Professors to delete from");
            }
        }

        public static void deleteRating(Ratings rat)
        {
            string path = "ratings.json";

            string existingJson = File.ReadAllText(path);

            List<Ratings> existingRatings = JsonConvert.DeserializeObject<List<Ratings>>(existingJson);

            if (existingRatings != null)
            {
                foreach (Ratings rating in existingRatings)
                {
                    if (rat.getId() == rating.getId())
                    {
                        existingRatings.Remove(rating);


                        if (existingRatings.Count == 0)
                        {
                            File.WriteAllText(path, "");
                        }
                        else
                        {
                            string updatedJson = JsonConvert.SerializeObject(existingRatings, Formatting.Indented);

                            File.WriteAllText(path, updatedJson);
                        }

                        return;
                    }
                }

                Console.WriteLine("Rating cannot be deleted because it does not exist");
            }
            else
            {
                Console.WriteLine("There are no existing Ratings to delete from");
            }
        }

    }
}
