using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using Pizzalia;

namespace Pizzalia
{
    public partial class PedidoParaLlevarForm : Form
    {
        private List<Articulo> articulos = new List<Articulo>();
        private List<PedidoItem> pedidoActual = new List<PedidoItem>();
        private decimal total = 0;
        private readonly string rutaArticulos = "articulos.json";
        public Pedido PedidoEditado { get; private set; }
        private bool modoEdicion = false;

        public PedidoParaLlevarForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += PedidoParaLlevarForm_KeyDown;

            CargarArticulos();
            InicializarControles();
            ActualizarTotal();
        }

        public PedidoParaLlevarForm(Pedido pedidoAEditar, bool edicion = false)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += PedidoParaLlevarForm_KeyDown;

            CargarArticulos();
            InicializarControles();
            ActualizarTotal();

            if (edicion && pedidoAEditar != null)
            {
                modoEdicion = true;
                txtTelefono.Text = pedidoAEditar.NombrePedido;
                txtDireccion.Text = pedidoAEditar.Direccion;
                pedidoActual = pedidoAEditar.Articulos.Select(a => new PedidoItem
                {
                    Categoria = a.Categoria,
                    Articulo = a.Articulo,
                    Cantidad = a.Cantidad,
                    PrecioUnitario = a.PrecioUnitario,
                    Importe = a.Importe
                }).ToList();
                RefrescarPedido();
                ActualizarTotal();
            }
        }

        private void PedidoParaLlevarForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                LimpiarPedido();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                btnFinalizar.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void LimpiarPedido()
        {
            pedidoActual.Clear();
            RefrescarPedido();
            ActualizarTotal();
            txtTelefono.Clear();
            txtDireccion.Clear();
        }

        private void CargarArticulos()
        {
            if (File.Exists(rutaArticulos))
            {
                string json = File.ReadAllText(rutaArticulos);
                articulos = JsonSerializer.Deserialize<List<Articulo>>(json) ?? new List<Articulo>();
            }
        }

        private void InicializarControles()
        {
            cbCategoria.Items.AddRange(new string[] { "Pizzas", "Complementos", "Bebidas", "Postres" });
            cbCategoria.SelectedIndexChanged += cbCategoria_SelectedIndexChanged;
            cbCategoria.SelectedIndex = 0;

            dgvArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArticulos.MultiSelect = false;
            dgvArticulos.ReadOnly = true;
            dgvArticulos.AllowUserToAddRows = false;

            dgvPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedido.MultiSelect = false;
            dgvPedido.ReadOnly = true;
            dgvPedido.AllowUserToAddRows = false;

            nudCantidad.Minimum = 1;
            nudCantidad.Value = 1;

            RefrescarArticulos();
            RefrescarPedido();
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefrescarArticulos();
        }

        private void RefrescarArticulos()
        {
            string categoria = cbCategoria.SelectedItem.ToString();
            var lista = articulos.Where(a => a.Categoria == categoria).ToList();

            if (categoria == "Pizzas")
            {
                lista = lista.SelectMany(a => new[]
                {
                    // Podemos añadir aqui el extra de precio por tamaño
                    new Articulo { Id = a.Id, Nombre = $"{a.Nombre} (Pequeña)", Categoria = a.Categoria, Precio = a.Precio },
                    new Articulo { Id = a.Id, Nombre = $"{a.Nombre} (Mediana)", Categoria = a.Categoria, Precio = a.Precio + 4 },
                    new Articulo { Id = a.Id, Nombre = $"{a.Nombre} (Grande)", Categoria = a.Categoria, Precio = a.Precio + 9 }
                }).ToList();
            }

            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = lista;
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["Categoria"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.SelectedRows.Count == 0) return;

            var articulo = (Articulo)dgvArticulos.SelectedRows[0].DataBoundItem;
            int cantidad = (int)nudCantidad.Value;

            pedidoActual.Add(new PedidoItem
            {
                Categoria = articulo.Categoria,
                Articulo = articulo.Nombre,
                Cantidad = cantidad,
                PrecioUnitario = articulo.Precio,
                Importe = articulo.Precio * cantidad
            });

            RefrescarPedido();
            ActualizarTotal();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPedido.SelectedRows.Count == 0) return;

            var item = (PedidoItem)dgvPedido.SelectedRows[0].DataBoundItem;
            pedidoActual.Remove(item);

            RefrescarPedido();
            ActualizarTotal();
        }

        private void RefrescarPedido()
        {
            dgvPedido.DataSource = null;
            dgvPedido.DataSource = pedidoActual.ToList();
            dgvPedido.Columns["PrecioUnitario"].DefaultCellStyle.Format = "0.00";
            dgvPedido.Columns["Importe"].DefaultCellStyle.Format = "0.00";
        }

        private void ActualizarTotal()
        {
            total = pedidoActual.Sum(x => x.Importe);
            lblTotal.Text = $"Total: {total:0.00} €";
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            string telefono = txtTelefono.Text.Trim();
            string direccion = txtDireccion.Text.Trim();

            if (string.IsNullOrWhiteSpace(telefono))
            {
                MessageBox.Show("Debes introducir el número de teléfono.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(direccion))
            {
                MessageBox.Show("Debes introducir la dirección.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccion.Focus();
                return;
            }

            PedidoEditado = new Pedido
            {
                NombrePedido = telefono,
                TipoPedido = "Llevar",
                Direccion = direccion,
                Motorista = "",
                Fecha = DateTime.Now,
                Articulos = new List<PedidoItem>(pedidoActual),
                Total = total
            };

            this.DialogResult = DialogResult.OK;
        }
    }
}
