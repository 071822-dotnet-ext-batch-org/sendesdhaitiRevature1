using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame2
{
    internal class Round
    {
        //List of rounds
        private Player roundPlayer = new Player();
        public int RoundNumber {get; set;}

        internal Round(){

        }
        

        //Retrieved from the Player class(Each Player inherits a username)
        //public Player user1 {get;set;} = null; 
        //public Player computer {get;set;} = null;




    }
}

