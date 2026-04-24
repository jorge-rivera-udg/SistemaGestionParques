using ProyectoFinalDemo.common;
using ProyectoFinalDemo.controladores;
using ProyectoFinalDemo.modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDemo.vistas
{
    public partial class Login : Form
    {
        private AdministradorController admctrl = new AdministradorController();
        private Sesion sesion;

        public Login(Sesion s)
        {
            InitializeComponent();
            sesion = s;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            sesion.Usuario = admctrl.validarLogin(txtUsuario.Text,txtPassword.Text);
            Console.WriteLine($"usuario en login: {sesion.Usuario.ToString()}");
            if(sesion.Usuario == null)
            {
                MessageBox.Show("Nombre de usuario/contrasena incorrectos.");
            }
            else
            {
                MessageBox.Show($"Bienvenido {sesion.Usuario.Nombres}!!");
                this.Dispose(true);
            }
        }
    }
}
