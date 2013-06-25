using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;

namespace IDSA.Modules.DataScanner
{
    public abstract class BaseFilter : IFilter
    {
        public Int64 _lowValue {get; set;}
        public Int64 _highValue { get; set; }

        public BaseFilter(int low, int high)
        {
            this._lowValue = low;
            this._highValue = high;
        }

        public BaseFilter()
        {
            this._lowValue = 0;
            this._highValue = 0;
        }

        public abstract IList<Company> FilterAction(IList<Company> lst);
    }
}
