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
        private string computer;
        public string Computer{
            get{
                return computer;
            }
            set{
                computer = "Computer";
            }
        }

        private int choice;
        public int Choice{
            get{
                return choice;
            }
            set{
                foreach(int i in Enum.GetValues(typeof(GamePieces.Pieces)) ){
                    if(value == i){
                        choice = value;
                    }
                }
                
            }
        }
        private int win = 0;
        public DateTime DOB {get;set;}

        //INITIALIZATION OF VALUES
        public Player(){
            
        }//End of Player Construtor Scope

        public Player(string username){//A Player will be able to create and have a username
            Username = username;
        }//End of Player Construtor Scope

        //GETTERS
            //For ENCAPSULATION
            //This is to make sure that you cannot change the value outside of the class
            //This makes managing code easier since changes can be made in one place 
                //and reflected everywhere else
        public string getUsername(){
            return this.Username;
        }


        //SETTERS
        public void setUsername(string name){
            this.Username = name;
        }




        //private int wins;
        //private int loses;
    }
}