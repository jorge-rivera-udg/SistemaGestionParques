using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDemo.modelos
{
    public class Reporte
    {
        private int id;
        private string descripcion;
        private DateTime fecha;
        private int estado;
        private string usuario;
        private int parque;
        private int categoria;

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int Estado { get => estado; set => estado = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public int Parque { get => parque; set => parque = value; }
        public int Categoria { get => categoria; set => categoria = value; }
    }
}
