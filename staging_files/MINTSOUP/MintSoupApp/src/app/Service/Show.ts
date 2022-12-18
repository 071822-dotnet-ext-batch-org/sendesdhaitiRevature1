
export interface IShow {
    id: string,
    fK_ViewerID_Owner: string,
    showName: string,
    showImage: string,
    subscribersCount: 0,
    views: 0,
    likes: 0,
    comments: 0,
    rating: 0,
    rank: 0,
    privacyLevel: 0,
    showStatus: 0,
    dateCreated: Date,
    lastLive: Date,
    subscribers:ShowSubscriber[],
    showLikes: ShowLike[],
    showComments:ShowComment[],
    donations: Donation[]

}


export interface ShowSesssion
{
    id: string,
    fK_ShowID: string,
    views: 0,
    likes: 0,
    comments: 0,
    sessionStartDate: Date,
    sessionEndDate: Date
  }

export interface ShowSessionJoin
    {
        id: string,
        fK_ShowSessionsID: string,
        fK_ViewerID_ShowViewer: string,
        sessionJoinDate: Date,
        sessionLeaveDate: Date
    }

export interface ShowSubscriber
    {
      id:string,
      fK_ViewerID_Follower: string,
      fK_ViewerID_Followie: string,
      fK_ShowID_Followie: string,
      followerStatus: 0,
      followDate: Date,
      statusUpdateDate: Date
    }
export interface ShowLike
    {
      id: string,
      fK_ViewerID_Liker:string,
      fK_ShowID_Likie: string,
      fK_ShowSessionID: string,
      likeDate: Date
    }

export interface ShowComment
    {
    id: string,
    fK_ViewerID_Commenter: string,
    fK_ShowID_Commentie: string,
    fK_ShowSessionID: string,
    comment: string,
    likes: 0,
    commentDate: Date,
    commentUpdateDate: Date
    }
export interface Donation
    {
    id:string,
    fK_ViewerID_Donater: string,
    fK_ShowID_Donatie: string,
    amount: 0,
    note: string,
    donationDate: Date
    }