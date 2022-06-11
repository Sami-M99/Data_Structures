using System;
using System.Collections;

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

        /** ICloneable **/
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /** IEnumerable **/
        // this to able make a loop(for) in ConsoleApp
        public IEnumerator GetEnumerator()
        {
            /* Print Array from first to last */
            // return InnerArray.GetEnumerator();
            return new CustomArrayEnumerator(InnerArray);

            /* Or Print it from last to first */
            // return  new CustomArrayEnumeratorX(InnerArray);
        }

        public int IndexOf(Object value)
        {
            for (int i = 0; i < InnerArray.Length; i++)
            {
                if (GetValue(i).Equals(value))
                    return i;
            }
            return -1; // O(n)
        }

    }

    public class CustomArrayEnumerator : IEnumerator
    {
        private Object[] _array;
        int index;

        public CustomArrayEnumerator(Object[] SourceArray)
        {
            _array = SourceArray;
            index = -1;
        }

        public object Current => _array[index];

        public bool MoveNext()
        {
            if (index < _array.Length - 1) // here -1 because we made index++ for after
            {
                index++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            index = -1;
        }
    }

    public class CustomArrayEnumeratorX : IEnumerator
    {
        Object[] _array;
        int index;
        public CustomArrayEnumeratorX(Object[] SourceArray)
        {
            _array = SourceArray;
            index = SourceArray.Length;
        }

        public object Current => _array[index];

        public bool MoveNext()
        {
            if (index > 0)
            {
                index--;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            index = _array.Length;
        }

    }

}
