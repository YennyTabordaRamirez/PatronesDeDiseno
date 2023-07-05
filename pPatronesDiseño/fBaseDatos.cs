using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using pPatronesDiseño.Patrones.Clases;
using pPatronesDiseño.Patrones.Creacionales.Abstract_Factory;
using pPatronesDiseño.Patrones.Estructurales.Adapter;
using System.Xml.Linq;
using pPatronesDiseño.Patrones.Comportamiento.Mediator;

namespace pPatronesDiseño
{
    public partial class fBaseDatos : Form
    {

        private IDbAdapterDB dbAdapter;

        public fBaseDatos()
        {
            InitializeComponent();

            // Configura el control de selección            
            cboBaseDatos.Items.Add("MySQL");
            cboBaseDatos.Items.Add("Access");
            cboBaseDatos.SelectedIndex = 0; // Establece el valor predeterminado

            cboPatron.Items.Add("Adapter");
            cboPatron.Items.Add("Mediator");
            cboPatron.SelectedIndex = 0;
        }


        private void btnInsertar_Click(object sender, EventArgs e)
        {
            // Crear o actualizar una entidad según el ID proporcionado
            string name = txtNombre.Text;
            string apellido = txtApellido.Text;
            int age = Convert.ToInt32(txtEdad.Text);
            EmpleadoEntity entity = new EmpleadoEntity { Nombre = name, Apellido = apellido, Edad = age };

            // Obtén la opción seleccionada por el usuario
            string selectedDatabase = cboBaseDatos.SelectedItem.ToString();

            string selectPatter = cboPatron.SelectedItem.ToString();

            if (selectPatter == "Adapter")
            {
                switch (selectedDatabase)
                {
                    case "SQL Server":
                        dbAdapter = new SqlServerAdapter();
                        break;
                    case "MySQL":
                        dbAdapter = new MySqlAdapter();
                        break;
                    case "Access":
                        dbAdapter = new AccessAdapter();
                        break;
                    default:
                        // Manejo de error si no se selecciona ninguna opción válida
                        MessageBox.Show("Selecciona una base de datos válida");
                        dbAdapter.Desconectar();
                        return;
                }

                dbAdapter.Conectar();

                dbAdapter.Insertar(entity);

                dbAdapter.Desconectar();
            }

            if(selectPatter == "Mediator")
            {
                switch (selectedDatabase)
                {
                    case "MySQL":
                        entity.TipoBaseDatos = TipoBaseDatos.MySql;
                        break;
                    case "Access":
                        entity.TipoBaseDatos = TipoBaseDatos.Access;
                        break;
                }

                string mySqlConnectionString = "Server=localhost;Port=3307;Database=prueba;Uid=root;Pwd=;"; //cambiar
                MySqlDatabase mySqlDatabase = new MySqlDatabase(mySqlConnectionString);

                string accessConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\PERSONAL\prueba.accdb;"; //cambiar
                AccessDatabase accessDatabase = new AccessDatabase(accessConnectionString);


                ConcreteMediator mediator = new ConcreteMediator(accessDatabase, mySqlDatabase);

                // Insertar el empleado usando el mediador
                mediator.InsertarEmpleado(entity);

            }

            MessageBox.Show("Se guardo correctamente");

            // Limpiar los campos después de guardar

            txtNombre.Text = "";
            txtEdad.Text = "";
            txtApellido.Text = "";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        }

        private void fBaseDatos_Load(object sender, EventArgs e)
        {
        }

    }
}
