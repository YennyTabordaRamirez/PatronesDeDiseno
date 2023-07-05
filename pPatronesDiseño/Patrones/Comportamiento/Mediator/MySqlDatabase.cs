using pPatronesDiseño.Patrones.Clases;
using pPatronesDiseño.Patrones.Estructurales.Adapter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pPatronesDiseño.Patrones.Comportamiento.Mediator
{
    public class MySqlDatabase : Database
    {
        public MySqlDatabase(string connectionString) : base(connectionString)
        {
        }

        public void InsertarEmpleado(EmpleadoEntity empleado)
        {
            using (IDbConnection connection = CreateConnectionMysql())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Empleado (Id, Nombre, Apellido, Edad) VALUES (@Id, @Nombre, @Apellido, @Edad)";
                    command.Parameters.Add(CreateParameter(command, "Id", empleado.Id));
                    command.Parameters.Add(CreateParameter(command, "Nombre", empleado.Nombre));
                    command.Parameters.Add(CreateParameter(command, "Apellido", empleado.Apellido));
                    command.Parameters.Add(CreateParameter(command, "Edad", empleado.Edad));


                    command.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarEmpleado(EmpleadoEntity empleado)
        {
            using (IDbConnection connection = CreateConnectionMysql())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Empleado SET Nombre = @Nombre, Apellido = @Apellido WHERE Id = @Id";
                    command.Parameters.Add(CreateParameter(command, "Id", empleado.Id));
                    command.Parameters.Add(CreateParameter(command, "Nombre", empleado.Nombre));
                    command.Parameters.Add(CreateParameter(command, "Apellido", empleado.Apellido));

                    command.ExecuteNonQuery();
                }
            }
        }

        private IDataParameter CreateParameter(IDbCommand command, string parameterName, object value)
        {
            IDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value;
            return parameter;
        }

        // Implementa los métodos para eliminar y obtener empleados de la base de datos MySQL.
        public void EliminarEmpleado(int empleadoId)
        {
            using (IDbConnection connection = CreateConnectionMysql())
            {
                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Empleado WHERE Id = @Id";
                    command.Parameters.Add(CreateParameter(command, "Id", empleadoId));

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
