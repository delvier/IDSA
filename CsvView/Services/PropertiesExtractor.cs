using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace IDSA.Services
{
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
