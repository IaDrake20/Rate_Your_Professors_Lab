using RateMyProfessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lab_RateMyProfessor
{
    public class Ratings_Test
    {
        [Fact]
        public void ValidProfRating()
        {
            var rateings = new Ratings();

            var result = prog.RecieveProfRating();
            int rating = Int32.Parse(result.ToString());

            // Assert rating is number
            Assert.True(result.All(char.IsNumber));

            //check that rating is within range
            Assert.True(rating <= 10 && rating >= 0);
        }
    }
}
