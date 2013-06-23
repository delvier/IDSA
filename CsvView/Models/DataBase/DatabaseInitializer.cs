using System.Data.Entity;

namespace IDSA.Models
{
    public class ContextDatabaseInitializer : IDatabaseInitializer<Context>
    {
        public void InitializeDatabase(Context context)
        {
            if (context.Database.Exists())
            {
                //if (!context.Database.CompatibleWithModel(true))
                //{
                    context.Database.Delete();
                    context.Database.Create();
                //}
            }
            else
                context.Database.Create();
            //Seed(context);
        }

        protected void Seed(Context context)
        {
            
        }
    }
}
