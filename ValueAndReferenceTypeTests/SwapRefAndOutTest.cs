using ValueAndReferenceType;
using Xunit;

namespace ValueAndReferenceTypeTests
{
    public class SwapRefAndOutTest
    {
        [Fact]
        public void ReferenceSwapTest()
        {
            // Arrange
            int a = 5, b = 6;
            var refType = new ReferenceType();


            // Act
            refType.Swap(ref a, ref b);

            // Assert
            Assert.Equal(6, a);
            Assert.Equal(5, b);


        }

        [Fact]
        public void ValueSwapTest()
        {
            // Arrange
            int a = 5, b = 6;
            var valType = new ValueAndReferenceType.ValueType();


            // Act
            valType.Swap(a, b);

            // Assert
            Assert.Equal(5, a);
            Assert.Equal(6, b);


        }

        [Fact]
        public void CheckOutReferenceTest()
        {
            // Arrange
            int x = 44;
            var refType = new ReferenceType();

            // Act 
            refType.CheckOut(out x);

            // Assert
            Assert.NotEqual(44, x);  // x = 500
        }

        [Fact]
        public void CheckOutValueTest()
        {
            // Arrange
            int x = 44;
            var valType = new ValueAndReferenceType.ValueType();

            // Act 
            valType.CheckOut(x);

            // Assert
            Assert.Equal(44, x);
        }


    }
}
