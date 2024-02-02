using RateMyProfessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Lab_RateMyProfessor
{
    public class Professor_Test
    {
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
    }
}
