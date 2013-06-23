using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace IDSA.Models
{
    public interface IReport
    {
        int ReportId { get; set; }
        int Year { get; set; }
        int Quarter { get; set; }
        long Sales { get; set; }    //AO //RZiS
        long OwnSaleCosts { get; set; }
        long SalesCost1 { get; set; }
        long SalesCost2 { get; set; }
        long EarningOnSales { get; set; }
        long OtherOperationalActivity1 { get; set; }
        long OtherOperationalActivity2 { get; set; }
        long EBIT { get; set; }
        long FinancialActivity1 { get; set; }
        long FinancialActivity2 { get; set; }
        long OtherCostOrSales { get; set; }
        long SalesOnEconomicActivity { get; set; }
        long ExceptionalOccurence { get; set; }
        long EarningBeforeTaxes { get; set; }
        long DiscontinuedOperations { get; set; }
        long NetProfit { get; set; }
        long NetParentProfit { get; set; }
    }

    public class Report : IReport, ICloneable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReportId { get; set; }
        public string ColumnC { get; set; }
        [Range(1900, 2500)]
        public int Year { get; set; }
        [Range(1, 4)]
        public int Quarter { get; set; }
        public long Sales { get; set; }                     //AO //RZiS //IncomeStatement
        public long OwnSaleCosts { get; set; }              //RZiS      //IncomeStatement
        public long SalesCost1 { get; set; }                            //IncomeStatement
        public long SalesCost2 { get; set; }                            //IncomeStatement
        public long EarningOnSales { get; set; }            //RZiS      //IncomeStatement
        public long OtherOperationalActivity1 { get; set; }             //IncomeStatement
        public long OtherOperationalActivity2 { get; set; }             //IncomeStatement
        public long EBIT { get; set; }                      //RZiS      //IncomeStatement
        public long FinancialActivity1 { get; set; }                    //IncomeStatement
        public long FinancialActivity2 { get; set; }                    //IncomeStatement
        public long OtherCostOrSales { get; set; }                      //IncomeStatement
        public long SalesOnEconomicActivity { get; set; }               //IncomeStatement
        public long ExceptionalOccurence { get; set; }                  //IncomeStatement
        public long EarningBeforeTaxes { get; set; }        //RZiS      //IncomeStatement
        public long DiscontinuedOperations { get; set; }                //IncomeStatement
        public long NetProfit { get; set; }                 //RZiS      //IncomeStatement
        public long NetParentProfit { get; set; }                       //IncomeStatement

        [Required]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public Report Clone()
        {
            return (Report)this.MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}
