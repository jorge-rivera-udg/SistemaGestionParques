using ProyectoFinalDemo.controladores;
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
    public partial class FotoDisplayForm : Form
    {
        private FotoController fctrlr;
        public FotoDisplayForm(Image foto)
        {
            InitializeComponent();
            fctrlr = new FotoController();
            pictureBox1.Image = foto;
        }

        public FotoDisplayForm(int id)
        {
            InitializeComponent();
            fctrlr = new FotoController();
            pictureBox1.Image = fctrlr.obtenerPorId(id);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
