using MySql.Data.MySqlClient;
using ProyectoFinalDemo.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using ProyectoFinalDemo.utils;
using System.Data.SqlTypes;

namespace ProyectoFinalDemo.controladores
{
    public class AdministradorController
    {
        //private string Constantes.MYSQL_DB_CONNECTION = "Server=localhost;Database=SiGePaVe;User=root;Password=michel12;";//"Server=localhost;Database=SiGePaVe;Uid=root;Pwd=michel12;"

        public bool insertar(Administrador administrador)
        {
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                try
                {
                    conexion.Open();
                    string query = "INSERT INTO administradores (nombres, apellidos, email, telefono, estado, rol, contrasena, fdn, usuario, avatar) VALUES (@nombres, @apellidos, @email, @telefono, @estado, @rol, @contrasena, @fdn, @usuario, @avatar)";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@nombres", administrador.Nombres);
                    comando.Parameters.AddWithValue("@apellidos", administrador.Apellidos);
                    comando.Parameters.AddWithValue("@email", administrador.Email);
                    comando.Parameters.AddWithValue("@telefono", administrador.Telefono);
                    comando.Parameters.AddWithValue("@estado", administrador.Estado);
                    comando.Parameters.AddWithValue("@rol", administrador.Rol);
                    comando.Parameters.AddWithValue("@contrasena", administrador.Contrasena);
                    comando.Parameters.AddWithValue("@fdn", administrador.Fdn);
                    comando.Parameters.AddWithValue("@usuario", administrador.Usuario);
                    comando.Parameters.AddWithValue("@avatar", ImagenABlob(administrador.Avatar));
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
        }

        private string ImagenABlob(Image imagen)
        {
            if(imagen!=null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return Convert.ToBase64String(ms.ToArray());
                }
            }

            return "";
        }

        private Image BlobAImagen(byte[] blob)
        {
            using(MemoryStream ms = new MemoryStream(blob))
            {
                return Image.FromStream(ms);
            }
        }

        private Image BlobAImagen(string blob)
        {
            byte[] bytes = Convert.FromBase64String(blob);
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        public bool actualizar(Administrador administrador)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "UPDATE administradores SET nombres=@nombres, apellidos=@apellidos, email=@email, telefono=@telefono, estado=@estado, rol=@rol, contrasena=@contrasena, modificado_en=@modificado_en, fdn=@fdn, usuario=@usuario avatar=@avatar WHERE id=@id";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@nombres", administrador.Nombres);
                    comando.Parameters.AddWithValue("@apellidos", administrador.Apellidos);
                    comando.Parameters.AddWithValue("@email", administrador.Email);
                    comando.Parameters.AddWithValue("@telefono", administrador.Telefono);
                    comando.Parameters.AddWithValue("@estado", administrador.Estado);
                    comando.Parameters.AddWithValue("@rol", administrador.Rol);
                    comando.Parameters.AddWithValue("@contrasena", administrador.Contrasena);
                    comando.Parameters.AddWithValue("@modificado_en", DateTime.Now);
                    comando.Parameters.AddWithValue("@fdn", administrador.Fdn);
                    comando.Parameters.AddWithValue("@usuario", administrador.Usuario);
                    comando.Parameters.AddWithValue("@id", administrador.Id);
                    comando.Parameters.AddWithValue("@avatar", ImagenABlob(administrador.Avatar));
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            } catch(Exception ex)
            {
                MessageBox.Show($"Error actualizando datos: {ex.Message}");
                return false;
            }
            return true;
        }

        public void eliminar(int id)
        {
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                conexion.Open();
                string query = "DELETE FROM administradores WHERE id=@id";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public Administrador obtenerPorId(int id)
        {
            Administrador administrador = null;
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                conexion.Open();
                string query = "SELECT * FROM administradores WHERE id=@id";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    administrador = new Administrador
                    {
                        Id = reader.GetInt32("id"),
                        Nombres = reader.GetString("nombres"),
                        Apellidos = reader.GetString("apellidos"),
                        Email = reader.GetString("email"),
                        Telefono = reader.GetString("telefono"),
                        Estado = reader.GetString("estado"),
                        Rol = reader.GetString("rol"),
                        Contrasena = reader.GetString("contrasena"),
                        Creado_en = reader.GetDateTime("creado_en"),
                        Actualizado_en = reader.GetDateTime("modificado_en"),
                        Fdn = reader.GetDateTime("fdn"),
                        Usuario = reader.GetString("usuario"),
                        Avatar = BlobAImagen((byte[])reader["avatar"])
                    };
                }
                conexion.Close();
            }
            return administrador;
        }

        public List<Administrador> obtenerTodos()
        {
            List<Administrador> administradores = new List<Administrador>();
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                conexion.Open();
                string query = "SELECT * FROM administradores";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        Administrador administrador = new Administrador
                        {
                            Id = reader.GetInt32("id"),
                            Nombres = reader.GetString("nombres"),
                            Apellidos = reader.GetString("apellidos"),
                            Email = reader.GetString("email"),
                            Telefono = reader.GetString("telefono"),
                            Estado = reader.GetString("estado"),
                            Rol = reader.GetString("rol"),
                            Contrasena = reader.GetString("contrasena"),
                            Creado_en = reader.GetDateTime("creado_en"),
                            Actualizado_en = reader.GetDateTime("modificado_en"),
                            Fdn = reader.GetDateTime("fdn"),
                            Usuario = reader.GetString("usuario"),
                            Avatar = BlobAImagen((byte[])reader["avatar"])
                        };
                        administradores.Add(administrador);
                    } catch(SqlNullValueException snve) 
                    {
                        Console.WriteLine($"Error parsing user data: {snve.Message}");
                    } catch(InvalidCastException ice)
                    {
                        Console.WriteLine($"Error casting user values: {ice.Message}");
                    }
                }
                conexion.Close();
            }
            return administradores;
        }

        public List<Administrador> buscarPorNombre(string nombre)
        {
            List<Administrador> administradores = new List<Administrador>();
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                conexion.Open();
                string query = "SELECT * FROM administradores WHERE nombres LIKE @nombre";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Administrador administrador = new Administrador
                    {
                        Id = reader.GetInt32("id"),
                        Nombres = reader.GetString("nombres"),
                        Apellidos = reader.GetString("apellidos"),
                        Email = reader.GetString("email"),
                        Telefono = reader.GetString("telefono"),
                        Estado = reader.GetString("estado"),
                        Rol = reader.GetString("rol"),
                        Contrasena = reader.GetString("contrasena"),
                        Creado_en = reader.GetDateTime("creado_en"),
                        Actualizado_en = reader.GetDateTime("modificado_en"),
                        Fdn = reader.GetDateTime("fdn"),
                        Usuario = reader.GetString("usuario"),
                        Avatar = BlobAImagen((byte[])reader["avatar"])
                    };
                    administradores.Add(administrador);
                }
                conexion.Close();
            }
            return administradores;
        }

        public Administrador validarLogin(string usuario, string contrasena)
        {
            Administrador administrador = null;
            Console.WriteLine(Constantes.MYSQL_DB_CONNECTION);
            Console.WriteLine(usuario);
            Console.WriteLine(contrasena);
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                conexion.Open();
                string query = "SELECT * FROM administradores WHERE usuario=@usuario AND contrasena=@contrasena";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@contrasena", contrasena);
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    administrador = new Administrador
                    {
                        Id = reader.GetInt32("id"),
                        Nombres = reader.GetString("nombres"),
                        Apellidos = reader.GetString("apellidos"),
                        Email = reader.GetString("email"),
                        Telefono = reader.GetString("telefono"),
                        Estado = reader.GetString("estado"),
                        Rol = reader.GetString("rol"),
                        Contrasena = reader.GetString("contrasena"),
                        Creado_en = reader.GetDateTime("creado_en"),
                        Actualizado_en = reader.GetDateTime("modificado_en"),
                        Fdn = reader.GetDateTime("fdn"),
                        Usuario = reader.GetString("usuario"),
                        Avatar = BlobAImagen((byte[])reader["avatar"])
                    };
                }
                conexion.Close();
            }
            return administrador;
        }

        public Administrador obtenerPorUsuario(string usuario)
        {
            Administrador administrador = null;
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                conexion.Open();
                string query = "SELECT * FROM administradores WHERE usuario=@usuario";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@usuario", usuario);
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    administrador = new Administrador
                    {
                        Id = reader.GetInt32("id"),
                        Nombres = reader.GetString("nombres"),
                        Apellidos = reader.GetString("apellidos"),
                        Email = reader.GetString("email"),
                        Telefono = reader.GetString("telefono"),
                        Estado = reader.GetString("estado"),
                        Rol = reader.GetString("rol"),
                        Contrasena = reader.GetString("contrasena"),
                        Creado_en = reader.GetDateTime("creado_en"),
                        Actualizado_en = reader.GetDateTime("modificado_en"),
                        Fdn = reader.GetDateTime("fdn"),
                        Usuario = reader.GetString("usuario"),
                        Avatar = BlobAImagen((byte[])reader["avatar"])
                    };
                }
                conexion.Close();
            }
            return administrador;
        }
    }
}