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
            usuariosForm.StartPosition = FormStartPosition.CenterScreen; // Para centrar la ventana, esto es opcional pero queda mejor
            usuariosForm.ShowDialog(); //Espera a que se cierre UsuariosForm para volver a Administracion
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Articulos articulosForm = new Articulos();
            articulosForm.StartPosition = FormStartPosition.CenterScreen;
            articulosForm.ShowDialog(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inventario inventarioForm = new Inventario();
            inventarioForm.StartPosition = FormStartPosition.CenterScreen;
            inventarioForm.ShowDialog();
        }
    }
}
