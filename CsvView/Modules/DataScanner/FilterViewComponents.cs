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
        public ComboBox filterCmbb {get;set;}
        public Button deleteBtn {get;set;}
        public TextBox lowValue {get;set;}
        public TextBox highValue { get; set; }
        
        public FilterViewComponents()
        {
            this.filterCtrls = new List<Control>();
            this.filterCmbb = new ComboBox();
            this.deleteBtn = new Button();
            this.lowValue = new TextBox();
            this.highValue = new TextBox();

            InitFilterComponentsList();
        }

        public void InitFilterComponentsList()
        {
            this.filterCtrls.Add(filterCmbb);
            this.filterCtrls.Add(deleteBtn);
            this.filterCtrls.Add(lowValue);
            this.filterCtrls.Add(highValue);
        }
        

    }
}
