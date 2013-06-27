using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDSA.Models;
using System.Collections;

namespace IDSA.Modules.CachedDataContainer
{
    public interface ICachedDataContainer
    {

    }

    public class CacheDataContainer<T> : IList<T>, ICachedDataContainer
    {
        public IList<T> _cacheLst = new List<T>();
        public CacheDataContainer(IList<T> cacheLst)
        {
            this._cacheLst = cacheLst;
        }
        public int IndexOf(T item)
        {
            return _cacheLst.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _cacheLst.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _cacheLst.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                return _cacheLst[index];
            }
            set
            {
                _cacheLst[index] = value;
            }
        }

        public void Add(T item)
        {
            _cacheLst.Add(item);
        }

        public void Clear()
        {
            _cacheLst.Clear();
        }

        public bool Contains(T item)
        {
            return _cacheLst.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _cacheLst.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _cacheLst.Count; }
        }

        public bool IsReadOnly
        {
            get { return _cacheLst.IsReadOnly; }
        }

        public bool Remove(T item)
        {
            return _cacheLst.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _cacheLst.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _cacheLst.GetEnumerator();
        }
    }

}
