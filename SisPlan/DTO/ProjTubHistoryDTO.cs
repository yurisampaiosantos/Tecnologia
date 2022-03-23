using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionProjTubHistoriesDTO : List<ProjTubHistoryDTO> { }
    //====================================================================
    public class ProjTubHistoryDTO : BaseDTO
    {
        private decimal id;
        private DateTime processHistoryDate;
        private string fileName;
        private string processHistory;
        private string status;
        //====================================================================
        public enum attributeName { ID, PROCESS_HISTORY_DATE, FILE_NAME, PROCESS_HISTORY, STATUS };
        public enum propertyName { ID, ProcessHistoryDate, FileName, ProcessHistory, Status };
        //====================================================================
        private static int length = 5;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public DateTime ProcessHistoryDate { get { return processHistoryDate; } set { processHistoryDate = value; } }
        public string FileName { get { return fileName; } set { fileName = TruncateValue(value, 500); } }
        public string ProcessHistory { get { return processHistory; } set { processHistory = TruncateValue(value, 4000); } }
        public string Status { get { return status; } set { status = TruncateValue(value, 20); } }
    }
}