using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;

namespace Persistence
{
    public class Create
    {
        private readonly ConnectionMySQL connection = new ConnectionMySQL();

        public bool AddEmployee(string employeeCi, string employeeName, string employeeLastName, string city,
                                string street, string numberSt, string phone, string email, DateTime birthDate,
                                DateTime dateOfAdmission, string userAcc, string passwordAcc, string userType, Image imgEmployee)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connection.ConnectionON();
                string query = @"INSERT INTO Employees (EmployeeCi, EmployeeName, EmployeeLastName, City, Street, NumberSt, Phone, Email, BirthDate, DateOfAdmission, userAcc, passwordAcc, UserType, ImgEmployee)
                                 VALUES (@EmployeeCi, @EmployeeName, @EmployeeLastName, @City, @Street, @NumberSt, @Phone, @Email, @BirthDate, @DateOfAdmission, @userAcc, @passwordAcc, @UserType, @ImgEmployee)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
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
                    cmd.Parameters.AddWithValue("@userAcc", userAcc);
                    cmd.Parameters.AddWithValue("@passwordAcc", passwordAcc);
                    cmd.Parameters.AddWithValue("@UserType", userType);

                    if (imgEmployee != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            imgEmployee.Save(ms, imgEmployee.RawFormat);
                            byte[] imgBytes = ms.ToArray();
                            cmd.Parameters.AddWithValue("@ImgEmployee", imgBytes);
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ImgEmployee", DBNull.Value);
                    }

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar empleado: {ex.Message}");
                return false;
            }
            finally
            {
                connection.ConnectionOFF();
            }
        }

        public bool AddClient(string clientCi, string clientName, string clientLastName, string city, string street,
                              string numberSt, string phone, string email, DateTime DateOfAdmission)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connection.ConnectionON();
                string query = @"INSERT INTO Clients (ClientCi, ClientName, ClientLastName, City, Street, NumberSt, Phone, Email, DateOfAdmission)
                                 VALUES (@ClientCi, @ClientName, @ClientLastName, @City, @Street, @NumberSt, @Phone, @Email, @DateOfAdmission)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ClientCi", clientCi);
                    cmd.Parameters.AddWithValue("@ClientName", clientName);
                    cmd.Parameters.AddWithValue("@ClientLastName", clientLastName);
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@Street", street);
                    cmd.Parameters.AddWithValue("@NumberSt", numberSt);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@DateOfAdmission", DateOfAdmission);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar cliente: {ex.Message}");
                return false;
            }
            finally
            {
                connection.ConnectionOFF();
            }
        }

        public bool AddLocal(string localName, string country, string city, string street, string numberSt,
                             string services, string description, TimeSpan openingTime, TimeSpan closingTime)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connection.ConnectionON();
                string query = @"INSERT INTO Local (LocalName, Country, City, Street, NumberSt, Services, Description, OpeningTime, ClosingTime)
                                 VALUES (@LocalID, @LocalName, @Country, @City, @Street, @NumberSt, @Services, @Description, @OpeningTime, @ClosingTime)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LocalName", localName);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@Street", street);
                    cmd.Parameters.AddWithValue("@NumberSt", numberSt);
                    cmd.Parameters.AddWithValue("@Services", services);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@OpeningTime", openingTime);
                    cmd.Parameters.AddWithValue("@ClosingTime", closingTime);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar local: {ex.Message}");
                return false;
            }
            finally
            {
                connection.ConnectionOFF();
            }
        }

        public bool AddSupplier(string supplierFirstName, string country, string city,
                                string street, string numberSt, string phone, string email, string typeProducts)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connection.ConnectionON();
                string query = @"INSERT INTO Supplier (SupplierFirstName, Country, City, Street, NumberSt, Phone, Email, TypeProducts)
                                 VALUES (@SupplierFirstName, @Country, @City, @Street, @NumberSt, @Phone, @Email, @TypeProducts)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SupplierFirstName", supplierFirstName);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@Street", street);
                    cmd.Parameters.AddWithValue("@NumberSt", numberSt);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@TypeProducts", typeProducts);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar proveedor: {ex.Message}");
                return false;
            }
            finally
            {
                connection.ConnectionOFF();
            }
        }

        public bool AddProduct(string productName, decimal unitPrice, string description, string category)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connection.ConnectionON();
                string query = @"INSERT INTO Product (ProductName, UnitPrice, Description, Category)
                                 VALUES (@ProductID, @ProductName, @UnitPrice, @Description, @Category)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Category", category);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar producto: {ex.Message}");
                return false;
            }
            finally
            {
                connection.ConnectionOFF();
            }
        }
    }
}
