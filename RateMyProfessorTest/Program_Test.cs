using RateMyProfessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using Lab_RateMyProfessor;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata.Ecma335;

namespace Lab_RateMyProfessor
{
    public class Program_Test
    {

        [Fact]
        public void Test_FM_Add_Delete_Category()
        {
            //add , retrieve , delte json -- Categories

            Professor bilitski = new Professor("bilitski");
            Category bestDressed = new Category("Best Dressed", "Who dresses the best");
            Ratings rat = new Ratings(bilitski.getId(), bestDressed.getCategoryId(), 10);
            
            
            bool found = false;
            
            Assert.True(File_Manager.addCategory(bestDressed));

            List<Category> existingCats = File_Manager.getCategories();
            foreach (Category cat in existingCats)
            {
                if (cat.getCategoryId() == bestDressed.getCategoryId())
                {
                    found = true;
                }
            }
            Assert.True(found);

            File_Manager.deleteCategory(bestDressed);

            found = false;
            existingCats = File_Manager.getCategories();
            foreach (Category cat in existingCats)
            {
                if (cat.getCategoryId() == bestDressed.getCategoryId())
                {
                    found = true;
                }
            }
            Assert.False(found);
        }

        [Fact]
        public void Test_FM_Add_Delete_Professor()
        {
            //add and retrieve json -- Professor

            Professor bilitski = new Professor("bilitski");
            Category bestDressed = new Category("Best Dressed", "Who dresses the best");
            Ratings rat = new Ratings(bilitski.getId(), bestDressed.getCategoryId(), 10);

            bilitski.addRating(rat);

            bool found = false;

            Assert.True(File_Manager.addProfessor(bilitski));

            List<Professor> existingProfs = File_Manager.getProfessors();
            foreach (Professor prof in existingProfs)
            {
                if (prof.getId() == bilitski.getId())
                {
                    found = true;
                }
            }
            Assert.True(found);


            File_Manager.deleteProfessor(bilitski);

            found = false;
            existingProfs = File_Manager.getProfessors();
            if (existingProfs.Count != 0)
            {
                foreach (Professor prof in existingProfs)
                {
                    if (prof.getId() == bilitski.getId())
                    {
                        found = true;
                    }
                }
            }
            Assert.False(found);
        }

    

        
        [Fact]
        public void Test_FM_Add_Delete_Rating()
        {

            //add and retrieve json -- Ratings

            Professor bilitski = new Professor("bilitski");
            Category bestDressed = new Category("Best Dressed", "Who dresses the best");
            Ratings rat = new Ratings(bilitski.getId(), bestDressed.getCategoryId(), 10);

            

            bool found = false;

            Assert.True(File_Manager.addRating(rat));

            List<Ratings> existingRats = File_Manager.getRatings();
            foreach (Ratings rating in existingRats)
            {
                if (rating.getId() == rat.getId())
                {
                    found = true;
                }
            }
            Assert.True(found);

            File_Manager.deleteRating(rat);

            found = false;
            existingRats = File_Manager.getRatings();
            foreach (Ratings rating in existingRats)
            {
                if (rating.getId() == rat.getId())
                {
                    found = true;
                }
            }
            Assert.False(found);
        }

        [Fact]
        public void Test_Get_Categories()
        {
            Category cat1 = new Category("hi", "ji");
            Category cat2 = new Category("f", "ji");
            Category cat3 = new Category("sd", "ji");
            File_Manager.addCategory(cat1);
            File_Manager.addCategory(cat2);
            File_Manager.addCategory(cat3);

            List<Category> categories = File_Manager.getCategories();
            
            Assert.True(categories.Count == 3);
        }



    }






        /*public class ProfessorTests
        {
            [Fact]
            public void TestProfessor()
            {
                using (var consoleOutput = new ConsoleOutput())
                {
                 
                    Professor professor = new Professor();

                    // Simulate user input for the Main method
                    string[] userInputs = { "-addProf", "John Doe", "-viewProf", "E" };

                    
                    SimulateUserInput(userInputs);
                    //This needs a proper main reference so that the test runs main
                    //Lab_RateMyProfessor.Program.Main(null);

                   
                    string output = consoleOutput.GetOutput();
                    Assert.Contains("Please enter a professor's name:", output);
                    Assert.Contains("John Doe", output);
                    Assert.Contains("John Doe", output);
                }
            }

            private void SimulateUserInput(string[] inputs)
            {
                using (var stringReader = new StringReader(string.Join(Environment.NewLine, inputs)))
                {
                    Console.SetIn(stringReader);
                }
            }

            private class ConsoleOutput : IDisposable
            {
                private readonly StringWriter stringWriter;
                private readonly TextWriter originalOutput;

                public ConsoleOutput()
                {
                    stringWriter = new StringWriter();
                    originalOutput = Console.Out;
                    Console.SetOut(stringWriter);
                }

                public string GetOutput()
                {
                    return stringWriter.ToString();
                }

                public void Dispose()
                {
                    stringWriter.Dispose();
                    Console.SetOut(originalOutput);
                }
            }
        }*/
}



