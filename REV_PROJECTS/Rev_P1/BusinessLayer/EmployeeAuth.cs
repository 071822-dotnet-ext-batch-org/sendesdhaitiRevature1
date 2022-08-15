using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;


namespace ModelLayer
{
    public class EmployeeAuth : Employee
    {
        public static void RegisterEmployee(){


            // Employee employee = new Employee();
            // Dictionary<string, Dictionary<string, string>.ValueCollection> UserList = new Dictionary<string, Dictionary<string, string>.ValueCollection>();
            // Dictionary<string,string> UserCredentials = new Dictionary<string, string>();
            // employee.SetFName();
            // UserCredentials.Add("Firstname", employee.GetFName());
            // employee.SetLName();
            // UserCredentials.Add("Lastname", employee.GetLName());
            // employee.SetUserName();
            // UserCredentials.Add("Username", employee.GetUserName());
            // employee.SetUserPassword();
            // UserCredentials.Add("Password", employee.GetUserPassword());
            // UserList.Add(UserCredentials["Username"], UserCredentials.Values);
            // //using(StreamWriter writer = new StreamWriter())
            // //StreamWriter stream = new StreamWriter("ReImbursement_Files/UserAuth.text");
            //     //This will create an object that will allow us to create the path thats in the parameter
            //     //This also includes the file itself
            // //string exString = "This is an example string";
            // // for(int i = 0; i < exString.Length; i++){
            // //     stream.Write(exString[i]);
            // //     //Write one character at a time to the file specified in the Streamwriter
            // // }//To write the whole string just use writeline without the for loop
            // //foreach loop can write sentence foor everycharacter in sentence
            // int iterator = 0;
            // // foreach(KeyValuePair<string, string> c in UserCredentials){
            // //     //Employee Employee = (Employee)
            // //     Console.WriteLine($"\nCongradulations, the User {iterator} has been saved.");
            // //     //foreach(string s in c)
            // //     stream.WriteLine($"\n\t{c.Key} : {c.Value},");

            // // }
            // //StreamReader read = new StreamReader("ReImbursement_Files/UserAuth.text");
            // using(StreamReader streamReader = new StreamReader("ReImbursement_Files/UserAuth.json"))
            // {
            //     bool flag = false;
            //     string s = "";
            //     do{
            //         s = streamReader.ReadLine();
            //         if(s.Contains(employee.Username)){
            //             Console.WriteLine($"\n\t\tThe username {employee.Username} is already present.");
            //             flag = true;
            //         }else{
            //             Console.WriteLine(s);
            //             StreamWriter stream = File.AppendText("ReImbursement_Files/UserAuth.json");
            //             stream.WriteLine("\n{");
            //             foreach(KeyValuePair<string, string> c in UserCredentials){
            //                 Console.WriteLine($"\nRow {iterator++} has been saved.");
            //                 stream.WriteLine($"\n\t{c.Key} : {c.Value}");             
            //             }     
            //             stream.WriteLine("\n},");
                        
            //             stream.Close();//This closes the file thats been read by the StreamWriter
            //         }
            //         Console.WriteLine(s);

            //         flag = true;

            //     }while(flag == false);
            // }


            //Now that we're able to add things to this file, lets try reading from it
            // StreamReader read = new StreamReader("file.txt");
            // int i = 0;
            // string wholeString = "";
        }
    }
}