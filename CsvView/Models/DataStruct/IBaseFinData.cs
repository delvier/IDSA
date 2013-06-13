using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Models.DataStruct
{
    interface IBaseFinData
    {
        int Id { get; set; }
        int Year { get; set; }
        int Quarter { get; set; }
        int CompanyId { get; set; }
        DateTime FinancialStatmentDate { get; set; }
        DateTime FinancialReportReleaseDate { get; set; }
            
    }
    public class BaseFinData : IBaseFinData
    {
        public enum BaseFinDataKey
        {
            Id = 1,         //1
            CmpId,      //2
            ColumnC,    //3
            Year,       //4
            Quater,     //5
            ColumnBV = 74,   //74  Sytuacja finansowa na dzień.
            ColumnBW,        //75  Raport wydany dnia. (KEY FOR SORT!)
            ColumnBX         //76  N/A
        }

        public int Id { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
        public int CompanyId { get; set; }
        public DateTime FinancialStatmentDate {get;set;}
        public DateTime FinancialReportReleaseDate { get; set; }
    }
}
