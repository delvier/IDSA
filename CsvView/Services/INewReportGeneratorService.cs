using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models.DataStruct;
using IDSA.Models;
using IDSA.Modules.CachedListContainer;
using Microsoft.Practices.ServiceLocation;
using IDSA.Services;
using System.Reflection;
using IDSA.Modules.DataScanner;

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
                    Balance = new BalanceData(),
                    CashFlow = new CashFlowData(),
                    IncomeStatement = new IncomeStatmentData()
                };

            FillFinancialDataWithValues(templateFinData, 1000); // all numbers are in thousands.

            try
            {
                templateFinData.Quarter = GetNextQuarter(cmp.Reports.First().Quarter);
                templateFinData.Year = GetNextYear(cmp.Reports.First());  
            }
            catch (Exception ex)
            {
                templateFinData.Quarter = 1;
                templateFinData.Year = System.DateTime.Now.Year;
                _messageBox.ErrorNotify("No report in the db : " + cmp.Name);
            }
            
            return templateFinData;
        }

        private void FillFinancialDataWithValues(FinancialData inputData, int fillValue)
        {
            var nestedDataClassProperties = inputData.GetType().GetProperties()
                                                               .Where(p => p.PropertyType.IsClass && 
                                                                           p.PropertyType.Name != "Company");
            
            // browse through Balance/CashFlow/IncomeStatment neested class.
            foreach (PropertyInfo internalClassObject in nestedDataClassProperties) 
            {
                // get class as object not property
                var classInfo = BasicPropertyFilter.RtrnObjPropertyInfo(inputData, internalClassObject.PropertyType);
                var classValue = BasicPropertyFilter.RtrnObjPropVal(inputData, classInfo);

                // take each property from Balance /CashFlow / Income statment and fill it.
                foreach (PropertyInfo internalClassProperty in classValue.GetType().GetProperties())
                {
                    internalClassProperty.SetValue(
                        classValue,
                        Convert.ChangeType(fillValue, internalClassProperty.PropertyType), 
                        null );
                }
            }
        }

        private int GetNextYear(FinancialData lastReport)
        {
            if (lastReport.Quarter == 4)
            {
                return lastReport.Year++;
            }
            else
            {
                return lastReport.Year;
            }
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
