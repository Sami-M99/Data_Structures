using DataStructures.LinkedList.DoublyLinkedList;
using System;
using Xunit;

namespace LinkedListTests
{
    public class DoublyLinkedListTests
    {
        private DoublyLinkedList<int> _list { get; set; }
        public DoublyLinkedListTests()
        {
            // Arrange
            // 30 -> 20 -> 10
            _list = new DoublyLinkedList<int>(new int[] { 10, 20, 30 });
        }

        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        [InlineData(0)]
        [InlineData(810)]
        [InlineData(77)]
        public void AddFirst_Test(int value)
        {
            // Act
            _list.AddFirst(value);

            // Assert
            Assert.Equal(_list.Head.Value, value);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        [InlineData(0)]
        [InlineData(810)]
        [InlineData(77)]
        public void AddLast_Test(int value)
        {
            // Act
            _list.AddLast(value);

            // Assert
            Assert.Equal(_list.Tail.Value, value);

            Assert.Collection(_list,
                item => Assert.Equal(item, 30),
                item => Assert.Equal(item, 20),
                item => Assert.Equal(item, 10),
                item => Assert.Equal(item, value)
                );
        }

        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        [InlineData(0)]
        [InlineData(810)]
        [InlineData(77)]
        public void AddBefore_Test(int value)
        {
            // Act
            // 30 [value] 20  10 
            _list.AddBefore(_list.Head.Next, value);

            // Assert
            Assert.Collection(_list,
                item => Assert.Equal(item, 30),
                item => Assert.Equal(item, value),
                item => Assert.Equal(item, 20),
                item => Assert.Equal(item, 10)
                );
        }

        [Fact]
        public void AddBefore_Exception_Test()
        {
            // Act
            var node = new DbNode<int>(55);

            // Assert
            Assert.Throws<ArgumentException>(() => _list.AddBefore(node, 77));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        [InlineData(0)]
        [InlineData(810)]
        [InlineData(77)]
        public void AddAfter_Test(int value)
        {
            // Act
            // 30  20 [value]  10 
            _list.AddAfter(_list.Head.Next, value);

            // Assert
            Assert.Collection(_list,
                item => Assert.Equal(item, 30),
                item => Assert.Equal(item, 20),
                item => Assert.Equal(item, value),
                item => Assert.Equal(item, 10)
                );
        }

        [Fact]
        public void AddAfter_Exception_Test()
        {
            // Act
            var node = new DbNode<int>(55);

            // Assert
            Assert.Throws<ArgumentException>(() => _list.AddAfter(node, 77));
        }

        [Fact]
        public void RemoveFirst_Test()
        {
            // Act
            var result1 = _list.RemoveFirst();
            var result2 = _list.RemoveFirst();
            var result3 = _list.RemoveFirst();

            // Assert
            Assert.Equal(result1, 30);
            Assert.Equal(result2, 20);
            Assert.Equal(result3, 10);
        }


        [Fact]
        public void RemoveLastt_Test()
        {
            // Act
            var result = _list.RemoveLast();

            // Assert
            Assert.Collection(_list,
                item => Assert.Equal(item, 30),
                item => Assert.Equal(item, 20)
                );

            Assert.Equal(result, 10);
        }

        [Fact]
        public void Remove_Test()
        {
            // Act
            var result = _list.Remove(20);

            // Assert
            Assert.Collection(_list,
                item => Assert.Equal(item, 30),
                item => Assert.Equal(item, 10)
                );

            Assert.Equal(result, 20);
        }

        [Fact]
        public void ToList_Test()
        {
            // Act
            var list = _list.ToList();

            // Assert
            Assert.Collection(list,
                item => Assert.Equal(item, 30),
                item => Assert.Equal(item, _list.Head.Next.Value),  // 20
                item => Assert.Equal(item, _list.Tail.Value)        // 10
                );
        }
    }

}
