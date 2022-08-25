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

        private static readonly RunAppSession _currentSession = new RunAppSession();

        [HttpGet("Ticket/")]
        //[HttpGet("Ticket/{id}/")]
        //[HttpGet("Ticket/{status}/")]
        public async Task<ActionResult<IEnumerable<ModelLayer.TicketDTO>?>> GetTickets()
        {


            //Retrieve a list of all ticketDTOs whether empty or not
            List<TicketDTO>? allTickets = await _currentSession.Get_AllTickets();

            //If list if not empty
            if (allTickets != null)
            {
                //show the list of tickets
                return Ok(allTickets);
            }
            else
            {
                //show an epty list of tickets
                return Ok(allTickets);
            }
        }



        // POST api/values
        [HttpPost("Create/")]
        public async Task<ActionResult<bool>> Create_Ticket([FromQuery] TicketDTO ticket)
        {
            //ModelLayer.TicketDTO newTicket = new ModelLayer.TicketDTO(ticket);
            RunAppSession _currentSession = new RunAppSession();

            bool savedTicket = await _currentSession.Create_Ticket(ticket);
            if (savedTicket == true)
            {
                return Created("Create", savedTicket);
            }
            else
            {
                return BadRequest(savedTicket);
            }
        }

        // PUT api/values/5
        [HttpPut("Update")]
        public async Task<ActionResult<string?>> UpdateTicket([FromQuery] string statusChange, [FromQuery] string manager, [FromQuery] Guid ticketIDToChange)
        {
            string? returnedResponse = await _currentSession.Update_Ticket(statusChange, manager, ticketIDToChange);
            if (returnedResponse != null)
            {
                return returnedResponse;
            }
            return returnedResponse;
        }
    }
}
