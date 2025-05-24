using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzalia
{
    public partial class CambioContra : Form
    {
        public CambioContra()
        {
            InitializeComponent();
        }

        private void btnGuardarContra_Click(object sender, EventArgs e)
        {
            string nuevaContra = txtNuevaContra.Text.Trim();
            string repetirContra = txtRepetirContra.Text.Trim();

            if (string.IsNullOrEmpty(nuevaContra) || string.IsNullOrEmpty(repetirContra))
            {
                MessageBox.Show("Por favor, complete ambos campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nuevaContra != repetirContra)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNuevaContra.Clear();
                txtRepetirContra.Clear();
                txtNuevaContra.Focus();
                return;
            }

            UsuarioManager.CambiarContraseñaAdministrador(nuevaContra);
            MessageBox.Show("¡Contraseña de administrador cambiada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
