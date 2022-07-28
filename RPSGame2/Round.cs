using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame2
{
    public class Round
    {
        //PRIVATE VALUES
        //private Player roundPlayer = new Player();
        private int roundNumber = 0;
        public int RoundNumber {
            get{
                return this.roundNumber;
            } 
            set{
                this.roundNumber++;
            }
        }

        //INITIALIZATION OF VALUES

        internal Round(){

        }
        internal Round(int round){
            this.roundNumber = round;
        }


        //GETTERS



        //SETTERS
        

        //Retrieved from the Player class(Each Player inherits a username)
        //public Player user1 {get;set;} = null; 
        //public Player computer {get;set;} = null;




    }
}

