using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLayer;
using RepoLayer;


namespace BusinessLayer
{
    public class RunAppSession
    {
        private readonly AdoDotnetAccessPoint _accessPoint = new AdoDotnetAccessPoint();
        private AppSession _newAppSession;// = new AppSession();
        private List<Ticket>? _sessionTickets = new List<Ticket>();
        private Ticket? _mostRecentTicket = new Ticket();
        private Employee _sessionEmployee = new Employee();
        private Manager? _sessionManager = new Manager();
        //private Guid? _sessionID { get; set; }
        //public Guid? _SessionID
        //{
        //    get
        //    {
        //        return this._sessionID;
        //    }
        //    set
        //    {
        //        this._sessionID = value;
        //    }
        //}


        /// <summary>
        /// Method to set and track login id across the repo
        /// </summary>
        /// <param name="id"></param>
        //public Guid? setCurrentID(Guid? id)
        //{
        //    this._SessionID = id;
        //    Console.WriteLine($"My ID is {this._SessionID}");
        //    return this._SessionID;

        //}

        ///// <summary>
        ///// Method to get the current login id of the user
        ///// </summary>
        ///// <returns></returns>
        //public Guid? getCurrentID()
        //{
        //    return this._SessionID;
        //}


        //Our Model Layer - All Data saved for the session
        ////Gonna need a List model to hold all tickets - makee it a derived class
        //private List<Ticket> _sessionTickets { get; set; } = new List<Ticket>();

        ////Our Repo Layer - All Data dsaved and retrieved from Database


        ////------------------------------------------------Run Session Section
        ///// <summary>
        ///// This method starts/creates a new AppSession
        ///// </summary>
        public RunAppSession()
        {
            this._accessPoint = new AdoDotnetAccessPoint();
            this._newAppSession = new AppSession();
        }



        ////------------------------------------------------Employee Checks and Pages Section

        /// <summary>
        /// This method in the currently ran session returns a true or false if the Employee's login credential match
        /// </summary>
        /// <param name="employeeInput"></param>
        /// <returns></returns>
        public async Task<bool> CheckIfExists_Employee(EmployeeDTO emCheckDTO)
        {
            //Check if username has any symbols or special characters
            Employee checkEm = new Employee(emCheckDTO);
            bool checkAP = await this._accessPoint.Employee_LoginCheck(checkEm);
            if (checkAP == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// This logs the user in based on the EmployeeDTO obj
        /// </summary>
        /// <param name="emCheckDTO"></param>
        /// <returns></returns>
        public async Task<EmployeeDTO?> Login_Employee(EmployeeDTO emCheckDTO)
        {
            Employee _sessionEmployee = new Employee(emCheckDTO);
            _sessionEmployee = await this._accessPoint.Employee_Login(_sessionEmployee);
            if(_sessionEmployee == null)
            {
                return null;
            }
            this._sessionEmployee = _sessionEmployee;
            EmployeeDTO em = new EmployeeDTO(_sessionEmployee);
            return em;
        }


        public async Task<bool> Register_Employee(EmployeeDTO emDTO)
        {
            Employee _sessionEmployee = new Employee(emDTO);
            this._sessionEmployee = _sessionEmployee;
            var emSaveResponse = await this._accessPoint.Employee_Register(_sessionEmployee);
            return emSaveResponse;
        }



        ////------------------------------------------------Manager Checks and Pages Section


        public async Task<bool> CheckIfExists_Manager(ManagerDTO managerInput)
        {
            //Check if employee exists from the repo layer
            Manager checkMang = new Manager(managerInput);
            bool checkAP = await this._accessPoint.Manager_LoginCheck(checkMang);
            if (checkAP == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public async Task<ManagerDTO?> Login_Manager(ManagerDTO managerInput)
        {
            Manager _sessionManager = new Manager(managerInput);
            _sessionManager = await this._accessPoint.Manager_Login(_sessionManager);
            if(_sessionManager != null)
            {
                this._sessionManager = _sessionManager;
                Console.WriteLine($"The manager '{this._sessionManager.Username}' is now logged in");
                ManagerDTO? mangDTO = new ManagerDTO(_sessionManager);
                return mangDTO;
            }
            else
            {
                Console.WriteLine($"The manager '{managerInput.username}' could not be found!");
                return null;
            }
        }

        public async Task<bool> Register_Manager(ManagerDTO mangDTO)
        {
            Manager _sessionManager = new Manager(mangDTO);
            var mangSaveResponse = await this._accessPoint.Manager_Register(_sessionManager);
            return mangSaveResponse;
        }



        ////------------------------------------------------Tickets Getting, Saving, and Updating Section
        public async Task<List<TicketDTO>?> Get_AllTickets()
        {
            //Ticket em = new Ticket();
            //em.Ticket_Status = input_T;
            List<Ticket>? _sessionTickets = await _accessPoint.Get_All_Tickets();

            List<TicketDTO>? tickDTO = new List<TicketDTO>();
            if (_sessionTickets != null)
            {
                foreach(Ticket t in _sessionTickets)
                {
                    TicketDTO retirevedDTO_Ticket = new TicketDTO(t);
                    tickDTO.Add(retirevedDTO_Ticket);
                }

                Console.WriteLine("the list of tickets were found");
                return tickDTO;
            }
            else
            {
                Console.WriteLine("The list of tickets is empty");
                return tickDTO;
            }

        }

        /// <summary>
        /// This method creates a new ticket by a specific employee
        /// </summary>
        /// <param name="emTicketDTO"></param>
        /// <returns></returns>
        public async Task<bool> Create_Ticket(TicketDTO emTicketDTO)
        {
            //Check if ticket DTO values are good before converting to Ticket OBJ
            bool descCheck = VerifyAnswers.Verify_StringAnswer_For_Descrition(emTicketDTO.description, 0, 200);
            if(emTicketDTO.amount <= 0)
            {
                //If amount is zero
                Console.WriteLine($"The amount of {emTicketDTO.amount} cannot be zero");
                return false;
            }
            
            else
            {
                //If description is a valid descrition
                if(descCheck == true)
                {
                    Ticket _mostRecentTicket = new Ticket()
                    {
                        Ticket_ID = Guid.NewGuid(),
                        Amount = emTicketDTO.amount,
                        Description = emTicketDTO.description,
                        TicketStatus = emTicketDTO._status,
                        SubmitDate = DateTime.Now,
                        ReviewDate = DateTime.Now,
                        FK_EmployeeID = await this._accessPoint.Employee_GETID(emTicketDTO.Username)//this._accessPoint.getCurrentID()
                };

                    bool checkIfSaved = await this._accessPoint.Employee_TicketSubmit(_mostRecentTicket);
                    if (checkIfSaved == true)
                    {
                        Console.WriteLine("Ticket Recorded");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Ticket could not be saved");
                        return false;
                    }

                }
                else
                {
                    Console.WriteLine($"The description of '{emTicketDTO.description}' was invalid");
                    return false;
                }
               
            }
        }//End of Create Ticket


        public async Task<string?> Update_Ticket(string status, string managerName, Guid tickID)
        {
            //Get the manager
            Guid? mangID = await _accessPoint.Manager_GETID(managerName);
            if(mangID != null)//If there is an ID retrieved
            {
                //Get the ticket
                //verify status
                if((status == Status.Approved.ToString()) || (status == Status.Denied.ToString()))
                {
                    //If this is the status -- Do operation here
                    bool didTicketSave = await _accessPoint.Manager_UpdateTicket(status, tickID);


                    if (didTicketSave == true)//If the ticket saved
                    {
                        bool didT_M_Save_TO_Junc = await _accessPoint.Manager_SavingTo_Junc_T_M(tickID, mangID);
                        if(didT_M_Save_TO_Junc == true)
                        {
                            return $"The manager {managerName} with the id {mangID} updated ticket with id [{tickID}]";

                        }
                        return $"The manager {managerName} with the id {mangID} updated ticket with id [{tickID}], but did not update T_M data";
                    }
                    else
                    {
                        return $"The manager {managerName} with the id {mangID} didn't update anything";
                    }
                }else if (status == Status.Pending.ToString())
                {
                    //If this is the status -- Do not check DB
                    return $"The manager {managerName} didn't update anything. You can only change status from 'Pending' to 'Approved or Denied'";
                }
                else
                {
                    //If you didnt make the right choice
                    Console.WriteLine($"\n\n\t\tThe Status '{status}' the manager entered was not part of the choices\n\n");
                    return $"The manager {managerName} didn't update anything. You can only change status from 'Pending' to 'Approved or Denied'";
                }

            }
            else
            {
                //If your username for manager was wrong
                Console.WriteLine($"\n\n\t\tThe username '{managerName}' the manager entered was incorrect\n\n");
                return null;
            }



            //Change the status by saving

        }//End of Update Ticket

    }
}