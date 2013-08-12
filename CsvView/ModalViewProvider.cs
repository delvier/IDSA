using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views.ReportManagment;
using IDSA.Views.BasicViews;

namespace IDSA
{
    class ModalViewProvider : IViewProvider
    {
        public EProjectionType ProjectionType
        {
            get { return EProjectionType.Modal; }
        }

        public IEnumerable<ViewItemDescriptor> GetViews()
        {
            var lst = new List<ViewItemDescriptor>();

            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Report Add",
                    View = typeof(BasicDataControl)
                }
                );

            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Report Edit",
                    View = typeof(BasicDataControl)
                }
                );

            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Report Delete",
                    View = typeof(BasicDataControl)
                }
                );

            return lst;
        }
    }
}
