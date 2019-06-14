using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCampeonato
{
    public partial class frmCadastroEstadio : Form
    {

        private BindingSource bnEstadio = new BindingSource();
        private bool bInclusao = false;
        private DataSet dsEstadio = new DataSet();

        public frmCadastroEstadio()
        {
            InitializeComponent();
        }

        private void btnNovoRegistro_Click(object sender, EventArgs e)
        {
            /*if (TabControl1.SelectedIndex == 0)
            {
                TabControl1.SelectedTab(1);
            }

            bnEstadio
            */


        }

        private void frmCadastroEstadio_Load(object sender, EventArgs e)
        {
            try
            {
                Estadio Est = new Estadio();
                dsEstadio.Tables.Add(Est.Listar());
                bnEstadio.DataSource = dsEstadio.Tables["TBEstadio"];
                dgvEstadio.DataSource = bnEstadio;
                bnvEstadio.BindingSource = bnEstadio;

                txtId.DataBindings.Add("TEXT", bnEstadio, "id_estadio");
                txtNomeEstadio.DataBindings.Add("TEXT", bnEstadio, "nome_Estadio");
                cbxEstado.DataBindings.Add("SelectedItem", bnEstadio, "uf_Estadio");

            }
            catch(Exception erro)
            {
                Console.WriteLine(erro);
            }
        }

        private void bnvEstadio_RefreshItems(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }
    }
}
