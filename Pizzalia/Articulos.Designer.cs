namespace Pizzalia
{
    partial class Articulos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Articulos));
            dataGridViewArticulos = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            numericUpDownPrecio = new NumericUpDown();
            comboBoxCategoria = new ComboBox();
            label3 = new Label();
            textBoxNombre = new TextBox();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArticulos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrecio).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewArticulos
            // 
            dataGridViewArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewArticulos.Location = new Point(23, 12);
            dataGridViewArticulos.Name = "dataGridViewArticulos";
            dataGridViewArticulos.RowHeadersWidth = 62;
            dataGridViewArticulos.Size = new Size(587, 354);
            dataGridViewArticulos.TabIndex = 0;
            dataGridViewArticulos.CellClick += dataGridViewArticulos_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(640, 48);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 1;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(650, 96);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 2;
            label2.Text = "Precio";
            // 
            // numericUpDownPrecio
            // 
            numericUpDownPrecio.DecimalPlaces = 2;
            numericUpDownPrecio.Location = new Point(768, 93);
            numericUpDownPrecio.Name = "numericUpDownPrecio";
            numericUpDownPrecio.Size = new Size(180, 31);
            numericUpDownPrecio.TabIndex = 3;
            // 
            // comboBoxCategoria
            // 
            comboBoxCategoria.FormattingEnabled = true;
            comboBoxCategoria.Items.AddRange(new object[] { "Pizzas", "Complementos", "Bebidas", "Postres" });
            comboBoxCategoria.Location = new Point(766, 145);
            comboBoxCategoria.Name = "comboBoxCategoria";
            comboBoxCategoria.Size = new Size(182, 33);
            comboBoxCategoria.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(637, 148);
            label3.Name = "label3";
            label3.Size = new Size(88, 25);
            label3.TabIndex = 5;
            label3.Text = "Categoria";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(766, 44);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(182, 31);
            textBoxNombre.TabIndex = 6;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(255, 255, 192);
            btnAgregar.Location = new Point(650, 220);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(112, 49);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.LightGray;
            btnEditar.Location = new Point(799, 220);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(112, 49);
            btnEditar.TabIndex = 8;
            btnEditar.Text = "Modificar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.Location = new Point(650, 300);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 49);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = SystemColors.ActiveCaption;
            btnLimpiar.Location = new Point(799, 300);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(112, 49);
            btnLimpiar.TabIndex = 10;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // Articulos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 420);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(textBoxNombre);
            Controls.Add(label3);
            Controls.Add(comboBoxCategoria);
            Controls.Add(numericUpDownPrecio);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewArticulos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Articulos";
            Text = "Articulos | Pizzalia |  © Gael Diaz Lopez";
            ((System.ComponentModel.ISupportInitialize)dataGridViewArticulos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrecio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewArticulos;
        private Label label1;
        private Label label2;
        private NumericUpDown numericUpDownPrecio;
        private ComboBox comboBoxCategoria;
        private Label label3;
        private TextBox textBoxNombre;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
    }
}