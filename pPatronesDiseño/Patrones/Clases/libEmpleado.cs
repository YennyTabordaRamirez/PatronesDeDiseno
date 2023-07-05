using pPatronesDiseño.Patrones.Comportamiento.Mediator;
using pPatronesDiseño.Patrones.Creacionales.Abstract_Factory;
using pPatronesDiseño.Patrones.Estructurales.Adapter;
using System.Collections.Generic;

namespace pPatronesDiseño.Patrones.Clases
{
    public class EmpleadoEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public TipoBaseDatos TipoBaseDatos { get; set; }
    }
}