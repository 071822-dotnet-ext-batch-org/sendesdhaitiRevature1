using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Messages
    {
        /// <summary>
        /// "What is the 'message'?" printed on the console
        /// 
        /// This version message version has been deprecated and
        /// replaced with the VerifyAnswers.Verify_Short_StringOnly_Answer
        /// </summary>
        /// <param name="message"></param>
        public static void WhatIsYour_ConsoleMessage(string message){
            if(message.Length < 1){
                Console.WriteLine("\n\t\tYour response cannot be blank!\n\t\tTry again");
            }else if(message.Length > 50){
                Console.WriteLine("\n\t\tYour response cannot be greater than 50 characters!\n\t\tTry again");
            }else{
                Console.WriteLine($"\n\n\tWhat is the {message.Trim()}?\n\nENTER YOUR ANSWER BELOW\n");
                //return message.Trim();
            }
        }

        //Welcome message
        public static void Welcome(string message){
            Console.WriteLine($"\n\n\t{message}");
        }

        //Regular  message
        /// <summary>
        /// Regularly indented message
        /// </summary>
        /// <param name="message"></param>
        public static void Regular(string message){
            Console.WriteLine($"\n\n\t{message}");
        }

    }
}