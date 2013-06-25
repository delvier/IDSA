using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using IDSA.Models;

namespace IDSA.Modules.DataScanner
{
    public class ReportPropertiesFilter : BaseFilter
    {
        private PropertyInfo _propertyInfo;

        public ReportPropertiesFilter(PropertyInfo prop, int low, int high) : base(low, high)
        {
            this._propertyInfo = prop;
        }

        public ReportPropertiesFilter() : base()
        {
        }

        public override IList<Company> FilterAction(IList<Company> lst)
        {
            var _cmpsFilterOut = new List<Company>();
            foreach (Company cmp in lst)
            {
                int matchNum = cmp.Reports.Count(r => 
                    (int)r.GetType().
                    GetProperty(_propertyInfo.Name.ToString()).
                    GetValue(r, null) > _lowValue && 
                    (int)r.GetType().
                    GetProperty(_propertyInfo.Name.ToString()).
                    GetValue(r, null) < _highValue
                    );
                if (matchNum != 0)
                    _cmpsFilterOut.Add(cmp); //this cannot be done on active collection :)
            }
            return _cmpsFilterOut;
        }
    }
}
