using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IDSA.Models.DataStruct
{
    public interface IFinancialData
    {
        //BaseFinData Base                   { get; set; }
        BalanceData Balance                { get; set; }
        IncomeStatmentData IncomeStatement { get; set; }
        CashFlowData CashFlow              { get; set; }
        // Potential of "Segmenty" Data
    }
    public class FinancialData : IFinancialData, IBaseFinData
    {
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

        /* 
         *  Aditional Tables 
         */
        public BalanceData Balance {get;set;}
        public IncomeStatmentData IncomeStatement { get; set; }
        public CashFlowData CashFlow {get;set;}

        public virtual Company Company { get; set; }
    }
}
