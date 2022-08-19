using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using ModelLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReImbursementApp_Web_API.Controllers
{
    [Route("api/[controller]")]
    public class ReImbursementApp_Web_API_TicketController : Controller
    {
        private readonly Ticket _ticket = new Ticket();
        private readonly RunAppSession _runAppSession = new RunAppSession();
        // GET: api/values
        [HttpGet("Ticket/{ticket_Status}/")]
        public async Task<ActionResult<Ticket?>> Get(int ticket_Status)
        {
            //check if any tickets
            var checkTick = await this._runAppSession.CheckIfExists_Ticket(ticket_Status);

            if(checkTick == true)
            {
                //Found all tickets
                var getTick = await this._runAppSession.Get_Ticket_Employee(ticket_Status);


                return Ok(getTick);

            }
            else
            {
                //get all tickets
                return NotFound(checkTick);
            }
        }


        //Make new ticket
        [HttpGet("Ticket/create/")]
        public async Task<ActionResult<bool?>> Submit_Ticket(decimal emAM, string desc)
        {
            bool? result = null;
            if(emAM <= 0)
            {
                Console.WriteLine($"Ticket cannot be empty");
                return BadRequest(emAM);

            }
            else
            {
                //this._ticket.amount = emAM;
                bool descResult = VerifyAnswers.Verify_StringAnswer_For_Descrition(desc, 0, 200);
                if(descResult == false)
                {
                    Console.WriteLine("Something wrong with your description");
                    return BadRequest(desc);
                }
                else
                {
                    //this._ticket.description = desc;
                    Ticket newTick = new Ticket(emAM, desc);
                    result = await this._runAppSession.Submit_EmployeeTicket(newTick);
                    if(result == true)
                    {
                        //Saved successfully
                        return Ok(result);
                    }
                    else
                    {
                        return Ok(result);
                    }

                }

            }
        }

        // GET api/values/5
        //[HttpGet("Tickets/{ticket_status}/")]
        //public async Task<ActionResult<Ticket?>> Get_Employee_Ticket(int ticket_Status)
        //{
        //    //check if any tickets
        //    var checkTick = await this.runAppSession.Get_Ticket_Employee(ticket_Status);

        //    if (checkTick != null)
        //    {
        //        //Found all tickets
        //        return Ok(checkTick);

        //    }
        //    else
        //    {
        //        //get all tickets
        //        return NotFound(checkTick);
        //    }
        //}

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

