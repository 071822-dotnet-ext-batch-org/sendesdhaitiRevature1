using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MS_API1_Users_Model;
using Models;
namespace MS_API1_Users_Repo;

public class GET_AccessLayer : IGET_AccessLayer
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
            _conn = new SqlConnection(_config["ConnectionStrings:Production"]);
        }

    }

    //-----------------------GET VIEWER SECTION---------------------
    public async Task<List<Models.Viewer?>> GET_allViewers(string? MSToken)
    {
        List<Models.Viewer?> listOfViewers = new List<Models.Viewer?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Viewers Order By LastSignedIn DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
                    {
                        Models.Viewer viewer = new Models.Viewer();
                        viewer.ID = ret.GetGuid(0);
                        viewer.MSToken = ret.GetString(1);
                        viewer.Fn = ret.GetString(2);
                        viewer.Ln = ret.GetString(3);
                        viewer.Email = ret.GetString(4);
                        viewer.Image = ret.GetString(5);
                        if(!ret.IsDBNull(6))
                        {
                            viewer.Username = ret.GetString(6);
                        }else{viewer.Username = "PLEASE CREATE USERNAME!!";}
                        viewer.AboutMe = ret.GetString(7);
                        viewer.StreetAddy = ret.GetString(8);
                        viewer.City = ret.GetString(9);
                        viewer.State = ret.GetString(10);
                        viewer.Country = ret.GetString(11);
                        viewer.AreaCode = ret.GetInt32(12);

                        if (ret.GetString(13) == "Viewer") { viewer.Role = Models.Role.Viewer; }
                        else if (ret.GetString(13) == "Host") { viewer.Role = Models.Role.Host; }
                        else if (ret.GetString(13) == "Admin") { viewer.Role = Models.Role.Admin; }
                        else viewer.Role = Models.Role.Viewer;

                        if (ret.GetString(14) == "Viewer") { viewer.MembershipStatus = Models.ViewerStatus.Viewer; }
                        else viewer.MembershipStatus = Models.ViewerStatus.Guest;

                        viewer.DateSignedUp = ret.GetDateTime(15);
                        viewer.LastSignedIn = ret.GetDateTime(16);
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

    public async Task<Models.Viewer?> GET_myViewer_by_MSToken(string? MSToken)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Viewers Where MSToken = @MSToken", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Models.Viewer viewer = new Models.Viewer();
                    viewer.ID = ret.GetGuid(0);
                    viewer.MSToken = ret.GetString(1);
                    viewer.Fn = ret.GetString(2);
                    viewer.Ln = ret.GetString(3);
                    viewer.Email = ret.GetString(4);
                    viewer.Image = ret.GetString(5);
                    if(!ret.IsDBNull(6))
                    {
                        viewer.Username = ret.GetString(6);
                    }else{viewer.Username = "PLEASE CREATE USERNAME!!";}
                    viewer.AboutMe = ret.GetString(7);
                    viewer.StreetAddy = ret.GetString(8);
                    viewer.City = ret.GetString(9);
                    viewer.State = ret.GetString(10);
                    viewer.Country = ret.GetString(11);
                    viewer.AreaCode = ret.GetInt32(12);

                    if (ret.GetString(13) == "Viewer") { viewer.Role = Models.Role.Viewer; }
                    else if (ret.GetString(13) == "Host") { viewer.Role = Models.Role.Host; }
                    else if (ret.GetString(13) == "Admin") { viewer.Role = Models.Role.Admin; }
                    else viewer.Role = Models.Role.Viewer;

                    if (ret.GetString(14) == "Viewer") { viewer.MembershipStatus = Models.ViewerStatus.Viewer; }
                    else viewer.MembershipStatus = Models.ViewerStatus.Guest;

                    viewer.DateSignedUp = ret.GetDateTime(15);
                    viewer.LastSignedIn = ret.GetDateTime(16);

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
    }//End of Get_Viewer_by_MSToken

    public async Task<Models.Viewer?> GET_aViewer_by_aViewerID(string? MSToken, Guid? OBJID)
    {
        if ((MSToken != null) && (OBJID != null))
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Viewers Where ID = @ID", _conn))
            {
                command.Parameters.AddWithValue("@ID", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Models.Viewer viewer = new Models.Viewer();
                    viewer.ID = ret.GetGuid(0);
                    viewer.MSToken = ret.GetString(1);
                    viewer.Fn = ret.GetString(2);
                    viewer.Ln = ret.GetString(3);
                    viewer.Email = ret.GetString(4);
                    viewer.Image = ret.GetString(5);
                    if(!ret.IsDBNull(6))
                    {
                        viewer.Username = ret.GetString(6);
                    }else{viewer.Username = "PLEASE CREATE USERNAME!!";}
                    viewer.AboutMe = ret.GetString(7);
                    viewer.StreetAddy = ret.GetString(8);
                    viewer.City = ret.GetString(9);
                    viewer.State = ret.GetString(10);
                    viewer.Country = ret.GetString(11);
                    viewer.AreaCode = ret.GetInt32(12);
                    if (ret.GetString(13) == "Viewer") { viewer.Role = Models.Role.Viewer; }
                    else if (ret.GetString(13) == "Host") { viewer.Role = Models.Role.Host; }
                    else if (ret.GetString(13) == "Admin") { viewer.Role = Models.Role.Admin; }
                    else viewer.Role = Models.Role.Viewer;


                    if (ret.GetString(14) == "Viewer") { viewer.MembershipStatus = Models.ViewerStatus.Viewer; }
                    else viewer.MembershipStatus = Models.ViewerStatus.Guest;

                    viewer.DateSignedUp = ret.GetDateTime(15);
                    viewer.LastSignedIn = ret.GetDateTime(16);


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
    public async Task<Models.Admin?> GET_myAdmin_by_MSToken(string? MSToken)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Admins Where MSToken = @MSToken", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Models.Admin admin = new Models.Admin();
                    admin.ID = ret.GetGuid(0);
                    admin.MSToken = ret.GetString(1);
                    admin.Email = ret.GetString(2);
                    if(!ret.IsDBNull(3))
                    {
                        admin.Username = ret.GetString(3);
                    }else{admin.Username = "PLEASE CREATE USERNAME!!";}

                    if (ret.GetString(4) == "Admin") { admin.AdminStatus = Models.AdminStatus.Admin; }
                    else
                    {
                        admin.AdminStatus = Models.AdminStatus.NonAdmin;
                    }


                    admin.DateCreated = ret.GetDateTime(5);
                    admin.LastSignedIn = ret.GetDateTime(6);

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
    }//End of GET_myAdmin_by_MSToken

    //-----------------------GET FRIEND SECTION---------------------
    public async Task<List<Models.Friend?>> GET_allFriends(string? MSToken)
    {
        List<Models.Friend?> friendsList = new List<Models.Friend?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Friends Order By FriendUpdateDate DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
                    {
                        Models.Friend friend = new Models.Friend();

                        friend.ID = ret.GetGuid(0);
                        friend.FK_ViewerID_Friender = ret.GetGuid(1);
                        friend.FK_ViewerID_Friendie = ret.GetGuid(2);

                        if (ret.GetString(3) == "Friend") { friend.FriendshipStatus = Models.FriendShipStatus.Friend; }
                        else if (ret.GetString(3) == "PendingFriend") { friend.FriendshipStatus = Models.FriendShipStatus.PendingFriend; }
                        else if (ret.GetString(3) == "UnFriended") { friend.FriendshipStatus = Models.FriendShipStatus.UnFriended; }
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

    public async Task<List<Models.Friend?>> GET_myFriends_by_ViewerID_Freinder(string? MSToken)
    {
        List<Models.Friend?> friendsList = new List<Models.Friend?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Friends Where FK_ViewerID_Friender = (select ID from Viewers Where MSToken = @MSToken) Order By FriendUpdateDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
                    {
                        Models.Friend friend = new Models.Friend();

                        friend.ID = ret.GetGuid(0);
                        friend.FK_ViewerID_Friender = ret.GetGuid(1);
                        friend.FK_ViewerID_Friendie = ret.GetGuid(2);

                        if (ret.GetString(3) == "Friend") { friend.FriendshipStatus = Models.FriendShipStatus.Friend; }
                        else if (ret.GetString(3) == "PendingFriend") { friend.FriendshipStatus = Models.FriendShipStatus.PendingFriend; }
                        else if (ret.GetString(3) == "UnFriended") { friend.FriendshipStatus = Models.FriendShipStatus.UnFriended; }
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

    public async Task<Models.Friend?> GET_aFriend_by_ViewerID_Freinder(string? MSToken, Guid? FriendID, Guid? viewerID_Friender)
    {
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Friends Where ID = @ID AND FK_ViewerID_Friender = @FK_ViewerID_Friender ", _conn))
            {
                command.Parameters.AddWithValue("@ID", FriendID);
                command.Parameters.AddWithValue("@FK_ViewerID_Friender", viewerID_Friender);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Models.Friend friend = new Models.Friend();

                    friend.ID = ret.GetGuid(0);
                    friend.FK_ViewerID_Friender = ret.GetGuid(1);
                    friend.FK_ViewerID_Friendie = ret.GetGuid(2);

                    if (ret.GetString(3) == "Friend") { friend.FriendshipStatus = Models.FriendShipStatus.Friend; }
                    else if (ret.GetString(3) == "PendingFriend") { friend.FriendshipStatus = Models.FriendShipStatus.PendingFriend; }
                    else if (ret.GetString(3) == "UnFriended") { friend.FriendshipStatus = Models.FriendShipStatus.UnFriended; }
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
    public async Task<List<Models.Follower?>> GET_allFollowers(string? MSToken)
    {
        List<Models.Follower?> followerList = new List<Models.Follower?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Followers Order By StatusUpdateDate DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
                    {
                        Models.Follower follower = new Models.Follower();

                        follower.ID = ret.GetGuid(0);
                        follower.FK_ViewerID_Follower = ret.GetGuid(1);
                        follower.FK_ViewerID_Followie = ret.GetGuid(2);
                        follower.FK_ShowID_Followie = ret.GetGuid(3);

                        if (ret.GetString(4) == "Follower") { follower.FollowerStatus = Models.FollowerStatus.Follower; }
                        else if (ret.GetString(4) == "UnFollowed") { follower.FollowerStatus = Models.FollowerStatus.UnFollowed; }
                        else if (ret.GetString(4) == "NonFollower") { follower.FollowerStatus = Models.FollowerStatus.NonFollower; }
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

    public async Task<List<Models.Follower?>> GET_myFollowers_by_ViewerID_Follower(string? MSToken)
    {
        List<Models.Follower?> followerList = new List<Models.Follower?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Followers Where FK_ViewerID_Follower = (select ID from Viewers Where MSToken = @MSToken) Order By FollowDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
                    {
                        Models.Follower follower = new Models.Follower();

                        follower.ID = ret.GetGuid(0);
                        follower.FK_ViewerID_Follower = ret.GetGuid(1);
                        follower.FK_ViewerID_Followie = ret.GetGuid(2);
                        follower.FK_ShowID_Followie = ret.GetGuid(3);

                        if (ret.GetString(4) == "Follower") { follower.FollowerStatus = Models.FollowerStatus.Follower; }
                        else if (ret.GetString(4) == "UnFollowed") { follower.FollowerStatus = Models.FollowerStatus.UnFollowed; }
                        else if (ret.GetString(4) == "NonFollower") { follower.FollowerStatus = Models.FollowerStatus.NonFollower; }
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

    public async Task<Models.Follower?> GET_aFollower_by_ViewerID_Follower(string? MSToken, Guid? FollowerID,Guid? ViewerID_Follower)
    {
        Models.Follower follower = new Models.Follower();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Followers Where ID = @ID AND FK_ViewerID_Follower = @FK_ViewerID_Follower ", _conn))
            {
                command.Parameters.AddWithValue("@ID", FollowerID);
                command.Parameters.AddWithValue("@FK_ViewerID_Follower", ViewerID_Follower);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {

                    follower.ID = ret.GetGuid(0);
                    follower.FK_ViewerID_Follower = ret.GetGuid(1);
                    follower.FK_ViewerID_Followie = ret.GetGuid(2);
                    follower.FK_ShowID_Followie = ret.GetGuid(3);

                    if (ret.GetString(4) == "Follower") { follower.FollowerStatus = Models.FollowerStatus.Follower; }
                    else if (ret.GetString(4) == "UnFollowed") { follower.FollowerStatus = Models.FollowerStatus.UnFollowed; }
                    else if (ret.GetString(4) == "NonFollower") { follower.FollowerStatus = Models.FollowerStatus.NonFollower; }
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
    public async Task<List<Models.Show?>> GET_allShows(string? MSToken)
    {
        List<Models.Show?> createdShowsList = new List<Models.Show?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Shows Where Order By LastLive DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
                    {
                        Models.Show show = new Models.Show();

                        show.ID = ret.GetGuid(0);
                        show.FK_ViewerID_Owner = ret.GetGuid(1);
                        show.ShowName = ret.GetString(2);
                        show.ShowImage = ret.GetString(3);
                        show.SubscribersCount = ret.GetInt32(4);
                        show.Views = ret.GetInt32(5);
                        show.Likes = ret.GetInt32(6);
                        show.Comments = ret.GetInt32(7);
                        show.Rating = ret.GetDouble(8);
                        show.Rank = ret.GetInt32(9);

                        if (ret.GetString(10) == "Private") { show.PrivacyLevel = Models.PrivacyLevel.Private; }
                        else if (ret.GetString(10) == "Exclusive") { show.PrivacyLevel = Models.PrivacyLevel.Exclusive; }
                        else if (ret.GetString(10) == "Public") { show.PrivacyLevel = Models.PrivacyLevel.Public; }
                        else show.PrivacyLevel = Models.PrivacyLevel.Private;

                        if (ret.GetString(11) == "Pending") { show.ShowStatus = Models.ShowStanding.Pending; }
                        else if (ret.GetString(11) == "Great") { show.ShowStatus = Models.ShowStanding.Great; }
                        else if (ret.GetString(11) == "Good") { show.ShowStatus = Models.ShowStanding.Good; }
                        else if (ret.GetString(11) == "Moderate") { show.ShowStatus = Models.ShowStanding.Moderate; }
                        else if (ret.GetString(11) == "Bad") { show.ShowStatus = Models.ShowStanding.Bad; }
                        else if (ret.GetString(11) == "Deactivated") { show.ShowStatus = Models.ShowStanding.Deactivated; }
                        else { show.ShowStatus = Models.ShowStanding.Banned; }

                        show.DateCreated = ret.GetDateTime(12);
                        show.LastLive = ret.GetDateTime(12);

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

    public async Task<List<Models.Show?>> GET_myShows_by_ViewerID_Owner(string? MSToken)
    {
        List<Models.Show?> createdShowsList = new List<Models.Show?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Shows Where FK_ViewerID_Owner = (select ID from Viewers Where MSToken = @MSToken) Order By LastLive DESC", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
                    {
                        Models.Show show = new Models.Show();

                        show.ID = ret.GetGuid(0);
                        show.FK_ViewerID_Owner = ret.GetGuid(1);
                        show.ShowName = ret.GetString(2);
                        show.ShowImage = ret.GetString(3);
                        show.SubscribersCount = ret.GetInt32(4);
                        show.Views = ret.GetInt32(5);
                        show.Likes = ret.GetInt32(6);
                        show.Comments = ret.GetInt32(7);
                        show.Rating = ret.GetDouble(8);
                        show.Rank = ret.GetInt32(9);

                        if (ret.GetString(10) == "Private") { show.PrivacyLevel = Models.PrivacyLevel.Private; }
                        else if (ret.GetString(10) == "Exclusive") { show.PrivacyLevel = Models.PrivacyLevel.Exclusive; }
                        else if (ret.GetString(10) == "Public") { show.PrivacyLevel = Models.PrivacyLevel.Public; }
                        else show.PrivacyLevel = Models.PrivacyLevel.Private;

                        if (ret.GetString(11) == "Pending") { show.ShowStatus = Models.ShowStanding.Pending; }
                        else if (ret.GetString(11) == "Great") { show.ShowStatus = Models.ShowStanding.Great; }
                        else if (ret.GetString(11) == "Good") { show.ShowStatus = Models.ShowStanding.Good; }
                        else if (ret.GetString(11) == "Moderate") { show.ShowStatus = Models.ShowStanding.Moderate; }
                        else if (ret.GetString(11) == "Bad") { show.ShowStatus = Models.ShowStanding.Bad; }
                        else if (ret.GetString(11) == "Deactivated") { show.ShowStatus = Models.ShowStanding.Deactivated; }
                        else { show.ShowStatus = Models.ShowStanding.Banned; }

                        show.DateCreated = ret.GetDateTime(12);
                        show.LastLive = ret.GetDateTime(12);

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

    public async Task<Models.Show?> GET_aShow_by_ShowID_with_MSToken(string? MSToken, Guid? showID)
    {
        Models.Show show = new Models.Show();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Shows Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", showID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    show.ID = ret.GetGuid(0);
                    show.FK_ViewerID_Owner = ret.GetGuid(1);
                    show.ShowName = ret.GetString(2);
                    show.ShowImage = ret.GetString(3);
                    show.SubscribersCount = ret.GetInt32(4);
                    show.Views = ret.GetInt32(5);
                    show.Likes = ret.GetInt32(6);
                    show.Comments = ret.GetInt32(7);
                    show.Rating = ret.GetDouble(8);
                    show.Rank = ret.GetInt32(9);

                    if (ret.GetString(10) == "Private") { show.PrivacyLevel = Models.PrivacyLevel.Private; }
                    else if (ret.GetString(10) == "Exclusive") { show.PrivacyLevel = Models.PrivacyLevel.Exclusive; }
                    else if (ret.GetString(10) == "Public") { show.PrivacyLevel = Models.PrivacyLevel.Public; }
                    else show.PrivacyLevel = Models.PrivacyLevel.Private;

                    if (ret.GetString(11) == "Pending") { show.ShowStatus = Models.ShowStanding.Pending; }
                    else if (ret.GetString(11) == "Great") { show.ShowStatus = Models.ShowStanding.Great; }
                    else if (ret.GetString(11) == "Good") { show.ShowStatus = Models.ShowStanding.Good; }
                    else if (ret.GetString(11) == "Moderate") { show.ShowStatus = Models.ShowStanding.Moderate; }
                    else if (ret.GetString(11) == "Bad") { show.ShowStatus = Models.ShowStanding.Bad; }
                    else if (ret.GetString(11) == "Deactivated") { show.ShowStatus = Models.ShowStanding.Deactivated; }
                    else { show.ShowStatus = Models.ShowStanding.Banned; }

                    show.DateCreated = ret.GetDateTime(12);
                    show.LastLive = ret.GetDateTime(12);

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
    }//End of GET_aShow_by_ShowID_with_MSToken


    //-----------------------GET SHOW SUBSCRIBERS SECTION---------------------
    public async Task<List<Models.ShowSubscriber?>> GET_allShowSubscriber(string? MSToken)
    {
        List<Models.ShowSubscriber?> subscribedShowsList = new List<Models.ShowSubscriber?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Subscribers Order By LastLive DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
                    {
                        Models.ShowSubscriber subscribedShow = new Models.ShowSubscriber();

                        subscribedShow.ID = ret.GetGuid(0);
                        subscribedShow.FK_ViewerID_Subscriber = ret.GetGuid(1);
                        subscribedShow.FK_ShowID_Subscribie = ret.GetGuid(2);
                        subscribedShow.FK_ShowSessionID = ret.GetGuid(3);

                        if (ret.GetString(4) == "Subscriber") { subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.Subscriber; }
                        else if (ret.GetString(4) == "UnSubscribed") { subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.UnSubscribed; }
                        else if (ret.GetString(4) == "PremiumMember") { subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.PremiumMember; }
                        else if (ret.GetString(4) == "ExclusiveMember") { subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.ExclusiveMember; }
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

    public async Task<List<Models.ShowSubscriber?>> GET_myShowSubscriptions_by_ViewerID_Subscriber(string? MSToken)
    {
        List<Models.ShowSubscriber?> subscribedShowsList = new List<Models.ShowSubscriber?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Subscribers Where FK_ViewerID_Subscriber = (select ID from Viewers Where MSToken = @MSToken) Order By SubscriptionUpdateDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
                    {
                        Models.ShowSubscriber subscribedShow = new Models.ShowSubscriber();

                        subscribedShow.ID = ret.GetGuid(0);
                        subscribedShow.FK_ViewerID_Subscriber = ret.GetGuid(1);
                        subscribedShow.FK_ShowID_Subscribie = ret.GetGuid(2);
                        subscribedShow.FK_ShowSessionID = ret.GetGuid(3);

                        if (ret.GetString(4) == "Subscriber") { subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.Subscriber; }
                        else if (ret.GetString(4) == "UnSubscribed") { subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.UnSubscribed; }
                        else if (ret.GetString(4) == "PremiumMember") { subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.PremiumMember; }
                        else if (ret.GetString(4) == "ExclusiveMember") { subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.ExclusiveMember; }
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

    public async Task<List<Models.ShowSubscriber?>> GET_myShowSubscribers_by_ShowID_Subscriber(string? MSToken, Guid? OBJID)
    {
        List<Models.ShowSubscriber?> subscribedShowsList = new List<Models.ShowSubscriber?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Subscribers Where FK_ShowID_Subscribie = @FK_ShowID_Subscribie Order By SubscriptionUpdateDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@FK_ShowID_Subscribie", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
                    {
                        Models.ShowSubscriber subscribedShow = new Models.ShowSubscriber();

                        subscribedShow.ID = ret.GetGuid(0);
                        subscribedShow.FK_ViewerID_Subscriber = ret.GetGuid(1);
                        subscribedShow.FK_ShowID_Subscribie = ret.GetGuid(2);
                        subscribedShow.FK_ShowSessionID = ret.GetGuid(3);

                        if (ret.GetString(4) == "Subscriber") { subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.Subscriber; }
                        else if (ret.GetString(4) == "UnSubscribed") { subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.UnSubscribed; }
                        else if (ret.GetString(4) == "PremiumMember") { subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.PremiumMember; }
                        else if (ret.GetString(4) == "ExclusiveMember") { subscribedShow.MembershipStatus = Models.SubscriberMembershipStatus.ExclusiveMember; }
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

    public async Task<Models.ShowSubscriber?> GET_aSubscriber_by_SubscriberID_with_MSToken(string? MSToken, Guid? subscriberID)
    {
        Models.ShowSubscriber showSubscriber = new Models.ShowSubscriber();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Subscribers Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", subscriberID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    showSubscriber.ID = ret.GetGuid(0);
                    showSubscriber.FK_ViewerID_Subscriber = ret.GetGuid(1);
                    showSubscriber.FK_ShowID_Subscribie = ret.GetGuid(2);
                    showSubscriber.FK_ShowSessionID = ret.GetGuid(3);

                    if (ret.GetString(4) == "Subscriber") { showSubscriber.MembershipStatus = Models.SubscriberMembershipStatus.Subscriber; }
                    else if (ret.GetString(4) == "UnSubscribed") { showSubscriber.MembershipStatus = Models.SubscriberMembershipStatus.UnSubscribed; }
                    else if (ret.GetString(4) == "PremiumMember") { showSubscriber.MembershipStatus = Models.SubscriberMembershipStatus.PremiumMember; }
                    else if (ret.GetString(4) == "ExclusiveMember") { showSubscriber.MembershipStatus = Models.SubscriberMembershipStatus.ExclusiveMember; }
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
    }//End of GET_aSubscriber_by_SubscriberID_with_MSToken


    //-----------------------GET SHOW LIKES SECTION---------------------
    public async Task<List<Models.ShowLikes?>> GET_allShowLikes(string? MSToken)
    {
        List<Models.ShowLikes?> showSessionLikes = new List<Models.ShowLikes?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowLikes Order By LikeDate DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
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

    public async Task<List<Models.ShowLikes?>> GET_myShowSessionsLikes_by_ShowSessionID(string? MSToken, Guid? OBJID)
    {
        List<Models.ShowLikes?> showSessionLikes = new List<Models.ShowLikes?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowLikes Where FK_ShowSessionID = @FK_ShowSessionID AND FK_ViewerID_Liker = (select ID From Viewers Where MSToken = @MSToken) Order By LikeDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
                command.Parameters.AddWithValue("@FK_ShowSessionID", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
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

    public async Task<List<Models.ShowLikes?>> GET_LikesOfShowSession_by_ShowSessionID(string? MSToken, Guid? OBJID)
    {
        List<Models.ShowLikes?> showSessionLikes = new List<Models.ShowLikes?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowLikes Where FK_ShowSessionID = @FK_ShowSessionID Order By LikeDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@FK_ShowSessionID", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
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

    public async Task<Models.ShowLikes?> GET_aShowLike_by_ShowLikeID_with_MSToken(string? MSToken, Guid? ShowLikeID)
    {
        Models.ShowLikes showLike = new Models.ShowLikes();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowLikes Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", ShowLikeID);
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
    }//End of GET_aShowLike_by_ShowLikeID_with_MSToken


    //-----------------------GET SHOW COMMENTS SECTION---------------------
    public async Task<List<Models.ShowComment?>> GET_allShowComments(string? MSToken)
    {
        List<Models.ShowComment?> showSessionComments = new List<Models.ShowComment?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowComments Order By CommentUpdateDate DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
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

    public async Task<List<Models.ShowComment?>> GET_myShowComments_by_ViewerID_Commenter(string? MSToken, Guid? OBJID)
    {
        List<Models.ShowComment?> showSessionComments = new List<Models.ShowComment?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowComments Where FK_ShowSessionID = @FK_ShowSessionID AND FK_ViewerID_Commenter = (select ID from Viewers where MSToken = @MSToken) Order By CommentUpdateDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
                command.Parameters.AddWithValue("@FK_ShowSessionID", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
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

    public async Task<Models.ShowComment?> GET_aShowComment_by_ShowCommentID_with_MSToken(string? MSToken, Guid? OBJID)
    {
        Models.ShowComment showComment = new Models.ShowComment();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowComments Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", OBJID);
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
    }//End of GET_aShowComment_by_ShowCommentID_with_MSToken

    //-----------------------GET SHOW DONATIONS SECTION---------------------
    public async Task<List<Models.ShowDonation?>> GET_allShowDonations(string? MSToken)
    {
        List<Models.ShowDonation?> showDonationsList = new List<Models.ShowDonation?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowDonations Order By DonationDate DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
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

    public async Task<List<Models.ShowDonation?>> GET_myShowDonations_by_ViewerID_Donater(string? MSToken)
    {
        List<Models.ShowDonation?> showDonationsList = new List<Models.ShowDonation?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowDonations Where FK_ViewerID_Donater = (select ID from Viewers Where MSToken = @MSToken) Order By DonationDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
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

    public async Task<Models.ShowDonation?> GET_aShowDonation_by_ShowDonationID_with_MSToken(string? MSToken, Guid? OBJID)
    {
        Models.ShowDonation objToReturn = new Models.ShowDonation();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowDonations Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", OBJID);
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
    }//End of GET_aShowDonation_by_ShowDonationID_with_MSToken

    //-----------------------GET SHOW SESSIONS SECTION---------------------
    public async Task<List<Models.ShowSession?>> GET_allShowSessions(string? MSToken)
    {
        List<Models.ShowSession?> showSessionsList = new List<Models.ShowSession?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowSessions Order By SessionEndDate DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
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

    public async Task<List<Models.ShowSession?>> GET_myShowSessions_by_showID(string? MSToken, Guid? OBJID)
    {
        List<Models.ShowSession?> showSessionsList = new List<Models.ShowSession?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowSessions Where FK_ShowID = @FK_ShowID Order By SessionEndDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@FK_ShowID", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
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

    public async Task<Models.ShowSession?> GET_aShowSession_by_ShowSessionID_with_MSToken(string? MSToken, Guid? OBJID)
    {
        Models.ShowSession objToReturn = new Models.ShowSession();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowSessions Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", OBJID);
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
    }//End of GET_aShowSession_by_ShowSessionID_with_MSToken


    //-----------------------GET SHOW SESSION JOINS SECTION---------------------
    public async Task<List<Models.ShowSessionJoins?>> GET_allShowSessionJoins(string? MSToken)
    {
        List<Models.ShowSessionJoins?> showSessionsList = new List<Models.ShowSessionJoins?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowSessionJoins Order By SessionLeaveDate DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
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

    public async Task<List<Models.ShowSessionJoins?>> GET_Joins_of_ShowSession_by_showSessionID(string? MSToken, Guid? OBJID)
    {
        List<Models.ShowSessionJoins?> showSessionsList = new List<Models.ShowSessionJoins?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowSessionJoins Where FK_ShowID = @FK_ShowID AND FK_ViewerID_ShowViewer = (select ID from Viewers where MSToken = @MSToken) Order By SessionLeaveDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
                command.Parameters.AddWithValue("@FK_ShowID", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
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

    public async Task<Models.ShowSessionJoins?> GET_aShowSessionJoin_by_ShowSessionJoinID_with_MSToken(string? MSToken, Guid? OBJID)
    {
        Models.ShowSessionJoins objToReturn = new Models.ShowSessionJoins();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowSessionJoins Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", OBJID);
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
    }//End of GET_aShowSession_by_ShowSessionID_with_MSToken


    //-----------------------GET SHOW COMMENT LIKES SECTION---------------------
    public async Task<List<Models.ShowCommentLike?>> GET_allShowCommentLikes(string? MSToken)
    {
        List<Models.ShowCommentLike?> showSessionsList = new List<Models.ShowCommentLike?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowCommentLikes Order By LikeDate DESC", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
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

    public async Task<List<Models.ShowCommentLike?>> GET_allLikes_of_ShowComment_by_showCommentID(string? MSToken, Guid? OBJID)
    {
        List<Models.ShowCommentLike?> showSessionsList = new List<Models.ShowCommentLike?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM ShowCommentLikes Where FK_ShowCommentID = @FK_ShowCommentID Order By LikeDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
                command.Parameters.AddWithValue("@FK_ShowCommentID", OBJID);
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
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

    public async Task<Models.ShowCommentLike?> GET_myLike_of_ShowComment_by_showCommentID(string? MSToken, Guid? OBJID)
    {
        if (MSToken != null)
        {
            Models.ShowCommentLike showCommentLike = new Models.ShowCommentLike();
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowCommentLikes Where FK_ShowCommentID = @FK_ShowCommentID AND FK_ViewerID_Liker = (select ID from Viewers where MSToken = @MSToken) Order By LikeDate DESC", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
                command.Parameters.AddWithValue("@FK_ShowCommentID", OBJID);
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

    public async Task<Models.ShowCommentLike?> GET_aShowCommentLike_by_ShowCommentLikeID_with_MSToken(string? MSToken, Guid? OBJID)
    {
        Models.ShowCommentLike objToReturn = new Models.ShowCommentLike();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM ShowCommentLikes Where ID = @ID ", _conn))
            {
                command.Parameters.AddWithValue("@ID", OBJID);
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
    }//End of GET_aShowCommentLike_by_ShowCommentLikeID_with_MSToken

    //-----------------------GET SHOW COMMENT LIKES SECTION---------------------
    public async Task<List<Models.Wallet?>> GET_allPersonalWallets(string? MSToken)
    {
        List<Models.Wallet?> allWallets = new List<Models.Wallet?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Wallets_Viewer ORDER BY DateUpdated DESC ", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
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

    public async Task<List<Models.ShowWallet?>> GET_allShowWallets(string? MSToken)
    {
        List<Models.ShowWallet?> allWallets = new List<Models.ShowWallet?>();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Wallets_Show ORDER BY DateUpdated DESC ", _conn))
            {
                _conn.Open();

                SqlDataReader ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    while (ret.Read())
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


    public async Task<Models.Wallet> GET_myPersonalWallet_by_viewerID(string? MSToken)
    {
        Models.Wallet myWallet = new Models.Wallet();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Wallets_Viewer Where FK_ViewerID_WalletOwner = (select ID from Viewers where MSToken = @MSToken) ", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
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

    public async Task<Models.ShowWallet> GET_myShowWallet_by_viewer_AND_showID(string? MSToken, Guid? OBJID)
    {
        Models.ShowWallet myShowWallet = new Models.ShowWallet();
        if (MSToken != null)
        {
            using (SqlCommand command = new SqlCommand($"SELECT TOP(1) * FROM Wallets_Show WHERE FK_ViewerID_WalletOwner = (select ID from Viewers where MSToken = @MSToken) AND FK_ShowID_WalletShow = @FK_ShowID_WalletShow ", _conn))
            {
                command.Parameters.AddWithValue("@MSToken", MSToken);
                command.Parameters.AddWithValue("@FK_ShowID_WalletShow", OBJID);
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
