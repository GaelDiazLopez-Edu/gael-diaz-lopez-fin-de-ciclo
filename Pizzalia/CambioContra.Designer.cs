namespace Pizzalia
{
    partial class CambioContra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CambioContra));
            txtNuevaContra = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtRepetirContra = new TextBox();
            btnGuardarContra = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // txtNuevaContra
            // 
            txtNuevaContra.Location = new Point(242, 71);
            txtNuevaContra.Name = "txtNuevaContra";
            txtNuevaContra.Size = new Size(150, 31);
            txtNuevaContra.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 74);
            label1.Name = "label1";
            label1.Size = new Size(183, 25);
            label1.TabIndex = 1;
            label1.Text = "Introduce contraseña:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 140);
            label2.Name = "label2";
            label2.Size = new Size(156, 25);
            label2.TabIndex = 3;
            label2.Text = "Repite contraseña:";
            // 
            // txtRepetirContra
            // 
            txtRepetirContra.Location = new Point(242, 140);
            txtRepetirContra.Name = "txtRepetirContra";
            txtRepetirContra.Size = new Size(150, 31);
            txtRepetirContra.TabIndex = 2;
            // 
            // btnGuardarContra
            // 
            btnGuardarContra.BackColor = SystemColors.ActiveCaption;
            btnGuardarContra.Location = new Point(57, 218);
            btnGuardarContra.Name = "btnGuardarContra";
            btnGuardarContra.Size = new Size(132, 58);
            btnGuardarContra.TabIndex = 4;
            btnGuardarContra.Text = "Guardar";
            btnGuardarContra.UseVisualStyleBackColor = false;
            btnGuardarContra.Click += btnGuardarContra_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.Location = new Point(260, 218);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(132, 58);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // CambioContra
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 312);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardarContra);
            Controls.Add(label2);
            Controls.Add(txtRepetirContra);
            Controls.Add(label1);
            Controls.Add(txtNuevaContra);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CambioContra";
            Text = "Pizzalia |  © Gael Diaz Lopez";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNuevaContra;
        private Label label1;
        private Label label2;
        private TextBox txtRepetirContra;
        private Button btnGuardarContra;
        private Button btnCancelar;
    }
}