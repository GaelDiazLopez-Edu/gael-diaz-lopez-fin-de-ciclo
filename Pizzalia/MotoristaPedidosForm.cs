using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using Pizzalia;

namespace Pizzalia
{
    public partial class MotoristaPedidosForm : Form
    {
        private readonly string rutaPedidos = "pedidos.json";
        private List<Pedido> pedidos = new List<Pedido>();
        private string nombreMotorista;

        public MotoristaPedidosForm(string nombreMotorista)
        {
            InitializeComponent();
            this.nombreMotorista = nombreMotorista;
            CargarPedidos();
            InicializarGrids();
            RefrescarGrids();
        }

        private void CargarPedidos()
        {
            if (File.Exists(rutaPedidos))
            {
                string json = File.ReadAllText(rutaPedidos);
                pedidos = JsonSerializer.Deserialize<List<Pedido>>(json) ?? new List<Pedido>();
            }
        }

        private void InicializarGrids()
        {
            // Configurar DataGridView de pedidos sin asignar
            dgvSinAsignar.AutoGenerateColumns = false;
            dgvSinAsignar.Columns.Clear();
            dgvSinAsignar.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefono", HeaderText = "Teléfono", DataPropertyName = "NombrePedido" });
            dgvSinAsignar.Columns.Add(new DataGridViewTextBoxColumn { Name = "Direccion", HeaderText = "Dirección", DataPropertyName = "Direccion" });
            dgvSinAsignar.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fecha", HeaderText = "Fecha", DataPropertyName = "Fecha" });
            dgvSinAsignar.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "Total", DataPropertyName = "Total" });

            // Cabecera en negrita para grid izquierdo
            dgvSinAsignar.ColumnHeadersDefaultCellStyle.Font = new Font(dgvSinAsignar.Font, FontStyle.Bold);

            // Configurar DataGridView de mis pedidos
            dgvMisPedidos.AutoGenerateColumns = false;
            dgvMisPedidos.Columns.Clear();
            dgvMisPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefono", HeaderText = "Teléfono", DataPropertyName = "NombrePedido" });
            dgvMisPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Direccion", HeaderText = "Dirección", DataPropertyName = "Direccion" });
            dgvMisPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fecha", HeaderText = "Fecha", DataPropertyName = "Fecha" });
            dgvMisPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "Total", DataPropertyName = "Total" });

            // Cabecera en negrita para grid derecho
            dgvMisPedidos.ColumnHeadersDefaultCellStyle.Font = new Font(dgvMisPedidos.Font, FontStyle.Bold);
        }


        private void RefrescarGrids()
        {
            // Izquierda: Pedidos a domicilio sin motorista asignado
            var sinAsignar = pedidos
                .Where(p => p.TipoPedido == "Llevar" && string.IsNullOrWhiteSpace(p.Motorista))
                .ToList();

            // Derecha: Pedidos a domicilio asignados a este motorista
            var misPedidos = pedidos
                .Where(p => p.TipoPedido == "Llevar" && p.Motorista == nombreMotorista)
                .ToList();

            dgvSinAsignar.DataSource = null;
            dgvSinAsignar.DataSource = sinAsignar;

            dgvMisPedidos.DataSource = null;
            dgvMisPedidos.DataSource = misPedidos;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (dgvSinAsignar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un pedido de la izquierda para asignártelo.");
                return;
            }

            var pedido = (Pedido)dgvSinAsignar.SelectedRows[0].DataBoundItem;
            pedido.Motorista = nombreMotorista;

            GuardarPedidos();
            RefrescarGrids();
        }

        private void btnEntregado_Click(object sender, EventArgs e)
        {
            if (dgvMisPedidos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un pedido de la derecha para marcarlo como entregado.");
                return;
            }

            var pedido = (Pedido)dgvMisPedidos.SelectedRows[0].DataBoundItem;

            var resultado = MessageBox.Show("¿Seguro que deseas marcar este pedido como entregado? Se eliminará de la lista.", "Confirmar entrega", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                pedidos.Remove(pedido);
                GuardarPedidos();
                RefrescarGrids();
            }
        }

        private void GuardarPedidos()
        {
            File.WriteAllText(rutaPedidos, JsonSerializer.Serialize(pedidos, new JsonSerializerOptions { WriteIndented = true }));
        }
        // Botón de desasignar o eliminar pedido
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvMisPedidos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un pedido de la derecha para desasignarlo.");
                return;
            }

            var pedido = (Pedido)dgvMisPedidos.SelectedRows[0].DataBoundItem;

            var resultado = MessageBox.Show("¿Seguro que deseas desasignar este pedido? Volverá a la lista de sin asignar.", "Desasignar pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                pedido.Motorista = ""; 
                GuardarPedidos();
                RefrescarGrids();
            }
        }
    }
}
