using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionProjTubLogDTO : List<ProjTubLogDTO> { }
    //====================================================================
    public class ProjTubLogDTO : BaseDTO
    {
        private decimal id;
        private string fileName;
        private decimal statusId;
        private string processLog;
        private string createdBy;
        private DateTime createdDate;
        private string modifiedBy;
        private DateTime modifiedDate;
        //====================================================================
        public enum attributeName { ID, FILE_NAME, PROCESS_STATUS, PROCESS_LOG, CREATED_BY, CREATED_DATE, MODIFIED_BY, MODIFIED_DATE };
        public enum propertyName { ID, FileName, ProcessStatus, ProcessLog, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate };
        //====================================================================
        private static int length = 8;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string FileName { get { return fileName; } set { fileName = TruncateValue(value, 500); } }
        public decimal StatusId { get { return statusId; } set { statusId = value; } }
        public string ProcessLog { get { return processLog; } set { processLog = TruncateValue(value, 4000); } }
        public string CreatedBy { get { return createdBy; } set { createdBy = TruncateValue(value, 60); } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }
        public string ModifiedBy { get { return modifiedBy; } set { modifiedBy = TruncateValue(value, 60); } }
        public DateTime ModifiedDate { get { return modifiedDate; } set { modifiedDate = value; } }
    }
}
