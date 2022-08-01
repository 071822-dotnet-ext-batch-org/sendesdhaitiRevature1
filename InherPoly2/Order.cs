using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace InherPoly2
{
    public class Order : Travelor
    {
        public override DateTime DateGoing {get;set;}
        public override DateTime DateReturning {get;set;}
        public Order(){}
        public Order(DateTime dateGoing, DateTime dateReturning){
            this.DateGoing = dateGoing;
            this.DateReturning = dateReturning;
        }

        public void SaveDateGoing(){
            var cultureInfo = new CultureInfo("en-US");
            string dateSTR = "";
            bool dateFlag = false;

            //Get their departure Date

            do{
                Console.WriteLine($"\n\n\n\tSo how long will you be needing this vehicle for?\n\tEnter your input in 'mm/dd/yyyy' Format\n\nEnter Answer Below {this.GetName()}:");
                try{
                    dateSTR = Console.ReadLine();
                    this.DateGoing = DateTime.ParseExact(dateSTR, "d", cultureInfo).Date;
                    dateFlag = true;
                }catch (FormatException){
                    Console.WriteLine("Unable to parse due to a format of the date error\n Must be in 'mm', 'dd', 'yyyy' Format.\n Your Response Was: '{0}'", dateSTR);
                }
            }while(dateFlag == false );
        }

        public void SaveDateReturning(){
            var cultureInfo = new CultureInfo("en-US");
            string dateSTR = "";
            bool dateFlag = false;
            DateTime date = new DateTime();

            //Get their Return Date

            do{
                Console.WriteLine($"\n\n\tWhen will you be returning?\n\tEnter your input in 'mm/dd/yyyy' Format\n\nEnter Answer Below {this.GetName()}:");
                try{
                    dateSTR = Console.ReadLine();
                    date = DateTime.ParseExact(dateSTR, "d", cultureInfo).Date;
                    this.DateReturning = date.Date;
                    dateFlag = true;
                }catch (FormatException){
                    Console.WriteLine("Unable to parse due to a format of the date error\n Must be in 'mm', 'dd', 'yyyy' Format.\n Your Response Was: '{0}'", dateSTR);
                }
            }while(dateFlag == false );
        }

        public DateTime GetDateGoing(){
            return this.DateGoing;
        }
        public DateTime GetDateReturning(){
            return this.DateReturning.Date;
        }

        public int CalcTripDuration(){
            return (this.DateReturning - this.DateGoing).Days;
        }
    }
}