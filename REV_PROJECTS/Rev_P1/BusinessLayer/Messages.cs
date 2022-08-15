using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Messages
    {
        /// <summary>
        /// What is your "blank"?
        /// string cannot be greater than 50 char
        /// </summary>
        /// <param name="message"></param>
        public void WhatIsYour_ConsoleMessage(string message){
            if(message.Length < 1){
                Console.WriteLine("\n\t\tYour response cannot be blank!\n\t\tTry again");
            }else if(message.Length > 50){
                Console.WriteLine("\n\t\tYour response cannot be greater than 50 characters!\n\t\tTry again");
            }else{
                Console.WriteLine($"\n\n\tWhat is your {message.Trim()}?\n\nENTER YOUR ANSWER BELOW\n");
                //return message.Trim();
            }
        }

        //Welcome message
        public void Welcome(string message){
            Console.WriteLine($"\n\n\t{message}");
        }

        
    }
}