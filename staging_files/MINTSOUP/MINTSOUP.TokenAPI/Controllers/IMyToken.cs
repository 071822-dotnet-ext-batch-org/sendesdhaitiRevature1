using Microsoft.AspNetCore.Mvc;

namespace MINTSOUP.TokenAPI.Controllers
{
    public interface IMyToken
    {
        ActionResult<IEnumerable<string>> Get();
        Task<ActionResult<string?>> Get(string email);
        void Post([FromBody] string value);
    }
}