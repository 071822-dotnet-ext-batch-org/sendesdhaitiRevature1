using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame2
{
    public class GamePlay
    {
        //PRIVATE VALUES or the data that is obtained during gameplay
        private string GamerName {get;set;}
        internal Game CurrentGame;
        internal Round CurrentRound;
        internal Player CurrentPlayer;
        
        Random Rand = new Random();

        internal GamePieces GamePieces;


        private bool gameOn = true;
        //List of games played
        //List    
        //List of rounds
        //List of Players


        //INITIALIZATION OF GAME
        public void NewGame(){
            this.CurrentGame = new Game();
            //Console.WriteLine("Game Starts");
        }

        //INITIALIZATION OF PLAYER
        public void NewPlayer(){
            Console.WriteLine("\tCreate your username below:");
            this.CurrentPlayer = new Player(Console.ReadLine(),DateTime.Now);
            //CurrentPlayer.Username = ;

        }

        public void NewRobot(){
            this.CurrentPlayer = new Player("Robot");
        }

        public string GetPlayerUsername(){
            //Player CurrentPlayer = new Player();
            return this.CurrentPlayer.Username;
        }

        public string GetRobotName(){
            //Player CurrentPlayer = new Player();
            return this.CurrentPlayer.ComputerName;
        }

        public void SetRobotChoice(){
            this.GamePieces = new GamePieces();
            this.GamePieces.ComputerChoice = GamePieces.ComputerChoice;
        }
        public int GetRobotChoice(){
            return this.GamePieces.ComputerChoice;
        }

        public void SetPlayerChoice(){
            int choice = 0;
            try{
                choice = Convert.ToInt32(Console.ReadLine());
                
            }
            catch (FormatException msg){
                Console.WriteLine($"\tThe Message: {msg.Message},\n\twas caused by the following input '{choice}'");
            }
            this.GamePieces = new GamePieces();
            this.GamePieces.PlayerChoice = choice;
            
        }
        public int GetPlayerChoice(){
            return this.GamePieces.PlayerChoice;
        }




        //INITIALIZATION OF ROUND


        
        
        //Calculate Computer choice with random
        


        //GETTERS
        


        //SETTERS
        
    }
}