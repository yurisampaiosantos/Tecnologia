using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using goliath.pdf.MOD;

namespace goliath.pdf.DAL
{
    public class UserDAL
    {
        public UserMOD Find(int id)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql = "";
            sql += "SELECT CREATION_DATE, MODEL_TYPE ||' - '||MODEL AS DESCRIPTION , CUST_EMAIL, ";
            sql += "  CUST_DISPLAY_NAME, SERIAL_NUMBER, NAME As TAG, (SELECT UO FROM ORG_UO WHERE ORG_UO.ID = VW_ASSET_MASTER.UO ) AS UO_DESCRIPTION, ";
            sql += "  (SELECT UA FROM ORG_UA WHERE ORG_UA.ID = VW_ASSET_MASTER.UA ) AS UA_DESCRIPTION, substr(cust_manager,instr(cust_manager,'CN=')+3, instr(cust_manager,',')-4) as LIDER ";
            sql += "FROM VW_ASSET_MASTER ";
            sql += "WHERE ID = " + id;

            OleDbConnection con = new OleDbConnection(connection.StringToConnect);
            OleDbCommand cmd = new OleDbCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            UserMOD results = new UserMOD();
            using (con)
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                //Verificando se retornou algum registro
                if (reader.Read())
                {
                    //Gerar informacoes
                   // if (reader["Id"] != DBNull.Value)
                    //    results.Comments = (string)reader["Id"];
                        results.DateNow = DateTime.Now.Date.ToString("dd/MM/yyyy");
                    if (reader["CREATION_DATE"] != DBNull.Value)
                        results.DateReg = Convert.ToDateTime(reader["CREATION_DATE"]).ToString("dd/MM/yyyy"); ;
                    if (reader["DESCRIPTION"] != DBNull.Value)
                        results.Description = (string)reader["DESCRIPTION"];
                    if (reader["CUST_EMAIL"] != DBNull.Value)
                        results.Email = (string)reader["CUST_EMAIL"];
                    if (reader["CUST_DISPLAY_NAME"] != DBNull.Value)
                        results.Name = (string)reader["CUST_DISPLAY_NAME"];
                    if (reader["SERIAL_NUMBER"] != DBNull.Value)
                        results.NumberSerial = (string)reader["SERIAL_NUMBER"];
                    if (reader["TAG"] != DBNull.Value)
                        results.Tag = (string)reader["TAG"];
                    if (reader["UA_DESCRIPTION"] != DBNull.Value)
                        results.Ua = (string)reader["UA_DESCRIPTION"];
                    if (reader["UO_DESCRIPTION"] != DBNull.Value)
                        results.Uo = (string)reader["UO_DESCRIPTION"];
                    if (reader["LIDER"] != DBNull.Value)
                        results.Lider = (string)reader["LIDER"];
                    else
                        results.Lider = "__________";
                }
                con.Close();

                return results;
            }
        }
    }
}
