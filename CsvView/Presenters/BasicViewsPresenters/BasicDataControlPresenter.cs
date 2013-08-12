using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Views.BasicViews;
using IDSA.Models;
using IDSA.Models.DataStruct;
using IDSA.Modules.CachedListContainer;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel;

namespace IDSA.Presenters.BasicViewsPresenters
{
    public interface IBasicDataControlPresenter
    {
        IBindingList GetCompanyCacheData();
    }

    class BasicDataControlPresenter : IBasicDataControlPresenter
    {
        private BasicDataControl _view;
        private readonly ICacheService _cache;

        public BasicDataControlPresenter(BasicDataControl view)
        {
            this._view = view;
            this._cache = ServiceLocator.Current.GetInstance<ICacheService>();
        }

        public IBindingList GetCompanyCacheData()
        {
            return _cache.GetAllInBindingList();
        }
    }
}
