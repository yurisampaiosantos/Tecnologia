using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Oracle;
using System.Data;
using GridCarregamento.Modelo;

using Oracle.DataAccess.Client;


namespace GridCarregamento.DAL
{
    public class TabelaDAL
    {
        public DataTable ListArea()
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";
            sql += "  SELECT ID AS ID, AREA_DESCRIPTION as DESCRICAO FROM ETA.TA_AREAS ORDER BY AREA_DESCRIPTION ";

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);

                return table;
            }
        }
        public DataTable ListAreaGroup(decimal groupId)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";
            sql += "  SELECT  DISTINCT AREA_ID AS ID, (SELECT AREA_DESCRIPTION FROM  ETA.TA_AREAS WHERE ID = AREA_ID) as DESCRICAO ";
            sql += "  FROM ETA.TA_TEAM  ";
            sql += "  WHERE AREA_ID IS NOT NULL  ";
            sql += "  AND GROUP_ID =  " + groupId;
            sql += "  ORDER BY DESCRICAO  ";

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);

                return table;
            }
        }
        public DataTable ListCraft(decimal team_id)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";
            sql += "  select TA_TEAM_X_CRAFT.CRAFT_ID as id, TA_CRAFT.NAME as Descricao ";
            sql += "  FROM ETA.TA_TEAM_X_CRAFT,ETA.TA_CRAFT ";
            sql += "  WHERE TA_TEAM_X_CRAFT.CRAFT_ID = TA_CRAFT.EMP_NUMBER ";
            sql += "  AND  TA_TEAM_X_CRAFT.TEAM_ID = " + team_id;
            sql += "  AND  TA_CRAFT.STATUS <> 0 ";
            sql += "  order by TA_CRAFT.NAME ";

            DataTable table = new DataTable(); 
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);

                return table;
            }
        }
        public DataTable ListCraftUnion(decimal team_id, string date)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";

            sql += "  SELECT DISTINCT * FROM (select TA_TEAM_X_CRAFT.CRAFT_ID as id, TA_CRAFT.NAME as Descricao ";
            sql += "  FROM ETA.TA_TEAM_X_CRAFT,ETA.TA_CRAFT  ";
            sql += "  WHERE TA_TEAM_X_CRAFT.CRAFT_ID = TA_CRAFT.EMP_NUMBER  ";
            sql += "  AND  TA_TEAM_X_CRAFT.TEAM_ID = :TEAM_ID ";
            sql += "  AND  TA_TEAM_X_CRAFT.INIT_DATE <= to_date('" + date + " 23:59:59'" + ",'DD/MM/YYYY HH24:mi:ss') ";
            sql += "  AND  TA_CRAFT.STATUS <> 0  ";
            sql += "  UNION ";
            sql += "  SELECT CRAFT_ID as id, (SELECT TA_CRAFT.NAME FROM ETA.TA_CRAFT WHERE TA_CRAFT.EMP_NUMBER = TA_TIMESHEET.CRAFT_ID) as Descricao ";
            sql += "  FROM ETA.TA_TIMESHEET  ";
            sql += "  WHERE TEAM_ID = :TEAM_ID ";
            //sql += "  AND EXECUTION_DATE = :EXECUTION_DATE  ";
            sql += "  AND EXECUTION_DATE = TO_DATE('" + date + "','DD/MM/YYYY')";
            sql += "  UNION ";
            sql += "  SELECT TA_TEAM_X_CRAFT_HISTORY.CRAFT_ID as id, TA_CRAFT.NAME as Descricao ";
            sql += "  FROM ETA.TA_TEAM_X_CRAFT_HISTORY,ETA.TA_CRAFT  ";
            sql += "  WHERE TA_TEAM_X_CRAFT_HISTORY.CRAFT_ID = TA_CRAFT.EMP_NUMBER  ";
            sql += "  AND  TA_TEAM_X_CRAFT_HISTORY.TEAM_ID = :TEAM_ID ";
            sql += "  AND  TA_TEAM_X_CRAFT_HISTORY.FINAL_DATE >= TO_DATE('" + date + " 23:59:59'" + ",'DD/MM/YYYY HH24:mi:ss') ";
            sql += "  AND  TA_CRAFT.STATUS <> 0 ) ";
            sql += "  order by Descricao ";

            DataTable table = new DataTable(); 
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);
            cmd.Parameters.Add(":TEAM_ID", OracleDbType.Decimal).Value = team_id;
           // cmd.Parameters.Add(":EXECUTION_DATE", OracleDbType.Date).Value = Dados.DataString(date);
            cmd.Parameters.Add(":TEAM_ID", OracleDbType.Decimal).Value = team_id;
            //cmd.Parameters.Add(":EXECUTION_DATE", OracleDbType.Date).Value = Dados.DataString(date);
            cmd.Parameters.Add(":TEAM_ID", OracleDbType.Decimal).Value = team_id;
           
            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);

                return table;
            }
        }
        public DataTable ListCraftLeaderSupervisor(decimal team_id)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";
            sql += "  select  (SELECT TA_CRAFT.EMP_NUMBER || " + "' - '" + " || NAME FROM ETA.TA_CRAFT WHERE TA_CRAFT.EMP_NUMBER = TA_TEAM.LEADER_ID) as LEADER_ID, ";
            sql += "          (SELECT TA_CRAFT.EMP_NUMBER || " + "' - '" + " || NAME FROM ETA.TA_CRAFT WHERE TA_CRAFT.EMP_NUMBER = TA_TEAM.SUPERVISOR_ID) as SUPERVISOR_ID";
            sql += "  FROM ETA.TA_TEAM ";
            sql += "  WHERE ID = " + team_id;
            sql += "  AND  STATUS <> 0 ";

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);

                return table;
            }
        }
        public DataTable ListCraftLeaderSupervisorID(decimal team_id)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";
            sql += "  select  TA_TEAM.LEADER_ID, TA_TEAM.SUPERVISOR_ID ";
            sql += "  FROM ETA.TA_TEAM ";
            sql += "  WHERE ID = " + team_id;
            sql += "  AND  STATUS <> 0 ";

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);

                return table;
            }
        }
        public DataTable ListCraft(string listCraftUsed, string id_name)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";
            sql += "  select TA_CRAFT.EMP_NUMBER as id, TA_CRAFT.NAME as Descricao ";
            sql += "  FROM ETA.TA_CRAFT ";
            sql += "  WHERE UPPER(TA_CRAFT.EMP_NUMBER || TA_CRAFT.NAME) like UPPER('%" + id_name + "%')";
            sql += "  AND STATUS <> 0 ";
            if (listCraftUsed != "")
            {
                sql += "  AND  TA_CRAFT.EMP_NUMBER NOT IN (" + listCraftUsed + ")";
            }
            sql += "  order by TA_CRAFT.NAME ";

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);

                return table;
            }
        }
        public DataTable ListActivities(decimal team_id)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";

            sql += "  SELECT TA_ACTIVITIES.ID as id, ";
            sql += "  CASE WHEN ID > 0 THEN ";
            sql += "      TA_ACTIVITIES.TA_UA  ";
            sql += "  ELSE  ";
            sql += "      TA_ACTIVITIES.TITLE  ";
            sql += "  END as Descricao  ";
          //  sql += "    TA_ACTIVITIES.TITLE as Descricao  ";
            sql += "  FROM ETA.TA_TIMESHEET_TEMPLATE,ETA.TA_ACTIVITIES ";
            sql += "  WHERE  ACTIVITY_ID = TA_ACTIVITIES.ID ";
            sql += "  AND TA_TIMESHEET_TEMPLATE.TEAM_ID = " + team_id;
            sql += "  AND TA_ACTIVITIES.STATUS <> 0 ";
            sql += "  AND DISCIPLINE_ID = 'PEP' ";
            sql += "  ORDER BY TA_ACTIVITIES.TITLE ";

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);

                return table;
            }
        }
        public DataTable ListActivitiesUnion(decimal team_id, string date)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";
            sql += "  SELECT DISTINCT ACTIVITY_ID, (SELECT ";
            sql += "                                CASE WHEN ID > 0 THEN ";
            sql += "                                     TA_ACTIVITIES.TA_UA  ";
            sql += "                                ELSE  ";
            sql += "                                     TA_ACTIVITIES.TITLE  ";
            sql += "                                END as Descricao  ";
            sql += "                                FROM ETA.TA_ACTIVITIES WHERE TA_ACTIVITIES.ID = TA_TIMESHEET.ACTIVITY_ID) AS ACTIVITY_NAME ";
            sql += "  FROM ETA.TA_TIMESHEET  ";
            sql += "  WHERE TEAM_ID = :TEAM_ID ";
            sql += "  AND EXECUTION_DATE = TO_DATE('" + date + "','DD/MM/YYYY') ";
            sql += "  ORDER BY ACTIVITY_NAME ";

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);
            cmd.Parameters.Add(":TEAM_ID", OracleDbType.Decimal).Value = team_id;
            //cmd.Parameters.Add(":EXECUTION_DATE", OracleDbType.Date).Value = Dados.DataString(date);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);

                return table;
            }
        }
        public DataTable ListActivities(string listActivitieUsed, string title)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";

            sql += "  SELECT TA_ACTIVITIES.ID as id, ";
            sql += "  CASE WHEN ID > 0 THEN ";
            sql += "      TA_ACTIVITIES.TA_UA  ";
            sql += "  ELSE  ";
            sql += "      TA_ACTIVITIES.TITLE  ";
            sql += "  END as UA,  ";
            sql += "  TA_ACTIVITIES.TITLE as Titulo,  ";            
            sql += "  TA_ACTIVITIES.COMMENTS as Descricao  ";
            sql += "  FROM ETA.TA_ACTIVITIES ";
            sql += "  WHERE UPPER(id||TA_ACTIVITIES.TA_UA||COMMENTS||TA_ACTIVITIES.TITLE) like UPPER('%" + title + "%')";
            sql += "  AND STATUS <> 0 ";
            sql += "  AND DISCIPLINE_ID = 'PEP' ";
            if (listActivitieUsed != "")
            {
                sql += "  AND  TA_ACTIVITIES.ID NOT IN (" + listActivitieUsed + ")";
            }
            sql += "  ORDER BY TA_ACTIVITIES.TITLE ";

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);

                return table;
            }
        }
        public DataTable ListTeam()
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";
            sql += "  select ID as id, NAME as Descricao ";
            sql += "  FROM ETA.TA_TEAM ";
            sql += "  where  NAME is not null ";
            sql += "  AND STATUS <> 0 ";
            sql += "  AND EXISTS (SELECT ID FROM ETA.TA_TEAM_X_CRAFT WHERE TA_TEAM_X_CRAFT.TEAM_ID = TA_TEAM.ID) ";
            sql += "  order by NAME ";

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);

                return table;
            }
        }
        public DataTable GetTeamCodeByID(string teamId)
        {
            ///Metodo para obter TEAM_CODE de TA_TEAM
            ///
            string sql;
            sql = "SELECT TEAM_CODE FROM ETA.TA_TEAM WHERE ID = " + teamId;

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);

                return table;
            }
        }
        public DataTable ListGroup()
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";
            sql += "  SELECT ID as id, GROUP_TEAM_DESCRIPTION as Descricao  ";
            sql += "  FROM ETA.TA_GROUP_TEAM ";
            sql += "  WHERE STATUS = 0 ";
        //    sql += "  AND ID <> 1 ";
            sql += "  order by GROUP_TEAM_DESCRIPTION ";

            DataTable table = new DataTable();
            //OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            //OracleCommand cmd = new OracleCommand(sql, con);
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
               //OracleDataReader reader = cmd.ExecuteReader();
               OracleDataReader reader = cmd.ExecuteReader();

                table.Load(reader);

                return table;
            }
        }
        public DataTable ListTeamArea(decimal idArea, string date, decimal idGrup)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";
            //sql += "  SELECT ID as id, NAME || ' (' || LEADER_ID || '-' || (select name from ETA.TA_CRAFT WHERE EMP_NUMBER = LEADER_ID) || ')' as Descricao , Shift as Turno  ";
            sql += "  SELECT ID as id, (SELECT NAME || ' (' || LEADER_ID || ')' FROM ETA.TA_CRAFT WHERE EMP_NUMBER = LEADER_ID) as Descricao, Shift as Turno ";
            sql += "  FROM ETA.TA_TEAM ";
            sql += "  where AREA_ID = " + idArea;
            sql += "  AND GROUP_ID = " + idGrup;
            sql += "  AND STATUS <> 0 ";
            sql += "  AND (EXISTS (SELECT ID FROM ETA.TA_TEAM_X_CRAFT WHERE TA_TEAM_X_CRAFT.TEAM_ID = TA_TEAM.ID AND INIT_DATE <= to_date('" + date + " 23:59:59'" + ",'DD/MM/YYYY HH24:mi:ss') ) ";
            sql += "  OR EXISTS (SELECT ID FROM ETA.TA_TEAM_X_CRAFT_HISTORY WHERE TA_TEAM_X_CRAFT_HISTORY.TEAM_ID = TA_TEAM.ID AND FINAL_DATE >= to_date('" + date + " 23:59:59'" + ",'DD/MM/YYYY HH24:mi:ss'))) ";
            sql += "  ORDER BY NAME ";

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);
         //   cmd.Parameters.Add(":DATE", OracleDbType.datet).Value = Dados.DataString(date) + " 23:59:59";
         //   cmd.Parameters.Add(":DATE", OracleDbType.Date).Value = Dados.DataString(date) + " 23:59:59";

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);

                return table;
            }
        }        
        public DataTable ListTeam(decimal idTeam)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";
            //sql += "  select ID as id, NAME as Descricao, (SELECT AREA_DESCRIPTION FROM ETA.TA_AREAS WHERE ID = AREA_ID) as Turno, TEAM_CODE  ";
            //sql += "  FROM ETA.TA_TEAM ";
            //sql += "  where ID = " + idTeam;
            //sql += "  AND STATUS <> 0 ";


            sql += " SELECT T.ID as id, T.NAME as Descricao, (SELECT A.AREA_DESCRIPTION FROM ETA.TA_AREAS A WHERE A.ID = T.AREA_ID) as Turno, T.TEAM_CODE, T.GROUP_ID, G.GROUP_TEAM_DESCRIPTION";
            sql += " FROM ETA.TA_TEAM T, ETA.TA_GROUP_TEAM G ";
            sql += " WHERE T.ID = " + idTeam;
            sql += " AND T.STATUS <> 0 AND G.ID = T.GROUP_ID";

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);

                return table;
            }
        }
        public decimal TeamArea(decimal idTeam)
        {
            ///Metodo para Listar todos no banco
            ///
            decimal result = 0;
            string sql;
            sql = "";
            sql += "  select AREA_ID AREA  ";
            sql += "  FROM ETA.TA_TEAM ";
            sql += "  where ID = " + idTeam;
            sql += "  AND STATUS <> 0 ";

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["AREA"] != DBNull.Value)
                    {
                        result = Convert.ToDecimal(reader["AREA"]);
                    }
                }
                return result;
            }
        }
        public decimal TeamGroup(decimal idTeam)
        {
            ///Metodo para Listar todos no banco
            ///
            decimal result = 0;
            string sql;
            sql = "";
            sql += "  select GROUP_ID AS GROUP_ID  ";
            sql += "  FROM ETA.TA_TEAM ";
            sql += "  where ID = " + idTeam;
            sql += "  AND STATUS <> 0 ";

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["GROUP_ID"] != DBNull.Value)
                    {
                        result = Convert.ToDecimal(reader["GROUP_ID"]);
                    }
                }
                return result;
            }
        }
        public DataTable ListTimeSheets(decimal team_id, string date)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";
            sql += "  SELECT ACTIVITY_ID, ";
            sql += "  CRAFT_ID, ";
            sql += "  WORKED_HOURS, OVERTIME_HOURS, SPECIAL_SITUATION  ";
            sql += "  FROM ETA.TA_TIMESHEET ";
            sql += "  WHERE TEAM_ID = :TEAM_ID";
            sql += "  AND EXECUTION_DATE = TO_DATE('" + date + "','DD/MM/YYYY') ";
            sql += "  ORDER BY ID  ";

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);
            cmd.Parameters.Add(":TEAM_ID", OracleDbType.Decimal).Value = team_id;
            //cmd.Parameters.Add(":EXECUTION_DATE", OracleDbType.Date).Value = Dados.DataString(date);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);

                return table;
            }
        }        
        public bool SaveTimeSheetTemplate(List<ListTimeSheetsAll> listTimeSheetsAll)
        {
            bool save = false;
            using (OracleConnection con = new OracleConnection(Dados.StringDeConexao))
            {
                con.Open();

                OracleCommand comando = con.CreateCommand();
                OracleTransaction transaction;
                transaction = con.BeginTransaction(IsolationLevel.ReadCommitted);
                // Assign transaction object for a pending local transaction
                comando.Transaction = transaction;

                string userLogin = System.Environment.UserName;
                string sql;

                try
                {
                    sql = "";
                    sql += "  DELETE ETA.TA_TIMESHEET ";
                    sql += "  WHERE TEAM_ID = :TEAM_ID";
                    sql += "  AND EXECUTION_DATE = :EXECUTION_DATE";

                    comando.CommandText = sql;
                    comando.Parameters.Add(":TEAM_ID", OracleDbType.Decimal).Value = listTimeSheetsAll[0].TeamId;
                    comando.Parameters.Add(":EXECUTION_DATE", OracleDbType.Date).Value = Dados.DataString(listTimeSheetsAll[0].ExecutionDate);
                    comando.ExecuteNonQuery();

                    foreach (ListTimeSheetsAll timeSheetsAll in listTimeSheetsAll) // Loop through List with foreach
                    {
                        sql = "";
                        sql += " INSERT ";
                        sql += " INTO ETA.TA_TIMESHEET ";
                        sql += "   ( ";
                        sql += "     ACTIVITY_ID, ";
                        sql += "     CRAFT_ID, ";
                        sql += "     TEAM_ID, ";
                        sql += "     WORKED_HOURS, ";
                        sql += "     OVERTIME_HOURS, ";
                        sql += "     EXECUTION_DATE, ";
                        sql += "     CREATED_BY, ";
                        sql += "     SPECIAL_SITUATION, ";
                        sql += "     TURN, ";
                        sql += "     STATUS, ";
                        sql += "     AREA_ID, ";
                        sql += "     GROUP_TEAM_ID, ";
                        sql += "     LEADER_ID, ";
                        sql += "     SUPERVISOR_ID ";
                        sql += "   ) ";
                        sql += "   VALUES ";
                        //sql += "  (?,?,?,?,?,?,?,?,?,?,?,?,?,?) ";
                        sql += "   ( ";
                        sql += "     :ACTIVITY_ID, ";
                        sql += "     :CRAFT_ID, ";
                        sql += "     :TEAM_ID, ";
                        sql += "     :WORKED_HOURS, ";
                        sql += "     :OVERTIME_HOURS, ";
                        sql += "     :EXECUTION_DATE, ";
                        sql += "     :CREATED_BY, ";
                        sql += "     :SPECIAL_SITUATION, ";
                        sql += "     :TURN, ";
                        sql += "     :STATUS, ";
                        sql += "     :AREA_ID, ";
                        sql += "     :GROUP_TEAM_ID, ";
                        sql += "     :LEADER_ID, ";
                        sql += "     :SUPERVISOR_ID ";
                        sql += "   ) ";

                        comando.CommandText = sql;
                        comando.Parameters.Clear();

                        comando.Parameters.Add(":ACTIVITY_ID", OracleDbType.Decimal).Value = timeSheetsAll.ActivetyId;
                        comando.Parameters.Add(":CRAFT_ID", OracleDbType.Decimal).Value = timeSheetsAll.CraftId;
                        comando.Parameters.Add(":TEAM_ID", OracleDbType.Decimal).Value = timeSheetsAll.TeamId;
                        comando.Parameters.Add(":WORKED_HOURS", OracleDbType.Decimal).Value = timeSheetsAll.WorkedHours;
                        comando.Parameters.Add(":OVERTIME_HOURS", OracleDbType.Decimal).Value = timeSheetsAll.WorkedOverTime;
                        comando.Parameters.Add(":EXECUTION_DATE", OracleDbType.Date).Value = Dados.DataString(timeSheetsAll.ExecutionDate);
                        comando.Parameters.Add(":CREATED_BY", OracleDbType.Varchar2).Value = userLogin;
                        comando.Parameters.Add(":SPECIAL_SITUATION", OracleDbType.Varchar2).Value = timeSheetsAll.SpecialSituation;
                        comando.Parameters.Add(":TRUN", OracleDbType.Varchar2).Value = timeSheetsAll.Turno;
                        comando.Parameters.Add(":STATUS", OracleDbType.Decimal).Value = timeSheetsAll.Inconsistency;
                        comando.Parameters.Add(":AREA_ID", OracleDbType.Decimal).Value = timeSheetsAll.AreaId;
                        comando.Parameters.Add(":GROUP_TEAM_ID", OracleDbType.Decimal).Value = timeSheetsAll.GrupoId;
                        comando.Parameters.Add(":LEADER_ID", OracleDbType.Decimal).Value = timeSheetsAll.LeaderId;
                        comando.Parameters.Add(":SUPERVISOR_ID", OracleDbType.Decimal).Value = timeSheetsAll.SupervisorId;

                        comando.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    save = true;
                }
                catch 
                {
                    transaction.Rollback();
                    save = false;
                }
                finally
                {
                    con.Close();
                }
            }
            return save;
        }
        public string AllHoursCraft(decimal craftId, decimal teamId,string date)
        {
            ///Metodo para Listar todos no banco
            ///
            string result = "";
            string sql;
            sql = "";
            sql += "  SELECT SUM(WORKED_HOURS) as WORKED_HOURS, SUM(OVERTIME_HOURS) as OVERTIME_HOURS ";
            sql += "  FROM ETA.TA_TIMESHEET ";
            sql += "  WHERE TEAM_ID <> :TEAM_ID";
            sql += "  AND CRAFT_ID = :CRAFT_ID";
            sql += "  AND EXECUTION_DATE = :EXECUTION_DATE";            

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);
            cmd.Parameters.Add(":TEAM_ID", OracleDbType.Decimal).Value = teamId;
            cmd.Parameters.Add(":CRAFT_ID", OracleDbType.Decimal).Value = craftId;
            cmd.Parameters.Add(":EXECUTION_DATE", OracleDbType.Date).Value = Dados.DataString(date);

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
                result = table.Rows[0][0].ToString() + "|" + table.Rows[0][1].ToString();
                return result;
            }
        }
        public DataTable ListValidation(string date)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";
            sql += "  select sum(status),TEAM_ID,(Select NAME FROM ETA.TA_TEAM WHERE ID = TEAM_ID) as NAME,sum(WORKED_HOURS),sum(OVERTIME_HOURS),count(distinct CRAFT_ID) ";
            sql += "  FROM ETA.TA_TIMESHEET ";
            //sql += "  WHERE EXECUTION_DATE = ?";
            //sql += "  WHERE EXECUTION_DATE = :EXECUTION_DATE";
            sql += "  WHERE EXECUTION_DATE = TO_DATE('" + date + "','DD/MM/YYYY')";
            sql += "  GROUP BY TEAM_ID,trunc(CREATED_DATE) ";
            sql += "  order by trunc(CREATED_DATE) desc ";

            DataTable table = new DataTable();
            //OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            //OracleCommand cmd = new OracleCommand(sql, con);
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);
            //cmd.Parameters.Add(":EXECUTION_DATE", OracleDbType.Date).Value = Dados.DataString(date);
            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                //OracleDataReader reader = cmd.ExecuteReader();
                OracleDataReader reader = cmd.ExecuteReader();
                table.Load(reader);

                return table;
            }
        }
        public List<ListTimeSheets> PrintTimeSheets(decimal team_id, string date)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
          //  decimal OldTeamId = -1;
            int cntOne = 1;
            sql = "";
            sql += "  SELECT ROWNUM AS LINHA, R.* from (select TA_TEAM_X_CRAFT.TEAM_ID, TA_TEAM_X_CRAFT.CRAFT_ID as CRAFT_ID, TA_CRAFT.NAME as CRAFT_NAME, TA_CRAFT.JOB_TITLE as JOB_TITLE";
            sql += "  FROM ETA.TA_TEAM_X_CRAFT,ETA.TA_CRAFT ";
            sql += "  WHERE TA_TEAM_X_CRAFT.CRAFT_ID = TA_CRAFT.EMP_NUMBER ";
            sql += "  AND  TA_TEAM_X_CRAFT.TEAM_ID = " + team_id;
            sql += "  AND TA_CRAFT.STATUS <> 0 ";
            sql += "  order by TA_TEAM_X_CRAFT.TEAM_ID,TA_CRAFT.NAME) R ";

            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);
            List<ListTimeSheets> resultListTimeSheets = new List<Modelo.ListTimeSheets>();
            cmd.CommandType = CommandType.Text;
            int groupId = 1;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListTimeSheets listTimeSheets = new ListTimeSheets();
                    listTimeSheets.Linha = reader["LINHA"].ToString().PadLeft(2, '0');
                    listTimeSheets.TeamId = Convert.ToDecimal(reader["TEAM_ID"]);
                    listTimeSheets.Matricula = reader["CRAFT_ID"].ToString().PadLeft(4, '0');
                    listTimeSheets.Nome = reader["CRAFT_NAME"].ToString();//.Substring(0, reader["CRAFT_NAME"].ToString().IndexOf(' ', 0));
                    listTimeSheets.Funcao = reader["JOB_TITLE"].ToString();
                    listTimeSheets.Nome = FirstLastName(listTimeSheets.Nome);
                    listTimeSheets.GroupId = groupId;
                    //---start variable
                   /* if (OldTeamId == -1)
                        OldTeamId = listTimeSheets.TeamId;
                    //---  
                    if (OldTeamId != listTimeSheets.TeamId)
                    {
                        while (cntOne < 36)
                        {
                            ListTimeSheets listTimeSheetsWhite = new ListTimeSheets();
                            listTimeSheetsWhite.TeamId = OldTeamId;
                            listTimeSheetsWhite.Matricula = "  ";
                            listTimeSheetsWhite.Nome = "  ";
                            listTimeSheetsWhite.Funcao = "  ";
                            resultListTimeSheets.Add(listTimeSheetsWhite);
                            cntOne++;
                        }
                        OldTeamId = listTimeSheets.TeamId;
                        cntOne = 0;
                    } 
                    */
                    resultListTimeSheets.Add(listTimeSheets);                    
                    if (cntOne % 15 == 0)
                    {
                        groupId++;
                        cntOne = 0;
                    }
                    cntOne++;
                }
                if (cntOne != 1)
                {
                    while (cntOne < 15)
                    {
                        ListTimeSheets listTimeSheetsWhite = new ListTimeSheets();
                        listTimeSheetsWhite.TeamId = team_id;
                        listTimeSheetsWhite.GroupId = groupId;
                        listTimeSheetsWhite.Linha = "  ";
                        listTimeSheetsWhite.Matricula = "  ";
                        listTimeSheetsWhite.Nome = "  ";
                        listTimeSheetsWhite.Funcao = "  ";
                        resultListTimeSheets.Add(listTimeSheetsWhite);
                        cntOne++;
                    }
                }
                con.Close();
                return resultListTimeSheets;
            }
        }
        public List<ListActivities> PrintActivities(decimal team_id)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
           // decimal OldTeamId = -1;
            int cntOne = 0;
            sql = "";
            sql += "  SELECT TEAM_ID as id, ";
            sql += "    TA_ACTIVITIES.TITLE as Descricao  ";
            sql += "  FROM ETA.TA_TIMESHEET_TEMPLATE,ETA.TA_ACTIVITIES ";
            sql += "  WHERE  ACTIVITY_ID = TA_ACTIVITIES.ID ";
            sql += "  AND TA_TIMESHEET_TEMPLATE.TEAM_ID = " + team_id;
            sql += "  AND TA_ACTIVITIES.STATUS <> 0 ";
            sql += "  ORDER BY TA_ACTIVITIES.TITLE ";

            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);
            List<ListActivities> resultListActivities = new List<ListActivities>();
            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListActivities listActivities = new ListActivities();
                    listActivities.TeamId = Convert.ToDecimal(reader["ID"]);
                    listActivities.Descricao = ActivitiesTruncate(reader["Descricao"].ToString());
                    //---start variable
                /*    if (OldTeamId == -1)
                        OldTeamId = listActivities.TeamId;
                    //---
                    if (OldTeamId != listActivities.TeamId)
                    {
                        while (cntOne < 7)
                        {
                            ListActivities listActivitiesWhite = new ListActivities();
                            listActivitiesWhite.TeamId = OldTeamId;
                            listActivitiesWhite.Descricao = " ";
                            resultListActivities.Add(listActivitiesWhite);
                            cntOne++;
                        }
                        OldTeamId = listActivities.TeamId;
                        cntOne = 0;
                    }   
                 */
                    resultListActivities.Add(listActivities);
                    cntOne++;
                }
                /* while (cntOne < 7)
                {
                    ListActivities listActivitiesWhite = new ListActivities();
                    listActivitiesWhite.TeamId = OldTeamId;
                    listActivitiesWhite.Descricao = "  ";
                    resultListActivities.Add(listActivitiesWhite);
                    cntOne++;
                }
                 */
                if(resultListActivities.Count() == 0)
                {
                    ListActivities listActivitiesWhite = new ListActivities();
                    listActivitiesWhite.TeamId = 0;
                    listActivitiesWhite.Descricao = "  ";
                    resultListActivities.Add(listActivitiesWhite);
                    cntOne++;
                }
                con.Close();
                return resultListActivities;
            }
        }
        public List<ListTimeSheetsActivities> PrintTimeSheetsActivities(decimal team_id, string date)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
          //  decimal OldTeamId = -1;
            string activies  = "";
            int cntOne = 0;
            sql = "";
            sql += "  select TA_TEAM_X_CRAFT.TEAM_ID, TA_TEAM_X_CRAFT.CRAFT_ID as CRAFT_ID, TA_CRAFT.NAME as CRAFT_NAME,TA_TIMESHEET_TEMPLATE.ACTIVITY_ID ";
            sql += "  FROM ETA.TA_TEAM_X_CRAFT,ETA.TA_CRAFT,ETA.TA_TIMESHEET_TEMPLATE ";
            sql += "  WHERE TA_TEAM_X_CRAFT.CRAFT_ID = TA_CRAFT.EMP_NUMBER ";
            sql += "  AND  TA_TEAM_X_CRAFT.TEAM_ID in (1,2)";//= " + team_id;
            sql += "  order by TA_TEAM_X_CRAFT.TEAM_ID,TA_CRAFT.NAME ";

            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);
            List<ListTimeSheetsActivities> resultListTimeSheets = new List<ListTimeSheetsActivities>();
            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListTimeSheetsActivities listTimeSheets = new ListTimeSheetsActivities();
                    listTimeSheets.TeamId = Convert.ToDecimal(reader["TEAM_ID"]);
                    listTimeSheets.Barcode = Barcode(listTimeSheets.TeamId, date);
                    listTimeSheets.Matricula = reader["CRAFT_ID"].ToString().PadLeft(4,'0');
                    listTimeSheets.Nome = reader["CRAFT_NAME"].ToString().IndexOf(' ',0).ToString();
                    activies = reader["ACTIVITY_ID"].ToString();
                    listTimeSheets.Activities =activies;
                    listTimeSheets.Funcao = "";
                    //---start variable
                   /* if (OldTeamId == -1)
                        OldTeamId = listTimeSheets.TeamId;
                    //---
                    if (OldTeamId != listTimeSheets.TeamId)
                    {
                        while (cntOne < 41)
                        {
                            ListTimeSheetsActivities listTimeSheetsWhite = new ListTimeSheetsActivities();
                            listTimeSheetsWhite.TeamId = OldTeamId;
                            listTimeSheetsWhite.Barcode = Barcode(OldTeamId, date);
                            listTimeSheetsWhite.Activities = activies;
                            listTimeSheetsWhite.Matricula = "  ";
                            listTimeSheetsWhite.Nome = "  ";
                            listTimeSheetsWhite.Funcao = "  ";
                            resultListTimeSheets.Add(listTimeSheetsWhite);
                            cntOne++;
                        }
                        OldTeamId = listTimeSheets.TeamId;
                        cntOne = 0;
                    }
                    */
                    resultListTimeSheets.Add(listTimeSheets);
                    cntOne++;
                }
               /* while (cntOne < 41)
                {
                    ListTimeSheetsActivities listTimeSheetsWhite = new ListTimeSheetsActivities();
                    listTimeSheetsWhite.TeamId = OldTeamId;
                    listTimeSheetsWhite.Barcode = Barcode(OldTeamId, date);
                    listTimeSheetsWhite.Matricula = "  ";
                    listTimeSheetsWhite.Nome = "  ";
                    listTimeSheetsWhite.Funcao = "  ";
                    listTimeSheetsWhite.Activities = activies;
                    resultListTimeSheets.Add(listTimeSheetsWhite);
                    cntOne++;
                }
                */
                con.Close();
                return resultListTimeSheets;
            }
        }
        public string Barcode(decimal teamId, string date)
        {
            string barcode;
            barcode = Convert.ToDateTime(date).ToString("yyyyMMdd");
            barcode = barcode + Convert.ToString(teamId).PadLeft(5,'0');
            barcode = "*" + barcode + DigitoVerificador(barcode) + "*";
            return barcode;
        }
        public int DigitoVerificador(string barcode)
        {
            int soma = 0;
            int resto = 0;
            int dv = 0;
            int cnt = 2;
            for (int x = 0; x < barcode.Length; x++)
            {
                soma += Convert.ToInt16(barcode.Substring(barcode.Length-x-1, 1)) * cnt;
                cnt++;
                if (cnt == 10)
                    cnt = 2;
            }
            resto = soma % 11;
            dv = 11 - resto;
            return dv;
        }
        private string FirstLastName(string name)
        {
            string[] arrayName = name.Split(' ');
            string first = "";
            string last = "";
            first = arrayName[0];
            last = arrayName[arrayName.Count()-1];
            return first + " " + last;
        }
        private string ActivitiesTruncate(string activitiesDescription)
        {
            string result = activitiesDescription;
            if (activitiesDescription.IndexOf("-") != -1)
            {
                result = activitiesDescription.Substring(0, activitiesDescription.IndexOf("-"));
            }
            if (activitiesDescription.IndexOf("-", activitiesDescription.IndexOf("-")+1) != -1)
            {
                result += activitiesDescription.Substring(activitiesDescription.IndexOf("-", activitiesDescription.IndexOf("-")+1)+1, activitiesDescription.Length - activitiesDescription.IndexOf("-", activitiesDescription.IndexOf("-")+1)-1);
            }
            return result;
        }
        public void CalculationHoursProcedure(string data, string dia)
        {
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            try
            {
                OracleCommand comando = new OracleCommand()
                {
                    CommandText = "ETA.PRC_CALCULATION_HOURS",
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                };
                comando.Parameters.Add(":DATE_APROPR", OracleDbType.Date).Value = Dados.DataString(data);
                comando.Parameters.Add(":dia", OracleDbType.Varchar2).Value = dia.ToUpper();
                con.Open();
                comando.ExecuteNonQuery();
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
        public bool HollydayVerification(DateTime date)
        {
            ///Metodo para Listar todos no banco
            ///
            bool result = false;
            string sql;
            sql = "";
            sql += "  SELECT 1 Result FROM ETA.TA_HOLIDAY ";
            sql += "  where HOLIDAY_DATE = :HOLIDAY_DATE";

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);
            cmd.Parameters.Add(":HOLIDAY_DATE", OracleDbType.Date).Value = date;

            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Result"] != DBNull.Value)
                    {
                        result = true; 
                    }
                }
                return result;
            }
        }
        /*public string Turno(decimal team_id)
        {
            ///Metodo para Listar todos no banco
            ///
            string result = "D";
            string sql;
            sql = "";
            sql += "  SELECT TURN Result FROM TA_TEAM ";
            sql += "  where ID = " + team_id;

            DataTable table = new DataTable();
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);
            
            cmd.CommandType = CommandType.Text;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Result"] != null)
                    {
                        result = Convert.ToString(reader["Result"]);
                    }
                }
                return result;
            }
        }*/
        public string Turno(decimal team_id, DateTime date)
        {
            ///Metodo para Listar todos no banco
            ///
            string resultado = "";
            try
            {
                string sql;
                sql = "";
                sql += "  SELECT CASE   ";
                sql += "            WHEN (SELECT TURN FROM ETA.TA_TIMESHEET_HISTORY WHERE TEAM_ID = " + team_id + " AND EXECUTION_DATE = :EXECUTION_DATE AND ROWNUM = 1) IS NOT NULL THEN  ";
                sql += "                 (SELECT TURN FROM ETA.TA_TIMESHEET_HISTORY WHERE TEAM_ID = " + team_id + " AND EXECUTION_DATE = :EXECUTION_DATE AND ROWNUM = 1) ";
                sql += "            ELSE  ";
                sql += "              CASE ";
                sql += "                  WHEN (SELECT TURN FROM ETA.TA_TIMESHEET WHERE TEAM_ID = " + team_id + " AND EXECUTION_DATE = :EXECUTION_DATE AND ROWNUM = 1) IS NOT NULL THEN  ";
                sql += "                       (SELECT TURN FROM ETA.TA_TIMESHEET WHERE TEAM_ID = " + team_id + " AND EXECUTION_DATE = :EXECUTION_DATE AND ROWNUM = 1) ";
                sql += "                  ELSE  ";
                sql += "                     (SELECT TURN FROM ETA.TA_TEAM  WHERE ID = " + team_id + ") ";
                sql += "              END ";
                sql += "          END TURN ";
                sql += "  FROM DUAL ";


                OracleConnection con = new OracleConnection(Dados.StringDeConexao);
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.Parameters.Add(":EXECUTION_DATE", OracleDbType.Date).Value = date;
                cmd.Parameters.Add(":EXECUTION_DATE", OracleDbType.Date).Value = date;
                cmd.Parameters.Add(":EXECUTION_DATE", OracleDbType.Date).Value = date;
                cmd.Parameters.Add(":EXECUTION_DATE", OracleDbType.Date).Value = date;
                cmd.CommandType = CommandType.Text;                
                using (con)
                {
                    con.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader["TURN"] != DBNull.Value)
                            resultado = Convert.ToString(reader["TURN"]);
                    }

                }
            }
            catch
            {
                resultado = "D";
            }
            return resultado;
        }
        public decimal CalendarHours(DateTime date, string turno)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            //  decimal OldTeamId = -1;
            sql = "";
            sql += "  SELECT to_number(replace(HOURS,':')) AS HOURS ";
            sql += "  FROM ETA.TA_CALENDAR_HOURS ";
            sql += "  WHERE UPPER(TURN) = '" + turno + "' ";
            sql += "  AND DATE_HOURS = :DATE_HOURS";
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);
            cmd.Parameters.Add(":DATE_HOURS", OracleDbType.Date).Value = date;            
            cmd.CommandType = CommandType.Text;
            decimal resultado = 0;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    resultado = Convert.ToDecimal(reader["HOURS"]);
                }

            }
            return resultado;
        }
        public decimal HoursWork(decimal team_id, string turno, string dia)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            //  decimal OldTeamId = -1;
            sql = "";
            sql += "  SELECT to_number(replace(HOURS,':')) AS HOURS ";
            sql += "  FROM ETA.TA_HOURS_WORK ";
            sql += "  WHERE GROUP_ID = (SELECT GROUP_ID FROM ETA.TA_TEAM  WHERE ID = " + team_id + ") ";
            sql += "  AND UPPER(TURN) = '" + turno.ToUpper()  + "' ";
            sql += "  AND UPPER(DAY) = '" + dia.ToUpper()  + "' ";

            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            decimal resultado = 0;
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    resultado = Convert.ToDecimal(reader["HOURS"]);
                }
                else
                {
                    if (dia == "sex")
                    {
                        if (turno.ToUpper() == "N")
                            resultado = 700;
                        else
                            resultado = 800;
                    }
                    else
                    {
                        if (dia == "sáb" || dia == "dom")
                        {
                            resultado = 0;
                        }
                        else
                        {
                            if (turno.ToUpper() == "N")
                                resultado = 800;
                            else
                                resultado = 900;
                        }
                    }
                }

            }
            return resultado;
        }
        public bool verifyDataBase()
        {
            ///Metodo para Listar todos no banco
            ///
            bool resultado = true;
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            try
            {                
                con.Open();
            }
            catch
            {
                resultado = false;
            }
            con.Close();
            return resultado;
        }
        public DateTime ClosingDate()
        {
              ///Metodo para Listar todos no banco
            ///
            string sql;
            //  decimal OldTeamId = -1;
            sql = "";
            sql += "  SELECT MAX(DATE_CLOSE) AS DATA ";
            sql += "  FROM ETA.TA_CLOSING_DATE ";
            sql += "  WHERE STATUS = 0 ";

            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            DateTime resultado = Convert.ToDateTime("01/01/1999");
            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["DATA"] != DBNull.Value)
                    {
                        resultado = Convert.ToDateTime(reader["DATA"]).AddDays(1);
                    }
                }
            }
            return resultado;
        }
        public void ListTimeSheetsDeleteExists(decimal team_id, string date)
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";
            sql += "  DELETE ETA.TA_TIMESHEET ";
            sql += "  WHERE TEAM_ID = :TEAM_ID";
            sql += "  AND EXECUTION_DATE = :EXECUTION_DATE";

            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);
            cmd.Parameters.Add(":TEAM_ID", OracleDbType.Decimal).Value = team_id;
            cmd.Parameters.Add(":EXECUTION_DATE", OracleDbType.Date).Value = Dados.DataString(date);

            // cmd.CommandType = CommandType.Text;
            try
            {
                using (con)
                {
                    con.Open();
                    int count = cmd.ExecuteNonQuery();
                }
            }
            catch { }
            finally
            {
                con.Close();
            }
        }
    } 
}
