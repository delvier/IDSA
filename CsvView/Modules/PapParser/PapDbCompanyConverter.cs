using IDSA.Models.Repository;
using IDSA.Modules.CachedListContainer;
using Microsoft.Practices.ServiceLocation;
using NLog;
using System.Linq;

namespace IDSA.Modules.PapParser
{
    /// <summary>
    /// ... OBSOLETE CLASS ...
    /// </summary>
    public class PapDbCompanyConverter
    {
        private readonly ICacheService cache;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public PapDbCompanyConverter()
        {
            cache = ServiceLocator.Current.GetInstance<ICacheService>();
        }
        
        private void DbChangeName(string nameBefore, string nameAfter)
        {
            var uow = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            var cmp = cache.GetAll().FirstOrDefault(c => c.FullName.ToUpper() == nameBefore.ToUpper());
            cmp.FullName = nameAfter;
            uow.Companies.Update(cmp);
            uow.Commit();
        }

        private void AddCompanyDb(string name)
        {
            var uow = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            Models.Company cmp = new Models.Company();
            cmp.FullName = name;
            uow.Companies.Add(cmp);
            uow.Commit();
        }
    }
}
