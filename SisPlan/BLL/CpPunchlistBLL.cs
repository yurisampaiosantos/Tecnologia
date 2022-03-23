using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;
using DTO;
using DAL;

namespace BLL
{
    public class CpPunchlistBLL : BaseBLL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //====================================================================
        public static int Insert(DTO.CpPunchlistDTO entity, bool getIdentity)
        {
            try
            {
                return CpPunchlistDAL.Insert(entity, getIdentity);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void Update(DTO.CpPunchlistDTO entity)
        {
            try
            {
                CpPunchlistDAL.Update(entity);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void Delete(DTO.CpPunchlistDTO entity)
        {
            try
            {
                CpPunchlistDAL.Delete(entity.PunchId);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            try
            {
                return CpPunchlistDAL.Count(filter);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                CpPunchlistDAL.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                CpPunchlistDAL.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            try
            {
                return CpPunchlistDAL.Select(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DataTable Get()
        {
            try
            {
                return Get(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DataTable Get(string filter)
        {
            try
            {
                return Get(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DataTable Get(string filter, string sortOrder)
        {
            try
            {
                return CpPunchlistDAL.Get(filter, sortOrder);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CpPunchlistDTO Get(CpPunchlistDTO entity)
        {
            try
            {
                return DAL.CpPunchlistDAL.Get(entity.PunchId);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CpPunchlistDTO GetObject(string filter)
        {
            try
            {
                return DAL.CpPunchlistDAL.GetObject(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public static List<CpPunchlistDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                return DAL.CpPunchlistDAL.GetList(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<CpPunchlistDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<CpPunchlistDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionCpPunchlistDTO GetCollection()
        {
            try
            {
                return GetCollection(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionCpPunchlistDTO GetCollection(string filter)
        {
            try
            {
                return GetCollection(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionCpPunchlistDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return DAL.CpPunchlistDAL.GetCollection(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionCpPunchlistDTO GetCollection(DataTable dt)
        {
            try
            {
                return DAL.CpPunchlistDAL.GetCollection(dt);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        #endregion
    }
}
