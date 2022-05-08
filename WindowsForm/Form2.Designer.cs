namespace WindowsForm
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView2 = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Apellidos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Usuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.Contraseña = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Teléfono = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dirección = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Población = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.Nombre,
            this.Apellidos,
            this.Email,
            this.Usuario,
            this.Contraseña,
            this.Teléfono,
            this.Dirección,
            this.Población});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(13, 13);
            this.listView2.Margin = new System.Windows.Forms.Padding(4);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1235, 424);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // id
            // 
            this.id.Text = "id";
            this.id.Width = 110;
            // 
            // Nombre
            // 
            this.Nombre.Text = "Nombre";
            this.Nombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Nombre.Width = 110;
            // 
            // Apellidos
            // 
            this.Apellidos.Text = "Apellidos";
            this.Apellidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Apellidos.Width = 200;
            // 
            // Email
            // 
            this.Email.Text = "E-mail";
            this.Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Email.Width = 180;
            // 
            // Usuario
            // 
            this.Usuario.Text = "Usuario";
            this.Usuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Usuario.Width = 110;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1256, 13);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 80);
            this.button1.TabIndex = 3;
            this.button1.Text = "Visualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Contraseña
            // 
            this.Contraseña.Text = "Contraseña";
            this.Contraseña.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Contraseña.Width = 110;
            // 
            // Teléfono
            // 
            this.Teléfono.Text = "Teléfono";
            this.Teléfono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Teléfono.Width = 110;
            // 
            // Dirección
            // 
            this.Dirección.Text = "Dirección";
            this.Dirección.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Dirección.Width = 110;
            // 
            // Población
            // 
            this.Población.Text = "Población";
            this.Población.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Población.Width = 100;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader Apellidos;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader Usuario;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader Nombre;
        private System.Windows.Forms.ColumnHeader Contraseña;
        private System.Windows.Forms.ColumnHeader Teléfono;
        private System.Windows.Forms.ColumnHeader Dirección;
        private System.Windows.Forms.ColumnHeader Población;
    }
}