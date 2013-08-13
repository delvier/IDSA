﻿using System.Collections.Generic;
using IDSA.Views.PropertyView;
using IDSA.Presenters.Financial_InternalTabs;

namespace IDSA.Views.CompaniesInternal
{
    public class FinancialInternalTabbedProvider : IViewProvider<FinancialTabItemDescriptor>
    {
        public EProjectionType ProjectionType
        {
            get { return EProjectionType.Tabbed; }
        }

        public IEnumerable<FinancialTabItemDescriptor> GetViews()
        {
            var lst = new List<FinancialTabItemDescriptor>();
            lst.Add(
                   new FinancialTabItemDescriptor()
                   {
                       Header = "Bilans",
                       View = typeof(BasicGridView),
                       TabPresenterType = typeof(BalancePresenter)
                   });

            lst.Add( 
                   new FinancialTabItemDescriptor()
                   {
                       Header = "RZiS",
                       View = typeof(BasicGridView),
                       TabPresenterType = typeof(IncomeStatmentPresenter)
                   });

            lst.Add(
                   new FinancialTabItemDescriptor()
                   {
                       Header = "Cash Flow",
                       View = typeof(BasicGridView),
                       TabPresenterType = typeof(CashFlowPresenter)
                   });

            return lst;
        }
    }
}
