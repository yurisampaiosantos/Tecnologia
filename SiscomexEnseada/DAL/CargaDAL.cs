using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Xml;
using System.IO;

namespace SiscomexEnseada
{
    public class CargaDAL
    {
        private double id;
        private string identificacaoRecepcao;
        private string cnpj;
        private string localRecepcao;
        private string codigoURF;
        private string codigoRA;
        private string localArmazenamento;
        private string avariasIdentificadas;
        private string divergenciasIdentificadas;
        private string cnpjFornecedor;
        private DateTime data;
        private string login;
        private Int32 status;
        private SiscomexController siscomex;

        public double Id { get => id; set => id = value; }
        public string IdentificacaoRecepcao { get => identificacaoRecepcao; set => identificacaoRecepcao = value; }
        public string Cnpj { get => cnpj; set => cnpj = value; }
        public string LocalRecepcao { get => localRecepcao; set => localRecepcao = value; }
        public string CodigoURF { get => codigoURF; set => codigoURF = value; }
        public string CodigoRA { get => codigoRA; set => codigoRA = value; }
        public string LocalArmazenamento { get => localArmazenamento; set => localArmazenamento = value; }
        public string AvariasIdentificadas { get => avariasIdentificadas; set => avariasIdentificadas = value; }
        public string DivergenciasIdentificadas { get => divergenciasIdentificadas; set => divergenciasIdentificadas = value; }
        public string CnpjFornecedor { get => cnpjFornecedor; set => cnpjFornecedor = value; }
        public string Login { get => login; set => login = value; }
        public int Status { get => status; set => status = value; }
        public DateTime Data { get => data; set => data = value; }
        public CargaDAL()
        {
            siscomex = new SiscomexController();
        }
        public double InserirCarga(CargaDAL carga)
        {
            try
            {
                string sql = "insert into COMEX_CARGA ( CNPJ, Local_Recepcao, codigo_URF,codigo_RA,local_Armazenamento,avarias_Identificadas,divergencias_Identificadas,LOGIN_CADASTRO,DATA_CADASTRO,cnpj_fornecedor) " +
                    "values (:cnpj,:localRecepcao,:codigoURF,:codigoRA,:localArmazenamento,:avariasIdentificadas,:divergenciasIdentificadas,:login,:data,:cnpjfornecedor)" +
                    " RETURNING ID INTO :ID";
                OracleConnection oc = new OracleConnection(Conexao.StringDeConexao);
                oc.Open();

                string LoginRede = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Replace("INTRANET\\", "");
                if (LoginRede == "" || LoginRede == null)
                {
                    LoginRede = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                }

                // Preencher com os dados da Carga
                OracleCommand cmd = new OracleCommand(sql, oc);
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new OracleParameter("cnpj", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("localRecepcao", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("codigoURF", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("codigoRA", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("localArmazenamento", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("avariasIdentificadas", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("divergenciasIdentificadas", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("login", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("data", OracleDbType.Date, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("cnpjfornecedor", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("ID", OracleDbType.Decimal, ParameterDirection.Output));

                cmd.Parameters["cnpj"].Value = carga.Cnpj;
                cmd.Parameters["localRecepcao"].Value = carga.LocalRecepcao;
                cmd.Parameters["codigoURF"].Value = carga.CodigoURF;
                cmd.Parameters["codigoRA"].Value = carga.CodigoRA;
                cmd.Parameters["localArmazenamento"].Value = carga.LocalArmazenamento;
                cmd.Parameters["avariasIdentificadas"].Value = carga.AvariasIdentificadas;
                cmd.Parameters["divergenciasIdentificadas"].Value = carga.DivergenciasIdentificadas;
                cmd.Parameters["login"].Value = LoginRede;
                cmd.Parameters["data"].Value = carga.Data;
                cmd.Parameters["cnpjfornecedor"].Value = carga.CnpjFornecedor;

                cmd.ExecuteNonQuery();
                double retornoId = Convert.ToDouble(cmd.Parameters["ID"].Value.ToString());
                oc.Close();

                return retornoId;
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Inserir Carga");
            }
        }
        public void Atualizar(CargaDAL carga)
        {
            try
            {
                string sql = "UPDATE COMEX_CARGA SET CNPJ = :cnpj, Local_Recepcao = :localRecepcao, "+
                             " codigo_URF = :codigoURF,codigo_RA = :codigoRA,local_Armazenamento = :localArmazenamento, "+
                             " avarias_Identificadas = :avariasIdentificadas,divergencias_Identificadas = :divergenciasIdentificadas, " +
                             " cnpj_fornecedor = :cnpjfornecedor " +
                             " WHERE ID =" + carga.Id;
                OracleConnection oc = new OracleConnection(Conexao.StringDeConexao);
                oc.Open();

                // Preencher com os dados da Carga
                OracleCommand cmd = new OracleCommand(sql, oc);
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new OracleParameter("cnpj", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("localRecepcao", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("codigoURF", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("codigoRA", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("localArmazenamento", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("avariasIdentificadas", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("divergenciasIdentificadas", OracleDbType.Varchar2, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("cnpjfornecedor", OracleDbType.Varchar2, ParameterDirection.Input));

                cmd.Parameters["cnpj"].Value = carga.Cnpj;
                cmd.Parameters["localRecepcao"].Value = carga.LocalRecepcao;
                cmd.Parameters["codigoURF"].Value = carga.CodigoURF;
                cmd.Parameters["codigoRA"].Value = carga.CodigoRA;
                cmd.Parameters["localArmazenamento"].Value = carga.LocalArmazenamento;
                cmd.Parameters["avariasIdentificadas"].Value = carga.AvariasIdentificadas;
                cmd.Parameters["divergenciasIdentificadas"].Value = carga.DivergenciasIdentificadas;
                cmd.Parameters["cnpjfornecedor"].Value = carga.CnpjFornecedor;

                cmd.ExecuteNonQuery();
                oc.Close();

            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Atualizar Carga");
            }
        }
        public DataTable ListaCarga(DateTime data)
        {
            try
            {
                string sql = "select COMEX_CARGA.* , " +
                                     " (SELECT COUNT(ID) FROM COMEX_CARGA_NOTAS WHERE COMEX_CARGA.ID = COMEX_CARGA_NOTAS.CARGA_ID ) AS TOTAL_NOTAS, " +
                                     " (SELECT COUNT(ID) FROM COMEX_CARGA_NOTAS WHERE COMEX_CARGA.ID = COMEX_CARGA_NOTAS.CARGA_ID AND STATUS = 2 ) AS TOTAL_ERRO, " +
                                     "(SELECT COUNT(ID) FROM COMEX_CARGA_NOTAS WHERE COMEX_CARGA.ID = COMEX_CARGA_NOTAS.CARGA_ID AND STATUS = 1 ) - (SELECT COUNT(ID) FROM COMEX_CARGA_NOTAS WHERE COMEX_CARGA.ID = COMEX_CARGA_NOTAS.CARGA_ID AND STATUS = 2 ) as IMPORTADOS " +
                                     " from COMEX_CARGA where to_char(DATA_CADASTRO,'DDMMYYYY') = " + data.ToString("ddMMyyyy");
                OracleConnection oc = new OracleConnection(Conexao.StringDeConexao);
                oc.Open();
                OracleDataAdapter da = new OracleDataAdapter(sql, oc);
                DataSet ds = new DataSet();
                da.Fill(ds);
                oc.Close();

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Lista Carga");
            }
}
        public void PreencherCarga(double cargaId)
        {
            try
            {
                string sql = "select * from COMEX_CARGA where id = " + cargaId;
                OracleConnection oc = new OracleConnection(Conexao.StringDeConexao);
                oc.Open();
                OracleDataAdapter da = new OracleDataAdapter(sql, oc);
                DataSet ds = new DataSet();
                da.Fill(ds);
                oc.Close();

                DataTable t = ds.Tables[0];
                Id = Convert.ToDouble(t.Rows[0]["ID"].ToString());
                Cnpj = t.Rows[0]["CNPJ"].ToString();
                LocalRecepcao = t.Rows[0]["Local_Recepcao"].ToString();
                CodigoURF = t.Rows[0]["codigo_URF"].ToString();
                CodigoRA = t.Rows[0]["codigo_RA"].ToString();
                LocalArmazenamento = t.Rows[0]["local_Armazenamento"].ToString();
                AvariasIdentificadas = t.Rows[0]["avarias_Identificadas"].ToString();
                DivergenciasIdentificadas = t.Rows[0]["divergencias_Identificadas"].ToString();
                LocalArmazenamento = t.Rows[0]["local_Armazenamento"].ToString();
                CnpjFornecedor = t.Rows[0]["cnpj_fornecedor"].ToString();                
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Preencher Carga");
            }
        }
        private void ValidarXML(string xml)
        {
            XmlDocument xmlDocument = new XmlDocument();            
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, Conexao.DiretorioValidador);
                settings.ValidationType = ValidationType.Schema;
                xmlDocument.LoadXml(xml);

                XmlReader xr = XmlReader.Create(new StringReader(xmlDocument.InnerXml), settings);

                try
                {
                    while (xr.Read())
                    {
                        string s = xr.Name;
                    }
                }
                catch (Exception ex)
                {
                    throw new System.ArgumentException(xr.Name + " : " + ex.Message, "Validação do XML");
                }                
                siscomex.Enviar(xmlDocument.InnerXml);
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Validação do XML");
            }
        }
        public void EnviarLoteXML(double cargaID)
        {
            try
            {
                string sql = "";

                sql += " SELECT  COMEX_CARGA_NOTAS.ID, ";
                sql += " XMLELEMENT(\"recepcoesNFE\", XMLATTRIBUTES(  ";
                sql += "                                   'http://www.pucomex.serpro.gov.br/cct RecepcaoNFE.xsd' AS  ";
                sql += "                                           \"xsi:schemaLocation\",  ";
                sql += "                                   'http://www.pucomex.serpro.gov.br/cct' AS  ";
                sql += "                                           \"xmlns\",  ";
                sql += "                                   'http://www.w3.org/2001/XMLSchema-instance' AS \"xmlns:xsi\"),  ";
                sql += "           XMLELEMENT(\"recepcaoNFE\",  ";
                sql += "                    XMLELEMENT(\"identificacaoRecepcao\", IDENTIFICACAO_RECEPCAO),  ";
                sql += "                    XMLELEMENT(\"cnpjResp\", CNPJ),  ";
                //     sql += "                    --Local  ";
                sql += "                    XMLELEMENT(\"local\",  ";
                sql += "                                XMLELEMENT(\"codigoURF\", CODIGO_URF),  ";
                sql += "                                XMLELEMENT(\"codigoRA\", CODIGO_RA)  ";
                sql += "                               ),  ";
                sql += "                    XMLELEMENT(\"referenciaLocalRecepcao\", LOCAL_RECEPCAO),  ";
                //   sql += "                    --nota fiscal  ";
                sql += "                    XMLELEMENT(\"notasFiscais\",  ";
                sql += "                                XMLELEMENT(\"notaFiscalEletronica\",  ";
                sql += "                                             XMLELEMENT(\"chaveAcesso\", CHAVE_NOTA)  ";
                sql += "                                           )  ";
                sql += "                                ),  ";
                //sql += "                    --Transportador  ";
                sql += "                    XMLELEMENT(\"transportador\",  ";
                sql += "                                XMLELEMENT(\"cnpj\", CNPJ_TRANSPORTADOR)  ";
                //sql += "                                XMLELEMENT(\"cpfCondutor\", '')  ";
                sql += "                               ),  ";
                sql += "                    XMLELEMENT(\"pesoAferido\", TRIM(REPLACE(TO_CHAR(peso, '999999990D999'),',','.'))),  ";
                sql += "                    XMLELEMENT(\"localArmazenamento\", LOCAL_ARMAZENAMENTO),  ";
                sql += "                    XMLELEMENT(\"avariasIdentificadas\", AVARIAS_IDENTIFICADAS),  ";
                sql += "                    XMLELEMENT(\"divergenciasIdentificadas\", DIVERGENCIAS_IDENTIFICADAS),  ";
                sql += "                    XMLELEMENT(\"observacoesGerais\", OBSERVACOES_GERAIS)  ";
                sql += "         )  ";
                sql += " )as \"Xml\"  ";
                sql += " FROM COMEX_CARGA , COMEX_CARGA_NOTAS ";
                sql += " WHERE COMEX_CARGA.ID = COMEX_CARGA_NOTAS.CARGA_ID";
                sql += " AND COMEX_CARGA.cnpj_fornecedor = COMEX_CARGA_NOTAS.cnpj_fornecedor";                
                sql += " AND COMEX_CARGA_NOTAS.STATUS <> 1 ";
                sql += " AND COMEX_CARGA.ID = " + cargaID;
                CargaNotasDAL cargaNotas = new CargaNotasDAL();
                using (OracleConnection conn = new OracleConnection(Conexao.StringDeConexao))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        using (OracleDataReader dataReader = cmd.ExecuteReader()) //IDataReader
                        {
                            while (dataReader.Read())
                            {
                                if (dataReader["Xml"] != DBNull.Value)
                                {
                                    try
                                    {
                                        ValidarXML("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + (String)dataReader["Xml"]);
                                        cargaNotas.AtualizarStatus(Convert.ToDouble(dataReader["ID"]));
                                    }
                                    catch (Exception ex)
                                    {                                        
                                        cargaNotas.InserirErro(Convert.ToDouble(dataReader["ID"]), ex.Message);
                                    }
                                }
                            }
                        }
                    }
                    conn.Close();
                    AtualizarStatus(cargaID);
                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Retornar XML");
            }
}
        public void AtualizarStatus(double idCarga)
        {
            try
            {
                string sql = "";

                sql = "UPDATE COMEX_CARGA SET STATUS = 1 " +
                       "where id = " + idCarga +
                       " and not exists ( select id from comex_carga_notas where comex_carga_notas.carga_id = comex_carga.id and nvl(status,0) = 0)"+
                       " and exists ( select id from comex_carga_notas where comex_carga_notas.carga_id = comex_carga.id )";

                using (OracleConnection conn = new OracleConnection(Conexao.StringDeConexao))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Retornar XML");
            }
           /* try
            {
                string sql = "";

                sql = "UPDATE COMEX_CARGA SET STATUS = 2 " +
                       "where id = " + idCarga +
                       " and exists ( select id from comex_carga_notas where comex_carga_notas.carga_id = comex_carga.id and nvl(status,0) = 2)";

                using (OracleConnection conn = new OracleConnection(Conexao.StringDeConexao))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Retornar XML");
            }
            */
        }
        public void DeleteLote(double cargaId)
        {
            try
            {
                String sql = "delete COMEX_CARGA where id = " + cargaId + " AND STATUS <> 1 " +
                             " and not exists ( select id from comex_carga_notas where comex_carga_notas.carga_id = comex_carga.id and nvl(status,0) = 1)";

                OracleConnection oc = new OracleConnection(Conexao.StringDeConexao);
                oc.Open();
                OracleCommand cmd = new OracleCommand(sql, oc);
                int r = cmd.ExecuteNonQuery();
                oc.Close();
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Deleta Carga");
            }
        }
    }
}



















/*
 *                 //   sql += "                    --nota fiscal  ";
                sql += "                    XMLELEMENT(\"notasFiscais\",  ";
                sql += "                                XMLELEMENT(\"notaFiscalEletronica\",  ";
                sql += "                                            (SELECT  ";
                sql += "                                                   XMLAgg(XMLELEMENT(\"chaveAcesso\", CHAVE_NOTA)  ";
                sql += "                                                          ) as \"NOTAS\"  ";
                sql += "                                            FROM COMEX_CARGA_NOTAS  ";
                sql += "                                            WHERE COMEX_CARGA_NOTAS.CARGA_ID = COMEX_CARGA.ID  ";
                sql += "                                            )  ";
                sql += "                                )  ";
                sql += "                     ),  ";
*/