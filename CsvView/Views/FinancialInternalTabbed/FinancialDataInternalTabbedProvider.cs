using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views.PropertyView;

namespace IDSA.Views.CompaniesInternal
{
    class FinancialDataInternalTabbedProvider : IViewProvider
    {
        public EProjectionType ProjectionType
        {
            get { return EProjectionType.Tabbed; }
        }

        public IEnumerable<ViewItemDescriptor> GetViews()
        {
            var lst = new List<ViewItemDescriptor>();
            lst.Add(
                   new ViewItemDescriptor()
                   {
                       Header = "Bilans",
                       View = typeof(BasicGridView)
                   });

            lst.Add(
                   new ViewItemDescriptor()
                   {
                       Header = "RZiS",
                       View = typeof(BasicGridView)
                   });

            lst.Add(
                   new ViewItemDescriptor()
                   {
                       Header = "Cash Flow",
                       View = typeof(BasicGridView)
                   });

            return lst;
        }
    }
}
