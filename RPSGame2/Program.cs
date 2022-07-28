using System;

namespace RPSGame2
{
    class Program
    {
        static void Main(string[] args)
        {
            //What we need to run the game so we create an instance of the gameplay class 
            GamePlay thisGame = new GamePlay();
            Player thisPlayer = new Player();
            string user1 = "";
            int count = 0;
            
            //Start The Game
            thisGame.NewGame();
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");
            Console.WriteLine("\tCreate your username below:");
            try{
                thisPlayer.Username = Console.ReadLine();
                

            }catch (NullReferenceException msg){
                Console.WriteLine($"\tThe string method to set the P1Name was thrown by this message: \n\t'{msg.Message}'.");
            }



            Console.WriteLine($"\tYour new username is:\n\t{thisPlayer.Username}\n\tPress ENTER to begin!\n\n");
            Console.Read();
            while(true){
                //Start of the game loop
                thisGame.NewRound();
                thisGame.SetRound();
                
                Console.WriteLine(thisGame.GetRound());
                //count++;
                int round = thisGame.GetRound();
                Console.WriteLine($"\tCurrent Round: {round}");
                Console.WriteLine($"\tChoose 1 for Rock\n\tChoose 2 for Paper\n\tChoose 3 for Scissors");
                try
                {
                    int choiceAnswer = Int32.Parse(Console.ReadLine());
                    //thisGame.SetGamePiece();
                    //Console.WriteLine(numVal);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                
                // int playerChoice = thisGame.GetGamePieces();
                // Console.WriteLine($"\tYour choice was: {playerChoice}");
                //Make the choice of rock, paper or scissor so that the computer can choose as well

                break;
            }
            
            


            
        }
    }
}

//REMEMBER TO VALIDATE USER INPUT
// try
// {
//     player1Choice = Int32.Parse(player1ChoiceStr);
// }
// catch (OverflowException ex)
// {
//     //this method to write to the console is string interpolation.
//     Console.WriteLine($"The parse method failed because '{ex.Message}'.");

// }
// catch (FormatException ex)
// {
//     Console.WriteLine($"The parse method failed because {ex.Message}");//this method to write to the console is string interpolation.
// }
// catch (ArgumentNullException ex)
// {
//     Console.WriteLine("The parse method failed because {0}", ex.Message);// This is Composite Formatting.
// }