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
    public class ParqueController
    {
        public bool Insertar(Parque parque)
        {
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                try
                {
                    conexion.Open();
                    string query = "INSERT INTO parque (nombre, ubicacion, condicion) VALUES (@nombre, @ubicacion, @condicion)";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@nombre", parque.Nombre);
                    cmd.Parameters.AddWithValue("@ubicacion", parque.Ubicacion);
                    cmd.Parameters.AddWithValue("@condicion", parque.Condicion);
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al insertar el parque: {ex.Message}");
                    return false;
                }
                MessageBox.Show("Parque insertado correctamente.");
                return true;
            }
        }

        public List<Parque> ObtenerTodos()
        {
            List<Parque> parques = new List<Parque>();
            Parque parque = null;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "SELECT * FROM parque";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        parque = new Parque
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Ubicacion = Convert.ToString(reader["ubicacion"]),
                            Condicion = Convert.ToInt32(reader["condicion"])
                        };
                        parques.Add(parque);
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los parques: {ex.Message}");
            }
            return parques;
        }

        public Parque ObtenerPorId(int id)
        {
            Parque parque = null;
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "SELECT * FROM parque WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        parque = new Parque
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nombre = Convert.ToString(reader["nombre"]),
                            Ubicacion = Convert.ToString(reader["ubicacion"]),
                            Condicion = Convert.ToInt32(reader["condicion"])
                        };
                    }
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el parque por ID: {ex.Message}");
            }
            return parque;
        }
    }
}
