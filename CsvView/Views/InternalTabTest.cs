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
        private InternalTabTestPresenter _presenter;


        public InternalTabTest()
        {
            InitializeComponent();

            _presenter = new InternalTabTestPresenter(this);
        }

        public void AddInternalTab(Control tabControl, String header)
        {
            internalTabContainer.Controls.Add(tabControl);
            tabControl.Dock = DockStyle.Fill;
            var tp = new TabPage(header);
            tp.Controls.Add(tabControl);
            internalTabContainer.TabPages.Add(tp);
        }

        public void Message(String msg)
        {
            MessageBox.Show(msg);
        }
    }
}
