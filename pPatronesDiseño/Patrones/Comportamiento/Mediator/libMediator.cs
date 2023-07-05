using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pPatronesDiseño.Patrones.Comportamiento.Mediator
{
    public interface IDepartmentoMediator
    {
        void RegistrarUsuario(Usuario usuario);
        void EnviarReconocimiento(string mensaje, Usuario usuario);
        void EnviarMultipleReconocimiento(string mensaje, Usuario usuario);
    }

    public class DepartmentGroupMediator : IDepartmentoMediator
    {
        private List<Usuario> _usuariosList = new List<Usuario>();

        public void RegistrarUsuario(Usuario usuario)
        {
            _usuariosList.Add(usuario);
        }

        public void EnviarReconocimiento(string mensaje, Usuario usuario)
        {
            if (!usuario.EsEvaluador)
            {
                var examiner = _usuariosList.Find(j => j.EsEvaluador == true);
                examiner.Recibir(mensaje, usuario);
            }
            else
            {
                usuario.Recibir(mensaje, usuario);
            }
        }

        public void EnviarMultipleReconocimiento(string mensaje, Usuario usuario)
        {
            foreach (var persona in _usuariosList)
            {
                // mensaje should not be received by any examiner who is sending the
                // meesage and also the receiver should be in the same departmento as the examiner sending it
                if (persona.Department == usuario.Department && !persona.EsEvaluador)
                {
                    persona.Recibir(mensaje, persona);
                }
            }
        }

    }

    public abstract class Usuario
    {
        public string Mensaje { get; set; }
        protected IDepartmentoMediator _mediador;

        public bool EsEvaluador;
        public string Nombre { get; set; }
        public string Department { get; set; }

        public Usuario(IDepartmentoMediator mediador,
                    string nombre,
                    string departmento,
                    bool esEvaluador)
        {
            _mediador = mediador;
            Nombre = nombre;
            EsEvaluador = esEvaluador;
            Department = departmento;
        }

        public abstract void EnviarReconocimiento(string mensaje, Usuario usuario);
        public abstract void EnviarNotificacionEstudiantes(string mensaje, Usuario usuario);
        public abstract void Recibir(string mensaje, Usuario usuario);
        public abstract void RegistrarTemas(string[] tema, Usuario usuario);
    }

    public class SchoolMember : Usuario
    {
        public SchoolMember(IDepartmentoMediator mediador,
                            string nombre,
                            string departmento,
                            bool esEvaluador) : base(mediador, nombre, departmento, esEvaluador)
        {
        }
        public override void Recibir(string mensaje, Usuario usuario)
        {
            Mensaje += usuario?.Nombre + ": mensaje recibido: " + mensaje;
        }

        public override void RegistrarTemas(string[] tema, Usuario usuario)
        {
            Mensaje += this.Nombre + ": Temas enviados: " + tema.Length +
                " temas enviados al departamento " + this.Department + "\n";

            var mensaje = tema.Length + " información enviada por " + this.Nombre +
                " y recibida por " + usuario.Nombre;
            _mediador.EnviarReconocimiento(mensaje, usuario);
        }

        public override void EnviarReconocimiento(string mensaje, Usuario usuario)
        {
            Mensaje += this.Nombre + ": Enviando mensaje: " + mensaje + "\n";
            _mediador.EnviarReconocimiento(mensaje, usuario);
        }

        public override void EnviarNotificacionEstudiantes(string mensaje, Usuario usuario)
        {
            Mensaje += this.Nombre + ": Enviando mensaje: " + mensaje + "\n";
            _mediador.EnviarMultipleReconocimiento(mensaje, usuario);
        }
    }

}
