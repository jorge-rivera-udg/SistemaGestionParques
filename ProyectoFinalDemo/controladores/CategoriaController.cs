using MySql.Data.MySqlClient;
using ProyectoFinalDemo.modelos;
using ProyectoFinalDemo.utils;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDemo.controladores
{
    public class CategoriaController
    {
        public bool Insertar(Categoria cat)
        {
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                try
                {
                    conexion.Open();
                    string query = "insert into categorias (nombre) values (@nombre)";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@nombre", cat.Nombre);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Categoria agregada");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
                return true;
            }
        }

        public List<Categoria> ObtenerTodos()
        {
            List<Categoria> cats = new List<Categoria>();
            using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
            {
                conexion.Open();
                string query = "SELECT * FROM categorias";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        Categoria cat = new Categoria
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nombre = reader["nombre"].ToString()
                        };
                        cats.Add(cat);
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
            return cats;
        }

        public bool Actualizar(Categoria cat)
        {
            try
            {
                using (MySqlConnection conexion = new MySqlConnection(Constantes.MYSQL_DB_CONNECTION))
                {
                    conexion.Open();
                    string query = "UPDATE categorias SET nombre=@nombre WHERE id=@id";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@nombre", cat.Nombre);
                    comando.Parameters.AddWithValue("@id", cat.Id);
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
                string query = "DELETE FROM categorias WHERE id=@id";
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
