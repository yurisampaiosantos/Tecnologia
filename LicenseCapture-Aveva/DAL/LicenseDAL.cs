using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using goliath.licensecapture.MOD;

namespace goliath.licensecapture.DAL
{
    public class LicenseDAL
    {
        public bool Insert(License license)
        {
            bool save = false;
            string userLogin = System.Environment.UserName;
            string sql = "";
            sql += " INSERT ";
            sql += " INTO LICENSE_AVEVA ";
            sql += "( ";            
            sql += "     SERVICE, ";
            sql += "     ISSUED, ";
            sql += "     USE, ";
            sql += "     USERS, ";
            sql += "     MARCHINE, ";
            sql += "     DATE_START, ";
            sql += "     HOURS ";            
            sql += ") ";
            sql += "   VALUES ";
            sql += "( ";
            sql += "     ?, ";
            sql += "     ?, ";
            sql += "     ?, ";
            sql += "     ?, ";
            sql += "     ?, ";
            sql += "     ?, ";
            sql += "     ? ";           
            sql += ") ";
            OleDbConnection con = new OleDbConnection(Dados.StringDeConexao);
            try
            {
                OleDbCommand comando = new OleDbCommand(sql, con);
                comando.Parameters.Add("@SERVICE", OleDbType.VarChar).Value = license.Service;
                comando.Parameters.Add("@ISSUED", OleDbType.VarChar).Value = license.Issued;
                comando.Parameters.Add("@USE", OleDbType.VarChar).Value = license.Use;
                comando.Parameters.Add("@USERS", OleDbType.VarChar).Value = license.Users;
                comando.Parameters.Add("@MARCHINE", OleDbType.VarChar).Value = license.Marchine;
                comando.Parameters.Add("@DATE_START", OleDbType.VarChar).Value = license.DateStart;
                comando.Parameters.Add("@HOURS", OleDbType.VarChar).Value = license.Hours;                
                con.Open();
                int count = comando.ExecuteNonQuery();
                con.Close();
                save = true;
            }
            catch
            {
                save = false;
            }
            finally
            {
                con.Close();
            }
            return save;
        }
    }
}
