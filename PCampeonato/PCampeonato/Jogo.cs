using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCampeonato
{
    class Jogo
    {
        private int idJogo;
        private string nomeJogo;
        private DateTime dthrJogo;
        private int estadioIdEstadio;
        private int timeIdTime1;
        private int timeIdTime2;
        private char grupoJogo;
        private string obsJogo;


        public int IdJogo
        {
            get { return idJogo; }
            set { idJogo = value; }
        }
        public string NomeJogo
        {
            get { return nomeJogo; }
            set { nomeJogo = value; }
        }

        public DateTime DthrJogo
        {
            get { return dthrJogo; }
            set { dthrJogo = value; }
        }

        public int EstadioIdEstadio
        {
            get { return estadioIdEstadio; }
            set { estadioIdEstadio = value; }
        }

        public int TimeIdTime1
        {
            get { return timeIdTime1; }
            set { timeIdTime1 = value; }
        }

        public int TimeIdTime2
        {
            get { return timeIdTime2; }
            set { timeIdTime2 = value; }
        }

        public char GrupoJogo
        {
            get { return grupoJogo; }
            set { grupoJogo = value; }
        }

        public string ObsJogo
        {
            get { return obsJogo; }
            set { obsJogo = value; }
        }

        public DataTable Listar()
        {
            SqlDataAdapter daJogo;
            DataTable dtJogo = new DataTable();
            try
            {
                daJogo = new SqlDataAdapter("SELECT * FROM JOGO", frmMenuPrincipal.conexao);
                daJogo.Fill(dtJogo);
                daJogo.FillSchema(dtJogo, SchemaType.Source);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtJogo;
        }
        public int Salvar()
        {
            SqlCommand mycommand;
            int nReg = 0;
            int retorno = 0;
            try
            {
                mycommand = new SqlCommand("INSERT INTO JOGO VALUES (@dthr_jogo, @estadio_id_estadio, @time_id_time, @time_id_time2, @grupo_jogo, @obs_jogo)",
                    frmMenuPrincipal.conexao);

                mycommand.Parameters.Add(new SqlParameter("@dthr_jogo", SqlDbType.DateTime));
                mycommand.Parameters.Add(new SqlParameter("@estadio_id_estadio", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@time_id_time1", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@time_id_time2", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@grupo_jogo", SqlDbType.Char));
                mycommand.Parameters.Add(new SqlParameter("@obs_jogo", SqlDbType.VarChar));


                mycommand.Parameters["@dthr_jogo"].Value = dthrJogo;
                mycommand.Parameters["@estadio_id_estadio"].Value = dthrJogo;
                mycommand.Parameters["@time_id_time1"].Value = timeIdTime1;
                mycommand.Parameters["@time_id_time2"].Value = timeIdTime2;
                mycommand.Parameters["@grupo_jogo"].Value = grupoJogo;
                mycommand.Parameters["@obs_jogo"].Value = obsJogo;

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
            mycommand = new SqlCommand("UPDATE JOGO SET dthr_jogo = @dthr_jogo, estadio_id_estadio = @estadio_id_estadio, time_id_time1 = @time_id_time1, time_id_time2 = @time_id_time2, grupo_jogo = @grupo_jogo, obs_jogo = @obs_jogo WHERE id_jogo = @id_jogo", frmMenuPrincipal.conexao);
            mycommand.Parameters.Add(new SqlParameter("@id_jogo", SqlDbType.Int));
            mycommand.Parameters.Add(new SqlParameter("@dthr_jogo", SqlDbType.DateTime));
            mycommand.Parameters.Add(new SqlParameter("@estadio_id_estadio", SqlDbType.Int));
            mycommand.Parameters.Add(new SqlParameter("@time_id_time1", SqlDbType.Int));
            mycommand.Parameters.Add(new SqlParameter("@time_id_time2", SqlDbType.Int));
            mycommand.Parameters.Add(new SqlParameter("@grupo_jogo", SqlDbType.Char));
            mycommand.Parameters.Add(new SqlParameter("@obs_jogo", SqlDbType.VarChar));


            mycommand.Parameters["@id_jogo"].Value = idJogo;
            mycommand.Parameters["@dthr_jogo"].Value = dthrJogo;
            mycommand.Parameters["@estadio_id_estadio"].Value = EstadioIdEstadio;
            mycommand.Parameters["@time_id_time1"].Value = timeIdTime1;
            mycommand.Parameters["@time_id_time2"].Value = timeIdTime2;
            mycommand.Parameters["@grupo_jogo"].Value = grupoJogo;
            mycommand.Parameters["@obs_jogo"].Value = obsJogo;

            nReg = mycommand.ExecuteNonQuery();
            if (nReg > 0)
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
                mycommand = new SqlCommand("DELETE FROM JOGO WHERE id_jogo = @id_jogo", frmMenuPrincipal.conexao);
                mycommand.Parameters.Add(new SqlParameter("@id_time",
                    SqlDbType.Int));
                mycommand.Parameters["@id_time"].Value = idJogo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nReg;
        }
    }
}
