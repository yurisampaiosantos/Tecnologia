using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace WebServiceSeizo
{
    public class Item
    {
        private string numero_op_id;
        private string sap_material;
        private string qtd_projeto;
        private string qtd_corrida;
        private string qtd_reservada;
        private string qtd_aplicada;
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
        public string Sap_Material
        {
            get { return sap_material; }
            set { sap_material = value; }
        }
        public string Qtd_Projeto
        {
            get { return qtd_projeto; }
            set { qtd_projeto = value; }
        }
        public string Qtd_Corrida
        {
            get { return qtd_corrida; }
            set { qtd_corrida = value; }
        }
        public string Qtd_Reservada
        {
            get { return qtd_reservada; }
            set { qtd_reservada = value; }
        }
        public string Qtd_Aplicada
        {
            get { return qtd_aplicada; }
            set { qtd_aplicada = value; }
        }
        public void InserirDados(Item item)
        {
            string sql = "";
            sql += " INSERT INTO SZ_CARGA_OP_ITENS  ( IMPORTACAO_ID,   NUMERO_OP_ID,    SAP_MATERIAL,    QTD_PROJETO,    QTD_CORRIDA,    QTD_RESERVADA,    QTD_APLICADA ) ";
            sql += "VALUES  (";
            sql += " " + item.Importacao_id + ",";
            sql += " '" + item.Numero_Op_Id + "',";
            sql += " '" + item.Sap_Material + "',";
            sql += " '" + item.Qtd_Projeto + "',";
            sql += " '" + item.Qtd_Corrida + "',";
            sql += " '" + item.Qtd_Reservada + "',";
            sql += " '" + item.Qtd_Aplicada + "'";
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