using pPatronesDiseño.Patrones.Clases;
using pPatronesDiseño.Patrones.Estructurales.Adapter;
using System;
using System.Data;
using System.Data.SqlClient;

namespace pPatronesDiseño.Patrones.Estructurales.Adapter
{
    public class SqlServerAdapter : IDbAdapterDB
    {
        private SqlConnection connection;

        public void Conectar()
        {
            // Código para establecer la conexión con SQL Server
            string connectionString = "Data Source=nombre_servidor;Initial Catalog=nombre_base_datos;User ID=nombre_usuario;Password=contraseña;";

            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public void Desconectar()
        {
            connection.Close();
            connection.Dispose();
        }

        public void Insertar(EmpleadoEntity entity)
        {
            // Código para crear un empleado en SQL Server
            string query = "INSERT INTO Empleado (Nombre, Edad) VALUES (@Nombre, @Edad)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", entity.Nombre);
            command.Parameters.AddWithValue("@Edad", entity.Edad);
            command.ExecuteNonQuery();
        }

        public EmpleadoEntity Consultar(int id)
        {
            // Código para leer un empleado de SQL Server
            string query = "SELECT * FROM Employees WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string name = reader["Nombre"].ToString();
                string apellido = reader["Apellido"].ToString();
                return new EmpleadoEntity { Id = id, Nombre = name, Apellido = apellido };
            }

            return null;
        }

        public void Actualizar(EmpleadoEntity entity)
        {
            // Código para actualizar una entidad en SQL Server
            string query = "UPDATE Empleado SET Nomre = @Nombre, Edad = @Edad WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Nombre", entity.Nombre);
            command.Parameters.AddWithValue("@Edad", entity.Edad);
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            // Código para eliminar una entidad de SQL Server
            string query = "DELETE FROM Empleado WHERE Id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }

}