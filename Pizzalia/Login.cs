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
            labelContraseña.Visible = false;
            inputContra.Visible = false;
            comboBoxRepartidor.Visible = false;
            labelRepartidor.Visible = false;
        }

        private void comboBoxLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccionado = comboBoxLogin.SelectedItem?.ToString() ?? "";

            if (seleccionado == "Administrador")
            {
                labelContraseña.Visible = true;
                inputContra.Visible = true;
                inputContra.PasswordChar = '*'; // <-- Aquí ocultas la contraseña
                comboBoxRepartidor.Visible = false;
                labelRepartidor.Visible = false;
            }
            else if (seleccionado == "Empleado/Camarero")
            {
                labelContraseña.Visible = false;
                inputContra.Visible = false;
                comboBoxRepartidor.Visible = false;
                labelRepartidor.Visible = false;
            }
            else if (seleccionado == "Repartidor")
            {
                labelContraseña.Visible = false;
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
                    MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Aquí podrías lanzar el evento de login para camarero si lo necesitas
                LoginSuccess?.Invoke(this, EventArgs.Empty);
                return;
            }
            else
            {
                MessageBox.Show("Seleccione un usuario válido o complete los campos requeridos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
