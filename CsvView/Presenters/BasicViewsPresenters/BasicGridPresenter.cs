using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using IDSA.Views.PropertyView;
using IDSA.Models.DataStruct;
using IDSA.Models;
using Microsoft.Practices.Prism.ViewModel;
using System.ComponentModel;

namespace IDSA.Presenters.PropertyPresenters
{
    public interface IBasicGridPresenter
    {
        String Header { get; set; }
        IBindingList Data { get; }
        void DataSet(Company company);
    }
    public abstract class BasicGridPresenter : NotificationObject, IBasicGridPresenter
    {
        private IBasicGridView _view;
        private String _header;

        public BasicGridPresenter(IBasicGridView view)
        {
            this._view = view;
        }

        public IBindingList Data
        {
            get;
            set;
        }

        public string Header
        {
            get { return this._header; }
            set
            {
                if (this._header != value)
                {
                    this._header = value;
                    this.RaisePropertyChanged(() => this.Header);
                }
            }
        }

        public abstract void DataSet(Company company);
    }
}
