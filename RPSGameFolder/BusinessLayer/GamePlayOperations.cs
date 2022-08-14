using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLayer;

namespace BusinessLayer
{
    public class GamePlayOperations : IGPOps
    {
        public List<string> AskForName_And_ReturnListofNames(){
            List<string> PlayerNameList = new List<string>();
            
            string? Playeranswer1 = IfStatements.Verify_String_Answer("First name");
            string? pA1 =  Playeranswer1;
            PlayerNameList.Add(pA1);
            string? Playeranswer2 = IfStatements.Verify_String_Answer("Last name");
            string? pA2 =  Playeranswer2;
            PlayerNameList.Add(pA2);
            string? Playeranswer3 = IfStatements.Verify_String_Answer("username");
            string? pA3 =  Playeranswer3;
            PlayerNameList.Add(pA3);
            //foreach(string s in PlayerNameList) Console.WriteLine(s);
            return PlayerNameList;


        }
        /// <summary>
        /// This method randomly selects a list of names to pass to the name 
        /// of the computer
        /// </summary>
        /// <returns></returns>
        public static List<string> ChooseComputerName_To_Pass_Automatic(){
            List<string> RobotUserNames = new List<string>(){"Angela", "Dave", "Roboto", "Alexa", "Siri", "GigaSourausRex"};
            List<string> RobotFirstNames = new List<string>(){"John", "Stewart", "Bizarro Sednes", "Mark", "Saint Jean", "Gracience"};
            List<string> RobotLastNames = new List<string>(){"Stewart", "Little", "itiaH'D", "Moore", "D'Haiti", "Pastuer"};

            string CN = "";
            Random random = new Random();
            int randNum = random.Next(0,6);
            int index = 0;
            //Computer gets created only after Player 1 is created
            List<string> RandomizedNameList = new List<string>();
            if((randNum >= 0) && (randNum < 1)){
                index = random.Next(RobotUserNames.Count);
                CN =  RobotUserNames[index];
                RandomizedNameList.Add(CN);
                index = random.Next(RobotFirstNames.Count);
                CN = RobotFirstNames[index];
                RandomizedNameList.Add(CN);
                index = random.Next(RobotLastNames.Count);
                CN = RobotLastNames[index];
                RandomizedNameList.Add(CN);

                //Console.WriteLine($"\n\t\tPlayer 1 is: {this.currentGame.Player1.Username}\n\t\tPlayer 2 is: {this.currentGame.Player2.Username}\n");
                //flag = true;
            }else if((randNum >= 1) && (randNum < 2)){
                index = random.Next(RobotUserNames.Count);
                CN =  RobotUserNames[index];
                RandomizedNameList.Add(CN);
                index = random.Next(RobotFirstNames.Count);
                CN = RobotFirstNames[index];
                RandomizedNameList.Add(CN);
                index = random.Next(RobotLastNames.Count);
                CN = RobotLastNames[index];
                RandomizedNameList.Add(CN);
            }else if((randNum >= 2) && (randNum < 3)){
                index = random.Next(RobotUserNames.Count);
                CN =  RobotUserNames[index];
                RandomizedNameList.Add(CN);
                index = random.Next(RobotFirstNames.Count);
                CN = RobotFirstNames[index];
                RandomizedNameList.Add(CN);
                index = random.Next(RobotLastNames.Count);
                CN = RobotLastNames[index];
                RandomizedNameList.Add(CN);
            }else if((randNum >= 3) && (randNum < 4)){
                index = random.Next(RobotUserNames.Count);
                CN =  RobotUserNames[index];
                RandomizedNameList.Add(CN);
                index = random.Next(RobotFirstNames.Count);
                CN = RobotFirstNames[index];
                RandomizedNameList.Add(CN);
                index = random.Next(RobotLastNames.Count);
                CN = RobotLastNames[index];
                RandomizedNameList.Add(CN);
            }else if((randNum >= 4) && (randNum < 5)){
                CN =  RobotUserNames[index];
                RandomizedNameList.Add(CN);
                index = random.Next(RobotFirstNames.Count);
                CN = RobotFirstNames[index];
                RandomizedNameList.Add(CN);
                index = random.Next(RobotLastNames.Count);
                CN = RobotLastNames[index];
                RandomizedNameList.Add(CN);
            }else if((randNum >= 5) && (randNum < 6)){
                CN =  RobotUserNames[index];
                RandomizedNameList.Add(CN);
                index = random.Next(RobotFirstNames.Count);
                CN = RobotFirstNames[index];
                RandomizedNameList.Add(CN);
                index = random.Next(RobotLastNames.Count);
                CN = RobotLastNames[index];
                RandomizedNameList.Add(CN);
            }
            int index2 = random.Next(RandomizedNameList.Count);
            int index3 = random.Next(RandomizedNameList.Count);
            int index4 = random.Next(RandomizedNameList.Count);
            List<string> RobotNames = new List<string>(){RandomizedNameList[index2], RandomizedNameList[index3], RandomizedNameList[index4]};
            return RobotNames;
        }///End of Computer names that are automaticlly generated
        
        /// <summary>
        /// This method lets you specify six usernames to be randomly choosen 
        /// along with 6 prepopulated first and last names
        /// 
        /// Modied to randomly choose between all of the names
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="three"></param>
        /// <param name="four"></param>
        /// <param name="five"></param>
        /// <param name="six"></param>
        /// <returns></returns>
        public static List<string> ChooseComputerName_To_Pass_Username_Defined(string one, string two, string three, string four, string five, string six){
            List<string> RobotUserNames = new List<string>(){one, two, three, four, five, six};
            List<string> RobotFirstNames = new List<string>(){"John", "Stewart", "Bizarro Sednes", "Mark", "Saint Jean", "Gracience"};
            List<string> RobotLastNames = new List<string>(){"Stewart", "Little", "itiaH'D", "Moore", "D'Haiti", "Pastuer"};

            string CUN = "";
            string CFN = "";
            string CLN = "";
            Random random = new Random();
            int randNum = random.Next(0,6);
            
            //Computer gets created only after Player 1 is created
            if((randNum >= 0) && (randNum < 1)){
                int index = random.Next(RobotUserNames.Count);
                CUN =  RobotUserNames[index];
                index = random.Next(RobotFirstNames.Count);
                CFN = RobotFirstNames[index];
                index = random.Next(RobotLastNames.Count);
                CLN = RobotLastNames[index];
                //Console.WriteLine($"\n\t\tPlayer 1 is: {this.currentGame.Player1.Username}\n\t\tPlayer 2 is: {this.currentGame.Player2.Username}\n");
                //flag = true;
            }else if((randNum >= 1) && (randNum < 2)){
                CUN =  RobotUserNames[1];
                CFN = RobotFirstNames[1];
                CLN = RobotLastNames[1];
            }else if((randNum >= 2) && (randNum < 3)){
                CUN =  RobotUserNames[2];
                CFN = RobotFirstNames[2];
                CLN = RobotLastNames[2];
            }else if((randNum >= 3) && (randNum < 4)){
                CUN =  RobotUserNames[3];
                CFN = RobotFirstNames[3];
                CLN = RobotLastNames[3];
            }else if((randNum >= 4) && (randNum < 5)){
                CUN =  RobotUserNames[4];
                CFN = RobotFirstNames[4];
                CLN = RobotLastNames[4];
            }else if((randNum >= 5) && (randNum < 6)){
                CUN =  RobotUserNames[5];
                CFN = RobotFirstNames[5];
                CLN = RobotLastNames[5];
            }

            List<string> RobotNames = new List<string>(){CUN, CFN, CLN};
            return RobotNames;
        }//End of Computer names with user defined usernames

        //Player choice
        /// <summary>
        /// This method asks the user for their piece choices 
        ///     and displays the names and returns the chosen Piece Types
        /// </summary>
        /// <returns></returns>
        public static dynamic? SavePlayerChoice(){
            Console.WriteLine($"\n\t\tChoose a weapon type to make a move:\n\t\t |Choose 1 for Rock\n\t\t |Choose 2 for Paper\n\t\t |Choose 3 for Scissors");
            int answer = 0;
            bool flag1 = false;
            int ConvertChoicetoINT(){
                int a = 0;
                string stringAnswer = IfStatements.Verify_String_Answer_FOR_INT(1,1);
                // try{
                a = Convert.ToInt32(stringAnswer);
                return a;
                // }catch (FormatException msg){
                //     Console.WriteLine($"\n\t\tYour choice '{stringAnswer}' can ONLY contain numbers.\n\n\t\tIt threw the following error:\n\t\t{msg}");
                // }
            }


            do{//flag1
                CHOOSEAGAIN1:
                answer = ConvertChoicetoINT();
                //First Answer Loop
                //If Rock
                if(answer == 1){
                    //If they choose rock
                    Gamepiece gp = new Gamepiece();
                    Gamepiece.Rock gamePiece = new Gamepiece.Rock(gp);
                    //gamePiece.Name;
                    Console.WriteLine($"\n\t\tYour choice was {answer} or {gamePiece.Name}");
                    bool flag2 = false;

                    do{//flag2
                        //Rock - Loop1
                    CHOOSEAGAIN2:
                        Console.WriteLine($"\n\t\tWhich type of Rock will you use?");
                        Console.WriteLine($"\n\t\tSpecify weapon type:\n\t\t |Choose 1 for {gamePiece.brickClass.Name}\n\t\t |Choose 2 for {gamePiece.rocks_in_a_sackClass.Name}");
                        answer = ConvertChoicetoINT();
                        if(answer == 1){
                            Console.WriteLine($"\n\t\tYour choice was {answer} or {gamePiece.brickClass.Name}");
                            //set player choice as Gamepiece.Rock.Brick.BRICK value
                            return gamePiece.brickClass.BRICK;
                        }
                        
                        else if(answer == 2){
                            Console.WriteLine($"\n\t\tYour choice was {answer} or {gamePiece.rocks_in_a_sackClass.Name}");
                            //set player choice as Gamepiece.Rock.ROCKS_IN_SACK.ROCKS_IN_SACK value
                            return gamePiece.rocks_in_a_sackClass.ROCKS_IN_SACK;
                        }
                        Console.WriteLine($"\n\tYour choice was {answer} and could not be recorded.\n\t\tChoice MUST be 1 or 2\nTRY AGAIN!!!!");
                        //continue;
                        goto CHOOSEAGAIN2;
                    }while(flag2 == false);//End of Rock loop
                }
                
                //If Paper
                else if(answer == 2){
                    //They chose paper
                    Gamepiece gp = new Gamepiece();
                    Gamepiece.Paper gamePiece = new Gamepiece.Paper(gp);
                    
                    Console.WriteLine($"\n\t\tYour choice was {answer} or {gamePiece.Name}");
                    bool flag3 = false;
                    do{//flag3
                        //Paper loop1
                    CHOOSEAGAIN3:
                        Console.WriteLine($"\n\t\tWhich type of {gamePiece.Name} will you use?");
                        Console.WriteLine($"\n\t\tSpecify weapon type:\n\t\t |Choose 1 for {gamePiece.daggerPiece.Name}\n\t\t |Choose 2 for {gamePiece.shurikenPiece.Name}");
                        answer = ConvertChoicetoINT();
                        if(answer == 1){
                            Console.WriteLine($"\n\t\tYour choice was {answer} or {gamePiece.daggerPiece.Name}");
                            //set player choice as Gamepiece.Rock.Brick.BRICK value
                            return gamePiece.daggerPiece.Origami_Dagger;
                        }
                        
                        else if(answer == 2){
                            Console.WriteLine($"\n\t\tYour choice was {answer} or {gamePiece.shurikenPiece.Name}");
                            //set player choice as Gamepiece.Rock.ROCKS_IN_SACK.ROCKS_IN_SACK value
                            bool flag4 = false;

                            do{//flag4
                            CHOOSEAGAIN4:
                                Console.WriteLine($"\n\t\tWhich type of {gamePiece.shurikenPiece.Name} will you use?");
                                Console.WriteLine($"\n\t\tSpecify weapon type:\n\t\t |Choose 1 for {gamePiece.shurikenPiece.notebook_paperPiece.Name}\n\t\t |Choose 2 for {gamePiece.shurikenPiece.GOPPiece.Name}");
                                answer = ConvertChoicetoINT();
                                //Paper Loop2 - Shuriken types
                                if(answer == 1){
                                    Console.WriteLine($"\n\t\tYour choice was {answer} or {gamePiece.shurikenPiece.notebook_paperPiece.Name}");
                                    //set player choice as Gamepiece.Rock.Brick.BRICK value
                                    return gamePiece.shurikenPiece.notebook_paperPiece.NOTEBOOK_PAPER_SHURIKEN;
                                }
                                
                                else if(answer == 2){
                                    Console.WriteLine($"\n\t\tYour choice was {answer} or {gamePiece.shurikenPiece.GOPPiece.Name}");
                                    //set player choice as Gamepiece.Rock.ROCKS_IN_SACK.ROCKS_IN_SACK value
                                    return gamePiece.shurikenPiece.GOPPiece._Graphine_Oxide_Paper;
                                
                                }
                                //flag4 = true;
                                Console.WriteLine($"\n\tYour choice was {answer} and could not be recorded.\n\t\tChoice MUST be 1 or 2");
                                //continue;
                                goto CHOOSEAGAIN4;

                            }while(flag4 == false);//End of Paper loop2 - Shuriken Types

                        }
                        Console.WriteLine($"\n\tYour choice was {answer} and could not be recorded.\n\t\tChoice MUST be 1 or 2");
                        //continue;
                        goto CHOOSEAGAIN3;
                        //flag3 = false;

                    }while(flag3 == false);//End of Paper loop1
                }
                
                //If Scissor
                else if(answer == 3){
                    //They chose Scissors
                    Gamepiece gp = new Gamepiece();
                    Gamepiece.Scissors gamePiece = new Gamepiece.Scissors(gp);
                    Console.WriteLine($"\n\t\tYour choice was {answer} or {gamePiece.Name}");

                    bool flag5 = false;
                    do{//flag5
                        //Scissors loop1
                    CHOOSEAGAIN5:
                        Console.WriteLine($"\n\t\tWhich type of {gamePiece.Name} will you use?");
                        Console.WriteLine($"\n\t\tSpecify weapon type:\n\t\t |Choose 1 for {gamePiece.scissorsPiece.Name}\n\t\t |Choose 2 for {gamePiece.shearsPiece.Name}");
                        answer = ConvertChoicetoINT();
                        if(answer == 1){
                            Console.WriteLine($"\n\t\tYour choice was {answer} or {gamePiece.scissorsPiece.Name}");
                            //set player choice as Gamepiece.Rock.Brick.BRICK value
                            return gamePiece.scissorsPiece.CONSTRUCTION_SCISSORS;
                        }
                        else if(answer == 2){
                            Console.WriteLine($"\n\t\tYour choice was {answer} or {gamePiece.shearsPiece.Name}");
                            //set player choice as Gamepiece.Rock.Brick.BRICK value
                            return gamePiece.shearsPiece.SHEARS;
                        }
                        Console.WriteLine($"\n\tYour choice was {answer} and could not be recorded.\n\t\tChoice MUST be 1-3");
                        //continue;
                        goto CHOOSEAGAIN5;
                        return 0;
                        //flag5 = true;

                    }while(flag5 == false);//End of Scissors loop
                    
                }
                
                //If not 1, 2, or 3
                Console.WriteLine($"\n\tYour choice was {answer} and could not be recorded.\n\t\tChoice MUST be 1-3");
                //continue;
                goto CHOOSEAGAIN1;

                //flag1 = true;
            }while(flag1 == false);//End of First Answer Loop (Rock, Paper, Scissors)
               
            
        }//End of Player1choice

        /// <summary>
        /// This is the method to randomly pick between the list of choices
        /// for the computer opponent
        /// </summary>
        /// <returns></returns>
        public static dynamic? SavePlayer2Choice(){
            Gamepiece gp = new Gamepiece();
            Gamepiece.Rock gamePieceRock = new Gamepiece.Rock(gp);
            Gamepiece.Paper gamePiecePaper = new Gamepiece.Paper(gp);
            Gamepiece.Scissors gamePieceScissors = new Gamepiece.Scissors(gp);
            Dictionary<string, double> GamePieceList = new Dictionary<string, double>();
            GamePieceList.Add(gamePiecePaper.daggerPiece.Name , gamePiecePaper.daggerPiece.Origami_Dagger);
            GamePieceList.Add(gamePiecePaper.shurikenPiece.notebook_paperPiece.Name , gamePiecePaper.shurikenPiece.notebook_paperPiece.NOTEBOOK_PAPER_SHURIKEN);
            GamePieceList.Add(gamePiecePaper.shurikenPiece.GOPPiece.Name , gamePiecePaper.shurikenPiece.GOPPiece._Graphine_Oxide_Paper);
            GamePieceList.Add(gamePieceRock.brickClass.Name , gamePieceRock.brickClass.BRICK);
            GamePieceList.Add(gamePieceRock.rocks_in_a_sackClass.Name , gamePieceRock.rocks_in_a_sackClass.ROCKS_IN_SACK);
            GamePieceList.Add(gamePieceScissors.scissorsPiece.Name , gamePieceScissors.scissorsPiece.CONSTRUCTION_SCISSORS);
            GamePieceList.Add(gamePieceScissors.shearsPiece.Name , gamePieceScissors.shearsPiece.SHEARS);
            
            
        
            //int choiceINT = Convert.ToInt32(choice);
            KeyValuePair<string, double> ComputerChoice = new KeyValuePair<string, double>();//key val pair of choices 
            Random random = new Random();
            int value = random.Next(0,3);
            //double value = 0.0;
            int index = random.Next(GamePieceList.Count);
            if((value >= 0) && (value < 1)){
            Goto1:
                index = random.Next(GamePieceList.Count);
                if(GamePieceList.ElementAt(index).Value != GamePieceList.Values.Max()){
                    GamePieceList.Remove(GamePieceList.ElementAt(index).Key);//delete last one in list
                    index = random.Next(GamePieceList.Count);//roll again
                    ComputerChoice = GamePieceList.ElementAt(index);
                }else if(GamePieceList.ElementAt(index).Value != GamePieceList.Values.Min()){
                    GamePieceList.Remove(GamePieceList.ElementAt(index).Key);//delete last one in list
                    index = random.Next(GamePieceList.Count);//roll again
                    if(GamePieceList.ElementAt(index).Value != GamePieceList.Values.Min()){
                        GamePieceList.Remove(GamePieceList.ElementAt(index).Key);//delete last one in list
                        index = random.Next(GamePieceList.Count);//roll again
                        ComputerChoice = GamePieceList.ElementAt(index);
                    }else{
                        index = random.Next(GamePieceList.Count);//roll again
                        ComputerChoice = GamePieceList.ElementAt(index);
                    }
                }else{
                    goto Goto1;
                }
                
            }else if((value >= 1) && (value < 2)){
            Goto1:
                index = random.Next(GamePieceList.Count);
                if(GamePieceList.ElementAt(index).Value != GamePieceList.Values.Max()){
                    GamePieceList.Remove(GamePieceList.ElementAt(index).Key);//delete last one in list
                    index = random.Next(GamePieceList.Count);//roll again
                    ComputerChoice = GamePieceList.ElementAt(index);
                }else if(GamePieceList.ElementAt(index).Value != GamePieceList.Values.Min()){
                    GamePieceList.Remove(GamePieceList.ElementAt(index).Key);//delete last one in list
                    index = random.Next(GamePieceList.Count);//roll again
                    if(GamePieceList.ElementAt(index).Value != GamePieceList.Values.Min()){
                        GamePieceList.Remove(GamePieceList.ElementAt(index).Key);//delete last one in list
                        index = random.Next(GamePieceList.Count);//roll again
                        ComputerChoice = GamePieceList.ElementAt(index);
                    }else{
                        index = random.Next(GamePieceList.Count);//roll again
                        ComputerChoice = GamePieceList.ElementAt(index);
                    }
                }else{
                    goto Goto1;
                }
            }else if((value >= 2) && (value < 3)){
            Goto1:
                index = random.Next(GamePieceList.Count);
                if(GamePieceList.ElementAt(index).Value != GamePieceList.Values.Max()){
                    GamePieceList.Remove(GamePieceList.ElementAt(index).Key);//delete last one in list
                    index = random.Next(GamePieceList.Count);//roll again
                    ComputerChoice = GamePieceList.ElementAt(index);
                }else if(GamePieceList.ElementAt(index).Value != GamePieceList.Values.Min()){
                    GamePieceList.Remove(GamePieceList.ElementAt(index).Key);//delete last one in list
                    index = random.Next(GamePieceList.Count);//roll again
                    if(GamePieceList.ElementAt(index).Value != GamePieceList.Values.Min()){
                        GamePieceList.Remove(GamePieceList.ElementAt(index).Key);//delete last one in list
                        index = random.Next(GamePieceList.Count);//roll again
                        ComputerChoice = GamePieceList.ElementAt(index);
                    }else{
                        index = random.Next(GamePieceList.Count);//roll again
                        ComputerChoice = GamePieceList.ElementAt(index);
                    }
                }else{
                    goto Goto1;
                }
            }
            Console.WriteLine($"\t\tYour opponent's choice was {ComputerChoice.Key} which has a power-level of {ComputerChoice.Value}");
            return ComputerChoice;
            
        }//End Of the Computer choice

        //THis method will be to calculate the result of Player and Opponent's choice
        /// <summary>
        /// This method is here to calculate the result of the Player and Opponets choice
        /// </summary>
        public static int? CalcRound(KeyValuePair<string, double> ComputerChoice, double PlayerChoice){
            if(PlayerChoice > ComputerChoice.Value){
                Console.WriteLine($"\n\tRound {RoundOperations.SetRound()} Results:\n\t\tPlayer 1's choice of {PlayerChoice} \n\t\tbeat the computer's choice of {ComputerChoice.Value}");
                return 1;
            }else if(PlayerChoice == ComputerChoice.Value){
                Console.WriteLine($"\n\tRound {RoundOperations.SetRound()} Results:\n\t\tPlayer 1's choice of {PlayerChoice} \n\t\tied with the computer's choice of {ComputerChoice.Value}");
                return 2;
            }else if(PlayerChoice < ComputerChoice.Value){
                Console.WriteLine($"\n\tRound {RoundOperations.SetRound()} Results:\n\t\tPPlayer 1's choice of {PlayerChoice}\n\t\tlost to the computer's choice of {ComputerChoice.Value}");
                return 0;
            }else{
                return null;
            }

                
            //Console.WriteLine("End of the Round Calc");
        }
    }

    //Player makes a choice
    
}