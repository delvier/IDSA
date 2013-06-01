using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

/* Code Source - ! */
/* http://www.codeproject.com/Articles/19867/How-To-Allow-To-Sort-By-Multiple-Columns-in-Custom */
namespace IDSA.Models.Utilities
{
public class MultipleSortableBindingListView<T> : BindingList<T>, IBindingListView
{
    private ListSortDescriptionCollection _SortDescriptions;

    private List<PropertyComparer<T>> comparers;

    public MultipleSortableBindingListView(BindingList<T> lst) : base(lst)
    {

    }

    public ListSortDescriptionCollection SortDescriptions
    {
        get { return _SortDescriptions; }
    }

    public bool SupportsAdvancedSorting
    {
        get { return true; }
    }

    private int CompareValuesByProperties(T x, T y)
    {
        if (x == null)
            return (y == null) ? 0 : -1;
        else
        {
            if (y == null)
                return 1;
            else
            {
                foreach (PropertyComparer<T> comparer in comparers)
                {
                    int retval = comparer.Compare(x, y);
                    if (retval != 0)
                        return retval;
                }
                return 0;
            }
        }

    }

    public void ApplySort(ListSortDescriptionCollection sorts)
    {
        // Get list to sort
        // Note: this.Items is a non-sortable ICollection<T>
        List<T> items = this.Items as List<T>;

        // Apply and set the sort, if items to sort
        if (items != null)
        {
            _SortDescriptions = sorts;
            comparers = new List<PropertyComparer<T>>();
            foreach (ListSortDescription sort in sorts)
                comparers.Add(new PropertyComparer<T>(sort.PropertyDescriptor,
                    sort.SortDirection));
            items.Sort(CompareValuesByProperties);
            //_isSorted = true;
        }
        else
        {
            //_isSorted = false;
        }

        this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
    }


    public string Filter
    {
        get
        {
            throw new NotImplementedException();
        }
        set
        {
            throw new NotImplementedException();
        }
    }

    public void RemoveFilter()
    {
        throw new NotImplementedException();
    }

    public bool SupportsFiltering
    {
        get { throw new NotImplementedException(); }
    }
}
}

