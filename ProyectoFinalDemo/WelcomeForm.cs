using ProyectoFinalDemo.common;
using ProyectoFinalDemo.modelos;
using ProyectoFinalDemo.vistas;
using ProyectoFinalDemo.vistas.Actividades;
using ProyectoFinalDemo.vistas.Parques;
using ProyectoFinalDemo.vistas.Reportes;
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
    public partial class WelcomeForm : Form
    {
        private GestionUsuarioForm usersForm;
        private GestionCatalogosForm catalogosForm;
        private GestionParquesForm parquesForm;
        private GestionActividadesForm actividadesForm;
        private GestionReportesForm reportesForm;
        private Sesion sesion;
        private Login login;
        public WelcomeForm()
        {
            InitializeComponent();
            resetStatus();
            sesion = new Sesion();
            //usersForm = new GestionUsuarioForm("usuario");
            //catalogosForm = new GestionCatalogosForm();
            //parquesForm = new GestionParquesForm(sesion);
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
            usersForm = new GestionUsuarioForm("usuario");
            usersForm.Show();
        }

        private void check_status(object sender, EventArgs e)
        {
            Console.WriteLine($"Usuario en ventana principal: {sesion.Usuario}");
            if (sesion.Usuario != null)
            {
                DateTime timeout = sesion.Inicio;
                if (sesion.Usuario != null)
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

            if (power_users.Contains(rol))
            {
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

        private void admin_catalogos_Click(object sender, EventArgs e)
        {
            if (catalogosForm == null || catalogosForm.IsDisposed)
            {
                catalogosForm = new GestionCatalogosForm();
            }
            catalogosForm.Show();
        }

        private void admin_users_Click(object sender, EventArgs e)
        {
            usersForm = new GestionUsuarioForm("admin");
            usersForm.Show();
        }

        private void abrirFormularioParques()
        {
            if (parquesForm == null || parquesForm.IsDisposed)
            {
                parquesForm = new GestionParquesForm(sesion);
            }
            parquesForm.Show();
        }

        private void listadoParques_Click(object sender, EventArgs e)
        {
            abrirFormularioParques();
        }

        private void admin_parques_Click(object sender, EventArgs e)
        {
            abrirFormularioParques();
        }

        private void admin_actividades_Click(object sender, EventArgs e)
        {
            abrirFormularioActividades(null);
        }

        private void admin_reportes_Click(object sender, EventArgs e)
        {
            abrirFormularioReportes(null);
        }

        private void listadoActividades_Click(object sender, EventArgs e)
        {
            abrirFormularioActividades(null);
        }

        private void misActividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormularioActividades("mis");
        }

        private void abrirFormularioActividades(string vista)
        {
            if (actividadesForm == null || actividadesForm.IsDisposed)
            {
                actividadesForm = new GestionActividadesForm(sesion, vista);
            }
            actividadesForm.Show();
        }

        private void misReportes_Click(object sender, EventArgs e)
        {
            abrirFormularioReportes("mis");
        }

        private void listadoReportes_Click(object sender, EventArgs e)
        {
            abrirFormularioReportes(null);
        }

        private void abrirFormularioReportes(string vista)
        {
            if (reportesForm == null || reportesForm.IsDisposed)
            {
                reportesForm = new GestionReportesForm(sesion, vista);
            }
            reportesForm.Show();
        }
    }
}
