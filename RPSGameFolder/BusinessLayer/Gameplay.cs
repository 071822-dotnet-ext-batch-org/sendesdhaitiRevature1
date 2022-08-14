using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLayer;
using RepoLayer;

namespace BusinessLayer
{
    public class Gameplay : Game
    {
        //This class represents the Gameplay model class
        private Guid GamePlayID {get;set;} = new Guid();
        private readonly List<Player> AllPlayers = new List<Player>();//List of all currently playing players
        private readonly List<Game> AllGames = new List<Game>();//List of all games
        private  List<Round> RoundsList {get;set;}
        private Game currentGame;
        private Round currentRound {get;set;}
        //private Gamepiece currentGamePiece;
        private string username {get;set;}
        private string fname {get;set;}
        private string lname {get;set;}
        private int player1Wins = 0;
        private int player2Wins = 0;
        public List<Round> ListOfRounds{
            get{
                return RoundsList;
            }
            set{
                this.RoundsList.Add(this.currentRound);

            }
        }


        //Create the game
        public void NewGame(){
            Console.WriteLine("\tThis is the start of the game");
            this.currentGame = new Game();
        }

        //Method to set and save user names 
        /// <summary>
        /// This Method is here to set the current player's username, 
        ///     first name, and last name
        /// 
        /// It returns a true of false 
        ///     True: the name entered was not in the DB 
        ///     and thus is successfully saved to the list once the game ends along
        ///     with their game data
        /// 
        ///     False: the name entered was already in the DB so they wont be added to the list
        ///     at the end of the game. Only the data of the already existing user will be updated
        /// </summary>
        /// <param name="playernames"></param>
        /// <returns></returns>
        
        public Player? SetPlayer1Names(List<string> playernames){
            //GamePlayOperations.AskForName_And_ReturnListofNames();
            string fname;
            string lname;
            string username;
            //We need to check if the 


            if(playernames.Count > 2){
                // foreach(string s in playernames) Console.WriteLine(s);
                fname = playernames[0];
                lname = playernames[1];
                username = playernames[2];
                this.currentGame.Player1 = new Player(username,fname,lname);
                Console.WriteLine($"\n\t\t\t{this.currentGame.Player1.Username} is now your username ok?.\n\t\t\t\t{this.currentGame.Player1.Fname} {this.currentGame.Player1.Lname}.");
                Console.WriteLine($"\n\t\t\t\t{this.currentGame.Player1.Fname} {this.currentGame.Player1.Lname}, this mission is essential.\n\n\t\t\t\tIf you can get there in the best of 3 rounds,\n\t\t\t\t\tyou win.......FREE BEER AND P**** FOR EVERYBODY!!!");
                Console.WriteLine($"\n\t\t\tIt will be added to our system after you complete the game.");
                return this.currentGame.Player1;
            }else if(playernames.Count == 2){
                fname = playernames[0];
                lname = playernames[1];
                username = "UAUsername";
                this.currentGame.Player1 = new Player(username,fname,lname);
                Console.WriteLine($"\n\t\t\t{this.currentGame.Player1.Fname} {this.currentGame.Player1.Lname}, your new username is now {this.currentGame.Player1.Username}.");
                Console.WriteLine($"\n\t\t\tIt will be added to our system after you complete the game.");
                return this.currentGame.Player1;
            }else if(playernames.Count == 1){
                fname = "Default";
                lname = "Player";
                username = playernames[0];
                this.currentGame.Player1 = new Player(username,fname,lname);
                Console.WriteLine($"{this.currentGame.Player1}");
                Console.WriteLine($"\n\t\t\t{this.currentGame.Player1.Fname} {this.currentGame.Player1.Lname}, your new username is now {this.currentGame.Player1.Username}.");
                Console.WriteLine($"\n\t\t\tIt will be added to our system after you complete the game.");
                return this.currentGame.Player1;
            }else{
                fname = "Default";
                lname = "Player";
                username = "Bot1";
                this.currentGame.Player1 = new Player(username,fname,lname);
                Console.WriteLine($"\n\t\t\t{this.currentGame.Player1.Fname} {this.currentGame.Player1.Lname}, your new username is now {this.currentGame.Player1.Username}.");
                Console.WriteLine($"\n\t\t\tThis default account wont be added to the DB.");
                return this.currentGame.Player1;
            }

        }//End Set Player Name

        public Player? SetPlayer2Names(){
            List<string> CompName = GamePlayOperations.ChooseComputerName_To_Pass_Automatic();
            this.currentGame.Player2 = new Player(CompName[0], CompName[1], CompName[2]);
            Console.WriteLine($"\n\t\tThe mutant '{this.currentGame.Player2.Username}' named {this.currentGame.Player2.Fname} {this.currentGame.Player2.Lname} is about to make a move.\n\n\t\tGET READY!!");
            return this.currentGame.Player2;
        }

        public void RunRound(){
            
            //Console.WriteLine();
        RuntheRound:
            Console.WriteLine($"\n\t\t\t\t\tRound {this.currentGame.Player1.RoundPlayed}...FIGHT!!");
            
            if((this.currentGame.Player1.TotalRoundsPlayed.Count == 1) && (this.currentGame.Player1.TotalRoundsPlayed.Count%3 ==0)){
                //Run the game as normal until round 3
                this.ReRun();
                Console.WriteLine($"\n\n\t\t3 Rounds havent been played yet so this is still a game");
            }else if(this.currentGame.Player1.TotalRoundsPlayed.Count%3 == 0){
                //Run the game as normal until round 3
                this.ReRun();
                Console.WriteLine($"\n\n\t\t3 Rounds played");
                Console.WriteLine($"\n\n\t\tThis game winner was {this.currentGame.GameWinner}");
                Console.WriteLine($"\n\n\t\tWould you like to explore some other towns again {this.currentGame.Player1.Username}?\n\n\t\t|Choose 1 for YES\n\t\t|Choose 2 for NO");
                if(Convert.ToInt16(IfStatements.Verify_String_Answer_FOR_INT(1,1)) == 1){
                    //yes
                    //add one more to round and restart if loop
                    this.currentGame.Player1.RoundPlayed += 1;
                    goto RuntheRound;
                }else if(Convert.ToInt16(IfStatements.Verify_String_Answer_FOR_INT(1,1)) == 0){
                    //no
                    Console.WriteLine($"\n\n\t\tWe'll see you next time {this.currentGame.Player1.Username}.");
                    
                }else{
                    //wrong answer
                    Console.WriteLine($"\n\n\t\twrong answer {this.currentGame.Player1.Username}?");
                    goto RuntheRound;
                }
            }else{
            }
            // foreach (int piece in Gamepiece.Paper){
            //     Console.WriteLine(piece);
            //     // if(choice == 1){

            //     // }
            // }
            // this.currentGame.Player1.PlayerChoice = new Gamepiece().Values.ValueList;


            // this.currentGame.Player1.PlayerChoice = choice;
            // Console.WriteLine($"Your choice was {this.currentGame.Player1.PlayerChoice}");
            // // return this.currentGame.Player1.PlayerChoice;
        }
        /// <summary>
        /// THis is a method to run the round 
        /// It saves the stats of the last run round and gives the result
        /// </summary>
        /// <param name="currentRound"></param>
        private void ReRun()
        {
            dynamic currentGamePiece1 = 0;
            int currentRound = this.currentGame.Player1.RoundPlayed+1;
        RestartP1Choice:
            currentGamePiece1 = GamePlayOperations.SavePlayerChoice();
            if (currentGamePiece1 == 0)
            {
                goto RestartP1Choice;
            }
            //Add the current round number to the list of rounds played for each player
            this.currentGame.Player1.TotalRoundsPlayed.Add(currentRound);
            this.currentGame.Player2.TotalRoundsPlayed.Add(currentRound);

            this.currentGame.Player1.PlayerChoice = currentGamePiece1;
            Console.WriteLine($"\n\t\tYour choice was a {this.currentGame.Player1.PlayerChoice} power-level move!!");
            KeyValuePair<string, double> currentOppGamePiece = GamePlayOperations.SavePlayer2Choice();
            this.currentGame.Player2.PlayerChoice = currentOppGamePiece;
            int result = GamePlayOperations.CalcRound(this.currentGame.Player2.PlayerChoice, this.currentGame.Player1.PlayerChoice);
            if (result == 1)
            {
                //Player1 won this round
                this.currentGame.Player1.RoundWins++;
                this.currentGame.Player2.RoundLosses++;
                this.currentGame.Player1.TotalRoundsPlayed.Add(this.currentGame.Player1.RoundPlayed);
                this.currentGame.Player2.TotalRoundsPlayed.Add(this.currentGame.Player2.RoundPlayed);
                if (this.currentGame.Player1.TotalRoundsPlayed.Count > 1)
                {
                    double RoundwinlossRatio = (this.currentGame.Player1.RoundWins - this.currentGame.Player1.RoundLosses) / this.currentGame.Player1.TotalRoundsPlayed.Count;
                }
                else
                {
                    double RoundwinlossRatioP1 = (this.currentGame.Player1.RoundWins - this.currentGame.Player1.RoundLosses) / this.currentGame.Player1.TotalRoundsPlayed.Count;
                }
                Console.WriteLine($"\t\t\t\t{this.currentGame.Player1.Username}'s W/L Ratio so far is [{this.currentGame.Player1.RoundWins}] | [{this.currentGame.Player1.RoundLosses}]");

            }
            else if (result == 0)
            {
                //Player1 lost this round
                this.currentGame.Player2.RoundWins++;
                this.currentGame.Player2.TotalRoundsPlayed.Add(this.currentGame.Player2.RoundPlayed);
                if (this.currentGame.Player2.TotalRoundsPlayed.Count > 1)
                {
                    double RoundwinlossRatio = (this.currentGame.Player2.RoundWins - this.currentGame.Player2.RoundLosses) / this.currentGame.Player2.TotalRoundsPlayed.Count;
                }
                else
                {
                    double RoundwinlossRatioP2 = (this.currentGame.Player2.RoundWins - this.currentGame.Player2.RoundLosses) / this.currentGame.Player2.TotalRoundsPlayed.Count;
                }
                Console.WriteLine($"\t\t\t\t{this.currentGame.Player2.Username}'s W/L Ratio so far is [{this.currentGame.Player2.RoundWins}] | [{this.currentGame.Player2.RoundLosses}]");
            }
            else if (result == 2)
            {
                this.currentGame.Player1.TiedRounds++;
                this.currentGame.Player2.TiedRounds++;
                this.currentGame.Player1.TotalRoundsPlayed.Add(this.currentGame.Player1.RoundPlayed);
                this.currentGame.Player2.TotalRoundsPlayed.Add(this.currentGame.Player2.RoundPlayed);
                if (this.currentGame.Player1.TotalRoundsPlayed.Count < 1)
                {
                    Console.WriteLine($"\t\t\t\tRound {this.currentGame.Player1.RoundPlayed}'s wins & losses ratio cannot be calculated until you've played a round");
                }
                else if(result == null)
                {
                    double RoundwinlossRatioP1 = (this.currentGame.Player1.RoundWins - this.currentGame.Player1.RoundLosses) / this.currentGame.Player1.TotalRoundsPlayed.Count;
                    double RoundwinlossRatioP2 = (this.currentGame.Player2.RoundWins - this.currentGame.Player2.RoundLosses) / this.currentGame.Player2.TotalRoundsPlayed.Count;
                    Console.WriteLine($"\t\t\t\tRound {this.currentGame.Player1.RoundPlayed}'s wins & losses ratio cannot be calculated until you've played a round");
                }
                Console.WriteLine($"\t\t\t\t{this.currentGame.Player1.Username}'s W/L Ratio so far is [{this.currentGame.Player1.RoundWins}] | [{this.currentGame.Player1.RoundLosses}]");
                Console.WriteLine($"\t\t\t\t{this.currentGame.Player2.Username}'s W/L Ratio so far is [{this.currentGame.Player2.RoundWins}] | [{this.currentGame.Player2.RoundLosses}]");
            }

        }

        /// <summary>
        /// This Method returns the current game's player 1
        /// </summary>
        /// <returns></returns>
        public Player GetPlayer1(){
            return this.currentGame.Player1;
        }
        public Player GetPlayer2(){
            return this.currentGame.Player2;
        }
        // public Player GameWinner(){
        //     if(player1Wins || player2Wins){

        //     }
        // }

        //private
    }
}