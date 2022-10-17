using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ShowSessionJoins
    {
        public Guid? ID {get;set;}

        public Guid? FK_ShowSessionsID {get;set;}
        public Guid? FK_ViewerID_ShowViewer {get;set;}
        public DateTime? SessionJoinDate {get;set;}
        public DateTime? SessionLeaveDate {get;set;}
        public ShowSessionJoins(){}
        public ShowSessionJoins(Guid? fk_ShowSessionsID, Guid? fk_ViewerID_ShowViewer)
        {
            this.FK_ShowSessionsID = fk_ShowSessionsID;
            this.FK_ViewerID_ShowViewer = fk_ViewerID_ShowViewer;
        }
        public ShowSessionJoins(Guid? id, Guid? fk_showsessionID, Guid? fk_viewerID_ShowViewer, DateTime? sessionJoinDate, DateTime? sessionLeaveDate)
        {
            this.ID = id;
            this.FK_ShowSessionsID = fk_showsessionID;
            this.FK_ViewerID_ShowViewer = fk_viewerID_ShowViewer;
            this.SessionJoinDate = sessionJoinDate;
            this.SessionLeaveDate = sessionLeaveDate;
        }

        
    }
}