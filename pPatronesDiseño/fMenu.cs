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
using pPatronesDiseño.Patrones.Estructurales.Adapter;

namespace pPatronesDiseño
{
    public partial class fMenu : Form
    {
        public fMenu()
        {
            InitializeComponent();
        }
        private void btnAdapter_Click(object sender, EventArgs e)
        {
            fAdapter adapter = new fAdapter();
            adapter.Show();
        }
        private void btnBaseDatos_Click(object sender, EventArgs e)
        {
            fBaseDatos fBaseDatos = new fBaseDatos();
            fBaseDatos.Show();
        }
        private void btnMediator_Click(object sender, EventArgs e)
        {
            fMediator fmediator = new fMediator();
            fmediator.Show();
        }
    }
}
