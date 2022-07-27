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
        //private Game.Gamer1
        internal void NewGame(){
            this.CurrentGame = new Game();
            Console.WriteLine("Game Starts");
        }

        internal void P1Name(){

        }
        
        internal string P1Name(string playerName){
            //playerName = this.currentGame.Gamer1.Username;
            if (this.CurrentGame.Gamer1.Username == null){
                this.CurrentGame.Gamer1.Username = playerName; //= playerName;
            }
            return this.CurrentGame.Gamer1.Username;
        }

        internal Player GetPlayerName(){
            return this.CurrentGame.Gamer1;
        }
    }
}