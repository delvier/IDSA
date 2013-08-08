using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA
{
    class MixedViewProvider : IViewProvider<MixedViewItemDescriptor>
    {

        IEnumerable<MixedViewItemDescriptor> IViewProvider<MixedViewItemDescriptor>.GetViews()
        {
            var mixedList = new List<MixedViewItemDescriptor>();
            foreach (var tabViewItem in new TabbedViewProvider().GetViews())
            {
                mixedList.Add(new MixedViewItemDescriptor
                {
                    Header = tabViewItem.Header,
                    Type = EProjectionType.Tabbed,
                    View = tabViewItem.View
                });
            }

            foreach (var modalViewItem in new ModalViewProvider().GetViews())
            {
                mixedList.Add(new MixedViewItemDescriptor
                {
                    Header = modalViewItem.Header,
                    Type = EProjectionType.Modal,
                    View = modalViewItem.View
                });
            }
            return mixedList;
        }

        public EProjectionType ProjectionType
        {
            get { throw new NotImplementedException(); }
        }
    }
}
