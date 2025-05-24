using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Pizzalia
{
    public partial class Usuarios : Form
    {
        private BindingList<Usuario> usuarios;
        private int selectedRow = -1;

        public Usuarios()
        {
            InitializeComponent();
            // Cargar usuarios desde JSON
            usuarios = new BindingList<Usuario>(UsuarioCrudManager.CargarUsuarios());
            dataGridViewUsuarios.DataSource = usuarios;
            dataGridViewUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsuarios.MultiSelect = false;
            dataGridViewUsuarios.AutoGenerateColumns = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNumeroMoto.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Completa todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            usuarios.Add(new Usuario
            {
                Nombre = txtNombre.Text.Trim(),
                NumeroMoto = txtNumeroMoto.Text.Trim(),
                Telefono = txtTelefono.Text.Trim()
            });

            GuardarUsuarios();
            LimpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (selectedRow >= 0 && selectedRow < usuarios.Count)
            {
                usuarios[selectedRow].Nombre = txtNombre.Text.Trim();
                usuarios[selectedRow].NumeroMoto = txtNumeroMoto.Text.Trim();
                usuarios[selectedRow].Telefono = txtTelefono.Text.Trim();
                dataGridViewUsuarios.Refresh();
                GuardarUsuarios();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selectedRow >= 0 && selectedRow < usuarios.Count)
            {
                usuarios.RemoveAt(selectedRow);
                GuardarUsuarios();
                LimpiarCampos();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dataGridViewUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count > 0)
            {
                selectedRow = dataGridViewUsuarios.SelectedRows[0].Index;
                var usuario = usuarios[selectedRow];
                txtNombre.Text = usuario.Nombre;
                txtNumeroMoto.Text = usuario.NumeroMoto;
                txtTelefono.Text = usuario.Telefono;
            }
            else
            {
                selectedRow = -1;
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtNumeroMoto.Clear();
            txtTelefono.Clear();
            selectedRow = -1;
            dataGridViewUsuarios.ClearSelection();
        }

        private void GuardarUsuarios()
        {
            UsuarioCrudManager.GuardarUsuarios(new List<Usuario>(usuarios));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            GuardarUsuarios();
        }
    }
}
