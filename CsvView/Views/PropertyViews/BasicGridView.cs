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
        void UpdateLabaelName(String title);
        void UpdateBasicDataGrid(DataTable dataTable);
    }
    public partial class BasicGridView : UserControl, IBasicGridView
    {
        private BasicGridPresenter _presenter;
        public BasicGridView()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            _presenter.UpdateView();
        }

        public void UpdateLabaelName(String title)
        {
            titleLabel.Text = title;
        }

        public void UpdateBasicDataGrid(DataTable dataTable)
        {
            baseViewGrid.DataSource = dataTable;
        }
    }
}
