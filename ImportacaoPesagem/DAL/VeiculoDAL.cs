using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class VeiculoDAL
    {
        private XmlNodeList Listagem(string placa)
        {
            ServiceReferenceBalanca.PortariaClient balanca = new ServiceReferenceBalanca.PortariaClient();

            string s;
            s = balanca.ConsultarVeiculo(placa);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(s);
            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList codigo = root.SelectNodes("CodigoRetorno");
            if (codigo.Count >= 1)
            {
                return root.SelectNodes("/Veiculo");
            }
            else return null;
        }
        private DataSet ListagemSqlServer()
        {
            ///Metodo para Listar todos no banco
            ///
            string sql = "";

            sql = "select [Veiculo].*," +
                " (SELECT CPF FROM[Portaria].[dbo].[PessoaFisica] WHERE [PessoaFisica].IdPessoa = [Veiculo].IdMotorista) as CPFMotorista," +
                " (SELECT CODIGO FROM[Portaria].[dbo].[Pessoa] WHERE [Pessoa].IdPessoa = [Veiculo].IdMotorista) as CodigoMotorista," +
                " (SELECT NomeRazaoSocial FROM[Portaria].[dbo].[Pessoa] WHERE [Pessoa].IdPessoa = [Veiculo].IdMotorista) as NomeMotorista" +
                " FROM[Portaria].[dbo].[Veiculo]";


            SqlConnection con = new SqlConnection(Dados.StringDeConexaoSqlServer);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();

            return ds;
        }
        private DataTable ListagemPlacas()
        {
            DataSet ds = new DataSet();
            OleDbConnection con = new OleDbConnection(Dados.StringDeConexaoOracle);
            string sql = "SELECT DISTINCT PLACACAVALO  " +
                "FROM ERF.CA_PESAGENS " +
                "WHERE NOT EXISTS (SELECT PLACA FROM ERF.CA_PESAGENS_VEICULOS " +
                "                  WHERE CA_PESAGENS_VEICULOS.PLACA = CA_PESAGENS.PLACACAVALO) ";
            //OleDbCommand cmd = new OleDbCommand(con);
            OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
          //  cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();                
                da.Fill(ds);
            }
            con.Close();

            return ds.Tables[0];
        }

        public void InserirResultado()
        {
            DataTable dt = new DataTable();
            dt = ListagemPlacas();
            //exluir tabela temporaria
            Excluir();
            foreach (DataRow linha in dt.Rows)
            {
                ///Metodo para incluir no banco
                ///
                //capturar a lista a ser inserida


                XmlNodeList veiculos = Listagem(linha[0].ToString());
                string logErro = "";
                using (OleDbConnection con = new OleDbConnection(Dados.StringDeConexaoOracle))
                {
                    con.Open();

                    OleDbCommand comando = con.CreateCommand();
                    OleDbTransaction transaction;
                    transaction = con.BeginTransaction(IsolationLevel.ReadCommitted);
                    // Assign transaction object for a pending local transaction
                    comando.Transaction = transaction;
                    string sql = "";
                    foreach (XmlNode veiculo in veiculos)
                    {
                        try
                        {
                            sql = "";
                            sql += "Insert into ERF.TEMP_PESAGENS_VEICULOS ";
                            sql += "(PLACA,MODELO,PLACACARRETA,NOMEMOTORISTA,CPFMOTORISTA,CODIGOMOTORISTA) ";
                            sql += "Values ";
                            sql += "  (?,?,?,?,?,?) ";

                            comando.CommandText = sql;
                            comando.Parameters.Clear();
                            comando.Parameters.Add("1", OleDbType.VarChar).Value = veiculo["Placa"].InnerText;
                            comando.Parameters.Add("2", OleDbType.VarChar).Value = veiculo["Modelo"].InnerText;
                            comando.Parameters.Add("3", OleDbType.VarChar).Value = veiculo["PlacaCarreta"].InnerText;
                            comando.Parameters.Add("4", OleDbType.VarChar).Value = veiculo["NomeMotorista"].InnerText;
                            comando.Parameters.Add("5", OleDbType.VarChar).Value = veiculo["CPFMotorista"].InnerText;
                            comando.Parameters.Add("5", OleDbType.VarChar).Value = veiculo["CodigoMotorista"].InnerText;

                            comando.ExecuteNonQuery();

                        }
                        catch (Exception e)
                        {
                            logErro += veiculo["Placa"].InnerText + " : " + e.Message + " | ";
                        }
                    }
                    transaction.Commit();
                    con.Close();
                }                
            }
            Atualizar();
        }
        public void InserirResultadoSqlServer()
        {
            //exluir tabela temporaria
            Excluir();
            //capturar a lista a ser inserida
            DataSet veiculos = ListagemSqlServer();

                ///Metodo para incluir no banco
                string logErro = "";
            using (OleDbConnection con = new OleDbConnection(Dados.StringDeConexaoOracle))
            {
                con.Open();

                OleDbCommand comando = con.CreateCommand();
                OleDbTransaction transaction;
                transaction = con.BeginTransaction(IsolationLevel.ReadCommitted);
                // Assign transaction object for a pending local transaction
                comando.Transaction = transaction;
                string sql = "";
                foreach (DataRow veiculo in veiculos.Tables[0].Rows)
                {
                    try
                    {
                        sql = "";
                        sql += "Insert into ERF.TEMP_PESAGENS_VEICULOS ";
                        sql += "(PLACA,MODELO,PLACACARRETA,NOMEMOTORISTA,CPFMOTORISTA,CODIGOMOTORISTA) ";
                        sql += "Values ";
                        sql += "  (?,?,?,?,?,?) ";

                        comando.CommandText = sql;
                        comando.Parameters.Clear();
                        comando.Parameters.Add("1", OleDbType.VarChar).Value = veiculo["Placa"].ToString();
                        comando.Parameters.Add("2", OleDbType.VarChar).Value = veiculo["Modelo"].ToString();
                        comando.Parameters.Add("3", OleDbType.VarChar).Value = veiculo["PlacaCarreta"].ToString();
                        comando.Parameters.Add("4", OleDbType.VarChar).Value = veiculo["NomeMotorista"].ToString();
                        comando.Parameters.Add("5", OleDbType.VarChar).Value = veiculo["CPFMotorista"].ToString();
                        comando.Parameters.Add("5", OleDbType.VarChar).Value = veiculo["CodigoMotorista"].ToString();

                        comando.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                        logErro += veiculo["Placa"].ToString() + " : " + e.Message + " | ";
                    }
                }
                transaction.Commit();
                con.Close();
            }
            Atualizar();
        }
        private void Excluir()
        {
            ///Metodo para Excluir o registro no banco
            ///
            OleDbConnection con = new OleDbConnection(Dados.StringDeConexaoOracle);
            string sql = "";
            sql = "Delete ERF.TEMP_PESAGENS_VEICULOS";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        private void Atualizar()
        {
            ///Metodo para Excluir o registro no banco
            ///
            OleDbConnection con = new OleDbConnection(Dados.StringDeConexaoOracle);
            string sql = "";
            sql += "ERF.PRC_INSERIR_VEICULOS";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
    }
}
