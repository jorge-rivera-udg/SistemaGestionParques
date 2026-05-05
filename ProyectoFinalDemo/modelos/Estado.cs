using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDemo.modelos
{
    public class Estado
    {
        int _id;
        string _nombre;

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
    }
}
