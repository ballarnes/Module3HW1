using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module3HW1.Comparer;

namespace Module3HW1
{
    public class CustomList<T>
    {
        private T[] _items;
        private int _size;

        public CustomList()
        {
            _items = new T[4];
            _size = 4;
        }

        public CustomList(int n)
        {
            _items = new T[n];
            _size = n;
        }

        public int Count
        {
            get
            {
                return _size;
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
                if (_items[i].Equals(default(T)))
                {
                    _items[i] = (T)item;
                    break;
                }
            }
        }

        public void AddRange(CustomList<T> items)
        {
            int count = items.GetCount();
            var tempList = new CustomList<T>(count);
            for (var i = 0; i < count; i++)
            {
                tempList[i] = items[i];
            }

            int index = GetSpace(count);
            for (var i = index; i < index + count; i++)
            {
                _items[i] = tempList[i - index];
            }
        }

        public bool Remove(T item)
        {
            for (var i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(item))
                {
                    RemoveAt(IndexOf(_items[i]));
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
                for (var i = index + 1; i < _items.Length; i++)
                {
                    _items[i - 1] = _items[i];
                    if (i == _items.Length - 1)
                    {
                        _items[i] = default(T);
                    }
                }
            }
        }

        public void Sort()
        {
            Array.Sort(_items, new CustomListComparer<T>());
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

        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < _items.Length; i++)
            {
                yield return _items[i];
            }
        }

        public int GetCount()
        {
            int count = 0;
            for (var i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(default(T)))
                {
                    i++;
                }
                else
                {
                    count++;
                }
            }

            return count;
        }

        public int GetSpace(int size)
        {
            var space = 0;
            for (var i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(default(T)))
                {
                    space++;
                }
                else
                {
                    i++;
                }
            }

            if (space < size)
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

                return tempItems.Length;
            }
            else if (space >= size)
            {
                for (var i = 0; i < _items.Length; i++)
                {
                    if (_items[i].Equals(default(T)))
                    {
                        return IndexOf(_items[i]);
                    }
                }
            }

            return -1;
        }
    }
}
