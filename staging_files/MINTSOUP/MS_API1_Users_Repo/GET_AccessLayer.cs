using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MS_API1_Users_Model;
using Models;
using actions;
using Npgsql;

namespace MS_API1_Users_Repo;


public class GET_AccessLayer : IGET_AccessLayer
{
    private readonly IDBCONNECTION _conn;
    public GET_AccessLayer(IDBCONNECTION c)
    {
        this._conn = c;
    }

    //public GET_AccessLayer(IConfiguration config)
    //{
    //    _config = config;


    //    if (string.Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), "Production", StringComparison.InvariantCultureIgnoreCase))
    //    {
    //        _conn = new SqlConnection(_config["ConnectionStrings:Development"]);
    //    }
    //    else
    //    {
    //        _conn = new SqlConnection(_config["ConnectionStrings:Production"]);
    //    }

    //}

    //-----------------------GET VIEWER SECTION---------------------
    public async Task<List<Models.Viewer?>> GET_allViewers(Guid? MSToken)
    {
        List<Models.Viewer?> listOfViewers = new List<Models.Viewer?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT ID, FK_MSToken, Fn, Ln, Email, Image, Username, AboutMe, StreetAddy, " +
                                                                          //" City, State, Country, AreaCode, Role, MembershipStatus, DateSignedUp, LastSignedIn " +
                                                                          //" FROM Viewers Order By LastSignedIn DESC", _conn))
            {
                string command = $"SELECT ID, FK_MSToken, Fn, Ln, Email, Image, Username, AboutMe, StreetAddy, " +
                " City, State, Country, AreaCode, Role, MembershipStatus, DateSignedUp, LastSignedIn " +
                " FROM Viewers Order By LastSignedIn DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Models.Viewer viewer = new Models.Viewer();
                    viewer.ID = ret.GetGuid(0);
                    viewer.MSToken = ret.GetGuid(1);
                    viewer.Fn = ret.GetString(2);
                    viewer.Ln = ret.GetString(3);
                    viewer.Email = ret.GetString(4);
                    viewer.Image = ret.GetString(5);
                    viewer.Username = ret.GetString(6);
                    viewer.AboutMe = ret.GetString(7);
                    viewer.StreetAddy = ret.GetString(8);
                    viewer.City = ret.GetString(9);
                    viewer.State = ret.GetString(10);
                    viewer.Country = ret.GetString(11);
                    viewer.AreaCode = ret.GetInt32(12);

                    viewer.Role = REPO_ACTIONS.ConvertStringRole_To_ViewersRole(ret.GetString(13));
                    viewer.MembershipStatus = REPO_ACTIONS.ConvertStringStatus_To_ViewersMembershipStatus(ret.GetString(14));

                    viewer.DateSignedUp = ret.GetDateTime(15);
                    viewer.LastSignedIn = ret.GetDateTime(16);
                    Console.WriteLine($"{viewer.Username} was gotten at {DateTime.Now}");
                    listOfViewers.Add(viewer);
                }

                _conn.Close();
                Console.WriteLine($"{listOfViewers.Count} Viewers were gotten at {DateTime.Now}");
                return listOfViewers;
            }
        }
        else
        {
            return listOfViewers;
        }
    }//End of GET_allViewers

    public async Task<Models.Viewer?> GET_myViewer_by_MSToken(Guid? MSToken)
    {
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT TOP(1) * FROM Viewers Where FK_MSToken = @MSToken", _conn))
            {
                string command = $"SELECT * FROM Viewers Where FK_MSToken = @MSToken LIMIT 1";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                Models.Viewer? viewer = new Models.Viewer();
                if (ret.Read())
                {
                    viewer.ID = ret.GetGuid(0);
                    viewer.MSToken = ret.GetGuid(1);
                    viewer.Fn = ret.GetString(2);
                    viewer.Ln = ret.GetString(3);
                    viewer.Email = ret.GetString(4);
                    viewer.Image = ret.GetString(5);
                    viewer.Username = ret.GetString(6);
                    viewer.AboutMe = ret.GetString(7);
                    viewer.StreetAddy = ret.GetString(8);
                    viewer.City = ret.GetString(9);
                    viewer.State = ret.GetString(10);
                    viewer.Country = ret.GetString(11);
                    viewer.AreaCode = ret.GetInt32(12);

                    viewer.Role = REPO_ACTIONS.ConvertStringRole_To_ViewersRole(ret.GetString(13));
                    viewer.MembershipStatus = REPO_ACTIONS.ConvertStringStatus_To_ViewersMembershipStatus(ret.GetString(14));

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

    public async Task<Models.Viewer?> GET_aViewer_by_aViewerID(Guid? ViewerID)
    {
        if (ViewerID != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT TOP(1) * FROM Viewers Where ID = @ID", _conn))
            {
                string command = $"SELECT * FROM Viewers Where ID = @ID LIMIT 1";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@ID", ViewerID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Models.Viewer viewer = new Models.Viewer();
                    viewer.ID = ret.GetGuid(0);
                    viewer.MSToken = ret.GetGuid(1);
                    viewer.Fn = ret.GetString(2);
                    viewer.Ln = ret.GetString(3);
                    viewer.Email = ret.GetString(4);
                    viewer.Image = ret.GetString(5);
                    viewer.Username = ret.GetString(6);
                    viewer.AboutMe = ret.GetString(7);
                    viewer.StreetAddy = ret.GetString(8);
                    viewer.City = ret.GetString(9);
                    viewer.State = ret.GetString(10);
                    viewer.Country = ret.GetString(11);
                    viewer.AreaCode = ret.GetInt32(12);

                    viewer.Role = REPO_ACTIONS.ConvertStringRole_To_ViewersRole(ret.GetString(13));
                    viewer.MembershipStatus = REPO_ACTIONS.ConvertStringStatus_To_ViewersMembershipStatus(ret.GetString(14));

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
    public async Task<Models.Admin?> GET_myAdmin_by_MSToken(Guid? MSToken)
    {
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION()) //(NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT TOP(1) * FROM Admins Where FK_MSToken = @MSToken", _conn))
            {
                string command = $"SELECT * FROM Admins Where FK_MSToken = @MSToken LIMIT 1";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Models.Admin admin = new Models.Admin();
                    admin.ID = ret.GetGuid(0);
                    admin.MSToken = ret.GetGuid(1);
                    admin.Email = ret.GetString(2);
                    admin.Username = ret.GetString(3);
                    admin.AdminStatus = REPO_ACTIONS.ConvertStringStatus_To_AdminStatus(ret.GetString(4));
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
    public async Task<List<Models.Friend?>> GET_allFriends(Guid? MSToken)
    {
        List<Models.Friend?> friendsList = new List<Models.Friend?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM Friends where FK_ViewerID_Friender = (select ID from Viewers WHERE FK_MSToken = @MSToken ) AND FollowerStatus = 'Follower' Order By FriendUpdateDate DESC", _conn))
            {
                string command = $"SELECT * FROM Admins Where FK_MSToken = @MSToken LIMIT 1";
                using var cmd = new NpgsqlCommand(command, _conn);

                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Models.Friend friend = new Models.Friend();

                    friend.ID = ret.GetGuid(0);
                    friend.FK_ViewerID_Friender = ret.GetGuid(1);
                    friend.FK_ViewerID_Friendie = ret.GetGuid(2);

                    friend.FriendshipStatus = REPO_ACTIONS.ConvertStringStatus_To_FriendshipStatus(ret.GetString(3));

                    friend.FriendDate = ret.GetDateTime(4);
                    friend.FriendshipUpdateDate = ret.GetDateTime(5);

                    friendsList.Add(friend);
                }
                _conn.Close();
                return friendsList;
            }
        }
        else
        {
            return friendsList;
        }
    }//End of GET_allFriends

    public async Task<List<Models.Friend?>> GET_myFriends_by_ViewerID_Freinder(Guid? MSToken)
    {
        List<Models.Friend?> friendsList = new List<Models.Friend?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM Friends Where FK_ViewerID_Friender = (select ID from Viewers Where FK_MSToken = @MSToken) Order By FriendUpdateDate DESC", _conn))
            {
                string command = $"SELECT * FROM Friends Where FK_ViewerID_Friender = (select ID from Viewers Where FK_MSToken = @MSToken) Order By FriendUpdateDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Models.Friend friend = new Models.Friend();

                    friend.ID = ret.GetGuid(0);
                    friend.FK_ViewerID_Friender = ret.GetGuid(1);
                    friend.FK_ViewerID_Friendie = ret.GetGuid(2);

                    friend.FriendshipStatus = REPO_ACTIONS.ConvertStringStatus_To_FriendshipStatus(ret.GetString(3));

                    friend.FriendDate = ret.GetDateTime(4);
                    friend.FriendshipUpdateDate = ret.GetDateTime(5);

                    friendsList.Add(friend);
                }
                _conn.Close();
                return friendsList;
            }
        }
        else
        {
            return friendsList;
        }
    }//End of Get_myFriends_by_ViewerID_Freinder

    public async Task<Models.Friend?> GET_aFriend_by_ViewerID_Freinder(Guid? MSToken, Guid? FriendID)
    {
        if ((MSToken != null) && (FriendID != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT TOP(1) * FROM Friends Where ID = @ID  ", _conn))
            {
                string command = $"SELECT  * FROM Friends Where ID = @ID LIMIT 1 ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@ID", FriendID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Models.Friend friend = new Models.Friend();

                    friend.ID = ret.GetGuid(0);
                    friend.FK_ViewerID_Friender = ret.GetGuid(1);
                    friend.FK_ViewerID_Friendie = ret.GetGuid(2);

                    friend.FriendshipStatus = REPO_ACTIONS.ConvertStringStatus_To_FriendshipStatus(ret.GetString(3));

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
    public async Task<List<Models.Follower?>> GET_allFollowers(Guid? MSToken)
    {
        List<Models.Follower?> followerList = new List<Models.Follower?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM Followers Order By StatusUpdateDate DESC", _conn))
            {
                string command = $"SELECT * FROM Followers Order By StatusUpdateDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Models.Follower follower = new Models.Follower();

                    follower.ID = ret.GetGuid(0);
                    follower.FK_ViewerID_Follower = ret.GetGuid(1);
                    follower.FK_ViewerID_Followie = ret.GetGuid(2);
                    follower.FK_ShowID_Followie = ret.GetGuid(3);

                    follower.FollowerStatus = REPO_ACTIONS.ConvertStringStatus_To_FollowerStatus(ret.GetString(4));

                    follower.FollowDate = ret.GetDateTime(5);
                    follower.StatusUpdateDate = ret.GetDateTime(6);
                    followerList.Add(follower);
                }
                _conn.Close();
                return followerList;
            }
        }
        else
        {
            return followerList;
        }
    }//End of GET_allFollowers

    public async Task<List<Models.Follower?>> GET_myFollowers_by_ViewerID_Follower(Guid? MSToken)
    {
        List<Models.Follower?> followerList = new List<Models.Follower?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM Followers Where FK_ViewerID_Follower = (select ID from Viewers Where FK_MSToken = @MSToken) Order By FollowDate DESC", _conn))
            {
                string command = $"SELECT * FROM Followers Where FK_ViewerID_Follower = (select ID from Viewers Where FK_MSToken = @MSToken) Order By FollowDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Models.Follower follower = new Models.Follower();

                    follower.ID = ret.GetGuid(0);
                    follower.FK_ViewerID_Follower = ret.GetGuid(1);
                    follower.FK_ViewerID_Followie = ret.GetGuid(2);
                    follower.FK_ShowID_Followie = ret.GetGuid(3);

                    follower.FollowerStatus = REPO_ACTIONS.ConvertStringStatus_To_FollowerStatus(ret.GetString(4));

                    follower.FollowDate = ret.GetDateTime(5);
                    follower.StatusUpdateDate = ret.GetDateTime(6);
                    followerList.Add(follower);
                }
                _conn.Close();
                return followerList;
            }
        }
        else
        {
            return followerList;
        }
    }//End of Get_myFollowers_by_ViewerID_Follower

    public async Task<Models.Follower?> GET_aFollower_by_ViewerID_Followie(Guid? MSToken, Guid? Followie)
    {
        Models.Follower follower = new Models.Follower();
        if ((MSToken != null) && (Followie != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT TOP(1) * FROM Followers Where ID = @ID AND FK_ViewerID_Follower = @FK_ViewerID_Follower ", _conn))
            {
                string command = $"SELECT * FROM Followers Where FK_ViewerID_Follower = (select ID from Viewers where FK_MSToken = @MSToken) AND FK_ViewerID_Followie = @FK_Followie LIMIT 1";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_Followie", Followie);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                if (ret.Read())
                {

                    follower.ID = ret.GetGuid(0);
                    follower.FK_ViewerID_Follower = ret.GetGuid(1);
                    follower.FK_ViewerID_Followie = ret.GetGuid(2);
                    follower.FK_ShowID_Followie = ret.GetGuid(3);

                    follower.FollowerStatus = REPO_ACTIONS.ConvertStringStatus_To_FollowerStatus(ret.GetString(4));

                    follower.FollowDate = ret.GetDateTime(5);
                    follower.StatusUpdateDate = ret.GetDateTime(6);
                    _conn.Close();
                    return follower;
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
    }//End of GET_aFollower_by_ViewerID_Followie

    //-----------------------GET SHOWS SECTION---------------------
    public async Task<List<Models.Show?>> GET_allShows(Guid? MSToken)
    {
        List<Models.Show?> createdShowsList = new List<Models.Show?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM Shows Where Order By LastLive DESC", _conn))
            {
                string command = $"SELECT * FROM Shows Order By LastLive DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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

                    show.PrivacyLevel = REPO_ACTIONS.ConvertStringPL_To_PrivacyLevel(ret.GetString(10));
                    show.ShowStatus = REPO_ACTIONS.ConvertStringStanding_To_ShowStanding(ret.GetString(11));

                    show.DateCreated = ret.GetDateTime(12);
                    show.LastLive = ret.GetDateTime(12);

                    createdShowsList.Add(show);
                }
                _conn.Close();
                return createdShowsList;
            }
        }
        else
        {
            return createdShowsList;
        }
    }//End of GET_allShows

    public async Task<List<ShowSubscriber?>> GET_aShowsSubscribers_by_showID(Guid? showID)
    {
        List<ShowSubscriber?> subs = new List<ShowSubscriber?>();
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM Shows Where Order By LastLive DESC", _conn))
            {
                string command = $"SELECT * FROM Shows Order By LastLive DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                _conn.Open();
                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Models.ShowSubscriber sub = new Models.ShowSubscriber();
                    sub.ID = ret.GetGuid(0);
                    sub.FK_ViewerID_Subscriber = ret.GetGuid(1);
                    sub.FK_ShowID_Subscribie = ret.GetGuid(2);
                    sub.MembershipStatus = actions.REPO_ACTIONS.ConvertStringStatus_To_ShowSubscriptionMembershipStatus(ret.GetString(3));
                    sub.SubscribeDate = ret.GetDateTime(4);
                    sub.SubscriptionUpdateDate = ret.GetDateTime(5);
                    subs.Add(sub);
                }
                _conn.Close();
            }
            return subs;
    }

    public async Task<List<Models.Show?>> GET_myShows_by_ViewerID_Owner(Guid? MSToken)
    {
        List<Models.Show?> createdShowsList = new List<Models.Show?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM Shows Where FK_ViewerID_Owner = (select ID from Viewers WHERE FK_MSToken = @MSToken ) Order By LastLive DESC", _conn))
            {
                string command = $"SELECT * FROM Shows Where FK_ViewerID_Owner = (select ID from Viewers WHERE FK_MSToken = @MSToken ) Order By LastLive DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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

                    show.PrivacyLevel = REPO_ACTIONS.ConvertStringPL_To_PrivacyLevel(ret.GetString(10));
                    show.ShowStatus = REPO_ACTIONS.ConvertStringStanding_To_ShowStanding(ret.GetString(11));

                    show.DateCreated = ret.GetDateTime(12);
                    show.LastLive = ret.GetDateTime(12);

                    createdShowsList.Add(show);
                }
                _conn.Close();
                return createdShowsList;
            }
        }
        else
        {
            return createdShowsList;
        }
    }//End of Get_myShows_by_ViewerID_Owner

    public async Task<Models.Show?> GET_aShow_by_ShowID_with_MSToken(Guid? MSToken, Guid? showID)
    {
        Models.Show show = new Models.Show();
        if ((MSToken != null) && (showID != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT TOP(1) * FROM Shows Where ID = @ID ", _conn))
            {
                string command = $"SELECT * FROM Shows Where ID = @ID LIMIT 1";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@ID", showID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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

                    show.PrivacyLevel = REPO_ACTIONS.ConvertStringPL_To_PrivacyLevel(ret.GetString(10));
                    show.ShowStatus = REPO_ACTIONS.ConvertStringStanding_To_ShowStanding(ret.GetString(11));

                    show.DateCreated = ret.GetDateTime(12);
                    show.LastLive = ret.GetDateTime(12);

                    _conn.Close();
                    return show;
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
    }//End of GET_aShow_by_ShowID_with_MSToken


    //-----------------------GET SHOW SUBSCRIBERS SECTION---------------------
    public async Task<List<Models.ShowSubscriber?>> GET_allShowSubscriber(Guid? MSToken)
    {
        List<Models.ShowSubscriber?> subscribedShowsList = new List<Models.ShowSubscriber?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM Subscribers Order By LastLive DESC", _conn))
            {
                string command = $"SELECT * FROM Subscribers Order By LastLive DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Models.ShowSubscriber subscribedShow = new Models.ShowSubscriber();

                    Models.ShowSubscriber sub = new Models.ShowSubscriber();
                    sub.ID = ret.GetGuid(0);
                    sub.FK_ViewerID_Subscriber = ret.GetGuid(1);
                    sub.FK_ShowID_Subscribie = ret.GetGuid(2);
                    sub.MembershipStatus = actions.REPO_ACTIONS.ConvertStringStatus_To_ShowSubscriptionMembershipStatus(ret.GetString(3));
                    sub.SubscribeDate = ret.GetDateTime(4);
                    sub.SubscriptionUpdateDate = ret.GetDateTime(5);

                    subscribedShowsList.Add(sub);
                }
                _conn.Close();
                return subscribedShowsList;
            }
        }
        else
        {
            return subscribedShowsList;
        }
    }//End of GET_allShowSubscriber

    public async Task<List<Models.ShowSubscriber?>> GET_myShowSubscriptions_by_ViewerID_Subscriber(Guid? MSToken)
    {
        List<Models.ShowSubscriber?> subscribedShowsList = new List<Models.ShowSubscriber?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM Subscribers Where FK_ViewerID_Subscriber = (select ID from Viewers WHERE FK_MSToken = @MSToken ) Order By SubscriptionUpdateDate DESC", _conn))
            {
                string command = $"SELECT * FROM Subscribers Where FK_ViewerID_Subscriber = (select ID from Viewers WHERE FK_MSToken = @MSToken ) Order By SubscriptionUpdateDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Models.ShowSubscriber sub = new Models.ShowSubscriber();
                    sub.ID = ret.GetGuid(0);
                    sub.FK_ViewerID_Subscriber = ret.GetGuid(1);
                    sub.FK_ShowID_Subscribie = ret.GetGuid(2);
                    sub.MembershipStatus = actions.REPO_ACTIONS.ConvertStringStatus_To_ShowSubscriptionMembershipStatus(ret.GetString(3));
                    sub.SubscribeDate = ret.GetDateTime(4);
                    sub.SubscriptionUpdateDate = ret.GetDateTime(5);

                    subscribedShowsList.Add(sub);
                }
                _conn.Close();
                return subscribedShowsList;
            }
        }
        else
        {
            return subscribedShowsList;
        }
    }//End of Get_myShowSubscriptions_by_ViewerID_Subscriber

    public async Task<List<Models.ShowSubscriber?>> GET_myShowSubscribers_by_ShowID_Subscriber(Guid? MSToken, Guid? ShowID)
    {
        List<Models.ShowSubscriber?> subscribedShowsList = new List<Models.ShowSubscriber?>();
        if ((MSToken != null) && (ShowID != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM Subscribers Where FK_ShowID_Subscribie = @FK_ShowID_Subscribie  AND FK_ViewerID_Subscriber = (select ID from Viewers where FK_MSToken = @MSToken ) Order By SubscriptionUpdateDate DESC", _conn))
            {
                string command = $"SELECT * FROM Subscribers Where FK_ShowID_Subscribie = @FK_ShowID_Subscribie  AND FK_ViewerID_Subscriber = (select ID from Viewers where FK_MSToken = @MSToken ) Order By SubscriptionUpdateDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ShowID_Subscribie", ShowID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Models.ShowSubscriber sub = new Models.ShowSubscriber();
                    sub.ID = ret.GetGuid(0);
                    sub.FK_ViewerID_Subscriber = ret.GetGuid(1);
                    sub.FK_ShowID_Subscribie = ret.GetGuid(2);
                    sub.MembershipStatus = actions.REPO_ACTIONS.ConvertStringStatus_To_ShowSubscriptionMembershipStatus(ret.GetString(3));
                    sub.SubscribeDate = ret.GetDateTime(4);
                    sub.SubscriptionUpdateDate = ret.GetDateTime(5);

                    subscribedShowsList.Add(sub);
                }
                _conn.Close();
                return subscribedShowsList;
            }
        }
        else
        {
            return subscribedShowsList;
        }
    }//End of GET_myShowSubscribers_by_ShowID_Subscriber

    public async Task<Models.ShowSubscriber?> GET_aSubscriber_by_SubscriberID_with_MSToken(Guid? MSToken, Guid? subscriberID)
    {
        Models.ShowSubscriber showSubscriber = new Models.ShowSubscriber();
        if ((MSToken != null) && (subscriberID != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT TOP(1) * FROM Subscribers Where ID = @ID ", _conn))
            {
                string command = $"SELECT * FROM Subscribers Where ID = @ID LIMIT 1";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@ID", subscriberID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                if (ret.Read())
                {
                    Models.ShowSubscriber sub = new Models.ShowSubscriber();
                    sub.ID = ret.GetGuid(0);
                    sub.FK_ViewerID_Subscriber = ret.GetGuid(1);
                    sub.FK_ShowID_Subscribie = ret.GetGuid(2);
                    sub.MembershipStatus = actions.REPO_ACTIONS.ConvertStringStatus_To_ShowSubscriptionMembershipStatus(ret.GetString(3));
                    sub.SubscribeDate = ret.GetDateTime(4);
                    sub.SubscriptionUpdateDate = ret.GetDateTime(5);

                    _conn.Close();
                    return sub;
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
    }//End of GET_aSubscriber_by_SubscriberID_with_MSToken


    //-----------------------GET SHOW LIKES SECTION---------------------
    public async Task<List<Models.ShowLikes?>> GET_allShowLikes(Guid? MSToken)
    {
        List<Models.ShowLikes?> showSessionLikes = new List<Models.ShowLikes?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM ShowLikes Order By LikeDate DESC", _conn))
            {
                string command = $"SELECT * FROM ShowLikes Order By LikeDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
        }
        else
        {
            return showSessionLikes;
        }
    }//End of GET_allShowLikes

    public async Task<List<Models.ShowLikes?>> GET_myShowSessionsLikes_by_ShowSessionID(Guid? MSToken, Guid? showsessionID)
    {
        List<Models.ShowLikes?> showSessionLikes = new List<Models.ShowLikes?>();
        if ((MSToken != null) && (showsessionID != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM ShowLikes Where FK_ShowSessionID = @FK_ShowSessionID AND FK_ViewerID_Liker = (select ID From Viewers WHERE FK_MSToken = @MSToken ) Order By LikeDate DESC", _conn))
            {
                string command = $"SELECT * FROM ShowLikes Where FK_ShowSessionID = @FK_ShowSessionID AND FK_ViewerID_Liker = (select ID From Viewers WHERE FK_MSToken = @MSToken ) Order By LikeDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ShowSessionID", showsessionID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
        }
        else
        {
            return showSessionLikes;
        }
    }//End of GET_myShowSessionsLikes_by_ShowSessionID

    public async Task<List<Models.ShowLikes?>> GET_LikesOfShowSession_by_ShowSessionID(Guid? MSToken, Guid? ShowSessionID)
    {
        List<Models.ShowLikes?> showSessionLikes = new List<Models.ShowLikes?>();
        if ((MSToken != null) && (ShowSessionID != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM ShowLikes Where FK_ShowSessionID = @FK_ShowSessionID Order By LikeDate DESC", _conn))
            {
                string command = $"SELECT * FROM ShowLikes Where FK_ShowSessionID = @FK_ShowSessionID Order By LikeDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@FK_ShowSessionID", ShowSessionID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
        }
        else
        {
            return showSessionLikes;
        }
    }//End of GET_LikesOfShowSession_by_ShowSessionID

    public async Task<Models.ShowLikes?> GET_aShowLike_by_ShowSessionID_with_MSToken(Guid? MSToken, Guid? FK_ShowSessionID)
    {
        Models.ShowLikes showLike = new Models.ShowLikes();
        if ((MSToken != null) && (FK_ShowSessionID != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT TOP(1) * FROM ShowLikes Where ID = @ID ", _conn))
            {
                string command = $"SELECT * FROM ShowLikes Where FK_ViewerID_Liker = (select ID from Viewers where FK_MSToken = @MSToken) AND FK_ShowSessionID = @FK_ShowSessionID LIMIT 1";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ShowSessionID", FK_ShowSessionID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
                    return null;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aShowLike_by_ShowLikeID_with_MSToken


    //-----------------------GET SHOW COMMENTS SECTION---------------------
    public async Task<List<Models.ShowComment?>> GET_allShowComments(Guid? MSToken)
    {
        List<Models.ShowComment?> showSessionComments = new List<Models.ShowComment?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM ShowComments Order By CommentUpdateDate DESC", _conn))
            {
                string command = $"SELECT * FROM ShowComments Order By CommentUpdateDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
        }
        else
        {
            return showSessionComments;
        }
    }//End of GET_allShowComments

    public async Task<List<Models.ShowComment?>> GET_myShowComments_by_ViewerID_Commenter(Guid? MSToken, Guid? ShowSessionID)
    {
        List<Models.ShowComment?> showSessionComments = new List<Models.ShowComment?>();
        if ((MSToken != null) && (ShowSessionID != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM ShowComments Where FK_ShowSessionID = @FK_ShowSessionID AND FK_ViewerID_Commenter = (select ID from Viewers WHERE FK_MSToken = @MSToken ) Order By CommentUpdateDate DESC", _conn))
            {
                string command = $"SELECT * FROM ShowComments Where FK_ShowSessionID = @FK_ShowSessionID AND FK_ViewerID_Commenter = (select ID from Viewers WHERE FK_MSToken = @MSToken ) Order By CommentUpdateDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ShowSessionID", ShowSessionID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
        }
        else
        {
            return showSessionComments;
        }
    }//End of Get_myShowComments_by_ViewerID_Commenter

    public async Task<Models.ShowComment?> GET_aShowComment_by_ShowCommentID_with_MSToken(Guid? MSToken, Guid? commentID)
    {
        Models.ShowComment showComment = new Models.ShowComment();
        if ((MSToken != null) && (commentID != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT TOP(1) * FROM ShowComments Where ID = @ID ", _conn))
            {
                string command = $"SELECT * FROM ShowComments Where ID = @ID AND FK_ViewerID_Commenter = (select ID from Viewers where FK_MSToken = @MSToken ) LIMIT 1";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@ID", commentID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
                    return null;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aShowComment_by_ShowCommentID_with_MSToken

    //-----------------------GET SHOW DONATIONS SECTION---------------------
    public async Task<List<Models.ShowDonation?>> GET_allShowDonations(Guid? MSToken)
    {
        List<Models.ShowDonation?> showDonationsList = new List<Models.ShowDonation?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM ShowDonations Order By DonationDate DESC", _conn))
            {
                string command = $"SELECT * FROM ShowDonations Order By DonationDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
        }
        else
        {
            return showDonationsList;
        }
    }//End of GET_allShowDonations

    public async Task<List<Models.ShowDonation?>> GET_myShowDonations_by_ViewerID_Donater(Guid? MSToken)
    {
        List<Models.ShowDonation?> showDonationsList = new List<Models.ShowDonation?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM ShowDonations Where FK_ViewerID_Donater = (select ID from Viewers WHERE FK_MSToken = @MSToken ) Order By DonationDate DESC", _conn))
            {
                string command = $"SELECT * FROM ShowDonations Where FK_ViewerID_Donater = (select ID from Viewers WHERE FK_MSToken = @MSToken ) Order By DonationDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
        }
        else
        {
            return showDonationsList;
        }
    }//End of Get_myShowDonations_by_ViewerID_Donater

    public async Task<Models.ShowDonation?> GET_aShowDonation_by_ShowDonationID_with_MSToken(Guid? MSToken, Guid? donationid)
    {
        Models.ShowDonation objToReturn = new Models.ShowDonation();
        if ((MSToken != null) && (donationid != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT TOP(1) * FROM ShowDonations Where ID = @ID ", _conn))
            {
                string command = $"SELECT * FROM ShowDonations Where ID = @ID LIMIT 1";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@ID", donationid);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
                    return null;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aShowDonation_by_ShowDonationID_with_MSToken

    //-----------------------GET SHOW SESSIONS SECTION---------------------
    public async Task<List<Models.ShowSession?>> GET_allShowSessions(Guid? MSToken)
    {
        List<Models.ShowSession?> showSessionsList = new List<Models.ShowSession?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM ShowSessions Order By SessionEndDate DESC", _conn))
            {
                string command = $"SELECT * FROM ShowSessions Order By SessionEndDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
        }
        else
        {
            return showSessionsList;
        }
    }//End of GET_allShowSessions

    public async Task<List<Models.ShowSession?>> GET_myShowSessions_by_showID(Guid? MSToken, Guid? ShowID)
    {
        List<Models.ShowSession?> showSessionsList = new List<Models.ShowSession?>();
        if ((MSToken != null) && (ShowID != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM ShowSessions Where FK_ShowID = @ShowID AND Where FK_ShowID = (select ID from Viewers WHERE FK_MSToken = @MSToken )) Order By SessionEndDate DESC", _conn))
            {
                string command = $"SELECT * FROM ShowSessions Where FK_ShowID = @ShowID AND Where FK_ShowID = (select ID from Viewers WHERE FK_MSToken = @MSToken )) Order By SessionEndDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@ShowID", ShowID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
        }
        else
        {
            return showSessionsList;
        }
    }//End of Get_myShowDonations_by_ViewerID_Donater

    public async Task<Models.ShowSession?> GET_aShowSession_by_ShowSessionID_with_MSToken(Guid? MSToken, Guid? ShowSessionID)
    {
        Models.ShowSession objToReturn = new Models.ShowSession();
        if ((MSToken != null) && (ShowSessionID != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT TOP(1) * FROM ShowSessions Where ID = @ID ", _conn))
            {
                string command = $"SELECT TOP(1) * FROM ShowSessions Where ID = @ID ";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@ID", ShowSessionID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
                    return null;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aShowSession_by_ShowSessionID_with_MSToken


    //-----------------------GET SHOW SESSION JOINS SECTION---------------------
    public async Task<List<Models.ShowSessionJoins?>> GET_allShowSessionJoins(Guid? MSToken)
    {
        List<Models.ShowSessionJoins?> showSessionsList = new List<Models.ShowSessionJoins?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM ShowSessionJoins Order By SessionLeaveDate DESC", _conn))
            {
                string command = $"SELECT * FROM ShowSessionJoins Order By SessionLeaveDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
        }
        else
        {
            return showSessionsList;
        }
    }//End of GET_allShowSessionJoins

    public async Task<List<Models.ShowSessionJoins?>> GET_all_of_my_Joins_of_ShowSession_by_showSessionID(Guid? MSToken, Guid? ShowSessionID)
    {
        List<Models.ShowSessionJoins?> showSessionsList = new List<Models.ShowSessionJoins?>();
        if ((MSToken != null) && (ShowSessionID != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM ShowSessionJoins Where FK_ShowSessionID = @FK_ShowSessionID AND FK_ViewerID_ShowViewer = (select ID from Viewers WHERE FK_MSToken = @MSToken ) Order By SessionLeaveDate DESC", _conn))
            {
                string command = $"SELECT * FROM ShowSessionJoins Where FK_ShowSessionID = @FK_ShowSessionID AND FK_ViewerID_ShowViewer = (select ID from Viewers WHERE FK_MSToken = @MSToken ) Order By SessionLeaveDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ShowSessionID", ShowSessionID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
        }
        else
        {
            return showSessionsList;
        }
    }//End of Get_myShowDonations_by_ViewerID_Donater

    public async Task<Models.ShowSessionJoins?> GET_aShowSessionJoin_by_ShowSessionJoinID_with_MSToken(Guid? MSToken, Guid? SessionJoinID)
    {
        Models.ShowSessionJoins objToReturn = new Models.ShowSessionJoins();
        if ((MSToken != null) && (SessionJoinID != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT TOP(1) * FROM ShowSessionJoins Where ID = @ID ", _conn))
            {
                string command = $"SELECT * FROM ShowSessionJoins Where ID = @ID LIMIT 1";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@ID", SessionJoinID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
                    return null;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aShowSession_by_ShowSessionID_with_MSToken


    //-----------------------GET SHOW COMMENT LIKES SECTION---------------------
    public async Task<List<Models.ShowCommentLike?>> GET_allShowCommentLikes(Guid? MSToken)
    {
        List<Models.ShowCommentLike?> showSessionsList = new List<Models.ShowCommentLike?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM ShowCommentLikes Order By LikeDate DESC", _conn))
            {
                string command = $"SELECT * FROM ShowCommentLikes Order By LikeDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
        }
        else
        {
            return showSessionsList;
        }
    }//End of GET_allShowCommentLikes

    public async Task<List<Models.ShowCommentLike?>> GET_allLikes_of_ShowComment_by_showCommentID(Guid? MSToken, Guid? CommentID)
    {
        List<Models.ShowCommentLike?> showSessionsList = new List<Models.ShowCommentLike?>();
        if ((MSToken != null) && (CommentID != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM ShowCommentLikes Where FK_ShowCommentID = @FK_ShowCommentID Order By LikeDate DESC", _conn))
            {
                string command = $"SELECT * FROM ShowCommentLikes Where FK_ShowCommentID = @FK_ShowCommentID Order By LikeDate DESC";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@FK_ShowCommentID", CommentID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
        }
        else
        {
            return showSessionsList;
        }
    }//End of GET_allLikes_of_ShowComment_by_showCommentID

    public async Task<Models.ShowCommentLike?> GET_myLike_of_ShowComment_by_showCommentID(Guid? MSToken, Guid? CommentID)
    {
        if ((MSToken != null) && (CommentID != null))
        {
            Models.ShowCommentLike showCommentLike = new Models.ShowCommentLike();
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT TOP(1) * FROM ShowCommentLikes Where FK_ShowCommentID = @FK_ShowCommentID AND FK_ViewerID_Liker = (select ID from Viewers WHERE FK_MSToken = @MSToken ) Order By LikeDate DESC", _conn))
            {
                string command = $"SELECT * FROM ShowCommentLikes Where FK_ShowCommentID = @FK_ShowCommentID AND FK_ViewerID_Liker = (select ID from Viewers WHERE FK_MSToken = @MSToken ) Order By LikeDate DESC LIMIT 1";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ShowCommentID", CommentID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
                    return null;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of Get_myShowDonations_by_ViewerID_Donater

    public async Task<Models.ShowCommentLike?> GET_aShowCommentLike_by_ShowCommentID_with_MSToken(Guid? MSToken, Guid? CommentID)
    {
        Models.ShowCommentLike objToReturn = new Models.ShowCommentLike();
        if ((MSToken != null) && (CommentID != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT TOP(1) * FROM ShowCommentLikes Where ID = @ID ", _conn))
            {
                string command = $"SELECT * FROM ShowCommentLikes Where FK_ViewerID_Liker = (select ID Viewers where FK_MSToken = @MSToken) AND FK_ShowCommentID_Likie = @FK_ShowCommentID_Likie LIMIT 1";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ShowCommentID_Likie", CommentID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
                    return null;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_aShowCommentLike_by_ShowCommentLikeID_with_MSToken

    //-----------------------GET SHOW COMMENT LIKES SECTION---------------------
    public async Task<List<Models.Wallet?>> GET_allPersonalWallets(Guid? MSToken)
    {
        List<Models.Wallet?> allWallets = new List<Models.Wallet?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM Wallets_Viewer ORDER BY DateUpdated DESC ", _conn))
            {
                string command = $"SELECT * FROM Wallets_Viewer ORDER BY DateUpdated DESC ";
                using var cmd = new NpgsqlCommand(command, _conn);

                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
        }
        else
        {
            return allWallets;
        }
    }//End of GET_allPersonalWallets

    public async Task<List<Models.ShowWallet?>> GET_allShowWallets(Guid? MSToken)
    {
        List<Models.ShowWallet?> allWallets = new List<Models.ShowWallet?>();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT * FROM Wallets_Show ORDER BY DateUpdated DESC ", _conn))
            {
                string command = $"SELECT * FROM Wallets_Show ORDER BY DateUpdated DESC ";
                using var cmd = new NpgsqlCommand(command, _conn);

                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
        }
        else
        {
            return allWallets;
        }
    }//End of GET_allShowWallets


    public async Task<Models.Wallet?> GET_myPersonalWallet_by_viewerID(Guid? MSToken)
    {
        Models.Wallet myWallet = new Models.Wallet();
        if (MSToken != null)
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT TOP(1) * FROM Wallets_Viewer Where FK_ViewerID_WalletOwner = (select ID from Viewers WHERE FK_MSToken = @MSToken ) ", _conn))
            {
                string command = $"SELECT * FROM Wallets_Viewer Where FK_ViewerID_WalletOwner = (select ID from Viewers WHERE FK_MSToken = @MSToken ) LIMIT 1";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
                    return null;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_myPersonalWallet_by_viewerID

    public async Task<Models.ShowWallet?> GET_myShowWallet_by_viewer_AND_showID(Guid? MSToken, Guid? ShowID)
    {
        Models.ShowWallet myShowWallet = new Models.ShowWallet();
        if ((MSToken != null) && (ShowID != null))
        {
            using (NpgsqlConnection _conn = this._conn.GETDBCONNECTION())// = new SqlCommand($"SELECT TOP(1) * FROM Wallets_Show WHERE FK_ViewerID_WalletOwner = (select ID from Viewers WHERE FK_MSToken = @MSToken ) AND FK_ShowID_WalletShow = @FK_ShowID_WalletShow ", _conn))
            {
                string command = $"SELECT * FROM Wallets_Show WHERE FK_ViewerID_WalletOwner = (select ID from Viewers WHERE FK_MSToken = @MSToken ) AND FK_ShowID_WalletShow = @FK_ShowID_WalletShow LIMIT 1";
                using var cmd = new NpgsqlCommand(command, _conn);

                cmd.Parameters.AddWithValue("@MSToken", MSToken);
                cmd.Parameters.AddWithValue("@FK_ShowID_WalletShow", ShowID);
                _conn.Open();

                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
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
                    return null;
                }
            }
        }
        else
        {
            return null;
        }
    }//End of GET_myShowWallet_by_viewer_AND_showID

    public async Task<List<ShowSessionJoins?>> GET_aShowsJoinSessions(Guid? showid)
    {
        List<Models.ShowSessionJoins?> joinsList = new List<Models.ShowSessionJoins?>();
        if(showid.HasValue)
        {
            using (NpgsqlConnection connection = this._conn.GETDBCONNECTION())
            {
                string command = $"SELECT * FROM ShowSessionJoins where FK_ShowSessionID = (select ID from ShowSessions where FK_ShowID = @FK_ShowID) ";
                using var cmd = new NpgsqlCommand(command, connection);

                cmd.Parameters.AddWithValue("@FK_ShowID", showid);
                connection.Open();
                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                while(ret.Read())
                {
                    ShowSessionJoins obj = new ShowSessionJoins();
                    obj.ID = ret.GetGuid(0);
                    obj.FK_ShowSessionsID = ret.GetGuid(1);
                    obj.FK_ViewerID_ShowViewer = ret.GetGuid(2);

                    obj.SessionJoinDate = ret.GetDateTime(3);
                    obj.SessionLeaveDate = ret.GetDateTime(4);
                    joinsList.Add(obj);

                }
                connection.Close();
            }
            Console.WriteLine($"A show's list of session joins was just GOTTEN at {DateTime.UtcNow} for {showid}");
            return joinsList;
        }
        Console.WriteLine($"A show's list of session joins was just NOT GOTTEN at {DateTime.UtcNow} for {showid}");
        return joinsList;
    }

    public async Task<List<ShowSession?>> GET_aShowsSessions(Guid? showid)
    {
        List<ShowSession?> showsessionlist = new List<ShowSession?>();
        if (showid.HasValue)
        {
            using (NpgsqlConnection connection = this._conn.GETDBCONNECTION())
            {
                string command = $"SELECT * FROM ShowSessions where FK_ShowID = @FK_ShowID ";
                using var cmd = new NpgsqlCommand(command, connection);

                cmd.Parameters.AddWithValue("@FK_ShowID", showid);
                connection.Open();
                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                while (ret.Read())
                {
                    ShowSession obj = new ShowSession();
                    obj.ID = ret.GetGuid(0);
                    obj.FK_ShowID = ret.GetGuid(1);
                    obj.Views = ret.GetInt32(2);
                    obj.Likes = ret.GetInt32(3);
                    obj.Comments = ret.GetInt32(4);

                    obj.SessionStartDate = ret.GetDateTime(5);
                    obj.SessionEndDate = ret.GetDateTime(6);
                    showsessionlist.Add(obj);

                }
                connection.Close();
            }
            Console.WriteLine($"A show's list of sessions was just GOTTEN at {DateTime.UtcNow} for {showid}");
            return showsessionlist;
        }
        Console.WriteLine($"A show's list of sessions was just NOT GOTTEN at {DateTime.UtcNow} for {showid}");
        return showsessionlist;
    }

    public async Task<List<Follower?>> GET_aShowsFollowers_by_showID(Guid? showid)
    {
        List<Follower?> showfollowers = new List<Follower?>();
        if (showid.HasValue)
        {
            using (NpgsqlConnection connection = this._conn.GETDBCONNECTION())
            {
                string command = $"SELECT * FROM Followers where FK_ShowID_Followie = @FK_ShowID ";
                using var cmd = new NpgsqlCommand(command, connection);

                cmd.Parameters.AddWithValue("@FK_ShowID", showid);
                connection.Open();
                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                while (ret.Read())
                {
                    Follower obj = new Follower();
                    obj.ID = ret.GetGuid(0);
                    obj.FK_ViewerID_Follower = ret.GetGuid(1);
                    obj.FK_ViewerID_Followie = ret.GetGuid(2);
                    obj.FK_ShowID_Followie = ret.GetGuid(3);
                    obj.FollowerStatus =  actions.REPO_ACTIONS.ConvertStringStatus_To_FollowerStatus( ret.GetString(4));
                    obj.FollowDate = ret.GetDateTime(5);

                    obj.StatusUpdateDate = ret.GetDateTime(5);
                    showfollowers.Add(obj);

                }
                connection.Close();
            }
            Console.WriteLine($"A show's list of followers was just GOTTEN at {DateTime.UtcNow} for {showid}");
            return showfollowers;
        }
        Console.WriteLine($"A show's list of followers was just NOT GOTTEN at {DateTime.UtcNow} for {showid}");
        return showfollowers;
    }

    public async Task<List<ShowLikes?>> GET_aShowsLikes_by_showID(Guid? showid)
    {
        List<ShowLikes?> showlikes = new List<ShowLikes?>();
        if (showid.HasValue)
        {
            using (NpgsqlConnection connection = this._conn.GETDBCONNECTION())
            {
                string command = $"SELECT * FROM ShowLikes where FK_ShowSessionID = (select ID from ShowSessions where FK_ShowID = @FK_ShowID) ";
                using var cmd = new NpgsqlCommand(command, connection);

                cmd.Parameters.AddWithValue("@FK_ShowID", showid);
                connection.Open();
                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                while (ret.Read())
                {
                    ShowLikes obj = new ShowLikes();
                    obj.ID = ret.GetGuid(0);
                    obj.FK_ViewerID_Liker = ret.GetGuid(1);
                    obj.FK_ShowSessionID = ret.GetGuid(2);
                    obj.LikeDate = ret.GetDateTime(3);
                    showlikes.Add(obj);

                }
                connection.Close();
            }
            Console.WriteLine($"A show's list of showlikes was just GOTTEN at {DateTime.UtcNow} for {showid}");
            return showlikes;
        }
        Console.WriteLine($"A show's list of showlikes was just NOT GOTTEN at {DateTime.UtcNow} for {showid}");
        return showlikes;
    }

    public async Task<List<ShowComment?>> GET_aShowsComments_by_showID(Guid? showid)
    {
        List<ShowComment?> showcomments = new List<ShowComment?>();
        if (showid.HasValue)
        {
            using (NpgsqlConnection connection = this._conn.GETDBCONNECTION())
            {
                string command = $"SELECT * FROM ShowComments where FK_ShowSessionID = (select ID from ShowSessions where FK_ShowID = @FK_ShowID) ";
                using var cmd = new NpgsqlCommand(command, connection);

                cmd.Parameters.AddWithValue("@FK_ShowID", showid);
                connection.Open();
                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                while (ret.Read())
                {
                    ShowComment obj = new ShowComment();
                    obj.ID = ret.GetGuid(0);
                    obj.FK_ViewerID_Commenter = ret.GetGuid(1);
                    obj.FK_ShowSessionID = ret.GetGuid(2);
                    obj.Comment = ret.GetString(3);
                    obj.CommentDate = ret.GetDateTime(4);
                    showcomments.Add(obj);

                }
                connection.Close();
            }
            Console.WriteLine($"A show's list of showcomments was just GOTTEN at {DateTime.UtcNow} for {showid}");
            return showcomments;
        }
        Console.WriteLine($"A show's list of showcomments was just NOT GOTTEN at {DateTime.UtcNow} for {showid}");
        return showcomments;
    }

    public async Task<List<ShowDonation?>> GET_aShowsDonations_by_showID(Guid? showid)
    {
        List<ShowDonation?> showDonations = new List<ShowDonation?>();
        if (showid.HasValue)
        {
            using (NpgsqlConnection connection = this._conn.GETDBCONNECTION())
            {
                string command = $"SELECT * FROM ShowDonations where FK_Wallets_ShowID = @FK_ShowID_Donatie ";
                using var cmd = new NpgsqlCommand(command, connection);

                cmd.Parameters.AddWithValue("@FK_ShowID_Donatie", showid);
                connection.Open();
                NpgsqlDataReader ret = await cmd.ExecuteReaderAsync();
                while (ret.Read())
                {
                    ShowDonation obj = new ShowDonation();
                    obj.ID = ret.GetGuid(0);
                    obj.FK_ViewerID_Donater = ret.GetGuid(1);
                    obj.FK_WalletID = ret.GetGuid(2);
                    obj.FK_ShowID_Donatie = ret.GetGuid(3);
                    obj.Amount = ret.GetDecimal(4);
                    obj.Note = ret.GetString(5);
                    obj.DonationDate = ret.GetDateTime(4);
                    showDonations.Add(obj);

                }
                connection.Close();
            }
            Console.WriteLine($"A show's list of showDonations was just GOTTEN at {DateTime.UtcNow} for {showid}");
            return showDonations;
        }
        Console.WriteLine($"A show's list of showDonations was just NOT GOTTEN at {DateTime.UtcNow} for {showid}");
        return showDonations;
    }

    //Task<List<ShowSessionJoins?>> GET_aShowsJoinSessions(Guid? Showid);
    //Task<List<ShowSession?>> GET_aShowsSessions(Guid? showID);
    //Task<List<Follower?>> GET_aShowsFollowers_by_showID(Guid? showID);
    //Task<List<ShowLikes?>> GET_aShowsLikes_by_showID(Guid? showID);
    //Task<List<ShowComment?>> GET_aShowsComments_by_showID(Guid? showID);
    //Task<List<ShowDonation?>> GET_aShowsDonations_by_showID(Guid? showID);





}
