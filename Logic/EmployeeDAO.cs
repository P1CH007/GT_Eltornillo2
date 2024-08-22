using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using Entities;
using Persistence;

namespace Logic
{
    public class EmployeeDAO
    {
        public Employees VerifyUser(string userAcc, string passwordAcc)
        {
            QueryTypeUser query = new QueryTypeUser();
            Employees employee = query.CheckUser(userAcc, passwordAcc);

            return employee;
        }

        public bool AddEmployee(Employees employee)
        {
            Create add = new Create();
            return add.AddEmployee(
                employee.EmployeeCi,
                employee.EmployeeName,
                employee.EmployeeLastName,
                employee.City,
                employee.Street,
                employee.NumberSt,
                employee.Phone,
                employee.Email,
                employee.BirthDate,
                employee.DateOfAdmission,
                employee.UserAcc,
                employee.PasswordAcc,
                employee.UserType,
                employee.ImgEmployee
            );
        }

        public bool DeleteEmployee(string employeeCi)
        {
            Delete del = new Delete();
            return del.DeleteEmployee(employeeCi);
        }

        public List<Employees> GetEmployees()
        {
            Read read = new Read();
            DataTable dt = read.GetEmployeesData();
            List<Employees> employees = new List<Employees>();

            foreach (DataRow row in dt.Rows)
            {
                Employees employee = new Employees
                {
                    EmployeeCi = row["EmployeeCi"].ToString(),
                    EmployeeName = row["EmployeeName"].ToString(),
                    EmployeeLastName = row["EmployeeLastName"].ToString(),
                    City = row["City"].ToString(),
                    Street = row["Street"].ToString(),
                    NumberSt = row["NumberSt"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Email = row["Email"].ToString(),
                    UserType = row["UserType"].ToString()
                };
                employees.Add(employee);
            }

            return employees;
        }

        public Employees GetEmployeeByCi(string employeeCi)
        {
            Read read = new Read();
            DataRow row = read.GetEmployeeByCiData(employeeCi);

            if (row != null)
            {
                Employees employee = new Employees
                {
                    EmployeeCi = row["EmployeeCi"].ToString(),
                    EmployeeName = row["EmployeeName"].ToString(),
                    EmployeeLastName = row["EmployeeLastName"].ToString(),
                    City = row["City"].ToString(),
                    Street = row["Street"].ToString(),
                    NumberSt = row["NumberSt"].ToString(),
                    Phone = row["Phone"].ToString(),
                    Email = row["Email"].ToString(),
                    BirthDate = row["BirthDate"] != DBNull.Value ? Convert.ToDateTime(row["BirthDate"]) : DateTime.MinValue,
                    DateOfAdmission = row["DateOfAdmission"] != DBNull.Value ? Convert.ToDateTime(row["DateOfAdmission"]) : DateTime.MinValue,
                    UserAcc = row["UserAcc"].ToString(),
                    PasswordAcc = row["PasswordAcc"].ToString(),
                    UserType = row["UserType"].ToString(),
                    ImgEmployee = row["ImgEmployee"] != DBNull.Value ? ByteArrayToImage((byte[])row["ImgEmployee"]) : null
                };
                return employee;
            }

            return null;
        }

        // Convert byte array to Image
        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        public bool UpdateEmployee(Employees employee)
        {
            Update update = new Update();
            return update.UpdateEmployee(
                employee.EmployeeCi,
                employee.EmployeeName,
                employee.EmployeeLastName,
                employee.City,
                employee.Street,
                employee.NumberSt,
                employee.Phone,
                employee.Email,
                employee.BirthDate,
                employee.DateOfAdmission,
                employee.UserAcc,
                employee.PasswordAcc,
                employee.UserType,
                employee.ImgEmployee
            );
        }
    }

    // Similar modifications would be done for SupplierDAO, ProductsDAO, LocalDAO, and ClientsDAO classes
}
