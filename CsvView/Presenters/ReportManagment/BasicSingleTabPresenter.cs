using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views.BasicViews;

namespace IDSA.Presenters.BasicViewsPresenters
{
    public class BasicSingleTabPresenter
    {
        public IList<DataControlTabElement> _dataControlTabElements { get; set; }
        public BasicSingleTabPresenter()
        {
            this._dataControlTabElements = new List<DataControlTabElement>();
        }
    }
}
