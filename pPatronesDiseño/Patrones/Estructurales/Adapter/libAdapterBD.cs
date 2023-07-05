using pPatronesDiseño.Patrones.Clases;

namespace pPatronesDiseño.Patrones.Estructurales.Adapter
{
    public interface IDbAdapterDB
    {
        void Conectar();
        void Desconectar();
        void Insertar(EmpleadoEntity entity);
        EmpleadoEntity Consultar(int id);
        void Actualizar(EmpleadoEntity entity);
        void Eliminar(int id);
    }
}
