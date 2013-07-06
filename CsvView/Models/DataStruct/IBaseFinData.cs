using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
            Id,         //1
            CmpId,      //2
            ColumnC,    //3
            Year,       //4
            Quater,     //5
            FinancialStatmentDate = 73,        //74  Sytuacja finansowa na dzień.
            FinancialReportReleaseDate,        //75  Raport wydany dnia. (KEY FOR SORT!)
            ColumnBX                           //76  N/A
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Range(1900, 2222)]
        public int Year { get; set; }
        [Range(1, 4)]
        public int Quarter { get; set; }
        [Required]
        public int CompanyId { get; set; }

        public DateTime FinancialStatmentDate { get; set; }
        public DateTime FinancialReportReleaseDate { get; set; }
    }
}
