using DataStructures.Stack.Contracts;
using System;
using Xunit;

namespace StackTests
{
    public class ArrayStackTests
    {
        private readonly IStack<char> _stack;
        public ArrayStackTests()
        {
            _stack = new DataStructures.Stack.ArrayStack<char>(new char[] { 'S', 'a', 'm', 'i' });  // i m a S
            //_stack.Push('S');
            //_stack.Push('a');
            //_stack.Push('m');
            //_stack.Push('i');
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

            //////Assert.Collection(_stack,
            //////    item => Assert.Equal(item, 'm'),
            //////    item => Assert.Equal(item, 'a'),
            //////    item => Assert.Equal(item, 'S')
            //////    );
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
