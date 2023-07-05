using pPatronesDiseño.Patrones.Estructurales.Adapter;
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
    public partial class fAdapter : Form
    {
        public fAdapter()
        {
            InitializeComponent();
        }

        private void btnAdapter_Click(object sender, EventArgs e)
        {
            IEmpleadoTarget empleado = new EmpleadoAdapter(new Empleados());
            Nomina nomina = new Nomina(empleado);
            nomina.MostrarEmpleados();
            grdEmpleados.DataSource = nomina.InformacionEmpleados;
        }
    }
}
