namespace Pizzalia
{
    partial class SeleccionTipoDePedidoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeleccionTipoDePedidoForm));
            btnTienda = new Button();
            btnDomicilio = new Button();
            label1 = new Label();
            btnRevisarPedidos = new Button();
            SuspendLayout();
            // 
            // btnTienda
            // 
            btnTienda.Location = new Point(96, 104);
            btnTienda.Name = "btnTienda";
            btnTienda.Size = new Size(282, 62);
            btnTienda.TabIndex = 0;
            btnTienda.Text = "TIENDA";
            btnTienda.UseVisualStyleBackColor = true;
            btnTienda.Click += btnTienda_Click;
            // 
            // btnDomicilio
            // 
            btnDomicilio.Location = new Point(96, 198);
            btnDomicilio.Name = "btnDomicilio";
            btnDomicilio.Size = new Size(282, 62);
            btnDomicilio.TabIndex = 1;
            btnDomicilio.Text = "DOMICILIO";
            btnDomicilio.UseVisualStyleBackColor = true;
            btnDomicilio.Click += btnDomicilio_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(126, 28);
            label1.Name = "label1";
            label1.Size = new Size(220, 25);
            label1.TabIndex = 2;
            label1.Text = "¿Para donde es el pedido?";
            // 
            // btnRevisarPedidos
            // 
            btnRevisarPedidos.Location = new Point(12, 283);
            btnRevisarPedidos.Name = "btnRevisarPedidos";
            btnRevisarPedidos.Size = new Size(180, 43);
            btnRevisarPedidos.TabIndex = 3;
            btnRevisarPedidos.Text = "Revisar pedidos";
            btnRevisarPedidos.UseVisualStyleBackColor = true;
            btnRevisarPedidos.Click += btnRevisarPedidos_Click_1;
            // 
            // SeleccionTipoDePedidoForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 338);
            Controls.Add(btnRevisarPedidos);
            Controls.Add(label1);
            Controls.Add(btnDomicilio);
            Controls.Add(btnTienda);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SeleccionTipoDePedidoForm";
            Text = "Principal | Pizzalia |  © Gael Diaz Lopez";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTienda;
        private Button btnDomicilio;
        private Label label1;
        private Button btnRevisarPedidos;
    }
}