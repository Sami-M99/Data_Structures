using System.Collections.Generic;
using Xunit;

namespace ArrayTests
{
    public class ArrayListTest
    {
        DataStructures.Array.ArrayList _arrayList;

        public ArrayListTest()
        {
            // Arrange
            _arrayList = new DataStructures.Array.ArrayList();
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(16)]
        [InlineData(50)]
        public void ArryList_Constructor_Test(int defaultSize)
        {
            // Arrange & Act
            var arrayList = new DataStructures.Array.ArrayList(defaultSize);

            // Assert
            Assert.Equal(arrayList.Length, defaultSize);
        }

        [Fact]
        public void ArrayList_Add_Test()
        {
            // Act
            for (int i = 0; i < 17; i++)
            {
                _arrayList.Add(i);
            }

            // Assert
            Assert.Equal(32, _arrayList.Length); // 32 because 17 > 16 for this we made a double array 16*2 = 32 
        }

        [Fact]
        public void ArrayList_RemoveEmptyIndex_Test()
        {
            // Arrange
            var arrayList = new DataStructures.Array.ArrayList(128);
            // Act
            for (int i = 0; i < 9; i++)
            {
                arrayList.Add(i);
            }

            arrayList.RemoveEmptyIndex();

            // Assert 
            Assert.Equal(16, arrayList.Length);

        }

        [Theory]
        [InlineData(32)]
        [InlineData(64)]
        [InlineData(128)]
        [InlineData(256)]
        [InlineData(512)]
        public void ArrayList_Remove_Test(int len)
        {
            // 
            for (int i = 0; i < len; i++)
            {
                _arrayList.Add(i);
            }

            Assert.Equal(len, _arrayList.Length);

            //
            for (int i = _arrayList.Length - 1; i > 8; i--)  // if make less than 8 like this i > 7 we change 32 to 16
            {
                _arrayList.Remove();
            }

            Assert.Equal(32, _arrayList.Length);
        }

        [Fact]
        public void ForEach_Test()
        {
            // Arrange
            _arrayList.Add("H");
            _arrayList.Add("e");
            _arrayList.Add("l");
            _arrayList.Add("l");
            _arrayList.Add("o");

            _arrayList.Remove();
            _arrayList.Remove();

            // Act
            string s = "";
            foreach (var item in _arrayList)
            {
                s += item;
            }

            // Assert
            Assert.Equal("Hel", s);

        }

        [Fact]
        public void ArrayList_Constructor_With_IEnumerable_Test()
        {
            // Arrange
            var list = new List<int> { 1, 2, 3, 10 };

            // Act
            var _arr = new DataStructures.Array.ArrayList(list);
            string s = "";
            foreach (var item in _arr)
            {
                s += item;
            }

            // assert
            Assert.Equal("12310", s);
        }

    }
}
