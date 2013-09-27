using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace IDSA.Services
{
    /**
     * Breaking class as smaller class-properties dictionary.
     * This service support only 1 level of depth into the tree of class 
     * which mean class->class->class dict is not provided.
     */
    public class PropertiesExtractorService
    {
        private Type _breakingType { get; set; }
        private PropertyInfo[] _breakingProperties { get; set; }

        public PropertiesExtractorService(Type breakingType)
        {
            this._breakingType = breakingType;
            this._breakingProperties = breakingType.GetProperties();
        }

        public IEnumerable<PropertyInfo> GetClasses()
        {
            return _breakingProperties.Where(prop => prop.PropertyType.IsClass);
        }

        public IEnumerable<PropertyInfo> GetBaseProperties()
        {
            return _breakingProperties.Where(prop => !prop.PropertyType.IsClass);
        }

        public Dictionary<string, IEnumerable<PropertyInfo>> GetStructureDict()
        {
            var dict = new Dictionary<string, IEnumerable<PropertyInfo>>();
            dict.Add("Base", GetBaseProperties());
            foreach (var classProperty in GetClasses())
            {
                dict.Add(classProperty.PropertyType.Name, classProperty.PropertyType.GetProperties());
            }
            return dict;
        }
    }
}
