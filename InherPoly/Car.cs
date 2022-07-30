using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InherPoly
{
    public class Car : CarOwner
    {
        public  string Make {get; set;} = "Default Make";
        public  string Model {get; set;} = "Default Model";
        public  string Color {get; set;} = "Default Color";
        //private Type CarType ;
        //private Qualities CarQualities;

        public Car(){

            Color = "Matte Black";
            Make = "2019 Lamborgini";
            Model = "Merci";
            
        }
        // public virtual string GetCarMake(){
        //     return this.Make;
        // }
        // public virtual string GetCarModel(){
        //     return this.Model;
        // }
        // public virtual string GetCarColor(){
        //     return this.Color;
        // }
        // public virtual string ChangeColor(){
        //     Console.WriteLine("\tChange your car color free of charge!");
        //     this.Color = Console.ReadLine();
        //     return this.Color;
        // }
        // public virtual string ChangeMake(){
        //     Console.WriteLine("\tWe need to recall your car.\n\tWe'll send a replacement so what Make would you like?");
        //     this.Make = Console.ReadLine();
        //     return this.Make;
        // }
        // public virtual string ChangeModel(){
        //     Console.WriteLine("\tDont forget to change your car model also!");
        //     this.Model = Console.ReadLine();
        //     return this.Model;
        // }

        



        
    }
}