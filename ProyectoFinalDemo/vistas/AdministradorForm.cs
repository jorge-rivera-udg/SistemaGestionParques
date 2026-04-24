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
    public partial class AdministradorForm : Form
    {
        private string tipo_usuario;
        private Administrador admin;
        private List<Administrador> lista;
        private AdministradorController adminController;
        public AdministradorForm(string u)
        {
            adminController = new AdministradorController();
            InitializeComponent();
            tipo_usuario = u;
            resetCampos();
            if (u.ToUpper() == "usuario")
            {
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                listaUsuarios.Visible = false;
            }
            if (u.ToLower() == "admin")
            {
                listaUsuarios.Visible = true;
            }
            cargarUsuarios();
        }

        private void cargarUsuarios()
        {
            listaUsuarios.Rows.Clear();
            lista = adminController.obtenerTodos();
            foreach (Administrador item in lista)
            {
                listaUsuarios.Rows.Add(item.Id, item.Nombres, item.Apellidos, item.Email, item.Usuario, item.Rol);
            }
            
        }

        private void btnAvatar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(comboBox2.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena2.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(dtpFdn.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!txtContrasena.Text.Equals(txtContrasena2.Text))
            {
                MessageBox.Show("Las contrasenas no coinciden", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void resetCampos()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            comboBox1.Text = "USUARIO";
            comboBox2.Text = "INACTIVO";
            txtContrasena.Clear();
            txtContrasena2.Clear();
            txtUsuario.Clear();
            dtpFdn.Value = DateTime.Now;
            pictureBox1.Image = null;
        }

        private void cargarModelo()
        {
            admin = new Administrador();
            admin.Nombres = txtNombres.Text;
            admin.Apellidos = txtApellidos.Text;
            admin.Email = txtEmail.Text;
            admin.Telefono = txtTelefono.Text;
            admin.Estado = comboBox2.SelectedItem != null ? comboBox2.SelectedItem.ToString() : "";
            admin.Rol = comboBox1.SelectedItem != null ? comboBox1.SelectedItem.ToString() : "";
            admin.Contrasena = txtContrasena.Text;
            admin.Creado_en = DateTime.Now;
            admin.Actualizado_en = DateTime.Now;
            admin.Fdn = dtpFdn.Value;
            admin.Usuario = txtUsuario.Text;
            //Console.WriteLine($"Usuario a guardar: {admin}");
            //Console.WriteLine($"Rol: {admin.Rol}, estado: {admin.Estado}");
            if (pictureBox1.Image != null)
            {
                admin.Avatar = pictureBox1.Image;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                cargarModelo();
                if (adminController.insertar(admin))
                {
                    resetCampos();
                }
                if (tipo_usuario == "usuario")
                {
                    this.Dispose();
                }

            }
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                cargarModelo();
                if (adminController.actualizar(admin))
                {
                    resetCampos();
                }
            }
        }

        private void listaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = listaUsuarios.Rows[e.RowIndex];
                if (row.Cells[0].Value != null)
                {
                    try
                    {
                        int id = Int32.Parse(row.Cells[0].Value.ToString());
                        foreach (Administrador item in lista)
                        {
                            if (item.Id == id)
                            {
                                try
                                {
                                    lblId.Text = item.Id.ToString();
                                    txtNombres.Text = item.Nombres;
                                    txtApellidos.Text = item.Apellidos;
                                    txtContrasena.Text = item.Contrasena;
                                    txtUsuario.Text = item.Usuario;
                                    txtEmail.Text = item.Email;
                                    txtTelefono.Text = item.Telefono;
                                    dtpFdn.Value = item.Fdn;
                                    comboBox1.Text = item.Rol;
                                    comboBox2.Text = item.Estado;
                                    if (item.Avatar != null)
                                    {
                                        pictureBox1.Image = item.Avatar;
                                    }
                                } catch(NullReferenceException nre)
                                {
                                    MessageBox.Show($"Error parsing user: {nre.Message}");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error cargando datos de usuario: {ex.Message}");
                    }
                }
            }
        }
    }
}
