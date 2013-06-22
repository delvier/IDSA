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

        private const int filterCountLimit = 4;

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
            if (_activeFilterComponentsLst.Count <= filterCountLimit)
            {
                var newFilter = new FilterViewComponents();
                _activeFilterComponentsLst.Add(newFilter); // remember filters.


                newFilter.filterCmbb.DataSource = _presenter.GetFilters(); //fCmbb settings copy
                newFilter.filterCmbb.DisplayMember = FilterSelectComboBox.DisplayMember;
                
                newFilter.lowValue.Text = this.lowValue.Text; //txtBox settings copy.
                newFilter.highValue.Text = this.highValue.Text;

                // bind click event
                newFilter.deleteBtn.Click += new System.EventHandler(this.DeleteFilterBtn_Click);

                foreach (var fctrl in newFilter.filterCtrls)
                {
                    flowLayoutPanel1.Controls.Add(fctrl);
                }

                // this operation need to be done after cmb box is on the pannel.
                newFilter.filterCmbb.SelectedIndex = this.FilterSelectComboBox.SelectedIndex;

            }
        }

        // delete btn filter action
        private void DeleteFilterBtn_Click(object sender, EventArgs e)
        {
            Button callerBtn = (Button)sender;
            // find the caller cmponents.
            FilterViewComponents fcmps = findBtnFilterView(callerBtn);

            //delete control in panel
            foreach (var eControl in fcmps.filterCtrls)
                flowLayoutPanel1.Controls.Remove(eControl);
            
            //remove from active cmponents filter list
            _activeFilterComponentsLst.Remove(fcmps);
            
            //refresh panel
            flowLayoutPanel1.Refresh();
            
        }

        //enable us to easy find FilterViewComponentsObject.
        private FilterViewComponents findBtnFilterView (Button btn)
        {
            foreach (var cmp in _activeFilterComponentsLst)
            {
               int cnt = cmp.filterCtrls.Where(a => object.Equals(a, btn)).Count();
               if (cnt > 0)
               {
                   return cmp;
               }
            }
            return null;
        }

        private void scanBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Scanning gogogo");
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
