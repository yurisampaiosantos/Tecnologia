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
    public class BalancaDAL
    {
        private XmlNodeList Listagem(DateTime dataInicial, DateTime dataFinal)
        {
            ServiceReferenceBalanca.PortariaClient balanca = new ServiceReferenceBalanca.PortariaClient();

            string s;
            s = balanca.ConsultarPesagens(dataInicial, dataFinal);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(s);
            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList codigo = root.SelectNodes("CodigoRetorno");
            if (codigo.Count >= 1)
            {
                return root.SelectNodes("Pesagens/Pesagem");
            }
            else return null;
        }
        private DataSet ListagemSqlServer(DateTime dataInicial, DateTime dataFinal)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql = "";

            sql = "select [Pesagem].*," +
                " (SELECT CODIGO FROM[Portaria].[dbo].[Produto] WHERE[Produto].IdProduto = [Pesagem].IdProduto) as CodigoProduto," +
                " (SELECT DESCRICAO FROM[Portaria].[dbo].[Produto] WHERE[Produto].IdProduto = [Pesagem].IdProduto) as DescricaoProduto," +
                " (SELECT CODIGO FROM[Portaria].[dbo].[Pessoa] WHERE[Pessoa].IdPessoa = [Pesagem].IdMotorista) as CodigoMotorista," +
                " (SELECT CNPJ FROM[Portaria].[dbo].[PessoaJuridica] WHERE[PessoaJuridica].IdPessoa = [Pesagem].IdCliente) as CPFCNPJCliente," +
                " (SELECT CODIGO FROM[Portaria].[dbo].[Pessoa] WHERE[Pessoa].IdPessoa = [Pesagem].IdCliente) as CodigoCliente," +
                " (SELECT CNPJ FROM[Portaria].[dbo].[PessoaJuridica] WHERE[PessoaJuridica].IdPessoa = [Pesagem].IdTransportadora) as CPFCNPJTransportadora," +
                " (SELECT CODIGO FROM[Portaria].[dbo].[Pessoa] WHERE[Pessoa].IdPessoa = [Pesagem].IdTransportadora) as CodigoTransportadora," +
                " (SELECT DESCRICAO FROM[Portaria].[dbo].[Deposito] WHERE[Deposito].IdDeposito = [Pesagem].IdDeposito) as Deposito," +
                " (SELECT DESCRICAO FROM[Portaria].[dbo].[DepositoDoca] WHERE[DepositoDoca].IdDeposito = [Pesagem].IdDeposito AND[DepositoDoca].IdDepositoDoca = [Pesagem].IdDepositoDoca) as Doca," +
                " (SELECT DESCRICAO FROM[Portaria].[dbo].[ClienteDestino] WHERE[ClienteDestino].IdClienteDestino = [Pesagem].IdClienteDestino) as Destino," +
                " (SELECT NomeCompleto FROM[Portaria].[dbo].[Usuario] WHERE[Usuario].IdUsuario = [Pesagem].IdUsuarioCancelada) as UsuarioCancelada" +
                " FROM[Portaria].[dbo].[Pesagem]"+
                " WHERE [Pesagem].DataCadastro BETWEEN CONVERT(datetime,'" + dataInicial+ "', 103) AND CONVERT(datetime,'" + dataFinal + "', 103);";


            SqlConnection con = new SqlConnection(Dados.StringDeConexaoSqlServer);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();

            return ds;
        }
        private DataSet ListagemNotasSqlServer(double idPesagem)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql = "";
            
            sql = "select [PesagemNotaFiscal].*" +
                  " FROM [Portaria].[dbo].[PesagemNotaFiscal]"+
                  " WHERE idPesagem = "+idPesagem;

            SqlConnection con = new SqlConnection(Dados.StringDeConexaoSqlServer);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();

            return ds;
        }
        private DataSet ListagemProdutosAdicionaisSqlServer(double idPesagem)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql = "";

            sql = "select [PesagemProdutoAdicional].*" +
                  " FROM [Portaria].[dbo].[PesagemProdutoAdicional]" +
                  " WHERE idPesagem = " + idPesagem;

            SqlConnection con = new SqlConnection(Dados.StringDeConexaoSqlServer);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();

            return ds;
        }
        public void InserirResultado(DateTime dataInicial, DateTime dataFinal)
        {
            ///Metodo para incluir no banco
            ///
            //exluir tabela temporaria
            Excluir();
            //capturar a lista a ser inserida
            XmlNodeList pessagens = Listagem(dataInicial, dataFinal);
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
                foreach (XmlNode pessagem in pessagens)
                {
                    try
                    {
                        sql = "";
                        sql += "Insert into ERF.TEMP_PESAGENS ";
                        sql += "(CODIGO,	CODIGOPRODUTO, 	DESCRICAOPRODUTO, 	DATACADASTRO, 	CODIGOMOTORISTA, 	NOMEMOTORISTA, 	CPFMOTORISTA, 	PLACACAVALO," +
                            " PLACACARRETA, 	PESOTARA, 	PESOBUTO, 	PESOLIQUIDO, 	PESONF, 	PESOSECO, 	DATAPESAGEMTARA, 	DATAPESAGEMBRUTO, 	CODIGOCLIENTE, " +
                            "	NOMECLIENTE, 	CPFCNPJCLIENTE, 	CODIGOTRANSPORTADORA, 	NOMETRANSPORTADORA, 	CPFCNPJTRANSPORTADORA, 	DEPOSITO, 	DOCA, 	" +
                            "PESODESCONTO, 	PESOTOTALEIXO, 	STATUS, 	DATAENCERRAMENTO, 	MOTIVOTARA, 	MOTIVOBRUTO, 	SACAS, 	MOVIMENTO, 	DESTINO, 	" +
                            "OBSERVACAO, 	PESODIFERENCA, 	PORCENTAGEMDIFERENCA, 	MOTIVOLIBERACAODIFERENCA, 	USUARIOLIBERACAODIFERENCA, 	CODIGOPRODUTOR, 	" +
                            "NOMEPRODUTOR, 	CPFCNPJPRODUTOR, 	CANCELADA, 	DATACANCELADA, 	USUARIOCANCELADA, 	MOTIVOCANCELADA, 	CODIGOPREPESAGEM, 	" +
                            "IDEXTERNOPREPESAGEM, 	MINUTAROMANEIO, 	PESAGEM4ETAPAS, 	NUMEROATUAL4ETAPAS, 	PESOTARA1, 	PESOBRUTO1, 	PESOTARA2, 	" +
                            "PESOBRUTO2, 	DATAPESAGEMTARA2, 	DATAPESAGEMBRUTO2) ";
                        sql += "Values ";
                        sql += "  (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                        comando.CommandText = sql;
                        comando.Parameters.Clear();

                        comando.Parameters.Add("1", OleDbType.VarChar).Value = pessagem["Codigo"].InnerText;
                        comando.Parameters.Add("2", OleDbType.VarChar).Value = pessagem["CodigoProduto"].InnerText;
                        comando.Parameters.Add("3", OleDbType.VarChar).Value = pessagem["DescricaoProduto"].InnerText;
                        comando.Parameters.Add("4", OleDbType.Date).Value = pessagem["DataCadastro"].InnerText;
                        comando.Parameters.Add("5", OleDbType.VarChar).Value = pessagem["CodigoMotorista"].InnerText;
                        comando.Parameters.Add("6", OleDbType.VarChar).Value = pessagem["NomeMotorista"].InnerText;
                        comando.Parameters.Add("7", OleDbType.VarChar).Value = pessagem["CPFMotorista"].InnerText;
                        comando.Parameters.Add("8", OleDbType.VarChar).Value = pessagem["PlacaCavalo"].InnerText;
                        comando.Parameters.Add("9", OleDbType.VarChar).Value = pessagem["PlacaCarreta"].InnerText;
                        comando.Parameters.Add("10", OleDbType.Numeric).Value = pessagem["PesoTara"].InnerText;
                        comando.Parameters.Add("11", OleDbType.Numeric).Value = pessagem["PesoBruto"].InnerText;
                        comando.Parameters.Add("12", OleDbType.Numeric).Value = pessagem["PesoLiquido"].InnerText;
                        comando.Parameters.Add("13", OleDbType.Numeric).Value = pessagem["PesoNF"].InnerText;
                        comando.Parameters.Add("14", OleDbType.Numeric).Value = pessagem["PesoSeco"].InnerText;
                        comando.Parameters.Add("15", OleDbType.Date).Value = pessagem["DataPesagemTara"].InnerText;
                        comando.Parameters.Add("16", OleDbType.Date).Value = pessagem["DataPesagemBruto"].InnerText;
                        comando.Parameters.Add("17", OleDbType.VarChar).Value = pessagem["CodigoCliente"].InnerText;
                        comando.Parameters.Add("18", OleDbType.VarChar).Value = pessagem["NomeCliente"].InnerText;
                        comando.Parameters.Add("19", OleDbType.VarChar).Value = pessagem["CPFCNPJCliente"].InnerText;
                        comando.Parameters.Add("20", OleDbType.VarChar).Value = pessagem["CodigoTransportadora"].InnerText;
                        comando.Parameters.Add("21", OleDbType.VarChar).Value = pessagem["NomeTransportadora"].InnerText;
                        comando.Parameters.Add("22", OleDbType.VarChar).Value = pessagem["CPFCNPJTransportadora"].InnerText;
                        comando.Parameters.Add("23", OleDbType.VarChar).Value = pessagem["Deposito"].InnerText;
                        comando.Parameters.Add("24", OleDbType.VarChar).Value = pessagem["Doca"].InnerText;
                        comando.Parameters.Add("25", OleDbType.Numeric).Value = pessagem["PesoDesconto"].InnerText;
                        comando.Parameters.Add("26", OleDbType.Numeric).Value = pessagem["PesoTotalEixo"].InnerText;
                        comando.Parameters.Add("27", OleDbType.Numeric).Value = pessagem["Status"].InnerText;
                        comando.Parameters.Add("28", OleDbType.Date).Value = pessagem["DataEncerramento"].InnerText;
                        comando.Parameters.Add("29", OleDbType.VarChar).Value = pessagem["MotivoTara"].InnerText;
                        comando.Parameters.Add("30", OleDbType.VarChar).Value = pessagem["MotivoBruto"].InnerText;
                        comando.Parameters.Add("31", OleDbType.Numeric).Value = pessagem["Sacas"].InnerText;
                        comando.Parameters.Add("32", OleDbType.Numeric).Value = pessagem["Movimento"].InnerText;
                        comando.Parameters.Add("33", OleDbType.VarChar).Value = pessagem["Destino"].InnerText;
                        comando.Parameters.Add("34", OleDbType.VarChar).Value = pessagem["Observacao"].InnerText;
                        comando.Parameters.Add("35", OleDbType.Numeric).Value = pessagem["PesoDiferenca"].InnerText;
                        comando.Parameters.Add("36", OleDbType.Numeric).Value = pessagem["PorcentagemDiferenca"].InnerText;
                        comando.Parameters.Add("37", OleDbType.VarChar).Value = pessagem["MotivoLiberacaoDiferenca"].InnerText;
                        comando.Parameters.Add("38", OleDbType.VarChar).Value = pessagem["UsuarioLiberacaoDiferenca"].InnerText;
                        comando.Parameters.Add("39", OleDbType.VarChar).Value = pessagem["CodigoProdutor"].InnerText;
                        comando.Parameters.Add("40", OleDbType.VarChar).Value = pessagem["NomeProdutor"].InnerText;
                        comando.Parameters.Add("41", OleDbType.VarChar).Value = pessagem["CPFCNPJProdutor"].InnerText;
                        comando.Parameters.Add("42", OleDbType.VarChar).Value = pessagem["Cancelada"].InnerText;
                        comando.Parameters.Add("43", OleDbType.Date).Value = pessagem["DataCancelada"].InnerText;
                        comando.Parameters.Add("44", OleDbType.VarChar).Value = pessagem["UsuarioCancelada"].InnerText;
                        comando.Parameters.Add("45", OleDbType.VarChar).Value = pessagem["MotivoCancelada"].InnerText;
                        comando.Parameters.Add("46", OleDbType.VarChar).Value = pessagem["CodigoPrePesagem"].InnerText;
                        comando.Parameters.Add("47", OleDbType.VarChar).Value = pessagem["IdExternoPrePesagem"].InnerText;
                        comando.Parameters.Add("48", OleDbType.VarChar).Value = pessagem["MinutaRomaneio"].InnerText;
                        comando.Parameters.Add("49", OleDbType.VarChar).Value = pessagem["Pesagem4Etapas"].InnerText;
                        comando.Parameters.Add("50", OleDbType.Numeric).Value = pessagem["NumeroAtual4Etapas"].InnerText;
                        comando.Parameters.Add("51", OleDbType.Numeric).Value = pessagem["PesoTara1"].InnerText;
                        comando.Parameters.Add("52", OleDbType.Numeric).Value = pessagem["PesoBruto1"].InnerText;
                        comando.Parameters.Add("53", OleDbType.Numeric).Value = pessagem["PesoTara2"].InnerText;
                        comando.Parameters.Add("54", OleDbType.Numeric).Value = pessagem["PesoBruto2"].InnerText;
                        comando.Parameters.Add("55", OleDbType.Date).Value = pessagem["DataPesagemTara2"].InnerText;
                        comando.Parameters.Add("56", OleDbType.Date).Value = pessagem["DataPesagemBruto2"].InnerText;
                        comando.ExecuteNonQuery();

                        XmlNodeList notas = pessagem.SelectNodes("NotasFiscais/NotaFiscal");
                        foreach (XmlNode nota in notas)
                        {
                            sql = "";
                            sql += "Insert into ERF.TEMP_PESAGENS_NOTA_FISCAIS ";
                            sql += "(CODIGO_PESSAGEM,	NUMERO, 	PESO , CHAVENFE,PESO_LIQUIDO,VOLUME,DATA_HORA_EMISSAO) ";
                            sql += "Values ";
                            sql += "  (?,?,?,?,?,?,?) ";

                            comando.CommandText = sql;
                            comando.Parameters.Clear();

                            comando.Parameters.Add("1", OleDbType.VarChar).Value = pessagem["Codigo"].InnerText;
                            comando.Parameters.Add("2", OleDbType.Numeric).Value = nota["Numero"].InnerText;
                            comando.Parameters.Add("3", OleDbType.Numeric).Value = nota["PesoBruto"].InnerText;
                            comando.Parameters.Add("3", OleDbType.VarChar).Value = nota["ChaveNFe"].InnerText;
                            comando.Parameters.Add("4", OleDbType.Numeric).Value = nota["PesoLiquido"].InnerText;
                            comando.Parameters.Add("5", OleDbType.Numeric).Value = nota["Volume"].InnerText;
                            comando.Parameters.Add("6", OleDbType.Date).Value = Convert.ToDateTime(nota["DataHoraEmissao"].InnerText);

                            comando.ExecuteNonQuery();
                        }
                    
                        XmlNodeList produtosAdicionais = pessagem.SelectNodes("ProdutosAdicionais/ProdutoAdicional");
                        foreach (XmlNode noprodutoAdicional in produtosAdicionais)
                        {
                            sql = "";
                            sql += "Insert into ERF.TEMP_PESAGENS_PRODUTOS_ADICION ";
                            sql += "(CODIGO_PESSAGEM,	DESCRICAO, 	CODIGO) ";
                            sql += "Values ";
                            sql += "  (?,?,?) ";

                            comando.CommandText = sql;
                            comando.Parameters.Clear();

                            comando.Parameters.Add("1", OleDbType.VarChar).Value = pessagem["Codigo"].InnerText;
                            comando.Parameters.Add("2", OleDbType.VarChar).Value = noprodutoAdicional["Descricao"].InnerText;
                            comando.Parameters.Add("3", OleDbType.VarChar).Value = noprodutoAdicional["Codigo"].InnerText;
                            comando.ExecuteNonQuery();
                        }

                    }
                    catch (Exception e)
                    {
                        logErro += pessagem["Codigo"].InnerText + " : " + e.Message + " | ";
                    }
                }
                transaction.Commit();
                con.Close();
            }
            Execucao(logErro,dataInicial);
            Atualizar();
        }
        public void InserirResultadoSqlServer(DateTime dataInicial, DateTime dataFinal)
        {
            ///Metodo para incluir no banco
            ///
            //exluir tabela temporaria
            Excluir();
            //capturar a lista a ser inserida
            DataSet pessagens = ListagemSqlServer(dataInicial, dataFinal);
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
                foreach (DataRow pessagem in pessagens.Tables[0].Rows)
                {
                    try
                    {
                        sql = "";
                        sql += "Insert into ERF.TEMP_PESAGENS ";
                        sql += "(CODIGO,	CODIGOPRODUTO, 	DESCRICAOPRODUTO, 	DATACADASTRO, 	CODIGOMOTORISTA, 	NOMEMOTORISTA, 	CPFMOTORISTA, 	PLACACAVALO," +
                            " PLACACARRETA, 	PESOTARA, 	PESOBUTO, 	PESOLIQUIDO, 	PESONF, 	PESOSECO, 	DATAPESAGEMTARA, 	DATAPESAGEMBRUTO, 	CODIGOCLIENTE, " +
                            "	NOMECLIENTE, 	CPFCNPJCLIENTE, 	CODIGOTRANSPORTADORA, 	NOMETRANSPORTADORA, 	CPFCNPJTRANSPORTADORA, 	DEPOSITO, 	DOCA, 	" +
                            "PESODESCONTO, 	PESOTOTALEIXO, 	STATUS, 	DATAENCERRAMENTO, 	MOTIVOTARA, 	MOTIVOBRUTO, 	SACAS, 	MOVIMENTO, 	DESTINO, 	" +
                            "OBSERVACAO, 	PESODIFERENCA, 	PORCENTAGEMDIFERENCA, 	MOTIVOLIBERACAODIFERENCA, 	USUARIOLIBERACAODIFERENCA, 	CODIGOPRODUTOR, 	" +
                            "NOMEPRODUTOR, 	CPFCNPJPRODUTOR, 	CANCELADA, 	DATACANCELADA, 	USUARIOCANCELADA, 	MOTIVOCANCELADA, 	CODIGOPREPESAGEM, 	" +
                            "IDEXTERNOPREPESAGEM, 	MINUTAROMANEIO, 	PESAGEM4ETAPAS, 	NUMEROATUAL4ETAPAS, 	PESOTARA1, 	PESOBRUTO1, 	PESOTARA2, 	" +
                            "PESOBRUTO2, 	DATAPESAGEMTARA2, 	DATAPESAGEMBRUTO2) ";
                        sql += "Values ";
                        sql += "  (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";

                        comando.CommandText = sql;
                        comando.Parameters.Clear();

                        comando.Parameters.Add("1", OleDbType.VarChar).Value = pessagem["Codigo"].ToString();
                        comando.Parameters.Add("2", OleDbType.VarChar).Value = pessagem["CodigoProduto"].ToString();
                        comando.Parameters.Add("3", OleDbType.VarChar).Value = pessagem["DescricaoProduto"].ToString();
                        comando.Parameters.Add("4", OleDbType.Date).Value = ValidaData(pessagem["DataCadastro"].ToString());
                        comando.Parameters.Add("5", OleDbType.VarChar).Value = pessagem["CodigoMotorista"].ToString();
                        comando.Parameters.Add("6", OleDbType.VarChar).Value = pessagem["Motorista"].ToString();
                        comando.Parameters.Add("7", OleDbType.VarChar).Value = pessagem["CPFMotorista"].ToString();
                        comando.Parameters.Add("8", OleDbType.VarChar).Value = pessagem["PlacaCavalo"].ToString();
                        comando.Parameters.Add("9", OleDbType.VarChar).Value = pessagem["PlacaCarreta"].ToString();
                        comando.Parameters.Add("10", OleDbType.Numeric).Value = ValidaNumerico(pessagem["PesoTara"].ToString());
                        comando.Parameters.Add("11", OleDbType.Numeric).Value = ValidaNumerico(pessagem["PesoBruto"].ToString());
                        comando.Parameters.Add("12", OleDbType.Numeric).Value = ValidaNumerico(pessagem["PesoLiquido"].ToString());
                        comando.Parameters.Add("13", OleDbType.Numeric).Value = ValidaNumerico(pessagem["PesoTotal"].ToString());
                        comando.Parameters.Add("14", OleDbType.Numeric).Value = ValidaNumerico(pessagem["PesoSeco"].ToString());
                        comando.Parameters.Add("15", OleDbType.Date).Value = ValidaData(pessagem["DataPesagemTara"].ToString());
                        comando.Parameters.Add("16", OleDbType.Date).Value = ValidaData(pessagem["DataPesagemBruto"].ToString());
                        comando.Parameters.Add("17", OleDbType.VarChar).Value = pessagem["CodigoCliente"].ToString();
                        comando.Parameters.Add("18", OleDbType.VarChar).Value = pessagem["Cliente"].ToString();
                        comando.Parameters.Add("19", OleDbType.VarChar).Value = pessagem["CPFCNPJCliente"].ToString();
                        comando.Parameters.Add("20", OleDbType.VarChar).Value = pessagem["CodigoTransportadora"].ToString();
                        comando.Parameters.Add("21", OleDbType.VarChar).Value = pessagem["Transportadora"].ToString();
                        comando.Parameters.Add("22", OleDbType.VarChar).Value = pessagem["CPFCNPJTransportadora"].ToString();
                        comando.Parameters.Add("23", OleDbType.VarChar).Value = pessagem["Deposito"].ToString();
                        comando.Parameters.Add("24", OleDbType.VarChar).Value = pessagem["Doca"].ToString();
                        comando.Parameters.Add("25", OleDbType.Numeric).Value = 0;
                        comando.Parameters.Add("26", OleDbType.Numeric).Value = 0;
                        comando.Parameters.Add("27", OleDbType.Numeric).Value = ValidaNumerico(pessagem["Status"].ToString());
                        comando.Parameters.Add("28", OleDbType.Date).Value = ValidaData(pessagem["DataEncerramento"].ToString());
                        comando.Parameters.Add("29", OleDbType.VarChar).Value = pessagem["MotivoTara"].ToString();
                        comando.Parameters.Add("30", OleDbType.VarChar).Value = pessagem["MotivoBruto"].ToString();
                        comando.Parameters.Add("31", OleDbType.Numeric).Value = ValidaNumerico(pessagem["Sacas"].ToString());
                        comando.Parameters.Add("32", OleDbType.Numeric).Value = ValidaNumerico(pessagem["Movimento"].ToString());
                        comando.Parameters.Add("33", OleDbType.VarChar).Value = pessagem["Destino"].ToString();
                        comando.Parameters.Add("34", OleDbType.VarChar).Value = pessagem["Observacao"].ToString();
                        comando.Parameters.Add("35", OleDbType.Numeric).Value = ValidaNumerico(pessagem["PesoDiferenca"].ToString());
                        comando.Parameters.Add("36", OleDbType.Numeric).Value = ValidaNumerico(pessagem["PorcentagemDiferenca"].ToString());
                        comando.Parameters.Add("37", OleDbType.VarChar).Value = pessagem["MotivoLiberacaoDiferenca"].ToString();
                        comando.Parameters.Add("38", OleDbType.VarChar).Value = "";
                        comando.Parameters.Add("39", OleDbType.VarChar).Value = pessagem["IdProdutor"].ToString();
                        comando.Parameters.Add("40", OleDbType.VarChar).Value = "";
                        comando.Parameters.Add("41", OleDbType.VarChar).Value = "";
                        if (pessagem["Cancelada"].ToString() == "")
                        {
                            comando.Parameters.Add("42", OleDbType.VarChar).Value = "false";
                        }
                        else
                        {
                            comando.Parameters.Add("42", OleDbType.VarChar).Value = pessagem["Cancelada"].ToString();
                        }
                        comando.Parameters.Add("43", OleDbType.Date).Value = ValidaData(pessagem["DataCancelada"].ToString());
                        comando.Parameters.Add("44", OleDbType.VarChar).Value = pessagem["UsuarioCancelada"].ToString();
                        comando.Parameters.Add("45", OleDbType.VarChar).Value = pessagem["MotivoCancelada"].ToString();
                        comando.Parameters.Add("46", OleDbType.VarChar).Value = pessagem["IdPrePesagemRodoviaria"].ToString();
                        comando.Parameters.Add("47", OleDbType.VarChar).Value = "";
                        comando.Parameters.Add("48", OleDbType.VarChar).Value = "";
                        comando.Parameters.Add("49", OleDbType.VarChar).Value = pessagem["Pesagem4Etapas"].ToString();
                        comando.Parameters.Add("50", OleDbType.Numeric).Value = 0;
                        comando.Parameters.Add("51", OleDbType.Numeric).Value = ValidaNumerico(pessagem["PesoTara1"].ToString());
                        comando.Parameters.Add("52", OleDbType.Numeric).Value = ValidaNumerico(pessagem["PesoBruto1"].ToString());
                        comando.Parameters.Add("53", OleDbType.Numeric).Value = ValidaNumerico(pessagem["PesoTara2"].ToString());
                        comando.Parameters.Add("54", OleDbType.Numeric).Value = ValidaNumerico(pessagem["PesoBruto2"].ToString());
                        comando.Parameters.Add("55", OleDbType.Date).Value = ValidaData(pessagem["DataPesagemTara2"].ToString());
                        comando.Parameters.Add("56", OleDbType.Date).Value = ValidaData(pessagem["DataPesagemBruto2"].ToString());
                        comando.ExecuteNonQuery();

                        DataSet notas = ListagemNotasSqlServer(Convert.ToDouble(pessagem["idPesagem"].ToString()));
                        foreach (DataRow nota in notas.Tables[0].Rows)
                        {
                            sql = "";
                            sql += "Insert into ERF.TEMP_PESAGENS_NOTA_FISCAIS ";
                            sql += "(CODIGO_PESSAGEM,	NUMERO, 	PESO , CHAVENFE,PESO_LIQUIDO,VOLUME,DATA_HORA_EMISSAO) ";
                            sql += "Values ";
                            sql += "  (?,?,?,?,?,?,?) ";

                            comando.CommandText = sql;
                            comando.Parameters.Clear();

                            comando.Parameters.Add("1", OleDbType.VarChar).Value = pessagem["Codigo"].ToString();
                            comando.Parameters.Add("2", OleDbType.Numeric).Value = ValidaNumerico(nota["NumeroNotaFiscal"].ToString());
                            comando.Parameters.Add("3", OleDbType.Numeric).Value = ValidaNumerico(nota["PesoNotaFiscal"].ToString());
                            comando.Parameters.Add("3", OleDbType.VarChar).Value = nota["Chave"].ToString();
                            comando.Parameters.Add("4", OleDbType.Numeric).Value = ValidaNumerico(nota["PesoLiquido"].ToString());
                            comando.Parameters.Add("5", OleDbType.Numeric).Value = ValidaNumerico(nota["Volume"].ToString());
                            comando.Parameters.Add("6", OleDbType.Date).Value = ValidaData(nota["DataEmissao"].ToString());

                            comando.ExecuteNonQuery();
                        }
                    }
                    catch (Exception e)
                    {
                        logErro += pessagem["Codigo"].ToString() + " : " + e.Message + " | ";  
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                    }
                }
                transaction.Commit();
                con.Close();
            }
            Execucao(logErro, dataInicial);
            Atualizar();
        }
        private void Excluir()
        {
            ///Metodo para Excluir o registro no banco
            ///
            OleDbConnection con = new OleDbConnection(Dados.StringDeConexaoOracle);
            string sql = "";
            sql = "Delete ERF.TEMP_PESAGENS";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            con.Close();

            OleDbConnection con2 = new OleDbConnection(Dados.StringDeConexaoOracle);
            sql = "Delete ERF.TEMP_PESAGENS_NOTA_FISCAIS";
            OleDbCommand cmd2 = new OleDbCommand(sql, con2);
            cmd2.CommandType = CommandType.Text;
            using (con2)
            {
                con2.Open();
                cmd2.ExecuteNonQuery();
            }
            con2.Close();

            OleDbConnection con3 = new OleDbConnection(Dados.StringDeConexaoOracle);
            sql = "Delete ERF.TEMP_PESAGENS_PRODUTOS_ADICION";
            OleDbCommand cmd3 = new OleDbCommand(sql, con3);
            cmd3.CommandType = CommandType.Text;
            using (con3)
            {
                con3.Open();
                cmd3.ExecuteNonQuery();
            }

            con3.Close();
        }
        private void Atualizar()
        {
            ///Metodo para Excluir o registro no banco
            ///
            OleDbConnection con = new OleDbConnection(Dados.StringDeConexaoOracle);
            string sql = "";
            sql += "ERF.PRC_INSERIR_REGISTROS";
            OleDbCommand cmd = new OleDbCommand(sql, con);
            cmd.CommandType = CommandType.StoredProcedure;
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        private void Execucao(string erro, DateTime data)
        {
            ///Metodo para Excluir o registro no banco
            ///
            int status = 0;
            if (erro != "")
            {
                status = 1;
            }
            else
            {
                erro = "Com sucesso";
            }

            if (!VerificaExecucao(data))
            {
                OleDbConnection con = new OleDbConnection(Dados.StringDeConexaoOracle);
                con.Open();

                OleDbCommand comando = con.CreateCommand();
                OleDbTransaction transaction;
                transaction = con.BeginTransaction(IsolationLevel.ReadCommitted);
                // Assign transaction object for a pending local transaction
                comando.Transaction = transaction;
                string sql = "";
                sql += "Insert into ERF.CA_IMPORTACAO_BALANCA ";
                sql += "(DATA_EXECUCAO, DATA,	STATUS, 	LOG) ";
                sql += "Values ";
                sql += "  (sysdate,?,?,?) ";

                comando.CommandText = sql;
                comando.Parameters.Clear();

                comando.Parameters.Add("1", OleDbType.Date).Value = data;
                comando.Parameters.Add("2", OleDbType.Integer).Value = status;


                comando.Parameters.Add("3", OleDbType.VarChar).Value = erro.ToString();
                comando.ExecuteNonQuery();
                transaction.Commit();
                con.Close();
            }
            else
            {
                OleDbConnection con = new OleDbConnection(Dados.StringDeConexaoOracle);
                con.Open();

                OleDbCommand comando = con.CreateCommand();
                OleDbTransaction transaction;
                transaction = con.BeginTransaction(IsolationLevel.ReadCommitted);
                // Assign transaction object for a pending local transaction
                comando.Transaction = transaction;
                string sql = "";
                sql += "UPDATE ERF.CA_IMPORTACAO_BALANCA ";
                sql += "SET STATUS = ?, 	LOG = ? , DATA_EXECUCAO = SYSDATE ";
                sql += "WHERE TO_CHAR(DATA,'DDMMYYYY') =  '" + data.ToString("ddMMyyyy") + "' ";

                comando.CommandText = sql;
                comando.Parameters.Clear();

                comando.Parameters.Add("1", OleDbType.Integer).Value = status;
                comando.Parameters.Add("2", OleDbType.VarChar).Value = erro.Substring(0, erro.Length);
                comando.ExecuteNonQuery();
                transaction.Commit();
                con.Close();
            }

        }
        private bool VerificaExecucao(DateTime data)
        {
            string sql;
            sql = "";
            sql += "SELECT ";
            sql += " ID ";
            sql += "FROM ERF.CA_IMPORTACAO_BALANCA ";
            sql += "WHERE TO_CHAR(DATA,'DDMMYYYY') = '" + data.ToString("ddMMyyyy") +"' ";


            OleDbConnection con = new OleDbConnection(Dados.StringDeConexaoOracle);
            OleDbCommand cmd = new OleDbCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private DateTime ValidaData(string data)
        {
            DateTime dataRetorno = Convert.ToDateTime("30/12/1899");

            if (data != "" )
            {
                dataRetorno = Convert.ToDateTime(data);
            }
            return dataRetorno;
        }
        private double ValidaNumerico(string valor)
        {
            double valorRetorno = 0;

            if (valor != "" )
            {
                valorRetorno = Convert.ToDouble(valor);
            }
            return valorRetorno;
        }
    }
}
