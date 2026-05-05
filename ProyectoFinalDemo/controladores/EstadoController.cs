using MySql.Data.MySqlClient;
using ProyectoFinalDemo.modelos;
using ProyectoFinalDemo.utils;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDemo.controladores
{
    public class EstadoController
    {
        public bool Insertar(Estado estado)
        {
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                try
                {
                    conexion.Open();
                    string query = "insert into estados (nombre) values (@nombre)";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@nombre", estado.Nombre);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Estado agregado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
                return true;
            }
        }

        public List<Estado> ObtenerTodos()
        {
            List<Estado> estados = new List<Estado>();
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                conexion.Open();
                string query = "SELECT * FROM estados";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        Estado estado = new Estado
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nombre = reader["nombre"].ToString()
                        };
                        estados.Add(estado);
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
            return estados;
        }

        public bool Actualizar(Estado estado)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "UPDATE estados SET nombre=@nombre WHERE id=@id";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@nombre", estado.Nombre);
                    comando.Parameters.AddWithValue("@id", estado.Id);
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error actualizando datos: {ex.Message}");
                return false;
            }
            return true;
        }

        public bool Eliminar(int id)
        {
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                conexion.Open();
                string query = "DELETE FROM estados WHERE id=@id";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            return false;
        }
    }
}
