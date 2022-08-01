using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InherPoly2
{
    public class Vehicle : Travelor
    {
        private string VehType {get; set;}
        private int VehDoors {get; set;}
        private string VehColor {get; set;}
        private int VehWheels {get; set;}
        private string VehTravelChoice {get; set;}
        List<String> TravelMethodChoiceList {get;set;} = new List<String>();

        
        public Vehicle(){}
        public Vehicle(string type, string color, int doors, int wheels){
            this.VehType = type;
            this.VehColor = color;
            this.VehDoors = doors;
            this.VehWheels = wheels;

        }
        //Property Setters
        public void SaveVehType(){
            bool typeFlag = false;
            do{
                Console.WriteLine($"\n\n\tWhat type of vehicle would you like?\n\nEnter Answer Below {this.GetName()}:");
                string type = Console.ReadLine();
                if(type != ""){
                    this.VehType = type;
                    typeFlag = true;
                }else{
                    Console.WriteLine("YOUR INPUT CANNOT BE EMPTY!\n\n\tTry Again!");
                }
            }while(typeFlag == false);
        }
        public void SaveTravChoice(){

            bool travFlag = false;
            do{
                Console.WriteLine($"\n\n\tHow do you want to travel?\n\t|1 By Air\n\t|2 Land\n\t|3 By Sea\n\t|4 By Teleportation\n\nEnter Answer Below {this.GetName()}:");
                string choiceStr = Console.ReadLine();
                TravelMethodChoiceList.Add("1");
                TravelMethodChoiceList.Add("2");
                TravelMethodChoiceList.Add("3");
                TravelMethodChoiceList.Add("4");
                //make sure the string only has numbers
                foreach(char letter in choiceStr){
                    if (TravelMethodChoiceList.Contains(letter.ToString())){
                        int choice = Convert.ToInt32(choiceStr);
                        if (choice > 4 || choice <= 0){
                            Console.WriteLine("\n\tCHOICE MUST BE WITHIN RANGE!\n\t*must be between (1 - 4)*");
                            break;
                        }else if(choice.GetType() != typeof(int)){
                            Console.WriteLine("\n\tYOUR RESPONSE WAS NOT A STRING!\n\t*must be letters only(NO SPECIAL CHARACTERS)*");
                            break;
                        }else{
                            if(choice == 1){
                                this.VehTravelChoice = "Air";
                                travFlag = true;
                            }else if(choice == 2){
                                this.VehTravelChoice = "Land";
                                travFlag = true;
                            }else if(choice == 3){
                                this.VehTravelChoice = "Sea";
                                travFlag = true;
                            }else if (choice == 4){
                                this.VehTravelChoice = "Teleportation";
                                travFlag = true;
                            }
                        }

                    }else{
                        Console.WriteLine("Your chose was not one of the methods of transportation.\n\tTry Again!");
                        break;
                    }
                }


            }while(travFlag == false);
            
        }
        public void SaveVehColor(){
            bool colorFlag = false;
            do{
                Console.WriteLine($"\n\n\tWhat color will it be?\n\nEnter Answer Below {this.GetName()}");
                string color = Console.ReadLine();
                if(color != ""){
                    this.VehColor = color;
                    colorFlag = true;
                }else{
                    Console.WriteLine("YOUR INPUT CANNOT BE EMPTY!\n\n\tTry Again!");
                }
            }while(colorFlag == false);
        }
        public void SaveVehDoors(){
            bool doorsFlag = false;
            //int doors = 0;
            do{
                Console.WriteLine($"\n\n\tHow many doors will it have?\n\nEnter Answer Below {this.GetName()}");
                string doorsStr = Console.ReadLine();
                if(doorsStr != ""){
                    try{
                        int doors = Convert.ToInt32(doorsStr);
                        this.VehDoors = doors;
                        doorsFlag = true;
                    }catch (FormatException msg){
                        Console.WriteLine($"\n\tTHERE WAS AN ISSUE WITH YOUR INPUT '{0}':\n\t-'{msg}'\n\n\tMake sure your input is a number");
                    }
                    
                }else{
                    Console.WriteLine("YOUR INPUT CANNOT BE EMPTY!\n\n\tTry Again!");
                }
            }while(doorsFlag == false);

        }
        public void SaveVehWheels(){
            bool wheelsFlag = false;
            //int doors = 0;
            do{
                Console.WriteLine($"\n\n\tAnd finally how many wheels will it have?\n\nEnter Answer Below {this.GetName()}");
                string wheelsStr = Console.ReadLine();
                if(wheelsStr != ""){
                    try{
                        int wheels = Convert.ToInt32(wheelsStr);
                        this.VehWheels = wheels;
                        wheelsFlag = true;
                    }catch (FormatException msg){
                        Console.WriteLine($"\n\tTHERE WAS AN ISSUE WITH YOUR INPUT '{0}':\n\t-'{msg}'\n\n\tMake sure your input is a number");
                    }
                    
                }else{
                    Console.WriteLine("YOUR INPUT CANNOT BE EMPTY!\n\n\tTry Again!");
                }
            }while(wheelsFlag == false);
        }

        //Property Getters
        public string GetVehType(){
            return this.VehType;
        }
        public string GetVehColor(){
            return this.VehColor;
        }
        public int GetVehDoors(){
            return this.VehDoors;
        }
        public int GetVehWheels(){
            return this.VehWheels;
        }
        public string GetVehTravelChoice(){
            return this.VehTravelChoice;
        }



    }
}