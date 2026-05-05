using MySql.Data.MySqlClient;
using ProyectoFinalDemo.modelos;
using ProyectoFinalDemo.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDemo.controladores
{
    public class AdministradorController
    {
        public bool insertar(Administrador administrador)
        {
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                byte[] bytes = ImageToByteArray(administrador.Avatar);
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
                    comando.Parameters.AddWithValue("@avatar", bytes);
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
        private byte[] ImageToByteArray(Image image)
        {
            if (image == null) return new byte[0];
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
        private Image ByteArrayToImage(byte[] bytes)
        {
            if (bytes.Length == 0) return null;
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    ms.Position = 0;
                    return Image.FromStream(ms);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Invalid parameter: {ex.Message}");
                return null;
            }
        }

        public bool actualizar(Administrador administrador)
        {
            byte[] bytes = ImageToByteArray(administrador.Avatar);
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "UPDATE administradores SET nombres=@nombres, apellidos=@apellidos, email=@email, telefono=@telefono, estado=@estado, rol=@rol, contrasena=@contrasena, modificado_en=@modificado_en, fdn=@fdn, usuario=@usuario, avatar=@avatar WHERE id=@id";
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
                    comando.Parameters.AddWithValue("@avatar", bytes);
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            } catch(Exception ex)
            {
                MessageBox.Show($"Error actualizando datos: {ex.Message}");
                return false;
            }
            MessageBox.Show("Registro actualizado correctamente");
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
                    try {
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
                            Avatar = ByteArrayToImage(reader["avatar"] as byte[])
                        };
                    }
                    catch (SqlNullValueException snve)
                    {
                        Console.WriteLine($"Error parsing user data: {snve.Message}");
                    }
                    catch (InvalidCastException ice)
                    {
                        Console.WriteLine($"Error casting user values: {ice.Message}");
                    }

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
                            Avatar = ByteArrayToImage(reader["avatar"] as byte[])
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
                    try { 
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
                            Avatar = ByteArrayToImage((byte[])reader["avatar"])
                        };
                        administradores.Add(administrador);
                    }
                    catch (SqlNullValueException snve)
                    {
                        Console.WriteLine($"Error parsing user data: {snve.Message}");
                    }
                    catch (InvalidCastException ice)
                    {
                        Console.WriteLine($"Error casting user values: {ice.Message}");
                    }

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
                    try { 
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
                            Avatar = ByteArrayToImage(reader["avatar"] as byte[])
                        };
                    }
                    catch (SqlNullValueException snve)
                    {
                        Console.WriteLine($"Error parsing user data: {snve.Message}");
                    }
                    catch (InvalidCastException ice)
                    {
                        Console.WriteLine($"Error casting user values: {ice.Message}");
                    }

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
                    try { 
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
                            Avatar = ByteArrayToImage(reader["avatar"] as byte[])
                        };
                    }
                    catch (SqlNullValueException snve)
                    {
                        Console.WriteLine($"Error parsing user data: {snve.Message}");
                    }
                    catch (InvalidCastException ice)
                    {
                        Console.WriteLine($"Error casting user values: {ice.Message}");
                    }

                }
                conexion.Close();
            }
            return administrador;
        }
    }
}