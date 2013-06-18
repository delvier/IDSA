using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;

namespace IDSA.Modules.DataScanner
{
    public interface IFilter
    {
        int _lowValue { get; set; }
        int _highValue { get; set; }
        
        //filter action place.
        IList<Company> FilterAction(IList<Company> lst);
    }
}
