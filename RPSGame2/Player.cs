using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame2
{
    public class Player 
    {

        //PRIVATE VALUES
        //private int pieces = GamePieces.Pieces.ROCK;
        private Guid PlayerID {get;set;}
        private string username;
        public string Username {
            get{
                return username;
            } 
            set{
                if(value.Length <= 15){
                    username = value;
                }else{
                    username = "Default Player Name";
                }
            }
        }
        private string computerName;
        public string ComputerName{
            get{
                return computerName;
            }
            set{
                computerName = "Robot";
            }
        }

        // 
        private int wins = 0;
        private int loses = 0;
        public int Wins{
            get{
                return wins;
            }
            set{
                wins = wins++;
            }
        }

        public int Loses{
            get{
                return loses;
            }
            set{
                loses = loses++;
            }
        }
        public DateTime DATECREATED {get;set;} = DateTime.Now;

        //INITIALIZATION OF VALUES
        public Player(){
            
        }//End of Player Construtor Scope

        public Player(string username){//A Player will be able to create and have a username
            Username = username;
            DATECREATED = DateTime.Now;
        }//End of Player Construtor Scope
    }
}