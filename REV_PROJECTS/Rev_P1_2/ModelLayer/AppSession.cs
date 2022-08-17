using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class AppSession
    {
        private Guid sessionID {get;set;}= Guid.NewGuid();
        private Employee employee {get;set;} = new Employee();

        private Ticket? ticket {get;set;} = new Ticket();

        public AppSession(){}

        public Employee Employee {
            get{
                return this.employee;
            }
            set{
                this.employee = value;
            }
        }

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