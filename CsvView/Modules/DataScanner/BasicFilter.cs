using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Modules.DataScanner
{
    public class BasicFilter : IFilter
    {
        public int _lowValue {get; private set;}
        public int _highValue {get; private set;}

        public BasicFilter(int low, int high)
        {
            this._lowValue = low;
            this._highValue = high;
        }

        public IList<T> FiltrAction<T>(IList<T> lst)
        {
            throw new NotImplementedException();
        }


        int IFilter._lowValue
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        int IFilter._highValue
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        IList<T> IFilter.FiltrAction<T>(IList<T> lst)
        {
            throw new NotImplementedException();
        }
    }
}
