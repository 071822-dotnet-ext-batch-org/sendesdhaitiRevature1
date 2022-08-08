using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rev_P1
{
    public class Employee : User, IEmployee
    {
        // UserAuth userAuth = new UserAuth();
        //public User User {get; set;}
        //private string Username;
        private string Fname {get;set;}
        private string Lname {get; set;}
        private bool Manager {get; set;} = false;
        //private string Password {get; set;}
        public Employee(){
        }
        public Employee(string fName, string lName, string username, string password){
            // this.Fname = username;
            // this.Lname = username;
            base.Username = username;
            base.Password = password;
            Fname = fName;
            Lname = lName;
            // DOB = new DateOnly(DOBMonth, DOBDay, DOBYear);
            // DateJoined;

        }
        public void SetFName(){
            bool authFlag = false;
            do{
                Console.WriteLine($"\tWhat is your first name?\n\nEnter Your Answer Below");
                string name = Console.ReadLine();
                if(name.Length < 1){
                    Console.WriteLine($"\n\n\t\tYou first name cannot be empty");
                    continue;
                }else if(name.Length > 50){
                    Console.WriteLine($"\n\n\t\tYou first name cannot be greater than 50 characters");
                    continue;
                }else{
                    if(Fname != null){
                        //If this first name is set already
                        Console.WriteLine($"\t\tYou already have a last name set as {Lname}");
                        continue;
                    }else{
                        Fname = name.ToUpper().Trim();
                        Console.WriteLine($"\t\tYour first name is {Fname}");
                        authFlag = true;
                    }
                }
            }while(authFlag == false);
        }
        public void SetLName(){
            bool authFlag = false;
            do{
                Console.WriteLine($"\tWhat is your last name?\n\nEnter Your Answer Below");
                string name = Console.ReadLine();
                if(name.Length < 1){
                    Console.WriteLine($"\n\n\t\tYou last name cannot be empty");
                    continue;
                }else if(name.Length > 50){
                    Console.WriteLine($"\n\n\t\tYou last name cannot be greater than 50 characters");
                    continue;
                }else{
                    if(Lname != null){
                        //If this first name is set already
                        Console.WriteLine($"\t\tYou already have a last name set as {Lname}");
                        continue;
                    }else{
                        Lname = name.ToUpper().Trim();
                        Console.WriteLine($"\t\tYour last name is {Lname}");
                        authFlag = true;
                    }
                }
            }while(authFlag == false);
        }
        public void SetUserName(){
            bool authFlag = false;
            do{
                Console.WriteLine($"\tWhat is your username?\n\nEnter Your Answer Below");
                string name = Console.ReadLine();
                if(name.Length < 1){
                    Console.WriteLine($"\n\n\t\tYou username cannot be empty");
                    continue;
                }else if(name.Length > 20){
                    Console.WriteLine($"\n\n\t\tYou username cannot be greater than 20 characters");
                    continue;
                }else{
                    if(base.Username != null){
                        //If this username if set already
                        Console.WriteLine($"\t\tThe username you chose is active already");
                        continue;
                    }else{
                        base.Username = name.Trim();
                        Console.WriteLine($"\t\tYour new username is {Username}");
                        authFlag = true;
                    }
                }
            }while(authFlag == false);
        }   

        public void SetUserPassword(){
            bool authFlag = false;
            do{
                Console.WriteLine($"\tWhat is your password?\n\nEnter Your Answer Below");
                string pass = Console.ReadLine();
                if(pass.Length < 1){
                    Console.WriteLine($"\n\n\t\tYou password cannot be empty");
                    continue;
                }else if(pass.Length > 20){
                    Console.WriteLine($"\n\n\t\tYou password cannot be greater than 20 characters");
                    continue;
                }else{
                    if(base.Password != null){
                        //If this username if set already
                        Console.WriteLine($"\t\tYou already have a password");
                        continue;
                    }else{
                        base.Password = pass.Trim();
                        Console.WriteLine($"\t\tYour new password is {Password}");
                        authFlag = true;
                    }
                }
            }while(authFlag == false);
        }   
        public string GetFName(){
            return Fname;
        }
        public string GetLName(){
            return Lname;
        } 
        public void RegisterEmployee(){
            Console.WriteLine("User is now registered!");
            
        }       
        public void LoginEmployee(){
            Console.WriteLine("User is now logged in!");
        }

    }
}