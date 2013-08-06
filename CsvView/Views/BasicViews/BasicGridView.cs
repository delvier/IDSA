using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IDSA.Presenters.PropertyPresenters;
using Microsoft.Practices.ServiceLocation;

namespace IDSA.Views.PropertyView
{
    public interface IBasicGridView
    {
        void BindHeader(String title);
        void BindGridData(IBindingList dataTable);
        IBasicGridPresenter GetPresenterHandler();
    }
    public partial class BasicGridView : UserControl, IBasicGridView
    {
        private IBasicGridPresenter _presenter;
        public BasicGridView(Type presenterType)
        {
            _presenter = (IBasicGridPresenter)ServiceLocator.Current.GetInstance(presenterType);
            InitializeComponent();
            /* View data bind */
            this.BindHeader(_presenter.Header);
            this.BindGridData(_presenter.Data);

            //TODO : TRY TO ADD EVENT that will call procedure and rebind data on property change
            //_presenter.PropertPropertyChangedEventHandler += (o, eventArg) => BindDataGridView();
        }

        public void BindHeader(String header)
        {
            titleLabel.Text = header;
        }

        public void BindGridData(IBindingList bindingDataList)
        {
            baseViewGrid.DataSource = bindingDataList;
        }

        /* Handler for master presenter */
        public IBasicGridPresenter GetPresenterHandler()
        {
            return _presenter;
        }
    }
}
