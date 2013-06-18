using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDSA.Modules.DataScanner
{
    public class FilterDescriptor
    {
        public string Name { get; set; }
        public IFilter Filter { get; set; }
    }
}
