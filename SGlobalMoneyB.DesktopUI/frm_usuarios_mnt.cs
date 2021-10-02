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
        SqlConnection con = new SqlConnection(@"Data Source=.;initial catalog=SGlobalMoneyB ;Integrated Security=true;");
        public bool estado;
        public frm_usuarios_mnt()
        {
            InitializeComponent();
            cargarGrupo();
            //cargarReferido();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            estado = true;
            panel2.Enabled = true;
            txtbNombre.Focus();
            txtbNombre.ResetText();
            txtbApellido.Clear();
            txtbDNI.Clear();
            txtbEdad.Clear();
            txtbGenero.Clear();
            txtbCelular.Clear();
            txtbDireccion.Clear();
            txtbMonto.Clear();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            #region Bloque que valida los objetos de entrada
            if (string.IsNullOrEmpty(txtbNombre.Text) || string.IsNullOrEmpty(txtbDNI.Text) || string.IsNullOrEmpty(txtbEdad.Text)
                || string.IsNullOrEmpty(txtbGenero.Text) || string.IsNullOrEmpty(txtbCelular.Text) //|| string.IsNullOrEmpty(comboBox1.Text)
                || string.IsNullOrEmpty(txtbDireccion.Text) || string.IsNullOrEmpty(txtbMonto.Text) //|| string.IsNullOrEmpty(comboBox2.Text)
                || string.IsNullOrEmpty(dateTimeFIngreso.Text))
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
                var grupo = (Grupo)comboGrupo.SelectedItem;
                var referido = (Referido)comboReferido.SelectedItem;

                usuarioRN = new UsuarioRN();
                Usuario usuario = new Usuario
                {
                    Nombre = txtbNombre.Text,
                    Apellido = txtbApellido.Text,
                    DNI = txtbDNI.Text,
                    Edad = int.Parse(txtbEdad.Text),
                    Genero = txtbGenero.Text,
                    Celular = int.Parse(txtbCelular.Text),
                    Direccion = txtbDireccion.Text,
                    Monto_Inicial = int.Parse(txtbMonto.Text),
                    Fecha_Ingreso = dateTimeFIngreso.Value.Date,
                    Hora = DateTime.Now.ToLongTimeString(),
                    //referido = comboReferido.Text,
                    //grupo = comboGrupo.Text,
                    Grupo = grupo
                };
                usuarioRN.Agregar(usuario);
                MessageBox.Show("Datos Guardados");
            }
            else
            {
                Usuario usuario = usuarioRN.Buscar(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));

                usuario.Nombre = txtbNombre.Text;
                usuario.Apellido = txtbApellido.Text;
                usuario.DNI = txtbDNI.Text;
                usuario.Edad = int.Parse(txtbEdad.Text);
                usuario.Genero = txtbGenero.Text;
                usuario.Celular = int.Parse(txtbCelular.Text);
                //usuario.referido = comboReferido.Text;
                usuario.Direccion = txtbDireccion.Text;
                usuario.Monto_Inicial = int.Parse(txtbMonto.Text);
                usuario.grupo = comboGrupo.Text;
                usuario.Fecha_Ingreso = dateTimeFIngreso.Value.Date;

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

                    txtbNombre.Text = usuario.Nombre;
                    txtbApellido.Text = usuario.Apellido;
                    txtbDNI.Text = usuario.DNI;
                    txtbEdad.Text = usuario.Edad.ToString();
                    txtbGenero.Text = usuario.Genero;
                    txtbCelular.Text = usuario.Celular.ToString();
                    comboReferido.Text = usuario.referido;
                    txtbDireccion.Text = usuario.Direccion;
                    txtbMonto.Text = usuario.Monto_Inicial.ToString();
                    comboGrupo.Text = usuario.grupo;
                    dateTimeFIngreso.Text = usuario.Fecha_Ingreso.ToString();

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
        
        public void cargarGrupo()
        {
            using (Contexto_SGlobalMoneyB_DB db = new Contexto_SGlobalMoneyB_DB())
            {
                var listagrupo = (from d in db.grupos select d).ToList();
                comboGrupo.DataSource = listagrupo;

                comboGrupo.DisplayMember = "Nombre";
                comboGrupo.ValueMember = "Id";
            }
        }

        public void cargarReferido()
        {
            using (Contexto_SGlobalMoneyB_DB db = new Contexto_SGlobalMoneyB_DB())
            {
                var listareferido = (from d in db.referidos select d).ToList();
                comboGrupo.DataSource = listareferido;

                comboGrupo.DisplayMember = "Nombre";
                comboGrupo.ValueMember = "Id";
            }
        }

        //public void cargar_grupos()
        //{
            
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("SELECT Id, Nombre FROM Grupoes", con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();

        //    DataRow fila = dt.NewRow();
        //    fila["Nombre"] = "SELECCIONE UNA OPCION";
        //    dt.Rows.InsertAt(fila, 0);

        //    comboGrupo.ValueMember = "Id";
        //    comboGrupo.DisplayMember = "Nombre";
        //    comboGrupo.DataSource = dt;
        //}

        //public void cargar_referidos()
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("SELECT Id, Nombre FROM Referidoes", con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();

        //    DataRow fila = dt.NewRow();
        //    fila["Nombre"] = "SELECCIONE UNA OPCION";
        //    dt.Rows.InsertAt(fila, 0);

        //    comboReferido.ValueMember = "Id";
        //    comboReferido.DisplayMember = "Nombre";
        //    comboReferido.DataSource = dt;
        //}
    }
}
