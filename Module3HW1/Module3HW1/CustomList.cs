using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module3HW1.Comparer;

namespace Module3HW1
{
    public class CustomList<T> : IList<T>
    {
        private T[] _items;
        private int _size;
        private IComparer<T> _comparer;

        public CustomList()
        {
            _items = new T[4];
            _size = 4;
            _comparer = new CustomListComparer<T>();
        }

        public CustomList(int n)
        {
            _items = new T[n];
            _size = n;
            _comparer = new CustomListComparer<T>();
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return _items.IsReadOnly;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index > _size - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                return _items[index];
            }
            set
            {
                if (index > _size - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                _items[index] = value;
            }
        }

        public int IndexOf(T item)
        {
            for (var i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Add(T item)
        {
            for (var i = 0; i < _items.Length; i++)
            {
                var full = 0;
                if (_items[i].Equals(default(T)))
                {
                    _items[i] = item;
                    break;
                }
                else
                {
                    full++;
                }

                if (full == _size - 1)
                {
                    var tempItems = new T[_size];
                    for (var j = 0; j < _items.Length; j++)
                    {
                        tempItems[j] = _items[j];
                    }

                    _items = new T[_size * 2];

                    for (var j = 0; j <= tempItems.Length; j++)
                    {
                        _items[j] = tempItems[j];
                        if (j == tempItems.Length)
                        {
                            _items[j] = item;
                        }
                    }
                }
            }
        }

        public void AddRange(CustomList<T> items)
        {
            var empty = 0;
            for (var i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(default(T)))
                {
                    empty++;
                }
            }

            for (var i = 0; i < _items.Length; i++)
            {
                if (empty == items.Count && i - empty >= 0)
                {
                    i = i - empty;
                    foreach (var item in items)
                    {
                        _items[i] = item;
                    }
                }
                else
                {
                    var tempItems = new T[_size];
                    for (var j = 0; j < tempItems.Length; j++)
                    {
                        tempItems[j] = _items[j];
                    }

                    _items = new T[_size * 2];

                    for (var j = 0; j < tempItems.Length; j++)
                    {
                        _items[j] = tempItems[j];
                    }

                    for (var j = tempItems.Length; j < items.Count; j++)
                    {
                        if (j == tempItems.Length)
                        {
                            foreach (var item in items)
                            {
                                _items[j] = item;
                            }
                        }
                    }
                }
            }
        }

        public bool Remove(T item)
        {
            for (var i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(item))
                {
                    _items[i] = default(T);
                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index > _items.Length - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                _items[index] = default(T);
            }
        }

        public void Sort()
        {
            for (var i = 0; i < _items.Length; i++)
            {
                for (var j = i; j < _items.Length; j++)
                {
                    if (_comparer.Compare(_items[i], _items[j]) == 1)
                    {
                        (_items[i], _items[j]) = (_items[j], _items[i]);
                    }
                }
            }
        }

        public void Clear()
        {
            for (var i = 0; i < _items.Length; i++)
            {
                _items[i] = default(T);
            }
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (var i = 0; i < _items.Length; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public void CopyTo(T[] items, int index)
        {
        }

        public void Insert(int index, T item)
        {
        }
    }
}
