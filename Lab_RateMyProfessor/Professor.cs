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

/*
        * public static String[] internallisting=new String[200];

       public Professor(String n)
       {
           name = n;

           id = Guid.NewGuid();

           ratings = new List<Rating>();
           for(int i = 1; i < internallisting.Length; i++)
               {
               if (internallisting[i].Equals(null))
                   internallisting[i] = name;
               Console.WriteLine(name + " is entry number " + i);
               }
       }
       public void printProfArray()
       {
           for (int i = 1; i < internallisting.Length; i++) {
               if (!internallisting[i].Equals(""))
                   Console.WriteLine(i+". " + internallisting[i]);
                   }
       }
       public void setProfName(int pos, String newname)
       {
           internallisting[pos]=newname;
       }

       public Guid getId()
       {
           return id;
       }

       public void addProfRating(Rating r)
       {
           ratings.Add(r);
       }

       public String deleteProfRating(Rating r)
       {
           if (ratings.Contains(r))
           {
               ratings.Remove(r);
               return "Successfully deleted rating: " + r;
           }
           else
               return "Could not remove rating";

       }

       public int getProfpos(String name)
       {
           int pos = 0;
           int i = 1;
           while (!internallisting[i++].Equals(name))


               if (i != internallisting.Length)
                   pos = i;
               else
                   pos = -1;
           //If pos ==-1 print not found or something
           return pos;
       }
       public void deleteProfpos(int pos)
       {//internal class
           for (int i = pos; i < internallisting.Length; i++)
           {

               if (internallisting[i].Equals(null)||i == internallisting.Length-1)
               {
                   for(int j = pos; j < i; j++)
                   {
                       internallisting[j] = internallisting[j + 1];
                   }
               }

           }
       }
       public void deleteProf()
       {
           int p=getProfpos(name);
           if (p != -1)
               deleteProfpos(p);
           name = "";
           id = Guid.Empty;
           ratings = new List<Rating>(); 

       }
       /*
        *                                                                                                 
                                 :*%@@@@@@@@@@@@@@@@@@@@@@@@@@%-                                   
                          *%@@@@@@@@@@##++==-----------=++*#@@@@@@@%=                              
                     *#@@@@@@@%=..      ..                    ...+%@@@@#                           
                  *@@@@@@%-.......                              .....-%@@@@                        
               #@@@@@#-.....                                         ....#@@@%                     
            =@@@@@*.....                                                ...:@@@@+                  
          +@@@@+....                                                       ...%@@@#                
         %@@@-...                                                             ..%@@@*              
       *@@@=..                                                                  ..@@@@             
      #@@%..                                                                      .=@@@*           
     %@@+.                                                                          .%@@*          
    #@@=.                                                                           ..#@@*         
   #@@+                                                                               .#@@*        
   @@*.                                                                               ..%@@=       
  %@#..                                                     .... .......               .-@@%       
 %@@.                ....:--:.......                      ..:#@@@@@@@@*-....            .%@@#      
 %@=.               .-@@@@@@@@@@@@+.                      :@@@@@@@@@@@@@@@:.            .:@@%      
*@%..              .@@@@@@@@@@@@@@@@@#:.                .%@@@@@@@@@@@@@@@@@#            ..%@@#     
%@*              ..@@@@@#...-@@@@@@@@@@*.             .-@@@@@@=..:@@@@@@@@@@*.          ..=@@%     
%@=              .%@@@@=.. .#@@@@@@@@@@@-.            .@@@@@@:. .-@@@@@@@@@@@.           ..@@@     
%@:              -@@@@@:..-%@@@@@@@@@@@@#.            +@@@@@@=..-@@@@@@@@@@@@-            .#@@-    
%@:              -@@@@@@@@@@@@@@@@@@@@@@@.           .*@@@@@@@@@@@@@@@@@@@@@@=.           .*@@*    
%@:              .@@@@@@@@@@@@@@@@@@@@@@@.            -@@@@@@@@@@@@@@@@@@@@@@..            +@@#    
%@.              .#@@@@@@@@@@@@@@@@@@@@@%.            .%@@@@@@@@@@@@@@@@@@@@#.            .=@@#    
%@.              ..@@@@@@@@@@@@@@@@@@@@@:.            .:@@@@@@@@@@@@@@@@@@@-.             .*@@+    
-@%.              ...%@@@@@@@@@@@@@@@@@#...            ..=@@@@@@@@@@@@@@@+...              .#@@-    
#@@.                ..-%@@@@@@@@@@@@@%...                ..:*%@@@@@@%#=.. .              ..:@@%     
%@@.                  ......:--==-:....                    ............                  ..%@@#     
@@#..                                                                                   .#@@#      
%@@*.                                                                                 ..%@@#       
 %@@@:.                                                                              ..@@@%        
  *@@@#..                                                                           .+@@@#         
    %@@@*..                              .%%%%%%%%%%%%:.                         ..:@@@@=          
      %@@@*..                            .@@@@@@@@@@@@-.                      ...-@@@@*            
        %@@@*..                                                             ...+@@@%=              
          #@@@@...                                                      ....+@@@@*                 
            *@@@@-....                                            ......=%@@@@#-                   
               %@@@#....                                  ........:=%@@@@@@@@@@@@@@@@@@%#*=        
                 *@@@@+.                                ...:+%@@@@@@@@@@@@@%#*****##@@@@@@@@@=     
                    #@@@@+..         .. ... ...-=+*#@@@@@@@@@@@%#+-........         ......+@@@%    
                       %@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%#+:.......                          ..=@@%   
                         +#@@@@@@@@@@@@@#*=-::.......                                       .:@@#  
                             %@@=......     ..    .                                         ..-@@- 
                             #@*..                                                            .#@# 
                             #@=.                                                             .+@% 
                             *@=...                                                           .-@% 
                             =@+..                                                             :@% 
                             :@*..                                                            .:@% 
                              @#...               ....               ........   ...           .-@@ 
                              %@..               .%%..             ..-+#%%%%%%%%%..           .=@% 
                              %@-.               .@@+.            .=@@@@@@%@@@%@@@..          .*@% 
                              #@*.               .@@@.            .#%..   .-@% *@@..          .%@# 
                              +@@.              .-@@@:            .@*.     :@#  @@+..         :@@- 
                               %@=..            .+@@@-            :@*.    .:@#  *@@..       ..*@%  
                               %@#..             #@=@#..          =@*.    .:@+   @@..       ..@@=  
                               =@@-.             %@=@@:.          *@%..   .-@+   %@=.       .*@%   
                                %@%.            .@@ @@*.        ..@@@-.   .#@=   :@@..    ..:@@=   
                                +@@+.           :@% +@@:..      .-@@@@:...:@@:    @@=..   ..@@%    
                                 %@@:.          %@*  @@@..      .+@@@@@@%@@@@     =@@-....*@@@+    
                                  @@@...     ...@@-  .@@@...    .%@%.#@@@@%=       @@@@@@@@@@      
                                  +@@@:.     ..@@@    =@@@:.    =@@=                *%%%%**        
                                   *@@@#.....*@@@-     =@@@@=:-%@@#                                
                                     @@@@@@@@@@%         #@@@@@@@+                                 
                                       ##%##*                                                      

        * 



   }

   public class ProfessorTests
   {
       private readonly ITestOutputHelper output;
       public ProfessorTests(ITestOutputHelper output)
       {
           this.output = output;
       }
       [Fact]
       public void Professor_Constructor_SetsNameAndId()
       {

           string professorName = "John Doe";


           Professor professor = new Professor(professorName);


           Assert.Equal(professorName, professor.name);
           Assert.NotEqual(Guid.Empty, professor.getId());
       }

       /*[Fact]
       public void Professor_AddProfRating_AddsRatingToList()
       {

           Professor professor = new Professor("John Doe");
           Rating rating = new Rating(5, "Great professor!");


           professor.addProfRating(rating);


           Assert.Contains(rating, professor.ratings);
       }*/

/*  [Fact]
public void Professor_DeleteProfRating_RemovesRatingFromList()
{

    Professor professor = new Professor("John Doe");
    Rating rating = new Rating(4, "Good professor!");
    professor.addProfRating(rating);


    professor.deleteProfRating(rating);


    Assert.DoesNotContain(rating, professor.ratings);
}

[Fact]
public void Professor_DeleteProf_DeletesProfessor()
{

    string professorName = "John Doe";
    Professor professor = new Professor(professorName);


    professor.deleteProf();


    Assert.Equal(Guid.Empty, professor.getId());
    Assert.Equal("", professor.name);
    Assert.Empty(professor.ratings);
}

[Fact]
public void Professor_PrintProfArray_PrintsNonEmptyNames()
{
    // Arrange
    Professor professor1 = new Professor("John Doe");
    Professor professor2 = new Professor("Jane Smith");

    // Act
    professor1.printProfArray();

    // Assert
    string outputString = output.ToString();
    Assert.Contains("1. John Doe", outputString);
    Assert.Contains("2. Jane Smith", outputString);
}

[Fact]
public void Professor_SetProfName_SetsNameAtIndex()
{

    Professor professor = new Professor("John Doe");


    professor.setProfName(1, "Updated Name");


    Assert.Equal("Updated Name", Professor.internallisting[1]);
}

[Fact]
public void Professor_DeleteProfpos_DeletesNameAtIndex()
{

    Professor professor1 = new Professor("John Doe");
    Professor professor2 = new Professor("Jane Smith");


    professor1.deleteProfpos(1);


    Assert.Equal("Jane Smith", Professor.internallisting[1]);
}

[Fact]
public void Professor_GetProfpos_ReturnsCorrectPosition()
{

    Professor professor1 = new Professor("John Doe");
    Professor professor2 = new Professor("Jane Smith");


    int position = professor1.getProfpos("Jane Smith");


    Assert.Equal(2, position);
}
}
*/