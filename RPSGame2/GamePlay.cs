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
        Random Rand = new Random();

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
        
        //Calculate Computer choice with random
        


        //GETTERS
        


        //SETTERS
        
    }
}