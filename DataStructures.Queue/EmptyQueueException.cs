using System;

namespace DataStructures.Queue
{
    public class EmptyQueueException : Exception
    {
        private string message;

        public EmptyQueueException(string message = "Queue is Empty") : base(message)
        {
        }

    }

}
