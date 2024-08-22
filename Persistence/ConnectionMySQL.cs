using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Persistence
{
    public class ConnectionMySQL
    {
        MySqlConnection con = new MySqlConnection();

        static string server = "Localhost";
        static string bd = "tornillo";
        static string user = "root";
        static string password = "Mauri1234";
        static string port = "3306";

        string connectionChain = "server=" + server + ";" + "port=" + port + ";" + "user id=" + user + ";" + "password=" + password + ";" + "database=" + bd + ";";

        public MySqlConnection ConnectionON()
        {
            try
            {
                con.ConnectionString = connectionChain;

                con.Open();

                //MessageBox.Show("Conexión exitosa");
            }

            catch(MySqlException e)
            {
                MessageBox.Show("No se pudo conectar a la base de datos, error: " + e,ToString());
            }

            return con;
        }

        public void ConnectionOFF()
        {
            try
            {
                con.Close();
                // MessageBox.Show("Se cerro correctamente gatooo");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la BD: " + ex.Message);
            }
        }

        public MySqlConnection GetConnection()
        {
            return con;
        }


    }
}
