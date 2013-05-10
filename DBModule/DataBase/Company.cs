using System.ComponentModel.DataAnnotations;

namespace DBModule
{
    public interface ICompany
    {
        string Symbol { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Url { get; set; }
        TRADES Trade { get; set; }
    }

    public class Company : ICompany
    {
        public Company()
        {
            this.Reports = new ObservableListSource<Report>();
        }

        [Key]
        [MaxLength(3)]
        public string Symbol { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public string Url { get; set; }
        public TRADES Trade { get; set; }

        public virtual ObservableListSource<Report> Reports { get; set; }
    }

    public enum TRADES
    {
        CUKIERNICTWO,
        HANDEL,
        BUDOWNICTWO,
        INFORMATYKA,
        TELEKOMUNIKACJA
    }
}
