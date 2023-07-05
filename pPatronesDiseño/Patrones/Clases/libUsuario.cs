using pPatronesDiseño.Patrones.Creacionales.Abstract_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace pPatronesDiseño.Patrones.Clases
{
    public class Usuario
    {
        public string Documento { get; set; }
        public string Nombre { get; set;}
        public string Email { get; set; }
        public string Celular { get; set; }
    }
    public class brokerUsuario
    {
        //Clase que se encargará de conectar con la base de datos e invocar el factory correspondiente
        public Usuario usuario { get; set; }
        private string SQL;
        public string Consultar()
        {
            SQL = "SELECT       Documento, Nombre, Email, Celular " +
                  "FROM         Usuario " +
                  "WHERE        Documento = '" + usuario.Documento + "'";
            BaseDatosFactory factory = new BaseDatosFactory();
            return InvocarFactorySelect(factory);
        }
        public string ConsultarTodos()
        {
            SQL = "SELECT       Documento, Nombre, Email, Celular " +
                  "FROM         Usuario ";
            BaseDatosFactory factory = new BaseDatosFactory();
            return InvocarFactorySelect(factory);
        }
        public string Insertar()
        {
            SQL = "INSERT INTO Usuario (Documento, Nombre, Email, Celular) " +
                  "VALUES ('" + usuario.Documento + "', '" + usuario.Nombre + "', '" +
                            usuario.Email + "', '" + usuario.Celular + "')";
            BaseDatosFactory factory = new BaseDatosFactory();
            return InvocarFactoryExec(factory, "Insertar");
        }
        public string Actualizar()
        {
            SQL = "UPDATE       Usuario " +
                  "SET          Nombre      = '" + usuario.Nombre + "', " +
                               "Email       = '" + usuario.Email + "', " +
                               "Celular     = '" + usuario.Celular + "' " +
                  "WHERE        Documento   = '" + usuario.Documento + "'";
            BaseDatosFactory factory = new BaseDatosFactory();
            return InvocarFactoryExec(factory, "Actualizar");
        }
        public string Eliminar()
        {
            SQL = "DELETE FROM  Usuario " +
                  "WHERE        Documento = '" + usuario.Documento + "'";
            BaseDatosFactory factory = new BaseDatosFactory();
            return InvocarFactoryExec(factory, "Eliminar");
        }
        private string InvocarFactoryExec(IAbstractFactoryBD factoryBD, string Comando)
        {
            factoryBD.baseDatos = Configuracion.baseDatos;
            var bdUsuarios = factoryBD.CrearBaseDatos();
            bdUsuarios.SQL = SQL;
            switch (Comando)
            {
                case "Insertar":
                    return bdUsuarios.Insertar();
                case "Actualizar":
                    return bdUsuarios.Actualizar();
                case "Eliminar":
                    return bdUsuarios.Eliminar();
                default:
                    return null;
            }
            
        }
        private string InvocarFactorySelect(IAbstractFactoryBD factoryBD)
        {
            factoryBD.baseDatos = Configuracion.baseDatos;
            var bdUsuarios = factoryBD.CrearBaseDatos();
            bdUsuarios.SQL = SQL;
            return bdUsuarios.Consultar();
        }
    }
}
