using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models.DataStruct;
using IDSA.Models;
using IDSA.Modules.CachedListContainer;
using Microsoft.Practices.ServiceLocation;

namespace IDSA.Presenters.BasicViewsPresenters
{
    public interface INewReportGeneratorService
    {
        FinancialData GetNewTemplateReport(Company cmp);
    }

    /*
     * Generate new template report for the company.
     * Id,
     * Correleation to CompanyId,
     * Quarter/Year based on historical data.
     * Every field be in Thousands values so 1000 input every where.
     */
    public class NewReportGeneratorService : INewReportGeneratorService
    {
        private readonly ICacheService _cache;

        public NewReportGeneratorService()
        {
            _cache = ServiceLocator.Current.GetInstance<ICacheService>();
        }

        public FinancialData GetNewTemplateReport(Company cmp)
        {
            var templateFinData = new FinancialData();
            templateFinData.CompanyId = cmp.Id;
            templateFinData.Quarter = GetNextQuarter(cmp.Reports.Last().Quarter);
            
            // templateFinData.Id = _cache.GetAllInBindingList
            // should take max id from the reports scope.

            return templateFinData;
        }

        private int GetNextQuarter(int last)
        {
            if (last == 4)
            {
                return 1;
            }
            else
            {
                return last + 1;
            }
        }

    }
}
