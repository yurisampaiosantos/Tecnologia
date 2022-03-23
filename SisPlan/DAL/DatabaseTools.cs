using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Xml;
using System.Collections;
using System.Reflection;
using System.Web;
using Oracle.DataAccess.Client;

namespace DAL
{
    public class OracleDataTools
    {
        //============================================================================================
        //EEP_CONVERSION - DESENVOLVIMENTO - LCJUDBDEV01
        //internal static string StandardConnection = @"Data Source=LCJUDBDEV01.eepsa.com.br:1521/EEPCONVDEV.eepsa.com.br;User Id=EEP_CONVERSION;Password=eep_conversion@eep;PERSIST SECURITY INFO=True;";        

        //internal static string StandardConnection = @"Data Source=LCHLRAC-SCAN.eepsa.com.br:1521/EEPCONV;User Id=F_GL_CONVERSION ;Password=estaleiroSAF_GL_CONVERSION2013;PERSIST SECURITY INFO=True;";
        //EEP_CONVERSION - PRODUÇÃO - LCHLRAC
        internal static string StandardConnection = @"Data Source=LCJUDB01:1521/CJU01.intranet.local;User Id=F_GL_CONVERSION ;Password=estaleiroSAF_GL_CONVERSION2013;PERSIST SECURITY INFO=True;";


        //internal static string StandardConnection = System.Configuration.ConfigurationManager.ConnectionStrings[Convert.ToString(HttpContext.Current.Session["cnnKey"])].ConnectionString;
        //Enumerator for Connections
        public enum EnumConnection { EEP_CONVERSION_PRD, EEP_CONVERSION_DEV, E_TIME_APPROPRIATION_PRD, E_TIME_APPROPRIATION_DEV };
        //============================================================================================
        internal static string GetE_Connection(EnumConnection enumConnection)
        {
            string stdConn = "";
            switch (enumConnection)
            {
                case EnumConnection.E_TIME_APPROPRIATION_DEV: { break; }
                case EnumConnection.E_TIME_APPROPRIATION_PRD: { stdConn = @"Data Source=LCHLRAC-SCAN.eepsa.com.br:1521/EEPCONV;User Id=F_APP_TA;Password=f_app_taSAOra1978;PERSIST SECURITY INFO=True;"; break; }
                case EnumConnection.EEP_CONVERSION_DEV: { break; }
                case EnumConnection.EEP_CONVERSION_PRD: { stdConn = @"Data Source=LCHLRAC-SCAN.eepsa.com.br:1521/EEPCONV.eepsa.com.br;User Id=F_GL_CONVERSION ;Password=estaleiroSAF_GL_CONVERSION2013;PERSIST SECURITY INFO=True;"; break; }
            }
            return stdConn;
        }
        //============================================================================================
        //============================================================================================
        //============================================================================================
        public static bool DatabaseIsConnectable(EnumConnection enumConnection)
        {
            //string stdConn = GetStandardConnection(oracleDataConnection);
            bool bRet = false;
            using (OracleConnection conn = new OracleConnection(GetE_Connection(enumConnection)))
            {
                try
                {
                    conn.Open();
                    bRet = true;
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    throw new Exception("SQL Server does not exist or access denied");
                }
                finally { conn.Close(); }
            }
            return bRet;
        }
        //==========================================================================
        public static int ExecuteScalar(string strScalarQuery)
        {
            int value = 0;
            using (OracleConnection conn = new OracleConnection(StandardConnection))
            {
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(strScalarQuery, conn);
                    value = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex) { throw new Exception(PrepareMessage(ex.Message)); }
                finally { conn.Close(); }
            }
            return value;
        }
        //==========================================================================
        public static int ExecuteScalar(string strScalarQuery, OracleCommand cmd)
        {
            int value = 0;
            using (OracleConnection conn = new OracleConnection(StandardConnection))
            {
                try
                {
                    conn.Open();
                    cmd.Connection = conn;
                    value = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex) { throw new Exception(PrepareMessage(ex.Message)); }
                finally { conn.Close(); }
            }
            return value;
        }
        //==========================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            using (OracleConnection conn = new OracleConnection(StandardConnection))
            {
                try
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                { throw new Exception(PrepareMessage(ex.Message)); }
                finally { conn.Close(); }
            }
        }
        //==========================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            using (OracleConnection conn = new OracleConnection(StandardConnection))
            {
                try
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(strSQL, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(PrepareMessage(ex.Message));
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        //==========================================================================
        public static DataTable GetDataTable(string strSQL)
        {
            try
            {
                DataSet ds = new DataSet();
                OracleDataAdapter adap = new OracleDataAdapter();
                using (OracleConnection conn = new OracleConnection(OracleDataTools.StandardConnection))
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand(strSQL, conn);
                    adap.SelectCommand = cmd;
                    adap.Fill(ds);
                    cmd.Dispose();
                    //conn.Close();
                    conn.Dispose();
                }
                return ds.Tables[0];
            }
            catch (Exception ex) { throw new Exception(PrepareMessage(ex.Message)); }
        }
        //==========================================================================
        public static DataTable GetTableStructure(string tableName)
        {
            //try
            //{
            DataTable dt = null;
            //string tableStructure = "SELECT table_name,ordinal_position,column_name,data_type,  is_nullable,character_maximum_length FROM information_schema.COLUMNS WHERE table_name = '" + tableName + "' ORDER BY ordinal_position";
            //dt = GetDataTable(tableStructure);
            return dt;
            //}
            //catch (Exception ex) { throw new Exception(PrepareMessage(ex.Message)); }
        }
        //==========================================================================
        public static string ConvertSortSequence(string sortSequence, Hashtable dict)
        {
            IDictionaryEnumerator enumerator = dict.GetEnumerator();
            sortSequence = OracleDataTools.CleanSequence(ref sortSequence, enumerator);
            return sortSequence;
        }
        //==========================================================================
        public static List<T> LoadEntity<T>(string strSQL)
        {
            List<T> list = new List<T>();
            int numCampos = 0;
            PropertyInfo[] propriedades = typeof(T).GetProperties();
            Assembly objAssembly = Assembly.GetAssembly(typeof(T));
            //object instancia = objAssembly.CreateInstance(typeof(T).FullName, false);
            List<string> objCampos = new List<string>();
            using (OleDbConnection conn = new OleDbConnection(StandardConnection))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(strSQL, conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                numCampos = dr.FieldCount;
                while (dr.Read())
                {
                    for (int i = 0; i < numCampos; i++) objCampos.Add(dr.GetName(i).ToLower());
                    object instancia = objAssembly.CreateInstance(typeof(T).FullName, false);
                    #region [ Varre as propriedades atribuindo os valores do DataReader ]
                    foreach (PropertyInfo p in propriedades)
                    {
                        for (int j = 0; j < objCampos.Count; j++)
                        {
                            if (GetPropertyName(objCampos[j]) == p.Name)
                            {
                                object valorDr = dr.GetValue(j);
                                if (valorDr != DBNull.Value)
                                {
                                    if (!p.PropertyType.IsEnum)
                                    {
                                        if (Nullable.GetUnderlyingType(p.PropertyType) != null)
                                            p.SetValue(instancia, Convert.ChangeType(valorDr, Nullable.GetUnderlyingType(p.PropertyType)), null);
                                        else
                                        {
                                            object valorConvertido = Convert.ChangeType(valorDr, p.PropertyType);
                                            p.SetValue(instancia, valorConvertido, null);
                                        }
                                    }
                                    else
                                        p.SetValue(instancia, Enum.Parse(p.PropertyType, valorDr.ToString()), null);
                                }
                                break;
                            }
                        }
                    }
                    list.Add((T)instancia);
                    #endregion
                }
            }
            return list;
        }
        //==========================================================================
        public static T LoadEntity<T>(OleDbDataReader dr)  //Usada em MLD ReferenciaAcabamentoDAL.cs
        {
            PropertyInfo[] propriedades = typeof(T).GetProperties();
            Assembly objAssembly = Assembly.GetAssembly(typeof(T));
            object instancia = objAssembly.CreateInstance(typeof(T).FullName, false);
            List<string> objCampos = new List<string>();
            int numCampos = dr.FieldCount;
            for (int i = 0; i < numCampos; i++)
                objCampos.Add(dr.GetName(i).ToLower());
            #region [ Varre as propriedades atribuindo os valores do DataReader ]
            foreach (PropertyInfo p in propriedades)
            {
                if (objCampos.Contains(p.Name.ToLower()))
                {
                    object valorDr = dr[p.Name.ToLower()];
                    if (valorDr != DBNull.Value)
                    {
                        if (!p.PropertyType.IsEnum)
                        {
                            if (Nullable.GetUnderlyingType(p.PropertyType) != null)
                                p.SetValue(instancia, Convert.ChangeType(valorDr, Nullable.GetUnderlyingType(p.PropertyType)), null);
                            else
                            {
                                object valorConvertido = Convert.ChangeType(valorDr, p.PropertyType);
                                p.SetValue(instancia, valorConvertido, null);
                            }
                        }
                        else
                            p.SetValue(instancia, Enum.Parse(p.PropertyType, valorDr.ToString()), null);
                    }
                }
            }
            #endregion
            return (T)instancia;
        }
        //==========================================================================
        public static string ConvertFilterSequence(string filter, Hashtable dict)
        {
            IDictionaryEnumerator enumerator = dict.GetEnumerator();
            filter = OracleDataTools.CleanSequence(ref filter, enumerator);
            return filter;
        }
        //==========================================================================
        public static string CleanSequence(ref string sequence, IDictionaryEnumerator enumerator)
        {
            if (sequence != null)
            {
                while (sequence.IndexOf("  ") != -1)
                {
                    sequence = sequence.Replace("  ", " ");
                }
                sequence = sequence.Replace(", ", ",");
                sequence = sequence.Replace(" ,", ",");
                sequence = sequence.Replace("| ", "|");
                sequence = sequence.Replace(" |", "|");
                sequence = sequence.Trim();
                string[] sq = sequence.Split(',');
                sequence = "";
                for (int i = 0; i < sq.Length; i++)
                {
                    sq[i] = sq[i].Replace("|", " ");
                }
                for (int i = 0; i < sq.Length; i++)
                {
                    while (enumerator.MoveNext())
                    {
                        if (sq[i].IndexOf(enumerator.Key.ToString()) != -1)
                        {
                            sq[i] = sq[i].Replace(enumerator.Key.ToString(), enumerator.Value.ToString());
                            sequence += "," + sq[i];
                            break;
                        }
                    }
                }
                if (sequence != "") sequence = sequence.Substring(1);
            }
            return sequence;
        }
        //==========================================================================
        public static string ApplySQLComplement(string strSQL, string filter, string sortOrder)
        {
            if (filter != null && filter != "")
            {
                strSQL += " WHERE " + filter;
            }
            if (sortOrder != null && sortOrder != "")
            {
                strSQL += " ORDER BY " + sortOrder;
            }
            return strSQL;
        }
        //==========================================================================
        private static string PrepareMessage(string msg)
        {
            while (msg.IndexOf("\"") != -1)
            {
                msg = msg.Replace("\"", "");
            }
            return msg;
        }//======================================================
        public static string GetPropertyName(string nameColumn)
        {
            string s = nameColumn.ToLower();
            string sRet = GetPropertyNameCamel(nameColumn);
            sRet = sRet.Substring(0, 1).ToUpper() + sRet.Substring(1, sRet.Length - 1);
            return sRet;
        }
        //======================================================
        public static string GetPropertyNameCamel(string nameColumn)
        {
            string s = "";
            s = nameColumn.ToLower();
            //s = nameColumn.Substring(0, 1).ToLower() + nameColumn.Substring(1, nameColumn.Length - 1);
            string sRet = null;
            string c = null;
            for (int i = 0; i < s.Length; i++)
            {
                c = s.Substring(i, 1);
                if (c != "_")
                {
                    sRet += c;
                }
                else
                {
                    i++;
                    sRet += s.Substring(i, 1).ToUpper();
                }
            }
            if (sRet.Substring(sRet.Length - 2).ToUpper() == "ID")
            {
                sRet = sRet.Substring(0, sRet.Length - 2) + "Id";
            }
            return sRet;
        }
        //==========================================================================

    }
    //=====================================================================================================================
    //=====================================================================================================================
    //=====================================================================================================================
    public class OleDbDataTools
    {
        //============================================================================================
        internal static string StandardConnection = System.Configuration.ConfigurationManager.ConnectionStrings["Connectionmeninosdavilarj"].ConnectionString;
        //============================================================================================
        public static bool DatabaseIsConnectable()
        {
            bool bRet = false;
            using (OleDbConnection conn = new OleDbConnection(StandardConnection))
            {
                try
                {
                    conn.Open();
                    bRet = true;
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    throw new Exception("SQL Server does not exist or access denied");
                }
                finally { conn.Close(); }
            }
            return bRet;
        }
        //==========================================================================
        public static int ExecuteScalar(string strScalarQuery)
        {
            int value = 0;
            using (OleDbConnection conn = new OleDbConnection(StandardConnection))
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(strScalarQuery, conn);
                    value = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex) { throw new Exception(PrepareMessage(ex.Message)); }
                finally { conn.Close(); }
            }
            return value;
        }
        //==========================================================================
        public static int ExecuteScalar(string strScalarQuery, OleDbParameter[] param)
        {
            int value = 0;
            using (OleDbConnection conn = new OleDbConnection(StandardConnection))
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(strScalarQuery, conn);
                    for (byte p = 0; p < param.Length; p++) { cmd.Parameters.Add(param[p]); }
                    value = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex) { throw new Exception(PrepareMessage(ex.Message)); }
                finally { conn.Close(); }
            }
            return value;
        }
        //==========================================================================
        public static void ExecuteSQLInstruction(string strSQL, OleDbParameter[] param)
        {
            using (OleDbConnection conn = new OleDbConnection(StandardConnection))
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(strSQL, conn);
                    for (byte p = 0; p < param.Length; p++) { cmd.Parameters.Add(param[p]); }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                { throw new Exception(PrepareMessage(ex.Message)); }
                finally { conn.Close(); }
            }
        }
        //==========================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            using (OleDbConnection conn = new OleDbConnection(StandardConnection))
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(strSQL, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                { throw new Exception(PrepareMessage(ex.Message)); }
                finally { conn.Close(); }
            }
        }
        //==========================================================================
        public static DataTable GetDataTable(string strSQL)
        {
            try
            {
                DataSet ds = new DataSet();
                OleDbDataAdapter adap = new OleDbDataAdapter();
                using (OleDbConnection conn = new OleDbConnection(OleDbDataTools.StandardConnection))
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(strSQL, conn);
                    adap.SelectCommand = cmd;
                    adap.Fill(ds);
                    conn.Close();
                }
                return ds.Tables[0];
            }
            catch (Exception ex) { throw new Exception(PrepareMessage(ex.Message)); }
        }
        //==========================================================================
        public static DataTable GetTableStructure(string tableName)
        {
            //try
            //{
            DataTable dt = null;
            //string tableStructure = "SELECT table_name,ordinal_position,column_name,data_type,  is_nullable,character_maximum_length FROM information_schema.COLUMNS WHERE table_name = '" + tableName + "' ORDER BY ordinal_position";
            //dt = GetDataTable(tableStructure);
            return dt;
            //}
            //catch (Exception ex) { throw new Exception(PrepareMessage(ex.Message)); }
        }
        //==========================================================================
        public static string ConvertSortSequence(string sortSequence, Hashtable dict)
        {
            IDictionaryEnumerator enumerator = dict.GetEnumerator();
            sortSequence = OleDbDataTools.CleanSequence(ref sortSequence, enumerator);
            return sortSequence;
        }
        //==========================================================================
        public static OleDbDataReader GetDataReader(string strSQL)
        {
            try
            {
                OleDbDataReader dr;
                using (OleDbConnection conn = new OleDbConnection(OleDbDataTools.StandardConnection))
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(strSQL, conn);
                    dr = cmd.ExecuteReader();
                    return dr;
                }
            }
            catch (Exception ex) { throw new Exception(PrepareMessage(ex.Message)); }
        }
        //==========================================================================
        public static List<T> LoadEntity<T>(string strSQL)
        {
            List<T> list = new List<T>();
            int numCampos = 0;
            PropertyInfo[] propriedades = typeof(T).GetProperties();
            Assembly objAssembly = Assembly.GetAssembly(typeof(T));
            //object instancia = objAssembly.CreateInstance(typeof(T).FullName, false);
            List<string> objCampos = new List<string>();
            using (OleDbConnection conn = new OleDbConnection(StandardConnection))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(strSQL, conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                numCampos = dr.FieldCount;
                while (dr.Read())
                {
                    for (int i = 0; i < numCampos; i++) objCampos.Add(dr.GetName(i).ToLower());
                    object instancia = objAssembly.CreateInstance(typeof(T).FullName, false);
                    #region [ Varre as propriedades atribuindo os valores do DataReader ]
                    foreach (PropertyInfo p in propriedades)
                    {
                        for (int j = 0; j < objCampos.Count; j++)
                        {

                            if (GetPropertyName(objCampos[j]) == p.Name)
                            {
                                object valorDr = dr.GetValue(j);
                                if (valorDr != DBNull.Value)
                                {
                                    if (!p.PropertyType.IsEnum)
                                    {
                                        if (Nullable.GetUnderlyingType(p.PropertyType) != null)
                                            p.SetValue(instancia, Convert.ChangeType(valorDr, Nullable.GetUnderlyingType(p.PropertyType)), null);
                                        else
                                        {
                                            object valorConvertido = Convert.ChangeType(valorDr, p.PropertyType);
                                            p.SetValue(instancia, valorConvertido, null);
                                        }
                                    }
                                    else
                                        p.SetValue(instancia, Enum.Parse(p.PropertyType, valorDr.ToString()), null);
                                }
                                break;
                            }
                        }
                    }
                    list.Add((T)instancia);
                }
            }
                    #endregion
            return list;
        }
        //==========================================================================
        public static string ConvertFilterSequence(string filter, Hashtable dict)
        {
            IDictionaryEnumerator enumerator = dict.GetEnumerator();
            filter = OleDbDataTools.CleanSequence(ref filter, enumerator);
            return filter;
        }
        //==========================================================================
        public static string CleanSequence(ref string sequence, IDictionaryEnumerator enumerator)
        {
            if (sequence != null)
            {
                while (sequence.IndexOf("  ") != -1)
                {
                    sequence = sequence.Replace("  ", " ");
                }
                sequence = sequence.Replace(", ", ",");
                sequence = sequence.Replace(" ,", ",");
                sequence = sequence.Replace("| ", "|");
                sequence = sequence.Replace(" |", "|");
                sequence = sequence.Trim();
                string[] sq = sequence.Split(',');
                sequence = "";
                for (int i = 0; i < sq.Length; i++)
                {
                    sq[i] = sq[i].Replace("|", " ");
                }
                for (int i = 0; i < sq.Length; i++)
                {
                    while (enumerator.MoveNext())
                    {
                        if (sq[i].IndexOf(enumerator.Key.ToString()) != -1)
                        {
                            sq[i] = sq[i].Replace(enumerator.Key.ToString(), enumerator.Value.ToString());
                            sequence += "," + sq[i];
                            break;
                        }
                    }
                }
                if (sequence != "") sequence = sequence.Substring(1);
            }
            return sequence;
        }
        //==========================================================================
        public static string ApplySQLComplement(string strSQL, string filter, string sortOrder)
        {
            if (filter != null && filter != "")
            {
                strSQL += " WHERE " + filter;
            }
            if (sortOrder != null && sortOrder != "")
            {
                strSQL += " ORDER BY " + sortOrder;
            }
            return strSQL;
        }
        //==========================================================================
        private static string PrepareMessage(string msg)
        {
            while (msg.IndexOf("\"") != -1)
            {
                msg = msg.Replace("\"", "");
            }
            return msg;
        }
        //======================================================
        public static string GetPropertyName(string nameColumn)
        {
            string s = nameColumn.ToLower();
            string sRet = GetPropertyNameCamel(nameColumn);
            sRet = sRet.Substring(0, 1).ToUpper() + sRet.Substring(1, sRet.Length - 1);
            return sRet;
        }
        //======================================================
        public static string GetPropertyNameCamel(string nameColumn)
        {
            string s = "";
            s = nameColumn.ToLower();
            //s = nameColumn.Substring(0, 1).ToLower() + nameColumn.Substring(1, nameColumn.Length - 1);
            string sRet = null;
            string c = null;
            for (int i = 0; i < s.Length; i++)
            {
                c = s.Substring(i, 1);
                if (c != "_")
                {
                    sRet += c;
                }
                else
                {
                    i++;
                    sRet += s.Substring(i, 1).ToUpper();
                }
            }
            if (sRet.Substring(sRet.Length - 2).ToUpper() == "ID")
            {
                sRet = sRet.Substring(0, sRet.Length - 2) + "Id";
            }
            return sRet;
        }
        //==========================================================================

    }
}