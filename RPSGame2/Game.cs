using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame2
{
    public class Game
    {
        //PRIVATE VALUES
        private Player Gamer {get; set;}
        private List<Round> Rounds {get; set;} = new List<Round>();
        private Player computer = new Player("Computer");
        public Player Computer{
            get{
                return computer;
            }
            set{
                computer.Username = "Computer";
            }
        }

        //INITIALIZATION OF VALUES
        internal Game(){
            //this.Gamer.Username;


        }

        // internal string newGamer( name){
            
        // }
        // internal Game(){
        //     //
        // }
    }
}