
using System;
using Xunit;

namespace BinarySearchTests
{
    public class BinarySearchTests
    {
        private int[] _arr;
        public BinarySearchTests()
        {
            _arr = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
        }

        [Theory]
        [InlineData(0, 10)]
        [InlineData(1, 20)]
        [InlineData(2, 30)]
        [InlineData(3, 40)]
        [InlineData(4, 50)]
        [InlineData(5, 60)]
        [InlineData(6, 70)]
        [InlineData(7, 80)]
        [InlineData(8, 90)]
        public void BinarySearch_with_Iteration(int index, int value)
        {
            // Act
            var result = BinarySearch.BinarySearch.Search(_arr, value);

            // Assert
            Assert.Equal(result, index);
            Assert.Equal(_arr[result], value);
        }

        [Fact]
        public void BinarySearch_NotFound_Result_Test()
        {
            // Act
            var result = BinarySearch.BinarySearch.Search(_arr, 100);

            // Assert
            Assert.Equal(-1, result);

        }
    }

}
