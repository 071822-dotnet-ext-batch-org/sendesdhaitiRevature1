namespace MINTSOUP.TokenAPI
{
    public interface IMSAlgos
    {
        (string, string) HashPassword(string password);
        bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt);
    }
}