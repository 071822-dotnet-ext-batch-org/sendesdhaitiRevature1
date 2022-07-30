using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InherPoly
{
    public class CarOwner
    {
        public string Name {get;set;}= "Owner Name";
        //LinkedList<C
        public CarOwner(){}
        public CarOwnerChoice OwnerChoice;
        public CarOwner(string name){
            Name = name;
        }
        public string Choice {get;set;}
        
        public class CarOwnerChoice {
            
            public void GetChoice(string choiceS){
                bool conf = false;
                while(true){
                    string choiceStr = choiceS;
                    int choiceInt =  0;
                    while(conf == false){
                        if(Int32.TryParse(choiceStr, out choiceInt)){
                            if ( choiceInt == 1){
                                Choice = "Coupe/Sports Car";
                                conf == true;
                            }else if (choiceInt == 2){
                                Choice = "Truck";
                                conf == true;
                            }else if (choiceInt == 3){
                                Choice = "Sedan";
                                conf == true;
                            }else if (choiceInt == 4){
                                Choice = "SUV";
                                conf == true;
                            }else if (choiceInt == 5){
                                Choice = "Van";
                                conf == true;
                            }else{
                                Console.WriteLine("\nThat response was invalid.\n\n\tWhy don't you try again?\n\n");
                                continue;
                            }
                        }else{
                            Console.WriteLine("\n\t\tThe choice was not an integer.\n\n");
                        }//End if
                    }
                    Console.WriteLine($"\n\tYou chose a {Choice}!\n\t\tThat's tough!!!");
                    break;
                }
            }//End GetChoice


        }

    }//End2
}//End1