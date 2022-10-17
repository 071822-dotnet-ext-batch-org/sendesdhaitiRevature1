using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// This is the model to create a new Show Comment - it needs (Guid? id, Guid? userID, Guid? showID, string? comment, DateTime? commentDate)
    /// </summary>
    public class ShowComment
    {
        public Guid? ID {get;set;}
        public Guid? FK_ViewerID_Commenter {get;set;}
        public Guid? FK_ShowID_Commentie {get;set;}
        public Guid? FK_ShowSessionID {get;set;}
        public string? Comment {get;set;}
        public int? Likes {get;set;}
        public DateTime? CommentDate {get;set;}
        public DateTime? CommentUpdateDate {get;set;}

        /// <summary>
        /// This is the model to create a new Show Comment that is empty - it needs (Guid? id, Guid? userID, Guid? showID, string? comment, DateTime? commentDate)
        /// </summary>        
        public ShowComment(){}

    /// <summary>
    /// This is the model to create a new Show Comment - it needs (Guid? id, Guid? userID, Guid? showID, string? comment, DateTime? commentDate)
    /// </summary>
        public ShowComment(Guid? id, Guid? userID, Guid? showID, Guid? showSessionID, string? comment, int? likes, DateTime? commentDate, DateTime? commentUpdateDate)
        {
            this.ID = id;
            this.FK_ViewerID_Commenter = userID;
            this.FK_ShowID_Commentie = showID;
            this.FK_ShowSessionID = showSessionID;
            this.Comment = comment;
            this.Likes = likes;
            this.CommentDate = commentDate;
            this.CommentUpdateDate = commentUpdateDate;
        }

    }
}