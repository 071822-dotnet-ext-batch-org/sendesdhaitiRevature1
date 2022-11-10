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
using System.Security.Cryptography;//To hash the password

using System.Data.SqlClient;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MINTSOUP.TokenAPI.Controllers
{
    [EnableCors("MyAllowAllOrigins")]
    [Route("mint-soup.token")]
    public class MyToken : Controller
    {
        private readonly Iuserservice user;
        private readonly IMSAlgos msALGOS;
        public MyToken(Iuserservice _user, IMSAlgos algos)
        {
            this.user = _user;
            this.msALGOS = algos;
        }

        public class Models
        {
            public class SignUpDTO
            {
                public string email {get;set;}
                public string username {get;set;}
                public string password {get;set;}
                public SignUpDTO(){email = "";username = ""; password = "";}
                public SignUpDTO(string e, string u, string p): this()
                {
                    this.email = e;
                    this.username = u;
                    this.password = p;
                }
            }

            public class LoginDTO_w_username
            {
                public string username {get;set;}
                public string password {get;set;}
                public LoginDTO_w_username(){username = ""; password = "";}
                public LoginDTO_w_username( string u, string p):this()
                {
                    this.username = u;
                    this.password = p;
                }
            }

            public class LoginDTO_w_email
            {
                public string email {get;set;}
                public string password {get;set;}
                public LoginDTO_w_email(){email = ""; password = "";}
                public LoginDTO_w_email( string e, string p):this()
                {
                    this.email = e;
                    this.password = p;
                }
            }

            public class Change_PasswordDTO
            {
                public string email {get;set;}
                public string myMSToken {get;set;}
                public string newpassword {get;set;}
                public Change_PasswordDTO(){email = ""; myMSToken = ""; newpassword = "";}
                public Change_PasswordDTO( string e, string token, string p):this()
                {
                    this.email = e;
                    this.myMSToken = token;
                    this.newpassword = p;
                }
            }
            
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
                var MINTSOUP_securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes($"MINTSOUP|S{Guid.NewGuid()}E{Guid.NewGuid()}N"));
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


        // GET api/values/5
        //[DisableCors]
        [HttpGet("check-email/{email}")]
        public async Task<ActionResult<bool>> CHECK_IF_EMAIL_EXISTS([FromRoute] string email)
        {
            if ( token.IsValidEmail(email) == true)
            {
                //this checks if the user exists and returns the user's role if so
                bool res = await this.user.CHECK_IF_EMAIL_EXISTS(email);

                //this checks which result the check for the user in the database was and returns the result
                if (res == true)
                {
                    Console.WriteLine($"{res} at {DateTime.Now} to CHECK for email '{email}'");
                    return Ok(true);
                }
                else
                {
                    // return Ok(new MyToken.token().Generate_MINTSOUP_JWTtoken(email, "true"));
                    Console.WriteLine($"{res} at {DateTime.Now} to CHECK for email '{email}'");
                    return NotFound(false);
                }
            }
            else return BadRequest($"The email input of '{email}' is not a valid email");
        }

        [HttpGet("check-username/{username}")]
        public async Task<ActionResult<bool>> CHECK_IF_USERNAME_EXISTS([FromRoute] string username)
        {
            //this checks if the user exists and returns the user's role if so
            bool res = await this.user.CHECK_IF_EMAIL_EXISTS(username);

            //this checks which result the check for the user in the database was and returns the result
            if (res == true)
            {
                Console.WriteLine($"{res} at {DateTime.Now} to CHECK for username '{username}'");
                return Ok(true);
            }
            else
            {
                // return Ok(new MyToken.token().Generate_MINTSOUP_JWTtoken(email, "true"));
                Console.WriteLine($"{res} at {DateTime.Now} to CHECK for username '{username}'");
                return NotFound(false);
            }
        }

        [HttpPost("signup")]
        public async Task<ActionResult<bool>> CREATE_USER_ON_SIGNUP( [FromBody] Models.SignUpDTO dto)
        {
            if(ModelState.IsValid)
            {
                //this checks if the user exists and returns the user's role if so
                bool res = await this.user.CHECK_IF_EMAIL_EXISTS(dto.email);
                bool check_username = await this.user.CHECK_IF_USERNAME_EXISTS(dto.username);
                //this checks which result the check for the user in the database was and returns the result

                //Check if the username exists
                if(check_username == true) { return Conflict($"{check_username} at {DateTime.Now} - The username '{dto.username}' exists already"); }

                if (res == true)
                {
                    Console.WriteLine($"{res} at {DateTime.Now} to SIGNUP with '{dto.email}'");
                    return Conflict($"{res} at {DateTime.Now} - User could not be created because the user with email '{dto.email}' already exists");
                }
                else
                {

                    string newToken  = new MyToken.token().Generate_MINTSOUP_JWTtoken(dto.email, "true");
                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(newToken);
                    Console.WriteLine($"At {DateTime.Now} - The user {dto.email} made the token {token} decoded from {newToken}");

                    string hashedPassword = this.msALGOS.HashPassword(dto.password);
                    res = await this.user.CREATE_USER_ON_SIGNUP(dto.email, dto.username, hashedPassword);
                    if(res == true)
                    {
                        Console.WriteLine($"{res} at {DateTime.Now} to SIGNUP with '{dto.email}'");
                        return Created("token",token);
                    }
                    else
                    {
                        Console.WriteLine($"{res} at {DateTime.Now} to SIGNUP with '{dto.email}'");
                        return Conflict($"{res} at {DateTime.Now} - User could not be created due to an error with email '{dto.email}' and username '{dto.username}'");
                    }
                }
            }
            else
            {
                Console.WriteLine($"badrequest at {DateTime.Now} to SIGNUP with '{dto.email}'");
                return BadRequest("That was a bad request");
            }
        }

        [HttpPost("login-username")]
        public async Task<ActionResult<Guid?>> LOGIN_w_username([FromBody] Models.LoginDTO_w_username dto)
        {
            if(ModelState.IsValid)
            {
                //this checks if the user exists and returns the user's role if so
                bool res = await this.user.CHECK_IF_USERNAME_EXISTS(dto.username);

                //this checks which result the check for the user in the database was and returns the result
                if (res != true)
                {
                    return NotFound($"{res} at {DateTime.Now} - User could not be found with username '{dto.username}'");
                }
                else
                {
                    // return Ok(new MyToken.token().Generate_MINTSOUP_JWTtoken(email, "true"));
                    Guid? myToken = await this.user.LOGIN_USER_to_get_TOKEN_w_username(dto.username, dto.password);
                    if(myToken != null)
                    {
                        return Ok(myToken);
                    }
                    else
                    {
                        return Conflict(myToken);
                    }
                }
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }

        [HttpPost("login-email")]
        public async Task<ActionResult<Guid?>> LOGIN_w_email([FromBody] Models.LoginDTO_w_email dto)
        {
            if(ModelState.IsValid)
            {
                //this checks if the user exists and returns the user's role if so
                bool res = await this.user.CHECK_IF_EMAIL_EXISTS(dto.email);

                //this checks which result the check for the user in the database was and returns the result
                if (res != true)
                {
                    return NotFound($"{res} at {DateTime.Now} - User could not be found with email '{dto.email}'");
                }
                else
                {
                    // return Ok(new MyToken.token().Generate_MINTSOUP_JWTtoken(email, "true"));
                    Guid? myToken = await this.user.LOGIN_USER_to_get_TOKEN_w_email(dto.email, dto.password);
                    if(myToken != null)
                    {
                        return Ok(myToken);
                    }
                    else
                    {
                        return Conflict(myToken);
                    }
                }
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }

        // [HttpPost("change-password")]
        // public async Task<ActionResult<string?>> CHANGE_PASSWORD_w_email_and_token( Models.Change_PasswordDTO dto)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         //this checks if the user exists and returns the user's role if so
        //         bool res = await this.user.CHECK_IF_EMAIL_EXISTS(dto.email);

        //         //this checks which result the check for the user in the database was and returns the result
        //         if (res != true)
        //         {
        //             return NotFound($"{res} at {DateTime.Now} - User could not be found with email '{dto.email}'");
        //         }
        //         else
        //         {
        //             // return Ok(new MyToken.token().Generate_MINTSOUP_JWTtoken(email, "true"));
        //             string? myToken = await this.user.LOGIN_USER_to_get_TOKEN_w_email(dto.email, dto.password);
        //             if(myToken != null)
        //             {
        //                 return Ok(myToken);
        //             }
        //             else
        //             {
        //                 return Found(myToken);
        //             }
        //         }
        //     }
        //     else
        //     {
        //         return BadRequest("That was a bad request");
        //     }
        // }



        // POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)//the response is in the header - header response for the token by email or username and password
        //{
        //}

        [HttpGet]
        public ActionResult<bool> Get()
        {
            return Ok(true);
        }

    }
}

