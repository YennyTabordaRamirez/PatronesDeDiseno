using pPatronesDiseño.Patrones.Clases;
using pPatronesDiseño.Patrones.Estructurales.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pPatronesDiseño.Patrones.Comportamiento.Mediator
{
    public interface IMediatorDB
    {
        void InsertarEmpleado(EmpleadoEntity empleado);
        void ActualizarEmpleado(EmpleadoEntity empleado);
        void EliminarEmpleado(int empleadoId);
    }

    public class ConcreteMediator : IMediatorDB
    {
        private AccessDatabase accessDatabase;
        private MySqlDatabase mySqlDatabase;

        public ConcreteMediator(AccessDatabase accessDatabase, MySqlDatabase mySqlDatabase)
        {
            this.accessDatabase = accessDatabase;
            this.mySqlDatabase = mySqlDatabase;
        }

        public void InsertarEmpleado(EmpleadoEntity empleado)
        {
            if (empleado.TipoBaseDatos == TipoBaseDatos.Access)
            {
                accessDatabase.InsertarEmpleado(empleado);
            }
            else if (empleado.TipoBaseDatos == TipoBaseDatos.MySql)
            {
                mySqlDatabase.InsertarEmpleado(empleado);
            }
        }

        public void ActualizarEmpleado(EmpleadoEntity empleado)
        {
            if (empleado.TipoBaseDatos == TipoBaseDatos.Access)
            {
                accessDatabase.ActualizarEmpleado(empleado);
            }
            else if (empleado.TipoBaseDatos == TipoBaseDatos.MySql)
            {
                mySqlDatabase.ActualizarEmpleado(empleado);
            }
        }

        public void EliminarEmpleado(int empleadoId)
        {
            accessDatabase.EliminarEmpleado(empleadoId);
            mySqlDatabase.EliminarEmpleado(empleadoId);
        }
    }
}
