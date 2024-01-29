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

		public Rating(Guid pId, Guid catId, int value )
		{
			ratingId = Guid.NewGuid();

			professorId = pId;

			categoryId = catId;

			ratingValue = value;

		}
	}
}

