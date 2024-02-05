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

        public static Professor bilitski = new Professor("bilitski");
        public static Category bestDressed = new Category("Best Dressed", "Who dresses the best");
        Ratings rat = new Ratings(bilitski.getId(), bestDressed.getCategoryId(), 10);



        [Fact]
        public void Test_FM_Add_Category()
        {
            //add and retrieve json -- Categories
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
        }

        [Fact]
        public void Test_FM_Add_Professor()
        {
            //add and retrieve json -- Professor
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
        }

    

        
        [Fact]
        public void Test_FM_Add_Rating()
        {

            //add and retrieve json -- Ratings
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
        }


        [Fact]
        public void Test_FM_CAdd_Dup()
        {
            Assert.False(File_Manager.addProfessor(bilitski));
            Assert.False(File_Manager.addCategory(bestDressed));
        }

        [Fact]
        public void Test_FM_Delete_Prof()
        {
            File_Manager.deleteProfessor(bilitski);
            
            bool found = false;
            List<Professor> existingProfs = File_Manager.getProfessors();
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
        public void Test_FM_Delete_Category()
        {
            File_Manager.deleteCategory(bestDressed);

            bool found = false;
            List<Category> existingCats = File_Manager.getCategories();
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
        public void Test_FM_Delete_Rating()
        {
            File_Manager.deleteRating(rat);

            bool found = false;
            List<Ratings> existingRats = File_Manager.getRatings();
            foreach (Ratings rating in existingRats)
            {
                if (rating.getId() == rat.getId())
                {
                    found = true;
                }
            }
            Assert.False(found);

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



