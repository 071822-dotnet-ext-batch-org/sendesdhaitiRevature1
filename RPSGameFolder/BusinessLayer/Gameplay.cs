using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLayer;
using RepoLayer;

namespace BusinessLayer
{
    public class Gameplay : Game
    {
        //This class represents the Gameplay model class
        private Guid GamePlayID {get;set;} = new Guid();
        private readonly List<Player> AllPlayers = new List<Player>();//List of all currently playing players
        private readonly List<Game> AllGames = new List<Game>();//List of all games
        private Game currentGame;
        private Round currentRound;
        private Gamepiece currentGamePiece;
        private string username {get;set;}
        private string fname {get;set;}
        private string lname {get;set;}
        private int player1Wins = 0;
        private int player2Wins = 0;


        //Create the game
        public void NewGame(){
            Console.WriteLine("\tThis is the start of the game");
            this.currentGame = new Game();
        }

        //Method to set and save user names 
        /// <summary>
        /// This Method is here to set the current player's username, 
        ///     first name, and last name
        /// 
        /// It returns a true of false 
        ///     True: the name entered was not in the DB 
        ///     and thus is successfully saved to the list once the game ends along
        ///     with their game data
        /// 
        ///     False: the name entered was already in the DB so they wont be added to the list
        ///     at the end of the game. Only the data of the already existing user will be updated
        /// </summary>
        /// <param name="playernames"></param>
        /// <returns></returns>
        
        public Player? SetPlayer1Names(List<string> playernames){
            //GamePlayOperations.AskForName_And_ReturnListofNames();
            string fname;
            string lname;
            string username;
            //We need to check if the 


            if(playernames.Count > 2){
                // foreach(string s in playernames) Console.WriteLine(s);
                fname = playernames[0];
                lname = playernames[1];
                username = playernames[2];
                this.currentGame.Player1 = new Player(username,fname,lname);
                Console.WriteLine($"\n\t\t\t{this.currentGame.Player1.Username} is now your username {this.currentGame.Player1.Fname} {this.currentGame.Player1.Lname}.");
                Console.WriteLine($"\n\t\t\tIt will be added to our system after you complete the game.");
                return this.currentGame.Player1;
            }else if(playernames.Count == 2){
                fname = playernames[0];
                lname = playernames[1];
                username = "UAUsername";
                this.currentGame.Player1 = new Player(username,fname,lname);
                Console.WriteLine($"\n\t\t\t{this.currentGame.Player1.Fname} {this.currentGame.Player1.Lname}, your new username is now {this.currentGame.Player1.Username}.");
                Console.WriteLine($"\n\t\t\tIt will be added to our system after you complete the game.");
                return this.currentGame.Player1;
            }else if(playernames.Count == 1){
                fname = "Default";
                lname = "Player";
                username = playernames[0];
                this.currentGame.Player1 = new Player(username,fname,lname);
                Console.WriteLine($"{this.currentGame.Player1}");
                Console.WriteLine($"\n\t\t\t{this.currentGame.Player1.Fname} {this.currentGame.Player1.Lname}, your new username is now {this.currentGame.Player1.Username}.");
                Console.WriteLine($"\n\t\t\tIt will be added to our system after you complete the game.");
                return this.currentGame.Player1;
            }else{
                fname = "Default";
                lname = "Player";
                username = "Bot1";
                this.currentGame.Player1 = new Player(username,fname,lname);
                Console.WriteLine($"\n\t\t\t{this.currentGame.Player1.Fname} {this.currentGame.Player1.Lname}, your new username is now {this.currentGame.Player1.Username}.");
                Console.WriteLine($"\n\t\t\tThis default account wont be added to the DB.");
                return this.currentGame.Player1;
            }

        }//End Set Player Name

        public Player? SetPlayer2Names(){
            List<string> CompName = GamePlayOperations.ChooseComputerName_To_Pass_Automatic();
            this.currentGame.Player2 = new Player(CompName[0], CompName[1], CompName[2]);
            Console.WriteLine($"\n\t\tThe mutant '{this.currentGame.Player2.Username}' named {this.currentGame.Player2.Fname} {this.currentGame.Player2.Lname} is about to make a move.\n\n\t\tGET READY!!");
            return this.currentGame.Player2;
        }

        public void SetPlayer1Choice(){
            //currentGamePiece = new Gamepiece();
            dynamic currentGamePiece1 = GamePlayOperations.SavePlayerChoice();

            this.currentGame.Player1.PlayerChoice = currentGamePiece;
            Console.WriteLine($"\n\t\tYour choice was a {this.currentGame.Player1.PlayerChoice}");
            // foreach (int piece in Gamepiece.Paper){
            //     Console.WriteLine(piece);
            //     // if(choice == 1){

            //     // }
            // }
            // this.currentGame.Player1.PlayerChoice = new Gamepiece().Values.ValueList;


            // this.currentGame.Player1.PlayerChoice = choice;
            // Console.WriteLine($"Your choice was {this.currentGame.Player1.PlayerChoice}");
            // // return this.currentGame.Player1.PlayerChoice;
        }
        
        /// <summary>
        /// This Method returns the current game's player 1
        /// </summary>
        /// <returns></returns>
        public Player GetPlayer1(){
            return this.currentGame.Player1;
        }
        public Player GetPlayer2(){
            return this.currentGame.Player2;
        }
        // public Player GameWinner(){
        //     if(player1Wins || player2Wins){

        //     }
        // }

        //private
    }
}