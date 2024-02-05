using RateMyProfessor;
using System;
namespace RateMyProfessor
{
	public class Ratings
	{
		public Guid ratingId;

		public Guid professorId;

		public Guid categoryId;

		public int ratingValue; //1-10

		public Ratings()
		{
			ratingId = Guid.NewGuid();
			professorId = Guid.NewGuid();
			categoryId = Guid.NewGuid();
			ratingValue = 0;
		}

		public Ratings(Guid pId, Guid catId, int value )
		{
			ratingId = Guid.NewGuid();

			professorId = pId;

			categoryId = catId;

			ratingValue = value;

		}
        public Ratings(Guid rId, Guid pId, Guid catId, int value)
        {
            ratingId = Guid.NewGuid();

            professorId = pId;

            categoryId = catId;

            ratingValue = value;

        }
        public Guid getId()
		{
			return ratingId;
		}

		public Guid getProfessorId()
		{
			return professorId;
		}

		public int getRatingValue()
		{

			return ratingValue;
		}

		public void setRatingValue( int value )
		{
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

