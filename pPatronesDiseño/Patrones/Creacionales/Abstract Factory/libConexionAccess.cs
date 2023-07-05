using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Configuration;
using Newtonsoft.Json;

namespace pPatronesDiseño.Patrones.Creacionales.Abstract_Factory
{
    public class ConexionAccess : IAbstractFactoryBaseDatos
    {
        public ConexionAccess() {
            CadenaConexion = GenerarCadenaConexion();
        }
        public string SQL { get; set; }
        private string CadenaConexion;
        private string GenerarCadenaConexion()
        {
            return @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Trabajos\ITM\2023-1\Arquitectura\Patrones_Diseño\DBPatrones.accdb";
        }
        public string Actualizar()
        {
            return EjecutarSentencia();
        }
        public string Consultar()
        {
            List<object> _datosConsulta = new List<object>();
            clsConexionOleDB conexion = new clsConexionOleDB();
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
            clsConexionOleDB conexion = new clsConexionOleDB();
            conexion.CadenaConexion = CadenaConexion;
            conexion.SQL = SQL;
            if (conexion.EjecutarSentencia())
            {
                return "Se ejecutó la sentencia sql de ACCESS";
            }
            else
            {
                return conexion.Error;
            }
        }
    }
    public class clsConexionOleDB
    {
        #region "Atributos"
        private OleDbConnection conexion = new OleDbConnection();
        public OleDbDataReader Reader;
        private OleDbCommand command = new OleDbCommand();
        public string CadenaConexion { get; set; }
        public string SQL { get; set; }
        public string Error { get; set; }
        #endregion
        #region "Propiedades"
        public bool StoredProcedure { get; set; }
        public bool EjecutarSentencia()
        {
            if (SQL == "")
            {
                Error = "No definió la instrucción SQL";
                return false;
            }

            if (AbrirConexion())
            {
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
            //Validamos si la conexión está abierta
            if (conexion.State == System.Data.ConnectionState.Open)
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
                    if (conexion.State != System.Data.ConnectionState.Closed)
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
