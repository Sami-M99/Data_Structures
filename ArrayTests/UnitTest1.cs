using System;
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
    }
}
