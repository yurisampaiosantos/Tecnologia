using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;
using DTO;
using DAL;

namespace BLL
{
    public class ProjOutRcptBLL : BaseBLL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //====================================================================
        public static int Insert(DTO.ProjOutRcptDTO entity, bool getIdentity)
        {
            try
            {
                return ProjOutRcptDAL.Insert(entity, getIdentity);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void Update(DTO.ProjOutRcptDTO entity)
        {
            try
            {
                ProjOutRcptDAL.Update(entity);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void Delete(DTO.ProjOutRcptDTO entity)
        {
            try
            {
                ProjOutRcptDAL.Delete(entity.ID);
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
                return ProjOutRcptDAL.Count(filter);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        ////====================================================================
        //public static void ExecuteSQLInstruction(string strSQL, OracleParameter[] param)
        //{
        //    try
        //    {
        //        ProjOutRcptDAL.ExecuteSQLInstruction(strSQL, param);
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                ProjOutRcptDAL.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            try
            {
                return ProjOutRcptDAL.Select(strSQL);
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
                return ProjOutRcptDAL.Get(filter, sortOrder);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.ProjOutRcptDTO Get(ProjOutRcptDTO entity)
        {
            try
            {
                return DAL.ProjOutRcptDAL.Get(entity.ID);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.ProjOutRcptDTO GetObject(string filter)
        {
            try
            {
                return DAL.ProjOutRcptDAL.GetObject(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public static List<ProjOutRcptDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                return DAL.ProjOutRcptDAL.GetList(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<ProjOutRcptDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<ProjOutRcptDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionProjOutRcptDTO GetCollection()
        {
            try
            {
                return GetCollection(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionProjOutRcptDTO GetCollection(string filter)
        {
            try
            {
                return GetCollection(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionProjOutRcptDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return DAL.ProjOutRcptDAL.GetCollection(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionProjOutRcptDTO GetCollection(DataTable dt)
        {
            try
            {
                return DAL.ProjOutRcptDAL.GetCollection(dt);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        #endregion
    }
}
