using System;

namespace Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public Product()
        {
            ProductID = 0;
            ProductName = string.Empty;
            UnitPrice = 0.0m;
            Description = string.Empty;
            Category = string.Empty;
        }

        public Product(int productID, string productName, decimal unitPrice, string description, string category)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.UnitPrice = unitPrice;
            this.Description = description;
            this.Category = category;
        }
    }
}
