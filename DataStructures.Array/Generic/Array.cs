using System;
using System.Collections;
using System.Collections.Generic;


namespace DataStructures.Array.Generic
{
    public class Array<T> : ICloneable, IEnumerable<T>
    {
        protected T[] InnerArray;
        public int Length => InnerArray.Length;

        public Array(int defaultsize = 2)
        {
            InnerArray = new T[defaultsize];
            position = 0;
        }

        public Array(params T[] SourceArray) : this(SourceArray.Length) // to make reference to default condtructur to InnerArray 
        {
            System.Array.Copy(SourceArray, InnerArray, SourceArray.Length);
        }

        public T GetValue(int index)
        {
            if (!(index >= 0 && index < InnerArray.Length))
                throw new ArgumentOutOfRangeException("index");

            return InnerArray[index];
        }

        public void SetValue(T value, int index)
        {
            if (!(index >= 0 && index < InnerArray.Length))
                throw new ArgumentOutOfRangeException("index");

            if (value == null)
                throw new ArgumentNullException("value");

            InnerArray[index] = value;
        }

        /** ICloneable  **/
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /** IEnumerable **/
        public IEnumerator<T> GetEnumerator()
        {
            return new CustomArrayEnumerator<T>(InnerArray);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < InnerArray.Length; i++)
            {
                if (GetValue(i).Equals(value))
                    return i;
            }
            return -1; // O(n)
        }


        /** * ArrayList Part * **/
        private int position;
        public int Count => position;

        public Array(IEnumerable<T> collection) : this() // if made :base() => Error 
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Add(T value)
        {
            if (position == Length)
            {
                DoubleArray();
            }

            if (position < Length)
            {
                //SetValue(value,position);
                InnerArray[position] = value;
                position++;
                return;
            }

            throw new Exception();
        }

        private void DoubleArray()
        {
            try
            {
                var temp = new T[InnerArray.Length * 2];
                System.Array.Copy(InnerArray, temp, InnerArray.Length);
                InnerArray = temp;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public T Remove()
        {
            if (position >= 0)
            {
                //var temp = new Object[position - 1];
                var temp = InnerArray[position - 1];
                position--;
                if (position == InnerArray.Length / 4)
                    HalfArray();
                return temp;
            }
            throw new Exception();
        }

        private void HalfArray()
        {
            try
            {
                var temp = new T[InnerArray.Length / 2];
                System.Array.Copy(InnerArray, temp, InnerArray.Length / 2);
                InnerArray = temp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }

    public class CustomArrayEnumerator<T> : IEnumerator<T>
    {
        private T[] _array;
        private int index;
        public CustomArrayEnumerator(T[] array)
        {
            _array = array;
            index = -1;
        }
        public T Current => _array[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _array = null;
        }

        public bool MoveNext()
        {
            if (index < _array.Length - 1)
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
}
