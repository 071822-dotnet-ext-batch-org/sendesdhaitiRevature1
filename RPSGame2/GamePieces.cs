using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame2
{
    public class GamePieces
    {

        //private Round roundPieces;// = new Round();
        //internal Player PlayerPiece;
        //Game game;
        private int playerChoice {get;set;}
        private int computerChoice {get; set;}
        private List<GamePieces> ListOfPieces {get; set;}
        private Random Rand = new Random();
        // int RandPiece = RuntimeTypeHandle
        
        
        public enum Pieces {
            ROCK = 1,
            PAPER = 2,
            SCISSORS = 3,
        };

        public int PlayerChoice{
            get{
                return playerChoice;
            }
            set{
                playerChoice = value;
            }
        }

        public int ComputerChoice{
            get{
                return computerChoice;
            }
            set{
                //value
                value = Rand.Next(0,3);
                if(value >= 0 && value < 1){
                    computerChoice = 1;
                }else if(value >= 1 && value < 2){
                    computerChoice = 2;
                }else if(value >= 2 && value < 3){
                    computerChoice = 3;
                }else{
                    computerChoice = value;
                }
                

            }
        }

        public GamePieces(){

        }

        public GamePieces(int pieces){
            this.PlayerChoice = pieces;
        }

        // internal int GetChoice(){
        //     return this.Choice;
        // }
        // internal int GameChoice(int choice){
        //     //create a new player piece
            
        //     //
        //     // foreach( var i in Pieces){
        //     //     //if (choice )
        //     // }
            
        // }

        
    }
}