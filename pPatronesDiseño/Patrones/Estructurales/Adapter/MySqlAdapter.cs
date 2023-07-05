using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using pPatronesDiseño.Patrones.Clases;
using pPatronesDiseño.Patrones.Estructurales.Adapter;

namespace pPatronesDiseño.Patrones.Estructurales.Adapter
{
    public class MySqlAdapter : IDbAdapterDB
    {
        private MySqlConnection connection;

        public void Conectar()
        {
            // Código para establecer la conexión con MySQL
            string connectionString = "Server=localhost;Port=3307;Database=prueba;Uid=root;Pwd=;";


            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        public void Desconectar()
        {
            connection.Close();
            connection.Dispose();
        }

        public void Insertar(EmpleadoEntity entity)
        {
            // Código para crear una entidad en SQL Server
            string query = "INSERT INTO Empleado (Nombre, Apellido, Edad) VALUES (@Nombre, @Apellido, @Edad)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", entity.Nombre);
            command.Parameters.AddWithValue("@Apellido", entity.Apellido);
            command.Parameters.AddWithValue("@Edad", entity.Edad);
            command.ExecuteNonQuery();
        }

        public EmpleadoEntity Consultar(int id)
        {
            // Código para leer un empleado de MySQL
            string query = "SELECT * FROM Empleado WHERE Id = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string nombre = reader["Name"].ToString();
                string apellido = reader["Name"].ToString();
                int edad = Convert.ToInt32(reader["Age"]);
                return new EmpleadoEntity { Id = id, Nombre = nombre, Apellido = apellido, Edad = edad };
            }

            return null;
        }

        public void Actualizar(EmpleadoEntity entity)
        {
            // Código para actualizar una entidad en MySQL
            string query = "UPDATE Empleado SET Nombre = @Nombre, Edad = @Edad WHERE Id = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", entity.Nombre);
            command.Parameters.AddWithValue("@Edad", entity.Edad);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            // Código para eliminar un empleado de MySQL
            string query = "DELETE FROM Empleado WHERE Id = @Id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }

}