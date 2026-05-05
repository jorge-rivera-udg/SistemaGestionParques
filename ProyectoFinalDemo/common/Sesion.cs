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
        private Parque parque;
        private Reporte reporte;
        private Actividad actividad;
        private DateTime inicio;
        private List<Foto> fotos;
        private List<Parque> parques;
        private List<Reporte> reportes;
        private List<Actividad> actividades;
        private List<Participacion> participaciones;

        public Sesion()
        {
            inicio = DateTime.Now;
        }

        public Administrador Usuario { get => usuario; set => usuario = value; }
        public DateTime Inicio { get => inicio; set => inicio = value; }
        public List<Foto> Fotos { get => fotos; set => fotos = value; }
        public List<Parque> Parques { get => parques; set => parques = value; }
        public List<Reporte> Reportes { get => reportes; set => reportes = value; }
        public List<Actividad> Actividades { get => actividades; set => actividades = value; }
    }
}
