using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using System.Drawing;

namespace Pizzalia
{
    public partial class Articulos : Form
    {
        private List<Articulo> articulos = new List<Articulo>();
        private int? articuloSeleccionadoId = null;
        private readonly string rutaJson = "articulos.json";

        public Articulos()
        {
            InitializeComponent();
            CargarArticulosDesdeJson();
            InicializarControles();
            RefrescarGrid();
        }

        private void InicializarControles()
        {
            dataGridViewArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewArticulos.MultiSelect = false;
            dataGridViewArticulos.ReadOnly = true;
            dataGridViewArticulos.AllowUserToAddRows = false;
            dataGridViewArticulos.ColumnHeadersDefaultCellStyle.Font = new Font(
                dataGridViewArticulos.Font,
                FontStyle.Bold
            );
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return;
            }
            if (comboBoxCategoria.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoría.");
                return;
            }

            if (articulos.Any(a => a.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe un artículo con ese nombre. Por favor, elija otro nombre.");
                return;
            }

            decimal precioBase = numericUpDownPrecio.Value;
            string categoria = comboBoxCategoria.SelectedItem.ToString();

            Articulo nuevo = new Articulo
            {
                Id = articulos.Count > 0 ? articulos.Max(a => a.Id) + 1 : 1,
                Nombre = nombre,
                Precio = precioBase,
                Categoria = categoria
            };
            articulos.Add(nuevo);

            GuardarArticulosEnJson();
            RefrescarGrid();
            LimpiarCampos();
            MessageBox.Show("Se ha añadido el producto correctamente.");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            if (articuloSeleccionadoId == null || !articulos.Any(a => a.Id == articuloSeleccionadoId.Value))
            {
                MessageBox.Show("Seleccione un artículo válido para editar.");
                return;
            }

            string nuevoNombre = textBoxNombre.Text.Trim();
            if (articulos.Any(a => a.Id != articuloSeleccionadoId.Value && a.Nombre.Equals(nuevoNombre, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ya existe otro artículo con ese nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var articulo = articulos.FirstOrDefault(a => a.Id == articuloSeleccionadoId.Value);
            if (articulo != null)
            {
                articulo.Nombre = nuevoNombre;
                articulo.Precio = numericUpDownPrecio.Value;
                articulo.Categoria = comboBoxCategoria.SelectedItem.ToString();

                GuardarArticulosEnJson();
                RefrescarGrid();
                LimpiarCampos();
                MessageBox.Show("Artículo editado correctamente.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (articuloSeleccionadoId == null || !articulos.Any(a => a.Id == articuloSeleccionadoId.Value))
            {
                MessageBox.Show("Seleccione un artículo válido para eliminar.");
                return;
            }

            articulos.RemoveAll(a => a.Id == articuloSeleccionadoId.Value);
            GuardarArticulosEnJson();
            RefrescarGrid();
            LimpiarCampos();
            MessageBox.Show("Artículo eliminado correctamente.");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dataGridViewArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dataGridViewArticulos.Rows[e.RowIndex];
                articuloSeleccionadoId = Convert.ToInt32(fila.Cells["Id"].Value);
                textBoxNombre.Text = fila.Cells["Nombre"].Value.ToString();
                numericUpDownPrecio.Value = Convert.ToDecimal(fila.Cells["Precio"].Value);
                comboBoxCategoria.SelectedItem = fila.Cells["Categoria"].Value.ToString();
            }
        }

        private bool ValidarCampos()
        {
            string nombre = textBoxNombre.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return false;
            }
            if (comboBoxCategoria.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoría.");
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            articuloSeleccionadoId = null;
            textBoxNombre.Clear();
            numericUpDownPrecio.Value = 1;
            comboBoxCategoria.SelectedIndex = -1;
        }

        private void RefrescarGrid()
        {
            var datos = articulos.Select(a => new
            {
                a.Id,
                a.Nombre,
                a.Precio,
                a.Categoria
            }).ToList();

            dataGridViewArticulos.DataSource = null;
            dataGridViewArticulos.DataSource = datos;
            dataGridViewArticulos.Columns["Id"].Visible = false;

            // Aquí se fuerza el formato con dos decimales
            dataGridViewArticulos.Columns["Precio"].DefaultCellStyle.Format = "N2";
        }

        private void GuardarArticulosEnJson()
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(rutaJson, JsonSerializer.Serialize(articulos, opciones));
        }

        private void CargarArticulosDesdeJson()
        {
            if (File.Exists(rutaJson))
            {
                string json = File.ReadAllText(rutaJson);
                articulos = JsonSerializer.Deserialize<List<Articulo>>(json) ?? new List<Articulo>();
            }
            else
            {
                articulos = new List<Articulo>();
            }
        }
    }

    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
    }
}
