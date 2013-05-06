using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public interface IViewProvider
    {
        EProjectionType ProjectionType { get; }
        IEnumerable<ViewItemDescriptor> GetViews();
    }
}
