using System;

namespace RateMyProfessor
{
    class Program
    {

        static void Main(string[] args)
        {
            Professor myProf  = new Professor();
            var name = myProf.RecieveProfName();
            // handle if input is null, not alphabetic

            // check if Professor exists
            // if so, do not make a new ID

            Rating myRating = new Rating();
            var rating = myRating.RecieveProfRating();
            // handle if input is null, not a number, a number > 10 or < 0

            
        }           
    }
}
