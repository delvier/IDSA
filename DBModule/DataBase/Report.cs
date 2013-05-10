using System.ComponentModel.DataAnnotations;

namespace DBModule
{
    public interface IReport
    {
        int ID { get; set; }
        int Year { get; set; }
        int SalesRevenues { get; set; }
        int NetProfit { get; set; }
    }

    public class Report : IReport
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [EnumDataType(typeof(PERIOD))]
        public PERIOD Period { get; set; }

        public int SalesRevenues { get; set; }

        public int NetProfit { get; set; }

        [Required]
        public string CompanySymbol { get; set; }

        public virtual Company Company { get; set; }
    }

    public enum PERIOD
    {
        //TODO: Maybe change is needed?
        //YEARLY,
        //SEMIANNUAL1,
        //SEMIANNUAL2,
        Q1 = 1,
        Q2 = 2,
        Q3 = 3,
        Q4 = 4
    }
}
