using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ShowCommentLike
    {
        public Guid? ID {get;set;}
        public Guid? FK_ViewerID_Liker {get;set;}
        public Guid? FK_ShowCommentID_Likie {get;set;}
        public DateTime? LikeDate {get;set;}

        //Constructors
        public ShowCommentLike(){}
        public ShowCommentLike(Guid? id, Guid? fk_viewerID_Liker, Guid? fk_showCommentID_Likie, DateTime? likeDate)
        {
            this.ID = id;
            this.FK_ViewerID_Liker = fk_viewerID_Liker;
            this.FK_ShowCommentID_Likie = fk_showCommentID_Likie;
            this.LikeDate = likeDate;
        }
    }
}