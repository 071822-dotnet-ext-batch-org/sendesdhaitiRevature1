using MS_API1_Users_Repo;

namespace MS_API1_Users_LogicLayer;
public class Users_LogicLayer
{
    private readonly GET_AccessLayer _User_Repo;
    public Users_LogicLayer(GET_AccessLayer _user_repo)
    {
        this._User_Repo = _user_repo;
    }
    public async Task<Models.Viewer?> GET_myViewer_by_auth0ID(Models.GET_with_anAuth0ID_DTO? getViewerDTO)
    {
        Models.Viewer? viewer = await this._User_Repo.GET_myViewer_by_auth0ID(getViewerDTO);
        if (viewer != null)
        {
            return viewer;
        }
        else
        {
            return null;
        }
    }

}
