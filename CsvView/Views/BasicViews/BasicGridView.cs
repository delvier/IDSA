using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IDSA.Presenters.PropertyPresenters;

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
        public BasicGridView(IBasicGridPresenter presenter)
        {
            _presenter = presenter;
            InitializeComponent();
            /* View data bind */
            this.BindHeader(_presenter.Header);
            this.BindGridData(_presenter.Data);
        }

        public void BindHeader(String title)
        {
            titleLabel.Text = title;
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
