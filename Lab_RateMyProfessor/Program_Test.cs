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
        [Fact]
        public void ValidProfName()
        {
            var prog = new Program();

            var result = prog.RecieveProfName();

            //check name is only letters
            Assert.True(result.All(char.IsLetter));

            //check that name exists
            Assert.True(result.Length > 0);
        }

        [Fact]
        public void ValidProfRating()
        {
            var prog = new Program();

            var result = prog.RecieveProfRating();
            int rating = Int32.Parse(result.ToString());

            // Assert rating is number
            Assert.True(result.All(char.IsNumber));

            //check that rating is within range
            Assert.True( rating <= 10 && rating >= 0);
        }
    }
}
