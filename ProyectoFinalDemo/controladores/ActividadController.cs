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
    public class ActividadController
    {
        public bool Insertar(Actividad actividad)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "INSERT INTO actividades (nombre, fecha, descripcion, parque, categoria) VALUES (@nombre, @fecha, @descripcion, @parque, @categoria)";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@nombre", actividad.Nombre);
                    cmd.Parameters.AddWithValue("@fecha", actividad.Fecha);
                    cmd.Parameters.AddWithValue("@descripcion", actividad.Descripcion);
                    cmd.Parameters.AddWithValue("@parque", actividad.Parque);
                    cmd.Parameters.AddWithValue("@categoria", actividad.Categoria);
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error insertando la actividad: {ex.Message}");
                return false;
            }
            MessageBox.Show("Registro insertado exitosamente");
            return true;
        }

        public List<Actividad> ObtenerTodas()
        {
            List<Actividad> actividades = new List<Actividad>();
            Actividad act = null;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "SELECT * FROM actividades";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        act = new Actividad
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Fecha = Convert.ToDateTime(reader["fecha"]),
                            Descripcion = Convert.ToString(reader["descripcion"]),
                            Parque = Convert.ToInt32(reader["parque"]),
                            Categoria = Convert.ToInt32(reader["categoria"])
                        };
                        actividades.Add(act);
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error ");
            }
            return actividades;
        }

        public List<Actividad> ObtenerPorParque(int parqueId)
        {
            List<Actividad> actividades = new List<Actividad>();
            Actividad act = null;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "SELECT * FROM actividades WHERE parque = @parqueId";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@parqueId", parqueId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        act = new Actividad
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Fecha = Convert.ToDateTime(reader["fecha"]),
                            Descripcion = Convert.ToString(reader["descripcion"]),
                            Parque = Convert.ToInt32(reader["parque"]),
                            Categoria = Convert.ToInt32(reader["categoria"])
                        };
                        actividades.Add(act);
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error obteniendo actividades por parque: {ex.Message}");
            }
            return actividades;
        }

        public bool Actualizar(Actividad actividad)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "UPDATE actividades SET nombre = @nombre, fecha = @fecha, descripcion = @descripcion, parque = @parque, categoria = @categoria WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@nombre", actividad.Nombre);
                    cmd.Parameters.AddWithValue("@fecha", actividad.Fecha);
                    cmd.Parameters.AddWithValue("@descripcion", actividad.Descripcion);
                    cmd.Parameters.AddWithValue("@parque", actividad.Parque);
                    cmd.Parameters.AddWithValue("@categoria", actividad.Categoria);
                    cmd.Parameters.AddWithValue("@id", actividad.Id);
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error actualizando la actividad: {ex.Message}");
                return false;
            }
            MessageBox.Show("Registro actualizado exitosamente");
            return true;
        }

        public Actividad ObtenerPorId(int id)
        {
            Actividad act = null;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "SELECT * FROM actividades WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        act = new Actividad
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Fecha = Convert.ToDateTime(reader["fecha"]),
                            Descripcion = Convert.ToString(reader["descripcion"]),
                            Parque = Convert.ToInt32(reader["parque"]),
                            Categoria = Convert.ToInt32(reader["categoria"])
                        };
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error obteniendo la actividad por ID: {ex.Message}");
            }
            return act;
        }

        public bool Eliminar(int id)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "DELETE FROM actividades WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error eliminando la actividad: {ex.Message}");
                return false;
            }
            MessageBox.Show("Registro eliminado exitosamente");
            return true;
        }

        public List<Actividad> ObtenerPorCategoria(int categoriaId)
        {
            List<Actividad> actividades = new List<Actividad>();
            Actividad act = null;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "SELECT * FROM actividades WHERE categoria = @categoriaId";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@categoriaId", categoriaId);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        act = new Actividad
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Fecha = Convert.ToDateTime(reader["fecha"]),
                            Descripcion = Convert.ToString(reader["descripcion"]),
                            Parque = Convert.ToInt32(reader["parque"]),
                            Categoria = Convert.ToInt32(reader["categoria"])
                        };
                        actividades.Add(act);
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error obteniendo actividades por categoría: {ex.Message}");
            }
            return actividades;
        }
    }
}
