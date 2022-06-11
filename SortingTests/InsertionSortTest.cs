﻿using Sorting;
using Sorting.Utilities;
using Xunit;

namespace SortingTests
{
    public class InsertionSortTest
    {
        private int[] _array;
        public InsertionSortTest()
        {
            _array = new int[] { 10, 20, 50, 30, 40 };
        }

        [Fact]
        public void Insertion_Sort_Test()
        {
            // Act
            InsertionSort.Insertion_Sort(_array);
            // Assert
            Assert.Collection(_array,
                item => Assert.Equal(10, _array[0]),
                item => Assert.Equal(20, _array[1]),
                item => Assert.Equal(30, _array[2]),
                item => Assert.Equal(40, _array[3]),
                item => Assert.Equal(50, _array[4])
            );
        }

        [Fact]
        public void Insertion_Sort_with_SortDirection_Test()
        {
            // Act
            InsertionSort.Insertion_Sort(_array, SortDirection.Descending);

            // Assert
            Assert.Collection(_array,
                item => Assert.Equal(50, _array[0]),
                item => Assert.Equal(40, _array[1]),
                item => Assert.Equal(30, _array[2]),
                item => Assert.Equal(20, _array[3]),
                item => Assert.Equal(10, _array[4])
            );
        }
    }

}
