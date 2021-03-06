using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;
using DTO;
using DAL;

namespace BLL
{
    public class VwAcGrupoCriterioMedicaoBLL : BaseBLL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        
        //====================================================================
        public static int Count(string filter)
        {
            try
            {
                return VwAcGrupoCriterioMedicaoDAL.Count(filter);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                VwAcGrupoCriterioMedicaoDAL.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            try
            {
                return VwAcGrupoCriterioMedicaoDAL.Select(strSQL);
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
                return VwAcGrupoCriterioMedicaoDAL.Get(filter, sortOrder);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        ////====================================================================
        //public static DTO.VwAcGrupoCriterioMedicaoDTO Get(string filter, string sortSequence)
        //{
        //    try
        //    {
        //        return VwAcGrupoCriterioMedicaoDAL.Get(filter, sortSequence);
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}
        //====================================================================
        public static DTO.VwAcGrupoCriterioMedicaoDTO GetObject(string filter)
        {
            try
            {
                return DAL.VwAcGrupoCriterioMedicaoDAL.GetObject(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public static List<VwAcGrupoCriterioMedicaoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                return DAL.VwAcGrupoCriterioMedicaoDAL.GetList(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<VwAcGrupoCriterioMedicaoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<VwAcGrupoCriterioMedicaoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionVwAcGrupoCriterioMedicaoDTO GetCollection()
        {
            try
            {
                return GetCollection(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionVwAcGrupoCriterioMedicaoDTO GetCollection(string filter)
        {
            try
            {
                return GetCollection(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionVwAcGrupoCriterioMedicaoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return DAL.VwAcGrupoCriterioMedicaoDAL.GetCollection(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionVwAcGrupoCriterioMedicaoDTO GetCollection(DataTable dt)
        {
            try
            {
                return DAL.VwAcGrupoCriterioMedicaoDAL.GetCollection(dt);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        #endregion
    }
}
