using System;
using MySql.Data.MySqlClient;
using Entities;
using System.Windows.Forms;

namespace Persistence
{
    public class QueryTypeUser
    {
        ConnectionMySQL connection = new ConnectionMySQL();

        public Employees CheckUser(string userAcc, string passwordAcc)
        {
            Employees employee = null;

            MySqlConnection conn = null;
            try
            {

                conn = connection.ConnectionON();
                string query = "SELECT EmployeeName, UserType FROM Employees WHERE userAcc = @UserAcc AND passwordAcc = @PasswordAcc";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@UserAcc", userAcc);
                    cmd.Parameters.AddWithValue("@PasswordAcc", passwordAcc);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            employee = new Employees
                            {
                                EmployeeName = reader["EmployeeName"].ToString(),
                                UserType = reader["UserType"].ToString()
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en QueryTypeUser: " + ex.Message);
            }
            finally
            {

                connection.ConnectionOFF();

            }

            return employee;
        }
    }
}
