using System;
using Xunit;
using DataStructures.Array.Generic;
using System.Collections.Generic;

namespace ArrayTests
{
    public class GenericArrayTests
    {
        private Array<char> _array;
        public GenericArrayTests()
        {
            // for IEnumerable<T>
            _array = new Array<char>(new List<char>() { 's', 'a', 'm', 'i' });
        }

        [Theory]
        [InlineData(16)]
        [InlineData(32)]
        [InlineData(64)]
        [InlineData(50)]
        public void DefaultSize_Test(int defaultSize)
        {
            // Act
            var arr = new Array<char>(defaultSize);

            // Assert
            Assert.Equal(arr.Length, defaultSize);
        }

        [Fact]
        public void Params_Test()
        {
            // Act
            var arr = new Array<int>(1, 2, 3, 4, 5);

            // Asert
            Assert.Equal(5, arr.Length);
        }

        [Fact]
        public void GetValue_Test()
        {
            // Act
            var value = _array.GetValue(0);

            //Assert
            Assert.Equal('s', value);
            Assert.IsType<char>(value);
            Assert.IsType(typeof(char), value);
            Assert.True(value is char);
        }

        [Fact]
        public void SetValue_Test()
        {
            // Act
            _array.SetValue('W', 0);

            // Assert
            Assert.Equal('W', _array.GetValue(0));

        }

        [Fact]
        public void Array_Clone_Test()
        {
            // Arrange
            var array = new DataStructures.Array.Generic.Array<int>(1, 2, 3);

            // Act
            var clonedArray = array.Clone() as DataStructures.Array.Generic.Array<int>;   // Boxing , object to array

            // Assert
            Assert.NotNull(clonedArray);
            Assert.Equal(clonedArray.Length, array.Length); // to show Length, we made Boxing
            Assert.NotEqual(clonedArray.GetHashCode(), array.GetHashCode());  // like a Adress
            Assert.IsType<DataStructures.Array.Generic.Array<int>>(clonedArray);

            //Assert.NotEqual(clonedArray , array); // this if we don't add IEnumerable to class
            //Assert.Equal(clonedArray, array);  // this if we ad IEnumerable to class

        }

        [Fact]
        public void Array_GetEnumerator_Test()
        {
            // This test to be sure if loop work (foreach)
            // Arrange
            var array = new Array<int>(1, 2, 3);

            // Act
            string s = "";
            foreach (var item in array)
            {
                s += item;
            }

            // Assert
            Assert.Equal("123", s);
        }

        [Fact]
        public void IndexOf_Test()
        {
            // Arrange
            var _arrayList = new Array<string>();

            _arrayList.Add("a");
            _arrayList.Add("b");
            _arrayList.Add("c");
            _arrayList.Add("b");

            // Act
            var result = _arrayList.IndexOf("b");

            // Assert
            Assert.Equal(1, result); // 3 wrong because the first b is 1
        }


    }

}
