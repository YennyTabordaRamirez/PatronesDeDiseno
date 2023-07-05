using pPatronesDiseño.Patrones.Comportamiento.Mediator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pPatronesDiseño
{
    public partial class fMediator : Form
    {
        public fMediator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DepartmentGroupMediator departmentMediator = new DepartmentGroupMediator();
            //Instantiate students
            Usuario Estudiante1 = new SchoolMember(departmentMediator, "Carlos Botero", "Sistemas", false);
            Usuario Estudiante2 = new SchoolMember(departmentMediator, "Maria Rojas", "Mecánica", false);
            Usuario Estudiante3 = new SchoolMember(departmentMediator, "Fabio Morales", "Mecánica", false);

            //Instantiate Examiners
            Usuario Examinador1 = new SchoolMember(departmentMediator, "Felipe Martinez", "Sistemas", true);
            Usuario Examinador2 = new SchoolMember(departmentMediator, "Andres Salazar", "Mecánica", true);

            departmentMediator.RegistrarUsuario(Estudiante1);
            departmentMediator.RegistrarUsuario(Estudiante2);
            departmentMediator.RegistrarUsuario(Estudiante3);
            departmentMediator.RegistrarUsuario(Examinador1);
            departmentMediator.RegistrarUsuario(Examinador2);

            Estudiante1.EnviarReconocimiento("Buenas tardes profesor, Me gustaría registrar los temas hoy", Examinador1);
            lblMensaje.Text += Estudiante1.Mensaje;
            Examinador2.EnviarReconocimiento("Junio 30 es la fecha límite para registrar los temas. ", Examinador2);
            lblMensaje.Text += Examinador2.Mensaje;
            Examinador1.EnviarReconocimiento("Lo puedes hacer, estamos a tiempo.", Estudiante1);
            lblMensaje.Text += Examinador1.Mensaje;
            Estudiante3.EnviarReconocimiento("Ok, lo haré inmediatamente", Examinador2);
            lblMensaje.Text += Estudiante3.Mensaje;

            //list of subjects to register
            string[] TemasComputacionales = { "Java", "C#", "Phython", "MS Sql" };
            Estudiante1.RegistrarTemas(TemasComputacionales, Examinador1);
            lblMensaje.Text += Estudiante1.Mensaje;
            string[] TemasBasicos = { "Inglés", "Ciencia de los materiales", "Cálculo" };
            Estudiante3.RegistrarTemas(TemasBasicos, Examinador2);
            lblMensaje.Text += Estudiante3.Mensaje;
        }
    }
}
