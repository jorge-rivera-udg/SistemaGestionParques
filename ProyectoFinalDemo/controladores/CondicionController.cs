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
    public class CondicionController
    {
        public bool Insertar(Condicion condicion)
        {
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                try
                {
                    conexion.Open();
                    string query = "insert into condiciones (nombre) values (@nombre)";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@nombre", condicion.Nombre);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Condicion agregada");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
                return true;
            }
        }

        public List<Condicion> ObtenerTodos()
        {
            List<Condicion> condiciones = new List<Condicion>();
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                conexion.Open();
                string query = "SELECT * FROM condiciones";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        Condicion condicion = new Condicion
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nombre = reader["nombre"].ToString()
                        };
                        condiciones.Add(condicion);
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
            return condiciones;
        }

        public bool Actualizar(Condicion condicion)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "UPDATE condiciones SET nombre=@nombre WHERE id=@id";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@nombre", condicion.Nombre);
                    comando.Parameters.AddWithValue("@id", condicion.Id);
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
                string query = "DELETE FROM condiciones WHERE id=@id";
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
