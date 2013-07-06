using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using IDSA.Models;

namespace IDSA.Modules.DataScanner
{
    public class ReportPropertiesFilter : PropertyFilter
    {
        public override IList<Company> FilterAction(IList<Company> lst)
        {
            var _cmpsFilterOut = new List<Company>();
            foreach (Company cmp in lst)
            {
                int matchNum = cmp.Reports.Count(r => 
                    Int64.Parse(r.GetType().
                    GetProperty(_propertyInfo.Name.ToString()).
                    GetValue(r, null).ToString()) > _lowValue &&
                    Int64.Parse(r.GetType().
                    GetProperty(_propertyInfo.Name.ToString()).
                    GetValue(r, null).ToString()) < _highValue
                    );
                if (matchNum != 0)
                    _cmpsFilterOut.Add(cmp); //this cannot be done on active collection :)
            }
            return _cmpsFilterOut;
        }
    }
}
