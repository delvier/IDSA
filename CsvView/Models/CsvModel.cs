using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LumenWorks.Framework.IO.Csv;

namespace IDSA.Models
{
    class CsvModel
    {
        private CachedCsvReader _csv;

        public CsvEnums.DataType typeOf;
        public int RowSize { get; private set; }

        Dictionary<CsvEnums.DataType, Enum> csvDataTypeDict = new Dictionary<CsvEnums.DataType, Enum>();

        public CsvModel(CachedCsvReader csv, CsvEnums.DataType type)
        {
            this._csv = csv;
            this.typeOf = type;
            this.RowSize = csv.FieldCount;
        }

        public CachedCsvReader GetSourceData()
        {
            return _csv;
        }
        public void InitCsvDataTypeDictionary ()
        {
            // PROBLEM : How to solve this releation ?
            // or class needed to handle this ? or imposible ?
            //csvDataTypeDict.Add(CsvEnums.DataType.Company, CsvEnums.company);
        }
    }
}
