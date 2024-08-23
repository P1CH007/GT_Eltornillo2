using System;

namespace Entities
{
    public class Local
    {
        public int LocalID { get; set; }
        public string LocalName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string NumberSt { get; set; }
        public string[] Services { get; set; }
        public string Description { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }

        public Local()
        {
            LocalID = 0;
            LocalName = string.Empty;
            Country = string.Empty;
            City = string.Empty;
            Street = string.Empty;
            NumberSt = string.Empty;
            Services = new string[0];
            Description = string.Empty;
            OpeningTime = TimeSpan.Zero;
            ClosingTime = TimeSpan.Zero;
        }

        public Local(int localID, string localName, string country, string city, string street, string streetNumber, string[] services, string description, TimeSpan openingTime, TimeSpan closingTime)
        {
            this.LocalID = localID;
            this.LocalName = localName;
            this.Country = country;
            this.City = city;
            this.Street = street;
            this.NumberSt = streetNumber;
            this.Services = services;
            this.Description = description;
            this.OpeningTime = openingTime;
            this.ClosingTime = closingTime;
        }
    }
}
