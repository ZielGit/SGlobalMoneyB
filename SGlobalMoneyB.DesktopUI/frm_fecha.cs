using SGlobalMoneyB.Core.Entidades;
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
    public partial class frm_fecha : Form
    {
        private FechaRN fechaRN;
        private string buscarvariable;
        private double procentaje = 0.10;
        public frm_fecha()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime Ingreso = Fecha_Ingreso.Value.Date;
            DateTime Final = Fecha_hoy.Value.Date;

            TimeSpan tspam = Ingreso - Final;
            int dias = tspam.Days;

            txtResultado.Text = dias.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
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
                               Fecha_Ingreso = d.Fecha_Ingreso,
                           }).AsQueryable();
                if (!txtName.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.Nombre.Contains(txtName.Text.Trim()));
                    buscarvariable = txtName.Text;
                }
                //txtMonto.Text = lst.Monto_Inicial.ToString();
                //falta logica
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double resultado;
            resultado = procentaje * Convert.ToInt32(txtMonto.Text) * Convert.ToInt32(txtResultado.Text);

            txtRetiro.Text = resultado.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fechaRN = new FechaRN();
            Fecha fecha = new Fecha
            {
                Fecha_retiro = Fecha_hoy.Value.Date,
                Dias = int.Parse(txtResultado.Text),
                Retiro = int.Parse(txtRetiro.Text),
            };
            fechaRN.Agregar(fecha);
            MessageBox.Show("Datos Guardados");
        }
    }
}
