using SGlobalMoneyB.Core.Entidades;
using SGlobalMoneyB.Infraestructura.ReglasNegocio;
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
using SGlobalMoneyB.Core.Entidades.ViewModel;
using System.Data.SqlClient;

namespace SGlobalMoneyB.DesktopUI
{
    public partial class frm_usuarios_mnt : Form
    {
        private UsuarioRN usuarioRN;
        private string buscarvariable;
        private BindingSource bindingSource_usuario = new BindingSource();
        //Contexto_SGlobalMoneyB_DB contexto;
        SqlConnection con = new SqlConnection(@"Data Source=.;initial catalog=SGlobalMoneyB ;Integrated Security=true;");
        public bool estado;
        public frm_usuarios_mnt()
        {
            InitializeComponent();
            cargar_grupos();
            cargar_referidos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            estado = true;
            panel2.Enabled = true;
            Tbx_Nombre.Focus();
            Tbx_Nombre.ResetText();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            //textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            //textBox10.Clear();
            //textBox11.Clear();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            #region Bloque que valida los objetos de entrada
            if (string.IsNullOrEmpty(Tbx_Nombre.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text)
                || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(comboBox1.Text)
                || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox9.Text) || string.IsNullOrEmpty(comboBox2.Text)
                || string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                panel2.BackColor = Color.FromArgb(219, 81, 69);
                MessageBox.Show("Completa los Datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(panel2, "Completa los Datos");
                return;
            }
            else
            {
                errorProvider1.SetError(panel2, string.Empty);
                panel2.BackColor = Color.FromArgb(255, 255, 255);
            }
            #endregion

            #region Haciendo datos persistentes en el contexto (BD)
            if (estado)
            {
                usuarioRN = new UsuarioRN();
                Usuario usuario = new Usuario
                {
                    Nombre = Tbx_Nombre.Text,
                    Apellido = textBox1.Text,
                    DNI = textBox2.Text,
                    Edad = int.Parse(textBox3.Text),
                    Genero = textBox4.Text,
                    Celular = int.Parse(textBox5.Text),
                    referido = comboBox1.Text,
                    Direccion = textBox8.Text,
                    Monto_Inicial = int.Parse(textBox9.Text),
                    grupo = comboBox2.Text,
                    Fecha_Ingreso = dateTimePicker1.Value.Date
                };
                usuarioRN.Agregar(usuario);
                MessageBox.Show("Datos Guardados");
            }
            else
            {
                Usuario usuario = usuarioRN.Buscar(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));

                usuario.Nombre = Tbx_Nombre.Text;
                usuario.Apellido = textBox1.Text;
                usuario.DNI = textBox2.Text;
                usuario.Edad = int.Parse(textBox3.Text);
                usuario.Genero = textBox4.Text;
                usuario.Celular = int.Parse(textBox5.Text);
                usuario.referido = comboBox1.Text;
                usuario.Direccion = textBox8.Text;
                usuario.Monto_Inicial = int.Parse(textBox9.Text);
                usuario.grupo = comboBox2.Text;
                usuario.Fecha_Ingreso = dateTimePicker1.Value.Date;

                usuarioRN.Modificar(usuario);
                MessageBox.Show("Datos actualizados con éxito...");
            }
            #endregion
        }

        private void bindingNavigatorButton1_Click(object sender, EventArgs e)
        {
            frm_usuarios_mnt_Load(sender, e);
        }

        private void frm_usuarios_mnt_Load(object sender, EventArgs e)
        {
            usuarioRN = new UsuarioRN();
            bindingSource_usuario.DataSource = usuarioRN.ListarUsuario();
            bindingNavigator1.BindingSource = bindingSource_usuario;

            dataGridView1.DataSource = bindingSource_usuario;
            dataGridView1.AutoResizeColumns();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                if (e.ColumnIndex > -1 && e.RowIndex > -1)
                {
                    estado = false;
                    Usuario usuario = usuarioRN.Buscar(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));

                    Tbx_Nombre.Text = usuario.Nombre;
                    textBox1.Text = usuario.Apellido;
                    textBox2.Text = usuario.DNI;
                    textBox3.Text = usuario.Edad.ToString();
                    textBox4.Text = usuario.Genero;
                    textBox5.Text = usuario.Celular.ToString();
                    comboBox1.Text = usuario.referido;
                    textBox8.Text = usuario.Direccion;
                    textBox9.Text = usuario.Monto_Inicial.ToString();
                    comboBox2.Text = usuario.grupo;
                    dateTimePicker1.Text = usuario.Fecha_Ingreso.ToString();

                    tabControl1.SelectedTab = tabPage2;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
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
                               //Grupo = d.Grupo.Id.ToString(),
                               //Referido = d.Referido.Id.ToString()
                           }).AsQueryable();
                if (!toolStripTextNombre.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.Nombre.Contains(toolStripTextNombre.Text.Trim()));
                    buscarvariable = toolStripTextNombre.Text;
                }
                dataGridView1.DataSource = lst.ToList();
            }
        }
        
        public void cargar_grupos()
        {
            
            con.Open();
            //Contexto_SGlobalMoneyB_DB contexto = new Contexto_SGlobalMoneyB_DB();
            //contexto.Open();
            SqlCommand cmd = new SqlCommand("SELECT Id, Nombre FROM Grupoes", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            DataRow fila = dt.NewRow();
            fila["Nombre"] = "SELECCIONE UNA OPCION";
            dt.Rows.InsertAt(fila, 0);

            comboBox2.ValueMember = "Id";
            comboBox2.DisplayMember = "Nombre";
            comboBox2.DataSource = dt;
        }

        public void cargar_referidos()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Id, Nombre FROM Referidoes", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            DataRow fila = dt.NewRow();
            fila["Nombre"] = "SELECCIONE UNA OPCION";
            dt.Rows.InsertAt(fila, 0);

            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Nombre";
            comboBox1.DataSource = dt;
        }
    }
}
