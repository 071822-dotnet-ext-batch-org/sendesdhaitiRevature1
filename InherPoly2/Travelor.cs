using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InherPoly2
{
    public class Travelor
    {
        public virtual string Name {get;set;} = "Travelor";
        public string TravChoice {get;set;}
        public virtual string VehChoice {get;set;}
        public virtual DateTime DateGoing {get;set;}
        public virtual DateTime DateReturning {get;set;}
        
        //LinkedList<C
        public Travelor(){}
        //public CarOwnerChoice OwnerChoice;
        public Travelor(string name, string travChoice, string vehChoice, DateTime dateGoing, DateTime dateReturning){
            this.Name = name;
            this.TravChoice = travChoice;
            this.VehChoice = vehChoice;
            this.DateGoing = dateGoing;
            this.DateReturning = dateReturning;


        }

        public void SaveName(){
            bool nameFlag = false;
            do{
                Console.WriteLine("\tWhat is your name?\n\nEnter Answer Below:");
                string name = Console.ReadLine();
                if(name != ""){
                    if (name.Length > 20){
                        Console.WriteLine("\n\tLENGTH OF YOUR NAME TOO LONG!\n\t*must be less than 20 characters*");
                    }else if(name.GetType() != typeof(string)){
                        Console.WriteLine("\n\tYOUR RESPONSE WAS NOT A STRING!\n\t*must be letters only(NO SPECIAL CHARACTERS)*");
                    }else{
                        this.Name = name;
                        nameFlag = true;
                    }
                }else{
                    Console.WriteLine("\n\tYou don't have a name?\n\tWhy not make one?\n");
                }

            }while(nameFlag == false);
            
        }

        
        public string GetName(){
            return this.Name;
        }


        //What do I want to do with the choice?
        //I want them to choose the Traveling method, vehicle, and how long they'll be traveling for
        
        // public class CarOwnerChoice {
            
        //     public void GetChoice(string choiceS){
        //         bool conf = false;
        //         while(true){
        //             string choiceStr = choiceS;
        //             int choiceInt =  0;
        //             while(conf == false){
        //                 if(Int32.TryParse(choiceStr, out choiceInt)){
        //                     if ( choiceInt == 1){
        //                         Choice = "Coupe/Sports Car";
        //                         conf == true;
        //                     }else if (choiceInt == 2){
        //                         Choice = "Truck";
        //                         conf == true;
        //                     }else if (choiceInt == 3){
        //                         Choice = "Sedan";
        //                         conf == true;
        //                     }else if (choiceInt == 4){
        //                         Choice = "SUV";
        //                         conf == true;
        //                     }else if (choiceInt == 5){
        //                         Choice = "Van";
        //                         conf == true;
        //                     }else{
        //                         Console.WriteLine("\nThat response was invalid.\n\n\tWhy don't you try again?\n\n");
        //                         continue;
        //                     }
        //                 }else{
        //                     Console.WriteLine("\n\t\tThe choice was not an integer.\n\n");
        //                 }//End if
        //             }
        //             Console.WriteLine($"\n\tYou chose a {Choice}!\n\t\tThat's tough!!!");
        //             break;
        //         }
        //     }//End GetChoice


        // }

    }//End2
}//End1