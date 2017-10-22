using System;
using System.Collections.Generic;

namespace Assignment1
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int lastEmpty = 0;

        public IntegerList()
        {
            _internalStorage = new int[4];
        }

        public IntegerList(int initialSize)
        {
            _internalStorage = new int[initialSize];
        }

        public void Add(int item)
        {
            if (_internalStorage.Length < lastEmpty + 1)
            {
                int[] _oldIntStr = new int[_internalStorage.Length];
                for (int i = 0; i < lastEmpty; i++)
                {
                    _oldIntStr[i] = _internalStorage[i];
                }

                _internalStorage = new int[2 * (lastEmpty + 1)];

                for (int i = 0; i < lastEmpty; i++)
                {
                    _internalStorage[i] = _oldIntStr[i];
                }
            }
            _internalStorage[lastEmpty] = item;
            lastEmpty++;
        }

        public bool Remove(int item)
        {
            int index = IndexOf(item);

            if (index != -1)
            {
                RemoveAt(index);
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool RemoveAt(int index)
        {
            if (index >= lastEmpty || index < 0)
            {
                throw new IndexOutOfRangeException();

            }

            for (int i = index; i < lastEmpty - 1; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            lastEmpty--;
            return true;
        }

        public int GetElement(int index)
        {
            if (index >= lastEmpty || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return _internalStorage[index];
            }
        }

        public int IndexOf(int item)
        {
            int index = -1;

            for (int i = 0; i < lastEmpty; i++)
            {
                if (item == _internalStorage[i])
                {
                    index = i;
                    return index;
                }
            }

            return index;
        }

        public int Count
        {
            get
            {
                return lastEmpty;
            }
        }

        public void Clear()
        {
            _internalStorage = new int[4];
            lastEmpty = 0;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < lastEmpty; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
