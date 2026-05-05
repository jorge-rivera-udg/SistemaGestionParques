using MySql.Data.MySqlClient;
using ProyectoFinalDemo.modelos;
using ProyectoFinalDemo.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDemo.controladores
{
    public class FotoController
    {

        public bool Insertar(Foto foto)
        {
            byte[] bytes = ImagenUtils.ConvertirImagenABlob(foto.Imagen);
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "INSERT INTO imagenes (imagen, fuente, fuente_id, usuario) VALUES (@imagen, @fuente, @fuenteId, @usuario)";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@imagen", bytes);
                    cmd.Parameters.AddWithValue("@fuente", foto.Fuente);
                    cmd.Parameters.AddWithValue("@fuenteId", foto.FuenteId);
                    cmd.Parameters.AddWithValue("@usuario", foto.Usuario);
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error insertando imagen: {ex.Message}");
                return false;
            }
            MessageBox.Show("Imagen insertada correctamente");
            return true;
        }

        public List<Foto> ObtenerImagenesPorFuente(int id, string fuente)
        {
            List<Foto> imagenes = new List<Foto>();
            Foto foto = null;
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                conexion.Open();
                string query = "SELECT * FROM imagenes WHERE fuente_id = @id and fuente = @fuente";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@fuente", fuente);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    foto = new Foto
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Imagen = ImagenUtils.ConvertirBlobAImagen(reader["imagen"] as byte[]),
                        Fuente = Convert.ToString(reader["fuente"]),
                        FuenteId = Convert.ToInt32(reader["fuente_id"]),
                        Usuario = Convert.ToString(reader["usuario"])
                    };
                    imagenes.Add(foto);
                }
                conexion.Close();
            }
            return imagenes;
        }

        public List<Foto> obtenerImagenesPorUsuario(string usuario)
        {
            List<Foto> imagenes = null;
            Foto foto = null;
            using(MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                conexion.Open();
                string query = "SLELCT * FROM imagenes WHERE usuario = @usuario";
                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    foto = new Foto
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Imagen = ImagenUtils.ConvertirBlobAImagen(reader["imagen"] as byte[]),
                        Fuente = Convert.ToString(reader["fuente"]),
                        FuenteId = Convert.ToInt32(reader["fuente_id"]),
                        Usuario = Convert.ToString(reader["usuario"])
                    };
                    imagenes.Add(foto);
                }
                conexion.Close();
            }
            return imagenes;
        }

        public bool Borrar(int id)
        {
            try
            {
                using(MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "DELETE FROM imagenes WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteScalar();
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"Error borrando la imagen: {ex.Message}");
                return false;
            }
            MessageBox.Show("La imagen fue borrada exitosamente");
            return true;
        }
    }
}
