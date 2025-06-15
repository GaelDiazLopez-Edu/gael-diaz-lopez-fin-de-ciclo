namespace Pizzalia
{
    partial class Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            dataGridViewInventario = new DataGridView();
            numericUpDownAviso = new NumericUpDown();
            label1 = new Label();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInventario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAviso).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewInventario
            // 
            dataGridViewInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInventario.Location = new Point(30, 23);
            dataGridViewInventario.Name = "dataGridViewInventario";
            dataGridViewInventario.RowHeadersWidth = 62;
            dataGridViewInventario.Size = new Size(703, 340);
            dataGridViewInventario.TabIndex = 0;
            dataGridViewInventario.CellFormatting += dataGridViewInventario_CellFormatting;
            dataGridViewInventario.EditingControlShowing += dataGridViewInventario_EditingControlShowing;
            // 
            // numericUpDownAviso
            // 
            numericUpDownAviso.Location = new Point(372, 388);
            numericUpDownAviso.Name = "numericUpDownAviso";
            numericUpDownAviso.Size = new Size(180, 31);
            numericUpDownAviso.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 388);
            label1.Name = "label1";
            label1.Size = new Size(295, 25);
            label1.TabIndex = 2;
            label1.Text = "Avisar cuando el stock sea menor a:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.ActiveCaption;
            btnGuardar.Location = new Point(643, 377);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(112, 51);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // Inventario
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGuardar);
            Controls.Add(label1);
            Controls.Add(numericUpDownAviso);
            Controls.Add(dataGridViewInventario);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Inventario";
            Text = "Inventario | Pizzalia |  © Gael Diaz Lopez";
            ((System.ComponentModel.ISupportInitialize)dataGridViewInventario).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAviso).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewInventario;
        private NumericUpDown numericUpDownAviso;
        private Label label1;
        private Button btnGuardar;
    }
}