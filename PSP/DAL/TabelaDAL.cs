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
        //NUMBER OF LINES
        int numberOfLines = 25;
        string quebraLinha = Environment.NewLine;
        string sql;
        const string aspas = "\"";

        public DataTable ListArea()
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            sql = "";
            sql += "  SELECT ID AS ID, AREA_DESCRIPTION as DESCRICAO FROM ETA.TA_AREAS ORDER BY AREA_DESCRIPTION";

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
        public DataTable ListAreaGroupComissionamento(decimal groupId)
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
        public DataTable ListAreaGroup(decimal groupId, string data)
        {
            TabelaDAL obj = new TabelaDAL();

            string sql;
            sql = "";
            sql += "  SELECT DISTINCT EQ.AREA_ID AS ID, (SELECT A.AREA_DESCRIPTION FROM  ETA.TA_AREAS A WHERE ID = EQ.AREA_ID) as DESCRICAO " + quebraLinha;
            sql += "  FROM ETA.TA_TEAM EQ " + quebraLinha;
            sql += "  WHERE EQ.AREA_ID IS NOT NULL AND EQ.GROUP_ID = " + groupId + quebraLinha;
            sql += "  AND " + quebraLinha;
            sql += "  ( " + quebraLinha;
            sql += "     SELECT COUNT(*) " + quebraLinha;
            sql += "     FROM ETA.TA_TEAM TQ " + quebraLinha;
            sql += "     WHERE TQ.AREA_ID = EQ.AREA_ID  AND TQ.GROUP_ID = " + groupId + quebraLinha;
            sql += "     AND TQ.STATUS <> 0   AND (EXISTS (SELECT ID FROM ETA.TA_TEAM_X_CRAFT WHERE TA_TEAM_X_CRAFT.TEAM_ID = TQ.ID AND INIT_DATE <= to_date('" + data + "','DD/MM/YYYY') )   " + quebraLinha;
            sql += "     OR EXISTS (SELECT ID FROM ETA.TA_TEAM_X_CRAFT_HISTORY WHERE TA_TEAM_X_CRAFT_HISTORY.TEAM_ID = TQ.ID AND FINAL_DATE >= to_date('" + data + "','DD/MM/YYYY')))   " + quebraLinha;
            sql += "  ) > 0 " + quebraLinha;
            sql += "  ORDER BY DESCRICAO " + quebraLinha;

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
        public DataTable ListaArea(decimal groupId, decimal responsavelId)
        {
            string varResponsavel1 = (responsavelId != 0) ? " AND EQ.RP_ID = " + responsavelId : "";
            string varResponsavel2 = (responsavelId != 0) ? " AND TQ.RP_ID = " + responsavelId : "";

            string sql;
            sql = @"SELECT DISTINCT 
                      EQ.AREA_ID AS ID, 
                      (SELECT A.AREA_DESCRIPTION FROM ETA.TA_AREAS A WHERE ID = EQ.AREA_ID) as DESCRICAO 
                    FROM 
                      ETA.TA_TEAM EQ 
                    WHERE 
                          EQ.AREA_ID IS NOT NULL 
                      AND EQ.GROUP_ID = " + groupId + varResponsavel1 + @"
                      AND (SELECT 
                              COUNT(*) 
                            FROM 
                              ETA.TA_TEAM TQ 
                            WHERE 
                                  TQ.AREA_ID = EQ.AREA_ID 
                              AND TQ.GROUP_ID = " + groupId + varResponsavel2 + @"
                              AND TQ.STATUS <> 0 
                              AND (EXISTS (SELECT ID FROM ETA.TA_TEAM_X_CRAFT WHERE TA_TEAM_X_CRAFT.TEAM_ID = TQ.ID AND INIT_DATE <= to_date('" + System.DateTime.Now.ToString("dd/MM/yyyy") + @" 23:59:59','DD/MM/YYYY HH24:mi:ss') ) 
                                OR EXISTS (SELECT ID FROM ETA.TA_TEAM_X_CRAFT_HISTORY WHERE TA_TEAM_X_CRAFT_HISTORY.TEAM_ID = TQ.ID AND FINAL_DATE >= to_date('" + System.DateTime.Now.ToString("dd/MM/yyyy") + @" 23:59:59','DD/MM/YYYY HH24:mi:ss'))) ) > 0 
                    ORDER BY 
                      DESCRICAO";

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
        public DataTable ListaResponsavel(decimal groupId)
        {
            string sql;
            sql = @"SELECT DISTINCT 
                      EQ.RP_ID AS ID,
                      (SELECT A.RP_DESCRIPTION FROM ETA.TA_RP A WHERE RP_ID = EQ.RP_ID) as DESCRICAO 
                    FROM 
                      ETA.TA_TEAM EQ 
                    WHERE 
                          EQ.RP_ID IS NOT NULL 
                      AND EQ.GROUP_ID = " + groupId + @"
                      AND (SELECT 
                              COUNT(*) 
                            FROM 
                              ETA.TA_TEAM TQ 
                            WHERE 
                                  TQ.RP_ID = EQ.RP_ID 
                              AND TQ.GROUP_ID = " + groupId + @" 
                              AND TQ.STATUS <> 0 
                              AND (EXISTS (SELECT ID FROM ETA.TA_TEAM_X_CRAFT WHERE TA_TEAM_X_CRAFT.TEAM_ID = TQ.ID AND INIT_DATE <= to_date('" + System.DateTime.Now.ToString("dd/MM/yyyy") + @" 23:59:59','DD/MM/YYYY HH24:mi:ss') ) 
                                OR EXISTS (SELECT ID FROM ETA.TA_TEAM_X_CRAFT_HISTORY WHERE TA_TEAM_X_CRAFT_HISTORY.TEAM_ID = TQ.ID AND FINAL_DATE >= to_date('" + System.DateTime.Now.ToString("dd/MM/yyyy") + @" 23:59:59','DD/MM/YYYY HH24:mi:ss'))) ) > 0 
                    ORDER BY 
                      DESCRICAO";

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
            string sql = @"SELECT 
                                craf.ID, craf.DESCRICAO, MAX(craf.ST) AS ST, 
                                (SELECT 'X' AS FT FROM ETA.TA_FALTA WHERE FALTA_DATA = TO_DATE('" + date + @"', 'DD/MM/YYYY') AND FALTA_EMP_NUMBER = craf.ID) AS FT,
                                MAX(NVL((SELECT loca.LOCAL_DESCRIPTION FROM ETA.TA_TIMESHEET tish, ETA.TA_LOCAL loca WHERE tish.LOCAL_ID = loca.LOCAL_ID AND tish.CRAFT_ID = craf.ID AND tish.EXECUTION_DATE = TO_DATE('" + date + @"', 'DD/MM/YYYY') AND ROWNUM = 1), loca.LOCAL_DESCRIPTION)) AS LOCAL,
                                MAX(NVL((SELECT loca.STATUS FROM ETA.TA_TIMESHEET tish, ETA.TA_LOCAL loca WHERE tish.LOCAL_ID = loca.LOCAL_ID AND tish.CRAFT_ID = craf.ID AND tish.EXECUTION_DATE = TO_DATE('" + date + @"', 'DD/MM/YYYY') AND ROWNUM = 1), loca.STATUS)) AS STATUS_LOCAL
                            FROM 
                                (
                                --Funcionários Não demitidos cujo dia do movimento esteja dentro da equipe ativa
                                SELECT 
                                    TA_CRAFT.STATUS_FDM AS ST, TA_TEAM_X_CRAFT.CRAFT_ID as id, TA_CRAFT.NAME as Descricao, TEAM_ID
                                FROM 
                                    ETA.TA_TEAM_X_CRAFT,ETA.TA_CRAFT  
                                WHERE   
                                    TA_TEAM_X_CRAFT.CRAFT_ID = TA_CRAFT.EMP_NUMBER AND   
                                    TA_CRAFT.STATUS <> 0 AND 
                                    TA_TEAM_X_CRAFT.TEAM_ID = " + team_id + @" AND 
                                    TO_DATE('" + date + @"','DD/MM/YYYY') >= TA_TEAM_X_CRAFT.INIT_DATE AND 
                                    (TA_CRAFT.STATUS_FDM != 'D' or TA_CRAFT.STATUS_FDM IS NULL) 
        
                                UNION 
    
                                --Funcionários DEMITIDOS cujo dia do movimento anterior ou igual à data de demissão
                                SELECT 
                                    TA_CRAFT.STATUS_FDM AS ST, TA_TEAM_X_CRAFT.CRAFT_ID as id, TA_CRAFT.NAME as Descricao, TEAM_ID 
                                FROM 
                                    ETA.TA_TEAM_X_CRAFT,ETA.TA_CRAFT  
                                WHERE   
                                    TA_TEAM_X_CRAFT.CRAFT_ID = TA_CRAFT.EMP_NUMBER AND   
                                    TA_CRAFT.STATUS <> 0 AND 
                                    TA_TEAM_X_CRAFT.TEAM_ID = " + team_id + @" AND 
                                    TO_DATE('" + date + @"','DD/MM/YYYY') <= TA_CRAFT.DEMISSAO 
        
                                UNION 
    
                                --Funcionários que possuem movimento na equipe na data do movimento
                                SELECT 
                                    NULL AS ST, CRAFT_ID as id, (SELECT TA_CRAFT.NAME FROM ETA.TA_CRAFT WHERE TA_CRAFT.EMP_NUMBER = TA_TIMESHEET.CRAFT_ID) as Descricao, TEAM_ID 
                                FROM 
                                    ETA.TA_TIMESHEET, ETA.TA_CRAFT  
                                WHERE 
                                    TEAM_ID = " + team_id + @" AND 
                                    TA_CRAFT.EMP_NUMBER = TA_TIMESHEET.CRAFT_ID AND 
                                    (TA_CRAFT.STATUS_FDM != 'D' or TA_CRAFT.STATUS_FDM IS NULL) AND 
                                    EXECUTION_DATE = TO_DATE('" + date + @"','DD/MM/YYYY')

                                UNION 
                                
                                --Funcionários NÃO demitidos cujo dia do movimento esteja FORA da equipe ativa e que a data do movimento esteja dentro do intervalo de Data Inicial e Data Final da equipe //Q qualquer que seja o status do Funcionário (Mesmo que HOJE o funcionário já esteja demitido)
                                SELECT 
                                    TA_CRAFT.STATUS_FDM AS ST, TA_TEAM_X_CRAFT_HISTORY.CRAFT_ID as id, TA_CRAFT.NAME as Descricao, TEAM_ID 
                                FROM 
                                    ETA.TA_TEAM_X_CRAFT_HISTORY,ETA.TA_CRAFT  
                                WHERE   
                                    TA_TEAM_X_CRAFT_HISTORY.CRAFT_ID = TA_CRAFT.EMP_NUMBER AND   
                                    TA_CRAFT.STATUS <> 0 AND 
                                    TA_TEAM_X_CRAFT_HISTORY.TEAM_ID = " + team_id + @" AND 
                                    TO_DATE('" + date + @"','DD/MM/YYYY') >= TA_TEAM_X_CRAFT_HISTORY.INIT_DATE AND TO_DATE('" + date + @"','DD/MM/YYYY') <= TA_TEAM_X_CRAFT_HISTORY.FINAL_DATE
                                ) craf,
                                ETA.TA_TEAM team,
                                ETA.TA_LOCAL loca
                            WHERE
                                    craf.TEAM_ID = team.ID (+)
                                AND team.LOCAL_ID = loca.LOCAL_ID (+)
                            GROUP BY 
                                craf.ID, craf.DESCRICAO
                            ORDER BY 
                                craf.DESCRICAO";

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
        public DataTable ListCraftLeaderSupervisor(decimal team_id)
        {
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
        public DataTable ListaLocal()
        {
            string sql = "SELECT LOCAL_ID, LOCAL_DESCRIPTION FROM ETA.TA_LOCAL WHERE STATUS = 1 ORDER BY LOCAL_DESCRIPTION";

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
        public DataTable ListTeamOtherFKs(decimal team_id)
        {
            string sql = @"SELECT 
                                team.LEADER_ID, team.SUPERVISOR_ID, TEAM_CODE, RP_ID, GERE_ID, team.LOCAL_ID, TASK_ID, DIEF_ID, SBCN_SIGLA, TEAM_TIPO_MO, 
                                (SELECT LOCAL_DESCRIPTION FROM ETA.TA_LOCAL loca WHERE loca.LOCAL_ID = team.LOCAL_ID) AS NOME_LOCAL  
                            FROM 
                                ETA.TA_TEAM team
                            WHERE 
                                    ID = " + team_id + @" 
                                AND STATUS <> 0";

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
        public DataTable ListActivitiesUnion(decimal team_id, string date)
        {
            string sql;
            sql = "";
            sql += " SELECT DISTINCT" + quebraLinha;
            sql += "     time.ACTIVITY_ID," + quebraLinha;
            sql += "     CASE WHEN ativ.TITLE LIKE 'P%' THEN" + quebraLinha;
            sql += "       ativ.TITLE" + quebraLinha;
            sql += "     ELSE" + quebraLinha;
            sql += "       ativ.TA_UA " + quebraLinha;
            sql += "     END as Descricao" + quebraLinha;
            sql += " FROM" + quebraLinha;
            sql += "     ETA.TA_ACTIVITIES ativ, ETA.TA_TIMESHEET time" + quebraLinha;
            sql += " WHERE" + quebraLinha;
            sql += "         ativ.ID = time.ACTIVITY_ID" + quebraLinha;
            sql += "     AND time.TEAM_ID = :TEAM_ID" + quebraLinha;
            sql += "     AND time.EXECUTION_DATE = TO_DATE('" + date + "', 'DD/MM/YYYY')" + quebraLinha;
            sql += " ORDER BY" + quebraLinha;
            sql += "     time.ACTIVITY_ID";

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
            string sql;
            sql = "";
            sql += "  SELECT TA_ACTIVITIES.ID as id, ";
            sql += "  CASE WHEN TA_ACTIVITIES.TITLE LIKE 'P%' THEN ";
            sql += "      TA_ACTIVITIES.TITLE  ";
            sql += "  ELSE  ";
            sql += "      TA_ACTIVITIES.TA_UA  ";
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

        public DataTable ListEquipesByTeamId(decimal teamId)
        {
            string sql;
            sql = @"SELECT  T.ID EQUIPE_ID, T.TEAM_CODE, T.NAME AS EQUIPE, T.RP_ID, R.RP_DESCRIPTION, T.LEADER_ID, C.NAME AS LIDER, T.GROUP_ID, G.GROUP_TEAM_DESCRIPTION, T.SUPERVISOR_ID, 
                    (SELECT S.NAME FROM ETA.TA_CRAFT S WHERE S.EMP_NUMBER = SUPERVISOR_ID) AS SUPERVISOR, 
                    T.LOCAL_ID, L.LOCAL_DESCRIPTION
            FROM    ETA.TA_TEAM T, ETA.TA_GROUP_TEAM G, ETA.TA_CRAFT C, ETA.TA_RP R, ETA.TA_LOCAL L
            WHERE   G.ID(+) = T.GROUP_ID AND 
                    C.EMP_NUMBER = T.LEADER_ID AND
                    R.RP_ID = T.RP_ID AND
                    L.LOCAL_ID(+) = T.LOCAL_ID AND
                    T.ID = " + teamId + @"
            ORDER BY EQUIPE";

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

        public DataTable ListEquipesByRpId(decimal rpId)
        {
            string sql;
            sql = @"SELECT    T.ID EQUIPE_ID, T.TEAM_CODE, T.NAME AS EQUIPE, T.RP_ID, R.RP_DESCRIPTION, T.LEADER_ID, C.NAME AS LIDER, T.GROUP_ID, G.GROUP_TEAM_DESCRIPTION, T.SUPERVISOR_ID, 
                              (SELECT S.NAME FROM ETA.TA_CRAFT S WHERE S.EMP_NUMBER = SUPERVISOR_ID) AS SUPERVISOR, 
                              T.LOCAL_ID, L.LOCAL_DESCRIPTION
                    FROM      ETA.TA_TEAM T, ETA.TA_GROUP_TEAM G, ETA.TA_CRAFT C, ETA.TA_RP R, ETA.TA_LOCAL L
                    WHERE     G.ID(+) = T.GROUP_ID AND 
                              C.EMP_NUMBER = T.LEADER_ID AND
                              R.RP_ID = T.RP_ID AND
                              L.LOCAL_ID(+) = T.LOCAL_ID AND
                              T.RP_ID = " + rpId + @"
                    ORDER BY  EQUIPE";

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
        public DataTable ListRP()
        {
            ///Metodo para Listar todos no banco
            ///
            string sql;
            //sql = "SELECT RP_ID, RP_DESCRIPTION FROM ETA.TA_RP ORDER BY 2";
            sql = @"
                    SELECT      DISTINCT R.RP_ID, R.RP_DESCRIPTION   --, (C.NAME || ' (' ||C.EMP_NUMBER || ')') AS LIDER, T.*
                    FROM        ETA.TA_RP R, ETA.TA_TEAM T, ETA.TA_TEAM_X_CRAFT TC, ETA.TA_CRAFT C
                    WHERE       R.RP_ID = T.RP_ID
                    AND         TC.TEAM_ID = T.ID
                    AND         C.EMP_NUMBER = T.LEADER_ID
                    ORDER BY 2
                   ";

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
        public DataTable GetTeamByRpId(decimal rpId)
        {
            string sql;
            sql = @"SELECT  T.ID EQUIPE_ID, T.TEAM_CODE, T.NAME AS EQUIPE, T.RP_ID, R.RP_DESCRIPTION, C.NAME||' ('||T.LEADER_ID||')' AS LIDER_IDENTIFICATION, T.LEADER_ID, 
                            C.NAME AS LIDER, T.GROUP_ID, G.GROUP_TEAM_DESCRIPTION, T.SUPERVISOR_ID,  
                            (SELECT S.NAME FROM ETA.TA_CRAFT S WHERE S.EMP_NUMBER = SUPERVISOR_ID) AS SUPERVISOR, 
                            T.LOCAL_ID, L.LOCAL_DESCRIPTION
                    FROM    ETA.TA_TEAM T, ETA.TA_GROUP_TEAM G, ETA.TA_CRAFT C, ETA.TA_RP R, ETA.TA_LOCAL L, ETA.TA_TEAM_X_CRAFT TC
                    WHERE   G.ID(+) = T.GROUP_ID AND T.GROUP_ID IN (21,22,23,24,25,26,27,41) AND 
                            C.EMP_NUMBER = T.LEADER_ID AND
                            R.RP_ID = T.RP_ID AND
                            L.LOCAL_ID(+) = T.LOCAL_ID AND
                            TC.TEAM_ID = T.ID AND TC.CRAFT_ID = C.EMP_NUMBER AND
                            T.RP_ID = " + rpId.ToString() + " ORDER BY LIDER_IDENTIFICATION";

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
        public DataTable GetTeamByTeamId(decimal teamId)
        {
            string sql;
            sql = @"SELECT  T.ID EQUIPE_ID, T.TEAM_CODE, T.NAME AS EQUIPE, T.RP_ID, R.RP_DESCRIPTION, T.LEADER_ID, C.NAME AS LIDER, T.GROUP_ID, G.GROUP_TEAM_DESCRIPTION, T.SUPERVISOR_ID, 
                            (SELECT S.NAME FROM ETA.TA_CRAFT S WHERE S.EMP_NUMBER = SUPERVISOR_ID) AS SUPERVISOR 
                    FROM    ETA.TA_TEAM T, ETA.TA_GROUP_TEAM G, ETA.TA_CRAFT C, ETA.TA_RP R
                    WHERE   G.ID(+) = T.GROUP_ID AND 
                            C.EMP_NUMBER = T.LEADER_ID AND
                            R.RP_ID = T.RP_ID AND
                            T.ID = " + teamId.ToString();

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
        public DataTable ListTeam()
        {
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
            sql += "  ORDER BY GROUP_TEAM_DESCRIPTION ";

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

        public DataTable ListTeamAreaComissionamento(decimal idArea, string date, decimal idGrup, string turno)
        {
            string sql;
            sql = "";
            sql += "SELECT ID, DESCRICAO, TURNO, STATUS_FDM ";
            sql += "FROM ";
            sql += "( ";
            sql += "		SELECT ";
            sql += "  		ID as id, ";
            sql += "  		(SELECT NAME || ' (' || LEADER_ID || '-' || TURN || ')' FROM ETA.TA_CRAFT WHERE EMP_NUMBER = LEADER_ID) as Descricao, ";
            sql += "  		TURN as Turno, ";
            sql += "  		(SELECT STATUS_FDM FROM ETA.TA_CRAFT WHERE EMP_NUMBER = LEADER_ID) as STATUS_FDM ";
            sql += "  	FROM ETA.TA_TEAM ";
            sql += "  	WHERE AREA_ID = " + idArea;
            sql += "  	AND GROUP_ID = " + idGrup;
            sql += "  	AND STATUS <> 0 ";
            turno = turno.ToUpper();
            if (turno != null && turno != "")
            {
                sql += " 	AND TURN = '" + turno + "'";
            }
           
            sql += ") ";
            sql += "WHERE ";
            sql += "	STATUS_FDM <> 'D' OR STATUS_FDM IS NULL ";

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
        public DataTable ListTeamArea(decimal idArea, string date, decimal idGrup)
        {
            string sql = @"SELECT 
                                ID as id, 
                                (SELECT NAME || ' (' || LEADER_ID || '-' || TURN || ')' FROM ETA.TA_CRAFT WHERE EMP_NUMBER = LEADER_ID) as Descricao, 
                                (SELECT STATUS_FDM FROM ETA.TA_CRAFT WHERE EMP_NUMBER = LEADER_ID) as STATUS_FDM 
                            FROM 
                                ETA.TA_TEAM 
                            WHERE 
                                    AREA_ID = " + idArea + @"
                                AND GROUP_ID = " + idGrup + @"
                                AND STATUS <> 0 
                                AND TEAM_TIPO_MO = 'MOD'
                                AND (EXISTS (SELECT ID FROM ETA.TA_TEAM_X_CRAFT WHERE TA_TEAM_X_CRAFT.TEAM_ID = TA_TEAM.ID AND INIT_DATE <= to_date('" + date + @"','DD/MM/YY') ) 
                                  OR EXISTS (SELECT ID FROM ETA.TA_TEAM_X_CRAFT_HISTORY WHERE TA_TEAM_X_CRAFT_HISTORY.TEAM_ID = TA_TEAM.ID AND FINAL_DATE >= to_date('" + date + @"','DD/MM/YY')) )
                            ORDER BY
                                (SELECT NAME || ' (' || LEADER_ID || '-' || TURN || ')' FROM ETA.TA_CRAFT WHERE EMP_NUMBER = LEADER_ID)";

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
        public DataTable ListaEquipe(decimal idArea, string date, decimal idGrup, string turno, decimal idResponsavel)
        {
            string sql;
            sql = "";
            sql += "SELECT " + quebraLinha;
            sql += "            ID, DESCRICAO, TURNO, STATUS_FDM " + quebraLinha;
            sql += "    FROM " + quebraLinha;
            sql += "    ( " + quebraLinha;
            sql += "    		SELECT " + quebraLinha;
            sql += "      		ID as id, " + quebraLinha;
            sql += "      		(SELECT NAME || ' (' || TEAM_CODE || '-' || TURN || ')' FROM ETA.TA_CRAFT WHERE EMP_NUMBER = LEADER_ID) as Descricao, " + quebraLinha;
            sql += "      		TURN as Turno, " + quebraLinha;
            sql += "      		(SELECT STATUS_FDM FROM ETA.TA_CRAFT WHERE EMP_NUMBER = LEADER_ID) as STATUS_FDM " + quebraLinha;
            sql += "      	FROM ETA.TA_TEAM " + quebraLinha;
            sql += "      	WHERE AREA_ID = " + idArea + quebraLinha;
            sql += "      	AND GROUP_ID = " + idGrup + quebraLinha;
            sql += ((idResponsavel != 0) ? "      	AND RP_ID = " + idResponsavel : "") + quebraLinha;
            sql += "      	AND STATUS <> 0 " + quebraLinha;
            turno = turno.ToUpper();
            if (turno != null && turno != "")
            {
                sql += "     	AND TURN = '" + turno + "'" + quebraLinha;
            }
            sql += "      	AND (EXISTS (SELECT ID FROM ETA.TA_TEAM_X_CRAFT WHERE TA_TEAM_X_CRAFT.TEAM_ID = TA_TEAM.ID AND INIT_DATE <= to_date('" + date + " 23:59:59'" + ",'DD/MM/YYYY HH24:mi:ss') ) " + quebraLinha;
            sql += "      	OR EXISTS (SELECT ID FROM ETA.TA_TEAM_X_CRAFT_HISTORY WHERE TA_TEAM_X_CRAFT_HISTORY.TEAM_ID = TA_TEAM.ID AND FINAL_DATE >= to_date('" + date + " 23:59:59'" + ",'DD/MM/YYYY HH24:mi:ss')) )" + quebraLinha;

            sql += "    ) " + quebraLinha;
            sql += "    WHERE " + quebraLinha;
            sql += "    	STATUS_FDM <> 'D' OR STATUS_FDM IS NULL " + quebraLinha;

            sql += "    UNION " + quebraLinha;

            sql += "    SELECT ID, DESCRICAO, TURNO, STATUS_FDM " + quebraLinha;
            sql += "    FROM " + quebraLinha;
            sql += "        ( " + quebraLinha;
            sql += "		SELECT " + quebraLinha;
            sql += "  		ID as id, " + quebraLinha;
            sql += "  		(SELECT NAME || ' (' || TEAM_CODE || '-' || TURN || ')' FROM ETA.TA_CRAFT WHERE EMP_NUMBER = LEADER_ID) as Descricao, " + quebraLinha;
            sql += "  		TURN as Turno, " + quebraLinha;
            sql += "  		(SELECT STATUS_FDM FROM ETA.TA_CRAFT WHERE EMP_NUMBER = LEADER_ID) as STATUS_FDM " + quebraLinha;
            sql += "  	FROM ETA.TA_TEAM " + quebraLinha;
            sql += "  	WHERE AREA_ID = " + idArea + quebraLinha;
            sql += "  	AND GROUP_ID = " + idGrup + quebraLinha;
            sql += ((idResponsavel != 0) ? "      	AND RP_ID = " + idResponsavel : "") + quebraLinha;
            sql += "  	AND STATUS <> 0 " + quebraLinha;
            turno = turno.ToUpper();
            if (turno != null && turno != "")
            {
                sql += " 	AND TURN = '" + turno + "'" + quebraLinha;
            }
            sql += "  	AND (EXISTS (SELECT ID FROM ETA.TA_TEAM_X_CRAFT WHERE TA_TEAM_X_CRAFT.TEAM_ID = TA_TEAM.ID AND INIT_DATE <= to_date('" + date + " 23:59:59'" + ",'DD/MM/YYYY HH24:mi:ss') ) " + quebraLinha;
            sql += "  	OR EXISTS (SELECT ID FROM ETA.TA_TEAM_X_CRAFT_HISTORY WHERE TA_TEAM_X_CRAFT_HISTORY.TEAM_ID = TA_TEAM.ID AND FINAL_DATE >= to_date('" + date + " 23:59:59'" + ",'DD/MM/YYYY HH24:mi:ss')) )" + quebraLinha;

            sql += "    ) " + quebraLinha;
            sql += "WHERE " + quebraLinha;
            sql += "	STATUS_FDM = 'D' " + quebraLinha;
            sql += "    AND ID IN (SELECT DISTINCT TEAM_ID FROM ETA.TA_TEAM_X_CRAFT, ETA.TA_CRAFT WHERE CRAFT_ID = EMP_NUMBER AND (STATUS_FDM != 'D' OR STATUS_FDM IS NULL))" + quebraLinha;

            sql += "ORDER BY DESCRICAO" + quebraLinha;

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

        public DataTable ListTeam(decimal idTeam)
        {
            string sql = @"SELECT 
                                T.ID as id, T.NAME as Descricao, T.SBCN_SIGLA,
                                (SELECT A.AREA_DESCRIPTION FROM ETA.TA_AREAS A WHERE A.ID = T.AREA_ID) as Turno, 
                                (SELECT EMP_NUMBER || '-' || TURN FROM ETA.TA_CRAFT WHERE EMP_NUMBER = T.LEADER_ID) as MATRICULA, 
                                (SELECT B.TASK_DESCRIPTION FROM ETA.TA_TASK B WHERE B.TASK_ID = T.TASK_ID) as TAREFA, 
                                (SELECT R.RP_DESCRIPTION FROM ETA.TA_RP R WHERE R.RP_ID = T.RP_ID) as RP, 
                                T.TEAM_CODE, T.GROUP_ID, T.DIEF_ID, G.GROUP_TEAM_DESCRIPTION , L.LOCAL_DESCRIPTION, A.AREA_DESCRIPTION 
                            FROM   
                                ETA.TA_TEAM T, ETA.TA_GROUP_TEAM G, ETA.TA_LOCAL L, ETA.TA_AREAS A  
                            WHERE  
                                    T.ID = " + idTeam + @" 
                                AND G.ID = T.GROUP_ID 
                                AND L.LOCAL_ID(+) = T.LOCAL_ID 
                                AND A.ID(+) = T.AREA_ID
                            ORDER BY
                                T.STATUS DESC";

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
        public DataTable qtdeEquipes(string De, string Ate)
        {
            string sql;
            sql = @"SELECT DISTINCT
                        tecr.TEAM_ID, (SELECT craf1.NAME FROM ETA.TA_CRAFT craf1 WHERE craf1.EMP_NUMBER = team.LEADER_ID) as LIDER_NOME, team.GROUP_ID
                    FROM 
                        ETA.TA_EXAMES_PERIODICOS expe, ETA.TA_TEAM_X_CRAFT tecr, ETA.TA_CRAFT craf, ETA.TA_TEAM team
                    WHERE 
                            expe.EXPE_CRAFT_ID = tecr.CRAFT_ID
                        AND tecr.CRAFT_ID = craf.EMP_NUMBER
                        AND tecr.TEAM_ID = team.ID
                        AND team.GROUP_ID > 20
                        AND tecr.INIT_DATE IS NOT NULL
                        AND team.TEAM_TIPO_MO = 'MOD'
                        AND TO_DATE(expe.EXPE_DATA, 'DD/MM/YYYY') BETWEEN TO_DATE('" + De + "', 'DD/MM/YYYY') AND TO_DATE('" + Ate + @"', 'DD/MM/YYYY')
                    ORDER BY
                        team.GROUP_ID";

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

        public DataTable ListaAtividades(string plataforma, int idDisciplina)
        {
            sql = @"SELECT 
                        acti.TA_UA || ' - ' || acti.COMMENTS AS ATIVIDADES,
                        acti.TA_UA,
                        acti.SBCN_SIGLA,
                        acdi.ACDI_DISC_ID,
                        acdi.ACDI_NIVEL_PRINCIPAL
                    FROM 
                        ETA.TA_ACTIVITIES_DISCIPLINA acdi,
                        ETA.TA_ACTIVITIES acti
                    WHERE
                            acdi.ACDI_ACTI_ID = acti.ID
                        AND acdi.ACDI_SBCN_SIGLA = '" + plataforma + @"'
                        AND acdi.ACDI_DISC_ID = " + idDisciplina + @"
                    ORDER BY
                        ACDI_NIVEL_PRINCIPAL";

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
        public decimal RetornaIdLocal(string strNovoLocal)
        {
            decimal result = 0;
            string sql = "SELECT LOCAL_ID FROM ETA.TA_LOCAL WHERE LOCAL_DESCRIPTION = '" + strNovoLocal + "'";

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
                    if (reader["LOCAL_ID"] != DBNull.Value)
                    {
                        result = Convert.ToDecimal(reader["LOCAL_ID"]);
                    }
                }
                return result;
            }
        }
        public DataTable ListTimeSheets(decimal team_id, string date)
        {
            string sql;
            sql = @"SELECT 
                          time.ACTIVITY_ID
                        , time.CRAFT_ID
                        , time.WORKED_HOURS
                        , time.OVERTIME_HOURS
                        , time.SPECIAL_SITUATION  
                        , craf.DEMISSAO
                    FROM 
                        ETA.TA_TIMESHEET time, ETA.TA_CRAFT craf
                    WHERE 
                            time.TEAM_ID = :TEAM_ID 
                        AND time.CRAFT_ID = craf.EMP_NUMBER
                        AND time.EXECUTION_DATE = TO_DATE('" + date + @"', 'DD/MM/YYYY')  
                        AND (craf.DEMISSAO >= TO_DATE('" + date + @"', 'DD/MM/YY') OR craf.DEMISSAO IS NULL)
                    ORDER BY 
                        time.ID";

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
                    sql += "  AND EXECUTION_DATE = TO_DATE(:EXECUTION_DATE,'DD/MM/YY')";
                    //sql += "  AND EXECUTION_DATE = TO_DATE('" + listTimeSheetsAll[0].ExecutionDate + "','DD/MM/YY')";
                    //sql += "  AND EXECUTION_DATE = :EXECUTION_DATE";

                    comando.CommandText = sql;
                    comando.Parameters.Add(":TEAM_ID", OracleDbType.Decimal).Value = listTimeSheetsAll[0].TeamId;
                    comando.Parameters.Add(":EXECUTION_DATE", OracleDbType.Varchar2).Value = listTimeSheetsAll[0].ExecutionDate.ToString();
                    //comando.Parameters.Add(":EXECUTION_DATE", OracleDbType.Date).Value = Dados.DataString(listTimeSheetsAll[0].ExecutionDate);

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
                        sql += "     SUPERVISOR_ID, ";
                        sql += "     TEAM_CODE, ";
                        sql += "     RP_ID, ";
                        sql += "     GERE_ID, ";
                        sql += "     LOCAL_ID, ";
                        sql += "     TASK_ID, ";
                        sql += "     DIEF_ID, ";
                        sql += "     SBCN_SIGLA, ";
                        sql += "     TEAM_TIPO_MO ";


                        sql += "   ) ";
                        sql += "   VALUES ";
                        sql += "   ( ";
                        sql += "     :ACTIVITY_ID, ";
                        sql += "     :CRAFT_ID, ";
                        sql += "     :TEAM_ID, ";
                        sql += "     :WORKED_HOURS, ";
                        sql += "     :OVERTIME_HOURS, ";
                        sql += "     TO_DATE(:EXECUTION_DATE,'DD/MM/YY'), ";
                        sql += "     :CREATED_BY, ";
                        sql += "     :SPECIAL_SITUATION, ";
                        sql += "     :TURN, ";
                        sql += "     :STATUS, ";
                        sql += "     :AREA_ID, ";
                        sql += "     :GROUP_TEAM_ID, ";
                        sql += "     :LEADER_ID, ";
                        sql += "     :SUPERVISOR_ID, ";
                        sql += "     :TEAM_CODE, ";
                        sql += "     :RP_ID, ";
                        sql += "     :GERE_ID, ";
                        sql += "     :LOCAL_ID, ";
                        sql += "     :TASK_ID, ";
                        sql += "     :DIEF_ID, ";
                        sql += "     :SBCN_SIGLA, ";
                        sql += "     :TEAM_TIPO_MO ";
                        sql += "   ) ";

                        comando.CommandText = sql;
                        comando.Parameters.Clear();

                        comando.Parameters.Add(":ACTIVITY_ID", OracleDbType.Decimal).Value = timeSheetsAll.ActivetyId;
                        comando.Parameters.Add(":CRAFT_ID", OracleDbType.Decimal).Value = timeSheetsAll.CraftId;
                        comando.Parameters.Add(":TEAM_ID", OracleDbType.Decimal).Value = timeSheetsAll.TeamId;
                        comando.Parameters.Add(":WORKED_HOURS", OracleDbType.Decimal).Value = timeSheetsAll.WorkedHours;
                        comando.Parameters.Add(":OVERTIME_HOURS", OracleDbType.Decimal).Value = timeSheetsAll.WorkedOverTime;
                        comando.Parameters.Add(":EXECUTION_DATE", OracleDbType.Varchar2).Value = timeSheetsAll.ExecutionDate.ToString();
                        comando.Parameters.Add(":CREATED_BY", OracleDbType.Varchar2).Value = userLogin;
                        comando.Parameters.Add(":SPECIAL_SITUATION", OracleDbType.Varchar2).Value = timeSheetsAll.SpecialSituation;
                        comando.Parameters.Add(":TRUN", OracleDbType.Varchar2).Value = timeSheetsAll.Turno;
                        comando.Parameters.Add(":STATUS", OracleDbType.Decimal).Value = timeSheetsAll.Inconsistency;
                        comando.Parameters.Add(":AREA_ID", OracleDbType.Decimal).Value = timeSheetsAll.AreaId;
                        comando.Parameters.Add(":GROUP_TEAM_ID", OracleDbType.Decimal).Value = timeSheetsAll.GrupoId;
                        comando.Parameters.Add(":LEADER_ID", OracleDbType.Decimal).Value = timeSheetsAll.LeaderId;
                        comando.Parameters.Add(":SUPERVISOR_ID", OracleDbType.Decimal).Value = timeSheetsAll.SupervisorId;

                        comando.Parameters.Add(":TEAM_CODE", OracleDbType.Decimal).Value = timeSheetsAll.TeamCode;
                        comando.Parameters.Add(":RP_ID", OracleDbType.Decimal).Value = timeSheetsAll.RpId;
                        comando.Parameters.Add(":GERE_ID", OracleDbType.Decimal).Value = timeSheetsAll.GereId;
                        comando.Parameters.Add(":LOCAL_ID", OracleDbType.Decimal).Value = timeSheetsAll.LocalId;
                        comando.Parameters.Add(":TASK_ID", OracleDbType.Decimal).Value = timeSheetsAll.TaskId;
                        comando.Parameters.Add(":DIEF_ID", OracleDbType.Decimal).Value = timeSheetsAll.DiefId;
                        comando.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = timeSheetsAll.SbcnSigla;
                        comando.Parameters.Add(":TEAM_TIPO_MO", OracleDbType.Varchar2).Value = timeSheetsAll.TeamTipoMo;

                        comando.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    save = true;
                }
                catch (Exception ex)
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
        public bool EnviaStatus(string strMatricula, string strStatus, string strInicioAfastado, string strInicioFerias, string strFimFerias, string strDataDemissao)
        {
            bool save = false;
            using (OracleConnection con = new OracleConnection(Dados.StringDeConexao))
            {
                con.Open();

                OracleCommand comando = con.CreateCommand();
                OracleTransaction transaction;
                transaction = con.BeginTransaction(IsolationLevel.ReadCommitted);
                comando.Transaction = transaction;

                string userLogin = System.Environment.UserName;

                try
                {
                    string sql = @"UPDATE 
                                        ETA.TA_CRAFT 
                                    SET 
                                          STATUS_FDM = '" + strStatus + @"'
                                        , AFAST_INICIO = TO_DATE('" + strInicioAfastado + @"', 'DD/MM/YYYY')
                                        , FERIAS_INICIO = TO_DATE('" + strInicioFerias + @"', 'DD/MM/YYYY')
                                        , FERIAS_RETORNO = TO_DATE('" + strFimFerias + @"', 'DD/MM/YYYY')
                                        , DEMISSAO = TO_DATE('" + strDataDemissao + @"' , 'DD/MM/YYYY')
                                        , MODIFICADO_POR = '" + userLogin + @"'
                                    WHERE 
                                        EMP_NUMBER = " + strMatricula;

                    comando.CommandText = sql;
                    comando.ExecuteNonQuery();

                    save = true;
                }
                catch (Exception ex)
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
        public bool AtualizaStatus(string strMatricula, string strStatus, string strInicioAfastado, string strInicioFerias, string strFimFerias, string strDataDemissao)
        {
            try
            {
                string userLogin = System.Environment.UserName;

                string sql = @"UPDATE 
                                    ETA.TA_CRAFT 
                                SET 
                                        STATUS_FDM = '" + strStatus + @"'
                                    , AFAST_INICIO = TO_DATE('" + strInicioAfastado + @"', 'DD/MM/YYYY')
                                    , FERIAS_INICIO = TO_DATE('" + strInicioFerias + @"', 'DD/MM/YYYY')
                                    , FERIAS_RETORNO = TO_DATE('" + strFimFerias + @"', 'DD/MM/YYYY')
                                    , DEMISSAO = TO_DATE('" + strDataDemissao + @"' , 'DD/MM/YYYY')
                                    , MODIFICADO_POR = '" + userLogin + @"'
                                WHERE 
                                    EMP_NUMBER = " + strMatricula;

                using (OracleConnection conn = new OracleConnection(Dados.StringDeConexao))
                {
                    try
                    {
                        conn.Open();
                        OracleCommand cmd = new OracleCommand(sql, conn);
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool EnviaNovos(string strMatricula, string strNome, string strFuncao, string strDtAdmissao, string strTipoMO)
        {
            bool save = false;
            using (OracleConnection con = new OracleConnection(Dados.StringDeConexao))
            {
                con.Open();

                OracleCommand comando = con.CreateCommand();
                OracleTransaction transaction;
                transaction = con.BeginTransaction(IsolationLevel.ReadCommitted);
                comando.Transaction = transaction;

                string userLogin = System.Environment.UserName;

                try
                {
                    string sql = @"INSERT INTO TA_CRAFT (
                                        EMP_NUMBER,
                                        NAME,
                                        JOB_TITLE,
                                        HIRE_DATE,
                                        SAP,
                                        TIPO_DIRETA_INDIRETA,
                                        MODIFICADO_POR
                                    ) VALUES (
                                        " + strMatricula + @",
                                        '" + strNome + @"',
                                        '" + strFuncao + @"',
                                        TO_DATE('" + strDtAdmissao + @"', 'DD/MM/YY'),
                                        '" + strMatricula + @"',
                                        '" + strTipoMO + @"',
                                        '" + userLogin + @"'
                                    )";

                    comando.CommandText = sql;
                    comando.ExecuteNonQuery();

                    save = true;
                }
                catch (Exception ex)
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
        public bool InsereNovos(string strMatricula, string strNome, string strFuncao, string strDtAdmissao, string strTipoMO)
        {
            try
            {
                string userLogin = System.Environment.UserName;

                string sql = @"INSERT INTO TA_CRAFT 
                                    (
                                        EMP_NUMBER,
                                        NAME,
                                        JOB_TITLE,
                                        HIRE_DATE,
                                        SAP,
                                        TIPO_DIRETA_INDIRETA,
                                        MODIFICADO_POR
                                    ) VALUES (
                                        " + strMatricula + @",
                                        '" + strNome + @"',
                                        '" + strFuncao + @"',
                                        TO_DATE('" + strDtAdmissao + @"', 'DD/MM/YY'),
                                        '" + strMatricula + @"',
                                        '" + strTipoMO + @"',
                                        '" + userLogin + @"'
                                    )";

                using (OracleConnection conn = new OracleConnection(Dados.StringDeConexao))
                {
                    try
                    {
                        conn.Open();
                        OracleCommand cmd = new OracleCommand(sql, conn);
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AtualizaColaborador(string strMatricula, string strNome, string strFuncao, string strDtAdmissao, string strTipoMO)
        {
            try
            {
                string userLogin = System.Environment.UserName;

                string sql = @"UPDATE 
                                    TA_CRAFT
                                SET 
                                    MODIFICADO_POR = '" + userLogin + "'" + quebraLinha;
                                    if (strNome != "") sql += "                                  , NAME = '" + strNome + @"'" + quebraLinha;
                                    if (strFuncao != "") sql += "                                  , JOB_TITLE = '" + strFuncao + @"'" + quebraLinha;
                                    if (strDtAdmissao != "") sql += "                                  , HIRE_DATE = TO_DATE('" + strDtAdmissao + @"', 'DD/MM/YY')" + quebraLinha;
                                    if (strTipoMO != "") sql += "                                  , TIPO_DIRETA_INDIRETA = '" + strTipoMO + @"'" + quebraLinha;

                       sql += @"WHERE 
                                    EMP_NUMBER = " + strMatricula;

                using (OracleConnection conn = new OracleConnection(Dados.StringDeConexao))
                {
                    try
                    {
                        conn.Open();
                        OracleCommand cmd = new OracleCommand(sql, conn);
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string AllHoursCraft(decimal craftId, decimal teamId, string date)
        {
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
            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);
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
        public List<ListTimeSheets> PrintTimeSheets(decimal team_id, string date)
        {
            string sql;
            //  decimal OldTeamId = -1;
            int cntOne = 1;
            sql = @"SELECT 
                      ROWNUM AS LINHA, R.* 
                    FROM 
                     (SELECT 
                          TA_TEAM_X_CRAFT.TEAM_ID, TA_TEAM_X_CRAFT.CRAFT_ID as CRAFT_ID, TA_CRAFT.NAME as CRAFT_NAME, TA_CRAFT.JOB_TITLE as JOB_TITLE,
                          CASE 
                            WHEN STATUS_FDM = 'A' THEN 'Afastado'
                            WHEN STATUS_FDM = 'F' THEN 'Férias'
                            WHEN STATUS_FDM = 'R' THEN 'Licença Remunerada'
                          END AS STATUS_FDM
                    FROM 
                        ETA.TA_TEAM_X_CRAFT,ETA.TA_CRAFT 
                    WHERE 
                            TA_TEAM_X_CRAFT.CRAFT_ID = TA_CRAFT.EMP_NUMBER 
                        AND TA_TEAM_X_CRAFT.TEAM_ID = " + team_id + @"
                        AND TA_CRAFT.STATUS <> 0 
                        AND ((TA_CRAFT.STATUS_FDM != 'D' AND TA_CRAFT.STATUS_FDM != 'L') OR TA_CRAFT.STATUS_FDM IS NULL) 
                    ORDER BY 
                        TA_TEAM_X_CRAFT.TEAM_ID,TA_CRAFT.NAME) R ";

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
                    //listTimeSheets.Nome = FirstLastName(listTimeSheets.Nome);
                    listTimeSheets.GroupId = groupId;
                    listTimeSheets.StatusFDM = reader["STATUS_FDM"].ToString();
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
                    if (cntOne % (numberOfLines) == 0)
                    {
                        groupId++;
                        cntOne = 0;
                    }
                    cntOne++;
                }

                if (cntOne != 1)
                {
                    while (cntOne < numberOfLines)
                    {
                        ListTimeSheets listTimeSheetsWhite = new ListTimeSheets();
                        listTimeSheetsWhite.TeamId = team_id;
                        listTimeSheetsWhite.GroupId = groupId;
                        listTimeSheetsWhite.Linha = "  ";
                        listTimeSheetsWhite.Matricula = "  ";
                        listTimeSheetsWhite.Nome = "  ";
                        listTimeSheetsWhite.Funcao = "  ";
                        listTimeSheetsWhite.StatusFDM = "  ";
                        resultListTimeSheets.Add(listTimeSheetsWhite);
                        cntOne++;
                    }
                }
                con.Close();
                return resultListTimeSheets;
            }
        }
        public List<ListTimeSheets> ImprimeIntegrantes(string sql, decimal team_id, string date)
        {
            int cntOne = 1;
            
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
                    listTimeSheets.Nome = reader["CRAFT_NAME"].ToString();
                    listTimeSheets.Funcao = reader["JOB_TITLE"].ToString();
                    listTimeSheets.GroupId = groupId;
                    listTimeSheets.StatusFDM = reader["STATUS_FDM"].ToString();
                    resultListTimeSheets.Add(listTimeSheets);
                    if (cntOne % (numberOfLines) == 0)
                    {
                        groupId++;
                        cntOne = 0;
                    }
                    cntOne++;
                }

                if (cntOne != 1)
                {
                    while (cntOne < numberOfLines)
                    {
                        ListTimeSheets listTimeSheetsWhite = new ListTimeSheets();
                        listTimeSheetsWhite.TeamId = team_id;
                        listTimeSheetsWhite.GroupId = groupId;
                        listTimeSheetsWhite.Linha = "  ";
                        listTimeSheetsWhite.Matricula = "  ";
                        listTimeSheetsWhite.Nome = "  ";
                        listTimeSheetsWhite.Funcao = "  ";
                        listTimeSheetsWhite.StatusFDM = "  ";
                        resultListTimeSheets.Add(listTimeSheetsWhite);
                        cntOne++;
                    }
                }
                con.Close();
                return resultListTimeSheets;
            }
        }
        public List<ListTimeSheets> RelacaoConvocados(decimal TeamId, string De, string Ate)
        {
            string sql;
            int cntOne = 1;
            sql = @"SELECT
                        tecr.TEAM_ID, tecr.CRAFT_ID, craf.NAME AS CRAFT_NAME, craf.JOB_TITLE, expe.EXPE_DATA
                    FROM 
                        ETA.TA_EXAMES_PERIODICOS expe, ETA.TA_TEAM_X_CRAFT tecr, ETA.TA_CRAFT craf, ETA.TA_TEAM team
                    WHERE 
                            expe.EXPE_CRAFT_ID = tecr.CRAFT_ID
                        AND tecr.CRAFT_ID = craf.EMP_NUMBER
                        AND tecr.TEAM_ID = team.ID
                        AND team.GROUP_ID > 20
                        AND tecr.INIT_DATE IS NOT NULL
                        AND team.TEAM_TIPO_MO = 'MOD'
                        AND tecr.TEAM_ID = " + TeamId + @"
                        AND TO_DATE(expe.EXPE_DATA, 'DD/MM/YYYY') BETWEEN TO_DATE('" + De + "', 'DD/MM/YYYY') AND TO_DATE('" + Ate + @"', 'DD/MM/YYYY')
                    ORDER BY
                      EXPE_DATA";

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
                    listTimeSheets.TeamId = Convert.ToDecimal(reader["TEAM_ID"]);
                    listTimeSheets.Matricula = reader["CRAFT_ID"].ToString().PadLeft(4, '0');
                    listTimeSheets.Nome = reader["CRAFT_NAME"].ToString();
                    listTimeSheets.Funcao = reader["JOB_TITLE"].ToString();
                    listTimeSheets.DataExame = reader["EXPE_DATA"].ToString();
                    listTimeSheets.GroupId = groupId;

                    resultListTimeSheets.Add(listTimeSheets);
                    if (cntOne % (numberOfLines) == 0)
                    {
                        groupId++;
                        cntOne = 0;
                    }
                    cntOne++;
                }

                if (cntOne != 1)
                {
                    while (cntOne < numberOfLines)
                    {
                        ListTimeSheets listTimeSheetsWhite = new ListTimeSheets();
                        listTimeSheetsWhite.GroupId = groupId;
                        listTimeSheetsWhite.Linha = "  ";
                        listTimeSheetsWhite.Matricula = "  ";
                        listTimeSheetsWhite.Nome = "  ";
                        listTimeSheetsWhite.Funcao = "  ";
                        listTimeSheetsWhite.DataExame = "   ";
                        listTimeSheetsWhite.StatusFDM = "  ";
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
                comando.Parameters.Add("DATE_APROPR", OracleDbType.Varchar2).Value = data.ToString();
                comando.Parameters.Add("dia", OracleDbType.Varchar2).Value = dia.ToUpper();

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
        public DataTable ListarSuperiores(string teamCode, string dataConsulta)
        {
            string sql;
            sql = @"SELECT 
                        team.GROUP_ID,
                        team.AREA_ID,
                        team.ID AS TEAM_ID,
                        team.TEAM_TIPO_MO,
                        (SELECT DISTINCT
                            COUNT(vihi0.CRAFT_ID) AS QTD_FUNCIONARIO_EQUIPE
                        FROM 
                            ETA.VW_TA_VINCULO_HISTORICO vihi0, ETA.TA_TEAM team0, ETA.TA_CRAFT craf0
                        WHERE
                                vihi0.TEAM_ID = team.ID
                            AND vihi0.CRAFT_ID = craf0.EMP_NUMBER
                            AND team0.STATUS = 1
                            AND team0.GROUP_ID > 20
                            AND (craf0.DEMISSAO IS NULL OR craf0.DEMISSAO >= TO_DATE('" + dataConsulta + @"','DD/MM/YY'))
                            AND TO_DATE('" + dataConsulta + @"','DD/MM/YY') BETWEEN vihi0.INIT_DATE AND vihi0.FINAL_DATE
                            AND team0.TEAM_CODE = team.TEAM_CODE) AS QTD_FUNCIONARIO_EQUIPE,
                        team.STATUS
                    FROM 
                        ETA.TA_TEAM team,
                        ETA.TA_CRAFT craf,
                        ETA.TA_AREAS area
                    WHERE
                            team.LEADER_ID = craf.EMP_NUMBER (+)
                        AND team.AREA_ID = area.ID (+) 
                        AND team.GROUP_ID >= 21
                        AND team.TEAM_CODE > 0
                        AND team.TEAM_CODE = '" + teamCode + @"'
                    ORDER BY
                      team.STATUS DESC";

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
        public DataTable ListarSemApropriacao(DateTime dt1, DateTime dt2)
        {
            //Calcula quantos dias foram selecionados
            TimeSpan ts = dt2.Subtract(dt1);
            int qtdDiasSelecionado = ts.Days;

            string sql = "";

            for (int i = 0; i <= qtdDiasSelecionado; i++)
            {
                //string diaSemana = dt1.AddDays(i).ToString("ddd");

                if (i > 0)
                {
                    sql += @"

                       UNION

                       ";
                }

                sql += @"SELECT
                            craf.EMP_NUMBER AS MATRICULA,
                            craf.NAME AS NOME,
                            team.TEAM_CODE AS EQUIPE,
                            NVL(HORAS, 0) AS HORAS,
                            TO_CHAR(TO_DATE('" + dt1.AddDays(i).ToString("dd/MM/yy") + @"','DD/MM/YY'),'MM/DD/YYYY') AS DATA_APROPRIACAO,
                            team.TEAM_TIPO_MO AS TIPO_MO,
                            TO_CHAR(craf.DEMISSAO, 'DD/MM/YYYY') AS DEMISSAO,
                            craf.STATUS_FDM AS STATUS,
                            TO_CHAR(craf.FERIAS_INICIO, 'DD/MM/YYYY') AS FERIAS_INICIO,
                            TO_CHAR(craf.FERIAS_RETORNO, 'DD/MM/YYYY') AS FERIAS_RETORNO
                        FROM
                            ETA.TA_CRAFT craf,
                            (SELECT 
                                  CRAFT_ID,
                                  SUM(WORKED_HOURS + OVERTIME_HOURS) AS HORAS
                              FROM 
                                  ETA.TA_TIMESHEET 
                              WHERE
                                  EXECUTION_DATE = TO_DATE('" + dt1.AddDays(i).ToString("dd/MM/yy") + @"','DD/MM/YY')
                              GROUP BY
                                  CRAFT_ID) time,
                            ETA.VW_TA_VINCULO_HISTORICO vihi,
                            ETA.TA_TEAM team
                        WHERE
                                craf.EMP_NUMBER = time.CRAFT_ID (+)
                            AND craf.EMP_NUMBER = vihi.CRAFT_ID
                            AND TO_DATE('" + dt1.AddDays(i).ToString("dd/MM/yy") + @"','DD/MM/YY') BETWEEN vihi.INIT_DATE AND vihi.FINAL_DATE
                            AND vihi.TEAM_ID = team.ID
                            AND (craf.DEMISSAO IS NULL OR craf.DEMISSAO > TO_DATE('" + dt1.AddDays(i).ToString("dd/MM/yy") + @"','DD/MM/YY'))
                            AND (HORAS = 0 OR HORAS IS NULL)
                            AND team.STATUS = 1
                            AND team.GROUP_ID > 20
                            AND team.TEAM_TIPO_MO = 'MOD'
                        GROUP BY
                            craf.EMP_NUMBER,
                            team.TEAM_CODE,
                            craf.NAME,
                            HORAS,
                            team.TEAM_TIPO_MO,
                            craf.DEMISSAO,
                            craf.STATUS_FDM,
                            craf.FERIAS_INICIO,
                            craf.FERIAS_RETORNO";

                if (i == qtdDiasSelecionado)
                {
                    sql += @"
                        ORDER BY
                            DATA_APROPRIACAO, EQUIPE";
                }
            }

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
        public DataTable ListarMovimentacaoDiaria(DateTime dt)
        {
            string sql = @"SELECT 
                                craf.EMP_NUMBER AS " + aspas + @"MATRÍCULA" + aspas + @", craf.NAME AS NOME, 
                                craf.JOB_TITLE AS " + aspas + @"FUNÇÃO" + aspas + @", 
                                craf.STATUS_FDM AS STATUS, craf.TIPO_DIRETA_INDIRETA AS " + aspas + @"TIPO MO" + aspas + @", 
                                team.TEAM_CODE AS " + aspas + @"CÓD EQUIPE" + aspas + @", team.NAME AS " + aspas + @"NOME EQUIPE" + aspas + @"
                            FROM 
                                ETA.TA_TEAM_X_CRAFT tecr, ETA.TA_CRAFT craf, ETA.TA_TEAM team
                            WHERE
                                    tecr.INIT_DATE = TO_DATE('" + dt.ToString("dd/MM/yy") + @"', 'DD/MM/YY') 
                                AND tecr.CRAFT_ID = craf.EMP_NUMBER 
                                AND team.ID = tecr.TEAM_ID
                            ORDER BY 
                                craf.EMP_NUMBER";

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
        public DataTable ListarApropriacaoPeriodo(DateTime dt1, DateTime dt2)
        {
            string sql = @"SELECT 
                                (SELECT craf.EMP_NUMBER FROM ETA.TA_CRAFT craf WHERE craf.EMP_NUMBER = tish.CRAFT_ID) AS " + aspas + @"MATRÍCULA" + aspas + @",
                                (SELECT craf.NAME FROM ETA.TA_CRAFT craf WHERE craf.EMP_NUMBER = tish.CRAFT_ID) AS " + aspas + @"FUNCIONÁRIO" + aspas + @",
                                (SELECT ativ.TITLE FROM ETA.TA_ACTIVITIES ativ WHERE ativ.ID = tish.ACTIVITY_ID) AS ATIVIDADE,
                                (SELECT ativ.COMMENTS FROM ETA.TA_ACTIVITIES ativ WHERE ativ.ID = tish.ACTIVITY_ID) AS " + aspas + @"DESCRIÇÃO ATIVIDADE" + aspas + @",
                                TO_CHAR((SELECT ativ.TA_UA FROM ETA.TA_ACTIVITIES ativ WHERE ativ.ID = tish.ACTIVITY_ID)) AS UA,
                                (SELECT ativ.TYPE FROM ETA.TA_ACTIVITIES ativ WHERE ativ.ID = tish.ACTIVITY_ID) AS TIPO,
                                EXECUTION_DATE AS " + aspas + @"DATA EXECUÇÃO" + aspas + @",
                                (SELECT SEMA_ID FROM ETA.TA_SEMANA WHERE EXECUTION_DATE BETWEEN SEMA_DATA_INICIO AND SEMA_DATA_FIM) AS SEMANA,
                                WORKED_HOURS AS HN, OVERTIME_HOURS AS HE, TEAM_CODE AS " + aspas + @"CÓD EQUIPE" + aspas + @",
                                (SELECT NAME FROM ETA.TA_CRAFT cr WHERE cr.EMP_NUMBER = tish.LEADER_ID) AS " + aspas + @"NOME ENCARREGADO" + aspas + @",
                                (SELECT RP_DESCRIPTION FROM ETA.TA_RP rp WHERE rp.RP_ID = tish.RP_ID) AS " + aspas + @"NOME RP" + aspas + @",
                                (SELECT GERE_DESCRIPTION FROM ETA.TA_GERENCIA gere WHERE gere.GERE_ID = tish.GERE_ID) AS " + aspas + @"DESCRIÇÃO GERENCIA" + aspas + @",
                                (SELECT LOCAL_DESCRIPTION FROM ETA.TA_LOCAL loca WHERE loca.LOCAL_ID = tish.LOCAL_ID) AS " + aspas + @"DESCRIÇÃO LOCAL" + aspas + @",
                                (SELECT DIEF_DESCRIPTION FROM ETA.TA_DISCIPLINA_EFETIVO dief WHERE dief.DIEF_ID = tish.DIEF_ID) AS " + aspas + @"DISCIPLINA EFETIVO" + aspas + @",
                                SBCN_SIGLA AS " + aspas + @"SUB CONTRATO" + aspas + @",
                                TEAM_TIPO_MO AS " + aspas + @"TIPO MO" + aspas + @"
                            FROM 
                                ETA.TA_TIMESHEET tish
                            WHERE
                                    EXECUTION_DATE BETWEEN TO_DATE('" + dt1.ToString("dd/MM/yy") + @"', 'DD/MM/YY') AND TO_DATE('" + dt2.ToString("dd/MM/yy") + @"', 'DD/MM/YY')
                                AND WORKED_HOURS + OVERTIME_HOURS > 0";

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
        public DataTable ListarSemanas(int mes, int ano)
        {
            string sql = @"SELECT 
                                SEMA_ID
                            FROM 
                                ETA.TA_SEMANA
                            WHERE
                                    TO_NUMBER(SUBSTR(SEMA_MES_COMPETENCIA, 1, 2)) = " + mes + @"
                                AND TO_NUMBER(SUBSTR(SEMA_MES_COMPETENCIA, 4, 4)) = " + ano + @"
                            ORDER BY
                                SEMA_ID";

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
        public DataTable ListarProdutividade(DataTable dtbSemanas)
        {
            int qtdSemanas = dtbSemanas.Rows.Count;
            string sql = @"SELECT 
                                DESCRICAO_LOCAL AS LOCAL, UA, DESCRICAO_ATIVIDADE AS ATIVIDADE, ORCA_QTD_ORCADO AS " + aspas + @"QTD ORÇADO" + aspas + @",
                                UNIDADE_MEDIDA AS " + aspas + @"UNID." + aspas + @", ORCA_HH_ORCADO AS " + aspas + @"HH ORÇADO" + aspas + @", 
                                INDICE_ORCADO AS " + aspas + @"ÍNDICE ORÇADO" + aspas + @", 
                                NVL2(UNIDADE_MEDIDA, 'HH/' || UNIDADE_MEDIDA, '') AS " + aspas + @"UNID. ÍNDICE" + aspas + @"," + quebraLinha;

                                for (int i = 0; i < qtdSemanas; i++)
                                {
                                    sql += @"                                '' AS PROG_" + dtbSemanas.Rows[i][0] + ", REAL_" + dtbSemanas.Rows[i][0] + ", '' AS HH_PREV_" + dtbSemanas.Rows[i][0] + ", SUM(DECODE(SEMANA, " + dtbSemanas.Rows[i][0] + ", HORA_NORMAL + HORA_EXTRA, 0)) AS HH_REAL_" + dtbSemanas.Rows[i][0] + @", 
                                    ROUND(CASE WHEN REAL_" + dtbSemanas.Rows[i][0] + " = 0 OR REAL_" + dtbSemanas.Rows[i][0] + " IS NULL THEN 0 ELSE SUM(DECODE(SEMANA, " + dtbSemanas.Rows[i][0] + ", HORA_NORMAL + HORA_EXTRA, 0)) / REAL_" + dtbSemanas.Rows[i][0] + " END, 2) AS INDICE_" + dtbSemanas.Rows[i][0] + ((i < qtdSemanas - 1) ? ", " : "") + quebraLinha;
                                }

                   sql += @"FROM 
                                ETA.VW_APROPRIACAO_POR_PERIODO, ETA.TA_ORCAMENTO,
                                (SELECT
                                    atli.ATLI_TEXTO, unac.UNAC_SIGLA, " + quebraLinha;

                                    for (int i = 0; i < qtdSemanas; i++)
                                    {
                                        sql += @"                                    MAX(DECODE(SEMANA, " + dtbSemanas.Rows[i][0] + ", EXEC_POND, 0)) AS REAL_" + dtbSemanas.Rows[i][0] + ((i < qtdSemanas - 1) ? ", " : "") + quebraLinha;
                                    }

                   sql += @"    FROM
                                    (";

                                    for (int i = 0; i < qtdSemanas; i++)
                                    {
                                        sql += @"SELECT
                                                    fose.FOSE_CNTR_CODIGO, exma.UNAC_ID, exma.FOSE_ID, exma.FCES_ID, exma.SEMANA,
                                                    ROUND((((fose.FOSE_QTD_PREVISTA * ((exma.PERC_CRITERIO / peua.SOMA_PERC) * 100)) / 100) * NVL2(exan.FSME_AVANCO_ACM, exma.EXEC_SEM_ACUM - exan.FSME_AVANCO_ACM, exma.EXEC_SEM_ACUM)) / 100, 3) AS EXEC_POND
                                                FROM
                                                    (SELECT
                                                        NVL2(fosm.FOSM_UNAC_ID, fosm.FOSM_UNAC_ID, fose.FOSE_UNAC_ID) AS UNAC_ID,
                                                        fose.FOSE_ID, fces.FCES_ID, fces.FCES_SIGLA, fces.FCES_PESO_REL_CRON AS PERC_CRITERIO,
                                                        (SELECT SEMA_ID FROM ETA.TA_SEMANA WHERE fsme.FSME_DATA BETWEEN SEMA_DATA_INICIO AND SEMA_DATA_FIM) AS SEMANA,
                                                        MAX(fsme.FSME_AVANCO_ACM) AS EXEC_SEM_ACUM
                                                    FROM 
                                                        EPCCQ.FOLHA_SERVICO fose, EPCCQ.FOLHA_SERVICO_MEDICAO fosm, EPCCQ.FOLHA_CRITERIO_ESTRUTURA fces, EPCCQ.FOLHA_SERVICO_MEDICAO_EXEC fsme, EPCCQ.ATRIBUTO_VINCULO atvi
                                                    WHERE   
                                                            fose.FOSE_ID = fosm.FOSM_FOSE_ID AND fose.FOSE_CNTR_CODIGO = fosm.FOSM_CNTR_CODIGO 
                                                        AND fosm.FOSM_FCES_ID = fces.FCES_ID (+) AND fosm.FOSM_CNTR_CODIGO = fces.FCES_CNTR_CODIGO (+)
                                                        AND fosm.FOSM_ID = fsme.FSME_FOSM_ID (+) AND fosm.FOSM_CNTR_CODIGO = fsme.FSME_CNTR_CODIGO (+)
                                                        AND fose.FOSE_ID = atvi.ATVI_FOSE_ID AND fose.FOSE_CNTR_CODIGO = atvi.ATVI_CNTR_CODIGO 
                                                        AND (fosm.FOSM_UNAC_ID IS NOT NULL OR fose.FOSE_UNAC_ID IS NOT NULL) -- PEGA UA DA TAREFA, SE NÃO TIVER PEGA DA FS
                                                        AND (SELECT MAX(FCES_NIVEL) FROM EPCCQ.FOLHA_CRITERIO_ESTRUTURA WHERE FCES_FCME_ID = fose.FOSE_FCME_ID) = fces.FCES_NIVEL -- PEGA ÚLTIMO NÍVEL DA TAREFA
                                                        AND fosm.FOSM_CNTR_CODIGO = 'Conversão' 
                                                        AND fces.FCES_PESO_REL_CRON > 0
                                                        AND atvi.ATVI_ATPE_ID = 14
                                                        AND (CASE WHEN fose.FOSE_DISC_ID = 2 AND fose.FOSE_FCME_ID <> 116 THEN '0' ELSE '1' END) <> '0' -- DE ESTRUTURA PEGA APENAS O CRITÉRIO AVANÇO%
                                                        AND (SELECT SEMA_ID FROM ETA.TA_SEMANA WHERE fsme.FSME_DATA BETWEEN SEMA_DATA_INICIO AND SEMA_DATA_FIM) = " + dtbSemanas.Rows[i][0] + quebraLinha + @"
                                                        --AND fose.FOSE_NUMERO IN ('PRACK6C_C-B18H-6026_7382_SP03', 'PRACK6C_C-B18H-6026_7382_SP02')
                                                    GROUP BY
                                                        fosm.FOSM_UNAC_ID, fose.FOSE_UNAC_ID, fose.FOSE_ID, fces.FCES_ID, fces.FCES_SIGLA, fces.FCES_PESO_REL_CRON, fsme.FSME_DATA) exma,
                                                    (SELECT
                                                        NVL2(fosm.FOSM_UNAC_ID, fosm.FOSM_UNAC_ID, fose.FOSE_UNAC_ID) AS UNAC_ID,
                                                        fose.FOSE_ID, fces.FCES_ID, fces.FCES_SIGLA,
                                                        MAX(fsme.FSME_AVANCO_ACM) AS FSME_AVANCO_ACM
                                                    FROM 
                                                        EPCCQ.FOLHA_SERVICO fose, EPCCQ.FOLHA_SERVICO_MEDICAO fosm, EPCCQ.FOLHA_CRITERIO_ESTRUTURA fces, EPCCQ.FOLHA_SERVICO_MEDICAO_EXEC fsme, EPCCQ.ATRIBUTO_VINCULO atvi
                                                    WHERE   
                                                            fose.FOSE_ID = fosm.FOSM_FOSE_ID AND fose.FOSE_CNTR_CODIGO = fosm.FOSM_CNTR_CODIGO 
                                                        AND fosm.FOSM_FCES_ID = fces.FCES_ID (+) AND fosm.FOSM_CNTR_CODIGO = fces.FCES_CNTR_CODIGO (+)
                                                        AND fosm.FOSM_ID = fsme.FSME_FOSM_ID (+) AND fosm.FOSM_CNTR_CODIGO = fsme.FSME_CNTR_CODIGO (+)
                                                        AND fose.FOSE_ID = atvi.ATVI_FOSE_ID AND fose.FOSE_CNTR_CODIGO = atvi.ATVI_CNTR_CODIGO 
                                                        AND (fosm.FOSM_UNAC_ID IS NOT NULL OR fose.FOSE_UNAC_ID IS NOT NULL) -- PEGA UA DA TAREFA, SE NÃO TIVER PEGA DA FS
                                                        AND (SELECT MAX(FCES_NIVEL) FROM EPCCQ.FOLHA_CRITERIO_ESTRUTURA WHERE FCES_FCME_ID = fose.FOSE_FCME_ID) = fces.FCES_NIVEL -- PEGA ÚLTIMO NÍVEL DA TAREFA
                                                        AND fosm.FOSM_CNTR_CODIGO = 'Conversão' 
                                                        AND fces.FCES_PESO_REL_CRON > 0
                                                        AND atvi.ATVI_ATPE_ID = 14
                                                        AND (CASE WHEN fose.FOSE_DISC_ID = 2 AND fose.FOSE_FCME_ID <> 116 THEN '0' ELSE '1' END) <> '0' -- DE ESTRUTURA PEGA APENAS O CRITÉRIO AVANÇO%
                                                        AND (SELECT SEMA_ID FROM ETA.TA_SEMANA WHERE fsme.FSME_DATA BETWEEN SEMA_DATA_INICIO AND SEMA_DATA_FIM) < " + dtbSemanas.Rows[i][0] + @"
                                                        --AND fose.FOSE_NUMERO IN ('PRACK6C_C-B18H-6026_7382_SP03', 'PRACK6C_C-B18H-6026_7382_SP02')
                                                    GROUP BY
                                                        fosm.FOSM_UNAC_ID, fose.FOSE_UNAC_ID, fose.FOSE_ID, fces.FCES_ID, fces.FCES_SIGLA) exan,
                                                    ETA.VW_PERC_UA peua,
                                                    EPCCQ.FOLHA_SERVICO fose
                                                WHERE
                                                        exma.UNAC_ID = exan.UNAC_ID (+)
                                                    AND exma.FOSE_ID = exan.FOSE_ID (+)
                                                    AND exma.FCES_ID = exan.FCES_ID (+)
                                                    AND exma.UNAC_ID = peua.UNAC_ID
                                                    AND exma.FOSE_ID = peua.FOSE_ID
                                                    AND exma.FOSE_ID = fose.FOSE_ID
                                                " + ((i < qtdSemanas - 1) ? "UNION " : "");
                                    }

                                    sql += @"        ) exse,
                                    EPCCQ.ATRIBUTO_VINCULO atvi,
                                    EPCCQ.ATRIBUTO_LISTA atli,
                                    EPCCQ.UNIDADE_ACOMPANHAMENTO unac
                                WHERE
                                        exse.FOSE_ID = atvi.ATVI_FOSE_ID AND exse.FOSE_CNTR_CODIGO = atvi.ATVI_CNTR_CODIGO 
                                    AND atvi.ATVI_ATLI_ID = atli.ATLI_ID AND exse.FOSE_CNTR_CODIGO = atli.ATLI_CNTR_CODIGO 
                                    AND exse.UNAC_ID = unac.UNAC_ID (+)
                                    AND atvi.ATVI_ATPE_ID = 14
                                GROUP BY
                                    atli.ATLI_TEXTO, unac.UNAC_SIGLA
                                ORDER BY
                                    atli.ATLI_TEXTO, unac.UNAC_SIGLA) exec
                            WHERE
                                    LOCAL_ID = ORCA_LOCA_ID (+)
                                AND ACTIVITY_ID = ORCA_ATIV_ID (+)
                                AND DESCRICAO_LOCAL = exec.ATLI_TEXTO (+)
                                AND UA = exec.UNAC_SIGLA (+)
                                AND SEMANA IN (";

                                for (int i = 0; i < qtdSemanas; i++)
                                {
                                    sql += dtbSemanas.Rows[i][0] + ((i < qtdSemanas - 1) ? ", " : "");
                                }

               sql += @")
                                AND TEAM_TIPO_MO = 'MOD'
                                AND TYPE = 'PRD'
                            GROUP BY
                                DESCRICAO_LOCAL, UA, DESCRICAO_ATIVIDADE, ORCA_QTD_ORCADO, INDICE_ORCADO, UNIDADE_MEDIDA, ORCA_HH_ORCADO, ";

                                for (int i = 0; i < qtdSemanas; i++)
                                {
                                    sql += "REAL_" + dtbSemanas.Rows[i][0] + ((i < qtdSemanas - 1) ? ", " : quebraLinha);
                                }

               sql += @"    ORDER BY
                                DESCRICAO_LOCAL, UA, DESCRICAO_ATIVIDADE";


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
        public bool QtdIntegrantes(decimal teamId)
        {
            bool retorno = false;
            string sql = SqlIntegrantes(teamId);

            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;

            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }

            return retorno;
        }

        public string SqlIntegrantes(decimal teamId)
        {
            string sql = @"SELECT 
                                ROWNUM AS LINHA, R.* 
                            FROM 
                                (SELECT 
                                    TA_TEAM_X_CRAFT.TEAM_ID, TA_TEAM_X_CRAFT.CRAFT_ID as CRAFT_ID, TA_CRAFT.NAME as CRAFT_NAME, TA_CRAFT.JOB_TITLE as JOB_TITLE,
                                    CASE 
                                    WHEN STATUS_FDM = 'A' THEN 'Afastado'
                                    WHEN STATUS_FDM = 'F' THEN 'Férias'
                                    WHEN STATUS_FDM = 'R' THEN 'Licença Remunerada'
                                    END AS STATUS_FDM
                            FROM 
                                ETA.TA_TEAM_X_CRAFT,ETA.TA_CRAFT 
                            WHERE 
                                    TA_TEAM_X_CRAFT.CRAFT_ID = TA_CRAFT.EMP_NUMBER 
                                AND TA_TEAM_X_CRAFT.TEAM_ID = " + teamId + @"
                                AND TA_CRAFT.STATUS <> 0 
                                AND ((TA_CRAFT.STATUS_FDM != 'D' AND TA_CRAFT.STATUS_FDM != 'L') OR TA_CRAFT.STATUS_FDM IS NULL) 
                            ORDER BY 
                                TA_TEAM_X_CRAFT.TEAM_ID,TA_CRAFT.NAME) R ";

            return sql;
        }
        public bool ConsultaFalta(string strDataFalta, string strMatricula)
        {
            bool retorno = false;
            string sql = @"SELECT 
                                FALTA_DATA,
                                FALTA_EMP_NUMBER
                            FROM 
                                ETA.TA_FALTA
                            WHERE
                                    FALTA_DATA = TO_DATE('" + strDataFalta + @"', 'DD/MM/YYYY')
                                AND FALTA_EMP_NUMBER = " + strMatricula;

            OracleConnection con = new OracleConnection(Dados.StringDeConexao);
            OracleCommand cmd = new OracleCommand(sql, con);

            cmd.CommandType = CommandType.Text;

            using (con)
            {
                con.Open();
                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }

            return retorno;
        }
        public decimal ConsultaMatricula(string strMatricula)
        {
            try
            {
                decimal retorno = 0;
                string sql;

                sql = @"SELECT EMP_NUMBER FROM ETA.TA_CRAFT WHERE EMP_NUMBER = '" + strMatricula + @"'";

                OracleConnection con = new OracleConnection(Dados.StringDeConexao);
                OracleCommand cmd = new OracleCommand(sql, con);

                cmd.CommandType = CommandType.Text;

                using (con)
                {
                    con.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        retorno = 1;
                    }
                    else
                    {
                        retorno = 2;
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public DataTable PreparaMascaraFaltas(string strDataFalta, string strMatricula)
        {
            string sql = @"SELECT  
                                team.DIEF_ID,
                                team.SBCN_SIGLA,
                                (SELECT SEMA_ID FROM ETA.TA_SEMANA WHERE TO_DATE('" + strDataFalta + @"', 'DD/MM/YYYY') BETWEEN SEMA_DATA_INICIO AND SEMA_DATA_FIM) AS SEMANA
                            FROM 
                                ETA.TA_TEAM_X_CRAFT tecr, 
                                ETA.TA_TEAM team
                            WHERE  
                                    tecr.TEAM_ID = team.ID
                                AND team.STATUS = 1
                                AND team.GROUP_ID > 20
                                AND tecr.CRAFT_ID = " + strMatricula;

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

        public bool VerificaSeAtualiza(string matricula, string strCodSituacao, string strInicio, string strFim)
        {
            try
            {
                bool retorno = false;
                string sql;

                sql = @"SELECT 
                            SIHI_ID
                        FROM 
                            TA_SITUACAO_HISTORICO
                        WHERE
                                SIHI_CRAFT_ID = '" + matricula + @"'
                            AND SIHI_SITU_ID = '" + strCodSituacao + @"'
                            AND SIHI_DATA_INICIO IS NOT NULL
                            AND SIHI_DATA_FIM IS NULL";

                OracleConnection con = new OracleConnection(Dados.StringDeConexao);
                OracleCommand cmd = new OracleCommand(sql, con);

                cmd.CommandType = CommandType.Text;

                using (con)
                {
                    con.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        retorno = true;
                    }
                    else
                    {
                        retorno = false;
                    }
                }
                return retorno;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AtualizaMatricula(string strmatricula, string strCodSituacao, string strInicio, string strFim)
        {
            try
            {
                string userLogin = System.Environment.UserName;
                string sql;

                sql = @"UPDATE 
                            TA_SITUACAO_HISTORICO 
                        SET 
                            SIHI_DATA_FIM = '" + Convert.ToDateTime(strFim).ToString("dd/MM/yyyy") + @"', 
                            SIHI_CRIADO_POR = '" + userLogin + @"'
                        WHERE 
                                SIHI_CRAFT_ID    = '" + strmatricula + @"'
                            AND SIHI_SITU_ID     = '" + strCodSituacao + @"'
                            AND SIHI_DATA_FIM IS NULL";

                using (OracleConnection conn = new OracleConnection(Dados.StringDeConexao))
                {
                    try
                    {
                        conn.Open();
                        OracleCommand cmd = new OracleCommand(sql, conn);
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool InsereFalta(string strDataFalta, string strMatricula, string strDisciplina, string strSubContrato, string strSemana)
        {
            try
            {
                string userLogin = System.Environment.UserName;

                string sql = @"INSERT INTO ETA.TA_FALTA
                                  (
                                    FALTA_DATA,
                                    FALTA_EMP_NUMBER,
                                    FALTA_DIEF_ID,
                                    FALTA_SBCN_SIGLA,
                                    FALTA_SEMANA,
                                    FALTA_CRIADO_POR
                                  )
                                  VALUES
                                  (
                                    TO_DATE('" + strDataFalta + @"', 'DD/MM/YYYY'),
                                    '" + strMatricula + @"',
                                    '" + strDisciplina + @"',
                                    '" + strSubContrato + @"',
                                    '" + strSemana + @"',
                                    '" + userLogin + @"'
                                  )";

                using (OracleConnection conn = new OracleConnection(Dados.StringDeConexao))
                {
                    try
                    {
                        conn.Open();
                        OracleCommand cmd = new OracleCommand(sql, conn);
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public decimal VerificaJaCadastrado(string matricula, string strInicio, string strFim)
        {
            try {
                decimal retorno = 0;
                string sql;

                if (strInicio != "") strInicio = Convert.ToDateTime(strInicio).ToString("dd/MM/yyyy");
                if (strFim != "") strFim = Convert.ToDateTime(strFim).ToString("dd/MM/yyyy");

                sql = @"SELECT 
                            SIHI_CRAFT_ID
                        FROM 
                            TA_SITUACAO_HISTORICO
                        WHERE
                                SIHI_CRAFT_ID = '" + matricula + @"'
                            AND (SIHI_DATA_INICIO = '" + strInicio + @"'
                              OR (TO_DATE('" + strInicio + @"', 'DD/MM/YY') BETWEEN TO_DATE(SIHI_DATA_INICIO, 'DD/MM/YY') AND TO_DATE(SIHI_DATA_FIM, 'DD/MM/YY')) 
                              OR (TO_DATE('" + strFim + @"', 'DD/MM/YY') BETWEEN TO_DATE(SIHI_DATA_INICIO, 'DD/MM/YY') AND TO_DATE(SIHI_DATA_FIM, 'DD/MM/YY')))";

                OracleConnection con = new OracleConnection(Dados.StringDeConexao);
                OracleCommand cmd = new OracleCommand(sql, con);

                cmd.CommandType = CommandType.Text;

                using (con)
                {
                    con.Open();
                    OracleDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        retorno = 3;
                    }
                    else
                    {
                        retorno = 1;
                    }
                }

                return retorno;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool CadastraSituacao(string strMatricula, string strCodSituacao, string strInicio, string strFim)
        {
            try
            {
                string userLogin = System.Environment.UserName;

                if (strInicio != "") strInicio = Convert.ToDateTime(strInicio).ToString("dd/MM/yyyy");
                if (strFim != "") strFim = Convert.ToDateTime(strFim).ToString("dd/MM/yyyy");

                string sql = @"INSERT INTO TA_SITUACAO_HISTORICO (
                            SIHI_CRAFT_ID,
                            SIHI_SITU_ID,
                            SIHI_DATA_INICIO,
                            SIHI_DATA_FIM,
                            SIHI_CRIADO_POR
                         ) VALUES (
                            " + strMatricula + @",
                            " + strCodSituacao + @",
                            '" + strInicio + @"',
                            '" + strFim + @"',
                            '" + userLogin + @"'
                         )";

                using (OracleConnection conn = new OracleConnection(Dados.StringDeConexao))
                {
                    try
                    {
                        conn.Open();
                        OracleCommand cmd = new OracleCommand(sql, conn);
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    } 
}
