using System;

namespace IDSA
{
    public class ViewItemDescriptor
    {
        public string Header { get; set; }
        public Type View { get; set; }
    }

    public class FinancialTabItemDescriptor : ViewItemDescriptor
    {
        public Type TabPresenter { get; set; }
    }
}
