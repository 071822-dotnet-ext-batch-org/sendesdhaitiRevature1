using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BusinessLayer;
using ModelLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReImbursementApp_Web_API.Controllers
{
    [ApiController] //helps with routing
    [Route("api/[controller]")]
    public class ReImbursementApp_Web_API_AuthController : ControllerBase//instead of Controller
    {
        private readonly RunAppSession _currentSession;// = new RunAppSession();
        public ReImbursementApp_Web_API_AuthController()
        {
            this._currentSession = new RunAppSession();
        }


        /// <summary>
        /// This is to log in the Employee to their employee portal
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("Employee/Login/")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee([FromQuery]string username, [FromQuery]string password)
        {
            //RunAppSession _currentSession = new RunAppSession();
            EmployeeDTO em = new EmployeeDTO(username, password);


            //Send the Employee DTO to be checked
            var check = await _currentSession.CheckIfExists_Employee(em);

            //If check if successful, show the employee details
            if(check == true)
            {
                //get employee
                var getEm = await _currentSession.Login_Employee(em);
                if(getEm != null)
                {
                    return Ok(getEm);
                }
                else
                {
                    return NotFound($"The employee '{username}' could not be found");
                }
            }
            else
            {
                return Conflict("Your response could not be determined");
            }
        }



        /// <summary>
        /// This is to login the Manager to their Manger portal
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpGet("Manager/Login/")]
        public async Task<ActionResult<ManagerDTO>> GetManager([FromQuery]string username, [FromQuery]string password)
        {
            RunAppSession _currentSession = new RunAppSession();
            ManagerDTO manag = new ManagerDTO(username, password);


            //Send the Employee DTO to be checked
            var check = await _currentSession.CheckIfExists_Manager(manag);

            //If check if successful, show the employee details
            if (check == true)
            {
                //get employee
                var getEm = await _currentSession.Login_Manager(manag);
                if (getEm != null)
                {
                    return Ok(getEm);
                }
                else
                {
                    return NotFound($"The employee '{username}' could not be found");
                }
            }
            else
            {
                return BadRequest("Your response could not be determined");
            }
        }


        [HttpPost("Employee/Register")]
        public async Task<ActionResult<bool>> RegisterEmployee([FromQuery]string username, [FromQuery]string password, [FromQuery]string fn, [FromQuery]string ln )
        {
            EmployeeDTO newEm = new EmployeeDTO(username, password, fn, ln);

            //check if employee username is not already taken
            var check = await _currentSession.CheckIfExists_Employee(newEm);
            if(check == true)
            {
                //an employee with that username exists already
                return BadRequest($"This user '{username}'is registered already");
            }
            else
            {
                //an employee could not be found with that username, so it is clear for a new acc
                var regEm = await _currentSession.Register_Employee(newEm);
                if(regEm == true)
                {
                    //Save was successful
                    return Ok(regEm);
                }
                else
                {
                    return BadRequest($"Your response could not be completed due to an error on your end");
                }
            }
        }

        [HttpPost("Manager/Register")]
        public async Task<ActionResult<bool>> RegisterManager([FromQuery]string username, [FromQuery]string password, [FromQuery]string fn, [FromQuery]string ln)
        {
            ManagerDTO newMang = new ManagerDTO(username, password, fn, ln);

            //check if employee username is not already taken
            var check = await _currentSession.CheckIfExists_Manager(newMang);
            if (check == true)
            {
                //an employee with that username exists already
                return BadRequest($"This user '{username}'is registered already");
            }
            else
            {
                //an employee could not be found with that username, so it is clear for a new acc
                var regEm = await _currentSession.Register_Manager(newMang);
                if (regEm == true)
                {
                    //Save was successful
                    return Ok(regEm);
                }
                else
                {
                    return BadRequest($"Your response could not be completed due to an error on your end");
                }
            }
        }




        //[HttpGet]
        //public async Task<ActionResult<ModelLayer.EmployeeDTO>> GetEmployee(string username, string password)
        //{



        //}



        /// <summary>
        /// Checks for employee and 
        /// Logs Employee In
        /// </summary>
        /// <param name="userN"></param>
        /// <param name="userP"></param>
        /// <returns></returns>
        //[HttpGet("Login/{userN}/{userP}")]
        //public async Task<ActionResult<ModelLayer.Employee>> Log_In_Employee(string userN, string userP)
        //{
        //    RunAppSession _currentSession = new RunAppSession();
        //    _currentSession._sessionEmployee = new ModelLayer.Employee();
        //    Console.WriteLine("Let's Log you in");


        //    ModelLayer.Employee? myEmAccount = new ModelLayer.Employee(userN, userP);

        //    RunAppSession currentSession = new RunAppSession();
        //    currentSession.NewAppSession();

        //    //The repo layer in the session is gonna check if username and pass word is correct
        //    bool check = await currentSession.CheckIfExists_Employee(myEmAccount);
        //    if(check == false){
        //        //ReAsks for login
        //        Console.WriteLine($"The Employee Account of '{userN}' could not be found.");
        //        return NotFound(check);
        //        //Send Not Found status code using check obj
        //    }
        //    else
        //    {
        //        //log the employee in
        //        var EmAccount = await currentSession.Login_Employee(myEmAccount);
        //        Console.WriteLine($"Welcome back '{EmAccount.fname}'!");
        //        return Ok(EmAccount);
        //        //Send Success Status code using the account obj
        //    }

        //}



        //[HttpGet("Login/{userN}/")]
        //public async Task<ActionResult<ModelLayer.Employee?>> Log_In_Manager(string userN, string userP)
        //{
        //    Console.WriteLine("Welcome Manager, let's Log you in");


        //    ModelLayer.Manager? myMangAccount = new ModelLayer.Manager(userN, userP);

        //    RunAppSession currentSession = new RunAppSession();
        //    currentSession.NewAppSession();

        //    //The repo layer in the session is gonna check if username and pass word is correct
        //    bool check = await currentSession.CheckIfExists_Employee(myMangAccount);
        //    if (check == false)
        //    {
        //        //ReAsks for login
        //        Console.WriteLine($"The Employee Account of '{userN}' could not be found.");
        //        return NotFound(check);
        //        //Send Not Found status code using check obj
        //    }
        //    else
        //    {
        //        //log the employee in
        //        var EmAccount = await currentSession.Login_Employee(myEmAccount);
        //        Console.WriteLine($"Welcome back '{EmAccount.fname}'!");
        //        return Ok(EmAccount);
        //        //Send Success Status code using the account obj
        //    }

        //}



    }
}


        //// GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}