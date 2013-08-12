using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace IDSA.Models.DataStruct
{
    public interface IGridRawDataTableProvider
    {
        DataTable GetRawDataTable();
        void BuildDataTable();
    }

    public class GridRawDataTableProvider : IGridRawDataTableProvider
    {
        private DataTable _datatable;
        private IRawData _rawDataProvider;

        public GridRawDataTableProvider(String tableName, IRawData rawDataProvider)
        {
            _datatable = new DataTable(tableName);
            _rawDataProvider = rawDataProvider;

            this.BuildDataTable();
        }

        public DataTable GetRawDataTable()
        {
            return _datatable;
        }

        /*
         * Build data table based on IRawData,
         */
        public void BuildDataTable()
        {
            BuildDataTableHeaders();
            BuildDataTableValues();
        }

        /*
         * Build headers for data table based on IRawData-Headers<Ilist<String>>
         */
        private void BuildDataTableHeaders()
        {
            foreach (var header in _rawDataProvider.Headers)
            {
                _datatable.Columns.Add(header, header.GetType());
            }
        }

        /*
         * Build values for data table based on IRawData Ilist<Ilist<String>>
         */
        private void BuildDataTableValues()
        {
            _rawDataProvider.Values.ToList()
                                   .ForEach(_row => _datatable.Rows.Add(_row.ToArray()));
        }
    }
}
