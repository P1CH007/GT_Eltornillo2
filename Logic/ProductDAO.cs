using System;
using System.Collections.Generic;
using System.Data;
using Entities;
using Persistence;

namespace Logic
{
    public class ProductsDAO
    {
        public bool AddProduct(Product product)
        {
            Create create = new Create();
            return create.AddProduct(
                product.ProductName,
                product.UnitPrice,
                product.Description,
                product.Category
            );
        }

        public bool DeleteProduct(int productID)
        {
            Delete del = new Delete();
            return del.DeleteProduct(productID);
        }

        public List<Product> GetProducts()
        {
            Read read = new Read();
            DataTable dt = read.GetProductsData();
            List<Product> products = new List<Product>();

            foreach (DataRow row in dt.Rows)
            {
                Product product = new Product
                {
                    ProductID = Convert.ToInt32(row["ProductID"]),
                    ProductName = row["ProductName"].ToString(),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                    Description = row["Description"].ToString(),
                    Category = row["Category"].ToString()
                };
                products.Add(product);
            }

            return products;
        }

        public Product GetProductById(int productID)
        {
            Read read = new Read();
            DataRow row = read.GetProductByIdData(productID);

            if (row != null)
            {
                Product product = new Product
                {
                    ProductID = Convert.ToInt32(row["ProductID"]),
                    ProductName = row["ProductName"].ToString(),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                    Description = row["Description"].ToString(),
                    Category = row["Category"].ToString()
                };
                return product;
            }

            return null;
        }

        public bool UpdateProduct(Product product)
        {
            Update update = new Update();
            return update.UpdateProduct(
                product.ProductID,
                product.ProductName,
                product.UnitPrice,
                product.Description,
                product.Category
            );
        }
    }
}
