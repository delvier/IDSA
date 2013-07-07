using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;
using System.Reflection;

namespace IDSA.Modules.DataScanner
{
    public interface IFilter
    {
        Int64 _lowValue { get; set; }
        Int64 _highValue { get; set; }

        /* information required by data scanner */
        Type GetTypeClassFilterProperty();
        PropertyInfo GetFilterProperty();

        /* Filtering Action - filter Ilist */
        IList<Company> FilterAction(IList<Company> lst);
    }
}
