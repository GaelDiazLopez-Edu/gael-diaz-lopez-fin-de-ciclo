namespace Pizzalia
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            labelLogin = new Label();
            labelContraseña = new Label();
            inputContra = new TextBox();
            btnInicio = new Button();
            comboBoxLogin = new ComboBox();
            labelRepartidor = new Label();
            comboBoxRepartidor = new ComboBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Location = new Point(190, 365);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(60, 25);
            labelLogin.TabIndex = 1;
            labelLogin.Text = "Login:";
            // 
            // labelContraseña
            // 
            labelContraseña.AutoSize = true;
            labelContraseña.Location = new Point(166, 440);
            labelContraseña.Name = "labelContraseña";
            labelContraseña.Size = new Size(105, 25);
            labelContraseña.TabIndex = 2;
            labelContraseña.Text = "Contraseña:";
            // 
            // inputContra
            // 
            inputContra.Location = new Point(320, 434);
            inputContra.Name = "inputContra";
            inputContra.Size = new Size(188, 31);
            inputContra.TabIndex = 4;
            // 
            // btnInicio
            // 
            btnInicio.Location = new Point(240, 510);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(213, 47);
            btnInicio.TabIndex = 5;
            btnInicio.Text = "Iniciar Sesión";
            btnInicio.UseVisualStyleBackColor = true;
            btnInicio.Click += btnInicio_Click;
            // 
            // comboBoxLogin
            // 
            comboBoxLogin.FormattingEnabled = true;
            comboBoxLogin.Items.AddRange(new object[] { "Administrador", "Empleado/Camarero", "Repartidor" });
            comboBoxLogin.Location = new Point(320, 357);
            comboBoxLogin.Name = "comboBoxLogin";
            comboBoxLogin.Size = new Size(188, 33);
            comboBoxLogin.TabIndex = 6;
            comboBoxLogin.SelectedIndexChanged += comboBoxLogin_SelectedIndexChanged;
            // 
            // labelRepartidor
            // 
            labelRepartidor.AutoSize = true;
            labelRepartidor.Location = new Point(181, 440);
            labelRepartidor.Name = "labelRepartidor";
            labelRepartidor.Size = new Size(82, 25);
            labelRepartidor.TabIndex = 7;
            labelRepartidor.Text = "Nombre:";
            // 
            // comboBoxRepartidor
            // 
            comboBoxRepartidor.FormattingEnabled = true;
            comboBoxRepartidor.Location = new Point(320, 432);
            comboBoxRepartidor.Name = "comboBoxRepartidor";
            comboBoxRepartidor.Size = new Size(188, 33);
            comboBoxRepartidor.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_completo1;
            pictureBox1.Location = new Point(181, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(316, 273);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 192);
            ClientSize = new Size(699, 626);
            Controls.Add(pictureBox1);
            Controls.Add(comboBoxRepartidor);
            Controls.Add(labelRepartidor);
            Controls.Add(comboBoxLogin);
            Controls.Add(btnInicio);
            Controls.Add(inputContra);
            Controls.Add(labelContraseña);
            Controls.Add(labelLogin);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            Text = "Login | Pizzalia |  © Gael Diaz Lopez";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelLogin;
        private Label labelContraseña;
        private TextBox inputContra;
        private Button btnInicio;
        private ComboBox comboBoxLogin;
        private Label labelRepartidor;
        private ComboBox comboBoxRepartidor;
        private PictureBox pictureBox1;
    }
}
