using IDSA.Models.DataStruct;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace IDSA.Models
{
    public class Context : DbContext
    {
        public Context(IDatabaseInitializer<Context> context)
            : base("CompanyContext")
        {
            Database.SetInitializer(context);      //my own DatabaseInitializer
        }

        public Context() : base("CompanyContext") { }

        public DbSet<Company> Companies { get; set; }
        //public DbSet<Report> Reports { get; set; }
        public DbSet<FinancialData> FinData { get; set; }

    }
}
