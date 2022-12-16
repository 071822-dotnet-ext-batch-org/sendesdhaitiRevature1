using Microsoft.AspNetCore.Mvc;
using MS.REPO;
using MS.ACTIONS;
using MS.MODELS;
using MS.DATA.GUTTERAPI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

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

}//END of GET CONTROLLER

