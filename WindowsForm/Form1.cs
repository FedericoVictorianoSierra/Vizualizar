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
        public MySqlCommand commandDatabase;
        public MySqlConnection databaseConnection;
        public MySqlDataReader reader;

        public string server = "localhost"; //Nombre del Servidor
        public string database = "basededatos"; //Nombre de la base de datos SQL
        public string user = "root"; //Nombre de usuario 
        public string password = ""; //Contraseña de Usuario
        public string port = "3306"; // Puerto de MySQL
        public string sslM = "none";

        void connect()
        {
            //string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=basededatos;";
            string connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);

            databaseConnection = new MySqlConnection(connectionString);

            try{
                if (databaseConnection.State != ConnectionState.Open)
                {
                    databaseConnection.Open();
                    
                }
                else
                {
                    databaseConnection.Close();
                }
                Console.WriteLine("Conexion exitosa");
            }catch (MySqlException e){
                Console.WriteLine(e.Message + connectionString);
            }
        }

        void CloseDataBase()
        {
            databaseConnection.Close();
        }

        void readProducto()
        {
            // Seleccionar todo de la tabla productos
            string query = "SELECT * FROM productos";
            commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try
            {
                reader = commandDatabase.ExecuteReader();
                // Si se encontraron datos
                if (reader.HasRows) {
                    listView1.Items.Clear();
                    while (reader.Read()) {
                        //                   idProducto                    nombreProducto              descripcionProducto                precioProducto          existenciasProductos
                        //Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3) + " - " + reader.GetString(4));
                        // Ejemplo para mostrar en el listView1 :
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4) };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
                    }
                } else {
                    Console.WriteLine("No se encontro nada");
                }
            }catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect();
            readProducto();
            CloseDataBase();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect();
            SaveProducto();
            CloseDataBase();

            connect();
            readProducto();
            CloseDataBase();
        }

        private void SaveProducto()
        {                       // VALUES (NULL, '" + textBox1.Text +
            string query = "INSERT INTO productos(`idProducto`, `nombreProducto`, `descripcionProducto`, `precioProducto`, `existenciasProductos`) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')";
            // Que puede ser traducido con un valor a:
            //INSERT INTO `productos` (`idProducto`, `nombreProducto`, `descripcionProducto`, `precioProducto`, `existenciasProductos`) VALUES ('3456', 'ghfghfgh', 'fghghf', '12', '12');

            commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try{
                reader = commandDatabase.ExecuteReader();
                MessageBox.Show("Producto insertado satisfactoriamente");
            }catch (Exception ex){
                // Mostrar cualquier error
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteProducto()
        {
            // Borrar la fila con ID 1
            string cod = textID.Text;
            string query = "DELETE FROM `productos` WHERE idProducto =" + cod;
            commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                reader = commandDatabase.ExecuteReader();
                MessageBox.Show("Eliminado satisfactoriamente");
            }
            catch (Exception ex)
            {
                // Ops, quizás el id no existe
                MessageBox.Show(ex.Message);
            }
        }

        private void updateProducto()
        {
            string query = "UPDATE `productos` SET `idProducto` = '" + textBox1.Text + "', `nombreProducto` ='" + textBox2.Text + "', `descripcionProducto` ='" + textBox3.Text + "', `precioProducto` ='" + textBox4.Text + "', `existenciasProductos` ='" + textBox5.Text + "' WHERE `productos`.`idProducto` =" + textBox1.Text;
            //Console.WriteLine(query);
            commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                reader = commandDatabase.ExecuteReader();
                MessageBox.Show("Actualizado satisfactoriamente");
            }
            catch (Exception ex)
            {
                // Ops, quizás el ID no existe
                MessageBox.Show("Ops, quizás el ID no existe");
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connect();
            deleteProducto();
            CloseDataBase();

            connect();
            readProducto();
            CloseDataBase();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connect();
            updateProducto();
            CloseDataBase();

            connect();
            readProducto();
            CloseDataBase();
        }
    }
}
