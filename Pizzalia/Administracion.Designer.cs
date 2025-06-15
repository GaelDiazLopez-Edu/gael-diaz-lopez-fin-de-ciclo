namespace Pizzalia
{
    partial class Administracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Administracion));
            volverLogin = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // volverLogin
            // 
            volverLogin.Location = new Point(30, 380);
            volverLogin.Name = "volverLogin";
            volverLogin.Size = new Size(112, 45);
            volverLogin.TabIndex = 0;
            volverLogin.Text = "Volver";
            volverLogin.UseVisualStyleBackColor = true;
            volverLogin.Click += volverLogin_Click;
            // 
            // button1
            // 
            button1.Location = new Point(306, 160);
            button1.Name = "button1";
            button1.Size = new Size(182, 73);
            button1.TabIndex = 1;
            button1.Text = "Repartidores";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(30, 160);
            button2.Name = "button2";
            button2.Size = new Size(182, 73);
            button2.TabIndex = 2;
            button2.Text = "Inventario";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(524, 380);
            button3.Name = "button3";
            button3.Size = new Size(246, 45);
            button3.TabIndex = 3;
            button3.Text = "Restablecer Contraseña";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(588, 160);
            button4.Name = "button4";
            button4.Size = new Size(182, 73);
            button4.TabIndex = 4;
            button4.Text = "Articulos";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Administracion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(volverLogin);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Administracion";
            Text = "Administracion | Pizzalia |  © Gael Diaz Lopez";
            ResumeLayout(false);
        }

        #endregion

        private Button volverLogin;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}