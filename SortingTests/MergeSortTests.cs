using Sorting;
using Sorting.Utilities;
using Xunit;

namespace SortingTests
{
    public class MergeSortTests
    {
        private int[] _array;
        public MergeSortTests()
        {
            _array = new int[] { 10, 20, 50, 30, 40 };
        }

        [Fact]
        public void MergeSort_Test()
        {
            // Act
            MergeSort.Sort(_array);
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
        public void MergeSort_Test_with_SortDirection_Test()
        {
            // Act
            MergeSort.Merge_Sort(_array, 0, _array.Length - 1, SortDirection.Descending);
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

