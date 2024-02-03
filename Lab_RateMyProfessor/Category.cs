using System;
namespace RateMyProfessor
{
    public class Category
    {
        public string categoryName;

        public Guid categoryId;

        public string description;

        public Category(string n , string descr)
        {
            categoryName = n;

            description = descr;

            categoryId = Guid.NewGuid();
        }

        public string getName()
        {
            return categoryName;
        }

        public Guid getCategoryId()
        {
            return categoryId;
        }

        public string getDescription()
        {
            return description;
        }
    }
}

