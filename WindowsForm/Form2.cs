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
        public MySqlCommand commandDatabase;
        public MySqlConnection databaseConnection;
        public MySqlDataReader reader;

        public string server = "localhost";
        public string database = "basededatos";
        public string user = "root";
        public string password = "";
        public string port = "3306";
        public string sslM = "none";

        void connect()
        {
            //string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=basededatos;";
            string connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);

            databaseConnection = new MySqlConnection(connectionString);

            try
            {
                
                if (databaseConnection.State != ConnectionState.Open)
                {
                    databaseConnection.Open();
                    Console.WriteLine("Conexion exitosa");
                }
                else
                {
                    databaseConnection.Close();
                }
            
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message + connectionString);
            }
        }

        private void SaveUser()
        {
                                        
            string query = "INSERT INTO clientes(`id`, `Nombre`, `Apellidos`, `E-mail`, `Usuario`,`Contraseña`, `Teléfono`, `Dirección_Calle`, `Población`) VALUES ('" + txtID.Text + "', '" + txtNombre.Text + "', '" + txtApellidos.Text + "', '" + txtemail.Text + "', '" + txtUsuario.Text + "', '" + txtContraseña.Text + "', '" + txtTelefono.Text + "', '" + txtDireccion.Text + "', '" + txtPoblacion.Text + "')";
            // Que puede ser traducido con un valor a:
            //INSERT INTO `clientes` (`id`, `Nombre`, `Apellidos`, `E-mail`, `Usuario`,`Contraseña`, `Teléfono`, `Dirección_Calle`, `Población`) VALUES ('" + txtID.Text + "', '" + txtNombre.Text + "', '" + txtApellidos.Text + "', '" + txtemail.Text + "', '" + txtUsuario.Text + "', '" + txtContraseña.Text + "', '" + txtTelefono + "', '" + txtDireccion.Text + "', '" + txtPoblacion.Text + "')
            commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                
                reader = commandDatabase.ExecuteReader();

                MessageBox.Show("Usuario insertado satisfactoriamente");

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
            // Actualizar la fila user con ID 1
            string query = "UPDATE `clientes` SET `id` = '" + txtID.Text + "', `Nombre` ='" + txtNombre.Text + "', `Apellidos` ='" + txtApellidos.Text + "', `E-mail` ='" + txtemail.Text + "', `Usuario` ='" + txtUsuario.Text + "', `Contraseña` ='" + txtContraseña.Text + "', `Teléfono` ='" + txtTelefono.Text + "', `Dirección_Calle` ='" + txtDireccion.Text + "', `Población` ='" + txtPoblacion.Text + "' WHERE `clientes`.`id` =" + txtID.Text;
            
            commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                reader = commandDatabase.ExecuteReader();

                // Actualizado satisfactoriamente
                MessageBox.Show("Información del Usuario actualizada satisfactoriamente");

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
            // Borrar la fila con ID #?

            int ID = Convert.ToInt32(txtID.Text);

            string query = "DELETE FROM clientes WHERE `clientes`.`id` = " + ID;

            commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                reader = commandDatabase.ExecuteReader();

                // Eliminado satisfactoriamente
                MessageBox.Show("Usuario "+ID+" eliminado satisfactoriamente");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Ops, quizás el id no existe
                MessageBox.Show(ex.Message);
            }
        }

        public void VisualizarDatos()
        {
            // Seleccionar todo
            string query = "SELECT * FROM clientes";

            commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            

            try
            {
                reader = commandDatabase.ExecuteReader();


                // Si se encontraron datos
                if (reader.HasRows)
                {
                    listView2.Items.Clear();
                    while (reader.Read())
                    {
                        //
                        //reader.Read();
                        //                   ID                   Nombre                   Apellidos                   E-mail                   Usuario                   Contraseña                   Teléfono                   Dirección                   Población
                        //Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3));
                        // Ejemplo para mostrar en el listView1 :
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8) };
                        var lista = new ListViewItem(row);
                        listView2.Items.Add(lista);
                    }
                }
                else
                {
                    Console.WriteLine("No se encontro nada");
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect();
            VisualizarDatos();
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
            connect();
            SaveUser();

            connect();
            VisualizarDatos();
            
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            connect();
            UpdateUser();

            connect();
            VisualizarDatos();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            connect();
            DeleteUser();

            connect();
            VisualizarDatos();
        }
    }
}
