using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace IDSA.Modules.DataScanner
{
    public abstract class PropertyFilter : BaseFilter
    {
        protected PropertyInfo _propertyInfo { get; set; }
        protected Type _classProperty { get; set; }

        public PropertyFilter(PropertyInfo prop, Type filterType, int low, int high)
            : base(low, high)
        {
            this._propertyInfo = prop;
            this._classProperty = filterType;
        }

        public PropertyFilter()
            : base()
        {

        }
    }
}
