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
        private double porciento;
        private int id_usuario;
        double ganancia;
        private UsuarioRN usuarioRN;
        SqlConnection con = new SqlConnection(@"Data Source=.;initial catalog=SGlobalMoneyB ;Integrated Security=true;");
        DataTable datos = new DataTable();
        public frm_fecha()
        {
            InitializeComponent();
            autocompletar();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //double resultado;
            //resultado = (porcentaje * Convert.ToInt32(txtMonto.Text)) * Convert.ToInt32(txtResultado.Text);
            double Monto = int.Parse(lblMonto.Text);
            for (int i=0;i<int.Parse(lblResultado.Text);i++)
            {
                ganancia =+ porcentaje * Monto;
                //ganancia++;
                Monto =+ Monto + ganancia;
                //Monto++;
            }
            lblRetiro.Text = Monto.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        void autocompletar()
        {
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT * FROM Usuarios",con);
            adaptador.Fill(datos);

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                lista.Add(datos.Rows[i]["DNI"].ToString());
            }
            txtName.AutoCompleteCustomSource = lista;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            string consulta = "SELECT * FROM Usuarios WHERE DNI='" + txtName.Text + "' ";

            SqlCommand comando = new SqlCommand(consulta, con);
            con.Open();

            SqlDataReader leer = comando.ExecuteReader();
            if (leer.Read() == true)
            {
                lblMonto.Text = leer["Monto_Inicial"].ToString();
                Fecha_Ingreso.Text = leer["Fecha_Ingreso"].ToString();
                lblNombre.Text = leer["Nombre"].ToString();
                lblApellido.Text = leer["Apellido"].ToString();
                lblDNI.Text = leer["DNI"].ToString();
                lblEdad.Text = leer["Edad"].ToString();
                lblCelular.Text = leer["Celular"].ToString();
                lblGenero.Text = leer["Genero"].ToString();
                lblGrupo.Text = leer["Grupo"].ToString();
                lblReferido.Text = leer["Referido"].ToString();
                lblHora.Text = leer["Hora"].ToString();
                lblID.Text = leer["Id"].ToString();
                //MessageBox.Show("El registro se ha encontrado");
            }
            else
            {
                MessageBox.Show("No existe");
            }
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DateTime Ingreso = Fecha_Ingreso.Value.Date;
            DateTime Final = DateTime.Now;

            TimeSpan tspam = Final - Ingreso;
            int dias = tspam.Days;

            lblResultado.Text = dias.ToString();
            porciento = dias * porcentaje;
            double Monto = int.Parse(lblMonto.Text);

            ganancia = (Monto * porciento) + Monto;

            lblRetiro.Text = ganancia.ToString();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBoxButtons botones = MessageBoxButtons.YesNo;
            DialogResult dr = MessageBox.Show("¿Esta Seguro que desea devolver la Inversion?", "Devolución", botones, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                usuarioRN = new UsuarioRN();
                Usuario usuario = usuarioRN.Buscar(int.Parse(lblID.Text));
                usuarioRN.Eliminar(usuario);
                MessageBox.Show("Retiro Completado");
            }
            else if (dr == DialogResult.No)
            {
                MessageBox.Show("Se cancelo de Devolución");
            }

        }
    }
}
