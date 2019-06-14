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
        private BindingSource bsJogo = new BindingSource();
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
                bsJogo.DataSource = dsJogo.Tables["Jogo"];
                dgvJogo.DataSource = bsJogo;
                bnvJogo.BindingSource = bsJogo;

                txtIdJogo.DataBindings.Add("TEXT", bsJogo, "id_jogo");
                dtpDataHora.DataBindings.Add("TEXT", bsJogo, "dthr_jogo");
                cbbEstadio.DataBindings.Add("SelectedValue", bsJogo, "estadio_id_estadio");
                cbbTime1.DataBindings.Add("SelectedValue", bsJogo, "time_id_time1");
                cbbTime2.DataBindings.Add("SelctedValue", bsJogo, "time_id_time2");
                cbbGrupo.DataBindings.Add("SelectedValue", bsJogo, "grupo_jogo");
                rtxtObs.DataBindings.Add("TEXT", bsJogo, "obs_jogo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNovoRegistro_Click(object sender, EventArgs e)
        {
            if (TabControl1.SelectedIndex == 0)
            {
                TabControl1.SelectTab(1);
            }

            bsJogo.AddNew();
            txtIdJogo.Enabled = true;
            dtpDataHora.Enabled = true;
            cbbEstadio.Enabled = true;
            cbbEstadio.SelectedIndex = 0;
            cbbTime1.Enabled = true;
            cbbTime1.SelectedIndex = 0;
            cbbTime2.Enabled = true;
            cbbTime2.SelectedIndex = 0;
            cbbGrupo.Enabled = true;
            cbbGrupo.SelectedIndex = 0;
            rtxtObs.Enabled = true;
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnNovoRegistro.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;
            bInclusao = true; ;

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (TabControl1.SelectedIndex == 0)
            {
                TabControl1.SelectTab(1);
            }


            if (MessageBox.Show("Confirma exclusão?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Jogo regJogo = new Jogo();

                regJogo.IdJogo = Convert.ToInt16(txtIdJogo.Text);

                if (regJogo.Excluir() > 0)
                {
                    MessageBox.Show("Jogo excluído com sucesso!");
                    Jogo R = new Jogo();
                    dsJogo.Tables.Clear();
                    dsJogo.Tables.Add(R.Listar());
                    bsJogo.DataSource = dsJogo.Tables["JOGO"];
                }
                else
                {
                    MessageBox.Show("Erro ao excluir jogo!");
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // validar os dados
            if (cbbEstadio.SelectedIndex == -1)
            {
                MessageBox.Show("É necessário selecionar um estádio!");
            }
            else if(cbbTime1.SelectedIndex == -1 | cbbTime2.SelectedIndex == -1)
            {
                MessageBox.Show("É necessário selecionar dois times!");
            }
            else if(cbbGrupo.SelectedIndex == -1)
            {
                MessageBox.Show("É necessário selecionar um grupo!");
            }
            else if(rtxtObs.Text == "" | rtxtObs.Text != null)
            {
                MessageBox.Show("Digite alguma observação! Exemplo (São Paulo só tem bambi! Ou Palmeiras não tem Mundial!)");
            }
            else
            {
                Jogo RegJogo = new Jogo();

                RegJogo.IdJogo = Convert.ToInt16(txtIdJogo.Text);
                //RegJogo.Nomecidade = txtNomeCidade.Text;
                //RegJogo.Ufcidade = cbxEstado.SelectedItem.ToString();

                if (bInclusao)
                {
                    if (RegJogo.Salvar() > 0)
                    {
                        MessageBox.Show("Jogo adicionado com sucesso!");

                        btnSalvar.Enabled = false;
                        txtIdJogo.Enabled = false;
                        dtpDataHora.Enabled = false;
                        cbbEstadio.Enabled = false;
                        cbbTime1.Enabled = false;
                        cbbTime2.Enabled = false;
                        cbbGrupo.Enabled = false;
                        rtxtObs.Enabled = false;
                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnNovoRegistro.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;

                        bInclusao = false;

                        // recarrega o grid
                        dsJogo.Tables.Clear();
                        dsJogo.Tables.Add(RegJogo.Listar());
                        bsJogo.DataSource = dsJogo.Tables["JOGO"];
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar jogo!");
                    }
                }
                else
                {
                    if (RegJogo.Alterar() > 0)
                    {
                        MessageBox.Show("Cidade alterada com sucesso!");

                        dsJogo.Tables.Clear();
                        dsJogo.Tables.Add(RegJogo.Listar());
                        txtIdJogo.Enabled = false;
                        txtNomeCidade.Enabled = false;
                        cbxEstado.Enabled = false;
                        btnSalvar.Enabled = false;
                        btnAlterar.Enabled = true;
                        btnNovoRegistro.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnCancelar.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Erro ao gravar cidade!");
                    }

                }
            }
        }
    }
}
