using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using Pizzalia;

namespace Pizzalia
{
    public partial class SeleccionTipoDePedidoForm : Form
    {
        private readonly string rutaPedidos = "pedidos.json";

        public SeleccionTipoDePedidoForm()
        {
            InitializeComponent();

            btnRevisarPedidos.Click += btnRevisarPedidos_Click;
        }

        private void btnTienda_Click(object sender, EventArgs e)
        {
            PedidoEnTiendaForm pedidoForm = new PedidoEnTiendaForm();
            if (pedidoForm.ShowDialog() == DialogResult.OK && pedidoForm.PedidoEditado != null)
            {
                GuardarPedido(pedidoForm.PedidoEditado);
            }
        }

        private void btnDomicilio_Click(object sender, EventArgs e)
        {
            PedidoParaLlevarForm pedidoLlevarForm = new PedidoParaLlevarForm();
            if (pedidoLlevarForm.ShowDialog() == DialogResult.OK && pedidoLlevarForm.PedidoEditado != null)
            {
                GuardarPedido(pedidoLlevarForm.PedidoEditado);
            }
        }

        private void btnRevisarPedidos_Click(object sender, EventArgs e)
        {
            GestionPedidosForm form = new GestionPedidosForm();
            form.ShowDialog();
        }

        private void GuardarPedido(Pedido nuevoPedido)
        {
            List<Pedido> pedidos = new List<Pedido>();
            if (File.Exists(rutaPedidos))
            {
                string json = File.ReadAllText(rutaPedidos);
                pedidos = JsonSerializer.Deserialize<List<Pedido>>(json) ?? new List<Pedido>();
            }
            pedidos.Add(nuevoPedido);
            File.WriteAllText(rutaPedidos, JsonSerializer.Serialize(pedidos, new JsonSerializerOptions { WriteIndented = true }));
        }

        private void btnRevisarPedidos_Click_1(object sender, EventArgs e)
        {

        }
    }
}
