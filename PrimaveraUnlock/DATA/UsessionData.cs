using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Data;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;

namespace DATA
{
    public class UsessionData
    {

        public List<Usession> SelectUsession(string connection)
        {
            ///Metodo para Listar todos no banco
            ///
            ConnectionString connectionString = new ConnectionString();

            OracleConnection con = new OracleConnection(connectionString.Connection(connection));
            OracleCommand  cmd = new OracleCommand ("Select * from ADMUSER.USESSION WHERE DELETE_SESSION_ID IS NULL ORDER BY SESSION_ID", con);

            cmd.CommandType = CommandType.Text;
            List<Usession> results = new List<Usession>();

            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                //Verificando se retornou algum registro
                while (reader.Read())
                {
                    //Gerar informacoes

                    Usession usession = new Usession();

                    if (reader["SESSION_ID"] != DBNull.Value)
                        usession.SessionId = Convert.ToDecimal(reader["SESSION_ID"]);

                    if (reader["LOGIN_TIME"] != DBNull.Value)
                        usession.LoginTime = (DateTime)reader["LOGIN_TIME"];

                    if (reader["LAST_ACTIVE_TIME"] != DBNull.Value)
                        usession.LastActiveTime = (DateTime)reader["LAST_ACTIVE_TIME"];

                    if (reader["HOST_NAME"] != DBNull.Value)
                        usession.HostName = (string)reader["HOST_NAME"];

                    if (reader["APP_NAME"] != DBNull.Value)
                        usession.AppName = (string)reader["APP_NAME"];

                    if (reader["OS_USER_NAME"] != DBNull.Value)
                        usession.OsUserName = (string)reader["OS_USER_NAME"];

                    if (reader["UPDATE_USER"] != DBNull.Value)
                        usession.UpdateUser = (string)reader["UPDATE_USER"];

                    results.Add(usession);
                }

                con.Close();

                return results;
            }
        }

        public void UpdateUsession(string connection, decimal sessionId)
        {
            ///Metodo para update no banco
            ///
            ConnectionString connectionString = new ConnectionString();
            string sql = "";
            sql += " UPDATE ";
            sql += "ADMUSER.USESSION set ";
            sql += "DELETE_SESSION_ID = 0 ";
            sql += "WHERE SESSION_ID = " + sessionId;
            OracleConnection con = new OracleConnection(connectionString.Connection(connection));
            try
            {
                OracleCommand  cmd = new OracleCommand (sql, con);                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }
    
    }
}
