using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace pPatronesDiseño.Patrones.Estructurales.Adapter
{
    //La interfaz que utilizará el cliente
    public interface IEmpleadoTarget
    {
        List<Empleado> ListarEmpleados();
    }
    //Definir el adaptador para que sea accesado por el cliente
    public class Empleados
    {
        public List<Empleado> ListarEmpleados()
        {
            Empleado empleado = new Empleado();
            List<Empleado> ListaEmpleados = new List<Empleado>();
            empleado.Documento = "10023345848";
            empleado.Nombre = "ANDREA GONZALEZ";
            ListaEmpleados.Add(empleado);

            empleado = new Empleado();
            empleado.Documento = "1024357188";
            empleado.Nombre = "JUAN ANDRÉS GIL";
            ListaEmpleados.Add(empleado);

            empleado = new Empleado();
            empleado.Documento = "4365897456";
            empleado.Nombre = "MARTA BETANCUR";
            ListaEmpleados.Add(empleado);

            empleado = new Empleado();
            empleado.Documento = "1012450244";
            empleado.Nombre = "JULIANA MOLINA";
            ListaEmpleados.Add(empleado);

            return ListaEmpleados;
        }
    }
    public class Empleado
    {
        public string Documento { get; set; }
        public string Nombre { get; set; }
    }
    //Clase Adaptador que implementa la interfaz objetivo
    public class EmpleadoAdapter : IEmpleadoTarget
    {
        private Empleados _empleados;
        public EmpleadoAdapter(Empleados empleados)
        {
            _empleados = empleados;
        }
        public List<Empleado> ListarEmpleados()
        {
            return _empleados.ListarEmpleados();
        }
    }
    //Clase Cliente que realizará el acceso a adaptador
    public class Nomina
    {
        private IEmpleadoTarget _empleadoTarget;
        public List<Empleado> InformacionEmpleados { get; set; }
        public Nomina(IEmpleadoTarget empleadoTarget)
        {
            _empleadoTarget = empleadoTarget;
        }
        public void MostrarEmpleados()
        {
            InformacionEmpleados = _empleadoTarget.ListarEmpleados();
        }
    }
}
