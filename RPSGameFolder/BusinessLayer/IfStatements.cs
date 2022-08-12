using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class IfStatements
    {
        /// <summary>
        /// This is a generic class that takes and validates as string 
        /// The string input returns a console message "What is your {variable}?
        /// 
        /// And prompts the user for a response
        /// This answer is then validated (between 1-15 char)
        ///     and cannot contain numbers or special characters
        /// 
        /// This
        /// It can only be a 15 character string only containing 
        /// </summary>
        public static string Verify_String_Answer(string questionTopic){
            bool flag = false;
            string answer = "";
            do{
                Console.WriteLine($"\n\n\tWhat is your {questionTopic}?");
                answer = Console.ReadLine();
                if(answer.Length < 1){
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE\n");
                    Task.Delay(2000);
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot be less than 1 characters\nMAKE ANOTHER RESPONSE\n");

                }else if(answer.Length > 15){
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot be greater than 15 characters\nMAKE ANOTHER RESPONSE\n");
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
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot have numbers or special characters\nMAKE ANOTHER RESPONSE\n");
                    continue;

                    }else{
                        return answer;
                        flag = true;
                    }
                    // }//End foreach loop
                    //return "";
                }//End If
                //return "";
            }while(flag == false);
            return answer;
        }//End Verify Method

        public static string Verify_String_Answer(string questionTopic, int responseMin, int responseMax){
            bool flag = false;
            string answer = "";
            do{
                Console.WriteLine($"\n\n\t{questionTopic}?\n\nENTER YOUR RESPONSE BELOW:");
                answer = Console.ReadLine();
                if(answer.Length < responseMin){
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE\n");
                    Task.Delay(2000);
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot be less than 1 characters\nMAKE ANOTHER RESPONSE\n");

                }else if(answer.Length > responseMax){
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot be greater than 15 characters\nMAKE ANOTHER RESPONSE\n");
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
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot have numbers or special characters\nMAKE ANOTHER RESPONSE\n");
                    continue;

                    }else{
                        return answer;
                        flag = true;
                    }
                    // }//End foreach loop
                    //return "";
                }//End If
                //return "";
            }while(flag == false);
            return answer;
        }//End Verify Method2


        public static string Verify_String_Answer_FOR_INT(int responseMin, int responseMax){
            bool flag = false;
            string answer = "";
            do{
                //Console.WriteLine($"\n\n\t{questionTopic}?\n\nENTER YOUR RESPONSE BELOW:");
                answer = Console.ReadLine();
                answer = answer.ToUpperInvariant();
                if(answer.Length < responseMin){
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot be empty\nMAKE ANOTHER RESPONSE\n");
                    Task.Delay(2000);
                    //throw new System.FormatException($"\n\n\t\tYour answer '{answer}' cannot be less than 1 characters\nMAKE ANOTHER RESPONSE\n");

                }else if(answer.Length > responseMax){
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot be greater than 15 characters\nMAKE ANOTHER RESPONSE\n");
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
                    Console.WriteLine($"\n\n\t\tYour answer '{answer}' cannot have LETTERS or SPECIAL characters\nMAKE ANOTHER RESPONSE\n");
                    continue;

                    }else{
                        return answer;
                        flag = true;
                    }
                    // }//End foreach loop
                    //return "";
                }//End If
                //return "";
            }while(flag == false);
            return answer;
        }//End Verify Method2


    }
}