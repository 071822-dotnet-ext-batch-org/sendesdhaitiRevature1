using Microsoft.AspNetCore.Mvc;
using MS.REPO;
using MS.ACTIONS;
using MS.MODELS;
using MS.DATA.GUTTERAPI;
namespace MS.DATA.GUTTERAPI.Controllers;

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
        List<MintSoupToken> tokens = await this.repo.GET_ALL_MintSoupTokens();
        return Ok(tokens);
    }

    [HttpGet("stores")]
    public async Task<ActionResult<List<Store>>> Get_Stores([FromBody] Guid mstokenID)
    {
        if (ModelState.IsValid)
        {
            List<Store> tokens = await this.repo.GetStoresAsync(mstokenID);
            return Ok(tokens);
        }
        return BadRequest();
    }
}

