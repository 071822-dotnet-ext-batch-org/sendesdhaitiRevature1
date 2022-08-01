using System;
using System.Globalization;

namespace InherPoly2
{
    class Program
    {
        static void Main(string[] args)
        {
            Travelor person = new Travelor();
            Vehicle vehicle = new Vehicle();
            Order order = new Order();
        
            //Welcome Guest
            Console.WriteLine("Welcome to the Revature Transport Center.\n\n\tPRESS ENTER TO BEGIN!\n\n");
            Console.Read();

            //Get their name
            person.SaveName();
            Console.WriteLine($"\tWelcome {person.GetName()}");


            //Get their travel choice
            vehicle.SaveTravChoice();
            Console.WriteLine($"\n\tYou chose to travel by '{vehicle.GetVehTravelChoice()}'!\n\t\tThat's tough!!!\n");

            //Get the type of vehicle they'd like (vehicle Class with type, name)
            vehicle.SaveVehType();
            Console.WriteLine($"\t The vehicle type you chose was: {vehicle.GetVehType()}") ;
            //Vehicle Color
            vehicle.SaveVehColor();
            Console.WriteLine($"\t The vehicle color you chose was: {vehicle.GetVehColor()}") ;


            //Vehicle Doors
            vehicle.SaveVehDoors();
            Console.WriteLine($"\t This vehicle will have {vehicle.GetVehDoors()} doors.") ;


            //Vehicle Wheels
            vehicle.SaveVehWheels();
            Console.WriteLine($"\t The vehicle will be a {vehicle.GetVehWheels()} wheeler.") ;


            //Rent out the vehicle
            Console.WriteLine($"\n\n\tOk {person.GetName()}, here is the vehicle you chose!\n\n\tA {vehicle.GetVehColor()} {vehicle.GetVehDoors()} door {vehicle.GetVehType()} with {vehicle.GetVehWheels()} wheels.");

            //Complete the order
            // var cultureInfo = new CultureInfo("en-US");
            // var dateGoing = DateTime.Now;
            // var dateReturning = DateTime.Now;
            //string dateSTR = Console.ReadLine();
            //bool dateFlag = false;

            //Get their departure Date
            order.SaveDateGoing();

            //Console.WriteLine($"So you'll be gone from {order.GetDateGoing()}");

            //Get their Return Date
            order.SaveDateReturning();


            Console.WriteLine($"So you'll be on your trip from {order.GetDateGoing()} to {order.GetDateReturning()}\n\tYou will be gone for {order.CalcTripDuration()} days.");
    
            //Say goodbye after they've completed their order
            Console.WriteLine("\n\n\tHave fun and don't forget to bring a towel!");
            Console.WriteLine("\n\n\tPRESS ENTER TO END PROGRAM");
            Console.Read();


            //Console.WriteLine($"\t\t{coupe.Name} color is : {coupe.Color}");
            
            
        }
    }
}
