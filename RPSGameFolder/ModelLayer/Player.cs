using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Player
    {
        //This class represents the player model class
        public Guid PlayerID = Guid.NewGuid();
        private string username {get;set;} = "DefaultUser";
        private string fname {get;set;}  = "Hann";
        private string lname {get;set;}  = "Cock";
        public DateTime DATECREATED {get;set;}
        private int wins {get;set;}

        private int losses {get;set;}
        private Gamepiece playerChoice {get;set;}

        //Give other class access to values
        public string Username{
            get{
                return this.username;
            }
            set{
                this.username = value;
            }
        }

        public string Fname{
            get{
                return this.fname;
            }
            set{
                this.fname = value;
            }
        }

        public string Lname{
            get{
                return this.lname;
            }
            set{
                this.lname = value;
            }
        }
        public int Wins{
            get{
                return this.wins;
            }
            set{
                this.wins = value++;
            }
        }

        public int Losses{
            get{
                return this.losses;
            }
            set{
                this.losses = value++;
            }
        }
        public Gamepiece PlayerChoice{
            get{
                return this.playerChoice;
            }
            set{
                this.playerChoice = value;
            }
        }

        //Constructors
        public Player(){}
        public Player(string username, string fname, string lname){
            //The robot is usually the player created with only a username
            this.Username = username;
            this.Fname = fname;
            this.Lname = lname;
            this.DATECREATED = DateTime.Now;

        }
    }
}