using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace DTOs
{
    public class MSTokenACTIONDTO
    {
        private static Guid? MSToken;
        private static string nullTokenError = "You must be a registerd user with a valid Mint Soup Token to use this service";


        public string? GetNullTokenError()
        {
            Guid? check = GetMSToken();
            if(check != null)
            {
                return null;
            }
            return nullTokenError;
        }

        public Guid? GetMSToken()
        {
            return MSToken;
        }

        private static  void SetMSToken(Guid? value)
        {
            MSToken = value;
        }


        public MSTokenACTIONDTO() { }

        public MSTokenACTIONDTO(Guid? token) {
            SetMSToken(token);
        }

        /// <summary>
        /// This class of a Show is what a user with the MSToken will use to perform a show action
        /// </summary>
        public class ShowDTO : MSTokenACTIONDTO
        {
            private static Guid? showID;
            public  Guid? GetShowID()
            {
                return showID;
            }

            private static void SetShowID(Guid? value)
            {
                showID = value;
            }

            public ShowDTO() : base() { }

            public ShowDTO(Guid? mstoken, Guid? showid):base(mstoken)
            {
                SetShowID(showid);
                SetMSToken(mstoken);
            }

            public class ShowSessionDTO : ShowDTO
            {
                private static Guid? sessionID;

                public  Guid? GetSessionID()
                {
                    return sessionID;
                }

                private static void SetSessionID(Guid? value)
                {
                    sessionID = value;
                }

                public ShowSessionDTO() { }

                public ShowSessionDTO(Guid? mstoken , Guid?showId, Guid?sessionid): base(mstoken, showId)
                {
                    if(mstoken != null && sessionid != null && showId != null) { SetSessionID(sessionid);
                        SetMSToken(mstoken);SetShowID(showId);
                    }
                }

                /// <summary>
                /// 
                /// </summary>
                public class SessionJoinDTO: MSTokenACTIONDTO
                {
                    private static Guid?sessionJoinID;

                    public  Guid?GetsessionJoinID()
                    {
                        return sessionJoinID;
                    }

                    private static void SetsessionJoinID(Guid?value)
                    {
                        sessionJoinID = value;
                    }
                    /// <summary>
                    /// 
                    /// </summary>
                    /// <param name="sessionjoinID"></param>
                    /// <param name="sessionID"></param>
                    /// <param name="showid"></param>
                    /// <param name="mstoken"></param>
                    public SessionJoinDTO(Guid? mstoken, Guid? sessionjoinID ): base(mstoken)
                    {
                        SetMSToken(mstoken);
                        //SetShowID(showid);
                        //SetSessionID(sessionID);
                        SetsessionJoinID(sessionID);
                    }
                }
            }
        }

    }//END of MSTokenACTIONDTO

    public class DonationDTO : MSTokenACTIONDTO
    {
        private static Guid donationID;

        public Guid GetDonationID()
        {
            return donationID;
        }

        private static void SetDonationID(Guid value)
        {
            donationID = value;
        }
        public DonationDTO(Guid mt, Guid did) : base( mt)
        {
            SetDonationID(did);
        }
    }//END


    public class GETDTO : MSTokenACTIONDTO
    {
        private static Guid id;

        public Guid GetOBJID()
        {
            return id;
        }

        private static void SetOBJID(Guid value)
        {
            id = value;
        }
        public GETDTO(Guid mt, Guid objectid) : base(mt)
        {
            SetOBJID(objectid);
        }
    }//END

    //public class LikeDTO : MSTokenACTIONDTO
    //{
    //    private static Guid likeid;

    //    public static Guid GetLikeID()
    //    {
    //        return likeid;
    //    }

    //    private static void SetLikeID(Guid value)
    //    {
    //        likeid = value;
    //    }
    //    public LikeDTO(Guid mt, Guid lid) : base(mt)
    //    {
    //        SetLikeID(lid);
    //    }
    //}//END


    public class Create_ShowDTO
    {
        public Guid MSToken { get; set; }
        public string showName { get; set; } = "";
        public string showImage { get; set; } = "";
        public Models.PrivacyLevel privacyLevel { get; set; }
        public Create_ShowDTO(Guid mt, string sn, string si, PrivacyLevel pl)
        {
            this.MSToken = mt;
            this.showName = sn;
            this.showImage = si;
            this.privacyLevel = pl;
        }
    }//END OF CREATE SHOW DTO

    public class Create_Show_SessionDTO
    {
        public Guid MSToken { get; set; }
        public Guid showID { get; set; }
        public Create_Show_SessionDTO(Guid mt, Guid sid)
        {
            this.MSToken = mt;
            this.showID = sid;
        }
    }//END OF START SHOW SESSION DTO

    public class Create_Show_Session_JoinDTO
    {
        public Guid MSToken { get; set; }
        public Guid showsessionid { get; set; }
        public Create_Show_Session_JoinDTO(Guid mt, Guid ssid)
        {
            this.MSToken = mt;
            this.showsessionid = ssid;
        }
    }//END OF JOIN to SHOW SESSION DTO




}