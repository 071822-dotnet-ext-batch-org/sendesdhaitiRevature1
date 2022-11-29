using System;
using Models;
using MS_API1_Users_Repo;
using static System.Formats.Asn1.AsnWriter;

namespace actions
{
    public class REPO_ACTIONS
    {
        private static CHECK_AccessLayer.CHECKSTATUS checkstatus;
        private static ViewerStatus viewersMembershipStatus;
        private static Role viewersrole;
        private static SubscriberMembershipStatus viewersSubscriberStatus;
        private static AdminStatus adminsstatus;
        private static FriendShipStatus viewersFriendshipStatus;
        private static FollowerStatus viewerFollowerStatus;
        private static PrivacyLevel showPrivacyLvl;
        private static ShowStanding showStanding;

        private static CHECK_AccessLayer.CHECKSTATUS GetCheckstatus()
        {
            return checkstatus;
        }

        private static void SetCheckstatus(CHECK_AccessLayer.CHECKSTATUS value)
        {
            checkstatus = value;
        }

        //show
        private static ShowStanding GetShowStanding()
        {
            return showStanding;
        }

        private static void SetShowStanding(ShowStanding value)
        {
            showStanding = value;
        }

        private static PrivacyLevel GetShowPrivacyLvl()
        {
            return showPrivacyLvl;
        }

        private static void SetShowPrivacyLvl(PrivacyLevel value)
        {
            showPrivacyLvl = value;
        }



        //follower
        private static FollowerStatus GetViewerFollowerStatus()
        {
            return viewerFollowerStatus;
        }

        private static void SetViewerFollowerStatus(FollowerStatus value)
        {
            viewerFollowerStatus = value;
        }

        //friendship
        private static FriendShipStatus GetViewersFriendshipStatus()
        {
            return viewersFriendshipStatus;
        }

        private static void SetViewersFriendshipStatus(FriendShipStatus value)
        {
            viewersFriendshipStatus = value;
        }

        //subscriber
        private static SubscriberMembershipStatus GetViewersSubscriberStatus()
        {
            return viewersSubscriberStatus;
        }

        private static void SetViewersSubscriberStatus(SubscriberMembershipStatus value)
        {
            viewersSubscriberStatus = value;
        }

        //role
        private static Role GetviewersRole()
        {
            return viewersrole;
        }

        private static void SetviewersRole(Role value)
        {
            viewersrole = value;
        }

        //admin status
        private static AdminStatus GetAdminsstatus()
        {
            return adminsstatus;
        }

        private static void SetAdminsstatus(AdminStatus value)
        {
            adminsstatus = value;
        }

        
        //viewer status
        private static ViewerStatus GetviewersMembershipStatus()
        {
            return viewersMembershipStatus;
        }

        private static void SetviewersMembershipStatus(ViewerStatus value)
        {
            viewersMembershipStatus = value;
        }



        //------------------------OPERATIONS SECTION---------------------------
        public REPO_ACTIONS()
        {
        }
        public static Models.Role ConvertStringRole_To_ViewersRole(string stringRole)
        {

            if (stringRole == "Viewer") { SetviewersRole(Models.Role.Viewer); }
            else if (stringRole == "Host") { SetviewersRole(Models.Role.Host); }
            else if (stringRole == "Admin") { SetviewersRole(Models.Role.Admin); }
            else SetviewersRole(Models.Role.Viewer);
            return GetviewersRole();

        }
        public static Models.ViewerStatus ConvertStringStatus_To_ViewersMembershipStatus(string stringStatus)
        {
            if (stringStatus == "Viewer")
            {
                SetviewersMembershipStatus(Models.ViewerStatus.Viewer);
                return GetviewersMembershipStatus();
            }
            else
            {
                SetviewersMembershipStatus(Models.ViewerStatus.Guest);
                return GetviewersMembershipStatus();
            }
        }

        public static Models.AdminStatus ConvertStringStatus_To_AdminStatus(string stringStatus)
        {
            if (stringStatus == "Admin") {  SetAdminsstatus( Models.AdminStatus.Admin); }
            else
            {
                 SetAdminsstatus(Models.AdminStatus.NonAdmin);
            }
            return GetAdminsstatus();
        }

        public static Models.FriendShipStatus ConvertStringStatus_To_FriendshipStatus(string stringStatus)
        {
            if (stringStatus == "Friend") { SetViewersFriendshipStatus( Models.FriendShipStatus.Friend); }
            else if (stringStatus == "PendingFriend") { SetViewersFriendshipStatus( Models.FriendShipStatus.PendingFriend); }
            else if (stringStatus == "UnFriended") { SetViewersFriendshipStatus( Models.FriendShipStatus.UnFriended); }
            else SetViewersFriendshipStatus( Models.FriendShipStatus.Friend);
            return GetViewersFriendshipStatus();
        }

        public static Models.FollowerStatus ConvertStringStatus_To_FollowerStatus(string stringStatus)
        {
            if (stringStatus == "Follower") { SetViewerFollowerStatus( Models.FollowerStatus.Follower); }
            else if (stringStatus == "UnFollowed") { SetViewerFollowerStatus(Models.FollowerStatus.UnFollowed); }
            else if (stringStatus == "NonFollower") { SetViewerFollowerStatus(Models.FollowerStatus.NonFollower); }
            else SetViewerFollowerStatus( Models.FollowerStatus.Follower);
            return GetViewerFollowerStatus();
        }

        public static Models.PrivacyLevel ConvertStringPL_To_PrivacyLevel(string stringLvl)
        {
            if (stringLvl == "Private") { SetShowPrivacyLvl( Models.PrivacyLevel.Private); }
            else if (stringLvl == "Exclusive") { SetShowPrivacyLvl( Models.PrivacyLevel.Exclusive); }
            else if (stringLvl == "Public") { SetShowPrivacyLvl( Models.PrivacyLevel.Public); }
            else SetShowPrivacyLvl( Models.PrivacyLevel.Private);
            return GetShowPrivacyLvl();
        }

        public static Models.ShowStanding ConvertStringStanding_To_ShowStanding(string stringStanding)
        {
            if (stringStanding == "Pending") { SetShowStanding(Models.ShowStanding.Pending); }
            else if (stringStanding == "Great") { SetShowStanding(Models.ShowStanding.Great); }
            else if (stringStanding == "Good") { SetShowStanding(Models.ShowStanding.Good); }
            else if (stringStanding == "Moderate") { SetShowStanding(Models.ShowStanding.Moderate); }
            else if (stringStanding == "Bad") { SetShowStanding(Models.ShowStanding.Bad); }
            else if (stringStanding == "Deactivated") { SetShowStanding(Models.ShowStanding.Deactivated); }
            else { SetShowStanding(Models.ShowStanding.Banned); }
            return GetShowStanding();
        }

        public static Models.SubscriberMembershipStatus ConvertStringStatus_To_ShowSubscriptionMembershipStatus(string stringStanding)
        {
            if (stringStanding == "Subscriber") { SetViewersSubscriberStatus(Models.SubscriberMembershipStatus.Subscriber) ; }
            else if (stringStanding == "UnSubscribed") { SetViewersSubscriberStatus(Models.SubscriberMembershipStatus.UnSubscribed) ; }
            else if (stringStanding == "PremiumMember") { SetViewersSubscriberStatus(Models.SubscriberMembershipStatus.PremiumMember) ; }
            else if (stringStanding == "ExclusiveMember") { SetViewersSubscriberStatus(Models.SubscriberMembershipStatus.ExclusiveMember) ; }
            else SetViewersSubscriberStatus(Models.SubscriberMembershipStatus.Subscriber) ;
            return GetViewersSubscriberStatus();
        }

        public static bool CHECK_ifStatus_To_CHEKCSTATUS(CHECK_AccessLayer.CHECKSTATUS standing, string checkString)
        {
            SetCheckstatus(standing);
            // Specify the data source.
            CHECK_AccessLayer.CHECKSTATUS[] checks =  {
                                                        CHECK_AccessLayer.CHECKSTATUS.TRUE,
                                                        CHECK_AccessLayer.CHECKSTATUS.FALSE,
                                                        CHECK_AccessLayer.CHECKSTATUS.SAVED,
                                                        CHECK_AccessLayer.CHECKSTATUS.NOT_SAVED,
                                                        CHECK_AccessLayer.CHECKSTATUS.GOTTEN,
                                                        CHECK_AccessLayer.CHECKSTATUS.NOT_GOTTEN,
                                                        CHECK_AccessLayer.CHECKSTATUS.DELETED,
                                                        CHECK_AccessLayer.CHECKSTATUS.NOT_DELETED,
                                                        CHECK_AccessLayer.CHECKSTATUS.NO_MSTOKEN
                                                        };

            // Define the query expression.
            IEnumerable<CHECK_AccessLayer.CHECKSTATUS> checkQuery =
                from check in checks
                where check == GetCheckstatus()
                select check;

            // Execute the query.
            foreach (CHECK_AccessLayer.CHECKSTATUS i in checkQuery)
            {
                Console.Write($"A CHECK___STATUS at {DateTime.UtcNow} was -- " + i.ToString() + " ");
                if (i.ToString() == checkString)
                {

                    return true;
                }
                
            }
            return false;
        }
    }
}

