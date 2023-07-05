using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace pPatronesDiseño.Patrones.Creacionales.Abstract_Factory
{
    public interface IAbstractFactoryBD
    {
        eBaseDatos baseDatos { get; set; }
        IAbstractFactoryBaseDatos CrearBaseDatos();
    }
    public interface IAbstractFactoryBaseDatos
    {
        string SQL { get; set; }
        string Insertar();
        string Actualizar();
        string Eliminar();
        string Consultar();
    }
    public enum eBaseDatos
    {
        SQLServer = 1,
        Access = 2,
        SQLite = 3
    }
    public class BaseDatosFactory : IAbstractFactoryBD
    {
        public eBaseDatos baseDatos { get; set; }
        public IAbstractFactoryBaseDatos CrearBaseDatos()
        {
            switch (baseDatos)
            {
                case eBaseDatos.SQLServer:
                    return new ConexionSQL();
                case eBaseDatos.Access:
                    return new ConexionAccess();
                case eBaseDatos.SQLite:
                    return new ConexionSQLite();
                default : return null;
            }
        }
    }
}
