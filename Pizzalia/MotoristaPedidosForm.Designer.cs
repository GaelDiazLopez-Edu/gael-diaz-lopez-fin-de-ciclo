namespace Pizzalia
{
    partial class MotoristaPedidosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MotoristaPedidosForm));
            label1 = new Label();
            dgvSinAsignar = new DataGridView();
            label2 = new Label();
            btnAsignar = new Button();
            dgvMisPedidos = new DataGridView();
            btnEntregado = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSinAsignar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMisPedidos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 23);
            label1.Name = "label1";
            label1.Size = new Size(164, 25);
            label1.TabIndex = 0;
            label1.Text = "Pedidos sin asignar";
            // 
            // dgvSinAsignar
            // 
            dgvSinAsignar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinAsignar.Location = new Point(29, 71);
            dgvSinAsignar.Name = "dgvSinAsignar";
            dgvSinAsignar.RowHeadersWidth = 62;
            dgvSinAsignar.Size = new Size(410, 233);
            dgvSinAsignar.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(622, 23);
            label2.Name = "label2";
            label2.Size = new Size(110, 25);
            label2.TabIndex = 2;
            label2.Text = "Mis pedidos";
            // 
            // btnAsignar
            // 
            btnAsignar.BackColor = Color.Aquamarine;
            btnAsignar.Location = new Point(456, 133);
            btnAsignar.Name = "btnAsignar";
            btnAsignar.Size = new Size(104, 38);
            btnAsignar.TabIndex = 3;
            btnAsignar.Text = "→ Asignar a mí";
            btnAsignar.UseVisualStyleBackColor = false;
            btnAsignar.Click += btnAsignar_Click;
            // 
            // dgvMisPedidos
            // 
            dgvMisPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMisPedidos.Location = new Point(577, 71);
            dgvMisPedidos.Name = "dgvMisPedidos";
            dgvMisPedidos.RowHeadersWidth = 62;
            dgvMisPedidos.Size = new Size(410, 233);
            dgvMisPedidos.TabIndex = 4;
            // 
            // btnEntregado
            // 
            btnEntregado.BackColor = SystemColors.GradientActiveCaption;
            btnEntregado.Location = new Point(836, 321);
            btnEntregado.Name = "btnEntregado";
            btnEntregado.Size = new Size(138, 37);
            btnEntregado.TabIndex = 5;
            btnEntregado.Text = "ENTREGADO";
            btnEntregado.UseVisualStyleBackColor = false;
            btnEntregado.Click += btnEntregado_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Salmon;
            button1.Location = new Point(456, 196);
            button1.Name = "button1";
            button1.Size = new Size(104, 37);
            button1.TabIndex = 6;
            button1.Text = "← Quitar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // MotoristaPedidosForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 397);
            Controls.Add(button1);
            Controls.Add(btnEntregado);
            Controls.Add(dgvMisPedidos);
            Controls.Add(btnAsignar);
            Controls.Add(label2);
            Controls.Add(dgvSinAsignar);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MotoristaPedidosForm";
            Text = "Asignacion motoristas | Pizzalia |  © Gael Diaz Lopez";
            ((System.ComponentModel.ISupportInitialize)dgvSinAsignar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMisPedidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvSinAsignar;
        private Label label2;
        private Button btnAsignar;
        private DataGridView dgvMisPedidos;
        private Button btnEntregado;
        private Button button1;
    }
}