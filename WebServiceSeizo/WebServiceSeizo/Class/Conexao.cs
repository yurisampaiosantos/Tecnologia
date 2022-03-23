using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceSeizo
{
    public class Conexao
    {
        public static string StringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCDBDEV01)(PORT= 1521)))(CONNECT_DATA=(SID=CRP01DEV)(SERVER=DEDICATED)));User Id=ESEIZO;Password=seizENSE15";

        private byte[] _anexo;

        public byte[] Anexo
        {
            get { return _anexo; }
            set { _anexo = value; }
        }

        private string _nomeArquivo;

        public string NomeArquivo
        {
            get { return _nomeArquivo; }
            set { _nomeArquivo = value; }
        }
        public void SelecionarAnexo(decimal anexoId)
        {
            string sql = "";
            sql += " SELECT BLOB_CONTENT , FILENAME";
            sql += " FROM  SZ_IMPORTACAO";
            sql += " WHERE ID = " + anexoId;

            using (OleDbConnection conn = new OleDbConnection(Conexao.StringDeConexao))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    using (OleDbDataReader dataReader = cmd.ExecuteReader()) //IDataReader
                    {
                        if (dataReader.Read())
                        {
                            NomeArquivo = (string)dataReader["FILENAME"];
                            if (dataReader["BLOB_CONTENT"] != DBNull.Value)
                            {
                                Anexo = (Byte[])dataReader["BLOB_CONTENT"];
                            }
                        }
                    }
                }
                conn.Close();
            }
        }
    }
}