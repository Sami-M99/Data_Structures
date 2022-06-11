using System;

namespace DataStructures.Array
{
    public class Array
    {
        protected Object[] InnerArray { get; set; }

        public int Length => InnerArray.Length;

        public Array(int defaultsize = 16)
        {
            InnerArray = new Object[defaultsize];  // Fixed Size
        }

        public Array(params Object[] sourceArray) : this(sourceArray.Length) // to make reference to default condtructur to InnerArray
        {
            System.Array.Copy(sourceArray, InnerArray, InnerArray.Length);

            // // Or
            //for (int i = 0; i < sourceArray.Length; i++)
            //{
            //    InnerArray[i] = sourceArray[i];
            //}
        }

        public Object GetValue(int index)
        {
            if (!(index >= 0 && index < InnerArray.Length))
                throw new ArgumentOutOfRangeException("index");

            return InnerArray[index];
        }

        public void SetValue(Object value, int index)
        {
            if (!(index >= 0 && index < InnerArray.Length))
                throw new ArgumentOutOfRangeException("index");

            if (value == null)
                throw new ArgumentNullException("value");

            InnerArray[index] = value;
        }
    }
}
