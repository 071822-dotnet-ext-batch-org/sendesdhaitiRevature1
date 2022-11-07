namespace MINTSOUP.TokenAPI
{
    public interface Iuserservice
    {
        Task<(userservice.CHECKSTATUS, userservice.USERROLE)> CHECK_IF_Viewer_IS_ADMIN_by_Email(string? Email);
    }
}