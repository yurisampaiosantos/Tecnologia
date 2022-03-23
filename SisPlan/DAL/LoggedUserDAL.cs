using System;
using System.Collections.Generic;

using System.Data;
using System.Data.OleDb;
using Oracle.DataAccess.Client;
using System.Collections;

using DTO;

//====================================================================
//====================================================================

namespace DAL
{
    public class LoggedUserDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.DESCRIPTION FROM SURVEY_HEADSET_MODELS X ";
        //====================================================================

        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM SURVEY_HEADSET_MODELS";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting SurveyHeadsetModels"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction SurveyHeadsetModels"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction SurveyHeadsetModels"); }
        }
        //====================================================================
        public static DTO.LoggedUserDTO GetLoggedUser()
        {
            LoggedUserDTO entity = new LoggedUserDTO();
            entity.UserId = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //entity.UserId = username.Replace("\\", "|").Split('|')[1];
            return entity;
        }
        //====================================================================
        #endregion
    }
}

