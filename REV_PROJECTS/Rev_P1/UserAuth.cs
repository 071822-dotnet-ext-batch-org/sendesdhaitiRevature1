using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Rev_P1
{
    public class UserAuth
    {
        double speed;
        public void RegisterUser(double speed){
            //Read File
            speed = speed;
            string file = "ReImbursement_Files/ReUserAuthData.json";
            StreamReader read = new StreamReader(file);
            Dictionary<string> UserAuthDict = new Directory<string>();
            //UserAuthDict.

            
            User userObj = new User();
            bool userFlag = false;
            do{
                Console.WriteLine($"\tWhat is your username?\n\n\t(MUST BE '3-30' CHARACTERS)\n");
                string username = Console.ReadLine();
                Console.WriteLine($"\tWhat is your username?\n\n\t(MUST BE '8-50' CHARACTERS)\n");
                string password = Console.ReadLine();
                
                Console.WriteLine($"Current User OBJ is: {obj}");
                if(obj.username == username){
                    //If the username is already created
                    Console.WriteLine($"The username '{username}' is already registered.");
                }else if(username == ""){
                    //If the username is blank
                    Console.WriteLine($"Your username cannot be blank.");
                }else if((username.Length < 3)|| (username.Length > 30)){
                    //If the username is out of range
                    Console.WriteLine($"Your username must be between (3 - 30) characters.");
                }else if((password.Length < 8)|| (username.Length > 50)){
                    //If the password is out of range
                    Console.WriteLine($"Your password must be between (8 - 50) characters.");
                }else{
                    obj.username = username;
                    obj.password = password;
                    //Write file
                    Console.WriteLine($"Welcome! Your new username  is set to: '{obj.username}'.");
                    userFlag = true;
                }
                
            }while(userFlag == false);
        }
    }
}