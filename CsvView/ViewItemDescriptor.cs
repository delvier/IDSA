using System;

namespace IDSA
{
    public class ViewItemDescriptor
    {
        public string Header { get; set; }
        public Type View { get; set; }
    }

    public class BasicGridViewItemDescriptor : ViewItemDescriptor
    {
        public Type GridDataType { get; set; }
    }
}
