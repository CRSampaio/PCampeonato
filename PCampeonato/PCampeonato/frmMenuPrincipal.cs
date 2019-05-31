using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PCampeonato
{
    public partial class frmMenuPrincipal : Form
    {
        public static SqlConnection conexao;
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection("Data Source=apolo;Initial Catalog=LP2;User ID=BD1823009; Password = inf$2019;");
                //Usar a conexão abaixo no PC de casa ou não seila
                //conexao = new SqlConnection("Data Source=apolo;Initial Catalog=LP2;User ID=BD1823009");
                conexao.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro de banco de dados \n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Outros Erros \n" + ex.Message);
            }
        }
    }
}
