using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views.PropertyView;
using IDSA.Models.DataStruct;
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
                       TabPresenter = typeof(BalancePresenter)
                   });

            lst.Add( 
                   new FinancialTabItemDescriptor()
                   {
                       Header = "RZiS",
                       View = typeof(BasicGridView),
                       TabPresenter = typeof(IncomeStatmentPresenter)
                   });

            lst.Add(
                   new FinancialTabItemDescriptor()
                   {
                       Header = "Cash Flow",
                       View = typeof(BasicGridView),
                       TabPresenter = typeof(CashFlowPresenter)
                   });

            return lst;
        }
    }
}
