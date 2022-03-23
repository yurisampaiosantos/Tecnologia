using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceSeizo
{
    public class OrdemProducao
    {
        private string numero_op_id;
         private string op_tipos_id;
        private string revisao;
        private string descricao_op;
        private string qtd_prevista;
        private string qtd_real;
        private string un_medida;
        private string status;
        private string observacao;
        private string nome_semiacabado;
        private decimal importacao_id;

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
        public string Op_Tipos_Id
        {
            get { return op_tipos_id; }
            set { op_tipos_id = value; }
        }
        public string Revisao
        {
            get { return revisao; }
            set { revisao = value; }
        }
        public string Descricao_Op
        {
            get { return descricao_op; }
            set { descricao_op = value; }
        }
        public string Qtd_Prevista
        {
            get { return qtd_prevista; }
            set { qtd_prevista = value; }
        }
        public string Qtd_Real
        {
            get { return qtd_real; }
            set { qtd_real = value; }
        }
        public string Un_Medida
        {
            get { return un_medida; }
            set { un_medida = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public string Observacao
        {
            get { return observacao; }
            set { observacao = value; }
        }
        public string Nome_Semiacabado
        {
            get { return nome_semiacabado; }
            set { nome_semiacabado = value; }
        }

        public void InserirDados(OrdemProducao ordemProducao)
        {
            string sql = "";
            sql += " INSERT INTO SZ_CARGA_OP  ( IMPORTACAO_ID,   NUMERO_OP_ID,      OP_TIPOS_ID,    REVISAO,    DESCRICAO,    QTD_PREVISTA,    QTD_REAL,    UN_MEDIDA,    STATUS_ID,   OBSERVACAO,     NOME_SEMIACABADO ) ";
            sql += "VALUES  (";
            sql += " " + ordemProducao.Importacao_id + ",";
            sql += " '" + ordemProducao.Numero_Op_Id + "',";
            sql += " '" + ordemProducao.Op_Tipos_Id + "',";
            sql += " '" + ordemProducao.Revisao + "',";
            sql += " '" + ordemProducao.Descricao_Op + "',";
            sql += " '" + ordemProducao.Qtd_Prevista + "',";
            sql += " '" + ordemProducao.Qtd_Real + "',";
            sql += " '" + ordemProducao.Un_Medida + "',";
            sql += " '" + ordemProducao.Status + "',";
            sql += " '" + ordemProducao.Observacao + "',";            
            sql += " '" + ordemProducao.Nome_Semiacabado + "'";
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