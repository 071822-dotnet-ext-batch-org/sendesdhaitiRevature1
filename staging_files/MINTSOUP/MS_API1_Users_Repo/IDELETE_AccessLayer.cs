namespace MS_API1_Users_Repo
{
    public interface IDELETE_AccessLayer
    {
        Task<CHECK_AccessLayer.CHECKSTATUS> DELETE_myLike_on_ShowSession_by_MSToken(Guid? MSToken, Guid sessionID);
        Task<CHECK_AccessLayer.CHECKSTATUS> DELETE_myViewer_by_MSToken(Guid? MSToken);
    }
}