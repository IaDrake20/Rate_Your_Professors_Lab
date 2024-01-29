using System;
namespace RateMyProfessor
{
	public class Professor
	{
		String name;

		Guid id;

		List<Rating> ratings;


		public Professor(String n)
		{
			name = n;

			id = Guid.NewGuid();

			ratings = new List<Rating>();
		}


		public Guid getId()
		{
			return id;
		}



	}
}

