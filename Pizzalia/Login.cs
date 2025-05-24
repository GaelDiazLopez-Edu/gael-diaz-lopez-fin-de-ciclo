using System;
using System.Linq;
using System.Windows.Forms;

namespace Pizzalia
{
    public partial class Login : Form
    {
        public event EventHandler LoginSuccess;

        public string RepartidorSeleccionado { get; private set; }

        public Login()
        {
            InitializeComponent();
            labelContrase�a.Visible = false;
            inputContra.Visible = false;
            comboBoxRepartidor.Visible = false;
            labelRepartidor.Visible = false;
        }

        private void comboBoxLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccionado = comboBoxLogin.SelectedItem?.ToString() ?? "";

            if (seleccionado == "Administrador")
            {
                labelContrase�a.Visible = true;
                inputContra.Visible = true;
                inputContra.PasswordChar = '*'; // <-- Aqu� ocultas la contrase�a
                comboBoxRepartidor.Visible = false;
                labelRepartidor.Visible = false;
            }
            else if (seleccionado == "Empleado/Camarero")
            {
                labelContrase�a.Visible = false;
                inputContra.Visible = false;
                comboBoxRepartidor.Visible = false;
                labelRepartidor.Visible = false;
            }
            else if (seleccionado == "Repartidor")
            {
                labelContrase�a.Visible = false;
                inputContra.Visible = false;
                comboBoxRepartidor.Visible = true;
                labelRepartidor.Visible = true;

                // Rellenar ComboBox de repartidores
                comboBoxRepartidor.Items.Clear();
                foreach (var usuario in UsuarioCrudManager.CargarUsuarios())
                {
                    comboBoxRepartidor.Items.Add(usuario.Nombre);
                }
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            string seleccionado = comboBoxLogin.SelectedItem?.ToString() ?? "";

            if (seleccionado == "Administrador")
            {
                if (UsuarioManager.ValidarAdministrador(inputContra.Text))
                {
                    LoginSuccess?.Invoke(this, EventArgs.Empty);
                    return;
                }
                else
                {
                    MessageBox.Show("Contrase�a incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inputContra.Clear();
                    inputContra.Focus();
                }
            }
            else if (seleccionado == "Repartidor")
            {
                string repartidor = comboBoxRepartidor.SelectedItem?.ToString() ?? "";
                if (string.IsNullOrWhiteSpace(repartidor))
                {
                    MessageBox.Show("Seleccione un repartidor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Solo validamos que el repartidor existe en la lista
                var existe = UsuarioCrudManager.CargarUsuarios().Any(u => u.Nombre == repartidor);
                if (existe)
                {
                    RepartidorSeleccionado = repartidor; // <-- Guardamos el nombre seleccionado
                    LoginSuccess?.Invoke(this, EventArgs.Empty); // Lanzamos el evento de login exitoso
                    return;
                }
                else
                {
                    MessageBox.Show("Repartidor no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (seleccionado == "Empleado/Camarero")
            {
                // Aqu� podr�as lanzar el evento de login para camarero si lo necesitas
                LoginSuccess?.Invoke(this, EventArgs.Empty);
                return;
            }
            else
            {
                MessageBox.Show("Seleccione un usuario v�lido o complete los campos requeridos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
