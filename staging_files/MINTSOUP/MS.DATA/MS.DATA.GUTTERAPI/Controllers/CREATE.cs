using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MS.ACTIONS;
using MS.MODELS;
using MS.REPO;
using static MS.MODELS.Statuses;

namespace MS.DATA.GUTTERAPI.Controllers
{
    [EnableCors("MyAllowAllOrigins")]
    [Authorize]
    [ApiController]
    [Route("gutter/")]
    public class CREATE_CONTROLLER : ControllerBase
    {
        private readonly ILogger<CREATE_CONTROLLER> _logger;
        private readonly Idbaccess get;
        private readonly Idbcreate repo;
        private readonly Idbcheck check;
        private readonly Imsactions actions;

        public CREATE_CONTROLLER(ILogger<CREATE_CONTROLLER> logger, Idbcreate db,Idbaccess gt, Imsactions ac, Idbcheck ch)
        {
            _logger = logger;
            repo = db;
            actions = ac;
            check = ch;
            get = gt;
        }

        [HttpPost("create-store")]
        public async Task<ActionResult<bool>> CREATE_STORE( [FromBody] CreateShowDTO dto)
        {
            bool CHECK = false;
            if(ModelState.IsValid)
            {
                if (await this.check.CHECK_IF_PERSON_EXISTS(dto.personID))
                {
                    CHECK = await this.repo.CREATE_STORE(dto.personID, dto.storename, dto.image, dto.privacyLevel);
                    Console.WriteLine($"{dto.personID} made a store called {dto.storename} at {DateTime.Now}");
                    return Created( "mystore/", CHECK);
                }
                else
                {
                    return NotFound($"The person with {dto.personID} could not be found at {DateTime.Now}");
                }
            }
            return BadRequest(CHECK);
        }

        [HttpPost("create-product")]
        public async Task<ActionResult<bool>> CREATE_PRODUCT([FromBody] CreateProductDTO dto)
        {
            bool CHECK = false;
            if (ModelState.IsValid)
            {
                if(await this.check.CHECK_IF_PERSON_EXISTS(dto.personID))
                {
                    CHECK = await this.repo.CREATE_PRODUCT(dto.storeID, dto.type, dto.category, dto.name, dto.price, dto.description, dto.status);
                    Console.WriteLine($"{dto.personID} made a product named {dto.name} at {DateTime.Now}");
                    return Created("myproduct/", CHECK);
                }
                else
                {
                    return NotFound($"The person with {dto.personID} could not be found at {DateTime.Now}");
                }
            }
            return BadRequest(CHECK);
        }

        [HttpPost("create-order")]
        public async Task<ActionResult<bool>> CREATE_ORDER([FromBody] CreateOrderDTO dto)
        {
            bool CHECK = false;
            if (ModelState.IsValid)
            {
                if (await this.check.CHECK_IF_PERSON_EXISTS(dto.personID))
                {
                    CHECK = await this.repo.CREATE_ORDER(dto.personID, dto.storeID, dto.type, dto.category, dto.amount, dto.desc, dto.orderStatus);
                    if(CHECK)
                    {
                        Order order = await this.get.GET_MOST_RECENT_ORDER_by_PERSON_and_STOREID(dto.personID, dto.storeID);
                        bool check = await this.repo.CREATE_ORDER_INVOICE(order.orderID, dto.invoice?.storename ?? "empty", dto.invoice?.payment_method ?? "empty", dto.invoice.card_number, dto.invoice.quantity);
                        if (!check) { return Conflict($"Order Invoice could not be saved"); }
                        foreach(Guid id in dto.productIDs)
                        {
                            if (!CHECK && !check) { break; }
                            check = await this.repo.CREATE_ORDER_RECEIPT(dto.personID, order.orderID, id, dto.amount, dto.invoice.quantity);
                        }
                        Console.WriteLine($"{dto.personID} made an order of {dto.amount} at {DateTime.Now}");
                        return Created("myorder/", CHECK);

                    }
                    return Conflict($"Order could not be saved");
                }
                else
                {
                    return NotFound($"The person with {dto.personID} could not be found at {DateTime.Now}");
                }
            }
            return BadRequest(CHECK);
        }

    }//END of CREATE CONTROLLER
}

