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
using IDSA.Modules.DataScanner;

namespace IDSA.Views
{
    public partial class DataScanner : UserControl
    {
        private DataScannerPresenter _presenter;
        private IList<FilterViewComponents> _activeFilterComponentsLst;

        public DataScanner(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            _presenter = new DataScannerPresenter(this);
            eventAggregator.GetEvent<DatabaseCreatedEvent>().Subscribe(InitEvent);
            _activeFilterComponentsLst = new List<FilterViewComponents>();
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
            var newFilter = new FilterViewComponents();
            //newFilter.filterCtrls.Select( a => flowLayoutPanel1.Controls.Add(a))
            foreach (var element in newFilter.filterCtrls)
            {
                flowLayoutPanel1.Controls.Add(element);
            }
    
        }
    }
}

/* SELECT CTRLS OF THE TYPE AND DO SOME SELECTION OF THE TEXT ON IT 
 * CODE EXAMPALE SNIPPET */

//        List<content> rows = PlaceHolder_ForEntries.Controls.OfType<TextBox>()
//.Select(txt => new
//{
//    Txt = txt,
//    Number = new String(txt.ID.SkipWhile(c => !Char.IsDigit(c)).ToArray())
//})
//.GroupBy(x => x.Number)
//.Select(g => new content
//{
//    name = g.First(x => x.Txt.ID.StartsWith("TextBox_Name")).Txt.Text,
//    memberNo = g.First(x => x.Txt.ID.StartsWith("TextBox_MemberNo")).Txt.Text,
//    points = int.Parse(g.First(x => x.Txt.ID.StartsWith("TextBox_Points")).Txt.Text)
//})
//.ToList();
