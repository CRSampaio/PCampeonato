using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace PCampeonato
{
    class Estadio
    {
        private int idEstadio;
        private string nomeEstadio;

        public int IdEstadio
        {
            get { return idEstadio; }
            set { idEstadio = value; }
        }
        public string NomeEstadio
        {
            get { return nomeEstadio; }
            set { nomeEstadio = value; }
        }
        public DataTable Listar()
        {
            SqlDataAdapter daEstadio;
            DataTable dtEstadio = new DataTable();
            try
            {
                daEstadio = new SqlDataAdapter("SELECT * FROM TIME", frmMenuPrincipal.conexao);
                daEstadio.Fill(dtEstadio)
            }
        }


    }
}
