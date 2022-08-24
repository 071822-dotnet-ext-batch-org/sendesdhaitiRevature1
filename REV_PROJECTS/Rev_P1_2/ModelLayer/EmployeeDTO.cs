using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModelLayer
{
    public class EmployeeDTO
    {
        //Fields shown to user
        public Guid employee_ID { get; set; } //not null
        public string? fname { get; set; } //null
        public string? lname { get; set; } //null
        [Required(ErrorMessage = "You must have a valid!")]
        public string username { get; set; } //not null
        [Required(ErrorMessage = "A password is required!")]
        public string password { get; set; } //not null
        public DateTime dateRegistered = DateTime.Now;

        //Employee DTO Constructor
        public EmployeeDTO() { }

        public EmployeeDTO(string username, string password)
        {
            employee_ID = Guid.NewGuid();  //not null
            fname = "First Name";
            lname = "Last Name";
            this.username = username;
            this.password = password;
            dateRegistered = DateTime.Now;
        }

        /// <summary>
        /// Used for newly registering employees
        /// </summary>
        /// <param name="fn"></param>
        /// <param name="ln"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public EmployeeDTO(string username, string password,string fn, string ln )
        {
            employee_ID = Guid.NewGuid();
            fname = fn;
            lname = ln;
            this.username = username;
            this.password = password;
            dateRegistered = DateTime.Now;
        }

        
        /// <summary>
        /// Mostly used for returning employees
        /// Requires an Employee Object
        /// </summary>
        /// <param name="e"></param>
        public EmployeeDTO(Employee e)
        {
            employee_ID = e.Employee_ID;
            fname = e.Fname;
            lname = e.Lname;
            username = e.Username;
            password = e.Password;
            dateRegistered = e.DateRegistered;
        }

    }
}

