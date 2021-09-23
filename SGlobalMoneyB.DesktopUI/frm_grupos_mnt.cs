using SGlobalMoneyB.Core.Entidades;
using SGlobalMoneyB.Core.Entidades.ViewModel;
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

namespace SGlobalMoneyB.DesktopUI
{
    public partial class frm_grupos_mnt : Form
    {
        private GrupoRN grupoRN;
        private string buscarvariable;
        private BindingSource bindingSource_grupo = new BindingSource();
        public bool estado;
        public frm_grupos_mnt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            estado = true;
            panel2.Enabled = true;
            Tbx_Nombre.Focus();
            Tbx_Nombre.ResetText();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            #region Bloque que valida los objetos de entrada
            if (string.IsNullOrEmpty(Tbx_Nombre.Text))
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
                Grupo grupo = new Grupo { Nombre = Tbx_Nombre.Text };
                grupoRN.Agregar(grupo);
                MessageBox.Show("Datos Guardados");
            }
            else
            {
                Grupo grupo = grupoRN.Buscar(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));

                grupo.Nombre = Tbx_Nombre.Text;

                grupoRN.Modificar(grupo);
                MessageBox.Show("Datos actualizados con éxito...");
            }
            #endregion
        }

        private void frm_grupos_mnt_Load(object sender, EventArgs e)
        {
            grupoRN = new GrupoRN();
            bindingSource_grupo.DataSource = grupoRN.ListarGrupo();
            bindingNavigator1.BindingSource = bindingSource_grupo;

            dataGridView1.DataSource = bindingSource_grupo;
            dataGridView1.AutoResizeColumns();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                if (e.ColumnIndex > -1 && e.RowIndex > -1)
                {
                    estado = false;
                    Grupo grupo = grupoRN.Buscar(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));

                    Tbx_Nombre.Text = grupo.Nombre;

                    tabControl1.SelectedTab = tabPage2;
                }
            }
        }

        private void bindingNavigatorButton1_Click(object sender, EventArgs e)
        {
            frm_grupos_mnt_Load(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (Contexto_SGlobalMoneyB_DB db = new Contexto_SGlobalMoneyB_DB())
            {
                var lst = (from d in db.grupos
                           select new grupo
                           {
                               Id = d.Id,
                               Nombre = d.Nombre,
                           
                           }).AsQueryable();
                if (!toolStripTxbBuscar.Text.Trim().Equals(""))
                {
                    lst = lst.Where(d => d.Nombre.Contains(toolStripTxbBuscar.Text.Trim()));
                    buscarvariable = toolStripTxbBuscar.Text;
                }
                dataGridView1.DataSource = lst.ToList();
            }
        }
    }
}
