using RateMyProfessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xunit;
using Lab_RateMyProfessor;

namespace Lab_RateMyProfessor
{
    public class Program_Test
    {
        /*
        [Fact]
        public void test_input()
        {
            
        }

        [Fact]
        public void ValidProfName()
        {
            var prof = new Professor();

            var result = prof.RecieveProfName();

            //check name is only letters
            Assert.True(result.All(char.IsLetter));

            //check that name exists
            Assert.True(result.Length > 0);
        }

        [Fact]
        public void ValidProfRating()
        {
            var rateings = new Ratings();

            var result = rateings.RecieveProfRating();
            int rating = Int32.Parse(result.ToString());

            // Assert rating is number
            Assert.True(result.All(char.IsNumber));

            //check that rating is within range
            Assert.True(rating <= 10 && rating >= 0);
        }
        */

        [Fact]
        public void TestFileManager()
        {
            //quick tests for file manager

            Professor bilitski = new Professor("bilitski");
            Category bestDressed = new Category("Best Dressed", "Who dresses the best");
            Ratings rat = new Ratings(bilitski.getId(), bestDressed.getCategoryId(), 10);

            bilitski.addRating(rat);


            //add and retrieve json
            Assert.True(File_Manager.addProfessor(bilitski));
            Assert.Contains(bilitski, File_Manager.getProfessors());

            Assert.True(File_Manager.addCategory(bestDressed));
            Assert.Contains(bestDressed, File_Manager.getCategories());

            Assert.True(File_Manager.addRating(rat));

            //dupe
            Assert.True(File_Manager.addProfessor(bilitski));
            Assert.True(File_Manager.addCategory(bestDressed));

            File_Manager.deleteProfessor(bilitski);
            File_Manager.deleteCategory(bestDressed);
            File_Manager.deleteRating(rat);
        }





        public class ProfessorTests
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
        }
    }
}



