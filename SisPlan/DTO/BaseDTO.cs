using System;
using System.Collections.Generic;
//====================================================================
namespace DTO
{
    //====================================================================
    public class BaseDTO
    {
        //====================================================================
        protected string TruncateValue(string strValue, int v)
        {
            if (strValue != null)
            {
                if (strValue.Length > v) { strValue = strValue.Substring(0, v); }
            }
            return strValue;
        }
        //====================================================================
    }
}
