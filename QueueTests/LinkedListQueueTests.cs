using DataStructures.Queue;
using Xunit;

namespace QueueTests
{
    public class LinkedListQueueTests
    {
        private LinkedListQueue<int> _queue;
        public LinkedListQueueTests()
        {
            _queue = new LinkedListQueue<int>(new int[] { 1, 2, 3 });  // 1 2 3 
        }

        [Fact]
        public void Count_Test()
        {
            // Act
            var count = _queue.Count;

            // Assert
            Assert.Equal(3, count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(25)]
        [InlineData(150)]
        [InlineData(33)]
        [InlineData(70)]
        public void Enqueue_Test(int value)
        {
            // Act
            _queue.Enqueue(value);

            // Assert
            Assert.Equal(4, _queue.Count);
            Assert.Collection(_queue,
                item => Assert.Equal(item, 1),
                item => Assert.Equal(item, 2),
                item => Assert.Equal(item, 3),
                item => Assert.Equal(item, value)
                );
        }

        [Fact]
        public void Dequeue_Test()
        {
            // Act
            var dequeue = _queue.Dequeue();

            // Assert
            Assert.Equal(2, _queue.Count);
            Assert.Equal(1, dequeue);

            Assert.Collection(_queue,
                item => Assert.Equal(item, 2),
                item => Assert.Equal(item, 3)
                );

        }

        [Fact]
        public void Peek_Test()
        {
            // Act
            var peek = _queue.Peek();

            // Assert
            Assert.Equal(1, peek);
        }

        [Fact]
        public void EmptyQueueException_Text()
        {
            // Act
            _queue.Dequeue();
            _queue.Dequeue();
            _queue.Dequeue();

            // Assert
            Assert.Throws<EmptyQueueException>(() => _queue.Dequeue());
        }

    }
}
