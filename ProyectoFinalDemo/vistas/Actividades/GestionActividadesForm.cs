using MySqlX.XDevAPI;
using ProyectoFinalDemo.common;
using ProyectoFinalDemo.controladores;
using ProyectoFinalDemo.modelos;
using ProyectoFinalDemo.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDemo.vistas.Actividades
{
    public partial class GestionActividadesForm : Form
    {
        private Sesion sesion;
        private string vista;
        private FotoDisplayForm fotoDisplay;
        private FotoController fctrlr;
        private ActividadController actCtrlr;
        private ParqueController parqueCtrlr;
        private CategoriaController catCtrlr;
        private ParticipacionController partCtrlr;
        private List<int> imageList;
        private List<Parque> parques;
        private List<Actividad> actividades;
        private List<Categoria> categorias;

        public GestionActividadesForm(Sesion s, string vista)
        {
            sesion = s;
            this.vista = vista;
            InitializeComponent();
            imageList = new List<int>();
            fctrlr = new FotoController();
            actCtrlr = new ActividadController();
            parqueCtrlr = new ParqueController();
            catCtrlr = new CategoriaController();
            partCtrlr = new ParticipacionController();
            categorias = catCtrlr.ObtenerTodos();
            parques = parqueCtrlr.ObtenerTodos();
            cmbParque.DataSource = parques;
            cmbParque.ValueMember = "Id";
            cmbParque.DisplayMember = "Nombre";
            cmbCategoria.DataSource = categorias;
            cmbCategoria.ValueMember = "Id";
            cmbCategoria.DisplayMember = "Nombre";
            if (sesion.Usuario != null && Constantes.ROL_USUARIO.Equals(sesion.Usuario.Rol))
            {
                btnSave.Visible = false;
                btnDelete.Visible = false;
                txtDescripcion.Enabled = false;
                txtNombre.Enabled = false;
                dtFecha.Enabled = false;
                cmbParque.Enabled = false;
                cmbCategoria.Enabled = false;
            }
            inicializarDatos(vista);
            if(!string.IsNullOrEmpty(vista))
            {
                btnUserAdd.Visible = false;
            }
        }

        private void cargaImagenesPorActividad(int actividadId)
        {
            imageList.Clear();
            picSelector.Items.Clear();
            if (actividadId > 0)
            {
                fctrlr.ObtenerImagenesPorFuente(actividadId, Constantes.FUENTE_ACTIVIDADES).ForEach(foto =>
                {
                    imageList.Add(foto.Id);
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = imageList.Count - 1;
                    item.Text = item.ImageIndex + " - " + foto.Usuario + " - " + foto.Fuente;
                    picSelector.Items.Add(item);
                });
            }
        }

        private void inicializarDatos(string vista)
        {
            dgvActividades.DataSource = null;
            actividades = string.IsNullOrEmpty(vista)?actCtrlr.ObtenerTodas():actCtrlr.ObtenerPorUsuario(sesion.Usuario.Usuario);
            dgvActividades.DataSource = actividades.Select(a => new
            {
                a.Id,
                a.Nombre,
                a.Fecha,
                Parque = parques.FirstOrDefault(p => p.Id == a.Parque)?.Nombre ?? "N/A",
                Categoria = categorias.FirstOrDefault(c => c.Id == a.Categoria)?.Nombre ?? "N/A",
            }).ToList();
        }

        private void dgvActividades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                int actividadId = Convert.ToInt32(dgvActividades.Rows[e.RowIndex].Cells["Id"].Value);
                Actividad selectedActividad = actividades.FirstOrDefault(a => a.Id == actividadId);
                if(selectedActividad != null)
                {
                    cargaImagenesPorActividad(actividadId);
                    txtNombre.Text = selectedActividad.Nombre;
                    txtDescripcion.Text = selectedActividad.Descripcion;
                    cmbCategoria.SelectedValue = selectedActividad.Categoria;
                    cmbParque.SelectedValue = selectedActividad.Parque;
                    lblActividadId.Text = selectedActividad.Id.ToString();
                    dtFecha.Value = selectedActividad.Fecha;
                }
            }
        }

        private void btnLoadPic_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(openFileDialog1.FileName);
                previewPic.Image = image;
            }
        }

        private void btnSavePic_Click(object sender, EventArgs e)
        {
            if(previewPic.Image != null && !string.IsNullOrEmpty(lblActividadId.Text))
            {
                int actividadId = Convert.ToInt32(lblActividadId.Text);
                Foto foto = new Foto
                {
                    Usuario = sesion.Usuario.Usuario,
                    FuenteId = actividadId,
                    Fuente = Constantes.FUENTE_ACTIVIDADES,
                    Imagen = previewPic.Image
                };
                fctrlr.Insertar(foto);
                cargaImagenesPorActividad(actividadId);
            }
            else
            {
                MessageBox.Show("Seleccione una imagen y una actividad para guardar.");
            }
        }

        private void btnUserAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(lblActividadId.Text))
            {
                MessageBox.Show("Seleccione una actividad para agregar su participación.");
                return;
            }
            else 
            {
                partCtrlr.Insertar(new Participacion
                {
                    Usuario = sesion.Usuario.Usuario,
                    Actividad = Convert.ToInt32(lblActividadId.Text)
                });
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Actividad act = new Actividad
            {
                Nombre = txtNombre.Text,
                Fecha = dtFecha.Value,
                Descripcion = txtDescripcion.Text,
                Parque = (int)cmbParque.SelectedValue,
                Categoria = (int)cmbCategoria.SelectedValue
            };
            if (string.IsNullOrEmpty(lblActividadId.Text) ? actCtrlr.Insertar(act) : actCtrlr.Actualizar(act))
            {
                inicializarDatos(vista);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(lblActividadId.Text))
            {
                int id = Convert.ToInt32(lblActividadId.Text);
                if (actCtrlr.Eliminar(id))
                {
                    inicializarDatos(vista);
                }
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            txtNombre.Clear();
            dtFecha.Value = DateTime.Now;
            cmbParque.SelectedIndex = 0;
            cmbCategoria.SelectedIndex = 0;
            lblActividadId.Text = string.Empty;
        }

        private void picSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picSelector.SelectedIndices.Count > 0)
            {
                int id = Convert.ToInt32(picSelector.SelectedItems[0].Text.Split('-')[0].Trim());
                if (id >= 0 && id < imageList.Count)
                {
                    abrirFotoDisplayForm(imageList[id]);
                }
            }
        }

        private void abrirFotoDisplayForm(int id)
        {
            fotoDisplay = new FotoDisplayForm(id);
            fotoDisplay.ShowDialog();
        }
    }
}
