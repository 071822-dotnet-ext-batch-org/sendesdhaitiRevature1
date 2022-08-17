using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ModelLayer;


namespace RepoLayer
{
    public class AdoDotnetAccessPoint
    {
        private static void Regular(string message){
            Console.WriteLine($"\n\n\t{message}");
        }
        // private string? ReadReader(SqlDataReader? reader){
        //     string str = Convert.ToString(reader.Read()); //get Value of ppassword Column
        //     return str;
        // }
        //The connection stream to the Database
        private static readonly SqlConnection connection = new SqlConnection("Server=tcp:sendesdhaiti-revature-server.database.windows.net,1433;Initial Catalog=sendesdhaiti-revature-server;Persist Security Info=False;User ID=SendesD;Password=@Arcade30;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        /// <summary>
        /// This method checks to see if the employee is in the db
        /// Takes in the username of employee
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool?> Check_If_Employee_Exists_Async(string userName)
        {
            // SqlConnection connection = new SqlConnection("Server=tcp:sendesdhaiti-revature-server.database.windows.net,1433;Initial Catalog=sendesdhaiti-revature-server;Persist Security Info=False;User ID=SendesD;Password=@Arcade30;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using(SqlCommand command = new SqlCommand($"SELECT TOP 1 EmployeeID, Username, Firstname, Lastname, Manager, SignUpDate, LastSignedIn, EmPassword FROM Employee WHERE Username=@emUsername ", connection))
            {
                connection.Open();
                
                //To be able to input variables directly into the command, you use parameters
                //This Parameters also prevents against sql injection when users save data
                command.Parameters.AddWithValue("@emUsername", userName);
                //command.Parameters.AddWithValue("@emPass", userPass);
                
                SqlDataReader? returnValueOf_DB_Command = await command.ExecuteReaderAsync();
                //Console.WriteLine($"{returnValueOf_DB_Command.Read()}, {userName},  {userPass}");

                if(returnValueOf_DB_Command.Read()){
                    Console.WriteLine($"\tThis username is registered already.");
                    connection.Close();
                    return true;
                }else{
                    // Console.WriteLine($"\tData check for {em.Fname} with the id:{em.EmployeeID} was false ");
                    Console.WriteLine($"\tThis username is clear for you.");
                    connection.Close();
                    return false;
                }
            }

        }//END CHECK
        

        /// <summary>
        /// This method adds the employee to the DB
        /// </summary>
        /// <param name="emID"></param>
        /// <param name="userName"></param>
        /// <param name="userPass"></param>
        /// <param name="fNAME"></param>
        /// <param name="lNAME"></param>
        /// <param name="manager"></param>
        /// <param name="userSignupDate"></param>
        /// <param name="userLastModDate"></param>
        /// <returns></returns>
        public async Task<bool?> REGISTER_Employee_Async(Guid emID,string userName, string userPass, string fNAME, string lNAME, bool manager, DateTime userSignupDate, DateTime userLastModDate)
        {
            using(SqlCommand command = new SqlCommand($"INSERT INTO Employee VALUES(@emID, @emUsername, @emFirst, @emLast, @emManager, @emSignUp, @emLastMod, @emPass)", connection))
            {
                //To be able to input variables directly into the command, you use parameters
                //This Parameters also prevents against sql injection when users save data
                command.Parameters.AddWithValue("@emID", emID);
                command.Parameters.AddWithValue("@emUsername", userName);
                command.Parameters.AddWithValue("@emPass", userPass);
                command.Parameters.AddWithValue("@emFirst", fNAME);
                command.Parameters.AddWithValue("@emLast", lNAME);
                command.Parameters.AddWithValue("@emManager", manager);
                command.Parameters.AddWithValue("@emSignUp", userSignupDate);
                command.Parameters.AddWithValue("@emLastMod", userLastModDate);
                connection.Open();

                //The ExecuteNonQuery returns a response from the DB 
                //letting you know if the command was successful or not
                int returnValueOf_DB_Command = await command.ExecuteNonQueryAsync();

                if(returnValueOf_DB_Command > 0){
                    //If the command was successful
                    Regular($"Status Code {returnValueOf_DB_Command} - Account Saved");
                    connection.Close();
                    return true;
                }else{
                    //If the command was anything besides those first 2 conditions
                    Regular($"Status Code: {returnValueOf_DB_Command} - Account Not Saved");
                    connection.Close();
                    return false;
                }
            }

        }//END REGISTER

        /// <summary>
        /// This method logs the user in by populating the employee's class with the retrieved values
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPass"></param>
        /// <returns></returns>
        public async Task<Employee> LOGIN_Employee_Async(string userName, string userPass)
        {
            using(SqlCommand command = new SqlCommand($"SELECT Top 1 EmployeeID, Username, Firstname, Lastname, Manager, SignUpDate, LastSignedIn, EmPassword FROM Employee WHERE Username = @emUsername AND EmPassword = @emPass", connection))
            {
                //To be able to input variables directly into the command, you use parameters
                //This Parameters also prevents against sql injection when users save data
                command.Parameters.AddWithValue("@emUsername", userName);
                command.Parameters.AddWithValue("@emPass", userPass);
                connection.Open();
                SqlDataReader returnValueOf_DB_Command = await command.ExecuteReaderAsync();

                if(returnValueOf_DB_Command.Read()){
                    //If the command was successful
                    Employee newEm = new Employee();

                    newEm.EmployeeID = returnValueOf_DB_Command.GetGuid(0);
                    newEm.Username = returnValueOf_DB_Command.GetString(1);
                    newEm.Fname = returnValueOf_DB_Command.GetString(2);
                    newEm.Lname = returnValueOf_DB_Command.GetString(3);
                    newEm.Manager = returnValueOf_DB_Command.GetBoolean(4);
                    newEm.SIGNUPDATE = returnValueOf_DB_Command.GetDateTime(5);
                    newEm.LASTSIGNEDIN = returnValueOf_DB_Command.GetDateTime(6);
                    newEm.Password = returnValueOf_DB_Command.GetString(7);
                    connection.Close();
                    return newEm;
                }
                else{
                    Console.WriteLine("Employee could not be retrieved");
                    Employee newEm = new Employee();
                    connection.Close();
                    return newEm;
                }
            }

        }//End Login



        /// <summary>
        /// Updates the current Employee's data
        /// </summary>
        /// <param name="emID"></param>
        /// <param name="userName"></param>
        /// <param name="userPass"></param>
        /// <param name="fNAME"></param>
        /// <param name="lNAME"></param>
        /// <param name="manager"></param>
        /// <param name="userSignupDate"></param>
        /// <returns></returns>
        public async Task<int?> UPDATE_Employee_Async(Guid emID,string userName, string userPass, string fNAME, string lNAME, bool manager, DateTime userSignupDate, DateTime userLastModDate)
        {
            using(SqlCommand command = new SqlCommand($"UPDATE Employee VALUES(@emID, @emUsername, @emFirst, @emLast, @emManager, @emSignUp, @emLastMod, @emPass) WHERE Username = @emUsername AND EmPassword =@emPass", connection))
            {
                //To be able to input variables directly into the command, you use parameters
                //This Parameters also prevents against sql injection when users save data
                command.Parameters.AddWithValue("@emUsername", userName);
                command.Parameters.AddWithValue("@emPass", userPass);
                command.Parameters.AddWithValue("@emID", emID);
                command.Parameters.AddWithValue("@emFirst", fNAME);
                command.Parameters.AddWithValue("@emLast", lNAME);
                command.Parameters.AddWithValue("@emManager", manager);
                command.Parameters.AddWithValue("@emSignUp", userSignupDate);
                command.Parameters.AddWithValue("@emLastMod", userLastModDate);
                connection.Open();
                
                
                //The command going to the database
                int returnValueOf_DB_Command = await command.ExecuteNonQueryAsync();


                if(returnValueOf_DB_Command == 1){
                    //If the command was successful
                    connection.Close();
                    return returnValueOf_DB_Command;
                }else if(returnValueOf_DB_Command == 0){
                    //If the command was not successful
                    connection.Close();
                    return returnValueOf_DB_Command;
                }else{
                    //If the command was anything besides those first 2 conditions
                    connection.Close();
                    return returnValueOf_DB_Command;
                }
            }

        }//END UPDATE
        

        
    }
}