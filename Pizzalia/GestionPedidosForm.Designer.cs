namespace Pizzalia
{
    partial class GestionPedidosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionPedidosForm));
            dgvPedidos = new DataGridView();
            btnActualizar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            SuspendLayout();
            // 
            // dgvPedidos
            // 
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Location = new Point(39, 27);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.RowHeadersWidth = 62;
            dgvPedidos.Size = new Size(891, 417);
            dgvPedidos.TabIndex = 0;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(255, 255, 192);
            btnActualizar.Location = new Point(718, 469);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(212, 39);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar pedidos";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // GestionPedidosForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(971, 541);
            Controls.Add(btnActualizar);
            Controls.Add(dgvPedidos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GestionPedidosForm";
            Text = "Gestion de Pedidos | Pizzalia |  © Gael Diaz Lopez";
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPedidos;
        private Button btnActualizar;
    }
}