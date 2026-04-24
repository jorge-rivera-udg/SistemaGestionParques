using ProyectoFinalDemo.common;
using ProyectoFinalDemo.modelos;
using ProyectoFinalDemo.vistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDemo
{
    public partial class Form1 : Form
    {
        private AdministradorForm adminForm;
        private Sesion sesion;
        private Login login;
        public Form1()
        {
            InitializeComponent();
            resetStatus();
            sesion = new Sesion();
            adminForm = new AdministradorForm("usuario");
            this.Activated += new EventHandler(check_status);
            this.Deactivate += new EventHandler(bye_for_now);
        }

        private void bye_for_now(object sender, EventArgs e)
        {
            Console.WriteLine("Form1 focus lost");
        }

        private void user_login_Click(object sender, EventArgs e)
        {
            login = new Login(sesion);
            login.Show();
        }

        private void user_logout_Click(object sender, EventArgs e)
        {
            sesion.Usuario = null;
            cerrarVentanas();
            resetStatus();
        }

        private void user_register_Click(object sender, EventArgs e)
        {
            if (adminForm.IsDisposed)
                adminForm = new AdministradorForm("usuario");
            adminForm.Show();
        }

        private void check_status(object sender, EventArgs e)
        {
            Console.WriteLine($"Usuario en ventana principal: {sesion.Usuario}");
            if(sesion.Usuario != null)
            {
                DateTime timeout = sesion.Inicio;
                if(sesion.Usuario!=null)
                {
                    habilitar_funciones(sesion.Usuario.Rol);
                }
                if (sesion.Inicio > timeout.AddMinutes(20))
                {
                    MessageBox.Show("La sesion expiro, vuelva a iniciar");
                    cerrarVentanas();
                    habilitar_funciones("usuario");
                    resetStatus();
                }
            }
        }

        private void habilitar_funciones(string rol)
        {
            string[] power_users = { "ADMIN", "SUPER", "CONSULTOR" };
            Console.WriteLine($"Rol recibido: {rol}");

            if (power_users.Contains(rol)) {
                Console.WriteLine("super usuario");
                menuAdmin.Enabled = true;

            }
            menuActividades.Enabled = true;
            menuReportes.Enabled = true;
            menuParques.Enabled = true;
            if (sesion.Usuario != null)
            {
                user_login.Enabled = false;
                user_logout.Enabled = true;
                user_register.Enabled = false;
            }

        }

        private void cerrarVentanas()
        {

        }

        private void resetStatus()
        {
            user_login.Enabled = true;
            user_logout.Enabled = false;
            user_register.Enabled = true;
            menuAdmin.Enabled = false;
            menuActividades.Enabled = false;
            menuReportes.Enabled = false;
            menuParques.Enabled = false;
        }
}
}
