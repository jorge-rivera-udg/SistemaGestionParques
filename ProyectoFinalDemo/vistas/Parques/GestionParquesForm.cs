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

namespace ProyectoFinalDemo.vistas.Parques
{
    public partial class GestionParquesForm : Form
    {
        private Dictionary<int, List<Foto>> fotosPorParque;
        private Sesion sesion;
        private bool isNewFoto = false;
        private CondicionController cCtrlr;
        private ParqueController pCtrlr;
        private FotoController fCtrlr;
        private Form fotoDisplay;
        private List<int> imageList1;
        public GestionParquesForm(Sesion s)
        {
            sesion = s;
            pCtrlr = new ParqueController();
            cCtrlr = new CondicionController();
            fCtrlr = new FotoController();
            InitializeComponent();
            inicializarDatos();
            inicializarListaParques();
            cargarCondiciones();
            imageList1 = new List<int>();
            Console.WriteLine($"Usuario en sesión: {(sesion.Usuario != null ? sesion.Usuario.Usuario : "Ninguno")}, Rol: {(sesion.Usuario != null ? sesion.Usuario.Rol : "N/A")}");
            if (sesion.Usuario != null && Constantes.ROL_USUARIO.Equals(sesion.Usuario.Rol))
            {
                btnSaveParque.Visible = false;
                txtUbicacion.Enabled= false;
                txtNombre.Enabled = false;
                cmbCategorias.Enabled = false;
            }
        }

        private bool verificaCampos()
        {
            if(string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtUbicacion.Text) || cmbCategorias.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return false;
            }
            return true;
        }

        private void cargarCondiciones()
        {
            List<Condicion> condiciones = cCtrlr.ObtenerTodos();
            // Assuming you have a ComboBox named cmbCategorias
            cmbCategorias.Items.Clear();
            cmbCategorias.DataSource = condiciones;
            cmbCategorias.DisplayMember = "Nombre";
            cmbCategorias.ValueMember = "Id";
        }

        private void inicializarDatos()
        {
            fotosPorParque = new Dictionary<int, List<Foto>>();
            sesion.Parques = pCtrlr.ObtenerTodos();
            sesion.Parques.ForEach(parque =>
            {
                fotosPorParque.Add(parque.Id, fCtrlr.ObtenerImagenesPorFuente(parque.Id, Constantes.FUENTE_PARQUE) );
            });
        }

        private void cargaFotosParquePorId(int parqueId)
        {
            List<Foto> fotos = fCtrlr.ObtenerImagenesPorFuente(parqueId, Constantes.FUENTE_PARQUE);
            imageList1.Clear();
            Console.WriteLine($"Conteo de imagenes en lista de imagenes: {imageList1.Count}");
            curParFotoList.Items.Clear();
            Console.WriteLine($"Cargando fotos para el parque ID: {parqueId}, cantidad de fotos: {fotos.Count}");
            fotosPorParque.Remove(parqueId);
            fotosPorParque.Add(parqueId, fotos);
            fotos.ForEach(foto =>
            {
                imageList1.Add(foto.Id);
                ListViewItem item = new ListViewItem();
                item.ImageIndex = imageList1.Count - 1;
                item.Text = item.ImageIndex + " - " + foto.Usuario+" - " + foto.Fuente;
                curParFotoList.Items.Add(item);
            });
        }

        private void inicializarListaParques()
        {
            dgvParques.Rows.Clear();
            sesion.Parques.ForEach(parque =>
            {
                dgvParques.Rows.Add(parque.Id, parque.Nombre, parque.Ubicacion);
            });
        }

        private void cargaFotosParque(int parqueId)
        {
            imageList1.Clear();
            curParFotoList.Items.Clear();
            if (fotosPorParque.ContainsKey(parqueId))
            {
                fotosPorParque[parqueId].ForEach(foto =>
                {
                    imageList1.Add(foto.Id);
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = imageList1.Count - 1;
                    item.Text = item.ImageIndex +" - " + foto.Usuario+" - " + foto.Fuente;
                    curParFotoList.Items.Add(item);
                });
            }
        }

        private void dgvParques_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                // Your code to handle the cell click event
                try
                {
                    int id = Convert.ToInt32(dgvParques.Rows[e.RowIndex].Cells["Parque_Id"].Value);
                    Parque cur = sesion.Parques.Find(parque => parque.Id == id);
                    if(cur != null)
                    {
                        cargaFotosParque(cur.Id);
                        lblParqueId.Text = cur.Id.ToString();
                        txtNombre.Text = cur.Nombre;
                        txtUbicacion.Text = cur.Ubicacion;
                        cmbCategorias.SelectedValue = cur.Condicion; // Assuming Condicion is the category ID
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MessageBox.Show("Parque no encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el ID del parque: " + ex.Message);
                }
            }
        }

        private void loadImage_Click(object sender, EventArgs e)
        {
            isNewFoto = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void saveImage_Click(object sender, EventArgs e)
        {
            if(isNewFoto && !string.IsNullOrEmpty(lblParqueId.Text))
            {
                Foto pic = new Foto
                {
                    Imagen = pictureBox1.Image,
                    Fuente = Constantes.FUENTE_PARQUE,
                    FuenteId = Convert.ToInt32(lblParqueId.Text),
                    Usuario = sesion.Usuario.Usuario
                };
                if(fCtrlr.Insertar(pic))
                {
                    cargaFotosParquePorId(Convert.ToInt32(lblParqueId.Text));
                    isNewFoto = false;
                }
            }
        }

        private void btnLimpiarDatos_Click(object sender, EventArgs e)
        {
            lblParqueId.Text = "";
            txtNombre.Text = "";
            txtUbicacion.Text = "";
            cmbCategorias.SelectedIndex = -1;
            imageList1.Clear();
            curParFotoList.Items.Clear();
            pictureBox1.Image = null;
        }

        private void btnSaveParque_Click(object sender, EventArgs e)
        {
            if (verificaCampos())
            {
                Parque parque = new Parque
                {
                    Nombre = txtNombre.Text,
                    Ubicacion = txtUbicacion.Text,
                    Condicion = Convert.ToInt32(cmbCategorias.SelectedValue)
                };
                bool result = string.IsNullOrWhiteSpace(lblParqueId.Text) ? pCtrlr.Insertar(parque) : pCtrlr.Actualizar(parque);

                if (result)
                {
                    MessageBox.Show("Parque guardado exitosamente.");
                    inicializarDatos();
                    inicializarListaParques();
                }
                else
                {
                    MessageBox.Show("Error al guardar el parque.");
                }
            }
        }

        private void curParFotoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (curParFotoList.SelectedIndices.Count > 0)
            {
                int id = Convert.ToInt32(curParFotoList.SelectedItems[0].Text.Split('-')[0].Trim());
                if (id >= 0 && id < imageList1.Count)
                {
                    abrirFotoDisplayForm(imageList1[id]);
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
