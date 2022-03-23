using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;
using DTO;
using DAL;

namespace BLL
{
    public class AcAvnGrupoCriterioBLL : BaseBLL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //====================================================================
        public static int Insert(DTO.AcAvnGrupoCriterioDTO entity, bool getIdentity)
        {
            try
            {
                return AcAvnGrupoCriterioDAL.Insert(entity, getIdentity);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void Update(DTO.AcAvnGrupoCriterioDTO entity)
        {
            try
            {
                AcAvnGrupoCriterioDAL.Update(entity);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void Delete(DTO.AcAvnGrupoCriterioDTO entity)
        {
            try
            {
                AcAvnGrupoCriterioDAL.Delete(entity.AvgcId);
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
                return AcAvnGrupoCriterioDAL.Count(filter);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        ////====================================================================
        //public static void ExecuteSQLInstruction(string strSQL, OracleParameter[] param)
        //{
        //    try
        //    {
        //        AcAvnGrupoCriterioDAL.ExecuteSQLInstruction(strSQL, param);
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                AcAvnGrupoCriterioDAL.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            try
            {
                return AcAvnGrupoCriterioDAL.Select(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DataTable SelectAvancosSemanaObraGrupoCriterio(string semanaSelected, string obra, string grupoSigla)
        {
            try
            {
                return AcAvnGrupoCriterioDAL.SelectAvancosSemanaObraGrupoCriterio(semanaSelected, obra, grupoSigla);
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
                return AcAvnGrupoCriterioDAL.Get(filter, sortOrder);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.AcAvnGrupoCriterioDTO Get(AcAvnGrupoCriterioDTO entity)
        {
            try
            {
                return DAL.AcAvnGrupoCriterioDAL.Get(entity.AvgcId);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.AcAvnGrupoCriterioDTO GetObject(string filter)
        {
            try
            {
                return DAL.AcAvnGrupoCriterioDAL.GetObject(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public static List<AcAvnGrupoCriterioDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                return DAL.AcAvnGrupoCriterioDAL.GetList(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<AcAvnGrupoCriterioDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<AcAvnGrupoCriterioDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionAcAvnGrupoCriterioDTO GetCollection()
        {
            try
            {
                return GetCollection(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionAcAvnGrupoCriterioDTO GetCollection(string filter)
        {
            try
            {
                return GetCollection(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionAcAvnGrupoCriterioDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return DAL.AcAvnGrupoCriterioDAL.GetCollection(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionAcAvnGrupoCriterioDTO GetCollection(DataTable dt)
        {
            try
            {
                return DAL.AcAvnGrupoCriterioDAL.GetCollection(dt);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        #endregion
    }
}
