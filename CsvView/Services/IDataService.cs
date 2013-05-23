using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Services
{
    public interface IDataService<out TData>
    {
        IEnumerable<TData> GetData();
    }
}
