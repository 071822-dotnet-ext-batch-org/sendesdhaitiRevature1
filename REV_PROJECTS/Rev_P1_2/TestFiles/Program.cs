using System;

namespace Rev_P1_2
{
    class Program
    {
        public static double ex(double a){
            double e = 1 + 2;
            double e2  = e * ex2(a);
            Console.Read();
            return e2;
            

        }

        public static double ex2(double d){
            double e = (5 * ex(d))/3.14;
            double addition = Convert.ToDouble(Console.ReadLine());
            return e;

        }
        enum Status{
            approved,
            denied,
            pending
        }
        static void Main(string[] args)
        {
            //This section is to see how to have a string input converted
            //to an Enum type
            Status stat = new Status();
            Console.WriteLine("Hello World!");
            var result = Enum.TryParse<Status>(Console.ReadLine(),out stat);
            Console.WriteLine($"{result} - {stat}");

            //This section is to test out an infinitely looping method 
            //ex2(2);
            //the result is that if faild due to stack overflow
            //56k results even though I have a read() method to pause for a response
        }
    }
}
