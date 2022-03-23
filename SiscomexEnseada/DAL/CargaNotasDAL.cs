using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace SiscomexEnseada
{
    public class CargaNotasDAL
    {
        private double id;
        private double cargaId;
        private string chaveNota;
        private string cnpj;
        private string cnpjTransportador;
        private double peso;
        private string observacoes;
        private string erro;

        public double Id { get => id; set => id = value; }
        public double CargaId { get => cargaId; set => cargaId = value; }
        public string ChaveNota { get => chaveNota; set => chaveNota = value; }
        public string Cnpj { get => cnpj; set => cnpj = value; }
        public string CnpjTransportador { get => cnpjTransportador; set => cnpjTransportador = value; }
        public double Peso { get => peso; set => peso = value; }
        public string Observacoes { get => observacoes; set => observacoes = value; }
        public string Erro { get => erro; set => erro = value; }

        public void InserirNotasPlanilha(DataSet ds, double cargaId)
        {
            try
            {
                Delete(cargaId);
                string sql = "insert into COMEX_CARGA_NOTAS (CARGA_ID, CHAVE_NOTA, PESO ,observacoes_Gerais,CNPJ_TRANSPORTADOR,CNPJ_FORNECEDOR) " +
                    "values (:cargaId,:chaveNota,:peso,:observacoesGerais,:cnpjTransportadora,:cnpj)";
                OracleConnection oc = new OracleConnection(Conexao.StringDeConexao);
                oc.Open();
                // Preencher com os dados da Carga
                OracleCommand cmd = new OracleCommand(sql, oc);
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    try
                    {
                        if (Convert.ToString(r["erro"].ToString()) == "")
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add(new OracleParameter("CARGA_ID", OracleDbType.Decimal, ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter("CHAVE_NOTA", OracleDbType.Varchar2, ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter("PESO", OracleDbType.Decimal, ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter("observacoesGerais", OracleDbType.Varchar2, ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter("cnpjTransportadora", OracleDbType.Varchar2, ParameterDirection.Input));
                            cmd.Parameters.Add(new OracleParameter("cnpj", OracleDbType.Varchar2, ParameterDirection.Input));

                            cmd.Parameters["CARGA_ID"].Value = cargaId;
                            cmd.Parameters["CHAVE_NOTA"].Value = r["chave"].ToString().Replace("'", "");
                            cmd.Parameters["PESO"].Value = Convert.ToDecimal(r["PESO LIQUIDO"].ToString());
                            cmd.Parameters["observacoesGerais"].Value = Convert.ToDecimal(r["Observacao"].ToString());
                            cmd.Parameters["cnpjTransportadora"].Value = Convert.ToDecimal(r["CNPJ Transportadora"].ToString());
                            cmd.Parameters["cnpj"].Value = Convert.ToDecimal(r["CNPJ"].ToString());

                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        break;
                    }

                }
                oc.Close();
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Inserir Carga Notas");
            }
        }
        public void InserirNotasXML(List<CargaNotasDAL> listaCargaNotas, double cargaId)
        {
            try
            {
                Delete(cargaId);
                string sql = "insert into COMEX_CARGA_NOTAS (CARGA_ID, CHAVE_NOTA, PESO ,observacoes_Gerais,CNPJ_TRANSPORTADOR,CNPJ_FORNECEDOR) " +
                              "values (:cargaId,:chaveNota,:peso,:observacoesGerais,:cnpjTransportadora,:cnpj)";
                OracleConnection oc = new OracleConnection(Conexao.StringDeConexao);
                oc.Open();
                // Preencher com os dados da Carga
                OracleCommand cmd = new OracleCommand(sql, oc);
                foreach (CargaNotasDAL cargaNotas in listaCargaNotas)
                {
                    if (cargaNotas.Erro == "" || cargaNotas.Erro == null)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new OracleParameter("CARGA_ID", OracleDbType.Decimal, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("CHAVE_NOTA", OracleDbType.Varchar2, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("PESO", OracleDbType.Decimal, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("observacoesGerais", OracleDbType.Varchar2, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("cnpjTransportadora", OracleDbType.Varchar2, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("cnpj", OracleDbType.Varchar2, ParameterDirection.Input));

                        cmd.Parameters["CARGA_ID"].Value = cargaId;
                        cmd.Parameters["CHAVE_NOTA"].Value = cargaNotas.ChaveNota;
                        cmd.Parameters["PESO"].Value = cargaNotas.Peso;
                        cmd.Parameters["observacoesGerais"].Value = cargaNotas.Observacoes;
                        cmd.Parameters["cnpjTransportadora"].Value = cargaNotas.CnpjTransportador;
                        cmd.Parameters["cnpj"].Value = cargaNotas.Cnpj;

                        cmd.ExecuteNonQuery();
                    }
                }
                oc.Close();
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Inserir Carga Notas");
            }
        }
        private void Delete(double idCarga)
        {
            try
            {
                String sql = "delete COMEX_CARGA_NOTAS where CARGA_ID = " + idCarga + " AND STATUS <> 1 ";
                OracleConnection oc = new OracleConnection(Conexao.StringDeConexao);
                oc.Open();
                OracleCommand cmd = new OracleCommand(sql, oc);
                int r = cmd.ExecuteNonQuery();
                oc.Close();
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Deleta Carga Notas");
            }
        }
        public void DeleteNota(double idCargaNotas)
        {
            try
            {
                String sql = "delete COMEX_CARGA_NOTAS where id = " + idCargaNotas + " AND STATUS <> 1 ";
                OracleConnection oc = new OracleConnection(Conexao.StringDeConexao);
                oc.Open();
                OracleCommand cmd = new OracleCommand(sql, oc);
                int r = cmd.ExecuteNonQuery();
                oc.Close();
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Deleta Carga Notas");
            }
        }
        public DataTable ListaCargaNotas(double idCarga)
        {
            try
            {
                string sql = "select COMEX_CARGA_NOTAS.* , " +
                             "DECODE(" +
                             "        ( select COUNT(*) from ERF.CA_PESAGENS ,ERF.CA_PESAGENS_NOTA_FISCAIS "+
                             "          where ca_pesagens.codigo = ca_pesagens_nota_fiscais.codigo_pessagem " +
                             "          and replace(replace(replace(cpfcnpjcliente,'.',''),'/',''),'-','')= replace(replace(replace(CNPJ_FORNECEDOR,'.',''),'/',''),'-','') " +
                             "          AND LPAD(substr(chave_nota,26,9),9,'0') = LPAD(numero, 9, '0')) "+
                             "       ,0,2,1) AS STATUSBALANCA" +
                             " from ESISEPC.COMEX_CARGA_NOTAS where carga_id = " + idCarga;
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
                throw new System.ArgumentException(ex.Message, "Lista Carga Notas");
            }
        }
        public List<CargaNotasDAL> LerXML(string cnpjFornecedor)
        {
            List<CargaNotasDAL> listaCargaNota = new List<CargaNotasDAL>();

            bool emit = false;
            bool transp = false;
            bool detnItem = false;
            bool infAdic = false;
            bool prod = false;

            string CNPJEmi = "";
            string CNPJTransp = "";
            string UTrib = "";
            string QTrib = "";
            string IndCpl = "";
            string ChNFe = "";
            string idNFe = "";

            //   DialogResult result = DialogResult.Yes;
            // bool importarBanco = true;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo infoArquivo = new FileInfo(openFileDialog.FileName);
                DirectoryInfo diretorio = new DirectoryInfo(infoArquivo.DirectoryName);
                FileInfo[] Arquivos = diretorio.GetFiles("*.xml");
                
                foreach (FileInfo fileinfo in Arquivos)
                {
                    StreamReader reader = new System.IO.StreamReader(fileinfo.DirectoryName + "\\" + fileinfo.Name, System.Text.Encoding.GetEncoding("UTF-8"), true);//Windows-1252
                    XmlTextReader tr = new XmlTextReader(reader);

                    while (tr.Read())
                    {
                        if (tr.IsStartElement())
                        {
                            if (tr.IsStartElement())
                            {
                                if (tr.Name == "infNFe")
                                {
                                    idNFe = tr.GetAttribute("Id");
                                    try
                                    {
                                        idNFe = idNFe.Substring(3);
                                    }
                                    catch { }
                                }                               
                                //-------------------------
                                if (tr.Name == "emit")
                                {
                                    emit = true;
                                    transp = false;
                                    detnItem = false;
                                    infAdic = false;
                                }
                                if (emit == true)
                                {
                                    if (tr.Name == "CNPJ")
                                    {
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            CNPJEmi = tr.Value;
                                        }
                                        emit = false;
                                    }
                                }

                                //-------------------------
                                if (tr.Name == "det")
                                {
                                    emit = false;
                                    transp = false;
                                    detnItem = true;
                                    infAdic = false;
                                }
                                if (detnItem == true)
                                {
                                    if (tr.Name == "prod")
                                    {
                                        prod = true;
                                    }
                                    if (prod == true)
                                    {
                                        if (tr.Name == "uTrib")
                                        {
                                            tr.Read();
                                            if (tr.NodeType == XmlNodeType.Text)
                                            {
                                                UTrib = tr.Value;
                                            }
                                        }
                                        if (tr.Name == "qTrib")
                                        {
                                            tr.Read();
                                            if (tr.NodeType == XmlNodeType.Text)
                                            {
                                                QTrib = tr.Value;
                                            }
                                            detnItem = false;
                                            prod = false;
                                        }
                                    }
                                }

                                //-------------------------
                                if (tr.Name == "transp")
                                {
                                    emit = false;
                                    transp = true;
                                    detnItem = false;
                                    infAdic = false;
                                }
                                if (transp == true)
                                {
                                    if (tr.Name == "CNPJ")
                                    {
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            CNPJTransp = tr.Value;
                                        }
                                        transp = false;
                                    }

                                }

                                //-------------------------
                                if (tr.Name == "infAdic")
                                {
                                    emit = false;
                                    transp = false;
                                    detnItem = false;
                                    infAdic = true;
                                }
                                if (infAdic == true)
                                {
                                    if (tr.Name == "infCpl")
                                    {
                                        try
                                        {
                                            tr.Read();
                                            if (tr.NodeType == XmlNodeType.Text)
                                            {
                                                IndCpl = tr.Value;
                                            }
                                        }
                                        catch
                                        {
                                            IndCpl = "";
                                        }
                                        transp = false;
                                    }

                                }
                                //-------------------------
                                if (tr.Name == "chNFe")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        ChNFe = tr.Value;
                                    }
                                    transp = false;
                                }
                            }

                        }
                    }
                    if (ChNFe == "" || ChNFe == null)
                    {
                        if (idNFe != "" && idNFe != null)
                        {
                            ChNFe = idNFe;
                        }
                    }
                    CargaNotasDAL cargaNota = new CargaNotasDAL();
                    cargaNota.Cnpj = CNPJEmi;
                    cargaNota.CnpjTransportador = CNPJTransp;
                    cargaNota.ChaveNota = ChNFe;
                    if (IndCpl.ToUpper().IndexOf("MOTORISTA") != -1)
                    {
                        try
                        {
                            if (IndCpl.Count() - IndCpl.ToUpper().IndexOf("MOTORISTA") > 250)
                            {
                                cargaNota.Observacoes = IndCpl.Substring(IndCpl.ToUpper().IndexOf("MOTORISTA"), 250);
                            }
                            else
                            {
                                cargaNota.Observacoes = IndCpl.Substring(IndCpl.ToUpper().IndexOf("MOTORISTA"));
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        if (IndCpl.Count() > 250)
                        {
                            cargaNota.Observacoes = IndCpl.Substring(0, 250);
                        }
                        else
                        {
                            cargaNota.Observacoes = IndCpl;
                        }
                    }
                    if (UTrib.ToUpper() == "KG")
                    {
                        cargaNota.Peso = Convert.ToDouble(QTrib.Replace(".", ","));
                    }
                    if (cnpjFornecedor != cargaNota.Cnpj)
                    {
                        cargaNota.Erro = "CNPJ diferente do Lote - Essa nota não sera migrada";
                    }

                    if (ChNFe == "" || ChNFe == null)
                    {
                        cargaNota.Erro = "Numero da NFe não existe - Essa nota não sera migrada";
                    }
                    else
                    {
                        if (ExistenciaNota(ChNFe))
                        {
                            cargaNota.Erro = "Numero da NFe já foi migrada pro SISCOMEX";
                        }
                    }
                        listaCargaNota.Add(cargaNota);
                    
                    //--------- Limpar //
                    emit = false;
                    transp = false;
                    detnItem = false;
                    infAdic = false;
                    prod = false;

                    CNPJEmi = "";
                    CNPJTransp = "";
                    UTrib = "";
                    QTrib = "";
                    IndCpl = "";
                    ChNFe = "";
                    idNFe = "";
                }
            }
            return listaCargaNota;
        }
        public void InserirErro(double idCargaNotas, string erro)
        {
            try
            {
                string sql = "";

                sql = "UPDATE COMEX_CARGA_NOTAS SET STATUS = 2 , ERRO = '" + erro.Replace("'","*") + "' "+
                       "where id = " + idCargaNotas;

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
        }
        public void AtualizarStatus(double idCargaNotas)
        {
            try
            {
                string sql = "";

                sql = "UPDATE COMEX_CARGA_NOTAS SET STATUS = 1 , Erro = null " +
                       "where id = " + idCargaNotas;

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
        }
        public void AtualizarPeso(double idCargaNotas)
        {
            try
            {
                string sql = "";

                sql = "UPDATE COMEX_CARGA_NOTAS SET PESO = PESO * 1000 , Erro = null " +
                       "where id = " + idCargaNotas +
                       " AND NVL(STATUS,0) = 0 ";

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
        }
        public void AtualizarNota(double idCargaNotas, string cnpjTransportadora, string observacao, double peso)
        {
            try
            {
                string sql = "";

                sql = "UPDATE COMEX_CARGA_NOTAS SET PESO = "+peso+", Erro = null " +
                       ",CNPJ_TRANSPORTADOR ='" + cnpjTransportadora + "'" +
                       ",OBSERVACOES_GERAIS ='" + observacao +"'"+
                       "where id = " + idCargaNotas +
                       " AND NVL(STATUS,0) = 0 ";

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
        }
        public bool ExistenciaNota(string numeroNota)
        {
            bool result = false;
            try
            {
                string sql = "select 1 as Total " +
                " from COMEX_CARGA_NOTAS " +
                " WHERE NVL(STATUS,0) = 1" +
                " AND chave_Nota = '" + numeroNota + "'";

                OracleConnection oc = new OracleConnection(Conexao.StringDeConexao);
                OracleCommand da = new OracleCommand(sql, oc);

                using (oc)
                {
                    oc.Open();
                    OracleDataReader reader = da.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader["Total"] != DBNull.Value)
                        {
                            result = true;
                        }
                    }
                    oc.Close();
                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message, "Lista Carga Notas");
            }
            return result;
        }
    }
}
