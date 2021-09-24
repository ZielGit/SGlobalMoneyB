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
                //errorProvider1.SetError(Nombre, string.Empty);
                using (Contexto_SGlobalMoneyB_DB db = new Contexto_SGlobalMoneyB_DB())
                {
                    var lst = (from d in db.usuarios
                               select new usuario
                               {
                                   Id = d.Id,
                                   Nombre = d.Nombre,
                                   Apellido = d.Apellido,
                                   DNI = d.DNI,
                                   Edad = d.Edad,
                                   Genero = d.Genero,
                                   Celular = d.Celular,
                                   Direccion = d.Direccion,
                                   Monto_Inicial = d.Monto_Inicial,
                                   Fecha_Ingreso = d.Fecha_Ingreso
                               }).AsQueryable();
                    if (!Nombre.Text.Trim().Equals(""))
                    {
                        lst = lst.Where(d => d.Nombre.Contains(Nombre.Text.Trim()));
                    }
                    oReporteUsuarioBindingSource.DataSource = lst.ToList();
                }
                reportViewer1.RefreshReport();
            }
        }

        private void frm_reporte_usuarios_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
