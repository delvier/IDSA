using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views.BasicViews;
using IDSA.Models.DataStruct;

namespace IDSA.Presenters.BasicViewsPresenters
{
    public class MultiTabFinDataPresenter
    {
        private FinancialData _finData;
        //public IList<DataControlTabElement> _dataControlTabElements { get; set; }
        public MultiTabFinDataPresenter()
        {
            //this._dataControlTabElements = new List<DataControlTabElement>();
            _finData = new FinancialData();
        }


        public FinancialData GetFinData()
        {
            return _finData;
        }

        public void ChangeFinData()
        {
            _finData.Year = 1933;
        }
    }
}


// C:finData = base.props , C:balance, C:incomeStat. , C:cashFlow
// presenter : _finData => bind.IntoView.Components.

// V:finData => many TabElements. (boxField with label)