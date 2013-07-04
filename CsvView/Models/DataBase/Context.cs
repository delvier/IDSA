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
        public DbSet<Report> Reports { get; set; }
        public DbSet<FinancialData> FinData { get; set; }
        //TODO: Add new tables to DB
        
        //Add new functionalities, another way of migrations
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.ComplexType<IBaseFinData>();

        //    modelBuilder.Entity<Report>()
        //        .Map(m =>
        //        {
        //            m.Properties(t => new { t.ReportId, t.Year, t.Quarter });
        //            m.ToTable("BaseData");
        //        })
        //        .Map(m =>
        //        {
        //            m.Properties(t => new
        //            {
        //                t.Sales,
        //                t.OwnSaleCosts,
        //                t.SalesCost1,
        //                t.SalesCost2,
        //                t.EarningOnSales,
        //                t.OtherOperationalActivity1,
        //                t.OtherOperationalActivity2,
        //                t.EBIT,
        //                t.FinancialActivity1,
        //                t.FinancialActivity2,
        //                t.OtherCostOrSales,
        //                t.SalesOnEconomicActivity,
        //                t.ExceptionalOccurence,
        //                t.EarningBeforeTaxes,
        //                t.DiscontinuedOperations,
        //                t.NetProfit,
        //                t.NetParentProfit
        //            });
        //            m.ToTable("StatementData"); //RziS.
        //        })
        //        .Map(m =>
        //        {
        //            m.Properties(t => new
        //            {
                        
        //            });
        //            m.ToTable("IncomeData");
        //        });

        //    //modelBuilder.Entity<Report>().Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        //    //modelBuilder.Entity<Company>().Property(x => x.Reports = new ObservableListSource<String>());
        //}
    }
}
