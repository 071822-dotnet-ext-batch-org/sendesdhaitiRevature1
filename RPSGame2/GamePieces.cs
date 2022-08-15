using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPSGame2
{
    public class GamePieces: Round
    {
        private string playerStringChoice {get;set;}
        private int playerChoice {get;set;}
        private int computerChoice {get; set;}
        private string computerStringChoice {get;set;}
        //private List<GamePieces> ListOfPieces {get; set;}
        private Random Rand = new Random();
        internal enum Pieces {
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

        public string PlayerStringChoice{
            get{
                return playerStringChoice;
            }
            set{
                playerStringChoice = value;
            }
        }

        public int ComputerChoice{
            get{
                return computerChoice;
            }
            set{
                //value
                computerChoice = value;
                

            }
        }
        public string ComputerStringChoice{
            get{
                return computerStringChoice;
            }
            set{
                computerStringChoice = value;
            }
        }

        public GamePieces(){

        }

        // public GamePieces(int pieces){
        //     this.PlayerChoice = pieces;
        // }

        public void SetPlayerChoice(int choiceINT){
            //int choiceINT = Convert.ToInt32(choice);
            //GamePieces gamePiece = new GamePieces();
            if( choiceINT == 1){
                PlayerChoice = choiceINT;
                PlayerStringChoice = "Rock";

            }else if( choiceINT == 2){
                PlayerChoice = choiceINT;
                PlayerStringChoice = "Paper";

            }else if( choiceINT == 3){
                PlayerChoice = choiceINT;
                PlayerStringChoice = "Scissor";

            }else{
                Console.WriteLine("Your choice was not from 1-3");
                //break;
            }
        }

        public void SetPlayer2Choice(){
            //int choiceINT = Convert.ToInt32(choice);
            //GamePieces gamePiece = new GamePieces();
            Random Rand = new Random();
            int value = Rand.Next(0,3);
            if((value >= 0) && (value < 1)){
                ComputerChoice = 1;
            }else if((value >= 1) && (value < 2)){
                ComputerChoice = 2;
            }else if((value >= 2) && (value < 3)){
                ComputerChoice = 3;
            }

            if(ComputerChoice == 1){
                ComputerStringChoice = "Rock";
                Console.WriteLine($"Your opponent's choice was {ComputerChoice} or {ComputerStringChoice}");
            }else if( ComputerChoice == 2){
                ComputerStringChoice = "Paper";
                Console.WriteLine($"Your opponent's choice was {ComputerChoice} or {ComputerStringChoice}");
            }else if( ComputerChoice == 3){
                ComputerStringChoice = "Scissor";
                Console.WriteLine($"Your opponent's choice was {ComputerChoice} or {ComputerStringChoice}");
            }
        }

        //THis method will be to calculate the result of Player and Opponent's choice
        public void CalcRound(){
            if(PlayerChoice > ComputerChoice){
                Console.WriteLine($"\n\tRound {RoundNumber} Results:\n\t\tPlayer 1's choice of {PlayerChoice} '{PlayerStringChoice}'\n\t\tbeat the computer's choice of {ComputerChoice} or '{ComputerStringChoice}'");
                
            }else if(PlayerChoice == ComputerChoice){
                Console.WriteLine($"\n\tRound {RoundNumber} Results:\n\t\tPlayer 1's choice of {PlayerChoice} '{PlayerStringChoice}'\n\t\tied with the computer's choice of {ComputerChoice} or '{ComputerStringChoice}'");
            }else if(PlayerChoice < ComputerChoice){
                Console.WriteLine($"\n\tRound {RoundNumber} Results:\n\t\tPPlayer 1's choice of {PlayerChoice} '{PlayerStringChoice}'\n\t\tlost to the computer's choice of {ComputerChoice} or '{ComputerStringChoice}'");
            }
                
            //Console.WriteLine("End of the Round Calc");
        }
    }
}