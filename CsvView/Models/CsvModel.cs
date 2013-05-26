using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LumenWorks.Framework.IO.Csv;
using System.ComponentModel;

namespace IDSA.Models
{
    class CsvModel
    {
        private CachedCsvReader _csv;

        public CsvEnums.DataType typeOf;
        public Type csvEnumType;
        public int RowSize { get; private set; }

        [DefaultValue(false)]
        public bool csvModelInitialized { get; private set; }

        private static Dictionary<CsvEnums.DataType, Type> csvDataTypeDict = new Dictionary<CsvEnums.DataType, Type>
        {
            { CsvEnums.DataType.Company, typeof(CsvEnums.company) },
            { CsvEnums.DataType.Financial, typeof(CsvEnums.financialData)}
        };

        public CsvModel(CachedCsvReader csv, CsvEnums.DataType type)
        {
            this._csv = csv;
            this.typeOf = type;
            this.RowSize = csv.FieldCount;
            this.csvEnumType = GetEnumDataTypeFromDict(type);
            this.csvModelInitialized = true;
        }

        public CachedCsvReader GetSourceData()
        {
            if (csvModelInitialized)
            {
                return _csv;
            }
            else
            {
                return null;
            }
        }

        public Type GetEnumDataTypeFromDict (CsvEnums.DataType key)
        {
            return csvDataTypeDict[key];
        }


    }
}
