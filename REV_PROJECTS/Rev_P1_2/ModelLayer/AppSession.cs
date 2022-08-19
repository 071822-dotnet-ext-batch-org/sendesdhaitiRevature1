using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class AppSession
    {
        private Guid SessionID { get; set; } = Guid.NewGuid();

        private Guid? FK_Employee_ID {get;set;} = Guid.NewGuid();
        private Guid? FK_ManagerReviewer_ID { get; set; } = Guid.NewGuid();


        private Employee? sessionEm { get; set; }
        //private Manager? sessionMang { get; set; }


        //private Ticket? ticket {get;set;} = new Ticket();
        //private Manager? SessionManager {get;set;} = new Manager();

        public AppSession(){}

        public Employee Employee {
            get{
                return this.sessionEm;
            }
            set{
                this.sessionEm = value;
            }
        }

        //public Manager Manager
        //{
        //    get
        //    {
        //        return this.sessionMang;
        //    }
        //    set
        //    {
        //        this.sessionMang = value;
        //    }
        //}

        // public Ticket? Ticket {
        //     get{
        //         return this.ticket;
        //     }
        //     set{
        //         this.ticket = value;
        //     }
        // }

    }
}