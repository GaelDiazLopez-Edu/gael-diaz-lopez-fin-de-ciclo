namespace Pizzalia
{
    partial class PedidoParaLlevarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedidoParaLlevarForm));
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cbCategoria = new ComboBox();
            dgvArticulos = new DataGridView();
            dgvPedido = new DataGridView();
            nudCantidad = new NumericUpDown();
            btnAgregar = new Button();
            btnEliminar = new Button();
            lblTotal = new Label();
            btnFinalizar = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvArticulos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPedido).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(97, 31);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(177, 31);
            txtTelefono.TabIndex = 0;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(511, 31);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(360, 31);
            txtDireccion.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 34);
            label1.Name = "label1";
            label1.Size = new Size(79, 25);
            label1.TabIndex = 2;
            label1.Text = "Telefono";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(410, 34);
            label2.Name = "label2";
            label2.Size = new Size(85, 25);
            label2.TabIndex = 3;
            label2.Text = "Dirección";
            // 
            // cbCategoria
            // 
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Location = new Point(22, 78);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(182, 33);
            cbCategoria.TabIndex = 4;
            cbCategoria.SelectedIndexChanged += cbCategoria_SelectedIndexChanged;
            // 
            // dgvArticulos
            // 
            dgvArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArticulos.Location = new Point(22, 117);
            dgvArticulos.Name = "dgvArticulos";
            dgvArticulos.RowHeadersWidth = 62;
            dgvArticulos.Size = new Size(398, 302);
            dgvArticulos.TabIndex = 5;
            // 
            // dgvPedido
            // 
            dgvPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedido.Location = new Point(487, 117);
            dgvPedido.Name = "dgvPedido";
            dgvPedido.RowHeadersWidth = 62;
            dgvPedido.Size = new Size(433, 302);
            dgvPedido.TabIndex = 6;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(139, 434);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(114, 31);
            nudCantidad.TabIndex = 7;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(255, 255, 192);
            btnAgregar.Location = new Point(292, 429);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(112, 42);
            btnAgregar.TabIndex = 8;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.ForeColor = SystemColors.ControlText;
            btnEliminar.Location = new Point(693, 429);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 42);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(565, 436);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 25);
            lblTotal.TabIndex = 10;
            // 
            // btnFinalizar
            // 
            btnFinalizar.BackColor = SystemColors.GradientActiveCaption;
            btnFinalizar.Location = new Point(811, 429);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(112, 42);
            btnFinalizar.TabIndex = 11;
            btnFinalizar.Text = "Finalizar";
            btnFinalizar.UseVisualStyleBackColor = false;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 435);
            label3.Name = "label3";
            label3.Size = new Size(57, 25);
            label3.TabIndex = 12;
            label3.Text = "CANT";
            // 
            // PedidoParaLlevarForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 483);
            Controls.Add(label3);
            Controls.Add(btnFinalizar);
            Controls.Add(lblTotal);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(nudCantidad);
            Controls.Add(dgvPedido);
            Controls.Add(dgvArticulos);
            Controls.Add(cbCategoria);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDireccion);
            Controls.Add(txtTelefono);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PedidoParaLlevarForm";
            Text = "Pedidos para domicilio | Pizzalia |  © Gael Diaz Lopez";
            ((System.ComponentModel.ISupportInitialize)dgvArticulos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPedido).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private Label label1;
        private Label label2;
        private ComboBox cbCategoria;
        private DataGridView dgvArticulos;
        private DataGridView dgvPedido;
        private NumericUpDown nudCantidad;
        private Button btnAgregar;
        private Button btnEliminar;
        private Label lblTotal;
        private Button btnFinalizar;
        private Label label3;
    }
}