using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ProyectoFinalDemo.modelos;
using ProyectoFinalDemo.utils;

namespace ProyectoFinalDemo.controladores
{
    internal class ReporteController
    {

        public bool Insertar(Reporte reporte)
        {
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                try
                {
                    conexion.Open();
                    string query = "INSERT INTO reportes (descripcion, fecha, estado, usuario, parque, categoria) VALUES (@descripcion, @fecha, @estado, @usuario, @parque, @categoria)";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@descripcion", reporte.Descripcion);
                    cmd.Parameters.AddWithValue("@fecha", reporte.Fecha);
                    cmd.Parameters.AddWithValue("@estado", reporte.Estado);
                    cmd.Parameters.AddWithValue("@usuario", reporte.Usuario);
                    cmd.Parameters.AddWithValue("@parque", reporte.Parque);
                    cmd.Parameters.AddWithValue("@categoria", reporte.Categoria);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error insertando el reporte: {ex.Message}");
                    return false;
                }
            }
            MessageBox.Show("Reporte insertado correctamente");
            return true;
        }

        public List<Reporte> ObtenerTodos()
        {
            List<Reporte> reportes = new List<Reporte>();
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT * FROM reportes";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Reporte reporte = new Reporte
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Descripcion = reader["descripcion"].ToString(),
                            Fecha = Convert.ToDateTime(reader["fecha"]),
                            Estado = Convert.ToInt32(reader["estado"]),
                            Usuario = reader["usuario"].ToString(),
                            Parque = Convert.ToInt32(reader["parque"]),
                            Categoria = Convert.ToInt32(reader["categoria"])
                        };
                        reportes.Add(reporte);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error obteniendo los reportes: {ex.Message}");
                }
            }
            return reportes;

        }

        public bool Eliminar(int id)
        {
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                try
                {
                    conexion.Open();
                    string query = "DELETE FROM reportes WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error eliminando el reporte: {ex.Message}");
                    return false;
                }
            }
            MessageBox.Show("Reporte eliminado correctamente");
            return true;
        }

        public bool Actualizar(Reporte reporte)
        {
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                try
                {
                    conexion.Open();
                    string query = "UPDATE reportes SET descripcion = @descripcion, fecha = @fecha, estado = @estado, usuario = @usuario, parque = @parque, categoria = @categoria WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@descripcion", reporte.Descripcion);
                    cmd.Parameters.AddWithValue("@fecha", reporte.Fecha);
                    cmd.Parameters.AddWithValue("@estado", reporte.Estado);
                    cmd.Parameters.AddWithValue("@usuario", reporte.Usuario);
                    cmd.Parameters.AddWithValue("@parque", reporte.Parque);
                    cmd.Parameters.AddWithValue("@categoria", reporte.Categoria);
                    cmd.Parameters.AddWithValue("@id", reporte.Id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error actualizando el reporte: {ex.Message}");
                    return false;
                }
            }
            MessageBox.Show("Reporte actualizado correctamente");
            return true;
        }

        public Reporte ObtenerPorId(int id)
        {
            Reporte reporte = null;
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT * FROM reportes WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        reporte = new Reporte
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Descripcion = reader["descripcion"].ToString(),
                            Fecha = Convert.ToDateTime(reader["fecha"]),
                            Estado = Convert.ToInt32(reader["estado"]),
                            Usuario = reader["usuario"].ToString(),
                            Parque = Convert.ToInt32(reader["parque"]),
                            Categoria = Convert.ToInt32(reader["categoria"])
                        };
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error obteniendo el reporte: {ex.Message}");
                }
            }
            return reporte;
        }

        public List<Reporte> ObtenerReportesPorUsuario(string usuario)
        {
            List<Reporte> reportes = new List<Reporte>();
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT * FROM reportes WHERE usuario = @usuario";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Reporte reporte = new Reporte
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Descripcion = reader["descripcion"].ToString(),
                            Fecha = Convert.ToDateTime(reader["fecha"]),
                            Estado = Convert.ToInt32(reader["estado"]),
                            Usuario = reader["usuario"].ToString(),
                            Parque = Convert.ToInt32(reader["parque"]),
                            Categoria = Convert.ToInt32(reader["categoria"])
                        };
                        reportes.Add(reporte);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error obteniendo los reportes del usuario: {ex.Message}");
                }
            }
            return reportes;
        }
    }
}
