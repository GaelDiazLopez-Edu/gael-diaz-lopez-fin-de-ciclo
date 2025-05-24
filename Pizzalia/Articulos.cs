using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzalia
{
    public partial class Articulos : Form
    {
        private List<Articulo> articulos = new List<Articulo>();
        private int? articuloSeleccionadoId = null;
        private readonly string rutaJson = "articulos.json";

        private void InicializarControles()
        {
            btnAgregar.Click += btnAgregar_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            dataGridViewArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewArticulos.MultiSelect = false;
            dataGridViewArticulos.ReadOnly = true;
            dataGridViewArticulos.AllowUserToAddRows = false;
            dataGridViewArticulos.CellClick += dataGridViewArticulos_CellClick;
        }
        public Articulos()
        {
            InitializeComponent();
            CargarArticulosDesdeJson();
            InicializarControles();
            RefrescarGrid();
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            string nombre = textBoxNombre.Text.Trim();
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
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Validar primero los campos
            if (!ValidarCampos()) return;

            // Comprobar si hay artículo seleccionado y existe en la lista
            if (articuloSeleccionadoId == null || !articulos.Any(a => a.Id == articuloSeleccionadoId.Value))
            {
                MessageBox.Show("Seleccione un artículo válido para editar.");
                return;
            }

            var articulo = articulos.FirstOrDefault(a => a.Id == articuloSeleccionadoId.Value);
            if (articulo != null)
            {
                articulo.Nombre = textBoxNombre.Text.Trim();
                articulo.Precio = numericUpDownPrecio.Value;
                articulo.Categoria = comboBoxCategoria.SelectedItem.ToString();

                GuardarArticulosEnJson();
                RefrescarGrid();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Comprobar si hay artículo seleccionado y existe en la lista
            if (articuloSeleccionadoId == null || !articulos.Any(a => a.Id == articuloSeleccionadoId.Value))
            {
                MessageBox.Show("Seleccione un artículo válido para eliminar.");
                return;
            }

            articulos.RemoveAll(a => a.Id == articuloSeleccionadoId.Value);
            GuardarArticulosEnJson();
            RefrescarGrid();
            LimpiarCampos();
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
                Precio = a.Precio,
                a.Categoria
            }).ToList();

            dataGridViewArticulos.DataSource = null;
            dataGridViewArticulos.DataSource = datos;
            dataGridViewArticulos.Columns["Id"].Visible = false;
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