using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Pizzalia
{
    public partial class Inventario : Form
    {
        private readonly string rutaStock = "stock.json";
        private readonly string rutaArticulos = "articulos.json";
        private readonly string rutaAviso = "avisoStock.json";
        private List<StockItem> stockItems = new List<StockItem>();
        private int avisoStock = 20; // Valor por defecto (editable) de el aviso del stock

        public Inventario()
        {
            InitializeComponent();
            CargarAvisoStock();
            CargarArticulos();
            InicializarGrid();
            RefrescarGrid();

            numericUpDownAviso.ValueChanged += numericUpDownAviso_ValueChanged;
            dataGridViewInventario.CellFormatting += dataGridViewInventario_CellFormatting;
            dataGridViewInventario.EditingControlShowing += dataGridViewInventario_EditingControlShowing;
        }

        private void CargarAvisoStock()
        {
            if (File.Exists(rutaAviso))
            {
                int? aviso = JsonSerializer.Deserialize<int?>(File.ReadAllText(rutaAviso));
                if (aviso.HasValue) avisoStock = aviso.Value;
            }
            numericUpDownAviso.Value = avisoStock;
        }

        private void GuardarAvisoStock()
        {
            File.WriteAllText(rutaAviso, JsonSerializer.Serialize(avisoStock));
        }

        private void CargarArticulos()
        {
            // Artículos fijos
            var fijos = new List<StockItem>
            {
                new StockItem { Nombre = "Cajas medianas" },
                new StockItem { Nombre = "Cajas pequeñas" },
                new StockItem { Nombre = "Cajas grandes" },
                new StockItem { Nombre = "Cajas complementos" },
                new StockItem { Nombre = "Bolsas" }
            };

            // Artículos dinámicos (leídos de articulos.json)
            List<Articulo> articulos = new List<Articulo>();
            if (File.Exists(rutaArticulos))
            {
                string json = File.ReadAllText(rutaArticulos);
                articulos = JsonSerializer.Deserialize<List<Articulo>>(json) ?? new List<Articulo>();
            }

            var dinamicos = articulos
                .Where(a => a.Categoria == "Complementos" || a.Categoria == "Bebidas" || a.Categoria == "Postres")
                .Select(a => new StockItem { Nombre = a.Nombre })
                .ToList();

            // Cargar stock guardado si existe
            if (File.Exists(rutaStock))
            {
                string json = File.ReadAllText(rutaStock);
                stockItems = JsonSerializer.Deserialize<List<StockItem>>(json) ?? new List<StockItem>();
            }
            else
            {
                stockItems = new List<StockItem>();
            }

            // Añadir los artículos que no estén ya en el stock
            foreach (var item in fijos.Concat(dinamicos))
            {
                if (!stockItems.Any(s => s.Nombre == item.Nombre))
                    stockItems.Add(item);
            }

            // Eliminar del stock los artículos que ya no existen
            stockItems = stockItems.Where(s =>
                fijos.Any(f => f.Nombre == s.Nombre) ||
                dinamicos.Any(d => d.Nombre == s.Nombre)
            ).ToList();
        }

        private void InicializarGrid()
        {
            dataGridViewInventario.Columns.Clear();
            dataGridViewInventario.AutoGenerateColumns = false;

            // Columna Nombre (solo lectura)
            var colNombre = new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                DataPropertyName = "Nombre",
                HeaderText = "Artículo",
                ReadOnly = true,
                Width = 200
            };
            dataGridViewInventario.Columns.Add(colNombre);

            // Columna Stock (editable)
            var colStock = new DataGridViewTextBoxColumn
            {
                Name = "colStock",
                DataPropertyName = "Stock",
                HeaderText = "Stock",
                Width = 60,
                ReadOnly = false
            };
            dataGridViewInventario.Columns.Add(colStock);

            // Columna Aviso (solo lectura, calculada)
            var colAviso = new DataGridViewTextBoxColumn
            {
                Name = "colAviso",
                HeaderText = "Aviso",
                ReadOnly = true,
                Width = 60
            };
            dataGridViewInventario.Columns.Add(colAviso);

            // Permite editar directamente al seleccionar la celda
            dataGridViewInventario.EditMode = DataGridViewEditMode.EditOnEnter;

            // Cabecera en negrita
            dataGridViewInventario.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridViewInventario.Font, FontStyle.Bold);
        }


        private void RefrescarGrid()
        {
            dataGridViewInventario.DataSource = null;
            dataGridViewInventario.DataSource = stockItems;
        }

        private void dataGridViewInventario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewInventario.Columns[e.ColumnIndex].Name == "colAviso")
            {
                int stock = Convert.ToInt32(dataGridViewInventario.Rows[e.RowIndex].Cells["colStock"].Value);
                if (stock < avisoStock && stock >= 1)
                {
                    e.Value = "¡Bajo!";
                    e.CellStyle.ForeColor = Color.Orange;
                    e.CellStyle.Font = new Font(dataGridViewInventario.Font, FontStyle.Bold);
                }
                else if (stock <= 0)
                {
                    e.Value = "¡Vacio!";
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(dataGridViewInventario.Font, FontStyle.Bold);
                }
                else
                {
                    e.Value = "";
                    e.CellStyle.ForeColor = dataGridViewInventario.DefaultCellStyle.ForeColor;
                    e.CellStyle.Font = dataGridViewInventario.DefaultCellStyle.Font;
                }
            }
        }

        private void dataGridViewInventario_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridViewInventario.CurrentCell.ColumnIndex == dataGridViewInventario.Columns["colStock"].Index)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= Tb_KeyPress;
                    tb.KeyPress += Tb_KeyPress;
                }
            }
        }

        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo números y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Leer los valores del grid y actualizar la lista
            for (int i = 0; i < dataGridViewInventario.Rows.Count; i++)
            {
                string nombre = dataGridViewInventario.Rows[i].Cells["colNombre"].Value.ToString();
                int stock = 0;
                int.TryParse(dataGridViewInventario.Rows[i].Cells["colStock"].Value?.ToString(), out stock);

                var item = stockItems.FirstOrDefault(s => s.Nombre == nombre);
                if (item != null)
                {
                    item.Stock = stock;
                }
            }
            GuardarStock();
            RefrescarGrid();
            MessageBox.Show("Inventario guardado correctamente.");
        }

        private void numericUpDownAviso_ValueChanged(object sender, EventArgs e)
        {
            avisoStock = (int)numericUpDownAviso.Value;
            GuardarAvisoStock();
            RefrescarGrid();
        }

        private void GuardarStock()
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(rutaStock, JsonSerializer.Serialize(stockItems, opciones));
        }

    }

    public class StockItem
    {
        public string Nombre { get; set; }
        public int Stock { get; set; }
    }
}
