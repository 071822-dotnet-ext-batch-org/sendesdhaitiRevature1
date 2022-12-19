using Microsoft.AspNetCore.Mvc;
using MS.REPO;
using MS.ACTIONS;
using MS.MODELS;
using MS.DATA.GUTTERAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using System.Diagnostics.Metrics;

namespace MS.DATA.GUTTERAPI.Controllers;
[EnableCors("MyAllowAllOrigins")]
[Authorize]
[ApiController]
[Route("gutter/")]
public class GET_CONTROLLER : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<GET_CONTROLLER> _logger;
    private readonly Idbaccess repo;
    private readonly Imsactions actions;

    public GET_CONTROLLER(ILogger<GET_CONTROLLER> logger, Idbaccess db, Imsactions ac)
    {
        _logger = logger;
        repo = db;
        actions = ac;
    }

    [HttpGet("mst")]
    public async Task<ActionResult<List<MintSoupToken>>> Get()
    {
        if (ModelState.IsValid)
        {
            List<MintSoupToken> tokens = new();
            string? mstoken = Request.Headers["mstoken"];
            try
            {
                tokens = await this.repo.GET_ALL_MintSoupTokens(new Guid(mstoken));
            }
            catch (ArgumentNullException msg)
            {
                Console.WriteLine($"The token used was null and as a result threw this exception: {msg}");
            }
            Console.WriteLine($"The token {mstoken} got a list of all tokens at {DateTime.Now}");
            return Ok(tokens);
        }
        return BadRequest();
    }

    [HttpGet("stores")]
    public async Task<ActionResult<List<Store>>> Get_Stores()
    {
        if (ModelState.IsValid)
        {
            List<Store> stores = new();
            string? mstoken = Request.Headers["mstoken"];
            try
            {
                stores = await this.repo.GetStoresAsync(new Guid(mstoken)); 
            }
            catch( ArgumentNullException msg)
            {
                Console.WriteLine($"The token used was null and as a result threw this exception: {msg}");
            }
            Console.WriteLine($"The token {mstoken} got a list of all stores at {DateTime.Now}");
            return Ok(stores);
        }
        return BadRequest();
    }

    [HttpGet("get-my-store/{personid}")]
    public async Task<ActionResult<Store>> Get_Stores([FromRoute] Guid personid)
    {
        if (ModelState.IsValid)
        {
            Store store = new();
            string? mstoken = Request.Headers["mstoken"];
            try
            {
                if(mstoken != null)
                {
                    store = await this.repo.Get_my_Store_by_personidAsync(personid);
                }
            }
            catch (ArgumentNullException msg)
            {
                Console.WriteLine($"The token used was null and as a result threw this exception: {msg}");
            }
            Console.WriteLine($"The token {mstoken} got a store at {DateTime.Now}");
            return Ok(store);
        }
        return BadRequest();
    }

    [HttpGet("myperson")]
    public async Task<ActionResult<Person>> Get_my_Person()
    {
        if (ModelState.IsValid)
        {
            Person person = new();
            string? mstoken = Request.Headers["mstoken"];
            try
            {
                person = await this.repo.GET_myMOST_RECENT_PERSON_by_mstokenID(new Guid(mstoken));
            }
            catch (ArgumentNullException msg)
            {
                Console.WriteLine($"The token used was null and as a result threw this exception: {msg}");
            }
            Console.WriteLine($"The token {mstoken} got a person at {DateTime.Now}");
            return Ok(person);
        }
        return BadRequest();
    }

    [HttpPost("get-products")]
    public async Task<ActionResult<List<Product>>> Get_Products( [FromBody] GetProductsDTO dto)
    {
        if (ModelState.IsValid)
        {
            List<Product> products = new();
            string? mstoken = Request.Headers["mstoken"];
            try
            {
                if(mstoken != null)
                {
                    //if all three search args are used
                    if(dto.category != null && dto.name != null && dto.type != null)
                    {
                        Console.WriteLine("all three args to search for products has been provided");
                        products = await this.repo.get_products(dto.category, dto.name, (int) dto.type);
                    }

                    //if category and type search args are used
                    else if ((dto.category != null) && (dto.name == null) && dto.type != null)
                    {
                        Console.WriteLine("category and type args to search for products has been provided");
                        products = await this.repo.get_products(dto.category, (int) dto.type);
                    }

                    //if only category search arg is used
                    else if (dto.category != null && dto.name == null && dto.type == null)
                    {
                        Console.WriteLine("only category arg to search for products has been provided");
                        products = await this.repo.get_products(dto.category);
                    }

                    //if only name search arg is used
                    else if (dto.category == null && dto.name != null && dto.type == null)
                    {
                        Console.WriteLine("only name arg to search for products has been provided");
                        products = await this.repo.get_products_by_name(dto.name);
                    }

                    //if only type search arg is used
                    else if (dto.category == null && dto.name == null && dto.type != null)
                    {
                        Console.WriteLine("only type arg to search for products has been provided");
                        products = await this.repo.get_products( (int) dto.type);
                    }

                    //if all args are empty
                    else if (dto.category == null && dto.name == null && dto.type == null)
                    {
                        Console.WriteLine(" No args to search for products have been provided");
                        products = await this.repo.get_products();
                    }
                }
            }
            catch (ArgumentNullException msg)
            {
                Console.WriteLine($"The token used was null and as a result threw this exception: {msg}");
            }
            Console.WriteLine($"The token {mstoken} just searched for some products at {DateTime.Now}");
            return Ok(products);
        }
        return BadRequest();
    }

}//END of GET CONTROLLER

