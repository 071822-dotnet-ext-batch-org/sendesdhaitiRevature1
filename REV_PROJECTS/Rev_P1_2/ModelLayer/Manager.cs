using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Manager : Employee
    {
        private string role { get; set; } = "Manager";
        public string Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
            }
        }
        //Fields for manager
        //private Guid manager_ID { get; set; } //not null
        //private string? fname { get; set; } //null
        //private string? lname { get; set; } //null
        //[Required(ErrorMessage = "You must have a valid!")]
        //private string username { get; set; } //not null
        //[Required(ErrorMessage = "A password is required!")]
        //private string password { get; set; } //not null
        //private DateTime dateRegistered { get; set; } //not null

        //Manager specific Porperties
        //private List<Ticket> tickets_for_review;
        //private List<Ticket> reviewed_tickets;


        //Getters and Setters for Fields
        //public Guid Manager_ID
        //{
        //    get
        //    {
        //        return manager_ID;
        //    }
        //    set
        //    {
        //        manager_ID = value;
        //    }
        //}

        //public string? MFname
        //{
        //    get
        //    {
        //        return fname;
        //    }
        //    set
        //    {
        //        fname = value;
        //    }
        //}

        //public string? MLname
        //{
        //    get
        //    {
        //        return lname;
        //    }
        //    set
        //    {
        //        lname = value;
        //    }
        //}

        //public string MUsername
        //{
        //    get
        //    {
        //        return username;
        //    }
        //    set
        //    {
        //        username = value;
        //    }
        //}

        //public string MPassword
        //{
        //    get
        //    {
        //        return password;
        //    }
        //    set
        //    {
        //        password = value;
        //    }
        //}

        //public DateTime MDateRegistered
        //{
        //    get
        //    {
        //        return dateRegistered;
        //    }
        //    set
        //    {
        //        dateRegistered = value;
        //    }
        //}

        public Manager() { }
        public Manager(ManagerDTO mang)
        {
            Employee_ID = mang.Manager_ID;
            Fname= mang.fname;
            Lname = mang.lname;
            Username = mang.username;
            Password = mang.password;
            DateRegistered = mang.dateRegistered;
            Role = mang.role;
        }




    }
}

