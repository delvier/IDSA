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

namespace IDSA.Views
{
    public partial class InternalTabTest : UserControl
    {
        public InternalTabTest()
        {
            InitializeComponent();

            BuildInternalTabs(new FinancialDataInternalTabbedProvider(), internalTabContainer);
        }

        private void BuildInternalTabs(FinancialDataInternalTabbedProvider tabProvider, TabControl tabContainer)
        {
            foreach (var internalTab in tabProvider.GetViews())
            {
                var view = (Control)ServiceLocator.Current.GetInstance(internalTab.View);
                view.Dock = DockStyle.Fill;
                var tp = new TabPage(internalTab.Header);
                tp.Controls.Add(view);
                tabContainer.TabPages.Add(tp);
            }
        }
    }
}
