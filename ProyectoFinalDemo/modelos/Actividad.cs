using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDemo.modelos
{
    public class Actividad
    {
        private int id;
        private string nombre;
        private DateTime fecha;
        private string descripcion;
        private int parque;
        private int categoria;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Parque { get => parque; set => parque = value; }
        public int Categoria { get => categoria; set => categoria = value; }
    }
}
