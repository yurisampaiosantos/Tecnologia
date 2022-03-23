using System;
using System.Net;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;
using DTO;
using DAL;

using OfficeOpenXml;

namespace BLL
{
    public class RfNfEntradaBLL : BaseBLL
    {
        public static string strScript { set; get; }
        public static string strAmbiente { set; get; }
        public static string strDataFiltro { set; get; }

        public static string Ip()
        {
            IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName());

            return ip[1].ToString();
        }

        public static DataTable CarregaProdutos(bool booDe, string strDe, bool booAte, string strAte, string strSubContrato, string intSubContrato, string strDisciplina, string intDisciplina)
        {
            string SQL = @"SELECT
                                *
                            FROM 
                                V_OP opre
                            WHERE
                                    opre.DIPR_ID IS NULL
                                AND opre.DATA_FILTRO BETWEEN TO_DATE('" + ((booDe == false) ? "01/01/1800" : strDe) + @"', 'DD/MM/YY') AND TO_DATE('" + ((booAte == false) ? "31/12/2099" : strAte) + @"', 'DD/MM/YY')
                                " + ((strSubContrato != "(Todos)") ? "AND FOSE_SBCN_ID = " + intSubContrato : "") + @"
                                " + ((strDisciplina != "(Todas)") ? "AND DISC_ID = " + intDisciplina : "");

            DataTable dtConsulta = new DataTable();
            dtConsulta = Select(SQL);

            return dtConsulta;
        }

        public static DataTable ToDataTable(ExcelPackage package)
        {
            ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
            DataTable table = new DataTable();
            foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
            {
                table.Columns.Add(firstRowCell.Text);
            }

            for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
            {
                var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                var newRow = table.NewRow();
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }
                table.Rows.Add(newRow);
            }
            return table;
        }

        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //====================================================================
        public static int Insert(DTO.RfNfEntradaDTO entity, bool getIdentity)
        {
            try
            {
                return RfNfEntradaDAL.Insert(entity, getIdentity);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public static string Left(string str, int length)
        {
            return str.Substring(0, Math.Min(length, str.Length));
        }

        //====================================================================
        public static void Update(DTO.RfNfEntradaDTO entity)
        {
            try
            {
                RfNfEntradaDAL.Update(entity);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void Delete(DTO.RfNfEntradaDTO entity)
        {
            try
            {
                RfNfEntradaDAL.Delete(entity.ID);
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
                return RfNfEntradaDAL.Count(filter);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                RfNfEntradaDAL.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            try
            {
                return RfNfEntradaDAL.Select(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static void AtualizaSchedule(string strID, string strStatus)
        {
            try
            {
                RfNfEntradaDAL.AtualizaSchedule(strID, strStatus);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public static void SalvaChaves(string strChaves)
        {
            try
            {
                RfNfEntradaDAL.SalvaChaves(strChaves);
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
                return RfNfEntradaDAL.Get(filter, sortOrder);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.RfNfEntradaDTO Get(RfNfEntradaDTO entity)
        {
            try
            {
                return DAL.RfNfEntradaDAL.Get(entity.ID);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.RfNfEntradaDTO GetObject(string filter)
        {
            try
            {
                return DAL.RfNfEntradaDAL.GetObject(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public static List<RfNfEntradaDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                return DAL.RfNfEntradaDAL.GetList(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<RfNfEntradaDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static List<RfNfEntradaDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionRfNfEntradaDTO GetCollection()
        {
            try
            {
                return GetCollection(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionRfNfEntradaDTO GetCollection(string filter)
        {
            try
            {
                return GetCollection(filter, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionRfNfEntradaDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return DAL.RfNfEntradaDAL.GetCollection(filter, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        public static DTO.CollectionRfNfEntradaDTO GetCollection(DataTable dt)
        {
            try
            {
                return DAL.RfNfEntradaDAL.GetCollection(dt);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //====================================================================
        #endregion
    }
}
