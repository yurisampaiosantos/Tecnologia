using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceSeizo
{
    public class Atributo
    {
        private string numero_op_id;
        private string valorAtributo;
        private decimal importacao_id;
        private string valor;
        public decimal Importacao_id
        {
            get { return importacao_id; }
            set { importacao_id = value; }
        }
        public string Numero_Op_Id
        {
            get { return numero_op_id; }
            set { numero_op_id = value; }
        }
        public string ValorAtributo
        {
            get { return valorAtributo; }
            set { valorAtributo = value; }
        }
        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public void InserirDados(Atributo atributo)
        {
            string sql = "";
            sql += " INSERT INTO SZ_CARGA_OP_ATRIBUTOS  (  IMPORTACAO_ID, NUMERO_OP_ID,    ATRIBUTOS_ID,    VALOR ) ";
            sql += "VALUES  (";
            sql += " " + atributo.Importacao_id + ",";
            sql += " '" + atributo.Numero_Op_Id + "',";
            sql += " '" + atributo.ValorAtributo + "',";
            sql += " '" + atributo.Valor + "'";
            sql += "        )";

            using (OleDbConnection conn = new OleDbConnection(Conexao.StringDeConexao))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}