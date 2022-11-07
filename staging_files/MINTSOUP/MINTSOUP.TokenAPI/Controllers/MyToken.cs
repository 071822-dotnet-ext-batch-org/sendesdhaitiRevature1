using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using System.Text.Encodings.Web;//To encode the inputed data to be verified
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MINTSOUP.TokenAPI.Controllers
{
    [Route("mint-soup.token")]
    public class MyToken : Controller, IMyToken
    {
        private readonly Iuserservice user;
        public MyToken(Iuserservice _user)
        {
            this.user = _user;
        }
        




        /// <summary>
        /// Helps you get a jwt token with your email 
        /// </summary>
        public class token
        {
            private string email;

            public string Email { get => email; }

            public token() { email = ""; }

            public token(string _em)
            {
                this.email = _em;
            }
            /// <summary>
            /// This generates a token based on the user's email or username and assigns their role
            /// </summary>
            /// <param name="email_or_username"></param>
            /// <returns></returns>
            public string Generate_MINTSOUP_JWTtoken(string email, string userROLECHECK)
            {
                var MINTSOUP_securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes($"MINTSOUP|S{new Random().Next(0,9999)}E{new Random().Next(0, 9999)}N"));
                var token_credentials = new SigningCredentials(MINTSOUP_securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                    new Claim("Issuer", "MINTSOUP"),
                    new Claim("Admin", $"{userROLECHECK}"),//TODO - we should check if the user's credentials say they are admin/viewer/guest/or none
                    new Claim(JwtRegisteredClaimNames.UniqueName, email)
                };

                var _token = new JwtSecurityToken("MINTSOUP", "MINTSOUP", claims, expires: DateTime.Now.AddMinutes(10), signingCredentials: token_credentials);
                return new JwtSecurityTokenHandler().WriteToken(_token);
            }

            /// <summary>
            /// To validate if a string is in email format
            /// </summary>
            /// <param name="email"></param>
            /// <returns>true or false if the string is an email or not</returns>
            public static bool IsValidEmail(string email)
            {
                var trimmedEmail = email.Trim();

                if (trimmedEmail.EndsWith("."))
                {
                    return false; // suggested by @TK-421
                }
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == trimmedEmail;
                }
                catch
                {
                    return false;
                }
            }
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var _str = new string[] { "value1", "value2" };
            return Ok(_str);
        }

        // GET api/values/5
        [HttpGet("{email}")]
        public async Task<ActionResult<string?>> Get(string email)
        {
            if ( token.IsValidEmail(email) == true)
            {
                //this checks if the user exists and returns the user's role if so
                (userservice.CHECKSTATUS, userservice.USERROLE) res = await this.user.CHECK_IF_Viewer_IS_ADMIN_by_Email(email);

                //this checks which result the check for the user in the database was and returns the result
                if ((res.Item1 == userservice.CHECKSTATUS.TRUE) && (res.Item2 == userservice.USERROLE.Viewer))
                {
                    return Ok(new MyToken.token().Generate_MINTSOUP_JWTtoken(email, "false"));
                }
                else if ((res.Item1 == userservice.CHECKSTATUS.TRUE) && (res.Item2 == userservice.USERROLE.Admin))
                {
                    return Ok(new MyToken.token().Generate_MINTSOUP_JWTtoken(email, "true"));
                }
                else return NotFound(null);
            }
            else return NotFound(null);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)//the response is in the header - header response for the token by email or username and password
        {
        }

    }
}

