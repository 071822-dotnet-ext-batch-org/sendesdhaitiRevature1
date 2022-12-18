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
using Microsoft.AspNetCore.Authorization;//to authorize with jwt token

using System.Data.SqlClient;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Cors;
using static MINTSOUP.TokenAPI.Controllers.MyToken;


namespace MINTSOUP.TokenAPI.Controllers
{
    [EnableCors("MyAllowAllOrigins")]
    [Route("mint-soup.token")]
    [Authorize]
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
            public string Generate_MINTSOUP_JWTtoken( MintSoupToken token)
            {
                var MINTSOUP_securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes($"MINTSOUP|BY|SENDES"));
                var token_credentials = new SigningCredentials(MINTSOUP_securityKey, SecurityAlgorithms.HmacSha256);
                var myclaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Iss, "MINTSOUP"),
                    new Claim(JwtRegisteredClaimNames.Sid, token.Id.ToString() ?? "NotSignedIn"),//TODO - we should check if the user's credentials say they are admin/viewer/guest/or none
                    new Claim(JwtRegisteredClaimNames.Email, token.Email ?? ""),
                    new Claim(JwtRegisteredClaimNames.UniqueName, token.Username ?? ""),
                    new Claim(JwtRegisteredClaimNames.AuthTime, token.LastSignedIn.ToString()),
                    new Claim(JwtRegisteredClaimNames.Exp, DateTime.Now.AddHours(12).ToString())

                };

                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:7215",
                    audience: "http://localhost:7215",
                    claims: myclaims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: token_credentials
                );
                return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            }

            public JwtSecurityToken? Extract_JWT_claims(string MSToken)
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(MSToken);
                return token;
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
        [AllowAnonymous]
        [HttpGet("check-email/{email}")]
        public async Task<ActionResult<bool>> CHECK_IF_EMAIL_EXISTS([FromRoute] string email)
        {
            if ( token.IsValidEmail(email) == true)
            {
                //this checks if the user exists and returns the user's role if so
                bool res = await this.user.CHECK_IF_EMAIL_EXISTS(email);

                //this checks which result the check for the user in the database was and returns the result
                if (res)
                {
                    Console.WriteLine($"{res} at {DateTime.Now} to CHECK for email '{email}'");
                    return Ok(true);
                }
                else
                {
                    Console.WriteLine($"{res} at {DateTime.Now} to CHECK for email '{email}'");
                    return NotFound(false);
                }
            }
            else return BadRequest($"The email input of '{email}' is not a valid email");
        }

        [AllowAnonymous]
        [HttpGet("check-username/{username}")]
        public async Task<ActionResult<bool>> CHECK_IF_USERNAME_EXISTS( [FromRoute] string username)
        {
            //this checks if the user exists
            bool res = await this.user.CHECK_IF_USERNAME_EXISTS(username);

            //this checks which result the check for the user in the database was
            if (!res)
            {
                Console.WriteLine($"{res} at {DateTime.Now} to CHECK for username '{username}'");
                return NotFound(false);
            }
            Console.WriteLine($"{res} at {DateTime.Now} to CHECK for username '{username}'");
            return Ok(true);
            
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult<bool>> CREATE_USER_ON_SIGNUP( [FromBody] Models.SignUpDTO dto)
        {
            if(ModelState.IsValid)
            {
                //this checks if the user exists and returns the user's role if so
                dto.email = dto.email.ToLowerInvariant();
                dto.username = dto.username.ToLowerInvariant();
                bool check_email = await this.user.CHECK_IF_EMAIL_EXISTS(dto.email);
                bool check_username = await this.user.CHECK_IF_USERNAME_EXISTS(dto.username);
                //this checks which result the check for the user in the database was and returns the result

                //Check if the username exists
                if(check_username == true) { return Conflict($"{check_username} at {DateTime.Now} - The username '{dto.username}' exists already"); }

                if (check_email  == true)
                {
                    Console.WriteLine($"{check_email} at {DateTime.Now} to SIGNUP with '{dto.email}'");
                    return Conflict($"{check_email} at {DateTime.Now} - User could not be created because the user with email '{dto.email}' already exists");
                }
                // (string, string) hashedPassword = this.msALGOS.HashPassword(dto.password);
                bool res = await this.user.CREATE_USER_ON_SIGNUP(dto.email, dto.username,dto.password);
                if(res)
                {
                    Console.WriteLine($"{res} at {DateTime.Now} to SIGNUP with '{dto.email}' - 'could not get token'");
                    return Created($"{dto.username}", "your account was created successfully");
                }
                else
                {
                    Console.WriteLine($"{res} at {DateTime.Now} to SIGNUP with '{dto.email}'");
                    return Conflict($"{res} at {DateTime.Now} - User could not be created due to an error with email '{dto.email}' and username '{dto.username}'");
                }
            }
            else
            {
                Console.WriteLine($"badrequest at {DateTime.Now} to SIGNUP with '{dto.email}'");
                return BadRequest("That was a bad request");
            }
        }

        [AllowAnonymous]
        [HttpPost("login-username")]
        public async Task<ActionResult<JwtSecurityToken?>> LOGIN_w_username([FromBody] Models.LoginDTO_w_username dto)
        {
            if(ModelState.IsValid)
            {
                //this checks if the user exists and returns the user's role if so
                dto.username = dto.username.ToLowerInvariant();
                bool res = await this.user.CHECK_IF_USERNAME_EXISTS(dto.username);

                //this checks which result the check for the user in the database was and returns the result
                if (res)
                {
                    MintSoupToken? login_check = await this.user.LOGIN_USER_to_get_TOKEN_w_username(dto.username, dto.password);
                    if(login_check != null)
                    {
                        //Console.WriteLine($"{myMSToken?.Id}, {myMSToken?.Email}, {myMSToken?.Username} was gotten from token at {DateTime.Now} to LOGIN with '{dto.username}'");
                        if (login_check.Username == dto.username)
                        {
                            Console.WriteLine($"{login_check.Id} at {DateTime.Now} to LOGIN with '{dto.username}' - 'got token'");
                            string newToken = new MyToken.token().Generate_MINTSOUP_JWTtoken(login_check);
                            return Ok(new { Token = newToken });
                        }
                        Console.WriteLine($"{login_check} at {DateTime.Now} to LOGIN with '{dto.username}' - 'could not get token'");
                        return Ok($"At {DateTime.Now} - '{dto.username}' your account could not be retrieved");
                    }
                    else
                    {
                        Console.WriteLine($"{login_check} at {DateTime.Now} to LOGIN with '{dto.username}'");
                        return Conflict($"{res} at {DateTime.Now} - User already exists with username '{dto.username}'");
                    }
                }
                else
                {
                    return NotFound($"{res} at {DateTime.Now} - User could not be found with username '{dto.username}'");
                }
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }

        [AllowAnonymous]
        [HttpPost("login-email")]
        public async Task<ActionResult<JwtSecurityToken?>> LOGIN_w_email([FromBody] Models.LoginDTO_w_email dto)
        {
            if(ModelState.IsValid)
            {
                //this checks if the user exists and returns the user's role if so
                dto.email = dto.email.ToLowerInvariant();
                bool res = await this.user.CHECK_IF_EMAIL_EXISTS(dto.email);

                //this checks which result the check for the user in the database was and returns the result
                if (res)
                {
                    MintSoupToken? login_check = await this.user.LOGIN_USER_to_get_TOKEN_w_email(dto.email, dto.password);
                    if (login_check != null)
                    {
                        //Console.WriteLine($"{myMSToken?.Id}, {myMSToken?.Email}, {myMSToken?.Username} was gotten from token at {DateTime.Now} to LOGIN with '{dto.username}'");
                        if (login_check.Email == dto.email)
                        {
                            Console.WriteLine($"{login_check.Id} at {DateTime.Now} to LOGIN with '{dto.email}' - 'got token'");
                            string newToken = new MyToken.token().Generate_MINTSOUP_JWTtoken(login_check);
                            return Ok(new { Token = newToken });
                        }
                        Console.WriteLine($"{login_check} at {DateTime.Now} to LOGIN with '{dto.email}' - 'could not get token'");
                        return Ok($"At {DateTime.Now} - '{dto.email}' your account could not be retrieved");
                    }
                    else
                    {
                        Console.WriteLine($"{login_check} at {DateTime.Now} to LOGIN with '{dto.email}'");
                        return Conflict($"{res} at {DateTime.Now} - User already exists with email '{dto.email}'");
                    }
                }
                else
                {
                    return NotFound($"{res} at {DateTime.Now} - User could not be found with email '{dto.email}'");
                }
            }
            else
            {
                return BadRequest("That was a bad request");
            }
        }

        [HttpGet]
        public ActionResult<bool> Get()
        {
            return Ok(true);
        }

    }
}

