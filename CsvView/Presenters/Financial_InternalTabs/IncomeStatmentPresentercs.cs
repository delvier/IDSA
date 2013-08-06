using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Presenters.PropertyPresenters;
using IDSA.Views.PropertyView;
using System.Collections;
using System.ComponentModel;

namespace IDSA.Presenters.Financial_InternalTabs
{
    public class IncomeStatmentPresenter : BasicGridPresenter
    {
        public IncomeStatmentPresenter()
            : base()
        {
        }

        public override void DataUpdate(Models.Company company)
        {
            Data = new BindingList<IncomeStatmentObj>(company.Reports
                            .Select(r => new IncomeStatmentObj
                            {
                                CompanyName = company.Name,
                                Year_Quarter = String.Format("{0}:{1}", r.Year, r.Quarter),
                                Sales = r.IncomeStatement.Sales,
                                Costs = r.IncomeStatement.SalesCost1,
                                Costs2 = r.IncomeStatement.SalesCost2,
                                EBIT = r.IncomeStatement.EBIT,
                                NetProfit = r.IncomeStatement.NetProfit
                            })
                            .ToList<IncomeStatmentObj>()
                     );
            this.Header = company.FullName;
        }

        private class IncomeStatmentObj
        {
            public string CompanyName { get; set; }
            public string Year_Quarter { get; set; }
            public Int64 Sales { get; set; }
            public Int64 Costs { get; set; }
            public Int64 Costs2 { get; set; }
            public Int64 EBIT { get; set; }
            public Int64 NetProfit { get; set; }
        }
    }
}
