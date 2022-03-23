using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;
using DTO;
using DAL;

namespace BLL
{
    public class AcPendenciaMaterialBLL : BaseBLL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //====================================================================
        public static int Insert(DTO.AcPendenciaMaterialDTO entity, bool getIdentity)
        {
            try
            {
                return AcPendenciaMaterialDAL.Insert(entity, getIdentity);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        ////====================================================================
        //public static void Update(DTO.AcPendenciaMaterialDTO entity)
        //{
        //    try
        //    {
        //        AcPendenciaMaterialDAL.Update(entity);
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}
        //====================================================================
        public static void Delete(DTO.AcPendenciaMaterialDTO entity)
        {
            try
            {
                AcPendenciaMaterialDAL.Delete(entity.ID);
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
                return AcPendenciaMaterialDAL.Count(filter);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                AcPendenciaMaterialDAL.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                AcPendenciaMaterialDAL.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            try
            {
                return AcPendenciaMaterialDAL.Select(strSQL);
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
                return AcPendenciaMaterialDAL.Get(filter, sortOrder);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.AcPendenciaMaterialDTO Get(AcPendenciaMaterialDTO entity)
        {
            try
            {
                return DAL.AcPendenciaMaterialDAL.Get(entity.ID);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.AcPendenciaMaterialDTO GetObject(string filter)
        {
            try
            {
                return DAL.AcPendenciaMaterialDAL.GetObject(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public static List<AcPendenciaMaterialDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                return DAL.AcPendenciaMaterialDAL.GetList(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<AcPendenciaMaterialDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<AcPendenciaMaterialDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionAcPendenciaMaterialDTO GetCollection()
        {
            try
            {
                return GetCollection(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionAcPendenciaMaterialDTO GetCollection(string filter)
        {
            try
            {
                return GetCollection(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionAcPendenciaMaterialDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return DAL.AcPendenciaMaterialDAL.GetCollection(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionAcPendenciaMaterialDTO GetCollection(DataTable dt)
        {
            try
            {
                return DAL.AcPendenciaMaterialDAL.GetCollection(dt);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        #endregion
    }
}
