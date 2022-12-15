using MS_API1_Users_Repo;
using MS_API1_Users_Model;
using Models;

namespace MS_API1_Users_LogicLayer;

public interface IGET_LogicLayer
{
    //Task<(List<Viewer?>, string)> GET_allViewers_by_MSToken();
    //Task<(Viewer?, string)> GET_aViewer_by_MSToken_viewerID(string MSToken, Guid OBJID);
    //Task<(Admin?, string)> GET_myAdmin_by_MSToken(string MSToken);
    //Task<(Viewer?, string)> GET_myViewer_by_MSToken(string MSToken);
    Task<List<Show?>> GET_all_SHOWS(Guid? MSToken);
}

public class GET_LogicLayer : IGET_LogicLayer
{
    private readonly IGET_AccessLayer get_Repo;
    public GET_LogicLayer(IGET_AccessLayer _get)
    {
        this.get_Repo = _get;
    }

    public async Task<List<Show?>> GET_all_SHOWS(Guid? MSToken)
    {
       List<Show?> shows =  await this.get_Repo.GET_allShows(MSToken);
        if (shows.Any())
        {
            foreach(Show? show in shows)
            {
                if (show != null)
                {
                    Guid? viewerID = show.FK_ViewerID_Owner;
                    List<ShowSession?> Sessions = await this.get_Repo.GET_aShowsSessions(show.ID);
                    List<ShowSessionJoins?> SessionJoins = await this.get_Repo.GET_aShowsJoinSessions(show.ID);
                    List<ShowSubscriber?> Subscribers = await this.get_Repo.GET_aShowsSubscribers_by_showID(show.ID);
                    List<Follower?> Followers = await this.get_Repo.GET_aShowsFollowers_by_showID(show.ID);
                    List<ShowLikes?> ShowLikes = await this.get_Repo.GET_aShowsLikes_by_showID(show.ID);
                    List<ShowComment?> ShowComments = await this.get_Repo.GET_aShowsComments_by_showID(show.ID);
                    List<ShowDonation?> Donations = await this.get_Repo.GET_aShowsDonations_by_showID(show.ID);
                    show.Sessions = Sessions;
                    show.SessionJoins = SessionJoins;
                    show.Subscribers = Subscribers;
                    show.Followers = Followers;
                    show.ShowLikes = ShowLikes;
                    show.ShowComments = ShowComments;
                    show.Donations = Donations;
                    return shows;

    //show.

}
            }
            return shows;
        }
        else
        {
            return shows;
        }
    }

    ////----------------------------------------------GET my ADMIN SECTION--------------------------------------------------
    ///// <summary>
    ///// This logic method gets a nullable admin that is yours and a string response message - it needs (MSToken) 
    ///// </summary>
    ///// <param name="getViewerDTO"></param>
    ///// <returns>an async Task<(Models.Viewer?, string)</returns>
    //public async Task<(Models.Admin?, string)> GET_myAdmin_by_MSToken(string MSToken)
    //{
    //    Admin? admin = await this._get_Repo.GET_myAdmin_by_MSToken(MSToken);
    //    if (admin?.MSToken == new Guid(MSToken))
    //    {
    //        return (admin, $"You got {admin?.Email}");
    //    }
    //    else
    //    {
    //        return (admin, $"You got an empty viewer");
    //    }
    //}//END OF GET_myAdmin_by_MSToken


    ////----------------------------------------------GET my VIEWER SECTION--------------------------------------------------
    ///// <summary>
    ///// This logic method gets a nullable viewer that is yours and a string response message - it needs (MSToken) 
    ///// </summary>
    ///// <param name="getViewerDTO"></param>
    ///// <returns>an async Task<(Models.Viewer?, string)</returns>
    //public async Task<(Models.Viewer?, string)> GET_myViewer_by_MSToken(string MSToken)
    //{
    //    Viewer? viewer = await this._get_Repo.GET_myViewer_by_MSToken(MSToken);
    //    if (viewer?.MSToken == new Guid(MSToken))
    //    {
    //        Console.WriteLine($"\n\n\t\t Someone got '{viewer?.Email}' at '{DateTime.Now}' \n\n");
    //        return (viewer, $"You got {viewer?.Email}");
    //    }
    //    else
    //    {
    //        Console.WriteLine($"\n\n\t\t Someone tried to get '{MSToken}' at '{DateTime.Now}' \n\n");
    //        return (viewer, $"You got an empty viewer");
    //    }
    //}//END OF GET_myViewer_by_MSToken

    ////----------------------------------------------GET a VIEWER SECTION--------------------------------------------------
    ///// <summary>
    ///// This logic method gets a nullable viewer and a string response message - it needs (MSToken and viewerID) 
    ///// </summary>
    ///// <param name="getViewerDTO"></param>
    ///// <returns>an async Task<(Models.Viewer?, string)</returns>
    //public async Task<(Models.Viewer?, string)> GET_aViewer_by_MSToken_viewerID(string MSToken, Guid OBJID)
    //{
    //    Viewer? viewer = await this._get_Repo.GET_aViewer_by_aViewerID(MSToken, OBJID);
    //    if (viewer?.MSToken == new Guid(MSToken))
    //    {
    //        return (viewer, $"You got {viewer?.Email}");
    //    }
    //    else
    //    {
    //        return (viewer, $"You got an empty viewer");
    //    }
    //}//END OF GET_aViewer_by_MSToken_viewerID

    ////----------------------------------------------GET all VIEWERS SECTION--------------------------------------------------
    ///// <summary>
    ///// This logic method gets a nullable viewer and a string response message - it needs (MSToken and viewerID) 
    ///// </summary>
    ///// <param name="getViewerDTO"></param>
    ///// <returns>an async Task<(Models.Viewer?, string)</returns>
    //public async Task<(List<Viewer?>, string)> GET_allViewers_by_MSToken()
    //{
    //    List<Viewer?> viewers = await this._get_Repo.GET_allViewers();
    //    if (viewers.Count > 0)
    //    {
    //        return (viewers, $"You got {viewers.Count} viewers");
    //    }
    //    else
    //    {
    //        return (viewers, $"You got an empty list of viewers..There are none");
    //    }
    //}//END OF GET_aViewer_by_MSToken_viewerID

}
