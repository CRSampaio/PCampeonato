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
    public partial class frmCadastroJogo : Form
    {
        private BindingSource bnJogo = new BindingSource();
        private bool bInclusao = false;
        private DataSet dsJogo = new DataSet();

        public frmCadastroJogo()
        {
            InitializeComponent();
        }

        private void frmCadastroJogo_Load(object sender, EventArgs e)
        {

            try
            {
                Jogo jogo = new Jogo();
                dsJogo.Tables.Add(jogo.Listar());
                bnJogo.DataSource = dsJogo.Tables["Jogo"];
                dgvJogo.DataSource = bnJogo;
                bnvJogo.BindingSource = bnJogo;

                txtIdJogo.DataBindings.Add("TEXT", bnJogo, "id_jogo");
                dtpDataJogo.DataBindings.Add("TEXT", bnJogo, "dthr_jogo");
                cbbEstadio.DataBindings.Add("SelectedValue", bnJogo, "estadio_id_estadio");
                cbbTime1.DataBindings.Add("SelectedValue", bnJogo, "time_id_time1");
                cbbTime2.DataBindings.Add("SelctedValue", bnJogo, "time_id_time2");
                cbbGrupo.DataBindings.Add("SelectedValue", bnJogo, "grupo_jogo");
                rtxtObs.DataBindings.Add("TEXT", bnJogo, "obs_jogo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovoRegistro_Click(object sender, EventArgs e)
        {

        }
    }
}
