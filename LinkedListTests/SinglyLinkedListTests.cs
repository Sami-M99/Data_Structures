using DataStructures.LinkedList.SinglyLinkedList;
using System;
using Xunit;

namespace LinkedListTests
{
    public class SinglyLinkedListTests
    {
        public SinglyLinkedList<int> _list { get; set; }

        public SinglyLinkedListTests()
        {
            // 30 -> 20 -> 10
            _list = new SinglyLinkedList<int>(new int[] { 10, 20, 30 });

        }

        [Fact]
        public void Count_Test()
        {
            Assert.Equal(3, _list.Count);
        }

        [Fact]
        public void GetEnumerator_Test()
        {
            /* to make a loop for elements here , we had to call an IEnumerable<T> interface */
            Assert.Collection(_list,
                item => Assert.Equal(item, 30),
                item => Assert.Equal(item, 20),
                item => Assert.Equal(item, 10)
                );
        }

        [Theory]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(1)]
        [InlineData(9)]
        public void AddFirst_Test(int value)
        {
            // Act
            _list.AddFirst(value);

            // Assert
            Assert.Equal(_list.Head.Value, value);


            Assert.Collection(_list,
                item => Assert.Equal(item, value),
                item => Assert.Equal(item, 30),
                item => Assert.Equal(item, 20),
                item => Assert.Equal(item, 10)
                );

        }


        [Theory]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(1)]
        [InlineData(9)]
        public void AddLast_Test(int value)
        {
            // Act
            _list.AddLast(value);
            _list.AddLast(7);

            // Assert
            Assert.Collection(_list,
                item => Assert.Equal(item, 30),
                item => Assert.Equal(item, 20),
                item => Assert.Equal(item, 10),
                item => Assert.Equal(item, value),
                item => Assert.Equal(item, 7)
                );

        }

        [Theory]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(1)]
        [InlineData(9)]
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
        public void AddBefore_ArgumentException()
        {
            var node = new SinglyLinkedListNode<int>(50);

            // <Exception> because we make throw with this Exception in a method
            Assert.Throws<Exception>(() => _list.AddBefore(node, 40));
        }


        [Theory]
        [InlineData(6)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(1)]
        [InlineData(9)]
        public void AddAfter_Test(int value)
        {
            // Act
            // 30 [value] 20  10  
            _list.AddAfter(_list.Head, value);

            // Assert
            Assert.Collection(_list,
                item => Assert.Equal(item, 30),
                item => Assert.Equal(item, value),
                item => Assert.Equal(item, 20),
                item => Assert.Equal(item, 10)
                );
        }

        [Fact]
        public void AddAfter_ArgumentException()
        {
            var node = new SinglyLinkedListNode<int>(77);

            Assert.Throws<ArgumentException>(() => _list.AddAfter(node, 50));
        }

        [Fact]
        public void RemoveFirst_Test()
        {
            _list.RemoveFirst();

            Assert.Collection(_list,
                item => Assert.Equal(item, 20),
                item => Assert.Equal(item, 10)
                );
        }

        [Fact]
        public void RemoveFirst_Exception_Test()
        {
            _list.RemoveFirst();
            _list.RemoveFirst();
            _list.RemoveFirst();

            Assert.Throws<ArgumentNullException>(() => _list.RemoveFirst());

        }


        [Fact]
        public void RemoveLast_Test()
        {
            var result = _list.RemoveLast();

            Assert.Collection(_list,
                item => Assert.Equal(item, _list.Head.Value), // = 30
                item => Assert.Equal(item, 20)
                );

            Assert.Equal(10, result);
        }

        [Fact]
        public void Remove_Test()
        {
            var result = _list.Remove(20);

            Assert.Collection(_list,
                item => Assert.Equal(item, 30),
                item => Assert.Equal(item, 10)
                );

            Assert.Equal(20, result);
        }

        [Fact]
        public void Remove_Exception_Test()
        {
            Assert.Throws<ArgumentException>(() => _list.Remove(15));
        }

    }

}
