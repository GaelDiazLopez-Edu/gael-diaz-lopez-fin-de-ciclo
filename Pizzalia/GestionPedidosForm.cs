using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using System.Drawing;

namespace Pizzalia
{
    public partial class GestionPedidosForm : Form
    {
        private readonly string rutaPedidos = "pedidos.json";
        private List<Pedido> pedidos = new List<Pedido>();

        public GestionPedidosForm()
        {
            InitializeComponent();
            InicializarGrid();
            CargarPedidos();
            dgvPedidos.CellContentClick += dgvPedidos_CellContentClick;
        }

        private void InicializarGrid()
        {
            dgvPedidos.Columns.Clear();
            dgvPedidos.AutoGenerateColumns = false;

            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nombre", HeaderText = "Nombre", DataPropertyName = "Nombre" });
            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefono", HeaderText = "Teléfono", DataPropertyName = "Telefono" });
            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tipo", HeaderText = "Tipo", DataPropertyName = "Tipo" });
            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Mesa", HeaderText = "Mesa", DataPropertyName = "Mesa" });
            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Repartidor", HeaderText = "Repartidor", DataPropertyName = "Repartidor" });
            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Direccion", HeaderText = "Dirección", DataPropertyName = "Direccion" });
            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fecha", HeaderText = "Fecha", DataPropertyName = "Fecha" });
            dgvPedidos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "Total", DataPropertyName = "Total" });

            var btnEditar = new DataGridViewButtonColumn
            {
                Name = "Editar",
                HeaderText = "",
                Text = "Editar",
                UseColumnTextForButtonValue = true
            };
            dgvPedidos.Columns.Add(btnEditar);

            var btnEliminar = new DataGridViewButtonColumn
            {
                Name = "Eliminar",
                HeaderText = "",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };
            btnEliminar.CellTemplate.Style.BackColor = Color.IndianRed;
            dgvPedidos.Columns.Add(btnEliminar);

            // Ordenar
            string[] order = { "Nombre", "Telefono", "Tipo", "Mesa", "Repartidor", "Direccion", "Fecha", "Total", "Editar", "Eliminar" };
            for (int i = 0; i < order.Length; i++)
                dgvPedidos.Columns[order[i]].DisplayIndex = i;

            // Cabecera en negrita
            dgvPedidos.ColumnHeadersDefaultCellStyle.Font = new Font(dgvPedidos.Font, FontStyle.Bold);
        }

        private void CargarPedidos()
        {
            if (File.Exists(rutaPedidos))
            {
                string json = File.ReadAllText(rutaPedidos);
                pedidos = JsonSerializer.Deserialize<List<Pedido>>(json) ?? new List<Pedido>();
            }
            else
            {
                pedidos = new List<Pedido>();
            }

            var pedidosVista = pedidos.Select(p => new PedidoVista
            {
                Nombre = (p.TipoPedido == "Llevar") ? "" : p.NombrePedido,
                Telefono = (p.TipoPedido == "Llevar") ? p.NombrePedido : "",
                Tipo = (p.TipoPedido == "Llevar") ? "Domicilio"
                     : (p.TipoPedido == "Local" && p.Motorista == "PARA LLEVAR") ? "Llevar"
                     : "Local",
                Mesa = (p.TipoPedido == "Local" && !string.IsNullOrWhiteSpace(p.Motorista)
                        && p.Motorista != "PARA LLEVAR" && p.Motorista != "EN LOCAL") ? p.Motorista : "",
                Repartidor = (p.TipoPedido == "Llevar" && !string.IsNullOrWhiteSpace(p.Motorista) && p.Motorista != "PARA LLEVAR") ? p.Motorista : "",
                Direccion = (p.TipoPedido == "Llevar") ? p.Direccion : "",
                Fecha = p.Fecha.ToString("g"),
                Total = p.Total
            }).ToList();

            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = pedidosVista;
        }

        private void GuardarPedidos()
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(rutaPedidos, JsonSerializer.Serialize(pedidos, opciones));
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var fechaStr = dgvPedidos.Rows[e.RowIndex].Cells["Fecha"].Value?.ToString();
            var nombre = dgvPedidos.Rows[e.RowIndex].Cells["Nombre"].Value?.ToString();
            var telefono = dgvPedidos.Rows[e.RowIndex].Cells["Telefono"].Value?.ToString();
            var tipo = dgvPedidos.Rows[e.RowIndex].Cells["Tipo"].Value?.ToString();

            Pedido pedido = null;
            if (tipo == "Domicilio")
            {
                pedido = pedidos.FirstOrDefault(p =>
                    p.TipoPedido == "Llevar" &&
                    p.NombrePedido == telefono &&
                    p.Fecha.ToString("g") == fechaStr
                );
            }
            else // Local o Llevar desde local
            {
                pedido = pedidos.FirstOrDefault(p =>
                    p.TipoPedido == "Local" &&
                    p.NombrePedido == nombre &&
                    p.Fecha.ToString("g") == fechaStr
                );
            }

            if (pedido == null)
                return;

            if (dgvPedidos.Columns[e.ColumnIndex].Name == "Editar")
            {
                if (pedido.TipoPedido == "Local")
                {
                    PedidoEnTiendaForm form = new PedidoEnTiendaForm(pedido, true);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        pedidos[e.RowIndex] = form.PedidoEditado;
                        GuardarPedidos();
                        CargarPedidos();
                    }
                }
                else if (pedido.TipoPedido == "Llevar")
                {
                    PedidoParaLlevarForm form = new PedidoParaLlevarForm(pedido, true);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        pedidos[e.RowIndex] = form.PedidoEditado;
                        GuardarPedidos();
                        CargarPedidos();
                    }
                }
            }
            else if (dgvPedidos.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                var resultado = MessageBox.Show("¿Seguro que deseas eliminar este pedido?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    pedidos.Remove(pedido);
                    GuardarPedidos();
                    CargarPedidos();
                    MessageBox.Show("Pedido eliminado.", "Info");
                }
                else
                {
                    MessageBox.Show("Eliminación cancelada.", "Info");
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarPedidos();
        }
    }

    public class PedidoVista
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Tipo { get; set; }
        public string Mesa { get; set; }
        public string Repartidor { get; set; }
        public string Direccion { get; set; }
        public string Fecha { get; set; }
        public decimal Total { get; set; }
    }
}
