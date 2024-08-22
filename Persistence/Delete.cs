using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class Delete
    {
        ConnectionMySQL connection = new ConnectionMySQL();

        public bool DeleteEmployee(string employeeCi)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connection.ConnectionON();
                string query = @"DELETE FROM Employees 
                                 WHERE EmployeeCi = @EmployeeCi";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeCi", employeeCi);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
            finally
            {
                connection.ConnectionOFF();
            }
        }

        public bool DeleteClient(string clientCi)
        {
            MySqlConnection conn = null;
            try
            {
                conn = connection.ConnectionON();
                string query = @"DELETE FROM Clients 
                                 WHERE ClientCi = @ClientCi";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ClientCi", clientCi);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
            finally
            {
                connection.ConnectionOFF();
            }
        }

        public bool DeleteLocal(int localId)
        {
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();

            try
            {
                string query = "DELETE FROM Local WHERE LocalID = @LocalID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@LocalID", localId);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting local: " + ex.Message);
                return false;
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }
        }

        // Eliminar Supplier
        public bool DeleteSupplier(int supplierId)
        {
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();

            try
            {
                string query = "DELETE FROM Supplier WHERE SupplierID = @SupplierID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@SupplierID", supplierId);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting supplier: " + ex.Message);
                return false;
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }
        }

        // Eliminar Product
        public bool DeleteProduct(int productId)
        {
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();

            try
            {
                string query = "DELETE FROM Product WHERE ProductID = @ProductID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting product: " + ex.Message);
                return false;
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }
        }
    }
}
