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
        public void IsValidRating_ValidRating_ReturnsTrue()
        {
            var prog = new Program();

            var result = prog.RecieveProfName();

            // Assert
            Assert.True(result);
        }
    }
}
