using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using IDSA.Models;

namespace IDSA.Modules.DataScanner
{
    public class IncomeStatmentPropertiesFilter : PropertyFilter  
    {

        public IncomeStatmentPropertiesFilter(PropertyInfo prop, Type type, int low, int high ) 
            : base (prop, type, low,high) {} 
        
        public IncomeStatmentPropertiesFilter() 
            : base() {}

        public override IList<Company> FilterAction(IList<Company> lst)
        {
            throw new NotImplementedException();
        }
    }
  
}
