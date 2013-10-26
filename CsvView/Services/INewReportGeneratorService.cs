using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models.DataStruct;
using IDSA.Models;
using IDSA.Modules.CachedListContainer;
using Microsoft.Practices.ServiceLocation;
using IDSA.Services;

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
        private readonly IMessageBoxService _messageBox;

        public NewReportGeneratorService()
        {
            _cache = ServiceLocator.Current.GetInstance<ICacheService>();
            _messageBox = ServiceLocator.Current.GetInstance<IMessageBoxService>();
        }

        public FinancialData GetNewTemplateReport(Company cmp)
        {
            var templateFinData = new FinancialData() {
                    Id = _cache.GetAllReports().Last().Id++, // this cannot be changed latter on...
                    CompanyId = cmp.Id,        
                };
            
            try
            {
                templateFinData.Quarter = GetNextQuarter(cmp.Reports.Last().Quarter);
            }
            catch (Exception)
            {
                _messageBox.ErrorNotify("No reports in the db for the" + cmp.Name);
            }
            
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
