using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace pPatronesDiseño.Patrones.Creacionales.Abstract_Factory
{
    public class ConexionSQL : IAbstractFactoryBaseDatos
    {
        public string SQL { get; set; }
        public string Actualizar()
        {
            return EjecutarSentencia();   
        }
        public string Consultar()
        {
            List<object> _datosConsulta = new List<object>();
            clsConexionSQL conexion = new clsConexionSQL();
            conexion.SQL = SQL;
            if (conexion.Consultar())
            {
                while(conexion.Reader.Read())
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
            clsConexionSQL conexion = new clsConexionSQL();
            conexion.SQL = SQL;
            if (conexion.EjecutarSentencia())
            {
                return "Se ejecutó la sentencia sql de SQL Server";
            }
            else
            {
                return conexion.Error;
            }
        }
    }
    public class clsConexionSQL
    {
        #region "Constructor"
        public clsConexionSQL()
        {
            //Creamos el constructor de la clase conexión, donde creamos
            //las instancias de los objetos
            objConexionDB = new SqlConnection();
            oCommand = new SqlCommand();
            objAdapter = new SqlDataAdapter();
            objDataSet = new DataSet();
            oParametro = new SqlParameter();
            strSQL = "";
            strNombreTabla = "TablaGenerica";
        }
        #endregion
        #region "Destructor"
        //El destructor se invoca cuando se destruye el objeto
        ~clsConexionSQL()
        {
            //Elimina el dataset
            if (objDataSet != null)
            {
                //Elimina el dataset
                objDataSet = null;
            }
            //Cuando destruyen el objeto invoca el mètodo de cerrar conexion
            CerrarConexion();
        }
        #endregion
        #region "Atributos"
        private SqlConnection objConexionDB;
        private SqlDataReader objReader;
        private SqlDataAdapter objAdapter;
        private SqlParameter oParametro;
        private string strNombreTabla;
        private DataSet objDataSet;
        private string strCadenaConexion;
        private string strSQL;
        private string strError;
        #endregion
        #region "Propiedades"
        public bool StoredProcedure { get; set; }
        public SqlCommand oCommand { get; set; }
        public DataSet DATASET
        {
            get { return objDataSet; }
        }
        public SqlDataReader Reader
        {
            get
            {
                return objReader;
            }
        }
        public string NombreTabla
        {
            get { return strNombreTabla; }
            set { strNombreTabla = value; }
        }
        public string SQL
        {
            get
            {
                return strSQL;
            }
            set
            {
                strSQL = value;
            }
        }
        public string ArchivoXML { get; set; }
        public string Origen { get; set; }
        public string Error
        {
            get
            {
                return strError;
            }
        }
        private SqlTransaction BDTransaccion;
        #endregion 
        #region "Metodos"
        public bool EjecutarSentencia()
        {
            //Validamos si el SQL existe
            if (strSQL == "")
            {
                //No definieron el sql, se debe abortar el proceso
                strError = "No definió la instrucción SQL";
                return false;
            }

            //Ejecuta las instrucciones sql de insercion, actualización y borrado a la base de 
            //datos, es decir, aquellas que no retornan datos
            //El primer paso es abrir la base de datos
            if (AbrirConexion())
            {
                //Le asigna al comando las propiedades
                try
                {
                    if (StoredProcedure)
                    {
                        oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    }
                    else
                    {
                        oCommand.CommandType = System.Data.CommandType.Text;
                    }
                    oCommand.Connection = objConexionDB;
                    oCommand.CommandText = strSQL;

                    //Ejecuta la sentencia, cierra la conexión y retorna verdadero
                    oCommand.ExecuteNonQuery();
                    //CerrarConexion();
                    return true;
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
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
            if (strSQL == "")
            {
                //No definieron el sql, se debe abortar el proceso
                strError = "No definió la instrucción SQL";
                return false;
            }
            //Ejecuta las instrucciones sql de insercion, actualización y borrado a la base de 
            //datos, es decir, aquellas que no retornan datos
            //El primer paso es abrir la base de datos
            if (AbrirConexion())
            {
                //Le asigna al comando las propiedades
                try
                {
                    if (StoredProcedure)
                    {
                        oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    }
                    else
                    {
                        oCommand.CommandType = System.Data.CommandType.Text;
                    }
                    oCommand.Connection = objConexionDB;
                    oCommand.CommandText = strSQL;

                    //Ejecuta la sentencia, almacena los datos en un reader, 
                    //cierra la conexión y retorna verdadero
                    objReader = oCommand.ExecuteReader();
                    return true;
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private bool GenerarCadenaConexion()
        {
            //Creamos la instancia del objeto parametros
            clsParametrosSQL objParametros = new clsParametrosSQL();
            objParametros.ArchivoXML = ArchivoXML;
            objParametros.Origen = Origen;
            if (objParametros.GenerarCadena())
            {
                strCadenaConexion = objParametros.CadenaConexion;
                objParametros = null;
                return true;
            }
            else
            {
                strError = "Error en la generación de la cadena " + objParametros.Error;
                objParametros = null;
                return false;
            }
        }
        private bool AbrirConexion()
        {
            //Validamos si la conexión está abierta
            if (objConexionDB.State == System.Data.ConnectionState.Open)
            {
                return true;
            }

            //Abre la conexión a la base de datos
            //Crea la cadena de conexión
            if (GenerarCadenaConexion())
            {
                //Asigno la cadena de conexión y abro la conexión a la base de datos
                objConexionDB.ConnectionString = strCadenaConexion;
                try
                {
                    objConexionDB.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    //Captura si hubo un error al tratar de abrir la base de datos
                    strError = "Error al abrir la bd " + ex.Message;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void CerrarConexion()
        {
            try
            {
                //Cierra la conexión si està abierta y si existe
                if (objConexionDB != null)
                {
                    //La conexión existe, reviso que no estè cerrada
                    if (objConexionDB.State != System.Data.ConnectionState.Closed)
                    {
                        objConexionDB.Close();
                    }
                    //Libero memoria
                    objConexionDB = null;
                }

                //Elimina el command
                if (oCommand != null)
                {
                    oCommand = null;
                }

                //Libera el dataadapter
                if (objAdapter != null)
                {
                    objAdapter = null;
                }

                return;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return;
            }
        }
        public bool LlenarDataSet()
        {
            //Primero validamos que exista el SQL
            if (strSQL == "")
            {
                strError = "No definió el SQL";
                return false;
            }
            //Se asegura que la tabla tenga datos
            if (strNombreTabla == "")
            {
                strNombreTabla = "TablaGenerica";
            }
            //Abre la conexión a la base de datos
            if (AbrirConexion())
            {
                try
                {
                    //Define los paràmetros del objeto command
                    oCommand.Connection = objConexionDB;
                    oCommand.CommandText = strSQL;
                    if (StoredProcedure)
                    {
                        oCommand.CommandType = CommandType.StoredProcedure;
                    }
                    else
                    {
                        oCommand.CommandType = CommandType.Text;
                    }

                    //Defino las propiedades del objeto adapter y lleno el dataset
                    objAdapter.SelectCommand = oCommand;
                    //Con el método fill se llena el dataset
                    objAdapter.Fill(objDataSet, strNombreTabla);

                    //Cierro la conexión
                    CerrarConexion();
                    return true;
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                    CerrarConexion();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool AgregarParametro(string sNombreParametro, SqlDbType TipoDato, Int32 Tamano, object Valor)
        {
            try
            {
                oParametro.ParameterName = sNombreParametro;
                oParametro.SqlDbType = TipoDato;
                oParametro.Value = Valor;
                oParametro.Size = Tamano;
                oCommand.Parameters.Add(oParametro);
                oParametro = new SqlParameter();
                return (true);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return (false);
            }
        }
        public bool AgregarParametro(ParameterDirection Direccion, string Nombre, SqlDbType TipoDato, Int16 Tamano, object Valor)
        {
            try
            {
                oParametro.Direction = Direccion;
                oParametro.ParameterName = Nombre;
                oParametro.SqlDbType = TipoDato;
                oParametro.Size = Tamano;
                oParametro.Value = Valor;

                oCommand.Parameters.Add(oParametro);
                oParametro = new SqlParameter();
                return (true);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return (false);
            }
        }
        public bool AgregarParametro(string NombreParametro, object Valor)
        {
            try
            {
                oParametro.ParameterName = NombreParametro;
                oParametro.Value = Valor;
                oCommand.Parameters.Add(oParametro);
                oParametro = new SqlParameter();
                return (true);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return (false);
            }
        }
        public bool AbrirTransaccion()
        {
            /*if (strSQL == "")
            {
                strError = "No definio la instrucción SQL";
                return false;
            }*/
            if (objConexionDB.State != System.Data.ConnectionState.Open)
            {
                if (AbrirConexion() == false)
                {
                    return false;
                }
            }

            try
            {
                BDTransaccion = objConexionDB.BeginTransaction();
                oCommand.Transaction = BDTransaccion;
                return (true);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }
        public bool AceptarTransaccion()
        {
            try
            {
                BDTransaccion.Commit();
                return (true);
            }
            catch (Exception ex)
            {
                try
                {
                    BDTransaccion.Rollback();
                    strError = "No se aceptó la transacción" + ex.Message;
                    return (false);
                }
                catch (Exception ex1)
                {
                    strError = "No se aceptó la transacción ni la retrocedio: " + ex1.Message;
                    return (false);
                }
            }
        }
        public bool RechazarTransaccion()
        {
            try
            {
                BDTransaccion.Rollback();
                return (true);
            }
            catch (Exception ex)
            {
                strError = "No se retrocedió la transacción: " + ex.Message;
                return (false);
            }
        }
        #endregion
    }
    public class clsParametrosSQL
    {
        #region "Atributos"
        private string strArchivoXML;
        private string strServidor;
        private string strBaseDatos;
        private string strUsuario;
        private string strClave;
        private string strSeguridadIntegrada;
        private string strCadenaConexion;
        private string strError;
        #endregion

        #region "Propiedades"
        public string CadenaConexion
        {
            get
            {
                return strCadenaConexion;
            }
        }
        public string ArchivoXML { get; set; }
        public string Origen { get; set; }
        public string Error
        {
            get
            {
                return strError;
            }
        }
        #endregion

        #region "Metodos"
        public bool GenerarCadena()
        {
            if (string.IsNullOrEmpty(ArchivoXML))
            {
                //El primer paso es abrir el archivo de conexion
                //Capturamos el nombre de la aplicación, con base en la ruta donde se ejecuta el proyecto
                string strNombreAplicacion = AppDomain.CurrentDomain.BaseDirectory;
                //Se eliminan los dos  ùltimos caracteres
                strNombreAplicacion = strNombreAplicacion.Substring(1, strNombreAplicacion.Length - 2);
                //Se captura el nombre borrándole el directorio de origen de la ruta
                strNombreAplicacion = strNombreAplicacion.Substring(strNombreAplicacion.LastIndexOf('\\')
                    + 1, strNombreAplicacion.Length - (strNombreAplicacion.LastIndexOf('\\') + 1));

                //Defin el nombre del archivo, la ruta donde se ubica es donde ejecuta el proyecto
                //se le agrega la palabra CON, para indicar que es el archivo con la conexion

                strArchivoXML = Application.StartupPath + "\\CON_" + strNombreAplicacion + ".xml";
                if (Origen == "Servicio_Smarterasp")
                {
                    string sPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                    strArchivoXML = sPath + "\\CON_" + strNombreAplicacion + ".xml";
                }
                else
                {
                    strArchivoXML = Application.StartupPath + "\\CON_" + strNombreAplicacion + ".xml";
                }
            }
            else
            {
                strArchivoXML = ArchivoXML;
            }
            //Abrimos el archivo xml
            try
            {
                //Declaramos el objeto documento
                XmlDocument objDocumento = new XmlDocument();
                //Abrimos el archivo
                objDocumento.Load(strArchivoXML);

                //Leemos la información
                XmlNode objNodo;
                //Leemos el servidor
                objNodo = objDocumento.SelectSingleNode("//SERVIDOR");
                strServidor = objNodo.InnerText;

                //Leemos la base de datos
                objNodo = objDocumento.SelectSingleNode("//BASE_DATOS");
                strBaseDatos = objNodo.InnerText;

                //Leemos el usuario
                objNodo = objDocumento.SelectSingleNode("//USUARIO");
                strUsuario = objNodo.InnerText;

                //Leemos la clave
                objNodo = objDocumento.SelectSingleNode("//CLAVE");
                strClave = objNodo.InnerText;

                //Leemos la seguridad integrada
                objNodo = objDocumento.SelectSingleNode("//SEGURIDAD_INTEGRADA");
                strSeguridadIntegrada = objNodo.InnerText;

                //Con todos los datos generamos la cadena de conexion
                //Hay dos cadenas de conexion, una cuando la seguridad es integrada y otra
                //cuando la seguridad es mixta en el SQL Server, es decir, utilizo la seguridad de
                //SQL Server
                if (strSeguridadIntegrada.ToUpper() == "SI")
                {
                    //La cadena de conexion es con seguridad integrada
                    strCadenaConexion = "Data Source=" + strServidor + "; Initial Catalog=" + strBaseDatos +
                                                    "; Integrated Security=SSPI;";
                }
                else
                {
                    strCadenaConexion = "Data Source=" + strServidor + ";Initial Catalog=" + strBaseDatos +
                                                    ";User Id=" + strUsuario + ";Pwd=" + strClave + ";";
                }

                // Al terminar, se libera memoria de los objetos xml y node y retorna verdadero
                objNodo = null;
                objDocumento = null;
                return true;
            }
            catch (Exception ex)
            {
                strError = "Ruta del archivo: " + strArchivoXML + ex.Message;
                return false;
            }
        }
        #endregion
    }
}
