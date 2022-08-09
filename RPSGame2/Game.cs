using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame2
{
    public class Game : Player
    {
        //PRIVATE VALUES
        //private Player gamer;

        
        //private List<Round> Rounds {get; set;} = new List<Round>();
        //private List<Player> Players {get; set;} = new List<Player>();
        private Player P1;
        private Player P2;
        public Player Player1{
            get{
                return P1;
            }
            set{
                P1 = value;
            }
        }
        public  Player Player2{
            get{
                return  P2;
            }
            set{
                P2 = value;
            }
        }
        //private List<Game> Games {get; set;} = new List<Game>();



        

        //INITIALIZATION OF Game
        internal Game(){
        }

        //Create new game
        // public static void NewGame(){
        //     Console.WriteLine("\n\n\tWelcome to ROOOCK, PAAAPER, SCIIISSORS!!!\n\n\t\tPress Enter to Begin.\n\t");
        //     Game theGame = new Game();
        // }

        
    }
}