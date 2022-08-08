using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rev_P1
{
    public class User : IUser
    {
        private string username;
        private string password;
        public string Username {
            get{
                return username;
            }set{
                username = value;
            }
        }
        public string Password {
            get{
                return password;
            }set{
                password = value;
            }
        }
        //private string Lname {get; set;}
        
        public User(){}
        public User(string username){
            Username = username;
        }

        public User(string username, string password){
            Username = username;
            Password = password;
        }
        public void SetUserName(string username){
            Username = username.Trim();
        }
        public void SetUserPassword(string password){
            Password = password.Trim();
        }
        public string GetUserName(){
            return Username;
        }
        public string GetUserPassword(){
            return Password;
        }
        
    }
}