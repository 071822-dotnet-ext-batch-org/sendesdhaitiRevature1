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
        private double winsRound {get;set;} = 0;

        private double lossesRound {get;set;} = 0;
        private double gameWins {get;set;} = 0;

        private double gameLosses {get;set;} = 0;
        private dynamic playerChoice {get;set;}
        

        private int roundplayed {get;set;}
        private List<int> totalroundsplayed {get;set;}

        private double totalGamesPlayed {get; set;} = 0;
        private double roundTies {get; set;}
        public double TotalGamesPlayed{
            get{
                return this.totalGamesPlayed;
            }
            set{
                this.totalGamesPlayed++;
            }
        }

        public double TiedRounds{
            get{
                return this.roundTies;
            }
            set{
                this.roundTies++;
            }
        }

        public List<int> TotalRoundsPlayed{
            get{
                return this.totalroundsplayed;
            }
            set{
                this.totalroundsplayed= new List<int>();
            }
        }
        public int RoundPlayed{
            get{
                return this.roundplayed;
            }
            set{
                this.roundplayed += 1;
            }
        }
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
        public double RoundWins{
            get{
                return this.winsRound;
            }
            set{
                this.winsRound = value;
            }
        }

        public double RoundLosses{
            get{
                return this.lossesRound;
            }
            set{
                this.lossesRound = value;
            }
        }

        public double GameWins{
            get{
                return this.gameWins;
            }
            set{
                this.gameWins++;
            }
        }

        public double GameLosses{
            get{
                return this.gameLosses;
            }
            set{
                this.gameLosses++;
            }
        }
        public dynamic PlayerChoice{
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
            this.PlayerChoice = 0.0;
            this.GameWins = 0.0;
            this.GameLosses = 0.0;
            this.RoundWins = 0.0;
            this.RoundLosses = 0.0;
            this.TiedRounds = 0.0;
            this.totalGamesPlayed = 0.0;
            this.RoundPlayed = 0;
            this.TotalRoundsPlayed = null;
        }
    }
}