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
    public partial class frmCadastroTime : Form
    {
        public frmCadastroTime()
        {
            InitializeComponent();
        }
        

        private void btnNovoRegistro_Click(object sender, EventArgs e)
        {
            // Verificar os erros e continuar a configurar os botões
            if (tabControl1.SelectedIndex == 0)
            {
                tabControl1.SelectedTab(1);
            }

            btnNovoRegistro.AddNew();
            txtNomeTime.Enabled = true;
            txtNomeTime.Focus();
            btnSalvar.Enabled = true;
            btnAlterar.Enabled = false;
            btnNovoRegistro.Enabled = false;
            btnExcluir.Enabled = false;
            btnCancelar.Enabled = true;

            btnNovoRegistro.Enabled = true ;
        }

        private void frmCadastriTime_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
