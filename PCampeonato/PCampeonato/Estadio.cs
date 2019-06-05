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
                daEstadio = new SqlDataAdapter("SELECT * FROM ESTADIO", frmMenuPrincipal.conexao);
                daEstadio.Fill(dtEstadio);
                daEstadio.FillSchema(dtEstadio, SchemaType.Source);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtEstadio;
        }

        public int Salvar()
        {
            SqlCommand mycommand;
            int nReg = 0;
            int retorno = 0;
            try
            {
                mycommand = new SqlCommand("INSERT INTO ESTADIO VALUES (@nome_estadio)", frmMenuPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@nome_estadio", SqlDbType.VarChar));
                mycommand.Parameters["@nome_estadio"].Value = nomeEstadio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nReg;
        }

        public int Alterar()
        {
            int retorno = 0;
            SqlCommand mycommand;
            int nReg = 0;
            mycommand = new SqlCommand("UPDATE ESTADIO SET NOME_ESTADIO = @nome_estadio WHERE ID_ESTADIO = @id_estadio", frmMenuPrincipal.conexao);
            mycommand.Parameters.Add(new SqlParameter("@id_estadio", SqlDbType.Int));
            mycommand.Parameters.Add(new SqlParameter("@nome_estadio", SqlDbType.VarChar));
            mycommand.Parameters["@id_estadio"].Value = idEstadio;
            mycommand.Parameters["@nome_estadio"].Value = nomeEstadio;

            nReg = mycommand.ExecuteNonQuery();
            if(nReg > 0)
            {
                retorno = nReg;
            }
            return nReg;
        }

        public int Excluir()
        {
            int nReg = 0;
            SqlCommand mycommand;
            try
            {
                mycommand = new SqlCommand("DELETE FROM ESTADIO WHERE id_estadio=@id_estadio", frmMenuPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@id_estadio",
                    SqlDbType.Int));
                mycommand.Parameters["@id_estadio"].Value = idEstadio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nReg;
        }


    }
}
