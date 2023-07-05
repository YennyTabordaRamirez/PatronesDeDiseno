using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SQLite;

namespace pPatronesDiseño.Patrones.Creacionales.Abstract_Factory
{
    public class ConexionSQLite : IAbstractFactoryBaseDatos
    {
        public ConexionSQLite()
        {
            CadenaConexion = GenerarCadenaConexion();
        }
        
        public string SQL { get; set; }
        private string CadenaConexion;
        private string GenerarCadenaConexion()
        {
            return @"Data Source=D:\Trabajos\ITM\2023-1\Arquitectura\Patrones_Diseño\DBPatrones_sqlite.db3; Cache=Shared;";
        }
        public string Actualizar()
        {
            return EjecutarSentencia();
        }
        public string Consultar()
        {
            List<object> _datosConsulta = new List<object>();
            clsConexionSQLite conexion = new clsConexionSQLite();
            conexion.SQL = SQL;
            conexion.CadenaConexion = CadenaConexion;
            if (conexion.Consultar())
            {
                while (conexion.Reader.Read())
                {
                    IDictionary<string, object> _dato = new Dictionary<string, object>();
                    for (int i = 0; i < conexion.Reader.FieldCount; i++)
                    {
                        _dato.Add(conexion.Reader.GetName(i), conexion.Reader[i]);
                    }
                    _datosConsulta.Add(_dato);
                }
                return JsonConvert.SerializeObject(_datosConsulta);
            }
            else
            {
                return conexion.Error;
            }
        }
        public string Eliminar()
        {
            return EjecutarSentencia();
        }
        public string Insertar()
        {
            return EjecutarSentencia();
        }
        private string EjecutarSentencia()
        {
            clsConexionSQLite conexion = new clsConexionSQLite();
            conexion.SQL = SQL;
            conexion.CadenaConexion = CadenaConexion;
            if (conexion.EjecutarSentencia())
            {
                return "Se ejecutó la sentencia sql de SQLite";
            }
            else
            {
                return conexion.Error;
            }
        }
    }
    public class clsConexionSQLite
    {
        #region "Atributos"
        private SQLiteConnection conexion;
        public SQLiteDataReader Reader;
        private SQLiteCommand command;
        public string CadenaConexion { get; set; }
        public string SQL { get; set; }
        public string Error { get; set; }
        public bool EjecutarSentencia()
        {
            if (SQL == "")
            {
                Error = "No definió la instrucción SQL";
                return false;
            }

            if (AbrirConexion())
            {
                command = conexion.CreateCommand();
                try
                {
                    command.CommandType = CommandType.Text;
                    command.Connection = conexion;
                    command.CommandText = SQL;
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Consultar()
        {
            //Validamos si el SQL existe
            if (SQL == "")
            {
                Error = "No definió la instrucción SQL";
                return false;
            }

            if (AbrirConexion())
            {
                try
                {
                    command = conexion.CreateCommand();
                    command.CommandType = System.Data.CommandType.Text;
                    command.Connection = conexion;
                    command.CommandText = SQL;
                    Reader = command.ExecuteReader();
                    return true;
                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool AbrirConexion()
        {
            conexion = new SQLiteConnection(CadenaConexion);
            //Validamos si la conexión está abierta
            if (conexion.State == ConnectionState.Open)
            {
                return true;
            }
            CadenaConexion = CadenaConexion;
            //Asigno la cadena de conexión y abro la conexión a la base de datos
            conexion.ConnectionString = CadenaConexion;
            try
            {
                conexion.Open();
                return true;
            }
            catch (Exception ex)
            {
                //Captura si hubo un error al tratar de abrir la base de datos
                Error = "Error al abrir la bd " + ex.Message;
                return false;
            }
        }
        public void CerrarConexion()
        {
            try
            {
                //Cierra la conexión si està abierta y si existe
                if (conexion != null)
                {
                    //La conexión existe, reviso que no estè cerrada
                    if (conexion.State != ConnectionState.Closed)
                    {
                        conexion.Close();
                    }
                    //Libero memoria
                    conexion = null;
                }

                //Elimina el command
                if (command != null)
                {
                    command = null;
                }
                return;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return;
            }
        }
        #endregion
    }
}

