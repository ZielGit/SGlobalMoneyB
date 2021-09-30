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
    public partial class frm_backup : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;initial catalog=SGlobalMoneyB ;Integrated Security=true;");
        public frm_backup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre_copia = (System.DateTime.Today.Day.ToString() + "-" + System.DateTime.Today.Month.ToString() + "-" + System.DateTime.Today.Year.ToString() + "-" + System.DateTime.Now.Hour.ToString() + "-" + System.DateTime.Now.Minute.ToString() + "-" + System.DateTime.Now.Second.ToString() + "MiPrograma.bak");

            string comando_consulta = "BACKUP DATABASE [SGlobalMoneyB] TO  DISK = N'D:\\" + nombre_copia + "' WITH NOFORMAT, NOINIT,  NAME = N'SGlobalMoneyB-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

            SqlCommand cmd = new SqlCommand(comando_consulta, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("La copia se realizo correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Si desea realizar otra copia, cierre el formulario y intentelo denuevo");
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}
