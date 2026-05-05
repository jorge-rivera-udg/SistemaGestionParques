using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDemo.modelos
{
    public class Participacion
    {
        string usuario;
        int actividad;

        public string Usuario { get => usuario; set => usuario = value; }
        public int Actividad { get => actividad; set => actividad = value; }
    }
}
