using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;
using DTO;
using DAL;

namespace BLL
{
    public class ProjGenEmailBLL : BaseBLL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //====================================================================
        public static int Insert(DTO.ProjGenEmailDTO entity, bool getIdentity)
        {
            try
            {
                return ProjGenEmailDAL.Insert(entity, getIdentity);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void Update(DTO.ProjGenEmailDTO entity)
        {
            try
            {
                ProjGenEmailDAL.Update(entity);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void Delete(DTO.ProjGenEmailDTO entity)
        {
            try
            {
                ProjGenEmailDAL.Delete(entity.ID);
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
                return ProjGenEmailDAL.Count(filter);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        //public static void ExecuteSQLInstruction(string strSQL, OracleParameter[] param)
        //{
        //    try
        //    {
        //        ProjGenEmailDAL.ExecuteSQLInstruction(strSQL, param);
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                ProjGenEmailDAL.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            try
            {
                return ProjGenEmailDAL.Select(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DataTable GetEmailByTipoDestinatario(string tipoDestinatario)
        {
            try
            {
                return ProjGenEmailDAL.GetEmailByTipoDestinatario(tipoDestinatario);
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
                return ProjGenEmailDAL.Get(filter, sortOrder);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.ProjGenEmailDTO Get(ProjGenEmailDTO entity)
        {
            try
            {
                return DAL.ProjGenEmailDAL.Get(entity.ID);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.ProjGenEmailDTO GetObject(string filter)
        {
            try
            {
                return DAL.ProjGenEmailDAL.GetObject(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public static List<ProjGenEmailDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                return DAL.ProjGenEmailDAL.GetList(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<ProjGenEmailDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<ProjGenEmailDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionProjGenEmailDTO GetCollection()
        {
            try
            {
                return GetCollection(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionProjGenEmailDTO GetCollection(string filter)
        {
            try
            {
                return GetCollection(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionProjGenEmailDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return DAL.ProjGenEmailDAL.GetCollection(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionProjGenEmailDTO GetCollection(DataTable dt)
        {
            try
            {
                return DAL.ProjGenEmailDAL.GetCollection(dt);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        #endregion
    }
}
