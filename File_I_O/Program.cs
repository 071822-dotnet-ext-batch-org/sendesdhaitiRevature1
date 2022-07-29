using System;
using System.IO; // For I/O

namespace File_I_O
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Call the Streamwriter Class
            StreamWriter stream = new StreamWriter("file.txt");
                //This will create an object that will allow us to create the path thats in the parameter
                //This also includes the file itself
            string exString = "This is an example string";
            // for(int i = 0; i < exString.Length; i++){
            //     stream.Write(exString[i]);
            //     //Write one character at a time to the file specified in the Streamwriter
            // }//To write the whole string just use writeline without the for loop
            //foreach loop can write sentence foor everycharacter in sentence
            int iterator = 0;
            foreach(char c in exString){
                stream.WriteLine($"{iterator++} {exString}");
            }
            
            stream.Close();//This closes the file thats been read by the StreamWriter

            //Now that we're able to add things to this file, lets try reading from it
            StreamReader read = new StreamReader("file.txt");
            int i = 0;
            string wholeString = "";
            while(!read.EndOfStream){//EndStream is to the end of the file's content (Returns a bool)
                //EndofStream is good if you don't know how large the file is
                    //Or if you know file's size can vary and change at any time
                string str = read.ReadLine();//Going to read 1 line at a time so we need to add to while loop to continue reading all of them
                wholeString += read.ReadLine();//This will Add each line together
                Console.WriteLine($"{i++} - {str}");
            }
            Console.WriteLine($"{wholeString}");//This is used in file logs for errors and many other uses
            //It can have the errors, the data that caused the error, the user that data was associated to and so on
        }
    }
}
