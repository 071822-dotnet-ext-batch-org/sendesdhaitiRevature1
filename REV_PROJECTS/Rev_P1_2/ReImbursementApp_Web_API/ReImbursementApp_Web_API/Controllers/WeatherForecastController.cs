using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using ModelLayer;
namespace ReImbursementApp_Web_API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    //private RunAppSession? newSession;
    //private static readonly string[] Summaries = new[]
    //{
    //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //};

    //private readonly ILogger<WeatherForecastController> _logger;

    //public WeatherForecastController(ILogger<WeatherForecastController> logger)
    //{
    //    _logger = logger;
    //}

    //[HttpGet(Name = "GetWeatherForecast")]
    //public IEnumerable<WeatherForecast> Get()
    //{
    //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //    {
    //        Date = DateTime.Now.AddDays(index),
    //        TemperatureC = Random.Shared.Next(-20, 55),
    //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //    })
    //    .ToArray();
    //}


    //Creating the Login Employee Endpoint
    //[HttpGet("Login")]
    //public async Task<ActionResult<Employee?>> GetEmployee()
    //{
    //    Employee? newEm = new Employee();
    //    RunAppSession? newSession = new RunAppSession();

    //    newEm =  await this.newSession.LoginEmployee();
    //    if(newEm == null)
    //    {
    //        return NotFound(newEm);
    //    }
    //    else
    //    {
    //        return newEm;

    //    }
    //}
}

