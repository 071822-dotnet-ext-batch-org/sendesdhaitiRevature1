using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
// using MS_API1_Users_Model;
namespace MS_API1_Users_Repo;
public class GET_AccessLayer
{
    private readonly IConfiguration _config;
    private readonly SqlConnection _conn;

    public GET_AccessLayer(IConfiguration config)
    {
        _config = config;

        
        if (string.Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "Development", StringComparison.InvariantCultureIgnoreCase))
        {
            _conn = new SqlConnection(_config["ConnectionStrings:Development"]);
        }
        else
        {
            _conn = new SqlConnection(_config["ConnectionStrings:ProductionString"]);
        }    

    }

//-----------------------GET VIEWER SECTION---------------------
    public async Task<List<Models.Viewer?>> GET_allViewers(Models.GET_with_anAuth0ID_DTO? getViewerDTO)
    {
        List<Models.Viewer?> listOfViewers = new List<Models.Viewer?>();
        if(getViewerDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Viewers Order By LastSignedIn DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.Viewer viewer = new Models.Viewer();
                        viewer.ID = ret.GetGuid(0);
                        viewer.Auth0ID = ret.GetString(1);
                        viewer.Fn = ret.GetString(2);
                        viewer.Ln = ret.GetString(3);
                        viewer.Email = ret.GetString(4);
                        viewer.Image = ret.GetString(5);
                        viewer.Username =  ret.GetString(6);
                        viewer.AboutMe =  ret.GetString(7);
                        viewer.StreetAddy =  ret.GetString(8);
                        viewer.City =  ret.GetString(9);
                        viewer.State = ret.GetString(10);
                        viewer.Country = ret.GetString(11);
                        viewer.AreaCode =  ret.GetInt32(12);

                        if(ret.GetString(13) == "Viewer"){viewer.Role = Models.Role.Viewer;}
                        else if(ret.GetString(13) == "Host"){viewer.Role = Models.Role.Host;}
                        else if(ret.GetString(13) == "Admin"){viewer.Role = Models.Role.Admin;}
                        else viewer.Role = Models.Role.Viewer;

                        if(ret.GetString(14) == "Viewer"){viewer.MembershipStatus = Models.ViewerStatus.Viewer;}
                        else viewer.MembershipStatus = Models.ViewerStatus.Guest;

                        viewer.DateSignedUp =  ret.GetDateTime(15);
                        viewer.LastSignedIn =  ret.GetDateTime(16);
                        listOfViewers.Add(viewer);
                    }

                    _conn.Close();
                    return listOfViewers;
                }
                else
                {
                    _conn.Close();
                    return listOfViewers;
                }
            }
        }
        else
        {
            return listOfViewers;
        }
    }//End of GET_allViewers

    public async Task<Models.Viewer?> GET_myViewer_by_auth0ID(Models.GET_with_anAuth0ID_DTO? getViewerDTO)
    {
        if(getViewerDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Viewers Where Auth0ID = @Auth0ID", _conn))
            {
                command.Parameters.AddWithValue("@Auth0ID", getViewerDTO?.Auth0ID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Models.Viewer viewer = new Models.Viewer();
                    viewer.ID = ret.GetGuid(0);
                    viewer.Auth0ID = ret.GetString(1);
                    viewer.Fn = ret.GetString(2);
                    viewer.Ln = ret.GetString(3);
                    viewer.Email = ret.GetString(4);
                    viewer.Image = ret.GetString(5);
                    viewer.Username =  ret.GetString(6);
                    viewer.AboutMe =  ret.GetString(7);
                    viewer.StreetAddy =  ret.GetString(8);
                    viewer.City =  ret.GetString(9);
                    viewer.State = ret.GetString(10);
                    viewer.Country = ret.GetString(11);
                    viewer.AreaCode =  ret.GetInt32(12);
                    if(ret.GetString(13) == "Viewer"){viewer.Role = Models.Role.Viewer;}
                    else if(ret.GetString(13) == "Host"){viewer.Role = Models.Role.Host;}
                    else if(ret.GetString(13) == "Admin"){viewer.Role = Models.Role.Admin;}
                    else viewer.Role = Models.Role.Viewer;

                    if(ret.GetString(14) == "Viewer"){viewer.MembershipStatus = Models.ViewerStatus.Viewer;}
                    else viewer.MembershipStatus = Models.ViewerStatus.Guest;

                    viewer.DateSignedUp =  ret.GetDateTime(15);
                    viewer.LastSignedIn =  ret.GetDateTime(16);

                    _conn.Close();
                    return viewer;
                }
                else
                {
                    _conn.Close();
                    return null;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of Get_Viewer_by_auth0ID

    public async Task<Models.Viewer?> GET_aViewer_by_aViewerID(Models.GET_anOBJ_by_1GUID_with_auth0ID? getViewerDTO)
    {
        if((getViewerDTO?.Auth0ID != null) && (getViewerDTO?.OBJID != null))
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Viewers Where ID = @ID", _conn))
            {
                command.Parameters.AddWithValue("@ID", getViewerDTO?.OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Models.Viewer viewer = new Models.Viewer();
                    viewer.ID = ret.GetGuid(0);
                    viewer.Auth0ID = ret.GetString(1);
                    viewer.Fn = ret.GetString(2);
                    viewer.Ln = ret.GetString(3);
                    viewer.Email = ret.GetString(4);
                    viewer.Image = ret.GetString(5);
                    viewer.Username =  ret.GetString(6);
                    viewer.AboutMe =  ret.GetString(7);
                    viewer.StreetAddy =  ret.GetString(8);
                    viewer.City =  ret.GetString(9);
                    viewer.State = ret.GetString(10);
                    viewer.Country = ret.GetString(11);
                    viewer.AreaCode =  ret.GetInt32(12);
                    if(ret.GetString(13) == "Viewer"){viewer.Role = Models.Role.Viewer;}
                    else if(ret.GetString(13) == "Host"){viewer.Role = Models.Role.Host;}
                    else if(ret.GetString(13) == "Admin"){viewer.Role = Models.Role.Admin;}
                    else viewer.Role = Models.Role.Viewer;


                    if(ret.GetString(14) == "Viewer"){viewer.MembershipStatus = Models.ViewerStatus.Viewer;}
                    else viewer.MembershipStatus = Models.ViewerStatus.Guest;

                    viewer.DateSignedUp =  ret.GetDateTime(15);
                    viewer.LastSignedIn =  ret.GetDateTime(16);
                    

                    _conn.Close();
                    return viewer;
                }
                else
                {
                    _conn.Close();
                    return null;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aViewer_by_aViewerID

//-----------------------GET ADMIN SECTION---------------------
    public async Task<Models.Admin?> GET_myAdmin_by_auth0ID(Models.GET_with_anAuth0ID_DTO? getAdminDTO)
    {
        if(getAdminDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Admins Where Auth0ID = @Auth0ID", _conn))
            {
                command.Parameters.AddWithValue("@Auth0ID", getAdminDTO?.Auth0ID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Models.Admin admin = new Models.Admin();
                    admin.ID = ret.GetGuid(0);
                    admin.Auth0ID = ret.GetString(1);
                    admin.Email = ret.GetString(2);
                    admin.Username =  ret.GetString(3);

                    if(ret.GetString(4) == "Admin"){admin.AdminStatus = Models.AdminStatus.Admin;}
                    else{
                        admin.AdminStatus = Models.AdminStatus.NonAdmin;
                    }
                    

                    admin.DateCreated =  ret.GetDateTime(5);
                    admin.LastSignedIn =  ret.GetDateTime(6);

                    _conn.Close();
                    return admin;
                }
                else
                {
                    _conn.Close();
                    return null;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_myAdmin_by_auth0ID

//-----------------------GET FRIEND SECTION---------------------
    public async Task<List<Models.Friend?>> GET_allFriends(Models.GET_with_anAuth0ID_DTO? getFriendsDTO)
    {
        List<Models.Friend?> friendsList = new List<Models.Friend?>();
        if(getFriendsDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Friends Order By FriendUpdateDate DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.Friend friend = new Models.Friend();

                        friend.ID = ret.GetGuid(0);
                        friend.FK_ViewerID_Friender = ret.GetGuid(1);
                        friend.FK_ViewerID_Friendie = ret.GetGuid(2);

                        if(ret.GetString(3) == "Friend"){friend.FriendshipStatus = Models.FriendShipStatus.Friend;}
                        else if(ret.GetString(3) == "PendingFriend"){friend.FriendshipStatus = Models.FriendShipStatus.PendingFriend;}
                        else if(ret.GetString(3) == "UnFriended"){friend.FriendshipStatus = Models.FriendShipStatus.UnFriended;}
                        else friend.FriendshipStatus = Models.FriendShipStatus.Friend;

                        friend.FriendDate = ret.GetDateTime(4);
                        friend.FriendshipUpdateDate = ret.GetDateTime(5);

                        friendsList.Add(friend);
                    }
                    _conn.Close();
                    return friendsList;
                }
                else
                {
                    _conn.Close();
                    return friendsList;
                }
            }
        }
        else
        {
            return friendsList;
        }
    }//End of GET_allFriends

    public async Task<List<Models.Friend?>> GET_myFriends_by_ViewerID_Freinder(Models.GET_with_anAuth0ID_DTO? getMyFriendsDTO)
    {
        List<Models.Friend?> friendsList = new List<Models.Friend?>();
        if(getMyFriendsDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Friends Where FK_ViewerID_Friender = (select ID from Viewers Where Auth0ID = @Auth0ID) Order By FriendUpdateDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@Auth0ID", getMyFriendsDTO?.Auth0ID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.Friend friend = new Models.Friend();

                        friend.ID = ret.GetGuid(0);
                        friend.FK_ViewerID_Friender = ret.GetGuid(1);
                        friend.FK_ViewerID_Friendie = ret.GetGuid(2);

                        if(ret.GetString(3) == "Friend"){friend.FriendshipStatus = Models.FriendShipStatus.Friend;}
                        else if(ret.GetString(3) == "PendingFriend"){friend.FriendshipStatus = Models.FriendShipStatus.PendingFriend;}
                        else if(ret.GetString(3) == "UnFriended"){friend.FriendshipStatus = Models.FriendShipStatus.UnFriended;}
                        else friend.FriendshipStatus = Models.FriendShipStatus.Friend;

                        friend.FriendDate = ret.GetDateTime(4);
                        friend.FriendshipUpdateDate = ret.GetDateTime(5);

                        friendsList.Add(friend);
                    }
                    _conn.Close();
                    return friendsList;
                }
                else
                {
                    _conn.Close();
                    return friendsList;
                }
            }
        }
        else
        {
            return friendsList;
        }
    }//End of Get_myFriends_by_ViewerID_Freinder

    public async Task<Models.Friend?> GET_aFriend_by_ViewerID_Freinder(Models.GET_Friend_with_ViewerID_Friender? getFriendDTO)
    {
        if(getFriendDTO?.FK_ViewerID_Friender != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Friends Where ID = @ID AND FK_ViewerID_Friender = @FK_ViewerID_Friender ", _conn))
            {
                command.Parameters.AddWithValue("@ID", getFriendDTO?.FriendID);
                command.Parameters.AddWithValue("@FK_ViewerID_Friender", getFriendDTO?.FK_ViewerID_Friender);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Models.Friend friend = new Models.Friend();

                    friend.ID = ret.GetGuid(0);
                    friend.FK_ViewerID_Friender = ret.GetGuid(1);
                    friend.FK_ViewerID_Friendie = ret.GetGuid(2);

                    if(ret.GetString(3) == "Friend"){friend.FriendshipStatus = Models.FriendShipStatus.Friend;}
                    else if(ret.GetString(3) == "PendingFriend"){friend.FriendshipStatus = Models.FriendShipStatus.PendingFriend;}
                    else if(ret.GetString(3) == "UnFriended"){friend.FriendshipStatus = Models.FriendShipStatus.UnFriended;}
                    else friend.FriendshipStatus = Models.FriendShipStatus.Friend;

                    friend.FriendDate = ret.GetDateTime(4);
                    friend.FriendshipUpdateDate = ret.GetDateTime(5);

                    _conn.Close();
                    return friend;
                }
                else
                {
                    _conn.Close();
                    return null;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aFriend_by_ViewerID_Freinder



//-----------------------GET FOLLOWER SECTION---------------------
    public async Task<List<Models.Follower?>> GET_allFollowers(Models.GET_with_anAuth0ID_DTO? getFollowersDTO)
    {
        List<Models.Follower?> followerList = new List<Models.Follower?>();
        if(getFollowersDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Followers Where Order By StatusUpdateDate DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.Follower follower = new Models.Follower();

                        follower.ID = ret.GetGuid(0);
                        follower.FK_ViewerID_Follower = ret.GetGuid(1);
                        follower.FK_ViewerID_Followie = ret.GetGuid(2);
                        follower.FK_ShowID_Followie = ret.GetGuid(3);

                        if(ret.GetString(4) == "Follower"){follower.FollowerStatus = Models.FollowerStatus.Follower;}
                        else if(ret.GetString(4) == "UnFollowed"){follower.FollowerStatus = Models.FollowerStatus.UnFollowed;}
                        else if(ret.GetString(4) == "NonFollower"){follower.FollowerStatus = Models.FollowerStatus.NonFollower;}
                        else follower.FollowerStatus = Models.FollowerStatus.Follower;

                        follower.FollowDate = ret.GetDateTime(5);
                        follower.StatusUpdateDate = ret.GetDateTime(6);
                        followerList.Add(follower);
                    }
                    _conn.Close();
                    return followerList;
                }
                else
                {
                    _conn.Close();
                    return followerList;
                }
            }
        }
        else
        {
            return followerList;
        }
    }//End of GET_allFollowers

    public async Task<List<Models.Follower?>> GET_myFollowers_by_ViewerID_Follower(Models.GET_with_anAuth0ID_DTO? getMyFollowersDTO)
    {
        List<Models.Follower?> followerList = new List<Models.Follower?>();
        if(getMyFollowersDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Followers Where FK_ViewerID_Follower = (select ID from Viewers Where Auth0ID = @Auth0ID) Order By FollowDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@Auth0ID", getMyFollowersDTO?.Auth0ID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.Follower follower = new Models.Follower();

                        follower.ID = ret.GetGuid(0);
                        follower.FK_ViewerID_Follower = ret.GetGuid(1);
                        follower.FK_ViewerID_Followie = ret.GetGuid(2);
                        follower.FK_ShowID_Followie = ret.GetGuid(3);

                        if(ret.GetString(4) == "Follower"){follower.FollowerStatus = Models.FollowerStatus.Follower;}
                        else if(ret.GetString(4) == "UnFollowed"){follower.FollowerStatus = Models.FollowerStatus.UnFollowed;}
                        else if(ret.GetString(4) == "NonFollower"){follower.FollowerStatus = Models.FollowerStatus.NonFollower;}
                        else follower.FollowerStatus = Models.FollowerStatus.Follower;

                        follower.FollowDate = ret.GetDateTime(5);
                        follower.StatusUpdateDate = ret.GetDateTime(6);
                        followerList.Add(follower);
                    }
                    _conn.Close();
                    return followerList;
                }
                else
                {
                    _conn.Close();
                    return followerList;
                }
            }
        }
        else
        {
            return followerList;
        }
    }//End of Get_myFollowers_by_ViewerID_Follower

    public async Task<Models.Follower?> GET_aFollower_by_ViewerID_Follower(Models.GET_aFollower_with_ViewerID_Follower? getAFollowerDTO)
    {
        Models.Follower follower = new Models.Follower();
        if(getAFollowerDTO?.ViewerID_Follower != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Followers Where ID = @ID AND FK_ViewerID_Follower = @FK_ViewerID_Follower ", _conn))
            {
                command.Parameters.AddWithValue("@ID", getAFollowerDTO?.FollowerID);
                command.Parameters.AddWithValue("@FK_ViewerID_Follower", getAFollowerDTO?.ViewerID_Follower);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {

                    follower.ID = ret.GetGuid(0);
                    follower.FK_ViewerID_Follower = ret.GetGuid(1);
                    follower.FK_ViewerID_Followie = ret.GetGuid(2);
                    follower.FK_ShowID_Followie = ret.GetGuid(3);

                    if(ret.GetString(4) == "Follower"){follower.FollowerStatus = Models.FollowerStatus.Follower;}
                    else if(ret.GetString(4) == "UnFollowed"){follower.FollowerStatus = Models.FollowerStatus.UnFollowed;}
                    else if(ret.GetString(4) == "NonFollower"){follower.FollowerStatus = Models.FollowerStatus.NonFollower;}
                    else follower.FollowerStatus = Models.FollowerStatus.Follower;

                    follower.FollowDate = ret.GetDateTime(5);
                    follower.StatusUpdateDate = ret.GetDateTime(6);
                    _conn.Close();
                    return follower;
                }
                else
                {
                    _conn.Close();
                    return follower;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aFollower_by_ViewerID_Follower

//-----------------------GET SHOWS SECTION---------------------
    public async Task<List<Models.Show?>> GET_allShows(Models.GET_with_anAuth0ID_DTO getShowsDTO)
    {
        List<Models.Show?> createdShowsList = new List<Models.Show?>();
        if(getShowsDTO.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Shows Where Order By LastLive DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.Show show = new Models.Show();

                        show.ID = ret.GetGuid(0);
                        show.FK_ViewerID_Owner = ret.GetGuid(1);
                        show.ShowName = ret.GetString(2);
                        show.ShowImage = ret.GetString(3);
                        show.Views = ret.GetInt32(4);
                        show.Likes = ret.GetInt32(5);
                        show.Comments = ret.GetInt32(6);
                        show.Rating = ret.GetDouble(7);
                        show.Rank = ret.GetInt32(8);

                        if(ret.GetString(9) == "Private"){show.PrivacyLevel = Models.PrivacyLevel.Private;}
                        else if(ret.GetString(9) == "Exclusive"){show.PrivacyLevel = Models.PrivacyLevel.Exclusive;}
                        else if(ret.GetString(9) == "Public"){show.PrivacyLevel = Models.PrivacyLevel.Public;}
                        else show.PrivacyLevel = Models.PrivacyLevel.Private;

                        if(ret.GetString(10) == "Pending"){show.ShowStatus = Models.ShowStanding.Pending;}
                        else if(ret.GetString(10) == "Great"){show.ShowStatus = Models.ShowStanding.Great;}
                        else if(ret.GetString(10) == "Good"){show.ShowStatus = Models.ShowStanding.Good;}
                        else if(ret.GetString(10) == "Moderate"){show.ShowStatus = Models.ShowStanding.Moderate;}
                        else if(ret.GetString(10) == "Bad"){show.ShowStatus = Models.ShowStanding.Bad;}
                        else if(ret.GetString(10) == "Deactivated"){show.ShowStatus = Models.ShowStanding.Deactivated;}
                        else{show.ShowStatus = Models.ShowStanding.Banned;}

                        show.DateCreated = ret.GetDateTime(10);
                        show.LastLive = ret.GetDateTime(11);

                        createdShowsList.Add(show);
                    }
                    _conn.Close();
                    return createdShowsList;
                }
                else
                {
                    _conn.Close();
                    return createdShowsList;
                }
            }
        }
        else
        {
            return createdShowsList;
        }
    }//End of GET_allShows

    public async Task<List<Models.Show?>> GET_myShows_by_ViewerID_Owner(Models.GET_with_anAuth0ID_DTO? Owner)
    {
        List<Models.Show?> createdShowsList = new List<Models.Show?>();
        if(Owner?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Shows Where FK_ViewerID_Owner = (select ID from Viewers Where Auth0ID = @Auth0ID) Order By LastLive DESC", _conn))
            {
                command.Parameters.AddWithValue("@Auth0ID", Owner.Auth0ID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.Show show = new Models.Show();

                        show.ID = ret.GetGuid(0);
                        show.FK_ViewerID_Owner = ret.GetGuid(1);
                        show.ShowName = ret.GetString(2);
                        show.ShowImage = ret.GetString(3);
                        show.Views = ret.GetInt32(4);
                        show.Likes = ret.GetInt32(5);
                        show.Comments = ret.GetInt32(6);
                        show.Rating = ret.GetDouble(7);
                        show.Rank = ret.GetInt32(8);

                        if(ret.GetString(9) == "Private"){show.PrivacyLevel = Models.PrivacyLevel.Private;}
                        else if(ret.GetString(9) == "Exclusive"){show.PrivacyLevel = Models.PrivacyLevel.Exclusive;}
                        else if(ret.GetString(9) == "Public"){show.PrivacyLevel = Models.PrivacyLevel.Public;}
                        else show.PrivacyLevel = Models.PrivacyLevel.Private;

                        if(ret.GetString(10) == "Pending"){show.ShowStatus = Models.ShowStanding.Pending;}
                        else if(ret.GetString(10) == "Great"){show.ShowStatus = Models.ShowStanding.Great;}
                        else if(ret.GetString(10) == "Good"){show.ShowStatus = Models.ShowStanding.Good;}
                        else if(ret.GetString(10) == "Moderate"){show.ShowStatus = Models.ShowStanding.Moderate;}
                        else if(ret.GetString(10) == "Bad"){show.ShowStatus = Models.ShowStanding.Bad;}
                        else if(ret.GetString(10) == "Deactivated"){show.ShowStatus = Models.ShowStanding.Deactivated;}
                        else{show.ShowStatus = Models.ShowStanding.Banned;}

                        show.DateCreated = ret.GetDateTime(10);
                        show.LastLive = ret.GetDateTime(11);

                        createdShowsList.Add(show);
                    }
                    _conn.Close();
                    return createdShowsList;
                }
                else
                {
                    _conn.Close();
                    return createdShowsList;
                }
            }
        }
        else
        {
            return createdShowsList;
        }
    }//End of Get_myShows_by_ViewerID_Owner

    public async Task<Models.Show?> GET_aShow_by_ShowID_with_auth0ID(Models.GET_aShow_by_ShowID_with_auth0ID? getAShowDTO)
    {
        Models.Show show = new Models.Show();
        if(getAShowDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Shows Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", getAShowDTO?.ShowID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    show.ID = ret.GetGuid(0);
                    show.FK_ViewerID_Owner = ret.GetGuid(1);
                    show.ShowName = ret.GetString(2);
                    show.ShowImage = ret.GetString(3);
                    show.Views = ret.GetInt32(4);
                    show.Likes = ret.GetInt32(5);
                    show.Comments = ret.GetInt32(6);
                    show.Rating = ret.GetDouble(7);
                    show.Rank = ret.GetInt32(8);

                    if(ret.GetString(9) == "Private"){show.PrivacyLevel = Models.PrivacyLevel.Private;}
                    else if(ret.GetString(9) == "Exclusive"){show.PrivacyLevel = Models.PrivacyLevel.Exclusive;}
                    else if(ret.GetString(9) == "Public"){show.PrivacyLevel = Models.PrivacyLevel.Public;}
                    else show.PrivacyLevel = Models.PrivacyLevel.Private;

                    if(ret.GetString(10) == "Pending"){show.ShowStatus = Models.ShowStanding.Pending;}
                    else if(ret.GetString(10) == "Great"){show.ShowStatus = Models.ShowStanding.Great;}
                    else if(ret.GetString(10) == "Good"){show.ShowStatus = Models.ShowStanding.Good;}
                    else if(ret.GetString(10) == "Moderate"){show.ShowStatus = Models.ShowStanding.Moderate;}
                    else if(ret.GetString(10) == "Bad"){show.ShowStatus = Models.ShowStanding.Bad;}
                    else if(ret.GetString(10) == "Deactivated"){show.ShowStatus = Models.ShowStanding.Deactivated;}
                    else{show.ShowStatus = Models.ShowStanding.Banned;}

                    show.DateCreated = ret.GetDateTime(10);
                    show.LastLive = ret.GetDateTime(11);
                    _conn.Close();
                    return show;
                }
                else
                {
                    _conn.Close();
                    return show;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aShow_by_ShowID_with_auth0ID


//-----------------------GET SHOW SUBSCRIBERS SECTION---------------------
    public async Task<List<Models.ShowSubscriber?>> GET_allShowSubscriber(Models.GET_with_anAuth0ID_DTO? getShowSubscribersDTO)
    {
        List<Models.ShowSubscriber?> subscribedShowsList = new List<Models.ShowSubscriber?>();
        if(getShowSubscribersDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Subscribers Order By LastLive DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowSubscriber subscribedShow = new Models.ShowSubscriber();

                        subscribedShow.ID = ret.GetGuid(0);
                        subscribedShow.FK_ViewerID_Subscriber = ret.GetGuid(1);
                        subscribedShow.FK_ShowID_Subscribie = ret.GetGuid(2);
                        subscribedShow.FK_ShowSessionID = ret.GetGuid(3);

                        if(ret.GetString(4) == "Subscriber"){subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.Subscriber;}
                        else if(ret.GetString(4) == "UnSubscribed"){subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.UnSubscribed;}
                        else if(ret.GetString(4) == "PremiumMember"){subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.PremiumMember;}
                        else if(ret.GetString(4) == "ExclusiveMember"){subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.ExclusiveMember;}
                        else subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.Subscriber;

                        subscribedShow.SubscribeDate = ret.GetDateTime(5);
                        subscribedShow.SubscriptionUpdateDate = ret.GetDateTime(6);

                        subscribedShowsList.Add(subscribedShow);
                    }
                    _conn.Close();
                    return subscribedShowsList;
                }
                else
                {
                    _conn.Close();
                    return subscribedShowsList;
                }
            }
        }
        else
        {
            return subscribedShowsList;
        }
    }//End of GET_allShowSubscriber

    public async Task<List<Models.ShowSubscriber?>> GET_myShowSubscriptions_by_ViewerID_Subscriber(Models.GET_with_anAuth0ID_DTO? subscriber)
    {
        List<Models.ShowSubscriber?> subscribedShowsList = new List<Models.ShowSubscriber?>();
        if(subscriber?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Subscribers Where FK_ViewerID_Subscriber = (select ID from Viewers Where Auth0ID = @Auth0ID) Order By SubscriptionUpdateDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@Auth0ID", subscriber.Auth0ID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowSubscriber subscribedShow = new Models.ShowSubscriber();

                        subscribedShow.ID = ret.GetGuid(0);
                        subscribedShow.FK_ViewerID_Subscriber = ret.GetGuid(1);
                        subscribedShow.FK_ShowID_Subscribie = ret.GetGuid(2);
                        subscribedShow.FK_ShowSessionID = ret.GetGuid(3);

                        if(ret.GetString(4) == "Subscriber"){subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.Subscriber;}
                        else if(ret.GetString(4) == "UnSubscribed"){subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.UnSubscribed;}
                        else if(ret.GetString(4) == "PremiumMember"){subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.PremiumMember;}
                        else if(ret.GetString(4) == "ExclusiveMember"){subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.ExclusiveMember;}
                        else subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.Subscriber;

                        subscribedShow.SubscribeDate = ret.GetDateTime(5);
                        subscribedShow.SubscriptionUpdateDate = ret.GetDateTime(6);

                        subscribedShowsList.Add(subscribedShow);
                    }
                    _conn.Close();
                    return subscribedShowsList;
                }
                else
                {
                    _conn.Close();
                    return subscribedShowsList;
                }
            }
        }
        else
        {
            return subscribedShowsList;
        }
    }//End of Get_myShowSubscriptions_by_ViewerID_Subscriber

    public async Task<List<Models.ShowSubscriber?>> GET_myShowSubscribers_by_ShowID_Subscriber(Models.GET_anOBJ_by_1GUID_with_auth0ID? subscriber)
    {
        List<Models.ShowSubscriber?> subscribedShowsList = new List<Models.ShowSubscriber?>();
        if(subscriber?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Subscribers Where FK_ShowID_Subscribie = @FK_ShowID_Subscribie Order By SubscriptionUpdateDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@FK_ShowID_Subscribie", subscriber.OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowSubscriber subscribedShow = new Models.ShowSubscriber();

                        subscribedShow.ID = ret.GetGuid(0);
                        subscribedShow.FK_ViewerID_Subscriber = ret.GetGuid(1);
                        subscribedShow.FK_ShowID_Subscribie = ret.GetGuid(2);
                        subscribedShow.FK_ShowSessionID = ret.GetGuid(3);

                        if(ret.GetString(4) == "Subscriber"){subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.Subscriber;}
                        else if(ret.GetString(4) == "UnSubscribed"){subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.UnSubscribed;}
                        else if(ret.GetString(4) == "PremiumMember"){subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.PremiumMember;}
                        else if(ret.GetString(4) == "ExclusiveMember"){subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.ExclusiveMember;}
                        else subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.Subscriber;

                        subscribedShow.SubscribeDate = ret.GetDateTime(5);
                        subscribedShow.SubscriptionUpdateDate = ret.GetDateTime(6);

                        subscribedShowsList.Add(subscribedShow);
                    }
                    _conn.Close();
                    return subscribedShowsList;
                }
                else
                {
                    _conn.Close();
                    return subscribedShowsList;
                }
            }
        }
        else
        {
            return subscribedShowsList;
        }
    }//End of GET_myShowSubscribers_by_ShowID_Subscriber

    public async Task<Models.ShowSubscriber?> GET_aSubscriber_by_SubscriberID_with_auth0ID(Models.GET_aSubscriber_by_SubscriberID_with_auth0ID? getASubscriberDTO)
    {
        Models.ShowSubscriber showSubscriber = new Models.ShowSubscriber();
        if(getASubscriberDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Subscribers Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", getASubscriberDTO?.SubscriberID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    showSubscriber.ID = ret.GetGuid(0);
                    showSubscriber.FK_ViewerID_Subscriber = ret.GetGuid(1);
                    showSubscriber.FK_ShowID_Subscribie = ret.GetGuid(2);
                    showSubscriber.FK_ShowSessionID = ret.GetGuid(3);

                    if(ret.GetString(4) == "Subscriber"){showSubscriber.MembershipStatus = Models.SubscriberMembershipStatus.Subscriber;}
                    else if(ret.GetString(4) == "UnSubscribed"){showSubscriber.MembershipStatus = Models.SubscriberMembershipStatus.UnSubscribed;}
                    else if(ret.GetString(4) == "PremiumMember"){showSubscriber.MembershipStatus = Models.SubscriberMembershipStatus.PremiumMember;}
                    else if(ret.GetString(4) == "ExclusiveMember"){showSubscriber.MembershipStatus = Models.SubscriberMembershipStatus.ExclusiveMember;}
                    else showSubscriber.MembershipStatus = Models.SubscriberMembershipStatus.Subscriber;

                    showSubscriber.SubscribeDate = ret.GetDateTime(5);
                    showSubscriber.SubscriptionUpdateDate = ret.GetDateTime(6);

                    _conn.Close();
                    return showSubscriber;
                }
                else
                {
                    _conn.Close();
                    return showSubscriber;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aSubscriber_by_SubscriberID_with_auth0ID


//-----------------------GET SHOW LIKES SECTION---------------------
    public async Task<List<Models.ShowLikes?>> GET_allShowLikes(Models.GET_with_anAuth0ID_DTO? getShowLikes)
    {
        List<Models.ShowLikes?> showSessionLikes = new List<Models.ShowLikes?>();
        if(getShowLikes?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowLikes Order By LikeDate DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowLikes showLike = new Models.ShowLikes();
                        showLike.ID = ret.GetGuid(0);
                        showLike.FK_ViewerID_Liker = ret.GetGuid(1);
                        showLike.FK_ShowSessionID = ret.GetGuid(2);
                        showLike.LikeDate = ret.GetDateTime(3);
                        showSessionLikes.Add(showLike);
                    }
                    _conn.Close();
                    return showSessionLikes;
                }
                else
                {
                    _conn.Close();
                    return showSessionLikes;
                }
            }
        }
        else
        {
            return showSessionLikes;
        }
    }//End of GET_allShowLikes

    public async Task<List<Models.ShowLikes?>> GET_myShowSessionsLikes_by_ShowSessionID(Models.GET_anOBJ_by_1GUID_with_auth0ID? getMyShowsLikes)
    {
        List<Models.ShowLikes?> showSessionLikes = new List<Models.ShowLikes?>();
        if(getMyShowsLikes?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowLikes Where FK_ShowSessionID = @FK_ShowSessionID AND FK_ViewerID_Liker = (select ID From Viewers Where Auth0ID = @Auth0ID) Order By LikeDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@Auth0ID", getMyShowsLikes.Auth0ID);
                command.Parameters.AddWithValue("@FK_ShowSessionID", getMyShowsLikes.OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowLikes showLike = new Models.ShowLikes();
                        showLike.ID = ret.GetGuid(0);
                        showLike.FK_ViewerID_Liker = ret.GetGuid(1);
                        showLike.FK_ShowSessionID = ret.GetGuid(2);
                        showLike.LikeDate = ret.GetDateTime(3);
                        showSessionLikes.Add(showLike);
                    }
                    _conn.Close();
                    return showSessionLikes;
                }
                else
                {
                    _conn.Close();
                    return showSessionLikes;
                }
            }
        }
        else
        {
            return showSessionLikes;
        }
    }//End of GET_myShowSessionsLikes_by_ShowSessionID

    public async Task<List<Models.ShowLikes?>> GET_LikesOfShowSession_by_ShowSessionID(Models.GET_anOBJ_by_1GUID_with_auth0ID? getMyShowsLikes)
    {
        List<Models.ShowLikes?> showSessionLikes = new List<Models.ShowLikes?>();
        if(getMyShowsLikes?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowLikes Where FK_ShowSessionID = @FK_ShowSessionID Order By LikeDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@FK_ShowSessionID", getMyShowsLikes.OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowLikes showLike = new Models.ShowLikes();
                        showLike.ID = ret.GetGuid(0);
                        showLike.FK_ViewerID_Liker = ret.GetGuid(1);
                        showLike.FK_ShowSessionID = ret.GetGuid(2);
                        showLike.LikeDate = ret.GetDateTime(3);
                        showSessionLikes.Add(showLike);
                    }
                    _conn.Close();
                    return showSessionLikes;
                }
                else
                {
                    _conn.Close();
                    return showSessionLikes;
                }
            }
        }
        else
        {
            return showSessionLikes;
        }
    }//End of GET_LikesOfShowSession_by_ShowSessionID

    public async Task<Models.ShowLikes?> GET_aShowLike_by_ShowLikeID_with_auth0ID(Models.GET_aShowLike_by_ShowLikeID_with_auth0ID? getAShowLike)
    {
        Models.ShowLikes showLike = new Models.ShowLikes();
        if(getAShowLike?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowLikes Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", getAShowLike?.ShowLikeID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    showLike.ID = ret.GetGuid(0);
                    showLike.FK_ViewerID_Liker = ret.GetGuid(1);
                    showLike.FK_ShowSessionID = ret.GetGuid(2);
                    showLike.LikeDate = ret.GetDateTime(3);

                    _conn.Close();
                    return showLike;
                }
                else
                {
                    _conn.Close();
                    return showLike;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aShowLike_by_ShowLikeID_with_auth0ID


//-----------------------GET SHOW COMMENTS SECTION---------------------
    public async Task<List<Models.ShowComment?>> GET_allShowComments(Models.GET_with_anAuth0ID_DTO? getShowCommentsDTO)
    {
        List<Models.ShowComment?> showSessionComments = new List<Models.ShowComment?>();
        if(getShowCommentsDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowComments Order By CommentUpdateDate DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowComment showComment = new Models.ShowComment();
                        showComment.ID = ret.GetGuid(0);
                        showComment.FK_ViewerID_Commenter = ret.GetGuid(1);
                        showComment.FK_ShowSessionID = ret.GetGuid(2);
                        showComment.Comment = ret.GetString(3);

                        showComment.CommentDate = ret.GetDateTime(4);
                        showComment.CommentUpdateDate = ret.GetDateTime(5);
                        showSessionComments.Add(showComment);
                    }
                    _conn.Close();
                    return showSessionComments;
                }
                else
                {
                    _conn.Close();
                    return showSessionComments;
                }
            }
        }
        else
        {
            return showSessionComments;
        }
    }//End of GET_allShowComments

    public async Task<List<Models.ShowComment?>> GET_myShowComments_by_ViewerID_Commenter(Models.GET_anOBJ_by_1GUID_with_auth0ID getMyShowCommentsDTO)
    {
        List<Models.ShowComment?> showSessionComments = new List<Models.ShowComment?>();
        if(getMyShowCommentsDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowComments Where FK_ShowSessionID = @FK_ShowSessionID AND FK_ViewerID_Commenter = (select ID from Viewers where Auth0ID = @Auth0ID) Order By CommentUpdateDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@Auth0ID", getMyShowCommentsDTO.Auth0ID);
                command.Parameters.AddWithValue("@FK_ShowSessionID", getMyShowCommentsDTO.OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowComment showComment = new Models.ShowComment();
                        showComment.ID = ret.GetGuid(0);
                        showComment.FK_ViewerID_Commenter = ret.GetGuid(1);
                        showComment.FK_ShowSessionID = ret.GetGuid(2);
                        showComment.Comment = ret.GetString(3);

                        showComment.CommentDate = ret.GetDateTime(4);
                        showComment.CommentUpdateDate = ret.GetDateTime(5);
                        showSessionComments.Add(showComment);
                    }
                    _conn.Close();
                    return showSessionComments;
                }
                else
                {
                    _conn.Close();
                    return showSessionComments;
                }
            }
        }
        else
        {
            return showSessionComments;
        }
    }//End of Get_myShowComments_by_ViewerID_Commenter

    public async Task<Models.ShowComment?> GET_aShowComment_by_ShowCommentID_with_auth0ID(Models.GET_anOBJ_by_1GUID_with_auth0ID? getanOBJDTO)
    {
        Models.ShowComment showComment = new Models.ShowComment();
        if(getanOBJDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowComments Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", getanOBJDTO?.OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    showComment.ID = ret.GetGuid(0);
                    showComment.FK_ViewerID_Commenter = ret.GetGuid(1);
                    showComment.FK_ShowSessionID = ret.GetGuid(2);
                    showComment.Comment = ret.GetString(3);

                    showComment.CommentDate = ret.GetDateTime(4);
                    showComment.CommentUpdateDate = ret.GetDateTime(5);

                    _conn.Close();
                    return showComment;
                }
                else
                {
                    _conn.Close();
                    return showComment;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aShowComment_by_ShowCommentID_with_auth0ID

//-----------------------GET SHOW DONATIONS SECTION---------------------
    public async Task<List<Models.ShowDonation?>> GET_allShowDonations(Models.GET_with_anAuth0ID_DTO? getShowDonationsDTO)
    {
        List<Models.ShowDonation?> showDonationsList = new List<Models.ShowDonation?>();
        if(getShowDonationsDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowDonations Order By DonationDate DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowDonation showDonation = new Models.ShowDonation();
                        showDonation.ID = ret.GetGuid(0);
                        showDonation.FK_ViewerID_Donater = ret.GetGuid(1);
                        showDonation.FK_ShowID_Donatie = ret.GetGuid(2);
                        showDonation.Amount = ret.GetDecimal(3);
                        showDonation.Note = ret.GetString(4);
                        showDonation.DonationDate = ret.GetDateTime(5);
                        showDonationsList.Add(showDonation);
                    }
                    _conn.Close();
                    return showDonationsList;
                }
                else
                {
                    _conn.Close();
                    return showDonationsList;
                }
            }
        }
        else
        {
            return showDonationsList;
        }
    }//End of GET_allShowDonations

    public async Task<List<Models.ShowDonation?>> GET_myShowDonations_by_ViewerID_Donater(Models.GET_with_anAuth0ID_DTO? getMYShowDonationsDTO)
    {
        List<Models.ShowDonation?> showDonationsList = new List<Models.ShowDonation?>();
        if(getMYShowDonationsDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowDonations Where FK_ViewerID_Donater = (select ID from Viewers Where Auth0ID = @Auth0ID) Order By DonationDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@Auth0ID", getMYShowDonationsDTO.Auth0ID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowDonation showDonation = new Models.ShowDonation();
                        showDonation.ID = ret.GetGuid(0);
                        showDonation.FK_ViewerID_Donater = ret.GetGuid(1);
                        showDonation.FK_ShowID_Donatie = ret.GetGuid(2);
                        showDonation.Amount = ret.GetDecimal(3);
                        showDonation.Note = ret.GetString(4);
                        showDonation.DonationDate = ret.GetDateTime(5);
                        showDonationsList.Add(showDonation);
                    }
                    _conn.Close();
                    return showDonationsList;
                }
                else
                {
                    _conn.Close();
                    return showDonationsList;
                }
            }
        }
        else
        {
            return showDonationsList;
        }
    }//End of Get_myShowDonations_by_ViewerID_Donater

    public async Task<Models.ShowDonation?> GET_aShowDonation_by_ShowDonationID_with_auth0ID(Models.GET_anOBJ_by_1GUID_with_auth0ID? getanOBJDTO)
    {
        Models.ShowDonation objToReturn = new Models.ShowDonation();
        if(getanOBJDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowDonations Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", getanOBJDTO?.OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    objToReturn.ID = ret.GetGuid(0);
                    objToReturn.FK_ViewerID_Donater = ret.GetGuid(1);
                    objToReturn.FK_ShowID_Donatie = ret.GetGuid(2);
                    objToReturn.Amount = ret.GetDecimal(3);
                    objToReturn.Note = ret.GetString(4);
                    objToReturn.DonationDate = ret.GetDateTime(5);
                    _conn.Close();
                    return objToReturn;
                }
                else
                {
                    _conn.Close();
                    return objToReturn;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aShowDonation_by_ShowDonationID_with_auth0ID

//-----------------------GET SHOW SESSIONS SECTION---------------------
    public async Task<List<Models.ShowSession?>> GET_allShowSessions(Models.GET_with_anAuth0ID_DTO? getShowSessionsDTO)
    {
        List<Models.ShowSession?> showSessionsList = new List<Models.ShowSession?>();
        if(getShowSessionsDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowSessions Order By SessionEndDate DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowSession showSession = new Models.ShowSession();
                        showSession.ID = ret.GetGuid(0);
                        showSession.FK_ShowID = ret.GetGuid(1);
                        showSession.Views = ret.GetInt32(2);
                        showSession.Likes = ret.GetInt32(3);
                        showSession.SessionStartDate = ret.GetDateTime(4);
                        showSession.SessionEndDate = ret.GetDateTime(5);
                        showSessionsList.Add(showSession);
                    }
                    _conn.Close();
                    return showSessionsList;
                }
                else
                {
                    _conn.Close();
                    return showSessionsList;
                }
            }
        }
        else
        {
            return showSessionsList;
        }
    }//End of GET_allShowSessions

    public async Task<List<Models.ShowSession?>> GET_myShowSessions_by_showID(Models.GET_anOBJ_by_1GUID_with_auth0ID? getMyShowSessions)
    {
        List<Models.ShowSession?> showSessionsList = new List<Models.ShowSession?>();
        if(getMyShowSessions?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowSessions Where FK_ShowID = @FK_ShowID Order By SessionEndDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@FK_ShowID", getMyShowSessions.OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowSession showSession = new Models.ShowSession();
                        showSession.ID = ret.GetGuid(0);
                        showSession.FK_ShowID = ret.GetGuid(1);
                        showSession.Views = ret.GetInt32(2);
                        showSession.Likes = ret.GetInt32(3);
                        showSession.SessionStartDate = ret.GetDateTime(4);
                        showSession.SessionEndDate = ret.GetDateTime(5);
                        showSessionsList.Add(showSession);
                    }
                    _conn.Close();
                    return showSessionsList;
                }
                else
                {
                    _conn.Close();
                    return showSessionsList;
                }
            }
        }
        else
        {
            return showSessionsList;
        }
    }//End of Get_myShowDonations_by_ViewerID_Donater

    public async Task<Models.ShowSession?> GET_aShowSession_by_ShowSessionID_with_auth0ID(Models.GET_anOBJ_by_1GUID_with_auth0ID? getanOBJDTO)
    {
        Models.ShowSession objToReturn = new Models.ShowSession();
        if(getanOBJDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowSessions Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", getanOBJDTO?.OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    objToReturn.ID = ret.GetGuid(0);
                    objToReturn.FK_ShowID = ret.GetGuid(1);
                    objToReturn.Views = ret.GetInt32(2);
                    objToReturn.Likes = ret.GetInt32(3);
                    objToReturn.SessionStartDate = ret.GetDateTime(4);
                    objToReturn.SessionEndDate = ret.GetDateTime(5);
                    _conn.Close();
                    return objToReturn;
                }
                else
                {
                    _conn.Close();
                    return objToReturn;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aShowSession_by_ShowSessionID_with_auth0ID


//-----------------------GET SHOW SESSION JOINS SECTION---------------------
    public async Task<List<Models.ShowSessionJoins?>> GET_allShowSessionJoins(Models.GET_with_anAuth0ID_DTO? getShowSessionJoinsDTO)
    {
        List<Models.ShowSessionJoins?> showSessionsList = new List<Models.ShowSessionJoins?>();
        if(getShowSessionJoinsDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowSessionJoins Order By SessionLeaveDate DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowSessionJoins showSessionJoin = new Models.ShowSessionJoins();

                        showSessionJoin.ID = ret.GetGuid(0);
                        showSessionJoin.FK_ShowSessionsID = ret.GetGuid(1);
                        showSessionJoin.FK_ViewerID_ShowViewer = ret.GetGuid(2);

                        showSessionJoin.SessionJoinDate = ret.GetDateTime(3);
                        showSessionJoin.SessionLeaveDate = ret.GetDateTime(4);

                        showSessionsList.Add(showSessionJoin);
                    }
                    _conn.Close();
                    return showSessionsList;
                }
                else
                {
                    _conn.Close();
                    return showSessionsList;
                }
            }
        }
        else
        {
            return showSessionsList;
        }
    }//End of GET_allShowSessionJoins

    public async Task<List<Models.ShowSessionJoins?>> GET_Joins_of_ShowSession_by_showSessionID(Models.GET_anOBJ_by_1GUID_with_auth0ID? getJoinDTO)
    {
        List<Models.ShowSessionJoins?> showSessionsList = new List<Models.ShowSessionJoins?>();
        if(getJoinDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowSessionJoins Where FK_ShowID = @FK_ShowID AND FK_ViewerID_ShowViewer = (select ID from Viewers where Auth0ID = @Auth0ID) Order By SessionLeaveDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@Auth0ID", getJoinDTO.Auth0ID);
                command.Parameters.AddWithValue("@FK_ShowID", getJoinDTO.OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowSessionJoins showSessionJoin = new Models.ShowSessionJoins();

                        showSessionJoin.ID = ret.GetGuid(0);
                        showSessionJoin.FK_ShowSessionsID = ret.GetGuid(1);
                        showSessionJoin.FK_ViewerID_ShowViewer = ret.GetGuid(2);

                        showSessionJoin.SessionJoinDate = ret.GetDateTime(3);
                        showSessionJoin.SessionLeaveDate = ret.GetDateTime(4);

                        showSessionsList.Add(showSessionJoin);
                    }
                    _conn.Close();
                    return showSessionsList;
                }
                else
                {
                    _conn.Close();
                    return showSessionsList;
                }
            }
        }
        else
        {
            return showSessionsList;
        }
    }//End of Get_myShowDonations_by_ViewerID_Donater

    public async Task<Models.ShowSessionJoins?> GET_aShowSessionJoin_by_ShowSessionJoinID_with_auth0ID(Models.GET_anOBJ_by_1GUID_with_auth0ID? getanOBJDTO)
    {
        Models.ShowSessionJoins objToReturn = new Models.ShowSessionJoins();
        if(getanOBJDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowSessionJoins Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", getanOBJDTO?.OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    objToReturn.ID = ret.GetGuid(0);
                    objToReturn.FK_ShowSessionsID = ret.GetGuid(1);
                    objToReturn.FK_ViewerID_ShowViewer = ret.GetGuid(2);

                    objToReturn.SessionJoinDate = ret.GetDateTime(3);
                    objToReturn.SessionLeaveDate = ret.GetDateTime(4);

                    _conn.Close();
                    return objToReturn;
                }
                else
                {
                    _conn.Close();
                    return objToReturn;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aShowSession_by_ShowSessionID_with_auth0ID


//-----------------------GET SHOW COMMENT LIKES SECTION---------------------
    public async Task<List<Models.ShowCommentLike?>> GET_allShowCommentLikes(Models.GET_with_anAuth0ID_DTO? getShowCommentLikesDTO)
    {
        List<Models.ShowCommentLike?> showSessionsList = new List<Models.ShowCommentLike?>();
        if(getShowCommentLikesDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowCommentLikes Order By LikeDate DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowCommentLike showCommentLike = new Models.ShowCommentLike();

                        showCommentLike.ID = ret.GetGuid(0);
                        showCommentLike.FK_ViewerID_Liker = ret.GetGuid(1);
                        showCommentLike.FK_ShowCommentID_Likie = ret.GetGuid(2);

                        showCommentLike.LikeDate = ret.GetDateTime(3);
                        
                        showSessionsList.Add(showCommentLike);
                    }
                    _conn.Close();
                    return showSessionsList;
                }
                else
                {
                    _conn.Close();
                    return showSessionsList;
                }
            }
        }
        else
        {
            return showSessionsList;
        }
    }//End of GET_allShowCommentLikes

    public async Task<List<Models.ShowCommentLike?>> GET_allLikes_of_ShowComment_by_showCommentID(Models.GET_anOBJ_by_1GUID_with_auth0ID? getShowCommentDTO)
    {
        List<Models.ShowCommentLike?> showSessionsList = new List<Models.ShowCommentLike?>();
        if(getShowCommentDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowCommentLikes Where FK_ShowCommentID = @FK_ShowCommentID Order By LikeDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@Auth0ID", getShowCommentDTO.Auth0ID);
                command.Parameters.AddWithValue("@FK_ShowCommentID", getShowCommentDTO.OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowCommentLike showCommentLike = new Models.ShowCommentLike();

                        showCommentLike.ID = ret.GetGuid(0);
                        showCommentLike.FK_ViewerID_Liker = ret.GetGuid(1);
                        showCommentLike.FK_ShowCommentID_Likie = ret.GetGuid(2);

                        showCommentLike.LikeDate = ret.GetDateTime(3);
                        
                        showSessionsList.Add(showCommentLike);
                    }
                    _conn.Close();
                    return showSessionsList;
                }
                else
                {
                    _conn.Close();
                    return showSessionsList;
                }
            }
        }
        else
        {
            return showSessionsList;
        }
    }//End of GET_allLikes_of_ShowComment_by_showCommentID

    public async Task<Models.ShowCommentLike?> GET_myLike_of_ShowComment_by_showCommentID(Models.GET_anOBJ_by_1GUID_with_auth0ID? getShowCommentDTO)
    {
        if(getShowCommentDTO?.Auth0ID != null)
        {
            Models.ShowCommentLike showCommentLike = new Models.ShowCommentLike();
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowCommentLikes Where FK_ShowCommentID = @FK_ShowCommentID AND FK_ViewerID_Liker = (select ID from Viewers where Auth0ID = @Auth0ID) Order By LikeDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@Auth0ID", getShowCommentDTO.Auth0ID);
                command.Parameters.AddWithValue("@FK_ShowCommentID", getShowCommentDTO.OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {

                    showCommentLike.ID = ret.GetGuid(0);
                    showCommentLike.FK_ViewerID_Liker = ret.GetGuid(1);
                    showCommentLike.FK_ShowCommentID_Likie = ret.GetGuid(2);

                    showCommentLike.LikeDate = ret.GetDateTime(3);
                    _conn.Close();
                    return showCommentLike;
                }
                else
                {
                    _conn.Close();
                    return showCommentLike;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of Get_myShowDonations_by_ViewerID_Donater

    public async Task<Models.ShowCommentLike?> GET_aShowCommentLike_by_ShowCommentLikeID_with_auth0ID(Models.GET_anOBJ_by_1GUID_with_auth0ID? getanOBJDTO)
    {
        Models.ShowCommentLike objToReturn = new Models.ShowCommentLike();
        if(getanOBJDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowCommentLikes Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", getanOBJDTO?.OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    objToReturn.ID = ret.GetGuid(0);
                    objToReturn.FK_ViewerID_Liker = ret.GetGuid(1);
                    objToReturn.FK_ShowCommentID_Likie = ret.GetGuid(2);

                    objToReturn.LikeDate = ret.GetDateTime(3);

                    _conn.Close();
                    return objToReturn;
                }
                else
                {
                    _conn.Close();
                    return objToReturn;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aShowCommentLike_by_ShowCommentLikeID_with_auth0ID

//-----------------------GET SHOW COMMENT LIKES SECTION---------------------
    public async Task<List<Models.Wallet?>> GET_allPersonalWallets(Models.GET_with_anAuth0ID_DTO? getPersonalWalletsLikesDTO)
    {
        List<Models.Wallet?> allWallets = new List<Models.Wallet?>();
        if(getPersonalWalletsLikesDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Wallets_Viewer Where ORDER BY DateUpdated DESC ", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.Wallet myWallet = new Models.Wallet();
                        myWallet.ID = ret.GetGuid(0);
                        myWallet.FK_ViewerID_WalletOwner = ret.GetGuid(1);
                        myWallet.Balance = ret.GetDecimal(2);
                        myWallet.DateCreated = ret.GetDateTime(3);
                        myWallet.DateUpdated = ret.GetDateTime(4);
                        allWallets.Add(myWallet);
                    }
                        
                    _conn.Close();
                    return allWallets;
                }
                else
                {
                    _conn.Close();
                    return allWallets;
                }
            }
        }
        else
        {
            return allWallets;
        }
    }//End of GET_allPersonalWallets

    public async Task<List<Models.ShowWallet?>> GET_allShowWallets(Models.GET_with_anAuth0ID_DTO? getShowWalletsLikesDTO)
    {
        List<Models.ShowWallet?> allWallets = new List<Models.ShowWallet?>();
        if(getShowWalletsLikesDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Wallets_Show Where ORDER BY DateUpdated DESC ", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while(ret.Read())
                    {
                        Models.ShowWallet myWallet = new Models.ShowWallet();

                        myWallet.ID = ret.GetGuid(0);
                        myWallet.FK_ViewerID_WalletOwner = ret.GetGuid(1);
                        myWallet.FK_ShowID_WalletShow = ret.GetGuid(2);
                        myWallet.Balance = ret.GetDecimal(3);

                        myWallet.DateCreated = ret.GetDateTime(4);
                        myWallet.DateUpdated = ret.GetDateTime(5);

                        allWallets.Add(myWallet);
                    }
                        
                    _conn.Close();
                    return allWallets;
                }
                else
                {
                    _conn.Close();
                    return allWallets;
                }
            }
        }
        else
        {
            return allWallets;
        }
    }//End of GET_allShowWallets


    public async Task<Models.Wallet> GET_myPersonalWallet_by_viewerID(Models.GET_personalWalletDTO? getWalletDTO)
    {
        Models.Wallet myWallet = new Models.Wallet();
        if(getWalletDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Wallets_Viewer Where FK_ViewerID_WalletOwner = @FK_ViewerID_WalletOwner ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ViewerID_WalletOwner", getWalletDTO.FK_ViewerID_WalletOwner);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    myWallet.ID = ret.GetGuid(0);
                    myWallet.FK_ViewerID_WalletOwner = ret.GetGuid(1);
                    myWallet.Balance = ret.GetDecimal(2);
                    myWallet.DateCreated = ret.GetDateTime(3);
                    myWallet.DateUpdated = ret.GetDateTime(4);
                        
                    _conn.Close();
                    return myWallet;
                }
                else
                {
                    _conn.Close();
                    return myWallet;
                }
            }
        }
        else
        {
            return myWallet;
        }
    }//End of GET_myPersonalWallet_by_viewerID

    public async Task<Models.ShowWallet> GET_myShowWallet_by_viewer_AND_showID(Models.GET_showWalletDTO? getWalletDTO)
    {
        Models.ShowWallet myShowWallet = new Models.ShowWallet();
        if(getWalletDTO?.Auth0ID != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Wallets_Show Where FK_ViewerID_WalletOwner = @FK_ViewerID_WalletOwner AND FK_ShowID_WalletShow = @FK_ShowID_WalletShow ", _conn))
            {
                command.Parameters.AddWithValue("@FK_ViewerID_WalletOwner", getWalletDTO.FK_ViewerID_WalletOwner);
                command.Parameters.AddWithValue("@FK_ShowID_WalletShow", getWalletDTO.FK_ShowID_WalletShow);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    myShowWallet.ID = ret.GetGuid(0);
                    myShowWallet.FK_ViewerID_WalletOwner = ret.GetGuid(1);
                    myShowWallet.FK_ShowID_WalletShow = ret.GetGuid(2);
                    myShowWallet.Balance = ret.GetDecimal(3);

                    myShowWallet.DateCreated = ret.GetDateTime(4);
                    myShowWallet.DateUpdated = ret.GetDateTime(5);
                        
                    _conn.Close();
                    return myShowWallet;
                }
                else
                {
                    _conn.Close();
                    return myShowWallet;
                }
            }
        }
        else
        {
            return myShowWallet;
        }
    }//End of GET_myShowWallet_by_viewer_AND_showID





}
