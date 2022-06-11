using Xunit;

namespace ArrayTests
{
    public class ArrayTests
    {
        // Here we will make 4 test
        [Theory]
        [InlineData(5)]     // 1.test
        [InlineData(32)]
        [InlineData(64)]
        [InlineData(126)]   // 4.test
        public void Check_Default_Constructor_Test(int defualtSize)
        {
            // Arrange & Act
            var array = new DataStructures.Array.Array(defualtSize);

            // Assert
            Assert.Equal(defualtSize, array.Length);
        }


        [Fact]
        public void Check_Params_Constructor_Test()
        {
            // Arrange & Act
            var array = new DataStructures.Array.Array(1, 2, 3, 4);

            // Assert
            Assert.Equal(4, array.Length);

        }

        [Fact]
        public void GetAndSetValueTest()
        {
            // Arrange
            var array = new DataStructures.Array.Array();

            // Act
            array.SetValue(80, 2);
            array.SetValue(100, 3);

            // Assert
            Assert.Equal(80, array.GetValue(2));
            Assert.Equal(100, array.GetValue(3));

            Assert.Null(array.GetValue(5));

        }


        [Fact]
        public void ArrayCloneTest()
        {
            // Arrange
            var array = new DataStructures.Array.Array(1, 2, 3);

            // Act
            var clonedArray = array.Clone() as DataStructures.Array.Array;   // Boxing , object to array

            // Assert
            Assert.NotNull(clonedArray);
            Assert.Equal(clonedArray.Length, array.Length); // to show Length we made Boxing
            Assert.NotEqual(clonedArray.GetHashCode(), array.GetHashCode());  // like a Adress
            Assert.IsType<DataStructures.Array.Array>(clonedArray);

            //Assert.NotEqual(clonedArray , array); // this if we don't add IEnumerable to class
            //Assert.Equal(clonedArray, array);  // this if we add IEnumerable to class

        }


        [Fact]
        public void ArrayGetEnumeratorTest()
        {
            // This test to be sure if loop work (foreach)
            // Arrange
            var array = new DataStructures.Array.Array(1, 2, 3);

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
            var _arrayList = new DataStructures.Array.Array();

            _arrayList.SetValue("a", 0);
            _arrayList.SetValue("b", 1);
            _arrayList.SetValue("c", 2);
            _arrayList.SetValue("b", 3);

            // Act
            var result = _arrayList.IndexOf("b");

            // Assert
            Assert.Equal(1, result); // 3 wrong because the first b is 1
        }

    }

}
