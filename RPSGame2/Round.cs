using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame2
{
    public class Round : GamePlay
    {
        //PRIVATE VALUES
        //private Player roundPlayer = new Player();
        //GamePlay gamePlay;
        private int roundNumber {get;set;}= 1;
        public int RoundNumber {
            get{
                return roundNumber;
            } 
            set{
                roundNumber++;
            }
        }

        //INITIALIZATION OF VALUES

        internal Round(){

        }
        // internal Round(Round round){
        //     for (int i = 0; i < Rounds.Count; i++)
        //     {
        //         this.Rounds[] = round;
                
        //     }
        // }
        // public List<Round> AddCurrentRoundtoList(){
        //     Round round = new Round(RoundNumber);
        //     return this.Rounds.Add(round); 
        //     //I will have the gameplay run here
        //     //GamePlay.RunGamePlay();
        // }


        //GETTERS



        //SETTERS
        

        //Retrieved from the Player class(Each Player inherits a username)
        //public Player user1 {get;set;} = null; 
        //public Player computer {get;set;} = null;




    }
}

