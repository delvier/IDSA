using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Services;
using IDSA.Models.DataStruct;
using System.Windows.Forms;
using IDSA.Views.BasicViews;

namespace IDSA.Presenters.ReportManagment
{
    public class FinancialDataTabDescriptorProvider
    {
        private IList<ViewItemDescriptor> _tabDescriptors = new List<ViewItemDescriptor>();

        public FinancialDataTabDescriptorProvider()
        {
            _tabDescriptors.Add( new ViewItemDescriptor() { Header = "IncomeStatement" , View = typeof(IncomeStatmentData) }  );
            _tabDescriptors.Add( new ViewItemDescriptor() { Header = "Balance" , View = typeof(BalanceData) }  );
            _tabDescriptors.Add( new ViewItemDescriptor() { Header = "CashFlow", View = typeof(CashFlowData) });
        }


        public IList<ViewItemDescriptor> GetDescriptors()
        {
            return _tabDescriptors;
        }

    }
}