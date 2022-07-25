using System;

namespace RPSGame3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Welcome Message

            Console.WriteLine("Welcome to THE GAME!");
            Console.WriteLine("Lets play some Tic Tac Toe");

            //Instructors on how to play the game
            Console.WriteLine("X is 1 while O is 0.");
            Console.WriteLine("Connect three charcters on the board to win the round.");

            //start the game  by pressing enter or another key
            Console.WriteLine("Press enter to start!");
            Console.Read();

            //(Invisible to user)create user variables to store user choices
            //int computerChoice = 0;
            int player1Choice = 0;
            string boardChoice = "";
            string player1ChoiceSTR = "";
            int playerW1Wins = 0;
            int computerWins = 0;
            int numberOfFiles = 0;
            string player1Name = "";
            string computerName = "";
            Random rand = new Random();
            int computerChoice = rand.Next(0,2); //Generates a number between 0 and 2
            int goesFirst = rand.Next(0,2); //Generates a number between 0 and 2 to see who goes first
            bool gotAWinner = false; // Is the game still running?
            bool successfulStrtoIntConvert = false;
            //create the board
            //This will be a 2d array 
            int[,] boardArray = new int[3,3];

            //int[] arr = new int[];

            //get the users choices

            // get the user name
            Console.WriteLine("What is your name?: ");

            player1Name = Console.ReadLine();//user input

            //Console.WriteLine($"Welcome {player1Name}");

            //See who is going first
            if ((goesFirst <= 1) && (goesFirst >= 0)){//If between 0 and 1
                //Player1 goes first
                Console.WriteLine($"You get to go first {player1Name}!");
                Console.WriteLine("First choose your position then select X or O\nX = 1, O = 0");
                player1ChoiceSTR = Console.ReadLine();
                //Console.WriteLine(player1ChoiceSTR);

            }else if((goesFirst > 1) && (goesFirst <= 2)){//If between 1 and 2
                //Computer goes first
                Console.WriteLine("The Computer goes first.");
                //Console.WriteLine("X or O| X = 1, O = 0");
            }

            //While the game is running Add the choices to the board
            while(gotAWinner == false){
                //if the player chose X or 1 convert to 1 int
                if ((player1ChoiceSTR == "X")||(player1ChoiceSTR == "x")||(player1ChoiceSTR == "1")){
                    player1ChoiceSTR = "1";
                    successfulStrtoIntConvert = Int32.TryParse(player1ChoiceSTR, out player1Choice);
                }
                //if the player chose O or 0 convert to 0 int
                else if((player1ChoiceSTR == "O")||(player1ChoiceSTR == "o")||(player1ChoiceSTR == "0")){
                    player1ChoiceSTR = "0";
                    successfulStrtoIntConvert = Int32.TryParse(player1ChoiceSTR, out player1Choice);
                }
                else{
                    Console.WriteLine("That was not a valid response!");
                }
                
                //Add choice to board position
                //boardArray[0] = 0;
                //Choose the position on the board
                Console.WriteLine("Choose the position on the board.");
                Console.WriteLine("TL|TM|TR\nML|M|MR\nBL|BM|BR");
                boardChoice = Console.ReadLine().ToUpper();
                //Make this part into a method to run more thann once
                while (true){
                    if (boardChoice == "TL"){
                        //If player's choice is TL
                        //boardArray.Insert(0, player1Choice);
                        boardArray[0,0] = player1Choice;
                        
                    }else if(boardChoice == "TM"){
                        //If player's choice is TM
                        boardArray[0,1] = player1Choice;
                    }else if(boardChoice == "TR"){
                        //If player's choice is TR
                        boardArray[0,2] = player1Choice;
                    }else if(boardChoice == "MR"){
                        //If player's choice is MR
                        boardArray[1,0] = player1Choice;
                    }else if(boardChoice == "M"){
                        //If player's choice is M
                        boardArray[1,1] = player1Choice;
                    }else if(boardChoice == "MR"){
                        //If player's choice is MR
                        boardArray[1,2] = player1Choice;
                    }else if(boardChoice == "BL"){
                        //If player's choice is BL
                        boardArray[2,0] = player1Choice;
                    }else if(boardChoice == "BM"){
                        //If player's choice is BM
                        boardArray[2,1] = player1Choice;
                    }else if(boardChoice == "BR"){
                        //If player's choice is BR
                        boardArray[2,2] = player1Choice;
                    }else{
                        //This is not a valid response
                        Console.WriteLine("This is not a valid response. Try Again!");
                        continue;
                    }
                    //Add the choice to the board
                    
                    foreach (int i in boardArray){
                        Console.WriteLine(i);
                    }
                    Console.WriteLine("Your converted choice:");
                    Console.WriteLine(player1Choice);
                    break;
                }

            }

            //Get the computer choice
            

            

            //Get your choice 

            //Add choice to board position

            //Check if any if the positions are 3 in a row
            
            //If not show empty spots left if so present the winner




            //Console.WriteLine($"Your Answers: {i.Length}");
            //totalResult = totalResult + i.Length;

        }
    }
}
