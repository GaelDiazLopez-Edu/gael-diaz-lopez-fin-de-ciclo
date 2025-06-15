using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Pizzalia
{
    public partial class PedidoEnTiendaForm : Form
    {
        private List<Articulo> articulos = new List<Articulo>();
        private List<PedidoItem> pedidoActual = new List<PedidoItem>();
        private decimal total = 0;
        private readonly string rutaArticulos = "articulos.json";
        public Pedido PedidoEditado { get; private set; }
        private bool modoEdicion = false;

        public PedidoEnTiendaForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += PedidoEnTiendaForm_KeyDown;

            CargarArticulos();
            InicializarControles();
            ActualizarTotal();
            this.chkParaLlevar.CheckedChanged += chkParaLlevar_CheckedChanged;
        }

        public PedidoEnTiendaForm(Pedido pedidoAEditar, bool edicion = false)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += PedidoEnTiendaForm_KeyDown;

            CargarArticulos();
            InicializarControles();
            ActualizarTotal();

            if (edicion && pedidoAEditar != null)
            {
                modoEdicion = true;
                txtNombrePedido.Text = pedidoAEditar.NombrePedido;
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

                // --- MODIFICACIÓN PARA CHECKBOX Y MESA ---
                if (pedidoAEditar.Motorista == "PARA LLEVAR")
                {
                    chkParaLlevar.Checked = true;
                    nudNumeroMesa.Value = nudNumeroMesa.Minimum;
                }
                else
                {
                    chkParaLlevar.Checked = false;
                    int mesa;
                    if (int.TryParse(pedidoAEditar.Motorista, out mesa))
                    {
                        nudNumeroMesa.Value = Math.Max(nudNumeroMesa.Minimum, Math.Min(nudNumeroMesa.Maximum, mesa));
                    }
                    else
                    {
                        nudNumeroMesa.Value = nudNumeroMesa.Minimum;
                    }
                }
            }
            this.chkParaLlevar.CheckedChanged += chkParaLlevar_CheckedChanged;
        }

        private void PedidoEnTiendaForm_KeyDown(object sender, KeyEventArgs e)
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
            txtNombrePedido.Clear();
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
            // Cabecera en negrita para dgvArticulos
            dgvArticulos.ColumnHeadersDefaultCellStyle.Font = new Font(dgvArticulos.Font, System.Drawing.FontStyle.Bold);

            dgvPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedido.MultiSelect = false;
            dgvPedido.ReadOnly = true;
            dgvPedido.AllowUserToAddRows = false;
            // Cabecera en negrita para dgvPedido
            dgvPedido.ColumnHeadersDefaultCellStyle.Font = new Font(dgvPedido.Font, System.Drawing.FontStyle.Bold);

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
            string nombrePedido = txtNombrePedido.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombrePedido))
            {
                MessageBox.Show("Debes asignar un nombre al pedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombrePedido.Focus();
                return;
            }

            string repartidorOMesa;
            if (chkParaLlevar.Checked)
            {
                repartidorOMesa = "PARA LLEVAR";
            }
            else
            {
                repartidorOMesa = nudNumeroMesa.Value.ToString();
            }

            PedidoEditado = new Pedido
            {
                NombrePedido = nombrePedido,
                TipoPedido = "Local",
                Direccion = "",
                Motorista = repartidorOMesa,
                Fecha = DateTime.Now,
                Articulos = new List<PedidoItem>(pedidoActual),
                Total = total
            };

            this.DialogResult = DialogResult.OK;
        }

        private void chkParaLlevar_CheckedChanged(object sender, EventArgs e)
        {
            bool paraLlevar = chkParaLlevar.Checked;
            nudNumeroMesa.Visible = !paraLlevar;
            lblNumeroMesa.Visible = !paraLlevar;
        }
    }
}
