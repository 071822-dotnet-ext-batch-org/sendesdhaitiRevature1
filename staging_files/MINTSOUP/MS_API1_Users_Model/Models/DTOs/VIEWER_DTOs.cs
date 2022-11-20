using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public virtual  void SetMSToken(Guid? value)
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

                public ShowSessionDTO(Guid? mstoken , Guid?sessionid, Guid?showId): base(mstoken, showId)
                {
                    if(mstoken != null && sessionid != null && showId != null) { SetSessionID(sessionid);
                        SetMSToken(mstoken);SetShowID(showId);
                    }
                }


                public class SessionJoinDTO: ShowSessionDTO
                {
                    private static Guid?sessionJoinID;

                    public  Guid?GetsessionJoinID()
                    {
                        return showID;
                    }

                    private static void SetsessionJoinID(Guid?value)
                    {
                        showID = value;
                    }

                    public SessionJoinDTO(Guid? sessionjoinID , Guid?sessionID, Guid? showid, Guid? mstoken): base( sessionID, showid, mstoken)
                    {
                        SetMSToken(mstoken);
                        SetShowID(showid);
                        SetSessionID(sessionID);
                        SetsessionJoinID(sessionID);
                    }
                }
            }
        }
    }


}