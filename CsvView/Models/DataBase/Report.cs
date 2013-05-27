using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDSA.Models
{
    public interface IReport
    {
        int Id { get; set; }
        int Year { get; set; }
        int Quarter { get; set; }
        long Sales { get; set; }  //AO //RZiS
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

    public class Report : IReport
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        //public string ColumnC { get; set; }
        [Range(1900, 2500)]
        public int Year { get; set; }
        [Range(1, 4)]
        public int Quarter { get; set; }
        public long Sales { get; set; }  //AO //RZiS
        public long OwnSaleCosts { get; set; }
        public long SalesCost1 { get; set; }
        public long SalesCost2 { get; set; }
        public long EarningOnSales { get; set; }
        public long OtherOperationalActivity1 { get; set; }
        public long OtherOperationalActivity2 { get; set; }
        public long EBIT { get; set; }
        public long FinancialActivity1 { get; set; }
        public long FinancialActivity2 { get; set; }
        public long OtherCostOrSales { get; set; }
        public long SalesOnEconomicActivity { get; set; }
        public long ExceptionalOccurence { get; set; }
        public long EarningBeforeTaxes { get; set; }
        public long DiscontinuedOperations { get; set; }
        public long NetProfit { get; set; }
        public long NetParentProfit { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
