using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;
using DTO;
using DAL;

namespace BLL
{
    public class IntLocaisBLL : BaseBLL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //====================================================================
        public static int Insert(DTO.IntLocaisDTO entity, bool getIdentity)
        {
            try
            {
                return IntLocaisDAL.Insert(entity, getIdentity);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void Update(DTO.IntLocaisDTO entity)
        {
            try
            {
                IntLocaisDAL.Update(entity);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void Delete(DTO.IntLocaisDTO entity)
        {
            try
            {
                IntLocaisDAL.Delete(entity.InloId);
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
                return IntLocaisDAL.Count(filter);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                IntLocaisDAL.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                IntLocaisDAL.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            try
            {
                return IntLocaisDAL.Select(strSQL);
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
                return IntLocaisDAL.Get(filter, sortOrder);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.IntLocaisDTO Get(IntLocaisDTO entity)
        {
            try
            {
                return DAL.IntLocaisDAL.Get(entity.InloId);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.IntLocaisDTO GetObject(string filter)
        {
            try
            {
                return DAL.IntLocaisDAL.GetObject(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public static List<IntLocaisDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                return DAL.IntLocaisDAL.GetList(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<IntLocaisDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<IntLocaisDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionIntLocaisDTO GetCollection()
        {
            try
            {
                return GetCollection(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionIntLocaisDTO GetCollection(string filter)
        {
            try
            {
                return GetCollection(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionIntLocaisDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return DAL.IntLocaisDAL.GetCollection(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionIntLocaisDTO GetCollection(DataTable dt)
        {
            try
            {
                return DAL.IntLocaisDAL.GetCollection(dt);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        #endregion
    }
}
