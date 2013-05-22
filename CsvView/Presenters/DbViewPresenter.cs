using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DBModule;

namespace IDSA.Presenters
{
    public class DbViewPresenter
    {
        private IDbView view;
        private IUnitOfWork model;

        public DbViewPresenter(IDbView view)
        {
            this.view = view;
        }

        public void OnLoad()
        {
            Task.WaitAll();
            model = ServiceLocator.Instance.Resolve<EFUnitOfWork>();

            //TODO: Change in the future in this place !!!!!!!!!!!!
            if (!model.Companies.Query().Any())
                AddRecords();
        }

        public BindingList<Company> GetAllCompanies()
        {
            return model.Companies.GetAll();
        }
        
        public void AddCompany(Company company)
        {
            model.Companies.Add(company);
            model.Commit();
        }

        public void Dispose()
        {
            model.Dispose();
        }

        #region Testing methods(TODO: delete on the end)

        public void AddRecords()
        {
            var company = new Company
            {
                Name = "Wawel",
                Shortcut = "WWL",
                Href = "http://www.wawel.com.pl/",
                Description = ""
            };

            model.Companies.Add(company);
            model.Commit();

            var report = new Report
            {
                //CompanyId = "WWL",
                Year = 2011,
                NetProfit = 1000
            };
            var report2 = new Report
            {
                CompanyId = model.Companies.Query().SingleOrDefault(x => x.Shortcut == "WWL").Id,
                Year = 2012,
                NetProfit = 3010
            };

            model.Reports.Add(report);
            model.Reports.Add(report2);
            model.Commit();
        }

        public void AddsNewCompany()
        {
            var company = new Company
            {
                Shortcut = "WMO",
                Name = "Wind Mobile",
                Description = "Halogranie i Reklamowka",
                Href = "http://www.windmobile.pl"
            };
            model.Companies.Add(company);
            model.Commit();

            var report = new Report
            {
                //CompanyId = "WMO",
                Year = 2011,
                NetProfit = 1000,
                Quarter = 3
            };
            model.Reports.Add(report);
            model.Commit();
        }
        
        public void AddReport()
        {
            //foreach (var item in uow.Reports.Query().ToList())
            //{
            //    if (item.Year != 2012)
            //    {
            //        uow.Reports.Remove(item);
            //    }
            //}
            //uow.Commit();

            //delete relationship
            //db.Entry(report).Reference(r => r.CompanySymbol).CurrentValue = null;
        }

        #endregion
    }
}
