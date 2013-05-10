using System.Data.Entity;

namespace DBModule
{
    public class Context : DbContext
    {
        public Context()
            : base("CompanyContext")
        {
            Database.SetInitializer(new ContextDatabaseInitializer());      //my own DatabaseInitializer
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Report> Reports { get; set; }
        //TODO: Add new tables to DB

        //Add new functionalities, another way of migrations
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Company>().Property(x => x.Reports = new ObservableListSource<String>());
        }
    }
}
