using System;
using ValueAndReferenceType;
using Xunit;

namespace ValueAndReferenceTypeTests
{
    public class ValueAndReferenceTypeTest
    {
        [Fact]
        public void ReferenceTypeTest()
        {
            // Arrange
            var ref1 = new ReferenceType();
            ref1.X = 1;
            ref1.Y = 2;

            // Act
            var ref2 = ref1;
            ref2.X = 3;

            // Assert
            Assert.Equal(ref1, ref2);
            Assert.Equal(ref1.X, ref2.X);  // 3 , 3
        }

        [Fact]
        public void ValueTypeTest()
        {
            // Arrange
            var v1 = new ValueAndReferenceType.ValueType()   // Because it has => System.ValueType();
            {
                X = 1,
                Y = 2
            };

            // Act
            var v2 = v1;
            v2.X = 3;

            // Assert
            Assert.NotEqual(v1, v2);
            Assert.NotEqual(v1.X, v2.X);  // 1 , 3
        }

        [Fact]
        public void RecordTypeTest()
        {
            // Arrange
            var r1 = new RecordType(5, 14);

            // Act
            var r2 = new RecordType(5, 14);
            // // r2.X = 50; we can't make like this, because we can't change a value after insert it 

            // Assert
            Assert.Equal(r1, r2);

        }

        [Fact]
        public void ReferenceTypeTest2()
        {
            // Arrange & Act
            var r1 = new ReferenceType()
            {
                X = 5,
                Y = 10
            };

            var r2 = new ReferenceType()
            {
                X = 5,
                Y = 10
            };


            // Assert
            Assert.NotEqual(r1, r2);  /**** If it's Value Type, will be Equal ***/


        }
    }
}
