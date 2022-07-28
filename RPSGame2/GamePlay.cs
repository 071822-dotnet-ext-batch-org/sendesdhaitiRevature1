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
        private Game CurrentGame;
        internal Round CurrentRound;
        public Player PlayersGame;

        internal GamePieces GamePieces;


        private bool gameOn = true;
        //List of games played
        //List    
        //List of rounds
        //List of Players


        //INITIALIZATION OF VALUES
        public void NewGame(){
            this.CurrentGame = new Game();
            //Console.WriteLine("Game Starts");
        }
        public static string CreatePlayer(string name){
            Player PlayersGame = new Player(name);
            return PlayersGame.Username;
        }


        //GETTERS
        internal string GetP1Name(){
            return this.PlayersGame.Username;
        }

        internal int GetGamePieces(){
            return this.GamePieces.Choice;
        }

        // internal Player GetPlayer(){
        //     return this.CurrentGame.Gamer;
        // }
        // internal Player GetComputerName(){
        //     return this.CurrentGame.Computer;
        // }
        internal int GetRound(){
            //this.CurrentRound = new Round();
            //this.CurrentRound.RoundNumber;
            //Round CurrentRound = new Round();
            return this.CurrentRound.RoundNumber;
        }


        //SETTERS
        internal void SetP1Name(string playerName){
            //playerName = this.currentGame.Gamer1.Username;
            this.PlayersGame.Username = playerName;
        }

        
        // internal string SetGamePieces(){

        //     this.GamePieces.Choice = choice;
        //     // this.GamePieces.Choice;
        // }

        
        internal void NewRound(){
            this.CurrentRound = new Round();
            this.CurrentRound.RoundNumber++;
            //this.CurrentRound.RoundNumber++;
            //this.CurrentRound++;
            //this.CurrentRound.RoundNumber = roundNum;
            //return this.CurrentRound.RoundNumber;
        }


        internal void SetRound(){
            //create a new player piece
            //Round CurrentRound = new Round();

            this.CurrentRound.RoundNumber++;
            //Console.ReadLine(this.gamePieces.Choice.ToString());
            //return ;
            //
            // foreach( var i in Pieces){
            //     //if (choice )
            // }
            
        }
    }
}