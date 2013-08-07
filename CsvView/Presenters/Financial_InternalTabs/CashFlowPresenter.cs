using System;
using System.Linq;
using IDSA.Presenters.PropertyPresenters;
using IDSA.Models.DataStruct;
using System.ComponentModel;

namespace IDSA.Presenters.Financial_InternalTabs
{
    public class CashFlowPresenter : BasicGridPresenter
    {

        public override void DataUpdate(Models.Company company)
        {
            Data = new BindingList<PresenterCashFlow>(company.Reports
                            .Select(r => new PresenterCashFlow
                            { 
                                YearAndQuarter = String.Format("{0} : [{1}]", r.Year, r.Quarter),
                                ReportDate = r.FinancialReportReleaseDate,
                                CapexIntangible = r.CashFlow.CapexIntangible,
                                Depreciation = r.CashFlow.Depreciation,
                                Dividend = r.CashFlow.Dividend,
                                FinancialCF = r.CashFlow.FinancialCF,
                                InvestmentCF = r.CashFlow.InvestmentCF,
                                LiabilitiesChange = r.CashFlow.LiabilitiesChange,
                                LoansAndAdvancesObtained = r.CashFlow.LoansAndAdvancesObtained,
                                LoansAndAdvancesRepayed = r.CashFlow.LoansAndAdvancesRepayed,
                                ObligationsStateChange = r.CashFlow.ObligationsStateChange,
                                OperatingActivitiesCF = r.CashFlow.OperatingActivitiesCF,
                                ReceivablesChange = r.CashFlow.ReceivablesChange,
                                ReserveAndOtherChange = r.CashFlow.ReserveAndOtherChange,
                                SharesIssue = r.CashFlow.SharesIssue,
                                TotalCF = r.CashFlow.TotalCF,
                                WorkingCapital = r.CashFlow.WorkingCapital
                            })
                            .ToList()
                     );
            this.Header = company.FullName;
        }
        private class PresenterCashFlow : CashFlowData
        {
            public string YearAndQuarter { get; set; }
            public DateTime ReportDate { get; set; }
        }
    }
}
