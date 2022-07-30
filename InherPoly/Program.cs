using System;

namespace InherPoly
{
    class Program
    {
        static void Main(string[] args)
        {
            Coupe coupe = new Coupe();
            Truck truck = new Truck();
            CarOwner owner = new CarOwner();
            // CarOwnerChoice ownerChoice = new CarOwnerChoice();
            // ownerChoice.
            
            
            //CarOw
            //Welcome Guest
            Console.WriteLine("Welcome to the Revature Transport Center.\n\tLet us begin!\n\n");
            Console.WriteLine("\tWhat is your name?\n\tType Your answer in the field below!");
            owner.Name = Console.ReadLine();
            Console.WriteLine($"\tWelcome {owner.Name}");

            Console.WriteLine("\tWhich type of car do you prefer?\n\t|1 for a Coupe/Sports Car\n\t|2 for a Truck\n\t|3 for a Sedan\n\t|4 for an SUV\n\t|5 for a Van");
            string s = Console.ReadLine();
            owner.OwnerChoice.GetChoice(s);

            truck.Color = "Black";
            coupe.Color = "Orange";


            //Car Car2 = new Car();

            


            Console.WriteLine($"\t\t{coupe.Name} color is : {coupe.Color}");
            //Console.WriteLine($"Hello World!\n\t{Furniture1.GetHouseNumber()}");

            // WorkItem workitem1 = new WorkItem();
            // WorkItem workitem1 = new WorkItem();

            
        }
    }
}
