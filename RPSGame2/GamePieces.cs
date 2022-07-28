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
        private int choice {get;set;}
        
        public enum Pieces {
            ROCK = 1,
            PAPER = 2,
            SCISSORS = 3,
        };

        public int Choice{
            get{
                return choice;
            }
            set{
                if(value == 1 || value == 2 || value == 3){
                    choice = value;
                }
            }
        }

        public GamePieces(){

        }

        public GamePieces(int pieces){
            this.Choice = pieces;
        }

        internal int GetChoice(){
            return this.Choice;
        }
        // internal int GameChoice(int choice){
        //     //create a new player piece
            
        //     //
        //     // foreach( var i in Pieces){
        //     //     //if (choice )
        //     // }
            
        // }

        public void SetPiece(int choice){
            this.Choice = choice;
        }

        public int GetPiece(int choice){
            return this.Choice;
        }
    }
}