using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;

namespace IDSA.Modules.DataScanner
{
    public interface IFilter
    {
        Int64 _lowValue { get; set; }
        Int64 _highValue { get; set; }
        
        //filter action place.
        IList<Company> FilterAction(IList<Company> lst);
    }
}
