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
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace IDSA.Presenters.PropertyPresenters
{
    public interface IBasicGridPresenter
    {
        String Header { get; set; }
        IBindingList Data { get; set; }
        void DataUpdate(Company company);
        event PropertyChangedEventHandler PresenterDataChanged;
    }
    public abstract class BasicGridPresenter : NotificationObject, IBasicGridPresenter
    {
        //private IBasicGridView _view;
        public event PropertyChangedEventHandler PresenterDataChanged;

        public BasicGridPresenter()
        {
            //this._view = view;
        }

        private IBindingList  _data;
        public IBindingList Data
        {
            get
            {
                return this._data;
            }

            set
            {
                _data = value;
                NotifyPropertyChanged("Data");
                //_data.CollectionChanged += MyPropertyListChanged;
            }
        }

        private String _header;
        public string Header
        {
            get { return this._header; }
            set
            {
                if (this._header != value)
                {
                    this._header = value;
                    //this.RaisePropertyChanged(() => this.Header);
                    NotifyPropertyChanged("Header");
                }
            }
        }

        public void MyPropertyListChanged(object o, NotifyCollectionChangedEventArgs e)
        {
            {
                NotifyPropertyChanged("Data");
            }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PresenterDataChanged != null)
                PresenterDataChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract void DataUpdate(Company company);
    }
}
