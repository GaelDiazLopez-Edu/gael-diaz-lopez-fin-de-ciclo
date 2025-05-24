namespace Pizzalia
{
    partial class Usuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usuarios));
            btnAgregar = new Button();
            txtNombre = new TextBox();
            txtNumeroMoto = new TextBox();
            dataGridViewUsuarios = new DataGridView();
            txtTelefono = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(60, 336);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(112, 48);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(524, 87);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(241, 31);
            txtNombre.TabIndex = 1;
            // 
            // txtNumeroMoto
            // 
            txtNumeroMoto.Location = new Point(524, 143);
            txtNumeroMoto.Name = "txtNumeroMoto";
            txtNumeroMoto.Size = new Size(241, 31);
            txtNumeroMoto.TabIndex = 2;
            // 
            // dataGridViewUsuarios
            // 
            dataGridViewUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsuarios.Location = new Point(27, 30);
            dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            dataGridViewUsuarios.RowHeadersWidth = 62;
            dataGridViewUsuarios.Size = new Size(360, 225);
            dataGridViewUsuarios.TabIndex = 3;
            dataGridViewUsuarios.SelectionChanged += dataGridViewUsuarios_SelectionChanged;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(524, 201);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(241, 31);
            txtTelefono.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(411, 93);
            label1.Name = "label1";
            label1.Size = new Size(82, 25);
            label1.TabIndex = 5;
            label1.Text = "Nombre:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(417, 149);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 6;
            label2.Text = "Moto:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(413, 206);
            label3.Name = "label3";
            label3.Size = new Size(83, 25);
            label3.TabIndex = 7;
            label3.Text = "Telefono:";
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(243, 336);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(112, 48);
            btnModificar.TabIndex = 8;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(445, 336);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 48);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(625, 336);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(112, 48);
            btnLimpiar.TabIndex = 10;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // Usuarios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTelefono);
            Controls.Add(dataGridViewUsuarios);
            Controls.Add(txtNumeroMoto);
            Controls.Add(txtNombre);
            Controls.Add(btnAgregar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Usuarios";
            Text = "Repartidores | Pizzalia |  © Gael Diaz Lopez";
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private TextBox txtNombre;
        private TextBox txtNumeroMoto;
        private DataGridView dataGridViewUsuarios;
        private TextBox txtTelefono;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
    }
}