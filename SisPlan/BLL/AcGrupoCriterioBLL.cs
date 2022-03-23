using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;
using DTO;
using DAL;

namespace BLL
{
    public class AcGrupoCriterioBLL : BaseBLL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //====================================================================
        public static int Insert(DTO.AcGrupoCriterioDTO entity, bool getIdentity)
        {
            try
            {
                return DAL.AcGrupoCriterioDAL.Insert(entity, getIdentity);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void Update(DTO.AcGrupoCriterioDTO entity)
        {
            try
            {
                AcGrupoCriterioDAL.Update(entity);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void Delete(DTO.AcGrupoCriterioDTO entity)
        {
            try
            {
                AcGrupoCriterioDAL.Delete(entity.GrcrId);
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
                return AcGrupoCriterioDAL.Count(filter);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        ////====================================================================
        //public static void ExecuteSQLInstruction(string strSQL, OracleParameter[] param)
        //{
        //    try
        //    {
        //        AcGrupoCriterioDAL.ExecuteSQLInstruction(strSQL, param);
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                AcGrupoCriterioDAL.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            try
            {
                return AcGrupoCriterioDAL.Select(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DataTable SelectSiglasGrupoCriterio()
        {
            try
            {
                return AcGrupoCriterioDAL.SelectSiglasGrupoCriterio();
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
                return AcGrupoCriterioDAL.Get(filter, sortOrder);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.AcGrupoCriterioDTO Get(AcGrupoCriterioDTO entity)
        {
            try
            {
                return DAL.AcGrupoCriterioDAL.Get(entity.GrcrId);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.AcGrupoCriterioDTO GetObject(string filter)
        {
            try
            {
                return DAL.AcGrupoCriterioDAL.GetObject(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public static List<AcGrupoCriterioDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                return DAL.AcGrupoCriterioDAL.GetList(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<AcGrupoCriterioDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<AcGrupoCriterioDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionAcGrupoCriterioDTO GetCollection()
        {
            try
            {
                return GetCollection(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionAcGrupoCriterioDTO GetCollection(string filter)
        {
            try
            {
                return GetCollection(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionAcGrupoCriterioDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return DAL.AcGrupoCriterioDAL.GetCollection(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionAcGrupoCriterioDTO GetCollection(DataTable dt)
        {
            try
            {
                return DAL.AcGrupoCriterioDAL.GetCollection(dt);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        #endregion
    }
}
