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
        private int win = 0;
        public DateTime DATECREATED {get;set;} = DateTime.Now;

        //INITIALIZATION OF VALUES
        public Player(){
            
        }//End of Player Construtor Scope

        public Player(string username, DateTime created){//A Player will be able to create and have a username
            Username = username;
            DATECREATED = created;
        }//End of Player Construtor Scope

        public Player(string computerName){//A Computer will be able to have a username
            ComputerName = computerName;
        }//End of Player Construtor Scope

        //GETTERS
            //For ENCAPSULATION
            //This is to make sure that you cannot change the value outside of the class
            //This makes managing code easier since changes can be made in one place 
                //and reflected everywhere else
        // public string getUsername(){
        //     return this.Username;
        // }


        // //SETTERS
        // public void setUsername(string name){
        //     this.Username = name;
        // }




        //private int wins;
        //private int loses;
    }
}