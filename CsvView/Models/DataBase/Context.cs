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
        //TODO: Add new tables to DB

        //Add new functionalities, another way of migrations
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            
            //modelBuilder.Entity<Report>().Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //modelBuilder.Entity<Report>().Property(a => a.Id).HasKey(b => b.Id);

            //modelBuilder.Entity<Company>().Property(x => x.Reports = new ObservableListSource<String>());
        }
    }
}
