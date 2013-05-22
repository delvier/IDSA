using System.Collections.Generic;

namespace IDSA
{
    public interface IViewProvider
    {
        EProjectionType ProjectionType { get; }
        IEnumerable<ViewItemDescriptor> GetViews();
    }
}
