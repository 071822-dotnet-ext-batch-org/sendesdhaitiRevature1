using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ModelLayer;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace RepoLayer
{
    public class AdoDotnetAccessPoint
    {

        //The connection stream to the Database
        private static readonly SqlConnection connection = new SqlConnection("Server=tcp:sendesdhaiti-revature-server.database.windows.net,1433;Initial Catalog=sendesdhaiti-revature-server;Persist Security Info=False;User ID=SendesD;Password=@Arcade30;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");



        //----------------------------------------------Employee Section

        //Checks if the returning Employee Exists
        /// <summary>
        /// Checks if the returning Employee Exists
        /// </summary>
        /// <param name="emP"></param>
        /// <returns></returns>
        public async Task<bool> Employee_LoginCheck(EmployeeDTO emP)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP 1 EmployeeID,  Fname, Lname, Username, Password, SignUpDate FROM Employees WHERE Username=@UN", connection))
            {
                command.Parameters.AddWithValue("@UN", emP.username);
                //command.Parameters.AddWithValue("@UP", emP.password);

                connection.Open();

                SqlDataReader? data = await command.ExecuteReaderAsync();

                if (data.Read())
                {
                    //true - data exists
                    connection.Close();
                    Console.WriteLine("\t\tAccount with matching data was found");
                    return true;
                }
                else
                {
                    connection.Close();
                    Console.WriteLine("\t\tNo matching data was found");
                    return false;
                }

            }

        }//Login Check for  Employee


        /// <summary>
        /// Log Employee in
        /// </summary>
        /// <param name="emP"></param>
        /// <returns></returns>
        public async Task<EmployeeDTO?> Employee_Login(EmployeeDTO emP)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP 1 EmployeeID,  Fname, Lname, Username, Password, SignUpDate FROM Employees WHERE Username=@UN AND Password=@UP", connection))
            {
                Employee employee = new Employee();
                command.Parameters.AddWithValue("@UN", emP.username);
                command.Parameters.AddWithValue("@UP", emP.password);

                connection.Open();
                SqlDataReader? data = await command.ExecuteReaderAsync();
                if (data.Read())
                {
                    Console.WriteLine("\t\tAccount with matching data was found");
                    emP.employee_ID = data.GetGuid(0);
                    emP.fname = data.GetString(1);
                    emP.lname = data.GetString(2);
                    emP.username = data.GetString(3);
                    emP.password = data.GetString(4);
                    emP.dateRegistered = data.GetDateTime(5);
                    connection.Close();
                    return emP;
                }
                else
                {
                    connection.Close();
                    Console.WriteLine("\t\tNo matching data was found");
                    return null;
                }

            }

        }//End of Login for Employee

        public async Task<bool> Employee_Register(EmployeeDTO emDTO)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Employees VALUES(@emID, @emF, @emL, @emU, @emP, @emS)", connection))
            {
                //To be able to input variables directly into the command, you use parameters
                //This Parameters also prevents against sql injection when users save data
                command.Parameters.AddWithValue("@emID", emDTO.employee_ID);
                command.Parameters.AddWithValue("@emF", emDTO.fname);
                command.Parameters.AddWithValue("@emL", emDTO.lname);
                command.Parameters.AddWithValue("@emU", emDTO.username);
                command.Parameters.AddWithValue("@emP", emDTO.password);
                command.Parameters.AddWithValue("@emS", emDTO.dateRegistered);
                //command.Parameters.AddWithValue("@Tick_EmID", emTickSub.fk_Employee_ID);
                //command.Parameters.AddWithValue("@Tick_MangID", emTickSub.fk_Employee_ID);
                connection.Open();

                //The ExecuteNonQuery returns a response from the DB 
                //letting you know if the command was successful or not
                int checkIfSaved = await command.ExecuteNonQueryAsync();

                if (checkIfSaved > 0)
                {
                    //If the command was successful
                    Console.WriteLine($"Status Code {checkIfSaved} - Ticket Saved");
                    connection.Close();
                    return true;
                }
                else
                {
                    //If the command was anything besides those first 2 conditions
                    Console.WriteLine($"Status Code: {checkIfSaved} - Ticket Not Saved");
                    connection.Close();
                    return false;
                }
            }
        }//End Register Employee





        //---------------------------------------------------------Manager Section
        //Check if manager exists
        /// <summary>
        /// This method checks if Manager exists in DB
        /// </summary>
        /// <param name="Mang"></param>
        /// <returns></returns>
        public async Task<bool> Manager_LoginCheck(ManagerDTO Mang)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP 1 ManagerID,  MFname, MLname, MFUsername, MFPassword, SignUpDate FROM Managers WHERE MFUsername=@UN", connection))
            {
                command.Parameters.AddWithValue("@UN", Mang.username);
                //command.Parameters.AddWithValue("@UP", Mang.password);

                connection.Open();

                SqlDataReader? data = await command.ExecuteReaderAsync();

                if (data.Read())
                {
                    //true - data exists
                    connection.Close();
                    Console.WriteLine("\t\tAccount with matching data was found");
                    return true;
                }
                else
                {
                    connection.Close();
                    Console.WriteLine("\t\tNo matching data was found");
                    return false;
                }

            }

        }//Login Check for Returning Manager


        public async Task<ManagerDTO?> Manager_Login(ManagerDTO Mang)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP 1 ManagerID,  MFname, MLname, MFUsername, MFPassword, SignUpDate FROM Managers WHERE MFUsername=@UN AND MFPassword=@UP", connection))
            {
                command.Parameters.AddWithValue("@UN", Mang.username);
                command.Parameters.AddWithValue("@UP", Mang.password);

                connection.Open();
                SqlDataReader? data = await command.ExecuteReaderAsync();
                if (data.Read())
                {
                    Console.WriteLine("\t\tAccount with matching data was found");
                    Mang.Manager_ID = data.GetGuid(0);
                    Mang.fname = data.GetString(1);
                    Mang.lname = data.GetString(2);
                    Mang.username = data.GetString(3);
                    Mang.password = data.GetString(4);
                    Mang.dateRegistered = data.GetDateTime(5);
                    connection.Close();
                    //emP.fk_TicketID = data.GetGuid(7);
                    return Mang;
                }
                else
                {
                    connection.Close();
                    Console.WriteLine("\t\tNo matching data was found");
                    return null;
                }

            }

        }//End of Login for Manager


        public async Task<bool> Manager_Register(ManagerDTO mangDTO)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Managers VALUES(@emID, @emF, @emL, @emU, @emP, @emS)", connection))
            {
                //To be able to input variables directly into the command, you use parameters
                //This Parameters also prevents against sql injection when users save data
                command.Parameters.AddWithValue("@emID", mangDTO.Manager_ID);
                command.Parameters.AddWithValue("@emF", mangDTO.fname);
                command.Parameters.AddWithValue("@emL", mangDTO.lname);
                command.Parameters.AddWithValue("@emU", mangDTO.username);
                command.Parameters.AddWithValue("@emP", mangDTO.password);
                command.Parameters.AddWithValue("@emS", mangDTO.dateRegistered);
                //command.Parameters.AddWithValue("@Tick_EmID", emTickSub.fk_Employee_ID);
                //command.Parameters.AddWithValue("@Tick_MangID", emTickSub.fk_Employee_ID);
                connection.Open();

                //The ExecuteNonQuery returns a response from the DB 
                //letting you know if the command was successful or not
                int checkIfSaved = await command.ExecuteNonQueryAsync();

                if (checkIfSaved > 0)
                {
                    //If the command was successful
                    Console.WriteLine($"Status Code {checkIfSaved} - Ticket Saved");
                    connection.Close();
                    return true;
                }
                else
                {
                    //If the command was anything besides those first 2 conditions
                    Console.WriteLine($"Status Code: {checkIfSaved} - Ticket Not Saved");
                    connection.Close();
                    return false;
                }
            }
        }//End Register Employee



        //---------------------------------------------------------Tickets Section

        public async Task<List<Ticket>?> Get_All_Tickets()
        {
            List<Ticket> allTicks = new List<Ticket>();
            using (SqlCommand command = new SqlCommand($"SELECT TicketID, Amount, Description, DateSubmitted, DateReviewed, Ticket_Status FROM Tickets", connection))
            {
                //command.Parameters.AddWithValue("@TStatus", employee.ticket_Status);

                connection.Open();

                SqlDataReader? data = await command.ExecuteReaderAsync();

                //if some data was found
                if (data != null)
                {
                    //iterate over that data
                    while (data.Read())
                    {
                        //Convert data to a TickDTO OBJ
                        Ticket Tick = new Ticket();
                        Status stat;
                        Enum.TryParse<Status>(data.GetString(5), out stat);
                        Tick.Ticket_ID = data.GetGuid(0);
                        Tick.Amount = data.GetDecimal(1);
                        Tick.Description = data.GetString(2);
                        Tick.SubmitDate = data.GetDateTime(3);
                        Tick.ReviewDate = data.GetDateTime(4);
                        Tick.TicketStatus = stat;
                        allTicks.Add(Tick);
                    }
                    //true - data exists

                    Console.WriteLine("\t\tTickets were retreived");
                    connection.Close();
                    return allTicks;
                }
                else
                {
                    Console.WriteLine("\t\tNo matching data was found");
                    connection.Close();
                    return allTicks;
                }

            }


        }

        public async Task<bool> Employee_TicketSubmit(Ticket emTickSub)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Tickets VALUES(@TickID, @TickAM, @Tickdesc, @TickSubDate, @TickRevDate, @TickStatus)", connection))
            {
                //To be able to input variables directly into the command, you use parameters
                //This Parameters also prevents against sql injection when users save data
                command.Parameters.AddWithValue("@TickID", emTickSub.Ticket_ID);
                command.Parameters.AddWithValue("@TickAM", emTickSub.Amount);
                command.Parameters.AddWithValue("@Tickdesc", emTickSub.Description);
                command.Parameters.AddWithValue("@TickSubDate", emTickSub.SubmitDate);
                command.Parameters.AddWithValue("@TickRevDate", emTickSub.ReviewDate);
                command.Parameters.AddWithValue("@TickStatus", emTickSub.TicketStatus);
                //command.Parameters.AddWithValue("@Tick_EmID", emTickSub.fk_Employee_ID);
                //command.Parameters.AddWithValue("@Tick_MangID", emTickSub.fk_Employee_ID);
                connection.Open();

                //The ExecuteNonQuery returns a response from the DB 
                //letting you know if the command was successful or not
                int checkIfSaved = await command.ExecuteNonQueryAsync();

                if (checkIfSaved > 0)
                {
                    //If the command was successful
                    Console.WriteLine($"Status Code {checkIfSaved} - Ticket Saved");
                    connection.Close();
                    return true;
                }
                else
                {
                    //If the command was anything besides those first 2 conditions
                    Console.WriteLine($"Status Code: {checkIfSaved} - Ticket Not Saved");
                    connection.Close();
                    return false;
                }
            }


        }
        //public async Task<bool> Employee_TicketCheck(Ticket emT)
        //{
        //    Ticket employee = new Ticket();
        //    employee.ticket_Status = emT.ticket_Status;
        //}//Tickect Check for Returning Ticket



        //public async Task<Ticket?> Employee_TicketGet(Ticket emStat)
        //{
        //    Ticket employee = new Ticket();
        //    //List<Ticket> tickList = new List<Ticket>();
        //    employee.ticket_Status = emStat.ticket_Status;
        //    using (SqlCommand command = new SqlCommand($"SELECT  TOP 1 TicketID,  Amount, Description, Ticket_Status, DateSubmitted, DateReviewed FROM Tickets WHERE Ticket_Status=@TStatus", connection))
        //    {
        //        command.Parameters.AddWithValue("@TStatus", employee.ticket_Status);

        //        connection.Open();

        //        SqlDataReader? data = await command.ExecuteReaderAsync();

        //        if (data.Read())
        //        {
        //            Ticket emTick = new Ticket();
        //            emTick.ticketID = data.GetGuid(0);
        //            emTick.amount = data.GetDecimal(1);
        //            emTick.description = data.GetString(2);
        //            emTick.ticket_Status = data.GetInt32(3);
        //            emTick.dateSubmitted = data.GetDateTime(4);
        //            emTick.dateReviewed = data.GetDateTime(5);
        //            //emTick.fk_Employee_ID = data.GetGuid(6);
        //            //emTick.fk_Manager_ID = data.GetGuid(7);



        //            //true - data exists
        //            connection.Close();
        //            Console.WriteLine("\t\tAccount with matching data was found");
        //            return emTick;
        //        }
        //        else
        //        {
        //            connection.Close();
        //            Console.WriteLine("\t\tNo matching data was found");
        //            return null;
        //        }

        //    }

        //}//Tickect Check for Returning Ticket


        //private static void Regular(string message){
        //    Console.WriteLine($"\n\n\t{message}");
        //}
        //// private string? ReadReader(SqlDataReader? reader){
        ////     string str = Convert.ToString(reader.Read()); //get Value of ppassword Column
        ////     return str;
        //// }

        ///// <summary>
        ///// This method checks to see if the employee is in the db
        ///// Takes in the username of employee
        ///// </summary>
        ///// <param name="userName"></param>
        ///// <returns></returns>
        //public async Task<bool?> Check_If_Employee_Exists_Async(string userName)
        //{
        //    // SqlConnection connection = new SqlConnection("Server=tcp:sendesdhaiti-revature-server.database.windows.net,1433;Initial Catalog=sendesdhaiti-revature-server;Persist Security Info=False;User ID=SendesD;Password=@Arcade30;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    using(SqlCommand command = new SqlCommand($"SELECT TOP 1 EmployeeID, Username, Firstname, Lastname, Manager, SignUpDate, LastSignedIn, EmPassword FROM Employee WHERE Username=@emUsername ", connection))
        //    {
        //        connection.Open();

        //        //To be able to input variables directly into the command, you use parameters
        //        //This Parameters also prevents against sql injection when users save data
        //        command.Parameters.AddWithValue("@emUsername", userName);
        //        //command.Parameters.AddWithValue("@emPass", userPass);

        //        SqlDataReader? returnValueOf_DB_Command = await command.ExecuteReaderAsync();
        //        //Console.WriteLine($"{returnValueOf_DB_Command.Read()}, {userName},  {userPass}");

        //        if(returnValueOf_DB_Command.Read()){
        //            Console.WriteLine($"\tThis username is registered already.");
        //            connection.Close();
        //            return true;
        //        }else{
        //            // Console.WriteLine($"\tData check for {em.Fname} with the id:{em.EmployeeID} was false ");
        //            Console.WriteLine($"\tThis username is clear for you.");
        //            connection.Close();
        //            return false;
        //        }
        //    }

        //}//END CHECK

        //public async Task<bool?> Check_If_Employee_Exists_UN_and_PW_Async(string userName, string passWord)
        //{
        //    // SqlConnection connection = new SqlConnection("Server=tcp:sendesdhaiti-revature-server.database.windows.net,1433;Initial Catalog=sendesdhaiti-revature-server;Persist Security Info=False;User ID=SendesD;Password=@Arcade30;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    using (SqlCommand command = new SqlCommand($"SELECT TOP 1 EmployeeID, Username, Firstname, Lastname, Manager, SignUpDate, LastSignedIn, EmPassword FROM Employee WHERE Username=@emUsername AND EmPassword=@emPassword ", connection))
        //    {
        //        connection.Open();

        //        //To be able to input variables directly into the command, you use parameters
        //        //This Parameters also prevents against sql injection when users save data
        //        command.Parameters.AddWithValue("@emUsername", userName);
        //        command.Parameters.AddWithValue("@@emPassword", passWord);

        //        SqlDataReader? returnValueOf_DB_Command = await command.ExecuteReaderAsync();
        //        //Console.WriteLine($"{returnValueOf_DB_Command.Read()}, {userName},  {userPass}");

        //        if (returnValueOf_DB_Command.Read())
        //        {
        //            Console.WriteLine($"\tThis username and password is registered!");
        //            connection.Close();
        //            return true;
        //        }
        //        else
        //        {
        //            // Console.WriteLine($"\tData check for {em.Fname} with the id:{em.EmployeeID} was false ");
        //            Console.WriteLine($"\tThis username is clear for you.");
        //            connection.Close();
        //            return false;
        //        }
        //    }

        //}//END CHECK



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
        //public async Task<bool?> REGISTER_Employee_Async(Guid emID,string userName, string userPass, string fNAME, string lNAME, bool manager, DateTime userSignupDate, DateTime userLastModDate)
        //{
        //    using(SqlCommand command = new SqlCommand($"INSERT INTO Employee VALUES(@emID, @emUsername, @emFirst, @emLast, @emManager, @emSignUp, @emLastMod, @emPass)", connection))
        //    {
        //        //To be able to input variables directly into the command, you use parameters
        //        //This Parameters also prevents against sql injection when users save data
        //        command.Parameters.AddWithValue("@emID", emID);
        //        command.Parameters.AddWithValue("@emUsername", userName);
        //        command.Parameters.AddWithValue("@emPass", userPass);
        //        command.Parameters.AddWithValue("@emFirst", fNAME);
        //        command.Parameters.AddWithValue("@emLast", lNAME);
        //        command.Parameters.AddWithValue("@emManager", manager);
        //        command.Parameters.AddWithValue("@emSignUp", userSignupDate);
        //        command.Parameters.AddWithValue("@emLastMod", userLastModDate);
        //        connection.Open();

        //        //The ExecuteNonQuery returns a response from the DB 
        //        //letting you know if the command was successful or not
        //        int returnValueOf_DB_Command = await command.ExecuteNonQueryAsync();

        //        if(returnValueOf_DB_Command > 0){
        //            //If the command was successful
        //            Regular($"Status Code {returnValueOf_DB_Command} - Account Saved");
        //            connection.Close();
        //            return true;
        //        }else{
        //            //If the command was anything besides those first 2 conditions
        //            Regular($"Status Code: {returnValueOf_DB_Command} - Account Not Saved");
        //            connection.Close();
        //            return false;
        //        }
        //    }

        //}//END REGISTER

        ///// <summary>
        ///// This method logs the user in by populating the employee's class with the retrieved values
        ///// </summary>
        ///// <param name="userName"></param>
        ///// <param name="userPass"></param>
        ///// <returns></returns>
        //public async Task<Employee> LOGIN_Employee_Async(string userName, string userPass)
        //{
        //    using(SqlCommand command = new SqlCommand($"SELECT Top 1 EmployeeID, Username, Firstname, Lastname, Manager, SignUpDate, LastSignedIn, EmPassword FROM Employee WHERE Username = @emUsername AND EmPassword = @emPass", connection))
        //    {
        //        //To be able to input variables directly into the command, you use parameters
        //        //This Parameters also prevents against sql injection when users save data
        //        command.Parameters.AddWithValue("@emUsername", userName);
        //        command.Parameters.AddWithValue("@emPass", userPass);
        //        connection.Open();
        //        SqlDataReader returnValueOf_DB_Command = await command.ExecuteReaderAsync();

        //        if(returnValueOf_DB_Command.Read()){
        //            //If the command was successful
        //            Employee newEm = new Employee();

        //            newEm.EmployeeID = returnValueOf_DB_Command.GetGuid(0);
        //            newEm.Username = returnValueOf_DB_Command.GetString(1);
        //            newEm.Fname = returnValueOf_DB_Command.GetString(2);
        //            newEm.Lname = returnValueOf_DB_Command.GetString(3);
        //            newEm.Manager = returnValueOf_DB_Command.GetBoolean(4);
        //            newEm.SIGNUPDATE = returnValueOf_DB_Command.GetDateTime(5);
        //            newEm.LASTSIGNEDIN = returnValueOf_DB_Command.GetDateTime(6);
        //            newEm.Password = returnValueOf_DB_Command.GetString(7);
        //            connection.Close();
        //            return newEm;
        //        }
        //        else{
        //            Console.WriteLine("Employee could not be retrieved");
        //            Employee newEm = new Employee();
        //            connection.Close();
        //            return newEm;
        //        }
        //    }

        //}//End Login



        ///// <summary>
        ///// Updates the current Employee's data
        ///// </summary>
        ///// <param name="emID"></param>
        ///// <param name="userName"></param>
        ///// <param name="userPass"></param>
        ///// <param name="fNAME"></param>
        ///// <param name="lNAME"></param>
        ///// <param name="manager"></param>
        ///// <param name="userSignupDate"></param>
        ///// <returns></returns>
        //public async Task<int?> UPDATE_Employee_Async(Guid emID,string userName, string userPass, string fNAME, string lNAME, bool manager, DateTime userSignupDate, DateTime userLastModDate)
        //{
        //    using(SqlCommand command = new SqlCommand($"UPDATE Employee VALUES(@emID, @emUsername, @emFirst, @emLast, @emManager, @emSignUp, @emLastMod, @emPass) WHERE Username = @emUsername AND EmPassword =@emPass", connection))
        //    {
        //        //To be able to input variables directly into the command, you use parameters
        //        //This Parameters also prevents against sql injection when users save data
        //        command.Parameters.AddWithValue("@emUsername", userName);
        //        command.Parameters.AddWithValue("@emPass", userPass);
        //        command.Parameters.AddWithValue("@emID", emID);
        //        command.Parameters.AddWithValue("@emFirst", fNAME);
        //        command.Parameters.AddWithValue("@emLast", lNAME);
        //        command.Parameters.AddWithValue("@emManager", manager);
        //        command.Parameters.AddWithValue("@emSignUp", userSignupDate);
        //        command.Parameters.AddWithValue("@emLastMod", userLastModDate);
        //        connection.Open();


        //        //The command going to the database
        //        int returnValueOf_DB_Command = await command.ExecuteNonQueryAsync();


        //        if(returnValueOf_DB_Command == 1){
        //            //If the command was successful
        //            connection.Close();
        //            return returnValueOf_DB_Command;
        //        }else if(returnValueOf_DB_Command == 0){
        //            //If the command was not successful
        //            connection.Close();
        //            return returnValueOf_DB_Command;
        //        }else{
        //            //If the command was anything besides those first 2 conditions
        //            connection.Close();
        //            return returnValueOf_DB_Command;
        //        }
        //    }

        //}//END UPDATE



    }
}