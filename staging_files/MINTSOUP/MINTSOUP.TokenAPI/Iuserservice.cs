using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MINTSOUP.TokenAPI
{
    public interface Iuserservice
    {
        Task<bool> CHECK_IF_EMAIL_EXISTS(string Email);
        Task<bool> CHECK_IF_USERNAME_EXISTS(string Username);
        Task<bool> CREATE_USER_ON_SIGNUP(string Email, string Username, string Password);
        Task<MintSoupToken?> LOGIN_USER_to_get_TOKEN_w_email(string Email, string Password);
        Task<MintSoupToken?> LOGIN_USER_to_get_TOKEN_w_username(string Username, string Password);

    }

    /// <summary>
    /// This is the model to represent a token
    /// </summary>
    public class MintSoupToken
    {
        private static Guid mstokenid;
        private static string? email;
        private static string? username;
        private static string? password;
        private static DateTime dateSignedUp;
        private static DateTime lastSignedIn;

        public   Guid Id { get => mstokenid;  }
        public   string? Email { get => email;  }
        public   string? Username { get => username; }
        public   string? Password { get => password;  }
        public   DateTime DateSignedUp { get => dateSignedUp; }
        public   DateTime LastSignedIn { get => lastSignedIn;  }
        public MintSoupToken() { }
        public MintSoupToken(Guid _id, string _em, string _us)
        {
            mstokenid = _id;
            email = _em;
            username = _us;
        }
        public MintSoupToken(Guid _id, string _em, string _us, string _pass,  DateTime _ds, DateTime _ls)
        {
            //Console.WriteLine($"This is the token constructor for {_em}");
            mstokenid = _id;
            email = _em;
            username = _us;
            password = _pass;
            dateSignedUp = _ds;
            lastSignedIn = DateTime.Now;
        }
    }
}