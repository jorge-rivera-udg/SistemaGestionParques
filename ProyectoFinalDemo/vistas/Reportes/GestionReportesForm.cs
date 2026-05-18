using Org.BouncyCastle.Utilities.Collections;
using ProyectoFinalDemo.common;
using ProyectoFinalDemo.controladores;
using ProyectoFinalDemo.utils;
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

namespace ProyectoFinalDemo.vistas.Reportes
{
    public partial class GestionReportesForm : Form
    {
        /**
         * Formulario para la gestión de reportes. Actualmente es un placeholder sin funcionalidad específica.
         * Se pueden agregar métodos y controles para generar y visualizar diferentes tipos de reportes relacionados con parques, actividades, usuarios, etc.
         * Este formulario puede ser accedido desde el menú principal o desde otras partes de la aplicación donde se requiera mostrar reportes.
         * 	id int auto_increment primary key,
            descripcion longtext not null,
            fecha datetime,
            estado int not null,
            usuario varchar(30) not null,
            parque int not null,
            categoria int not null,
         */
        Sesion sesion;
        string vista;
        List<int> imageListReporte;
        FotoDisplayForm fotoDisplay;
        FotoController fctrlr;
        EstadoController ectrlr;
        ParqueController pctrlr;
        ReporteController rctrlr;
        CategoriaController cctrlr;

        public GestionReportesForm()
        {
            InitializeComponent();
        }

        public GestionReportesForm(Sesion s, string vista)
        {
            InitializeComponent();
            sesion = s;
            this.vista = vista;
            imageListReporte = new List<int>();
            fctrlr = new FotoController();
            ectrlr = new EstadoController();
            pctrlr = new ParqueController();
            rctrlr = new ReporteController();
            cctrlr = new CategoriaController();
            inicializarCombos();
            actualizarReportes();
        }

        private void habilitarControles(string usuario)
        {
            // Aquí se implementaría la lógica para habilitar o deshabilitar controles en el formulario según el rol del usuario o el estado de la sesión.
            // Por ejemplo, podrías habilitar ciertos botones solo para usuarios con roles específicos o deshabilitar controles si la sesión no es válida.
            if (sesion != null && sesion.Usuario != null && 
                (sesion.Usuario.Usuario == usuario || sesion.Usuario.Rol == Constantes.ROL_ADMIN))
            {
                btnSaveRep.Enabled = true;      // Habilitar, el usuario tiene permiso para guardar/actualizar sus reportes.
                btnDeleteRep.Enabled = true;    // Habilitar, el usuario tiene permiso para eliminar sus reportes.
                btnLoadPic.Enabled = true;      // Habilitar, el usuario tiene permiso para cargar sus imágenes.
                btnSavePic.Enabled = true;      // Habilitar, el usuario tiene permiso para guardar sus imágenes.
            }
            else
            {
                btnSaveRep.Enabled = false;     // Deshabilitar, el usuario no tiene permiso para guardar reportes.
                btnDeleteRep.Enabled = false;   // Deshabilitar, el usuario no tiene permiso para eliminar reportes.
                btnLoadPic.Enabled = false;     // Deshabilitar, el usuario no tiene permiso para cargar imágenes.
                btnSavePic.Enabled = false;     // Deshabilitar, el usuario no tiene permiso para guardar imágenes.
            }
            if(sesion != null && sesion.Usuario != null && sesion.Usuario.Rol != Constantes.ROL_ADMIN)
            {
                cmbEstado.Enabled = false;
            }
        }

        private void actualizarReportes()
        {
            dgvListaReportes.Columns.Clear(); // Limpiar columnas para personalizar la visualización.
            dgvListaReportes.DataSource = string.IsNullOrEmpty(vista)?rctrlr.ObtenerTodos():rctrlr.ObtenerReportesPorUsuario(sesion.Usuario.Usuario);
            dgvListaReportes.Columns["Id"].Visible = false; // Ocultar la columna de ID.
            dgvListaReportes.Columns["Descripcion"].HeaderText = "Descripción";
            dgvListaReportes.Columns["Fecha"].HeaderText = "Fecha";
            dgvListaReportes.Columns["Estado"].Visible = false; // Ocultar la columna de estado.
            dgvListaReportes.Columns["Usuario"].Visible = false; // Ocultar la columna de usuario.
            dgvListaReportes.Columns["Parque"].HeaderText = "Parque";
            dgvListaReportes.Columns["Categoria"].HeaderText = "Categoría";
        }

        private void inicializarCombos()
        {
            // Por ejemplo:
            cmbEstado.DataSource = ectrlr.ObtenerTodos();
            cmbEstado.DisplayMember = "Nombre";
            cmbEstado.ValueMember = "Id";
            cmbParque.DataSource = pctrlr.ObtenerTodos();
            cmbParque.DisplayMember = "Nombre";
            cmbParque.ValueMember = "Id";
            cmbCategoria.DataSource = cctrlr.ObtenerTodos();
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id";
        }

        private void dgvListaReportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int reporteId = Convert.ToInt32(dgvListaReportes.Rows[e.RowIndex].Cells["Id"].Value);
                string usuario = dgvListaReportes.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();

                lblReporteId.Text = dgvListaReportes.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtDescripcion.Text = dgvListaReportes.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                dtFecha.Value = Convert.ToDateTime(dgvListaReportes.Rows[e.RowIndex].Cells["Fecha"].Value);
                cmbEstado.SelectedValue = dgvListaReportes.Rows[e.RowIndex].Cells["Estado"].Value;
                cmbParque.SelectedValue = dgvListaReportes.Rows[e.RowIndex].Cells["Parque"].Value;
                cmbCategoria.SelectedValue = dgvListaReportes.Rows[e.RowIndex].Cells["Categoria"].Value;
                cargarImagenesPorReporte(reporteId);
                habilitarControles(usuario);
                soloLectura(usuario);
            }
        }

        private void picList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picList.SelectedIndices.Count > 0)
            {
                int id = Convert.ToInt32(picList.SelectedItems[0].Text.Split('-')[0].Trim());
                if (id >= 0 && id < imageListReporte.Count)
                {
                    abrirFotoDisplayForm(imageListReporte[id]);
                }
            }
        }

        private void cargarImagenesPorReporte(int reporteId)
        {
            // Aquí se implementaría la lógica para cargar las imágenes asociadas a un reporte específico.
            // Por ejemplo, podrías obtener las imágenes desde el ReporteController y mostrarlas en un ListView o PictureBox.
            imageListReporte.Clear();
            picList.Items.Clear();
            if (reporteId > 0)
            {
                fctrlr.ObtenerImagenesPorFuente(reporteId, Constantes.FUENTE_REPORTES).ForEach(foto =>
                {
                    imageListReporte.Add(foto.Id);
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = imageListReporte.Count - 1;
                    item.Text = item.ImageIndex + " - " + foto.Fuente + " - " + reporteId;
                    picList.Items.Add(item);
                });
            }
        }

        private void abrirFotoDisplayForm(int id)
        {
            fotoDisplay = new FotoDisplayForm(id);
            fotoDisplay.ShowDialog();
        }

        private void btnCleanRep_Click(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
            dtFecha.Value = DateTime.Now;
            cmbEstado.SelectedIndex = -1;
            cmbParque.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;
            lblReporteId.Text = "";
        }

        private void soloLectura(string usuario)
        {
            if (usuario != sesion.Usuario.Usuario)
            {
                txtDescripcion.Enabled = false;
                dtFecha.Enabled = false;
                cmbEstado.Enabled = false;
                cmbParque.Enabled = false;
                cmbCategoria.Enabled = false;
                lblReporteId.Enabled = false;
            } else
            {
                txtDescripcion.Enabled = true;
                dtFecha.Enabled = true;
                cmbEstado.Enabled = true;
                cmbParque.Enabled = true;
                cmbCategoria.Enabled = true;
                lblReporteId.Enabled = true;
            }

            if("entregado".Equals(cmbEstado.SelectedText, StringComparison.OrdinalIgnoreCase))
            {
                cmbEstado.Enabled = false; // Solo el admin puede cambiar el estado del reporte.
                cmbEstado.Enabled = false;
                cmbParque.Enabled = false;
                cmbCategoria.Enabled = false;
            }
        }

        private void bntDeleteRep_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(lblReporteId.Text))
            {
                MessageBox.Show("Seleccione un reporte para eliminar.");
                return;
            } else
            {
                int reporteId = Convert.ToInt32(lblReporteId.Text);
                if (MessageBox.Show("¿Está seguro de que desea eliminar este reporte?", "Confirmar eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    fctrlr.BorrarPorFuente(reporteId, Constantes.FUENTE_REPORTES); // Eliminar imágenes asociadas al reporte
                    rctrlr.Eliminar(reporteId);
                    actualizarReportes();
                    btnCleanRep_Click(sender, e); // Limpiar campos después de eliminar
                }
            }
        }

        private void btnLoadPic_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btnSavePic_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(lblReporteId.Text))
            {
                MessageBox.Show("Seleccione un reporte para asociar la imagen.");
                return;
            }
            if(fctrlr.Insertar(new Foto
            {
                Usuario = sesion.Usuario.Usuario,
                FuenteId = Convert.ToInt32(lblReporteId.Text),
                Fuente = Constantes.FUENTE_REPORTES,
                Imagen = pictureBox.Image
            }))
            {
                cargarImagenesPorReporte(Convert.ToInt32(lblReporteId.Text)); // Recargar imágenes después de guardar
            }
        }

        private void btnSaveRep_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtDescripcion.Text) || cmbParque.SelectedIndex == -1 || cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            } else
            {
                Reporte rep = new Reporte
                {
                    Descripcion = txtDescripcion.Text,
                    Fecha = dtFecha.Value,
                    Estado = (int)cmbEstado.SelectedValue,
                    Usuario = sesion.Usuario.Usuario,
                    Parque = (int)cmbParque.SelectedValue,
                    Categoria = (int)cmbCategoria.SelectedValue
                };
                if(string.IsNullOrEmpty(lblReporteId.Text))
                {
                    rctrlr.Insertar(rep);
                    btnCleanRep_Click(sender, e); // Limpiar campos después de guardar
                }
                else
                {
                    rep.Id = Convert.ToInt32(lblReporteId.Text);
                    rctrlr.Actualizar(rep);
                    btnCleanRep_Click(sender, e); // Limpiar campos después de guardar
                }
                actualizarReportes();
            }
        }
    }
}
