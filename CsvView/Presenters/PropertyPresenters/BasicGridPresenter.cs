using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IDSA.Views.PropertyView;

namespace IDSA.Presenters.PropertyPresenters
{
    public interface IBasicGridPresenter
    {
        String GetTitleLabel();
        DataTable GetDataTable();
        void UpdateView();
    }
    public class BasicGridPresenter : IBasicGridPresenter
    {
        private IBasicGridView _view;

        public BasicGridPresenter(BasicGridView view)
        {
            this._view = view;
        }

        public string GetTitleLabel()
        {
            throw new NotImplementedException();
        }

        public DataTable GetDataTable()
        {
            throw new NotImplementedException();
        }

        public void UpdateView()
        {
            this._view.UpdateLabaelName(GetTitleLabel());
            this._view.UpdateBasicDataGrid(GetDataTable());
        }
    }
}
