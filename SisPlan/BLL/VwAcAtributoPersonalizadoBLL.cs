using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;
using DTO;
using DAL;

namespace BLL
{
    public class VwAcAtributoPersonalizadoBLL : BaseBLL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
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
                return VwAcAtributoPersonalizadoDAL.Count(filter);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                VwAcAtributoPersonalizadoDAL.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                VwAcAtributoPersonalizadoDAL.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            try
            {
                return VwAcAtributoPersonalizadoDAL.Select(strSQL);
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
                return VwAcAtributoPersonalizadoDAL.Get(filter, sortOrder);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.VwAcAtributoPersonalizadoDTO Get(VwAcAtributoPersonalizadoDTO entity)
        {
            try
            {
                return DAL.VwAcAtributoPersonalizadoDAL.Get(entity.ID);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.VwAcAtributoPersonalizadoDTO GetObject(string filter)
        {
            try
            {
                return DAL.VwAcAtributoPersonalizadoDAL.GetObject(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public static List<VwAcAtributoPersonalizadoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                return DAL.VwAcAtributoPersonalizadoDAL.GetList(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<VwAcAtributoPersonalizadoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<VwAcAtributoPersonalizadoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionVwAcAtributoPersonalizadoDTO GetCollection()
        {
            try
            {
                return GetCollection(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionVwAcAtributoPersonalizadoDTO GetCollection(string filter)
        {
            try
            {
                return GetCollection(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionVwAcAtributoPersonalizadoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return DAL.VwAcAtributoPersonalizadoDAL.GetCollection(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionVwAcAtributoPersonalizadoDTO GetCollection(DataTable dt)
        {
            try
            {
                return DAL.VwAcAtributoPersonalizadoDAL.GetCollection(dt);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        #endregion
    }
}
