using ProyectoFinalDemo.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDemo.common
{
    public class Sesion
    {
        private Administrador usuario;
        private DateTime inicio;

        public Sesion()
        {
            inicio = DateTime.Now;
        }

        public Administrador Usuario { get => usuario; set => usuario = value; }
        public DateTime Inicio { get => inicio; set => inicio = value; }
    }
}
