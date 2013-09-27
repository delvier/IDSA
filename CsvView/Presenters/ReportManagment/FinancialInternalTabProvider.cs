using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Services;
using IDSA.Models.DataStruct;
using System.Windows.Forms;
using IDSA.Views.BasicViews;

namespace IDSA.Presenters.ReportManagment
{
    public class FinancialInternalTabProvider
    {
        private IList<TabPage> _internalTabs = new List<TabPage>();

        public FinancialInternalTabProvider()
        {
            // here real provider comes into play...
            var structDict = new PropertiesExtractorService(typeof(FinancialData)).GetStructureDict();

            // fast exclude company from properties as abstract 
            // class should not be modified by add/edit/delete report

            if (structDict.ContainsKey("Company"))
                structDict.Remove("Company");

            // generating pure view of tab data.
            foreach (var dictElement in structDict)
            {
                var flowPanel = new FlowLayoutPanel();
                flowPanel.AutoSize = true;
                flowPanel.Dock = DockStyle.Fill;
                flowPanel.AutoScrollMinSize = new System.Drawing.Size(350, 350);
                foreach (var prop in dictElement.Value)
                {
                    flowPanel.Controls.Add(new DataControlTabElement(prop.Name));
                }
                var singleTabPage = new TabPage(dictElement.Key);
                singleTabPage.Controls.Add(flowPanel);
                _internalTabs.Add(singleTabPage);
            }
        }


        public IList<TabPage> GetTabs()
        {
            return _internalTabs;
        }

    }
}
