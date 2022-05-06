using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsForm
{
    public partial class Form1 : Form
    {
        void connect()
        {
            string server = "localhost";
            string database = "base_de_datos";
            string user = "root";
            string password = "";
            string port = "3306";
            string sslM = "none";

            //string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=base_de_datos;";
            string connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);

            // Seleccionar todo
            string query = "SELECT * FROM productos"; //Parte Mostrar (obtener datos)

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection); //Parte Mostrar (obtener datos)
            commandDatabase.CommandTimeout = 60; //Parte Mostrar (obtener datos)
            MySqlDataReader reader; //Parte Mostrar (obtener datos)

            try
            {
                databaseConnection.Open();

                Console.WriteLine("Conexion exitosa");

                //------------------------------------------Parte Mostrar (obtener datos)
                reader = commandDatabase.ExecuteReader();


                // Si se encontraron datos
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        //                   idProducto                    nombreProducto              descripcionProducto                precioProducto          existenciasProductos
                        Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3) + " - " + reader.GetString(4));
                        // Ejemplo para mostrar en el listView1 :
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4) };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
                    }
                }
                else
                {
                    Console.WriteLine("No se encontro nada");
                }
                //------------------------------------------Parte Mostrar (obtener datos)

                databaseConnection.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message + connectionString);
            }

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect();
        }
    }
}
