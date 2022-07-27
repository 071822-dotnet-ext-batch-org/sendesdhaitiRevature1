using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame2
{
    public class Player
    {
        public string Username {get; set;}
        public DateTime DOB {get;set;}

        //The Player Constructors
        public Player(){
            
        }//End of Player Construtor Scope

        public Player(string username){
            this.Username = username;
        }//End of Player Construtor Scope



        //private int wins;
        //private int loses;
    }
}