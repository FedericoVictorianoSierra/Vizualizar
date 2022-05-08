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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SaveUser()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=base_de_datos;";                             // VALUES (NULL, '" + textBox1.Text +
            string query = "INSERT INTO productos(`id`, `Nombre`, `Apellidos`, `email`, `usuario`,`contraseña`, `telefono`, `direccioncalle`, `poblacion`) VALUES ('" + txtID.Text + "', '" + txtNombre.Text + "', '" + txtApellidos.Text + "', '" + txtemail.Text + "', '" + txtUsuario.Text + "', '" + txtContraseña.Text + "', '" + txtTelefono + "', '" + txtDireccion.Text + "', '" + txtPoblacion.Text + "')";
            // Que puede ser traducido con un valor a:
            //INSERT INTO `productos` (`idProducto`, `nombreProducto`, `descripcionProducto`, `precioProducto`, `existenciasProductos`) VALUES ('3456', 'ghfghfgh', 'fghghf', '12', '12');

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Producto insertado satisfactoriamente");

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Mostrar cualquier error
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateUser()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=user;";
            // Actualizar la fila user con ID 1
            string query = "UPDATE  productos`user` SET (`id`, `Nombre`, `Apellidos`, `email`, `usuario`,`contraseña`, `telefono`, `direccioncalle`, `poblacion`) VALUES ('" + txtID.Text + "', '" + txtNombre.Text + "', '" + txtApellidos.Text + "', '" + txtemail.Text + "', '" + txtUsuario.Text + "', '" + txtContraseña.Text + "', '" + txtTelefono + "', '" + txtDireccion.Text + "', '" + txtPoblacion.Text + "')";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                // Actualizado satisfactoriamente

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, quizás el ID no existe
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteUser()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=user;";
            // Borrar la fila con ID #?

            int ID = Convert.ToInt32(txtID.Text);

            string query = "DELETE FROM `user` WHERE id = " + ID;

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();

                // Eliminado satisfactoriamente

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, quizás el id no existe
                MessageBox.Show(ex.Message);
            }
        }

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
            string query = "SELECT * FROM clientes"; //Parte Mostrar (obtener datos)

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

                        //                   id                    Nombre              Apellidos                Email          Usuario          Contraseña          Teléfono          Dirección          Población
                        //Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3) + " - " + reader.GetString(4) + " - " + reader.GetString(5) + " - " + reader.GetString(6) + " - " + reader.GetString(7) + " - " + reader.GetString(8));
                        // Ejemplo para mostrar en el listView2 :
                        string[] rows = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) , reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8) };
                        var listViewItem = new ListViewItem(rows);
                        listView2.Items.Add(listViewItem);
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblemail_Click(object sender, EventArgs e)
        {

        }

        private void buttonInsertar_Click(object sender, EventArgs e)
        {
            SaveUser();
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            UpdateUser();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }
    }
}
