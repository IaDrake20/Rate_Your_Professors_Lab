using System;
namespace RateMyProfessor
{
	public class Professor
	{
        public String name;

		public Guid id;

        public List<Ratings> ratings;

		public Professor()
		{
			name = "";
			id = Guid.NewGuid();
			ratings = new List<Ratings>();
		}

		public Professor(String n)
		{
			name = n;

			id = Guid.NewGuid();

			ratings = new List<Ratings>();
		}


		public Guid getId()
		{
			return id;
		}

        public string RecieveProfName()
        {
            Console.WriteLine("Please enter a professor's name: ");
            string p_input = Console.ReadLine();
            return p_input;
        }

		public void addRating(Ratings rat)
		{
			ratings.Add(rat);	
		}

    }
}

