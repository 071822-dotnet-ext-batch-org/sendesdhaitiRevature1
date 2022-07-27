using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame2
{
    public class GamePlay
    {
        //Add the data thats is obtained during 
        private Game CurrentGame;
        internal Round CurrentRound;

        private bool gameOn = true;
        //List of games played

        //private Game.Gamer1
        internal void NewGame(){
            this.CurrentGame = new Game();
            Console.WriteLine("Game Starts");
        }

        internal void P1Name(){

        }
        
        internal string P1Name(string playerName){
            //playerName = this.currentGame.Gamer1.Username;
            if (this.CurrentGame.Gamer.Username == null){
                this.CurrentGame.Gamer.Username = playerName; //= playerName;
            }
            return this.CurrentGame.Gamer.Username;
        }

        internal Player GetPlayerName(){
            return this.CurrentGame.Gamer;
        }
        internal void NewRound(){
            this.CurrentRound = new Round();
            //this.CurrentRound.RoundNumber = roundNum;
            //return this.CurrentRound.RoundNumber;
        }

        internal int GetRound(int roundNum){
            //this.CurrentRound = new Round();
            this.CurrentRound.RoundNumber = roundNum;
            return this.CurrentRound.RoundNumber;
        }
    }
}