using ProyectoFinalDemo.modelos;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalDemo.utils;

namespace ProyectoFinalDemo.controladores
{
    public class ParticipacionController
    {
        public bool Insertar(Participacion participacion)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "INSERT INTO participaciones (usuario, actividad) VALUES (@usuario, @actividad)";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@usuario", participacion.Usuario);
                    cmd.Parameters.AddWithValue("@actividad", participacion.Actividad);
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error insertando la participación: {ex.Message}");
                return false;
            }
            MessageBox.Show("Participación registrada exitosamente");
            return true;
        }

        public bool Eliminar(string usuario, int actividad)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "DELETE FROM participaciones WHERE usuario = @usuario AND actividad = @actividad";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@actividad", actividad);
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error eliminando la participación: {ex.Message}");
                return false;
            }
            MessageBox.Show("Participación eliminada exitosamente");
            return true;
        }

        public List<Participacion> ObtenerPorUsuario(string usuario)
        {
            List<Participacion> participaciones = new List<Participacion>();
            Participacion participacion = null;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "SELECT * FROM participaciones WHERE usuario = @usuario";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        participacion = new Participacion
                        {
                            Usuario = Convert.ToString(reader["usuario"]),
                            Actividad = Convert.ToInt32(reader["actividad"])
                        };
                        participaciones.Add(participacion);
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error obteniendo las participaciones: {ex.Message}");
            }
            return participaciones;
        }

        public List<Participacion> ObtenerTodas()
        {
            List<Participacion> participaciones = new List<Participacion>();
            Participacion participacion = null;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "SELECT * FROM participaciones";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        participacion = new Participacion
                        {
                            Usuario = Convert.ToString(reader["usuario"]),
                            Actividad = Convert.ToInt32(reader["actividad"])
                        };
                        participaciones.Add(participacion);
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error obteniendo las participaciones: {ex.Message}");
            }
            return participaciones;
        }
    }
}
