using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame2
{
    public class Game
    {
        //Retrieved from the Player class(Each Player inherits a username)
        public Player Gamer1 {get; set;} = new Player();
        public Player Gamer2 {get; set;} = new Player("Computer");
    }
}