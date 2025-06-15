using System;
using System.Linq;
using System.Windows.Forms;

namespace Pizzalia
{
    public partial class Login : Form
    {
        public event EventHandler LoginSuccess;


        public Login()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Login_KeyDown;

            labelContraseña.Visible = false;
            inputContra.Visible = false;
            comboBoxRepartidor.Visible = false;
            labelRepartidor.Visible = false;
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                string licencia = @"Este software es propiedad de Pizzalia. Se concede al cliente una licencia no exclusiva, intransferible y limitada, para usar el software únicamente en su negocio, bajo las siguientes condiciones:

- El cliente ha realizado el pago único por el derecho de uso.
- El mantenimiento técnico y las actualizaciones se ofrecen bajo una cuota anual renovable.
- El software no puede copiarse, compartirse, sub-licenciarse ni modificarse sin autorización expresa.
- El código fuente no se proporciona.
- Solo Pizzalia puede realizar cambios, integraciones o personalizaciones.";

                MessageBox.Show(licencia, "Licencia de uso - Pizzalia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.SuppressKeyPress = true;
            }
        }

        private void comboBoxLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccionado = comboBoxLogin.SelectedItem?.ToString() ?? "";

            if (seleccionado == "Administrador")
            {
                labelContraseña.Visible = true;
                inputContra.Visible = true;
                inputContra.PasswordChar = '*';
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
                    this.Hide(); // Oculta el login
                    Administracion adminForm = new Administracion();
                    adminForm.ShowDialog();
                    this.Show(); // Vuelve a mostrar el login después de cerrar Administracion
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

                var existe = UsuarioCrudManager.CargarUsuarios().Any(u => u.Nombre == repartidor);
                if (existe)
                {
                    this.Hide(); // Oculta el login
                    MotoristaPedidosForm form = new MotoristaPedidosForm(repartidor);
                    form.ShowDialog();
                    this.Show(); // Vuelve a mostrar el login al cerrar el formulario
                }
                else
                {
                    MessageBox.Show("Repartidor no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (seleccionado == "Empleado/Camarero")
            {
                this.Hide(); // Oculta el login
                SeleccionTipoDePedidoForm tipoPedidoForm = new SeleccionTipoDePedidoForm();
                tipoPedidoForm.ShowDialog(); // Abre el formulario de empleados
                this.Show(); // Vuelve a mostrar el login al cerrar el formulario
            }
            else
            {
                MessageBox.Show("Seleccione un usuario válido o complete los campos requeridos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
