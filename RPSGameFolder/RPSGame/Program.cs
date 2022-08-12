using System;
using BusinessLayer;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace RPSGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\t\tWelcome travelor. \n\n\t\tYou are about to embark on a perilous journey across a desolate wasteland.");
            Console.WriteLine("\n\n\n\t\tAlthough it is quite now, when hell breaks loose survival\n\t\t\tbecomes a priveldge for the most able.");
            Console.WriteLine("\n\t\tYour task although difficult is not impossible.\n\t\tIt is to get to the next outpost rife with supplies, liqour, and weed a few towns over.");

            bool gameOVER = false;
            do{
                Console.WriteLine("\n\n\t\tCan you handle it?\nENTER YOUR RESPONSE BELOW");
                string answer = Console.ReadLine();
                if((answer.Trim().ToUpper() == "Y")||(answer.Trim().ToUpper() == "YES") || (answer.Trim().ToUpper() == "YEA")){
                    Console.WriteLine($"\n\n{answer.Trim().ToUpper()} eh?\n\n\t\tGood luck...You're gonna need it, MUOAHAHAHAH!!!!\n");
                    Console.WriteLine("\n\n\t\tPRESS ENTER TO BEGIN");
                    Console.Read();
                    Gameplay gameplay = new Gameplay();
                    gameplay.NewGame();
                    while(true){
                        GamePlayOperations GPOp = new GamePlayOperations();
                        
                        var PlayerNames = GPOp.AskForName_And_ReturnListofNames();
                        
                        Console.WriteLine("Hello");
                        gameplay.SetPlayer1Names(PlayerNames);
                        gameplay.SetPlayer2Names();
                        //Make the player1 choice
                        gameplay.SetPlayer1Choice();
                        break;
                    }
                }else if((answer.Trim().ToUpper() == "N")||(answer.Trim().ToUpper() == "NO") || (answer.Trim().ToUpper() == "NAH")){
                    Console.WriteLine($"\n\nYou really chose {answer.Trim()}?\n\n\t\tBE GONE WITH Y0O0O0OUU!!!!!\n");
                    gameOVER = true;

                }else{
                    Console.WriteLine($"\n\nYour aswer {answer.Trim()} Must be a YES or NO!!\n\tTRY AGAIN!!\n");
                    continue;
                }
                
                Console.WriteLine("\n\n\t\tEND OF GAME");
                gameOVER = true;
            }while(gameOVER == false);
        }
    }
}
