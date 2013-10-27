using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models.DataStruct;
using Microsoft.Practices.Prism.ViewModel;

namespace IDSA.Services
{
    /*
     * Service used as communication layer for TabFinancialDataMaster, edit,add,delete reports.
     */
    public interface IReportStoreService
    {
        FinancialData financialData { get; set; }
    }

    public class ReportStoreService : NotificationObject, IReportStoreService
    {
        private FinancialData _financialData;

        public ReportStoreService()
        {
            //_financialData = new FinancialData();
        }

        public FinancialData financialData
        {
            get
            {
                return _financialData;
            }
            set
            {
               this._financialData = value;
               this.RaisePropertyChanged(() => this.financialData);
            }
        }
    }
}
