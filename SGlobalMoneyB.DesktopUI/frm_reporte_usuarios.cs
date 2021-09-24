using SGlobalMoneyB.Core.Entidades.ViewModel;
using SGlobalMoneyB.Infraestructura.ContextoDB;
using SGlobalMoneyB.Infraestructura.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGlobalMoneyB.DesktopUI
{
    public partial class frm_reporte_usuarios : Form
    {
        Reportes reportes;
        //public int id;
        public frm_reporte_usuarios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Nombre.Text))
            {
                Nombre.BackColor = Color.FromArgb(219, 81, 69);
                MessageBox.Show("Completa los Datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(Nombre, "Completa los Datos");
                return;
            }
            else
            {
                frm_report_nombre dni = new frm_report_nombre();
                dni.buscar = Nombre.Text;
                dni.ShowDialog();
            }
        }

        private void frm_reporte_usuarios_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(DNI.Text))
            {
                DNI.BackColor = Color.FromArgb(219, 81, 69);
                MessageBox.Show("Completa los Datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(DNI, "Completa los Datos");
                return;
            }
            else
            {
                //errorProvider1.SetError(Nombre, string.Empty);
                frm_report_dni dni = new frm_report_dni();
                //id = int.Parse(dni.Text);
                dni.buscar = DNI.Text;
                dni.ShowDialog();

            }
        }
    }
}
