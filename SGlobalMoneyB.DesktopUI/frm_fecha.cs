using SGlobalMoneyB.Core.Entidades;
using SGlobalMoneyB.Core.Entidades.ViewModel;
using SGlobalMoneyB.Infraestructura.ContextoDB;
using SGlobalMoneyB.Infraestructura.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private double porcentaje = 0.10;
        double ganancia;
        SqlConnection con = new SqlConnection(@"Data Source=.;initial catalog=SGlobalMoneyB ;Integrated Security=true;");
        public frm_fecha()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime Ingreso = Fecha_Ingreso.Value.Date;
            DateTime Final = Fecha_hoy.Value.Date;

            TimeSpan tspam = Final - Ingreso;
            int dias = tspam.Days;

            txtResultado.Text = dias.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string consulta = "SELECT * FROM Usuarios WHERE Id='" + txtName.Text + "' ";

            SqlCommand comando = new SqlCommand(consulta, con);
            con.Open();

            SqlDataReader leer = comando.ExecuteReader();
            if(leer.Read() == true)
            {
                txtMonto.Text = leer["Monto_Inicial"].ToString();
                Fecha_Ingreso.Text = leer["Fecha_Ingreso"].ToString();
                //MessageBox.Show("El registro se ha encontrado");
            }
            else
            {
                MessageBox.Show("No existe");
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //double resultado;
            //resultado = (porcentaje * Convert.ToInt32(txtMonto.Text)) * Convert.ToInt32(txtResultado.Text);
            double Monto = int.Parse(txtMonto.Text);
            for (int i=0;i<int.Parse(txtResultado.Text);i++)
            {
                ganancia =+ porcentaje * Monto;
                //ganancia++;
                Monto =+ Monto + ganancia;
                //Monto++;
            }
            txtRetiro.Text = Monto.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            fechaRN = new FechaRN();
            Fecha fecha = new Fecha
            {
                Fecha_retiro = Fecha_hoy.Value.Date,
                Dias = int.Parse(txtResultado.Text),
                Retiro = Double.Parse(txtRetiro.Text)
            };
            fechaRN.Agregar(fecha);
            MessageBox.Show("Datos Guardados");
        }
    }
}
