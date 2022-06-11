using System;
using System.Collections.Generic;

namespace Sorting.Utilities
{
    public class CustomComparer<T> : IComparer<T>
    {
        private readonly bool isMax;
        private readonly IComparer<T> _comparer;

        public CustomComparer(SortDirection sortDirection, IComparer<T> comparer)
        {
            isMax = (sortDirection == SortDirection.Ascending);
            _comparer = comparer;
        }

        public int Compare(T? x, T? y)
        {
            return isMax ? privCompare(x, y) : privCompare(y, x);
        }

        private int privCompare(T x, T y)
        {
            return _comparer.Compare(x, y);
        }
    }

}
