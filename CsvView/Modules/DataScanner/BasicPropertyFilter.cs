using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using IDSA.Models;

namespace IDSA.Modules.DataScanner
{
    public class BasicPropertyFilter : PropertyFilter
    {
        public BasicPropertyFilter()
            : base() { }

        public BasicPropertyFilter(PropertyInfo property, Type filterType, int low, int high)
            : base(property, filterType, low, high) { }

        public override IList<Company> FilterAction(IList<Company> lst)
        {
            var _cmpsFilterOut = new List<Company>();

            foreach (Company cmp in lst)
            {
                int matchNum = cmp.Reports.Count(r =>
                                    Int64.Parse(RtrnNtestedClassPropertyValue(r, _classProperty, _propertyInfo)) > _lowValue &&
                                    Int64.Parse(RtrnNtestedClassPropertyValue(r, _classProperty, _propertyInfo)) > _highValue
                                    );
                if (matchNum != 0)
                    _cmpsFilterOut.Add(cmp); //this cannot be done on active collection :)
            }
            return _cmpsFilterOut;
        }

        internal string RtrnNtestedClassPropertyValue(object multiLayerObj, Type firstLevelType, PropertyInfo lookingProperty)
        {
            var myProp       = RtrnObjPropertyInfo(multiLayerObj, firstLevelType);
            var nestedObj    = RtrnObjPropVal(multiLayerObj, myProp);
            var searchValue  = nestedObj.GetType().GetProperty(lookingProperty.Name)
                                        .GetValue(nestedObj, null).ToString();
            return searchValue;
        }

        internal PropertyInfo RtrnObjPropertyInfo(object obj, Type typeInfo)
        {
            return obj.GetType().GetProperties().First(p => p.PropertyType.Name == typeInfo.Name);
        }

        internal object RtrnObjPropVal(object obj, PropertyInfo prop)
        {
            return obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
        }
    }
}

