using System;
namespace RateMyProfessor
{
	public class Professor
	{
		String name;

		Guid id;

		List<Rating> ratings;

		public static String[] internallisting=new String[200];

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
		 */


    }

}

