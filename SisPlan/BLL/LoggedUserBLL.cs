using System;
using System.Collections.Generic;

using System.Data;

using System.Collections;
using DTO;
using DAL;

using Oracle.DataAccess.Client;

namespace BLL
{
    public class LoggedUserBLL : BaseBLL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //====================================================================
        public static int Count(string filter)
        {
            try
            {
                return LoggedUserDAL.Count(filter);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleParameter[] param)
        {
            try
            {
                //LoggedUserDAL.ExecuteSQLInstruction(strSQL, param);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                LoggedUserDAL.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        ////====================================================================
        //public static DataTable Select(string strSQL)
        //{
        //    try
        //    {
        //        return LoggedUserDAL.Select(strSQL);
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}
        //====================================================================
        //public static DataTable Get(string filter)
        //{
        //    try
        //    {
        //        return Get(filter, null);
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}
        ////====================================================================
        //public static DataTable Get(string filter, string sortOrder)
        //{
        //    try
        //    {
        //        return LoggedUserDAL.Get(filter, sortOrder);
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}
        //====================================================================
        #endregion
    }
}
