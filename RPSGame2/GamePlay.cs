using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame2
{
    public class GamePlay : Game
    {
        //PRIVATE VALUES or the data that is obtained during gameplay
        Game currentGame;
        private Guid GameID {get;set;}
        public List<Round> Rounds {get;set;} = new List<Round>();


        //INITIALIZATION OF GAME
        public GamePlay(){}
        
        public static void StartGame(){
            
            
        }
        public async void NewPlayers(){
            Console.WriteLine("\n\n\tWhat is your new username Player 1?\n\nENTER ANSWER BELOW\n\t");
            bool flag = false;
            List<string> RobotNames = new List<string>(){"Angela", "Dave", "Roboto", "Alexa", "Siri", "GigaSouraus Rex"};
            Random Rand = new Random();
            do{
                string username = Console.ReadLine();
                if(username.Length < 3){
                    Console.WriteLine($"\n\n\t{username} is too short of a name.\n\nTRY ANOTHER NAME");
                }else if(username.Length > 15){
                    Console.WriteLine($"\n\n\t{username} is too long of a name.\n\nTRY ANOTHER NAME");
                }else if(username.Contains("1")){
                    Console.WriteLine($"\n\n\t{username} cannot have a 1 in it.\n\nTRY ANOTHER NAME");
                }else{
                    //Create Player 1
                    this.currentGame.Player1 = new Player(username.Trim());
                    
                    int randNum = Rand.Next(0,6);
                    //Player 2 gets created only after Player 1 is created
                    if((randNum >= 0) && (randNum < 1)){
                        this.currentGame.Player2 = new Player(RobotNames[0]);
                        Console.WriteLine($"\n\t\tPlayer 1 is: {this.currentGame.Player1.Username}\n\t\tPlayer 2 is: {this.currentGame.Player2.Username}\n");
                        flag = true;
                    }else if((randNum >= 1) && (randNum < 2)){
                        this.currentGame.Player2 = new Player(RobotNames[1]);
                        Console.WriteLine($"\n\t\tPlayer 1 is: {this.currentGame.Player1.Username}\n\t\tPlayer 2 is: {this.currentGame.Player2.Username}\n");
                        flag = true;
                    }else if((randNum >= 2) && (randNum < 3)){
                        this.currentGame.Player2 = new Player(RobotNames[2]);
                        Console.WriteLine($"\n\t\tPlayer 1 is: {this.currentGame.Player1.Username}\n\t\tPlayer 2 is: {this.currentGame.Player2.Username}\n");
                        flag = true;
                    }else if((randNum >= 3) && (randNum < 4)){
                        this.currentGame.Player2 = new Player(RobotNames[3]);
                        Console.WriteLine($"\n\t\tPlayer 1 is: {this.currentGame.Player1.Username}\n\t\tPlayer 2 is: {this.currentGame.Player2.Username}\n");
                        flag = true;
                    }else if((randNum >= 4) && (randNum < 5)){
                        this.currentGame.Player2 = new Player(RobotNames[4]);
                        Console.WriteLine($"\n\t\tPlayer 1 is: {this.currentGame.Player1.Username}\n\t\tPlayer 2 is: {this.currentGame.Player2.Username}\n");
                        flag = true;
                    }else if((randNum >= 5) && (randNum < 6)){
                        this.currentGame.Player2 = new Player(RobotNames[5]);
                        Console.WriteLine($"\n\t\tPlayer 1 is: {this.currentGame.Player1.Username}\n\t\tPlayer 2 is: {this.currentGame.Player2.Username}\n");
                        flag = true;
                    }
                }
            }while(flag == false);
        }

        public void RunGamePlay(){
            NewPlayers();

            bool end = false;
            do{
                bool playAgain = false;
                do{
                    Round round = new Round();
                    Console.WriteLine($"\n\t\tRound {round.RoundNumber}...FIGHT!!") ; 
                    //Get the user's choice
                    Console.WriteLine($"\n\t\tTo make a move:\n\t\t |Choose 1 for Rock\n\t\t |Choose 2 for Paper\n\t\t |Choose 3 for Scissors");
                    int answer = 0;
                    string stringAnswer = Console.ReadLine();
                    try{
                        answer = Convert.ToInt32(stringAnswer);
                    }catch (FormatException msg){
                        Console.WriteLine($"\n\t\tYour choice '{stringAnswer}' can ONLY contain numbers.\n\n\t\tIt threw the following error:\n\t\t{msg}");
                    }
                    if((answer == 1) || (answer == 2) ||(answer == 3)){
                        GamePieces gamePiece = new GamePieces();
                        gamePiece.SetPlayerChoice(answer);
                        Console.WriteLine($"\n\t\tYour choice was {answer} or {gamePiece.PlayerChoice}");

                        //Get the computer's choice
                        //GamePieces computerGamePiece = new GamePieces();
                        gamePiece.SetPlayer2Choice();

                        //Get the results
                        gamePiece.CalcRound();

                        

                    }else{
                        Console.WriteLine($"\n\tYour choice was {answer} and could not be recoded.\n\t\tChoice MUST be 1-3");
                    }
                }while(playAgain == false);

            }while(end == false);
        }

        
    }
}