using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Persistence
{
    public class Read
    {
        public DataTable GetEmployeesData()
        {
            DataTable dataTable = new DataTable();
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();

            try
            {
                string query = "SELECT EmployeeCi, EmployeeName, EmployeeLastName, City, Street, NumberSt, Phone, Email, UserType FROM Employees";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                // Handle exceptions or log them
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }

            return dataTable;
        }

        public DataRow GetEmployeeByCiData(string employeeCi)
        {
            DataTable dataTable = new DataTable();
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();

            try
            {
                string query = "SELECT EmployeeCi, EmployeeName, EmployeeLastName, City, Street, NumberSt, Phone, Email, BirthDate, DateOfAdmission, UserAcc, PasswordAcc, UserType, ImgEmployee FROM Employees WHERE EmployeeCi = @EmployeeCi";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@EmployeeCi", employeeCi);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos del empleado: " + ex.Message);
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }

            return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
        }

        public DataTable GetClientsData()
        {
            DataTable dataTable = new DataTable();
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();

            try
            {
                string query = "SELECT ClientCi, ClientName, ClientLastName, City, Street, NumberSt, Phone, Email, DateOfAdmission FROM Clients";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos del empleado: " + ex.Message);
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }

            return dataTable;
        }

        public DataRow GetClientByCiData(string clientCi)
        {
            DataTable dataTable = new DataTable();
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();

            try
            {
                string query = "SELECT ClientCi, ClientName, ClientLastName, City, Street, NumberSt, Phone, Email, DateOfAdmission FROM Clients WHERE ClientCi = @ClientCi";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@ClientCi", clientCi);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos del empleado: " + ex.Message);
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }

            return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
        }

        public DataTable GetLocalsData()
        {
            DataTable dataTable = new DataTable();
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();

            try
            {
                string query = "SELECT LocalID, LocalName, Country, City, Street, NumberSt, Services, Description, OpeningTime, ClosingTime FROM Local";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos del empleado: " + ex.Message);
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }

            return dataTable;
        }

        public DataRow GetLocalByIdData(int localId)
        {
            DataTable dataTable = new DataTable();
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();

            try
            {
                string query = "SELECT LocalID, LocalName, Country, City, Street, NumberSt, Services, Description, OpeningTime, ClosingTime FROM Local WHERE LocalID = @LocalID";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@LocalID", localId);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos del empleado: " + ex.Message);
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }

            return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
        }

        public DataTable GetProductsData()
        {
            DataTable dataTable = new DataTable();
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();

            try
            {
                string query = "SELECT ProductID, ProductName, UnitPrice, Description, Category FROM Product";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos del empleado: " + ex.Message);
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }

            return dataTable;
        }

        public DataRow GetProductByIdData(int productId)
        {
            DataTable dataTable = new DataTable();
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();

            try
            {
                string query = "SELECT ProductID, ProductName, UnitPrice, Description, Category FROM Product WHERE ProductID = @ProductID";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@ProductID", productId);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos del empleado: " + ex.Message);
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }

            return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
        }

        public DataTable GetSuppliersData()
        {
            DataTable dataTable = new DataTable();
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();

            try
            {
                string query = "SELECT SupplierID, SupplierFirstName, Country, City, Street, NumberSt, Phone, Email, TypeProducts FROM Supplier";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos del empleado: " + ex.Message);
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }

            return dataTable;
        }

        public DataRow GetSupplierByIdData(int supplierId)
        {
            DataTable dataTable = new DataTable();
            ConnectionMySQL connectionMySQL = new ConnectionMySQL();
            MySqlConnection connection = connectionMySQL.ConnectionON();

            try
            {
                string query = "SELECT SupplierID, SupplierFirstName, Country, City, Street, NumberSt, Phone, Email, TypeProducts FROM Supplier WHERE SupplierID = @SupplierID";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@SupplierID", supplierId);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos del empleado: " + ex.Message);
            }
            finally
            {
                connectionMySQL.ConnectionOFF();
            }

            return dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
        }
    }
}
