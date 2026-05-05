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
        private CategoriaController cCtrlr;
        private ParqueController pCtrlr;
        private FotoController fCtrlr;
        public GestionParquesForm(Sesion s)
        {
            sesion = s;
            pCtrlr = new ParqueController();
            cCtrlr = new CategoriaController();
            InitializeComponent();
            inicializarDatos();
            inicializarListaParques();
            cargarCategorias();
        }

        private void cargarCategorias()
        {
            List<Categoria> categorias = cCtrlr.ObtenerTodos();
            // Assuming you have a ComboBox named cmbCategorias
            cmbCategorias.Items.Clear();
            categorias.ForEach(categoria =>
            {
                cmbCategorias.Items.Add(new { Text = categoria.Nombre, Value = categoria.Id });
            });
            cmbCategorias.DisplayMember = "Text";
            cmbCategorias.ValueMember = "Value";
        }

        private void inicializarDatos()
        {
            fotosPorParque = new Dictionary<int, List<Foto>>();
            sesion.Parques = pCtrlr.ObtenerTodos();
            sesion.Parques.ForEach(parque =>
            {
                fotosPorParque[parque.Id] = fCtrlr.ObtenerImagenesPorFuente(parque.Id, Constantes.FUENTE_PARQUE);
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
            imageList1.Images.Clear();
            curParFotoList.Items.Clear();
            if (fotosPorParque.ContainsKey(parqueId))
            {
                fotosPorParque[parqueId].ForEach(foto =>
                {
                    imageList1.Images.Add(foto.Imagen);
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = imageList1.Images.Count - 1;
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
                        txtNombre.Text = cur.Nombre;
                        txtUbicacion.Text = cur.Ubicacion;
                        cmbCategorias.SelectedValue = cur.Condicion; // Assuming Condicion is the category ID
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
                    cargaFotosParque(pic.FuenteId);
                    isNewFoto = false;
                }
            }
        }
    }
}
