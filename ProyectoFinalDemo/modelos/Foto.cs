using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDemo.modelos
{
    public class Foto
    {
        private int id;
        private Image imagen;
        private string fuente;
        private int fuenteId;
        private string usuario;

        public int Id { get => id; set => id = value; }
        public Image Imagen { get => imagen; set => imagen = value; }
        public string Fuente { get => fuente; set => fuente = value; }
        public int FuenteId { get => fuenteId; set => fuenteId = value; }
        public string Usuario { get => usuario; set => usuario = value; }
    }
}
