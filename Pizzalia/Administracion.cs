using System;
using System.Windows.Forms;

namespace Pizzalia
{
    public partial class Administracion : Form
    {
        public Administracion()
        {
            InitializeComponent();
        }

        private void volverLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Abre el formulario de cambio de contraseña como diálogo modal
            CambioContra cambioForm = new CambioContra();
            cambioForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios usuariosForm = new Usuarios();
            usuariosForm.StartPosition = FormStartPosition.CenterScreen; // Opcional, para centrar la ventana
            usuariosForm.ShowDialog(); // Modal, espera a que se cierre antes de volver a Administracion
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Articulos articulosForm = new Articulos();
            articulosForm.StartPosition = FormStartPosition.CenterScreen; // Opcional, para centrar la ventana
            articulosForm.ShowDialog(); // Modal, espera a que se cierre antes de volver a Administracion
        }
    }
}
