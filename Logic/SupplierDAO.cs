using System;
using System.Collections.Generic;
using System.Data;
using Entities;
using Persistence;

namespace Logic
{
    public class SupplierDAO
    {
        public bool AddSupplier(Supplier supplier)
        {
            Create create = new Create();
            return create.AddSupplier(
                supplier.SupplierFirstName,
                supplier.Country,
                supplier.City,
                supplier.Street,
                supplier.NumberSt,
                supplier.Phone,
                supplier.Email,
                supplier.TypeProducts
            );
        }

        public bool DeleteSupplier(int supplierID)
        {
            Delete del = new Delete();
            return del.DeleteSupplier(supplierID);
        }

        public List<Supplier> GetSuppliers()
        {
            Read read = new Read();
            DataTable dt = read.GetSuppliersData();
            List<Supplier> suppliers = new List<Supplier>();

            foreach (DataRow row in dt.Rows)
            {
                Supplier supplier = new Supplier
                {
                    SupplierID = Convert.ToInt32(row["SupplierID"]),
                    SupplierFirstName = row["SupplierFirstName"].ToString(),
                    Country = row["Country"].ToString(),
                    City = row["City"].ToString(),
                    Street = row["Street"].ToString(),
                    NumberSt = row["NumberSt"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Email = row["Email"].ToString(),
                    TypeProducts = row["TypeProducts"].ToString()
                };
                suppliers.Add(supplier);
            }

            return suppliers;
        }

        public Supplier GetSupplierById(int supplierID)
        {
            Read read = new Read();
            DataRow row = read.GetSupplierByIdData(supplierID);

            if (row != null)
            {
                Supplier supplier = new Supplier
                {
                    SupplierID = Convert.ToInt32(row["SupplierID"]),
                    SupplierFirstName = row["SupplierFirstName"].ToString(),
                    Country = row["Country"].ToString(),
                    City = row["City"].ToString(),
                    Street = row["Street"].ToString(),
                    NumberSt = row["NumberSt"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Email = row["Email"].ToString(),
                    TypeProducts = row["TypeProducts"].ToString()
                };
                return supplier;
            }

            return null;
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            Update update = new Update();
            return update.UpdateSupplier(
                supplier.SupplierID,
                supplier.SupplierFirstName,
                supplier.Country,
                supplier.City,
                supplier.Street,
                supplier.NumberSt,
                supplier.Phone,
                supplier.Email,
                supplier.TypeProducts
            );
        }
    }
}
