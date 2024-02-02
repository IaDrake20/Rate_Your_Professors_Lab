using RateMyProfessor;
using System;
namespace RateMyProfessor
{
	public class Rating
	{
		Guid ratingId;

		Guid professorId;

		Guid categoryId;

		int ratingValue; //1-10

		public Rating()
		{
			ratingId = Guid.NewGuid();
			professorId = Guid.NewGuid();
			categoryId = Guid.NewGuid();
			ratingValue = 0;
		}

		public Rating(Guid pId, Guid catId, int value )
		{
			ratingId = Guid.NewGuid();

			professorId = pId;

			categoryId = catId;

			ratingValue = value;

		}

        public string RecieveProfRating()
        {
            Console.WriteLine("Please enter your rating of the professor: ");
            string r_input = Console.ReadLine();
            return r_input;
        }
    }
}

