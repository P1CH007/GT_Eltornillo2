using System;

namespace Entities
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierFirstName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string NumberSt { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string TypeProducts{ get; set; }

        public Supplier()
        {
            SupplierID = 0;
            SupplierFirstName = string.Empty;
            Country = string.Empty;
            City = string.Empty;
            Street = string.Empty;
            NumberSt = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            TypeProducts = string.Empty;
        }

        public Supplier(int supplierID, string supplierFirstName, string country, string city, string street, string streetNumber, string phone, string email, string suppliedProducts)
        {
            this.SupplierID = supplierID;
            this.SupplierFirstName = supplierFirstName;
            this.Country = country;
            this.City = city;
            this.Street = street;
            this.NumberSt = streetNumber;
            this.Phone = phone;
            this.Email = email;
            this.TypeProducts = suppliedProducts;
        }
    }
}
