using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Presenters.PropertyPresenters;
using IDSA.Views.PropertyView;
using System.Collections;
using System.ComponentModel;
using System.Collections.ObjectModel;
using IDSA.Models.DataStruct;

namespace IDSA.Presenters.Financial_InternalTabs
{
    public class IncomeStatmentPresenter : BasicGridPresenter
    {
        public IncomeStatmentPresenter()
            : base() { }

        public override void DataUpdate(Models.Company company)
        {
            Data = new BindingList<PresenterIncomeStatment>(company.Reports
                            .Select(r => new PresenterIncomeStatment
                            {
                                YearAndQuarter = String.Format("{0} : [{1}]", r.Year, r.Quarter),
                                ReportDate = r.FinancialReportReleaseDate,
                                Sales = r.IncomeStatement.Sales,
                                SalesCost1 = r.IncomeStatement.SalesCost1,
                                SalesCost2 = r.IncomeStatement.SalesCost2,
                                OwnSaleCosts = r.IncomeStatement.OwnSaleCosts,
                                OtherCostOrSales = r.IncomeStatement.OtherCostOrSales,
                                OtherOperationalActivity1 = r.IncomeStatement.OtherOperationalActivity1,
                                OtherOperationalActivity2 = r.IncomeStatement.OtherOperationalActivity2,
                                FinancialActivity1 = r.IncomeStatement.FinancialActivity1,
                                FinancialActivity2 = r.IncomeStatement.FinancialActivity2,
                                EarningOnSales = r.IncomeStatement.EarningOnSales,
                                SalesOnEconomicActivity = r.IncomeStatement.SalesOnEconomicActivity,
                                ExceptionalOccurence = r.IncomeStatement.ExceptionalOccurence,
                                EarningBeforeTaxes = r.IncomeStatement.EarningBeforeTaxes,
                                EBIT = r.IncomeStatement.EBIT,
                                NetProfit = r.IncomeStatement.NetProfit,
                                NetParentProfit = r.IncomeStatement.NetParentProfit
                            })
                            .ToList<PresenterIncomeStatment>()
                     );
            this.Header = company.FullName;
        }

        private class PresenterIncomeStatment : IncomeStatmentData
        {
            public string YearAndQuarter { get; set; }
            public DateTime ReportDate { get; set; }
        }
    }

    
}
