using System.Collections.Generic;

namespace IDSA
{
    public interface IViewProvider<T>
    {
        EProjectionType ProjectionType { get; }
        IEnumerable<T> GetViews();
    }

    public interface IViewProvider
    {
        EProjectionType ProjectionType { get; }
        IEnumerable<ViewItemDescriptor> GetViews();
    }
}
