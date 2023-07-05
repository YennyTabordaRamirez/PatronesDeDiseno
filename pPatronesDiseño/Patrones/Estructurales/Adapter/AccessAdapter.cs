using pPatronesDiseño.Patrones.Clases;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pPatronesDiseño.Patrones.Estructurales.Adapter
{
    public class AccessAdapter : IDbAdapterDB
    {
        private OleDbConnection connection;

        public void Conectar()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\PERSONAL\prueba.accdb;";

            connection = new OleDbConnection(connectionString);
            connection.Open();
            Console.WriteLine("Conectado a la base de datos Access.");
        }

        public void Desconectar()
        {
            connection.Close();
            Console.WriteLine("Desconectado de la base de datos Access.");
        }

        public void Insertar(EmpleadoEntity employee)
        {
            string query = "INSERT INTO Empleado (Nombre, Apellido, Edad) VALUES (?, ?, ?)";
            OleDbCommand command = new OleDbCommand(query, connection);
            
            command.Parameters.AddWithValue("?", employee.Nombre);
            command.Parameters.AddWithValue("?", employee.Apellido);
            command.Parameters.AddWithValue("?", employee.Edad);
            command.ExecuteNonQuery();
            Console.WriteLine("Empleado creado en Access: {0}", employee.Nombre);
        }

        public EmpleadoEntity Consultar(int id)
        {
            string query = "SELECT * FROM Empleado WHERE Id = ?";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("?", id);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                EmpleadoEntity employee = new EmpleadoEntity
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Nombre = reader["Nombre"].ToString(),
                    Apellido = reader["Apellido"].ToString(),
                    Edad = Convert.ToInt32(reader["Edad"]),
                };
                reader.Close();
                Console.WriteLine("Empleado obtenido de Access: {0}", employee.Nombre);
                return employee;
            }
            reader.Close();
            return null;
        }

        public void Actualizar(EmpleadoEntity employee)
        {
            string query = "UPDATE Empleado SET Name = ? WHERE Id = ?";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("?", employee.Nombre);
            command.Parameters.AddWithValue("?", employee.Apellido);
            command.Parameters.AddWithValue("?", employee.Id);
            command.ExecuteNonQuery();
            Console.WriteLine("Empleado actualizado en Access: {0}", employee.Nombre);
        }

        public void Eliminar(int id)
        {
            string query = "DELETE FROM Empleado WHERE Id = ?";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("?", id);
            command.ExecuteNonQuery();
            Console.WriteLine("Empleado eliminado de Access con ID: {0}", id);
        }
    }
}
