using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IDSA.Presenters;
using IDSA.Models.Repository;
using Microsoft.Practices.Prism.Events;
using IDSA.Events;

namespace IDSA.Views
{
    public partial class DataScanner : UserControl
    {
        private DataScannerPresenter _presenter;

        public DataScanner(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            _presenter = new DataScannerPresenter(this);
            eventAggregator.GetEvent<DatabaseCreatedEvent>().Subscribe(InitEvent);
        }

        public void InitEvent(bool isDone)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => InitEvent(isDone)));
            }
            else
            {
                InitDataSettings();
            }
        }

        public void InitDataSettings()
        {
            FilterSelectComboBox.DataSource = _presenter.GetFilters();
            FilterSelectComboBox.DisplayMember = "Name";
        }

        private void AddFilterBtn_Click(object sender, EventArgs e)
        {
            var btn = new Button();
            flowLayoutPanel1.Controls.Add(btn);
        }
    }
}
