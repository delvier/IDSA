using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Data;
using IDSA.Models.Utilities;   //ToBindingList

namespace IDSA.Models
{
    public class ObservableListSource<T> : ObservableCollection<T>, IListSource 
        where T : class
    {
        private IBindingList _bindingList;

        bool IListSource.ContainsListCollection { get { return false; } }

        IList IListSource.GetList()
        {
            return _bindingList ?? (_bindingList = this.ToBindingList());
        }
    }
}
