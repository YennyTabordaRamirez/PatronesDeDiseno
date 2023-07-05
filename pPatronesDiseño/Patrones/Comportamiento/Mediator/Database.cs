using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pPatronesDiseño.Patrones.Comportamiento.Mediator
{
    public enum TipoBaseDatos
    {
        Access,
        MySql
    }

    public abstract class Database
    {
        protected string connectionString;

        public Database(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected IDbConnection CreateConnectionMysql()
        {
            IDbConnection connection = new MySqlConnection(connectionString);
            return connection;
        }

        protected OleDbConnection CreateConnectionAccess()
        {
            return new OleDbConnection(connectionString);
        }
    }
}
