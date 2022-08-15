using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace ModelLayer
{
    public class Employee 
    {
        // UserAuth userAuth = new UserAuth();
        //public User User {get; set;}
        //private string Username;
        private Guid EmployeeID {get;set;} = new Guid();
        private string fname {get;set;}
        private string lname {get; set;}
        private bool manager {get; set;} = false;
        private string username {get;set;}
        private string password {get;set;}
        private DateTime datecreated {get;set;}
        private DateTime lastsignedin {get;set;}
        public string Username {
            get{
                return this.username;
            }set{
                this.username = value;
            }
        }
        public string Password {
            get{
                return this.password;
            }set{
                this.password = value;
            }
        }

        public string Fname {
            get{
                return this.fname;
            }set{
                this.fname = value;
            }
        }

        public string Lname {
            get{
                return this.lname;
            }set{
                this.lname = value;
            }
        }

        public bool Manager{
            get{
                return this.manager;
            }set{
                this.manager = value;
            }
        }

        public DateTime SIGNUPDATE{
            get{
                return this.datecreated;
            }set{
                this.datecreated = value;
            }
        }
        public DateTime LASTSIGNEDIN{
            get{
                return this.lastsignedin;
            }set{
                this.lastsignedin = value;
            }
        }
        public Employee(){
        }

        /// <summary>
        /// This is an employee that is signing up for the first time
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Employee(string fName, string lName, string username, string password){
            this.Username = username;
            this.Password = password;
            this.Fname = fName;
            this.Lname = lName;
            this.Manager = false;
            this.SIGNUPDATE = new DateTime().Date;
        }

        /// <summary>
        /// This is an employee that has signed back into the system
        /// 
        /// It generates a new employee in the session 
        /// with the parameters/data that employee previously had
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="signupdate"></param>
        /// <param name="manager"></param>
        public Employee(string username, string password, DateTime signupdate, bool manager){
            this.Username = username;
            this.Password = password;
            this.Fname = "First Name";
            this.Lname = "Last Name";
            this.Manager = false;
            this.SIGNUPDATE = signupdate;
            this.LASTSIGNEDIN = new DateTime().Date;

        }
        // public void SetUserName(string username){
        //     Username = username.Trim();
        // }
        // public void SetUserPassword(string password){
        //     Password = password.Trim();
        // }
        // public string GetUserName(){
        //     return Username;
        // }
        // public string GetUserPassword(){
        //     return Password;
        // }
        // public void SetFName(){
        //     bool authFlag = false;
        //     do{
        //         Console.WriteLine($"\tWhat is your first name?\n\nEnter Your Answer Below");
        //         string name = Console.ReadLine();
        //         if(name.Length < 1){
        //             Console.WriteLine($"\n\n\t\tYou first name cannot be empty");
        //             continue;
        //         }else if(name.Length > 50){
        //             Console.WriteLine($"\n\n\t\tYou first name cannot be greater than 50 characters");
        //             continue;
        //         }else{
        //             if(Fname != null){
        //                 //If this first name is set already
        //                 Console.WriteLine($"\t\tYou already have a last name set as {Lname}");
        //                 continue;
        //             }else{
        //                 Fname = name.ToUpper().Trim();
        //                 Console.WriteLine($"\t\tYour first name is {Fname}");
        //                 authFlag = true;
        //             }
        //         }
        //     }while(authFlag == false);
        // }
        // public void SetLName(){
        //     bool authFlag = false;
        //     do{
        //         Console.WriteLine($"\tWhat is your last name?\n\nEnter Your Answer Below");
        //         string name = Console.ReadLine();
        //         if(name.Length < 1){
        //             Console.WriteLine($"\n\n\t\tYou last name cannot be empty");
        //             continue;
        //         }else if(name.Length > 50){
        //             Console.WriteLine($"\n\n\t\tYou last name cannot be greater than 50 characters");
        //             continue;
        //         }else{
        //             if(Lname != null){
        //                 //If this first name is set already
        //                 Console.WriteLine($"\t\tYou already have a last name set as {Lname}");
        //                 continue;
        //             }else{
        //                 Lname = name.ToUpper().Trim();
        //                 Console.WriteLine($"\t\tYour last name is {Lname}");
        //                 authFlag = true;
        //             }
        //         }
        //     }while(authFlag == false);
        // }
        // public void SetUserName(){
        //     bool authFlag = false;
        //     do{
        //         Console.WriteLine($"\tWhat is your username?\n\nEnter Your Answer Below");
        //         string name = Console.ReadLine();
        //         if(name.Length < 1){
        //             Console.WriteLine($"\n\n\t\tYou username cannot be empty");
        //             continue;
        //         }else if(name.Length > 20){
        //             Console.WriteLine($"\n\n\t\tYou username cannot be greater than 20 characters");
        //             continue;
        //         }else{
        //             if(base.Username != null){
        //                 //If this username if set already
        //                 Console.WriteLine($"\t\tThe username you chose is active already");
        //                 continue;
        //             }else{
        //                 base.Username = name.Trim();
        //                 Console.WriteLine($"\t\tYour new username is {Username}");
        //                 authFlag = true;
        //             }
        //         }
        //     }while(authFlag == false);
        // }   

        // public void SetUserPassword(){
        //     bool authFlag = false;
        //     do{
        //         Console.WriteLine($"\tWhat is your password?\n\nEnter Your Answer Below");
        //         string pass = Console.ReadLine();
        //         if(pass.Length < 1){
        //             Console.WriteLine($"\n\n\t\tYou password cannot be empty");
        //             continue;
        //         }else if(pass.Length > 20){
        //             Console.WriteLine($"\n\n\t\tYou password cannot be greater than 20 characters");
        //             continue;
        //         }else{
        //             if(base.Password != null){
        //                 //If this username if set already
        //                 Console.WriteLine($"\t\tYou already have a password");
        //                 continue;
        //             }else{
        //                 base.Password = pass.Trim();
        //                 Console.WriteLine($"\t\tYour new password is {Password}");
        //                 authFlag = true;
        //             }
        //         }
        //     }while(authFlag == false);
        // }   
        // public string GetFName(){
        //     return Fname;
        // }
        // public string GetLName(){
        //     return Lname;
        // } 
        // public void RegisterEmployee(){
        //     Console.WriteLine("User is now registered!");
            
        // }       
        // public void LoginEmployee(){
        //     Console.WriteLine("User is now logged in!");
        // }

    }
}