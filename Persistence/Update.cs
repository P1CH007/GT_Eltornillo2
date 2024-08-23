using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;

namespace Persistence
{
    public class Update
    {
        // Actualizar Employee
        public bool UpdateEmployee(string employeeCi, string employeeName, string employeeLastName, string city,
                                   string street, string numberSt, string phone, string email, DateTime birthDate,
                                   DateTime dateOfAdmission, string userAcc, string passwordAcc, string userType, Image imgEmployee)
        {
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();
            bool isUpdated = false;

            try
            {
                string query = @"UPDATE Employees 
                                 SET EmployeeName = @EmployeeName, EmployeeLastName = @EmployeeLastName, City = @City, 
                                     Street = @Street, NumberSt = @NumberSt, Phone = @Phone, Email = @Email, 
                                     BirthDate = @BirthDate, DateOfAdmission = @DateOfAdmission, 
                                     UserAcc = @UserAcc, PasswordAcc = @PasswordAcc, UserType = @UserType, 
                                     ImgEmployee = @ImgEmployee 
                                 WHERE EmployeeCi = @EmployeeCi";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EmployeeCi", employeeCi);
                cmd.Parameters.AddWithValue("@EmployeeName", employeeName);
                cmd.Parameters.AddWithValue("@EmployeeLastName", employeeLastName);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@Street", street);
                cmd.Parameters.AddWithValue("@NumberSt", numberSt);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@BirthDate", birthDate);
                cmd.Parameters.AddWithValue("@DateOfAdmission", dateOfAdmission);
                cmd.Parameters.AddWithValue("@UserAcc", userAcc);
                cmd.Parameters.AddWithValue("@PasswordAcc", passwordAcc);
                cmd.Parameters.AddWithValue("@UserType", userType);

                if (imgEmployee != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        imgEmployee.Save(ms, imgEmployee.RawFormat);
                        cmd.Parameters.AddWithValue("@ImgEmployee", ms.ToArray());
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ImgEmployee", DBNull.Value);
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                isUpdated = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating employee: " + ex.Message);
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }

            return isUpdated;
        }

        // Actualizar Client
        public bool UpdateClient(string clientCi, string clientName, string clientLastName, string city, string street,
                                 string numberSt, string phone, string email, DateTime DateOfAdmission)
        {
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();
            bool isUpdated = false;

            try
            {
                string query = @"UPDATE Clients 
                                 SET ClientName = @ClientName, ClientLastName = @ClientLastName, City = @City, 
                                     Street = @Street, NumberSt = @NumberSt, Phone = @Phone, Email = @Email, DateOfAdmission = @DateOfAdmission 
                                 WHERE ClientCi = @ClientCi";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ClientCi", clientCi);
                cmd.Parameters.AddWithValue("@ClientName", clientName);
                cmd.Parameters.AddWithValue("@ClientLastName", clientLastName);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@Street", street);
                cmd.Parameters.AddWithValue("@NumberSt", numberSt);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@DateOfAdmission", DateOfAdmission);

                int rowsAffected = cmd.ExecuteNonQuery();
                isUpdated = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating client: " + ex.Message);
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }

            return isUpdated;
        }

        // Actualizar Local
        public bool UpdateLocal(int localID, string localName, string country, string city, string street, string numberSt,
                                string services, string description, TimeSpan openingTime, TimeSpan closingTime)
        {
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();
            bool isUpdated = false;

            try
            {
                string query = @"UPDATE Local 
                                 SET LocalName = @LocalName, Country = @Country, City = @City, Street = @Street,
                                     NumberSt = @NumberSt, Services = @Services, Description = @Description,
                                     OpeningTime = @OpeningTime, ClosingTime = @ClosingTime 
                                 WHERE LocalID = @LocalID";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@LocalID", localID);
                cmd.Parameters.AddWithValue("@LocalName", localName);
                cmd.Parameters.AddWithValue("@Country", country);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@Street", street);
                cmd.Parameters.AddWithValue("@NumberSt", numberSt);
                cmd.Parameters.AddWithValue("@Services", services);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@OpeningTime", openingTime);
                cmd.Parameters.AddWithValue("@ClosingTime", closingTime);

                int rowsAffected = cmd.ExecuteNonQuery();
                isUpdated = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating local: " + ex.Message);
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }

            return isUpdated;
        }

        // Actualizar Supplier
        public bool UpdateSupplier(int supplierID, string supplierFirstName, string country, string city, string street,
                                   string numberSt, string phone, string email, string typeProducts)
        {
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();
            bool isUpdated = false;

            try
            {
                string query = @"UPDATE Supplier 
                                 SET SupplierFirstName = @SupplierFirstName, Country = @Country, City = @City, 
                                     Street = @Street, NumberSt = @NumberSt, Phone = @Phone, Email = @Email, 
                                     TypeProducts = @TypeProducts 
                                 WHERE SupplierID = @SupplierID";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@SupplierID", supplierID);
                cmd.Parameters.AddWithValue("@SupplierFirstName", supplierFirstName);
                cmd.Parameters.AddWithValue("@Country", country);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@Street", street);
                cmd.Parameters.AddWithValue("@NumberSt", numberSt);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@TypeProducts", typeProducts);

                int rowsAffected = cmd.ExecuteNonQuery();
                isUpdated = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating supplier: " + ex.Message);
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }

            return isUpdated;
        }

        // Actualizar Product
        public bool UpdateProduct(int productID, string productName, decimal unitPrice, string description, string category)
        {
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();
            bool isUpdated = false;

            try
            {
                string query = @"UPDATE Product 
                                 SET ProductName = @ProductName, UnitPrice = @UnitPrice, Description = @Description, 
                                     Category = @Category 
                                 WHERE ProductID = @ProductID";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductID", productID);
                cmd.Parameters.AddWithValue("@ProductName", productName);
                cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Category", category);

                int rowsAffected = cmd.ExecuteNonQuery();
                isUpdated = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating product: " + ex.Message);
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }

            return isUpdated;
        }
    }
}
