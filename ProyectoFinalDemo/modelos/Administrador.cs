using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDemo.modelos
{
    public class Administrador
    {
        private int _id;
        private string _nombres;
        private string _apellidos;
        private string _correo;
        private string _telefono;
        private string _estado;
        private string _rol;
        private string _contrasena;
        private DateTime _creadoEn;
        private DateTime _modificadoEn;
        private DateTime _fdn;
        private string _usuario;
        private Image _avatar;

        public int Id { get => _id; set => _id = value; }
        public string Nombres { get => _nombres; set => _nombres = value; }
        public string Apellidos { get => _apellidos; set => _apellidos = value; }
        public string Email { get => _correo; set => _correo = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Rol { get => _rol; set => _rol = value; }
        public string Contrasena { get => _contrasena; set => _contrasena = value; }
        public DateTime Creado_en { get => _creadoEn; set => _creadoEn = value; }
        public DateTime Actualizado_en { get => _modificadoEn; set => _modificadoEn = value; }
        public DateTime Fdn { get => _fdn; set => _fdn = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public Image Avatar { get => _avatar; set => _avatar = value; }

        public override string ToString()
        {
            return $"Nombre: {Nombres} {Apellidos}, correo: {Email}, rol: {Rol}";
        }
    }
}
