using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ModelLayer;
using BusinessLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReImbursementApp_Web_API.Controllers
{
    [ApiController] //helps with routing
    [Route("api/[controller]")]
    public class ReImbursementApp_Web_API_LoginController : ControllerBase//instead of Controller
    {
        /// <summary>
        /// Checks for employee and 
        /// Logs Employee In
        /// </summary>
        /// <param name="userN"></param>
        /// <param name="userP"></param>
        /// <returns></returns>
        [HttpGet("Login/{userN}/{userP}")]
        public async Task<ActionResult<Employee?>> Log_In_Employee(string userN, string userP)
        {
            Console.WriteLine("Let's Log you in");
            

            Employee? myEmAccount = new Employee(userN, userP);

            RunAppSession currentSession = new RunAppSession();
            currentSession.NewAppSession();

            //The repo layer in the session is gonna check if username and pass word is correct
            bool check = await currentSession.CheckIfExists_Employee(myEmAccount);
            if(check == false){
                //ReAsks for login
                Console.WriteLine($"The Employee Account of '{userN}' could not be found.");
                return NotFound(check);
                //Send Not Found status code using check obj
            }
            else
            {
                //log the employee in
                var EmAccount = await currentSession.Login_Employee(myEmAccount);
                Console.WriteLine($"Welcome back '{EmAccount.fname}'!");
                return Ok(EmAccount);
                //Send Success Status code using the account obj
            }




        }


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