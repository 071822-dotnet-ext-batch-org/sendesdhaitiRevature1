using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class IfStatements
    {
        /// <summary>
        /// 
        /// This is a generic class that takes and validates as string 
        /// The string input returns a console message "What is your {variable}?
        /// 
        /// And prompts the user for a response 
        /// this answer is then validated (between 1-15 char)
        ///     and cannot contain numbers or special characters
        /// 
        /// It can only be a 15 character string only containing 
        /// 
        /// </summary>
        /// <param name="questionTopic"></param>
        /// <returns></returns>
        public static string? Verify_Short_StringOnly_Answer(string questionTopic){
            bool flag = false;
            string? answer = "";
            do{
                Console.WriteLine($"\n\n\t\tWhat is your {questionTopic}?");
                answer = Console.ReadLine();
                if(answer.Length < 1){
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE BELOW:");
                    //Task.Delay(2000);
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot be less than 1 characters\nMAKE ANOTHER RESPONSE\n");
                    continue;

                }else if(answer.Length > 15){
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot be greater than 15 characters\nMAKE ANOTHER RESPONSE BELOW:");
                    continue;
                }else{
                    // foreach(char s in answer.Trim()){
                    if(answer.Contains("0")|| 
                    answer.Contains("1") ||
                    answer.Contains("2") ||
                    answer.Contains("3") ||
                    answer.Contains("4") ||
                    answer.Contains("5") ||
                    answer.Contains("6") ||
                    answer.Contains("7") ||
                    answer.Contains("8") ||
                    answer.Contains("9") ||
                    answer.Contains("!") ||
                    answer.Contains("@") ||
                    answer.Contains("#") ||
                    answer.Contains("$") ||
                    answer.Contains("%") ||
                    answer.Contains("^") ||
                    answer.Contains("&") ||
                    answer.Contains("*") ||
                    answer.Contains("(") ||
                    answer.Contains(")") ||
                    answer.Contains("-") ||
                    answer.Contains("+") ||
                    answer.Contains("=") ||
                    answer.Contains("_") ||
                    answer.Contains("{") ||
                    answer.Contains("}") ||
                    answer.Contains("[") ||
                    answer.Contains("]") ||
                    answer.Contains("|") ||
                    answer.Contains(";") ||
                    answer.Contains(":") ||
                    answer.Contains("'") ||
                    answer.Contains("<") ||
                    answer.Contains(">") ||
                    answer.Contains(",") ||
                    answer.Contains(".") ||
                    answer.Contains("?") ||
                    answer.Contains("/")){
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot have numbers or special characters\nMAKE ANOTHER RESPONSE\n");
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot have numbers or special characters.\nMAKE ANOTHER RESPONSE BELOW:");
                    continue;

                    }else{
                        return answer;
                    }
                    // }//End foreach loop
                    //return "";
                }//End If
                //return "";
            }while(flag == false);
            return answer;
        }//End Verify Method

        /// <summary>
        /// This method will ask a user to input a string response 
        /// 
        /// The method takes in a string specifying what the user will be asked.
        /// Then 2 min and max integers specifying how long user's response should be.
        /// </summary>
        /// <param name="questionTopic"></param>
        /// <param name="responseMin"></param>
        /// <param name="responseMax"></param>
        /// <returns></returns>
        public static string? Verify_String_Answer(string questionTopic, int responseMin, int responseMax){
            bool flag = false;
            string? answer = "";
            do{
                Console.WriteLine($"\n\n\t\t{questionTopic}?\n\nENTER YOUR RESPONSE BELOW:");
                answer = Console.ReadLine();
                if(answer.Length < responseMin){
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE BELOW:");
                    //Task.Delay(2000);
                    continue;
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot be less than 1 characters\nMAKE ANOTHER RESPONSE\n");

                }else if(answer.Length > responseMax){
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot be greater than 15 characters\nMAKE ANOTHER RESPONSE BELOW:");
                }else{
                    // foreach(char s in answer.Trim()){
                    if(answer.Contains("!") ||
                    answer.Contains("@") ||
                    answer.Contains("#") ||
                    answer.Contains("$") ||
                    answer.Contains("%") ||
                    answer.Contains("^") ||
                    answer.Contains("&") ||
                    answer.Contains("*") ||
                    answer.Contains("(") ||
                    answer.Contains(")") ||
                    answer.Contains("-") ||
                    answer.Contains("+") ||
                    answer.Contains("=") ||
                    answer.Contains("_") ||
                    answer.Contains("{") ||
                    answer.Contains("}") ||
                    answer.Contains("[") ||
                    answer.Contains("]") ||
                    answer.Contains("|") ||
                    answer.Contains(";") ||
                    answer.Contains(":") ||
                    answer.Contains("'") ||
                    answer.Contains("<") ||
                    answer.Contains(">") ||
                    answer.Contains(",") ||
                    answer.Contains(".") ||
                    answer.Contains("?") ||
                    answer.Contains("/")){
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot have numbers or special characters\nMAKE ANOTHER RESPONSE\n");
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot have numbers or special characters\nMAKE ANOTHER RESPONSE BELOW:");
                    continue;

                    }else{
                        return answer;
                    }
                    // }//End foreach loop
                    //return "";
                }//End If
                //return "";
            }while(flag == false);
            return answer;
        }//End Verify Method2

        /// <summary>
        /// This method lets a user input a string value to get an integer response back.
        /// 
        /// This method takes in 2 integer values that specify min and max integeger string length.
        /// </summary>
        /// <param name="responseMin"></param>
        /// <param name="responseMax"></param>
        /// <returns></returns>
        public static string? Verify_SingleString_Answer_FOR_INT(int responseMin, int responseMax){
            bool flag = false;
            string? answer = "";
            do{
                //Console.WriteLine($"\n\n\t{questionTopic}?\n\nENTER YOUR RESPONSE BELOW:");
                answer = Console.ReadLine();
                answer = answer.ToUpperInvariant();
                if(answer.Length < responseMin){
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE BELOW:");
                    Task.Delay(2000);
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot be less than 1 characters\nMAKE ANOTHER RESPONSE\n");

                }else if(answer.Length > responseMax){
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot be greater than 15 characters\nMAKE ANOTHER RESPONSE BELOW:");
                }else{
                    // foreach(char s in answer.Trim()){
                    if(answer.Contains("Z")|| 
                    answer.Contains("X") ||
                    answer.Contains("C") ||
                    answer.Contains("V") ||
                    answer.Contains("B") ||
                    answer.Contains("N") ||
                    answer.Contains("M") ||
                    answer.Contains("A") ||
                    answer.Contains("S") ||
                    answer.Contains("D") ||
                    answer.Contains("F") ||
                    answer.Contains("G") ||
                    answer.Contains("H") ||
                    answer.Contains("J") ||
                    answer.Contains("K") ||
                    answer.Contains("L") ||
                    answer.Contains("Q") ||
                    answer.Contains("W") ||
                    answer.Contains("E") ||
                    answer.Contains("R") ||
                    answer.Contains("T") ||
                    answer.Contains("Y") ||
                    answer.Contains("U") ||
                    answer.Contains("I") ||
                    answer.Contains("O") ||
                    answer.Contains("P") ||
                    answer.Contains("!") ||
                    answer.Contains("@") ||
                    answer.Contains("#") ||
                    answer.Contains("$") ||
                    answer.Contains("%") ||
                    answer.Contains("^") ||
                    answer.Contains("&") ||
                    answer.Contains("*") ||
                    answer.Contains("(") ||
                    answer.Contains(")") ||
                    answer.Contains("-") ||
                    answer.Contains("+") ||
                    answer.Contains("=") ||
                    answer.Contains("_") ||
                    answer.Contains("{") ||
                    answer.Contains("}") ||
                    answer.Contains("[") ||
                    answer.Contains("]") ||
                    answer.Contains("|") ||
                    answer.Contains(";") ||
                    answer.Contains(":") ||
                    answer.Contains("'") ||
                    answer.Contains("<") ||
                    answer.Contains(">") ||
                    answer.Contains(",") ||
                    answer.Contains(".") ||
                    answer.Contains("?") ||
                    answer.Contains("/")){
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot have numbers or special characters\nMAKE ANOTHER RESPONSE\n");
                    Console.WriteLine($"\n\n\t\t\tYour answer '{answer}' cannot have LETTERS or SPECIAL characters\nMAKE ANOTHER RESPONSE BELOW:");
                    continue;

                    }else{
                        return answer;
                    }
                    // }//End foreach loop
                }//End If
            }while(flag == false);
            return answer;
        }//End Verify Method2


    }
}