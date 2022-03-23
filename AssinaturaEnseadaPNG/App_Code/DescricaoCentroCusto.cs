using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace AssinaturaEnseadaPNG
{
    public class DescricaoCentroCusto
    {
        private static string StringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCRAC2-SCAN.intranet.local)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=CRP01.intranet.local)(SERVER=DEDICATED)));User Id=F_APP_ORC;Password=orcHersPrdOra";

        private string descricaoPortugues;

        private string descricaoIngles;

        public string DescricaoPortugues
        {
            get
            {
                return descricaoPortugues;
            }

            set
            {
                descricaoPortugues = value;
            }
        }

        public string DescricaoIngles
        {
            get
            {
                return descricaoIngles;
            }

            set
            {
                descricaoIngles = value;
            }
        }

        //referente ao contrato
        public DescricaoCentroCusto SelecionarAnexoContrato(string centroCusto)
        {
            DescricaoCentroCusto descricaoCentroCusto = new DescricaoCentroCusto();
            string sql = "";
            sql += " SELECT DESCRICAO , DESCRICAO_INGLES";
            sql += " FROM SAP_FI.Z_DE_PARA_CENTRO_CUSTO";
            sql += " WHERE CENTRO_CUSTO = '" + centroCusto + "'";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(StringDeConexao))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataReader dataReader = cmd.ExecuteReader()) //IDataReader
                        {
                            if (dataReader.Read())
                            {
                                    if (dataReader["DESCRICAO"] != DBNull.Value)
                                    {
                                       descricaoCentroCusto.descricaoPortugues = (string)dataReader["DESCRICAO"];
                                    }
                                    if (dataReader["DESCRICAO_INGLES"] != DBNull.Value)
                                    {
                                       descricaoCentroCusto.DescricaoIngles = (string)dataReader["DESCRICAO_INGLES"];
                                    }

                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return descricaoCentroCusto;
        }
    }
}