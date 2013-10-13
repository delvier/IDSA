using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views.BasicViews;
using IDSA.Models.DataStruct;
using IDSA.Modules.CachedListContainer;
using Microsoft.Practices.ServiceLocation;

namespace IDSA.Presenters.BasicViewsPresenters
{
    public class MultiTabFinDataPresenter
    {
        private FinancialData _finData;
        private ICacheService _cache;
        //public IList<DataControlTabElement> _dataControlTabElements { get; set; }
        public MultiTabFinDataPresenter()
        {
            this._cache = ServiceLocator.Current.GetInstance<ICacheService>();
            _finData = new FinancialData();
            
            // pro !
            //finData = _cache.GetCompany("Relpol").Reports.First();
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