namespace MINTSOUP.TokenAPI
{
    public interface Iuserservice
    {
        Task<bool> CHECK_IF_EMAIL_EXISTS(string Email);
        Task<bool> CHECK_IF_USERNAME_EXISTS(string Username);
        Task<bool> CREATE_USER_ON_SIGNUP(string Email, string Username, string Password);
        Task<bool> CHANGE_PASSWORD_w_email_and_token(string Email, string MSToken, string Password);
        Task<string?> LOGIN_USER_to_get_TOKEN_w_email(string Email, string Password);
        Task<string?> LOGIN_USER_to_get_TOKEN_w_username(string Username, string Password);
    }
}