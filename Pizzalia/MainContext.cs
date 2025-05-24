using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pizzalia
{
    public class MainContext : ApplicationContext
    {
        private Point? lastLocation = null;

        public MainContext()
        {
            AbrirLogin();
        }

        private void AbrirLogin()
        {
            var login = new Login();
            if (lastLocation.HasValue)
            {
                login.StartPosition = FormStartPosition.Manual;
                login.Location = lastLocation.Value;
            }
            login.LoginSuccess += (s, e) =>
            {
                lastLocation = login.Location;
                login.Hide();
                AbrirAdministracion();
            };
            login.FormClosed += (s, e) => ExitThread();
            login.Show();
        }

        private void AbrirAdministracion()
        {
            var admin = new Administracion();
            if (lastLocation.HasValue)
            {
                admin.StartPosition = FormStartPosition.Manual;
                admin.Location = lastLocation.Value;
            }
            admin.FormClosed += (s, e) =>
            {
                lastLocation = admin.Location;
                AbrirLogin();
            };
            admin.Show();
        }
    }
}
