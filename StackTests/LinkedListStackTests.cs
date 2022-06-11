using DataStructures.Stack.Contracts;
using Xunit;

namespace StackTests
{
    public class LinkedListStackTests
    {
        private readonly IStack<char> _stack;
        public LinkedListStackTests()
        {
            _stack = new DataStructures.Stack.LinkedListStack<char>(new char[] { 'S', 'a', 'm', 'i' });  // i m a S

        }

        [Fact]
        public void Count_Test()
        {
            // Act
            var count = _stack.Count;

            // Assert
            Assert.Equal(4, count);
        }

        [Fact]
        public void Pop_Test()
        {
            // Act
            var pop = _stack.Pop();

            // Assert
            Assert.Equal('i', pop);
            Assert.Collection(_stack,
                item => Assert.Equal('m', item),
                item => Assert.Equal('a', item),
                item => Assert.Equal('S', item)
                );


        }

        [Theory]
        [InlineData('a')]
        [InlineData('u')]
        [InlineData('x')]
        [InlineData('w')]
        [InlineData('c')]
        public void Push_and_Peek_Test(char value)
        {
            // Act
            _stack.Push(value);

            //Assert
            Assert.Equal(value, _stack.Peek());
        }
    }

}
