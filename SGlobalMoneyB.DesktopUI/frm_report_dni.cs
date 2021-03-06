using SGlobalMoneyB.Core.Entidades;
using SGlobalMoneyB.Core.Entidades.ViewModel;
using SGlobalMoneyB.Infraestructura.ContextoDB;
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
    public partial class frm_report_dni : Form
    {
        public string buscar;
        //public int id = 0;
        public frm_report_dni()
        {
            InitializeComponent();
        }

        private void frm_report_dni_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
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
                               grupo = d.grupo,
                               referido = d.referido,
                               Fecha_Ingreso = d.Fecha_Ingreso
                           }).AsQueryable();
                if (!buscar.Equals(""))
                {
                    lst = lst.Where(d => d.DNI.Contains(buscar.Trim().Trim()));
                }
                oReporteUsuarioBindingSource.DataSource = lst.ToList();
            }

        }
    }
}
