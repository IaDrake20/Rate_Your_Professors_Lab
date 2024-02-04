using Lab_RateMyProfessor;
using System;
using Xunit;

namespace RateMyProfessor
{
    class Program
    {

        static void Main(string[] args)
        {
            /*Professor myProf = new Professor();
            var name = myProf.RecieveProfName();
            // handle if input is null, not alphabetic

            // check if Professor exists
            // if so, do not make a new ID

            Ratings myRating = new Ratings();
            var rating = myRating.RecieveProfRating();
            // handle if input is null, not a number, a number > 10 or < 0*/


            //quick tests for file manager
            
            Professor bilitski = new Professor("bilitski");
            Category bestDressed = new Category("Best Dressed" , "Who dresses the best");
            Ratings rat = new Ratings(bilitski.getId() , bestDressed.getCategoryId(), 10);

            bilitski.addRating(rat);


            File_Manager.addProfessor(bilitski);
            File_Manager.addCategory(bestDressed);
            File_Manager.addRating(rat);

            //--------------ADD BREAK POINT TO CHECK OPERATIONS PRIOR TO CONTINUING---------------------

            File_Manager.deleteProfessor(bilitski);
            File_Manager.deleteCategory(bestDressed);
            File_Manager.deleteRating(rat);
        }
    }
}
