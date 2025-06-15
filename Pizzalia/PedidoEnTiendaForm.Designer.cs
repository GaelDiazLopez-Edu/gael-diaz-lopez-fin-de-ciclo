namespace Pizzalia
{
    partial class PedidoEnTiendaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedidoEnTiendaForm));
            cbCategoria = new ComboBox();
            dgvArticulos = new DataGridView();
            btnAgregar = new Button();
            nudCantidad = new NumericUpDown();
            LabelCantidad = new Label();
            dgvPedido = new DataGridView();
            btnEliminar = new Button();
            lblTotal = new Label();
            btnFinalizar = new Button();
            txtNombrePedido = new TextBox();
            label1 = new Label();
            chkParaLlevar = new CheckBox();
            nudNumeroMesa = new NumericUpDown();
            lblNumeroMesa = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvArticulos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPedido).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNumeroMesa).BeginInit();
            SuspendLayout();
            // 
            // cbCategoria
            // 
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Location = new Point(38, 22);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(182, 33);
            cbCategoria.TabIndex = 0;
            cbCategoria.SelectedIndexChanged += cbCategoria_SelectedIndexChanged;
            // 
            // dgvArticulos
            // 
            dgvArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArticulos.Location = new Point(24, 85);
            dgvArticulos.Name = "dgvArticulos";
            dgvArticulos.RowHeadersWidth = 62;
            dgvArticulos.Size = new Size(360, 225);
            dgvArticulos.TabIndex = 1;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(255, 255, 192);
            btnAgregar.Location = new Point(246, 321);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(112, 40);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(90, 324);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(130, 31);
            nudCantidad.TabIndex = 3;
            // 
            // LabelCantidad
            // 
            LabelCantidad.AutoSize = true;
            LabelCantidad.Location = new Point(27, 326);
            LabelCantidad.Name = "LabelCantidad";
            LabelCantidad.Size = new Size(57, 25);
            LabelCantidad.TabIndex = 4;
            LabelCantidad.Text = "CANT";
            // 
            // dgvPedido
            // 
            dgvPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedido.Location = new Point(422, 85);
            dgvPedido.Name = "dgvPedido";
            dgvPedido.RowHeadersWidth = 62;
            dgvPedido.Size = new Size(360, 225);
            dgvPedido.TabIndex = 5;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.IndianRed;
            btnEliminar.Location = new Point(659, 321);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 40);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(563, 330);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 25);
            lblTotal.TabIndex = 7;
            // 
            // btnFinalizar
            // 
            btnFinalizar.BackColor = SystemColors.GradientActiveCaption;
            btnFinalizar.Location = new Point(659, 381);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(112, 45);
            btnFinalizar.TabIndex = 8;
            btnFinalizar.Text = "Finalizar";
            btnFinalizar.UseVisualStyleBackColor = false;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // txtNombrePedido
            // 
            txtNombrePedido.Location = new Point(597, 24);
            txtNombrePedido.Name = "txtNombrePedido";
            txtNombrePedido.Size = new Size(191, 31);
            txtNombrePedido.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(500, 27);
            label1.Name = "label1";
            label1.Size = new Size(78, 25);
            label1.TabIndex = 10;
            label1.Text = "Nombre";
            // 
            // chkParaLlevar
            // 
            chkParaLlevar.AutoSize = true;
            chkParaLlevar.Location = new Point(487, 390);
            chkParaLlevar.Name = "chkParaLlevar";
            chkParaLlevar.Size = new Size(117, 29);
            chkParaLlevar.TabIndex = 11;
            chkParaLlevar.Text = "Para llevar";
            chkParaLlevar.UseVisualStyleBackColor = true;
            chkParaLlevar.CheckedChanged += chkParaLlevar_CheckedChanged;
            // 
            // nudNumeroMesa
            // 
            nudNumeroMesa.Location = new Point(368, 388);
            nudNumeroMesa.Name = "nudNumeroMesa";
            nudNumeroMesa.Size = new Size(86, 31);
            nudNumeroMesa.TabIndex = 12;
            // 
            // lblNumeroMesa
            // 
            lblNumeroMesa.AutoSize = true;
            lblNumeroMesa.Location = new Point(290, 393);
            lblNumeroMesa.Name = "lblNumeroMesa";
            lblNumeroMesa.Size = new Size(58, 25);
            lblNumeroMesa.TabIndex = 13;
            lblNumeroMesa.Text = "Mesa:";
            // 
            // PedidoEnTiendaForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblNumeroMesa);
            Controls.Add(nudNumeroMesa);
            Controls.Add(chkParaLlevar);
            Controls.Add(label1);
            Controls.Add(txtNombrePedido);
            Controls.Add(btnFinalizar);
            Controls.Add(lblTotal);
            Controls.Add(btnEliminar);
            Controls.Add(dgvPedido);
            Controls.Add(LabelCantidad);
            Controls.Add(nudCantidad);
            Controls.Add(btnAgregar);
            Controls.Add(dgvArticulos);
            Controls.Add(cbCategoria);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PedidoEnTiendaForm";
            Text = "Pedidos para tienda | Pizzalia |  © Gael Diaz Lopez";
            ((System.ComponentModel.ISupportInitialize)dgvArticulos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPedido).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNumeroMesa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbCategoria;
        private DataGridView dgvArticulos;
        private Button btnAgregar;
        private NumericUpDown nudCantidad;
        private Label LabelCantidad;
        private DataGridView dgvPedido;
        private Button btnEliminar;
        private Label lblTotal;
        private Button btnFinalizar;
        private TextBox txtNombrePedido;
        private Label label1;
        private CheckBox chkParaLlevar;
        private NumericUpDown nudNumeroMesa;
        private Label lblNumeroMesa;
    }
}