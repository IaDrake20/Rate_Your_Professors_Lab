using RateMyProfessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Xunit;


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


            Assert.True(File_Manager.addProfessor(bilitski));
            Assert.True(File_Manager.addCategory(bestDressed));
            Assert.True(File_Manager.addRating(rat));

            //dupe
            Assert.True(File_Manager.addProfessor(bilitski));
            Assert.True(File_Manager.addCategory(bestDressed));

            File_Manager.deleteProfessor(bilitski);
            File_Manager.deleteCategory(bestDressed);
            File_Manager.deleteRating(rat);

        }
        [Fact]
        public void TestProfessor()
        {
            //Tests for getters and setters in Professor
            Professor professor = new Professor("John Doe");
            Guid id = professor.getId();
            Category category = new Category("Best Dressed", "For the best of dress");
            Assert.NotEqual(Guid.Empty, id);

            var fakeConsoleInput = "James Bilitski"; // Replace with good input
            using (var consoleInput = new ConsoleInput(fakeConsoleInput))
            {
                string input = professor.RecieveProfName();
                Assert.Equal(fakeConsoleInput, input);
            }

            Ratings rating = new Ratings();

            professor.addRating(rating);

            Assert.Contains(rating, professor.ratings);

            professor.setProfName("New Name");

            Assert.Equal("New Name", professor.name);

            professor.deleteProfRating(rating);

            Assert.DoesNotContain(rating, professor.ratings);
        }

        private class ConsoleInput : IDisposable
        {
            private readonly System.IO.StringReader stringReader;
            private readonly System.IO.TextReader originalInput;

            public ConsoleInput(string input)
            {
                stringReader = new System.IO.StringReader(input);
                originalInput = Console.In;
                Console.SetIn(stringReader);
            }

            public void Dispose()
            {
                stringReader.Dispose();
                Console.SetIn(originalInput);
            }
        }
    }
}
