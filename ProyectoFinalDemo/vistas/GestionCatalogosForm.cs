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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoFinalDemo.vistas
{
    public partial class GestionCatalogosForm : Form
    {
        private CategoriaController catCtrl;
        private CondicionController condCtrl;
        private EstadoController edoCtrl;
        public GestionCatalogosForm()
        {
            InitializeComponent();
            catCtrl = new CategoriaController();
            edoCtrl = new EstadoController();
            condCtrl = new CondicionController();
            inicializarCategoria();
            inicializarCondicion();
            inicializarEstado();
        }
        private void inicializarCategoria()
        {
            dgvCats.Rows.Clear();
            foreach (Categoria item in catCtrl.ObtenerTodos())
            {
                dgvCats.Rows.Add(item.Id.ToString(), item.Nombre);
            }
        }
        private void inicializarCondicion()
        {
            dgvConds.Rows.Clear();
            foreach (Condicion item in condCtrl.ObtenerTodos())
            {
                dgvConds.Rows.Add(item.Id.ToString(), item.Nombre);
            }
        }
        private void inicializarEstado()
        {
            dgvEdos.Rows.Clear();
            foreach (Estado item in edoCtrl.ObtenerTodos())
            {
                dgvEdos.Rows.Add(item.Id.ToString(), item.Nombre);
            }
        }
        private bool validarNombre()
        {
            if(string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre no puede estar vacio");
                return false;
            }
            return true;
        }
        private void resetCampos()
        {
            txtNombre.Text = "";
            lblId.Text = "";
        }
        private void btnCatSave_Click(object sender, EventArgs e)
        {
            if (validarNombre())
            {
                Categoria cat = new Categoria();
                bool status = false;
                cat.Nombre = txtNombre.Text;
                if (!string.IsNullOrEmpty(lblId.Text))
                {
                    cat.Id = Convert.ToInt32(lblId.Text);
                    status = catCtrl.Actualizar(cat);
                }
                else
                {
                    status = catCtrl.Insertar(cat);
                }
                if (status)
                {
                    inicializarCategoria();
                    resetCampos();
                }
            }
        }
        private void btnCatDel_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(lblId.Text))
            {
                if (catCtrl.Eliminar(Convert.ToInt32(lblId.Text))){
                    inicializarCategoria();
                    resetCampos();
                }
            }
        }
        private void btnEdoSave_Click(object sender, EventArgs e)
        {
            if (validarNombre())
            {
                Estado edo = new Estado();
                bool status = false;
                edo.Nombre = txtNombre.Text;
                if (!string.IsNullOrEmpty(lblId.Text))
                {
                    edo.Id = Convert.ToInt32(lblId.Text);
                    status = edoCtrl.Actualizar(edo);
                }
                else
                {
                    status = edoCtrl.Insertar(edo);
                }
                if (status)
                {
                    inicializarEstado();
                    resetCampos();
                }
            }
        }
        private void btnEdoDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblId.Text))
            {
                if (edoCtrl.Eliminar(Convert.ToInt32(lblId.Text)))
                    inicializarEstado();
            }
        }
        private void btnCondSave_Click(object sender, EventArgs e)
        {
            if (validarNombre())
            {
                Condicion cond = new Condicion();
                bool status = false;
                cond.Nombre = txtNombre.Text;
                if (!string.IsNullOrEmpty(lblId.Text))
                {
                    cond.Id = Convert.ToInt32(lblId.Text);
                    status = condCtrl.Actualizar(cond);
                }
                else
                {
                    status = condCtrl.Insertar(cond);
                }
                if (status)
                {
                    inicializarCondicion();
                    resetCampos();
                }
            }
        }
        private void btnCondDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblId.Text))
            {
                if (condCtrl.Eliminar(Convert.ToInt32(lblId.Text))){
                    inicializarCondicion();
                    resetCampos();
                }
            }
        }

        private void dgvCats_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0){
                DataGridViewRow row = dgvCats.Rows[e.RowIndex];
                txtNombre.Text = row.Cells[1].Value.ToString();
                lblId.Text = row.Cells[0].Value.ToString();
            }
        }
        private void dgvEdos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEdos.Rows[e.RowIndex];
                txtNombre.Text = row.Cells[1].Value.ToString();
                lblId.Text = row.Cells[0].Value.ToString();
            }
        }
        private void dgvConds_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvConds.Rows[e.RowIndex];
                txtNombre.Text = row.Cells[1].Value.ToString();
                lblId.Text = row.Cells[0].Value.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            resetCampos();
        }
    }
}
