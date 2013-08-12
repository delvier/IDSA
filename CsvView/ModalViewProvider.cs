using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views.ReportManagment;

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
                    View = typeof(AddReport)
                }
                );

            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Report Edit",
                    View = typeof(EditReport)
                }
                );

            lst.Add(
                new ViewItemDescriptor()
                {
                    Header = "Report Delete",
                    View = typeof(DeleteReport)
                }
                );

            return lst;
        }
    }
}
