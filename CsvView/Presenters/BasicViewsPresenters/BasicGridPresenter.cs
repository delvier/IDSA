using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IDSA.Views.PropertyView;
using IDSA.Models.DataStruct;
using IDSA.Models;

namespace IDSA.Presenters.PropertyPresenters
{
    public interface IBasicGridPresenter
    {
        String GetTitle();
        DataTable GetDataTable();
        void UpdateView();
    }
    public class BasicGridPresenter : IBasicGridPresenter
    {
        private IBasicGridView _view;
        private String _title;
        private DataTable _dataTable;

        public BasicGridPresenter(BasicGridView view)
        {
            this._view = view;
        }

        public void SetTitle(String title)
        {
            _title = title;
        }
        public string GetTitle()
        {
            return _title;
        }

        public void SetDataTable(DataTable dataTable)
        {
            _dataTable = dataTable;
        }
        public DataTable GetDataTable()
        {
            return _dataTable;
        }

        public void UpdateView()
        {
            this._view.UpdateLabaelName(GetTitle());
            this._view.UpdateBasicDataGrid(GetDataTable());
        }
    }
}
