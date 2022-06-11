using System;
using System.Collections;
using System.Linq;

namespace DataStructures.Array
{
    /** We inherited everything in Array class **/
    public class ArrayList : DataStructures.Array.Array, IEnumerable
    {
        private int position;
        public int Count => position;  // Length for Array, but Count for List

        public ArrayList(int defaultSize = 2) : base(defaultSize)
        {
            position = 0;
        }

        public ArrayList(IEnumerable collection) : this()
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Add(object value)
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
                var temp = new object[InnerArray.Length * 2];
                System.Array.Copy(InnerArray, temp, InnerArray.Length);
                InnerArray = temp;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void RemoveEmptyIndex()
        {
            while (Count < Length / 2)
            {
                var temp = new object[Length / 2];
                System.Array.Copy(InnerArray, temp, Length / 2);
                InnerArray = temp;

                // //OR
                //System.Array.Resize(ref InnerArray, Length / 2);
            }
        }

        public Object Remove()
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
                var temp = new Object[InnerArray.Length / 2];
                System.Array.Copy(InnerArray, temp, InnerArray.Length / 2);
                InnerArray = temp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        new public IEnumerator GetEnumerator()  // we add -new- , because it had the same name in Array class 
        {
            // we use it for => ForEach_Test() when we use remove after added elements
            // Take() to return a specified number 
            return InnerArray.Take(position).GetEnumerator();
        }

    }

}
