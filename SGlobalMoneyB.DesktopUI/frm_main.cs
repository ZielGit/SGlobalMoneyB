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
    public partial class frm_main : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;initial catalog=SGlobalMoneyB ;Integrated Security=true;");
        public frm_main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void abrirformulariohijo(object forhijo)
        {
            if (this.panel3.Controls.Count > 0)
                this.panel3.Controls.RemoveAt(0);

            Form fh = forhijo as Form;
            fh.TopLevel = false;
            this.panel3.Controls.Add(fh);
            this.panel3.Tag = fh;
            fh.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            abrirformulariohijo(new frm_usuarios_mnt());
            this.Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            abrirformulariohijo(new frm_reporte_usuarios());
            this.Cursor = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            abrirformulariohijo(new frm_grupos_mnt());
            this.Cursor = Cursors.Default;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string nombre_copia = (System.DateTime.Today.Day.ToString() + "-"+ System.DateTime.Today.Month.ToString() + "-" + System.DateTime.Today.Year.ToString() + "-" + System.DateTime.Now.Hour.ToString() + "-" + System.DateTime.Now.Minute.ToString() + "-" + System.DateTime.Now.Second.ToString() + "MiPrograma.bak" );

            string comando_consulta = "BACKUP DATABASE [SGlobalMoneyB] TO  DISK = N'D:\\" + nombre_copia + "' WITH NOFORMAT, NOINIT,  NAME = N'SGlobalMoneyB-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

            SqlCommand cmd = new SqlCommand(comando_consulta, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("La copia se realizo correctamente");
            }
            catch(Exception ex)
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
