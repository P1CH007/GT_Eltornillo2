using System;
using System.Collections.Generic;


namespace Entities
{
    public class Clients
    {
        public string ClientCi { get; set; }
        public string ClientName { get; set; }
        public string ClientLastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string NumberSt { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfAdmission { get; set; }



        public Clients()
        {
            ClientCi = string.Empty;
            ClientName = string.Empty;
            ClientLastName = string.Empty;
            City = string.Empty;
            Street = string.Empty;
            NumberSt = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            DateOfAdmission = DateTime.MinValue;
           

        }

        public Clients(string clientCI, string clientName, string clientLasName, string city, string street, string number, string phone, string email, DateTime dateOfAdmission)
        {
            this.ClientCi = clientCI;
            this.ClientName = clientName;
            this.ClientLastName = clientLasName;
            this.City = city;
            this.Street = street;
            this.NumberSt = number;
            this.Phone = phone;
            this.Email = email;
            this.DateOfAdmission = dateOfAdmission;
            

        }


    }
}
