using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame2
{
    internal class Game
    {
        //Retrieved from the Player class(Each Player inherits a username) or (username and win)
        public Player Gamer {get; set;} = new Player();
        public Player Computer {get; set;} = new Player("Computer");

        internal Game(){

        }
        // internal Game(){
        //     //
        // }
    }
}