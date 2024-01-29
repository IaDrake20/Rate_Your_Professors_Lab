using System;
namespace RateMyProfessor
{
    public class Category
    {
        string categoryName;

        Guid categoryId;

        string description;

        public Category(string n , string descr)
        {
            categoryName = n;

            description = descr;

            categoryId = Guid.NewGuid();
        }
    }
}

