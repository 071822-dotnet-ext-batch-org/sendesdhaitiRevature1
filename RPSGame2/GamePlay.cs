using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame2
{
    internal class GamePlay
    {
        //Add the data thats is obtained during 
        private Game currentGame;
        //private Game.Gamer1
        internal void NewGame(){
            this.currentGame = new Game();
            Console.WriteLine("Game Starts");
        }
        
        internal void P1Name(string playerName){
            this.currentGame.Gamer1.Username = playerName;
        }

        internal Player GetPlayerName(){
            return this.currentGame.Gamer1;
        }
    }
}