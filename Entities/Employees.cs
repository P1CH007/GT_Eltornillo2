using System;
using System.Drawing;

namespace Entities
{
    //
    public class Employees
    {
        public string EmployeeCi { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string NumberSt { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public string UserAcc { get; set; }
        public string PasswordAcc { get; set; }
        public string UserType { get; set; }
        public Image ImgEmployee { get; set; }

        public Employees()
        {
            EmployeeCi = string.Empty;
            EmployeeName = string.Empty;
            EmployeeLastName = string.Empty;
            City = string.Empty;
            Street = string.Empty;
            NumberSt = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            BirthDate = DateTime.MinValue;
            DateOfAdmission = DateTime.MinValue;
            UserAcc = string.Empty;
            PasswordAcc = string.Empty;
            UserType = string.Empty;
            ImgEmployee = null;
        }

        public Employees(string employeeCi, string employeeName, string employeeLastName, string city, string street, string numberSt, string phone, string email, DateTime birthDate, DateTime dateOfAdmission, string userAcc, string passwordAcc, string userType, Image imgEmployee)
        {
            this.EmployeeCi = employeeCi;
            this.EmployeeName = employeeName;
            this.EmployeeLastName = employeeLastName;
            this.City = city;
            this.Street = street;
            this.NumberSt = numberSt;
            this.Phone = phone;
            this.Email = email;
            this.BirthDate = birthDate;
            this.DateOfAdmission = dateOfAdmission;
            this.UserAcc = userAcc;
            this.PasswordAcc = passwordAcc;
            this.UserType = userType;
            this.ImgEmployee = imgEmployee;
        }


    }
}
