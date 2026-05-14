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
        public GestionReportesForm()
        {
            InitializeComponent();
        }
    }
}
