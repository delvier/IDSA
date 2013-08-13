using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IDSA.Modules.DataScanner
{
    interface IFilterViewComponents
    {
        IList<Control> filterCtrls { get; set; }
        ComboBox filterCmbb { get; set; }
        Button deleteBtn { get; set; }
        TextBox lowValue { get; set; }
        TextBox highValue { get; set; }
    }

    public class FilterViewComponents : IFilterViewComponents
    {
        public IList<Control> filterCtrls { get; set; }
        public ComboBox filterCmbb { get; set; }
        public Button deleteBtn { get; set; }
        public TextBox lowValue { get; set; }
        public TextBox highValue { get; set; }

        public FilterViewComponents()
        {
            this.filterCtrls = new List<Control>();
            this.filterCmbb = new ComboBox();
            this.deleteBtn = new Button();
            this.lowValue = new TextBox();
            this.highValue = new TextBox();

            InitTextBoxSettings();
            InitBtnSettings();
            InitCmbBox();

            InitFilterComponentsList();
        }

        public void InitCmbBox()
        {
            var filprovider = new FilterListProvider();
            filterCmbb.DataSource = filprovider.GetFilters();
            filterCmbb.DisplayMember = "Name";
        }

        public void InitTextBoxSettings()
        {
            lowValue.Width = 60;
            highValue.Width = 60;
        }

        public void InitBtnSettings()
        {
            this.deleteBtn.Text = "Delete";
        }

        public void InitFilterComponentsList()
        {
            this.filterCtrls.Add(filterCmbb);
            this.filterCtrls.Add(lowValue);
            this.filterCtrls.Add(highValue);
            this.filterCtrls.Add(deleteBtn);
        }


    }
}
