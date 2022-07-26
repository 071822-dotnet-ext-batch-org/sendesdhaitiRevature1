using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Employee
    {
        //Employee Data Fields
        private Guid employee_ID { get; set; } //not null
        private string? fname { get; set; } //null
        private string? lname { get; set; } //null
        private string username { get; set; }
        private string password { get; set; } //not null
        private DateTime dateRegistered { get; set; } //not null


        //Getters and Setters for Fields
        public Guid Employee_ID
        {
            get
            {
                return employee_ID;
            }
            set
            {
                employee_ID = value;
            }
        }

        public string? Fname
        {
            get
            {
                return fname;
            }
            set
            {
                fname = value;
            }
        }

        public string? Lname
        {
            get
            {
                return lname;
            }
            set
            {
                lname = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public DateTime DateRegistered
        {
            get
            {
                return dateRegistered;
            }
            set
            {
                dateRegistered = value;
            }
        }



        //Constructors for Employee
        public Employee() {
            Employee_ID = Guid.NewGuid();
        }
        public Employee(EmployeeDTO e)
        {
            Employee_ID = Guid.NewGuid();
            Fname = e.fname;
            Lname = e.lname;
            Username = e.username;
            Password = e.password;
            DateRegistered = e.dateRegistered;
        }



    }
}