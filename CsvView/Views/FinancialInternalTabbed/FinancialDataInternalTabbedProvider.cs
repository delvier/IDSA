using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views.PropertyView;
using IDSA.Models.DataStruct;

namespace IDSA.Views.CompaniesInternal
{
    class FinancialDataInternalTabbedProvider : IViewProvider<BasicGridViewItemDescriptor>
    {
        public EProjectionType ProjectionType
        {
            get { return EProjectionType.Tabbed; }
        }

        public IEnumerable<BasicGridViewItemDescriptor> GetViews()
        {
            var lst = new List<BasicGridViewItemDescriptor>();
            lst.Add(
                   new BasicGridViewItemDescriptor()
                   {
                       Header = "Bilans",
                       View = typeof(BasicGridView),
                       GridDataType = typeof(IBalanceData)
                   });

            lst.Add(
                   new BasicGridViewItemDescriptor()
                   {
                       Header = "RZiS",
                       View = typeof(BasicGridView),
                       GridDataType = typeof(IIncomeStatmentData)
                   });

            lst.Add(
                   new BasicGridViewItemDescriptor()
                   {
                       Header = "Cash Flow",
                       View = typeof(BasicGridView),
                       GridDataType = typeof(ICashFlowData)
                   });

            return lst;
        }
    }
}
