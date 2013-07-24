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

        /*
         * Constructors
         */
        #region Constructors

        public BasicPropertyFilter()
            : base() { }

        public BasicPropertyFilter(PropertyInfo property, Type filterType, int low, int high)
            : base(property, filterType, low, high) { }

        #endregion

        /* 
         * Public Methods
         */
        #region Public Methods

        public override IList<Company> FilterAction(IList<Company> lst)
        {
            var _cmpsFilterOut = new List<Company>();

            foreach (Company cmp in lst)
            {
                int matchNum = cmp.Reports.Take(1).Count(r =>
                                            Int64.Parse(RtrnNtestedClassPropertyValue(r, _classProperty, _propertyInfo)) > _lowValue &&
                                            Int64.Parse(RtrnNtestedClassPropertyValue(r, _classProperty, _propertyInfo)) < _highValue
                                            );
               //var debugValue = cmp.Reports.Take(1).Select(r => RtrnNtestedClassPropertyValue(r, _classProperty, _propertyInfo)).ToList();
                if (matchNum != 0)
                {
                    var debugValue = cmp.Reports.Take(1).Select(r => RtrnNtestedClassPropertyValue(r, _classProperty, _propertyInfo)).ToList();
                    _cmpsFilterOut.Add(cmp); //this cannot be done on active collection :)
                }
                    
            }
            return _cmpsFilterOut;
        }

        public override Type GetTypeClassFilterProperty()
        {
            return _classProperty;
        }

        public override PropertyInfo GetFilterProperty()
        {
            return _propertyInfo;
        }

        #endregion

        /* 
         * Internal Methods 
         */
        #region Internal Methods

        public static string RtrnNtestedClassPropertyValue(object multiLayerObj, Type firstLevelType, PropertyInfo lookingProperty)
        {
            var myProp = RtrnObjPropertyInfo(multiLayerObj, firstLevelType);
            var nestedObj = RtrnObjPropVal(multiLayerObj, myProp);
            var searchValue = nestedObj.GetType().GetProperty(lookingProperty.Name)
                                        .GetValue(nestedObj, null).ToString();
            return searchValue;
        }

        public static PropertyInfo RtrnObjPropertyInfo(object obj, Type typeInfo)
        {
            return obj.GetType().GetProperties().First(p => p.PropertyType.Name == typeInfo.Name);
        }

        public static object RtrnObjPropVal(object obj, PropertyInfo prop)
        {
            return obj.GetType().GetProperty(prop.Name).GetValue(obj, null);
        }

        #endregion
        

       
    }
}

