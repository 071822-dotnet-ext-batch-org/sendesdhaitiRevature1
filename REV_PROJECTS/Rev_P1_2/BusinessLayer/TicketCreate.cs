using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLayer;

namespace BusinessLayer
{
    public class TicketCreate
    {
        public static Ticket CreateTicket(){
            Console.WriteLine($"\n\t\tWe understand your frustrations and are here to serve!\n\t\tPlease specify the necessary amount(0.00) to be reimbursted,\n\t\t\tand a description of the transaction.");
            double UserticketAmount = 0.0;
            string description = "";
            
            while(true){
            //What is the amount of ticket
            ReStateAmountIFNeitherFieldsAreIn:
            Messages.WhatIsYour_ConsoleMessage("ticket amount");
            UserticketAmount = VerifyAnswers.Verify_String_Answer_FOR_DOUBLE(2,5);
            
            //What is the description of the ticket
            //Messages.WhatIsYour_ConsoleMessage("description of your ticket");
            description = VerifyAnswers.Verify_String_Answer("\n\t\tFeel free to add a description of the request you're sending.", 0,50);
            
            
            //If both are given
            if ((UserticketAmount > 15.0) && (description.Length > 0)&& (description.Length < 50)){
                Ticket newTicket = new Ticket(UserticketAmount,description);
                Console.WriteLine($"\n\tYou've request for a ReImbursement Ticket in the ammount of : '{newTicket.Amount}'.\n\n\t\tPlease allow up to 3 business days for one of our Managers to\n\t\t\t respond to your request.");
                return newTicket;
            //if one is given
            }else if((UserticketAmount > 15.0) && (description.Length == 0)){
                Ticket newTicket = new Ticket(UserticketAmount);
                Console.WriteLine($"\n\tYou've request for a ReImbursement Ticket in the ammount of : '{newTicket.Amount}'.\n\n\t\tPlease allow up to 3 business days for one of our Managers to\n\t\t\t respond to your request.");
                return newTicket;
            }else if((UserticketAmount < 15.0) && (description.Length > 0)){
                //Ticket newTicket = new Ticket(UserticketUserticketAmount);
                Console.WriteLine($"\n\t\t\tYour ticket must have an ammount greater than $15 to be valid\n\t\t\tYour description must also be within 50 char");
                // return newTicket;
                goto ReStateAmountIFNeitherFieldsAreIn;
            }else{
                Console.WriteLine($"\n\t\t\tYour ticket cannot be blank");
                goto ReStateAmountIFNeitherFieldsAreIn;
            }


            }
        }        
    }
}