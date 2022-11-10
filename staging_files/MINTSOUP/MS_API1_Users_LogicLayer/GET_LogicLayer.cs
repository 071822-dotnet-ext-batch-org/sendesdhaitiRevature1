using MS_API1_Users_Repo;
using MS_API1_Users_Model;
using Models;

namespace MS_API1_Users_LogicLayer;

public interface IGET_LogicLayer
{
    Task<(List<Viewer?>, string)> GET_allViewers_by_MSToken(string? MSToken);
    Task<(Viewer?, string)> GET_aViewer_by_MSToken_viewerID(string? MSToken, Guid? OBJID);
    Task<(Admin?, string)> GET_myAdmin_by_MSToken(string? MSToken);
    Task<(Viewer?, string)> GET_myViewer_by_MSToken(string? MSToken);
}

public class GET_LogicLayer : IGET_LogicLayer
{
    private readonly IGET_AccessLayer _get_Repo;
    public GET_LogicLayer(IGET_AccessLayer _get)
    {
        this._get_Repo = _get;
    }

    //----------------------------------------------GET my ADMIN SECTION--------------------------------------------------
    /// <summary>
    /// This logic method gets a nullable admin that is yours and a string response message - it needs (MSToken) 
    /// </summary>
    /// <param name="getViewerDTO"></param>
    /// <returns>an async Task<(Models.Viewer?, string)</returns>
    public async Task<(Models.Admin?, string)> GET_myAdmin_by_MSToken(string? MSToken)
    {
        Admin? admin = await this._get_Repo.GET_myAdmin_by_MSToken(MSToken);
        if (admin?.MSToken == MSToken)
        {
            return (admin, $"You got {admin?.Email}");
        }
        else
        {
            return (admin, $"You got an empty viewer");
        }
    }//END OF GET_myAdmin_by_MSToken


    //----------------------------------------------GET my VIEWER SECTION--------------------------------------------------
    /// <summary>
    /// This logic method gets a nullable viewer that is yours and a string response message - it needs (MSToken) 
    /// </summary>
    /// <param name="getViewerDTO"></param>
    /// <returns>an async Task<(Models.Viewer?, string)</returns>
    public async Task<(Models.Viewer?, string)> GET_myViewer_by_MSToken(string? MSToken)
    {
        Viewer? viewer = await this._get_Repo.GET_myViewer_by_MSToken(MSToken);
        if (viewer?.MSToken == MSToken)
        {
            Console.WriteLine($"\n\n\t\t Someone got '{viewer?.Email}' at '{DateTime.Now}' \n\n");
            return (viewer, $"You got {viewer?.Email}");
        }
        else
        {
            Console.WriteLine($"\n\n\t\t Someone tried to get '{MSToken}' at '{DateTime.Now}' \n\n");
            return (viewer, $"You got an empty viewer");
        }
    }//END OF GET_myViewer_by_MSToken

    //----------------------------------------------GET a VIEWER SECTION--------------------------------------------------
    /// <summary>
    /// This logic method gets a nullable viewer and a string response message - it needs (MSToken and viewerID) 
    /// </summary>
    /// <param name="getViewerDTO"></param>
    /// <returns>an async Task<(Models.Viewer?, string)</returns>
    public async Task<(Models.Viewer?, string)> GET_aViewer_by_MSToken_viewerID(string? MSToken, Guid? OBJID)
    {
        Viewer? viewer = await this._get_Repo.GET_aViewer_by_aViewerID(MSToken, OBJID);
        if (viewer?.MSToken == MSToken)
        {
            return (viewer, $"You got {viewer?.Email}");
        }
        else
        {
            return (viewer, $"You got an empty viewer");
        }
    }//END OF GET_aViewer_by_MSToken_viewerID

    //----------------------------------------------GET all VIEWERS SECTION--------------------------------------------------
    /// <summary>
    /// This logic method gets a nullable viewer and a string response message - it needs (MSToken and viewerID) 
    /// </summary>
    /// <param name="getViewerDTO"></param>
    /// <returns>an async Task<(Models.Viewer?, string)</returns>
    public async Task<(List<Viewer?>, string)> GET_allViewers_by_MSToken(string? MSToken)
    {
        List<Viewer?> viewers = await this._get_Repo.GET_allViewers(MSToken);
        if (viewers.Count > 0)
        {
            return (viewers, $"You got {viewers.Count} viewers");
        }
        else
        {
            return (viewers, $"You got an empty list of viewers..There are none");
        }
    }//END OF GET_aViewer_by_MSToken_viewerID

}
