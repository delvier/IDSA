using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IDSA.Views.CompaniesInternal;
using Microsoft.Practices.ServiceLocation;
using IDSA.Presenters;

namespace IDSA.Views
{
    public partial class InternalTabTest : UserControl
    {
        private FinancialMasterTab _presenter;


        public InternalTabTest()
        {
            InitializeComponent();

            _presenter = new FinancialMasterTab(this);
            _presenter.InitInternalTabs();
        }

        public void AddInternalTab(Control tabView, String header)
        {
            var tp = new TabPage(header);
            tp.Controls.Add(tabView);
            tabView.Dock = DockStyle.Fill;
            internalTabContainer.Controls.Add(tp);
        }

        public void Message(String msg)
        {
            MessageBox.Show(msg);
        }
    }
}
