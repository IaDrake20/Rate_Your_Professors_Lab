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

        public Category()
        {
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

        public void setName(string n)
        {
            categoryName = n;
        }

        public void setDescription(string d)
        {
            description = d;
        }

    }
}

